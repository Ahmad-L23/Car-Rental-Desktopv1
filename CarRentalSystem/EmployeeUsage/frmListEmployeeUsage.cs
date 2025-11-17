using CarRentalBusiness;
using CarRentalSystem.EmployeeUsageForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.EmployeeUsage
{
    public partial class frmListEmployeeUsage : Form
    {
        private DataTable usageTable;

        public frmListEmployeeUsage()
        {
            InitializeComponent();

            // Form Load event
            this.Load += FrmListEmployeeUsage_Load;

            // DataGridView right-click event
            dgvEmpUsage.CellMouseDown += DgvEmpUsage_CellMouseDown;

            // Context menu event handlers
            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            dgvEmpUsage.CellFormatting += DgvEmpUsage_CellFormatting;

            // You can add an Add button event handler if needed
            // btnAddUsage.Click += BtnAddUsage_Click;
        }

        private void FrmListEmployeeUsage_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadEmployeeUsage();
        }

        private void SetupDataGridView()
        {
            dgvEmpUsage.AutoGenerateColumns = false;
            dgvEmpUsage.Columns.Clear();

            // UsageId hidden
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "UsageId",
                DataPropertyName = "UsageId",
                Visible = false
            };
            dgvEmpUsage.Columns.Add(colId);

            // Employee Name
            var colEmployee = new DataGridViewTextBoxColumn
            {
                Name = "EmployeeName",
                HeaderText = "Employee Name",
                DataPropertyName = "EmployeeName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvEmpUsage.Columns.Add(colEmployee);

            // Car Plate Number
            var colCarPlate = new DataGridViewTextBoxColumn
            {
                Name = "CarPlate",
                HeaderText = "Car Plate",
                DataPropertyName = "CarPlate",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvEmpUsage.Columns.Add(colCarPlate);

            // Car Group
            var colCarGroup = new DataGridViewTextBoxColumn
            {
                Name = "CarGroup",
                HeaderText = "Car Group",
                DataPropertyName = "CarGroup",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvEmpUsage.Columns.Add(colCarGroup);

            // Usage Reason
            var colReason = new DataGridViewTextBoxColumn
            {
                Name = "UsageReason",
                HeaderText = "Usage Reason",
                DataPropertyName = "UsageReason",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvEmpUsage.Columns.Add(colReason);

            // Exit Date
            var colExitDate = new DataGridViewTextBoxColumn
            {
                Name = "ExitDate",
                HeaderText = "Exit Date",
                DataPropertyName = "ExitDate",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = { Format = "yyyy-MM-dd HH:mm" }
            };
            dgvEmpUsage.Columns.Add(colExitDate);

            // Exit Branch
            var colExitBranch = new DataGridViewTextBoxColumn
            {
                Name = "BranchId",
                HeaderText = "Exit Branch",
                DataPropertyName = "ExitBranchName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvEmpUsage.Columns.Add(colExitBranch);

            // Status
            var colStatus = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvEmpUsage.Columns.Add(colStatus);
        }


        private void DgvEmpUsage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if this is the Status column
            if (dgvEmpUsage.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string statusText = e.Value.ToString();

                // Default colors
                Color foreColor = Color.Black;
                Color backColor = Color.White;

                switch (statusText)
                {
                    case "Pending":
                        backColor = Color.LightYellow;
                        foreColor = Color.DarkGoldenrod;
                        break;
                    case "Delivered":
                        backColor = Color.LightGreen;
                        foreColor = Color.DarkGreen;
                        break;
                    case "In Progress":
                        backColor = Color.LightSkyBlue;
                        foreColor = Color.DarkBlue;
                        break;
                    default:
                        backColor = Color.LightGray;
                        foreColor = Color.Black;
                        break;
                }

                e.CellStyle.BackColor = backColor;
                e.CellStyle.ForeColor = foreColor;
            }
        }

        private void LoadEmployeeUsage()
        {
            try
            {
                usageTable = ClsEmployeeUsage.GetEmployeeSummaryUsage();

                dgvEmpUsage.Rows.Clear();

                foreach (DataRow row in usageTable.Rows)
                {
                    int usageId = Convert.ToInt32(row["UsageId"]);
                    string employeeName = row["EmployeeName"].ToString();
                    string carPlate = row["PlateNumber"].ToString();
                    string carGroup = row["CarGroup"].ToString();
                    string usageReason = row["UsageReason"].ToString();
                    DateTime exitDate = Convert.ToDateTime(row["ExitDate"]);
                    string exitBranch = row["ExitBranchName"].ToString();
                    int status = Convert.ToInt32(row["Status"]);

                    dgvEmpUsage.Rows.Add(
                        usageId,
                        employeeName,
                        carPlate,
                        carGroup,
                        usageReason,
                        exitDate.ToString("yyyy-MM-dd HH:mm"),
                        exitBranch,
                        GetStatusString(status)
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load employee usage: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStatusString(int status)
        {
            switch (status)
            {
                case 0: return "Pending";
                case 1: return "Delivered";
                case 2: return "In Progress";
                default: return "Unknown";
            }
        }

        // Right-click to select row for context menu
        private void DgvEmpUsage_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvEmpUsage.ClearSelection();
                dgvEmpUsage.Rows[e.RowIndex].Selected = true;
                dgvEmpUsage.CurrentCell = dgvEmpUsage.Rows[e.RowIndex].Cells[1];
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEmpUsage.SelectedRows.Count == 0) return;

            int usageId = Convert.ToInt32(dgvEmpUsage.SelectedRows[0].Cells["UsageId"].Value);
            var frmEdit = new frmAddEditEmployeeUsage(usageId);
            frmEdit.ShowDialog();
                LoadEmployeeUsage();
            
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEmpUsage.SelectedRows.Count == 0) return;

            int usageId = Convert.ToInt32(dgvEmpUsage.SelectedRows[0].Cells["UsageId"].Value);
            string employeeName = dgvEmpUsage.SelectedRows[0].Cells["EmployeeName"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the usage record for '{employeeName}'?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClsEmployeeUsage.Delete(usageId);
                    if (deleted)
                    {
                        MessageBox.Show("Employee usage deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeUsage();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the employee usage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting employee usage: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditEmployeeUsage frm = new frmAddEditEmployeeUsage();
            frm.ShowDialog();
            LoadEmployeeUsage();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEmployeeUsageCardInfo frm = new frmEmployeeUsageCardInfo();
            frm.ShowDialog();
        }
    }
}
