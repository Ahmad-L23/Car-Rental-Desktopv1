using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.CarTransfer
{
    public partial class frmListCarTransfer : Form
    {
        private DataTable carTransferTable;

        public frmListCarTransfer()
        {
            InitializeComponent();

            this.Load += FrmListCarTransfer_Load;

            dgvCarTrans.CellMouseDown += dgvCarTrans_CellMouseDown;

            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
        }

        private void FrmListCarTransfer_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCarTransfers();
        }

        private void SetupDataGridView()
        {
            dgvCarTrans.AutoGenerateColumns = false;
            dgvCarTrans.Columns.Clear();

            // TransferId hidden column
            var colTransferId = new DataGridViewTextBoxColumn
            {
                Name = "TransferId",
                DataPropertyName = "TransferId",
                Visible = false
            };
            dgvCarTrans.Columns.Add(colTransferId);

            // Transfer Reason
            var colReason = new DataGridViewTextBoxColumn
            {
                Name = "TransferReason",
                HeaderText = "Reason",
                DataPropertyName = "TransferReason",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvCarTrans.Columns.Add(colReason);

            // Plate Number (Car)
            var colPlateNumber = new DataGridViewTextBoxColumn
            {
                Name = "PlateNumber",
                HeaderText = "Plate Number",
                DataPropertyName = "PlateNumber",
                Width = 120
            };
            dgvCarTrans.Columns.Add(colPlateNumber);

            // Employee Name
            var colEmployeeName = new DataGridViewTextBoxColumn
            {
                Name = "EmployeeName",
                HeaderText = "Employee",
                DataPropertyName = "EmployeeName",
                Width = 150
            };
            dgvCarTrans.Columns.Add(colEmployeeName);

            // Exit Date
            var colExitDate = new DataGridViewTextBoxColumn
            {
                Name = "ExitDate",
                HeaderText = "Exit Date",
                DataPropertyName = "ExitDate",
                Width = 100
            };
            dgvCarTrans.Columns.Add(colExitDate);

            // Exit Branch Name
            var colExitBranchName = new DataGridViewTextBoxColumn
            {
                Name = "ExitBranchName",
                HeaderText = "Exit Branch",
                DataPropertyName = "ExitBranchName",
                Width = 150
            };
            dgvCarTrans.Columns.Add(colExitBranchName);

            // Transfer To Branch Name
            var colToBranchName = new DataGridViewTextBoxColumn
            {
                Name = "TransferToBranchName",
                HeaderText = "Transferred To",
                DataPropertyName = "TransferToBranchName",
                Width = 150
            };
            dgvCarTrans.Columns.Add(colToBranchName);

            // Status (show string)
            var colStatus = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            };
            dgvCarTrans.Columns.Add(colStatus);
        }

        private void LoadCarTransfers()
        {
            try
            {
                var carTransferTable = ClsCarTransfer.GetAllCarTransferSummary(); // This should return your joined DataTable

                dgvCarTrans.Rows.Clear();

                foreach (DataRow row in carTransferTable.Rows)
                {
                    int transferId = Convert.ToInt32(row["TransferId"]);
                    string reason = row["TransferReason"]?.ToString() ?? "";
                    string plateNumber = row["PlateNumber"]?.ToString() ?? "";
                    string employeeName = row["EmployeeName"]?.ToString() ?? "";
                    string exitDate = row["ExitDate"] == DBNull.Value ? "" : Convert.ToDateTime(row["ExitDate"]).ToShortDateString();
                    string exitBranchName = row["ExitBranchName"]?.ToString() ?? "";
                    string transferToBranchName = row["TransferToBranchName"]?.ToString() ?? "";
                    string status = StatusName(Convert.ToInt32(row["Status"]));

                    dgvCarTrans.Rows.Add(
                        transferId,
                        reason,
                        plateNumber,
                        employeeName,
                        exitDate,
                        exitBranchName,
                        transferToBranchName,
                        status
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading car transfers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string StatusName(int status) 
        {
            switch(status)
            {
                case 0:
                    return "Pending";
                   
                case 1:
                    return "Delivered";
               
                case 2:
                     return "InProgress";


                default:
                    return "Unkown";

            }
        }

        private void dgvCarTrans_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvCarTrans.ClearSelection();
                dgvCarTrans.Rows[e.RowIndex].Selected = true;
                dgvCarTrans.CurrentCell = dgvCarTrans.Rows[e.RowIndex].Cells[1]; // Set focus to a visible cell
            }
        }

        private void BtnAddCarTransfer_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAddUpdateCarTransfer(null); // null for new
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                LoadCarTransfers();
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCarTrans.SelectedRows.Count == 0) return;

            int transferId = Convert.ToInt32(dgvCarTrans.SelectedRows[0].Cells["TransferId"].Value);

            var frmEdit = new frmAddUpdateCarTransfer(transferId);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                LoadCarTransfers();
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCarTrans.SelectedRows.Count == 0) return;

            int transferId = Convert.ToInt32(dgvCarTrans.SelectedRows[0].Cells["TransferId"].Value);
            string reason = dgvCarTrans.SelectedRows[0].Cells["TransferReason"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the transfer reason: '{reason}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClsCarTransfer.Delete(transferId);
                    if (deleted)
                    {
                        MessageBox.Show("Car transfer deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCarTransfers();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the car transfer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting car transfer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddCarTrans_Click(object sender, EventArgs e)
        {
            frmAddUpdateCarTransfer frm = new frmAddUpdateCarTransfer();
            frm.ShowDialog();
            LoadCarTransfers();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCarTransferCard frm = new frmCarTransferCard();
            frm.ShowDialog();
        }
    }
}


 