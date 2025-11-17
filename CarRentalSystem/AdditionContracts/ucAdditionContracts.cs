using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.AdditionContracts
{
    public partial class ucAdditionContracts : UserControl
    {
        private DataTable additionContractsTable;

        public ucAdditionContracts()
        {
            InitializeComponent();
        }

        private void ucAdditionContracts_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadAdditionContracts();
        }

        private void SetupDataGridView()
        {
            dgvAdditionContracts.AutoGenerateColumns = false;
            dgvAdditionContracts.Columns.Clear();

            dgvAdditionContracts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvAdditionContracts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name",
            });

            dgvAdditionContracts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price",
                DataPropertyName = "Price",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
        }

        public void LoadAdditionContracts()
        {
            try
            {
                additionContractsTable = ClsAdditionContract.GetAdditionContractsDataTable();
                dgvAdditionContracts.DataSource = additionContractsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading addition contracts:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddAdditionContract_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAddEditAdditionContract();
            if (frmAdd.ShowDialog() == DialogResult.OK)
                LoadAdditionContracts();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAdditionContracts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvAdditionContracts.SelectedRows[0].Cells["id"].Value);

            using (var frm = new frmAddEditAdditionContract(id))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadAdditionContracts();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAdditionContracts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvAdditionContracts.SelectedRows[0].Cells["id"].Value);
            string name = dgvAdditionContracts.SelectedRows[0].Cells["Name"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Delete addition contract '{name}'?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (ClsAdditionContract.DeleteAdditionContract(id))
                {
                    MessageBox.Show("Addition contract deleted successfully.");
                    LoadAdditionContracts();
                }
                else
                {
                    MessageBox.Show("Failed to delete addition contract.");
                }
            }
        }

        private void dgvAdditionContracts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvAdditionContracts.ClearSelection();
                dgvAdditionContracts.Rows[e.RowIndex].Selected = true;
                dgvAdditionContracts.CurrentCell = dgvAdditionContracts.Rows[e.RowIndex].Cells[1];
            }
        }
    }
}
