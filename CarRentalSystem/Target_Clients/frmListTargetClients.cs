using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.Target_Clients
{
    public partial class frmListTargetClients : Form
    {
        private DataTable targetClientsTable;

        public frmListTargetClients()
        {
            InitializeComponent();
        }

        private void SetupDataGridView()
        {
            dgvTargetClients.AutoGenerateColumns = false;
            dgvTargetClients.Columns.Clear();

            // Hidden ID column
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "TargetClientID",
                Visible = false
            };
            dgvTargetClients.Columns.Add(colId);

            // Name column
            var colName = new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvTargetClients.Columns.Add(colName);
        }

        private void LoadTargetClients()
        {
            try
            {
                targetClientsTable = ClsTargetClient.GetAll();

                dgvTargetClients.Rows.Clear();

                foreach (DataRow row in targetClientsTable.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string name = row["Name"].ToString();

                    dgvTargetClients.Rows.Add(id, name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading target clients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvTargetClients.SelectedRows.Count == 0) return;

            int targetClientId = Convert.ToInt32(dgvTargetClients.SelectedRows[0].Cells["id"].Value);

            var frmEdit = new frmAddUpdateTargetClient(targetClientId);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                LoadTargetClients();
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvTargetClients.SelectedRows.Count == 0) return;

            int targetClientId = Convert.ToInt32(dgvTargetClients.SelectedRows[0].Cells["id"].Value);
            string targetClientName = dgvTargetClients.SelectedRows[0].Cells["Name"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the target client '{targetClientName}'?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClsTargetClient.Delete(targetClientId);
                    if (deleted)
                    {
                        MessageBox.Show("Target client deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTargetClients();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the target client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during deletion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvTargetClients_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvTargetClients.ClearSelection();
                dgvTargetClients.Rows[e.RowIndex].Selected = true;
                dgvTargetClients.CurrentCell = dgvTargetClients.Rows[e.RowIndex].Cells[1];
            }
        }

        private void BtnAddTargetClient_Click_1(object sender, EventArgs e)
        {
            var frmAdd = new frmAddUpdateTargetClient(null);
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                LoadTargetClients();
            }
            LoadTargetClients();
        }

        private void frmListTargetClients_Load_1(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadTargetClients();
        }
    }
}
