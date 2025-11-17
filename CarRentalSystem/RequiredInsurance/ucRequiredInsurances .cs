using CarRentalBusiness;
using CarRentalSystem.RequiredInsurance;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.RequiredInsurances
{
    public partial class ucRequiredInsurances : UserControl
    {
        private DataTable requiredInsurancesTable;

        public ucRequiredInsurances()
        {
            InitializeComponent();
        }

        private void ucRequiredInsurances_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadRequiredInsurances();
        }

        private void SetupDataGridView()
        {
            dgvRequiredInsurances.AutoGenerateColumns = false;
            dgvRequiredInsurances.Columns.Clear();

            dgvRequiredInsurances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvRequiredInsurances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "ItemName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvRequiredInsurances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Description",
                DataPropertyName = "Price",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

    
        }

        public void LoadRequiredInsurances()
        {
            try
            {
                requiredInsurancesTable = ClsRequiredInsurance.GetAllInsurance();
                dgvRequiredInsurances.DataSource = requiredInsurancesTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading required insurances:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddRequiredInsurance_Click(object sender, EventArgs e)
        {
            var frm = new frmAddUpdateRequiredInsurance();
            frm.ShowDialog();
            LoadRequiredInsurances();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvRequiredInsurances.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvRequiredInsurances.SelectedRows[0].Cells["id"].Value);

            using (var frm = new frmAddUpdateRequiredInsurance(id))
            {
                frm.ShowDialog();
                LoadRequiredInsurances();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvRequiredInsurances.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvRequiredInsurances.SelectedRows[0].Cells["id"].Value);
            string name = dgvRequiredInsurances.SelectedRows[0].Cells["Name"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete '{name}'?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (ClsRequiredInsurance.Delete(id))
                {
                    MessageBox.Show("Required insurance deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRequiredInsurances();
                }
                else
                {
                    MessageBox.Show("Failed to delete required insurance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvRequiredInsurances_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvRequiredInsurances.ClearSelection();
                dgvRequiredInsurances.Rows[e.RowIndex].Selected = true;
                dgvRequiredInsurances.CurrentCell = dgvRequiredInsurances.Rows[e.RowIndex].Cells[1];
            }
        }
    }
}
