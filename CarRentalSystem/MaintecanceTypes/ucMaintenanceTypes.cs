using CarRentalBusiness;
using CarRentalSystem.maintenance;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.MaintenanceTypes
{
    public partial class ucMaintenanceTypes : UserControl
    {
        private DataTable maintenanceTypesTable;

        public ucMaintenanceTypes()
        {
            InitializeComponent();
        }

        private void ucMaintenanceTypes_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadMaintenanceTypes();
        }

        private void SetupDataGridView()
        {
            dgvMaintenanceTypes.AutoGenerateColumns = false;
            dgvMaintenanceTypes.Columns.Clear();

            dgvMaintenanceTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "Id",  // adjust if your DB column name differs
                Visible = false
            });

            dgvMaintenanceTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name", // adjust as needed
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvMaintenanceTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MileageInterval",
                HeaderText = "Mileage Interval",
                DataPropertyName = "MileageInterval", // adjust as needed
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvMaintenanceTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Description",
                DataPropertyName = "Description", // adjust as needed
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvMaintenanceTypes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Active",
                DataPropertyName = "IsActive", // adjust as needed
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvMaintenanceTypes.CellFormatting += dgvMaintenanceTypes_CellFormatting;
        }

        private void dgvMaintenanceTypes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMaintenanceTypes.Columns[e.ColumnIndex].Name == "IsActive" && e.Value != null)
            {
                bool isActive;
                if (bool.TryParse(e.Value.ToString(), out isActive))
                {
                    e.Value = isActive ? "✔" : "❌";
                    e.CellStyle.ForeColor = isActive ? Color.Green : Color.Red;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Make font bigger for this cell
                    e.CellStyle.Font = new Font(dgvMaintenanceTypes.Font.FontFamily, 14, FontStyle.Bold);
                }
            }
        }



        public void LoadMaintenanceTypes()
        {
            try
            {
                maintenanceTypesTable = ClsMaintenanceType.GetMaintenanceTypesDataTable();
                dgvMaintenanceTypes.DataSource = maintenanceTypesTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading maintenance types:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddMaintenanceType_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAddUpdateMaintenanceType();
            frmAdd.ShowDialog();
                LoadMaintenanceTypes();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMaintenanceTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvMaintenanceTypes.SelectedRows[0].Cells["id"].Value);

            using (var frm = new frmAddUpdateMaintenanceType(id))
            {
                frm.ShowDialog();
                LoadMaintenanceTypes();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMaintenanceTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvMaintenanceTypes.SelectedRows[0].Cells["id"].Value);
            string name = dgvMaintenanceTypes.SelectedRows[0].Cells["Name"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Delete maintenance type '{name}'?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (ClsMaintenanceType.DeleteMaintenanceType(id))
                {
                    MessageBox.Show("Maintenance type deleted successfully.");
                    LoadMaintenanceTypes();
                }
                else
                {
                    MessageBox.Show("Failed to delete maintenance type.");
                }
            }
        }

        private void dgvMaintenanceTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvMaintenanceTypes.ClearSelection();
                dgvMaintenanceTypes.Rows[e.RowIndex].Selected = true;
                dgvMaintenanceTypes.CurrentCell = dgvMaintenanceTypes.Rows[e.RowIndex].Cells[1];
            }
        }
    }
}
