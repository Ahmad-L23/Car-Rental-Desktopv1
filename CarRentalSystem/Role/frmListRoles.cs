using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.Role
{
    public partial class frmListRoles : Form
    {
        private DataTable rolesTable;

        public frmListRoles()
        {
            InitializeComponent();
        }

        

        private void SetupDataGridView()
        {
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.Columns.Clear();

            // Hidden ID column
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "id",
                Visible = false
            };
            dgvRoles.Columns.Add(colId);

            // English Name column
            var colNameEn = new DataGridViewTextBoxColumn
            {
                Name = "NameEn",
                HeaderText = "Name (English)",
                DataPropertyName = "NameEn",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvRoles.Columns.Add(colNameEn);

            // Arabic Name column
            var colNameAr = new DataGridViewTextBoxColumn
            {
                Name = "NameAr",
                HeaderText = "Name (Arabic)",
                DataPropertyName = "NameAr",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvRoles.Columns.Add(colNameAr);
        }

        private void LoadRoles()
        {
            try
            {
                rolesTable = ClsRole.GetAllRoles();

                dgvRoles.Rows.Clear();

                foreach (DataRow row in rolesTable.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string nameEn = row["NameEn"].ToString();
                    string nameAr = row["NameAr"].ToString();

                    dgvRoles.Rows.Add(id, nameEn, nameAr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading roles: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmListRoles_Load_1(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadRoles();
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 0) return;

            int roleId = Convert.ToInt32(dgvRoles.SelectedRows[0].Cells["id"].Value);
            string roleName = dgvRoles.SelectedRows[0].Cells["NameEn"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the role '{roleName}'?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClsRole.DeleteRole(roleId);
                    if (deleted)
                    {
                        MessageBox.Show("Role deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRoles();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during deletion: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 0) return;

            int roleId = Convert.ToInt32(dgvRoles.SelectedRows[0].Cells["id"].Value);

            var frmEdit = new frmAddEditRole(roleId);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                LoadRoles();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAddEditRole(null);
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                LoadRoles();
            }
        }

        private void dgvRoles_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvRoles.ClearSelection();
                dgvRoles.Rows[e.RowIndex].Selected = true;
                dgvRoles.CurrentCell = dgvRoles.Rows[e.RowIndex].Cells[1];
            }
        }
    }
}
