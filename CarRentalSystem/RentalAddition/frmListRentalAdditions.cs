using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalSystem.RentalAddition
{
    public partial class frmListRentalAdditions : Form
    {
        private DataTable rentalAdditionsTable;

        public frmListRentalAdditions()
        {
            InitializeComponent();

            // Form load event
            this.Load += frmListRentalAdditions_Load_1;
        }

        private void frmListRentalAdditions_Load_1(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadRentalAdditions();
        }

        private void SetupDataGridView()
        {
            dgvRentalAddition.AutoGenerateColumns = false;
            dgvRentalAddition.Columns.Clear();

            // Hidden ID column
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "RentalAdditionID",
                DataPropertyName = "RentalAdditionID",
                Visible = false
            };
            dgvRentalAddition.Columns.Add(colId);

            // Rental Name column
            var colRentalName = new DataGridViewTextBoxColumn
            {
                Name = "RentalName",
                HeaderText = "Rental Name",
                DataPropertyName = "RentalName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvRentalAddition.Columns.Add(colRentalName);

            // PaymentMethodID column (you can hide or show ID, or you can show name if joined)
            var colPaymentMethod = new DataGridViewTextBoxColumn
            {
                Name = "MethodName",
                HeaderText = "Payment Method Name",
                DataPropertyName = "MethodName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvRentalAddition.Columns.Add(colPaymentMethod);

            // Price column
            var colPrice = new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price",
                DataPropertyName = "Price",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            };
            dgvRentalAddition.Columns.Add(colPrice);

            // Rental Note column
            var colNote = new DataGridViewTextBoxColumn
            {
                Name = "RentalNote",
                HeaderText = "Note",
                DataPropertyName = "RentalNote",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvRentalAddition.Columns.Add(colNote);

            // IsActive column
            var colIsActive = new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Active",
                DataPropertyName = "IsActive",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };
            dgvRentalAddition.Columns.Add(colIsActive);
        }

        private void LoadRentalAdditions()
        {
            try
            {
                rentalAdditionsTable = ClsRentalAddition.GetRentalAdditionsDataTable();

                dgvRentalAddition.Rows.Clear();

                foreach (DataRow row in rentalAdditionsTable.Rows)
                {
                    int id = Convert.ToInt32(row["RentalAdditionID"]);
                    string rentalName = row["RentalName"].ToString();
                    string paymentMethodId = row["MethodName"].ToString();
                    decimal price = Convert.ToDecimal(row["Price"]);
                    string rentalNote = row["RentalNote"]?.ToString();
                    bool isActive = Convert.ToBoolean(row["IsActive"]);

                    dgvRentalAddition.Rows.Add(id, rentalName, paymentMethodId, price, rentalNote, isActive);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading rental additions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddRenAdd_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAddUpdateRentalAddition(null); 
            frmAdd.ShowDialog();
            
            LoadRentalAdditions();
            
        }
        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvRentalAddition.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a rental addition to edit.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idCell = dgvRentalAddition.SelectedRows[0].Cells["RentalAdditionID"];
            if (idCell == null || idCell.Value == null || string.IsNullOrWhiteSpace(idCell.Value.ToString()))
            {
                MessageBox.Show("Selected rental addition has invalid ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rentalAdditionId = Convert.ToInt32(idCell.Value);

            var frmEdit = new frmAddUpdateRentalAddition(rentalAdditionId);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                LoadRentalAdditions();
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvRentalAddition.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a rental addition to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idCell = dgvRentalAddition.SelectedRows[0].Cells["RentalAdditionID"];
            if (idCell == null || idCell.Value == null || string.IsNullOrWhiteSpace(idCell.Value.ToString()))
            {
                MessageBox.Show("Selected rental addition has invalid ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rentalAdditionId = Convert.ToInt32(idCell.Value);
            string rentalName = dgvRentalAddition.SelectedRows[0].Cells["RentalName"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the rental addition '{rentalName}'?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClsRentalAddition.DeleteRentalAddition(rentalAdditionId);
                    if (deleted)
                    {
                        MessageBox.Show("Rental addition deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRentalAdditions();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the rental addition.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during deletion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvRentalAddition_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvRentalAddition.ClearSelection();
                dgvRentalAddition.Rows[e.RowIndex].Selected = true;
                dgvRentalAddition.CurrentCell = dgvRentalAddition.Rows[e.RowIndex].Cells[1];
            }
        }

        
    }
}
