using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.Target_Clients
{
    public partial class ucTargetClients : UserControl
    {
        private DataTable targetClientsTable;

        public ucTargetClients()
        {
            InitializeComponent();
        }

        private void ucTargetClients_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadTargetClients();
        }

        private void SetupDataGridView()
        {
            dgvTargetClients.AutoGenerateColumns = false;
            dgvTargetClients.Columns.Clear();

            dgvTargetClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvTargetClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        public void LoadTargetClients()
        {
            try
            {
                targetClientsTable = ClsTargetClient.GetAll();
                dgvTargetClients.DataSource = targetClientsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading target clients:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddTargetClient_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAddUpdateTargetClient(null);
            frmAdd.ShowDialog();
            LoadTargetClients();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTargetClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvTargetClients.SelectedRows[0].Cells["id"].Value);

            using (var frm = new frmAddUpdateTargetClient(id))
            {
                frm.ShowDialog();                
                LoadTargetClients();
                
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTargetClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvTargetClients.SelectedRows[0].Cells["id"].Value);
            string name = dgvTargetClients.SelectedRows[0].Cells["Name"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Delete target client '{name}'?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (ClsTargetClient.Delete(id))
                {
                    MessageBox.Show("Client deleted successfully.");
                    LoadTargetClients();
                }
                else
                    MessageBox.Show("Failed to delete client.");
            }
        }

        private void dgvTargetClients_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvTargetClients.ClearSelection();
                dgvTargetClients.Rows[e.RowIndex].Selected = true;
                dgvTargetClients.CurrentCell = dgvTargetClients.Rows[e.RowIndex].Cells[1];
            }
        }
    }
}
