using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.Users
{
    public partial class frmListUsers : Form
    {
        private DataTable _dt;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            try
            {
                _dt = ClsUser.GetUsersDataTable();

                dgvUsers.DataSource = _dt;

                // Hide technical columns by their actual names
                if (dgvUsers.Columns.Contains("UserId"))
                    dgvUsers.Columns["UserId"].Visible = false;
                if (dgvUsers.Columns.Contains("Password"))
                    dgvUsers.Columns["Password"].Visible = false; // Hide passwords
                if (dgvUsers.Columns.Contains("RoleId"))
                    dgvUsers.Columns["RoleId"].Visible = false;
                if (dgvUsers.Columns.Contains("BranchId"))
                    dgvUsers.Columns["BranchId"].Visible = false;
                if (dgvUsers.Columns.Contains("NationalityId"))
                    dgvUsers.Columns["NationalityId"].Visible = false;
                if (dgvUsers.Columns.Contains("UpdatedAt"))
                    dgvUsers.Columns["UpdatedAt"].Visible = false;
                if (dgvUsers.Columns.Contains("createdat"))
                    dgvUsers.Columns["createdat"].Visible = false;

                // Rename headers for clarity with exact column names
                if (dgvUsers.Columns.Contains("NameEn"))
                    dgvUsers.Columns["NameEn"].HeaderText = "Name (EN)";
                if (dgvUsers.Columns.Contains("NameAr"))
                    dgvUsers.Columns["NameAr"].HeaderText = "Name (AR)";
                if (dgvUsers.Columns.Contains("UserName"))
                    dgvUsers.Columns["UserName"].HeaderText = "Username";
                if (dgvUsers.Columns.Contains("Email"))
                    dgvUsers.Columns["Email"].HeaderText = "Email";
                if (dgvUsers.Columns.Contains("EmployeeNumber"))
                    dgvUsers.Columns["EmployeeNumber"].HeaderText = "Employee #";
                if (dgvUsers.Columns.Contains("NationalId"))
                {
                    dgvUsers.Columns["NationalId"].Visible = true;
                    dgvUsers.Columns["NationalId"].HeaderText = "National ID";
                }
                if (dgvUsers.Columns.Contains("LicenseNumber"))
                    dgvUsers.Columns["LicenseNumber"].HeaderText = "License #";
                if (dgvUsers.Columns.Contains("LicenseExpiryDate"))
                    dgvUsers.Columns["LicenseExpiryDate"].HeaderText = "License Expiry";
                if (dgvUsers.Columns.Contains("PrimaryPhoneNumber"))
                    dgvUsers.Columns["PrimaryPhoneNumber"].HeaderText = "Phone (Primary)";
                if (dgvUsers.Columns.Contains("SecondaryPhoneNumber"))
                    dgvUsers.Columns["SecondaryPhoneNumber"].HeaderText = "Phone (Secondary)";


                // Clear selection by default
                if (dgvUsers.Rows.Count > 0)
                    dgvUsers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private int? GetSelectedUserId()
        {
            if (dgvUsers.CurrentRow != null)
            {
                object val = dgvUsers.CurrentRow.Cells["UserId"].Value;
                if (val != null && int.TryParse(val.ToString(), out int id))
                    return id;
            }
            return null;
        }

        private void dgvUsers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvUsers.ClearSelection();
                dgvUsers.Rows[e.RowIndex].Selected = true;
                dgvUsers.CurrentCell = dgvUsers.Rows[e.RowIndex].Cells[0];
            }
        }

        private void frmListUsers_Load_1(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int? userId = GetSelectedUserId();
            if (userId == null)
            {
                MessageBox.Show("Please select a user to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new frmAddEditUser(userId.Value))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadUsers();
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int? userId = GetSelectedUserId();
            if (userId == null)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool deleted = ClsUser.DeleteUser(userId.Value);
                if (deleted)
                    LoadUsers();
                else
                    MessageBox.Show("Failed to delete the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFinduser_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtFinduser.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                dgvUsers.DataSource = _dt; // show full list if empty search
                dgvUsers.ClearSelection();
                return;
            }

            string filterColumn = "";

            if (cmbFindBy.SelectedItem != null)
            {
                string selected = cmbFindBy.SelectedItem.ToString();

                if (selected == "Find by Employee name")
                {
                    filterColumn = "UserName"; // or "NameEn" depending on your data
                }
                else if (selected == "find by Employee number")
                {
                    filterColumn = "EmployeeNumber"; // note: no spaces in column names
                }
            }

            if (string.IsNullOrEmpty(filterColumn))
            {
                dgvUsers.DataSource = _dt;
                dgvUsers.ClearSelection();
                return;
            }

            DataView dv = new DataView(_dt);
            dv.RowFilter = $"{filterColumn} LIKE '%{searchText}%'";

            dgvUsers.DataSource = dv;

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.ClearSelection();
                dgvUsers.Rows[0].Selected = true;
                dgvUsers.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            using (var frmAdd = new frmAddEditUser())
            {
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();                 }
            }
        }
    }
}
