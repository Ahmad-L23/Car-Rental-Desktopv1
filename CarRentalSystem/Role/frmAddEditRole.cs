using CarRentalBusiness;
using System;
using System.Windows.Forms;

namespace CarRentalSystem.Role
{
    public partial class frmAddEditRole : Form
    {
        private int? roleId;
        private FormMode currentMode;

        private enum FormMode
        {
            Add,
            Edit
        }

        public frmAddEditRole(int? roleId = null)
        {
            InitializeComponent();
            this.roleId = roleId;

            currentMode = roleId.HasValue ? FormMode.Edit : FormMode.Add;
            SetupForm();
        }

        private void SetupForm()
        {
            if (currentMode == FormMode.Add)
            {
                this.Text = "Add New Role";
                btnSave.Text = "Add";
            }
            else
            {
                this.Text = "Edit Role";
                btnSave.Text = "Save";
                LoadRoleData();
            }
        }

        private void LoadRoleData()
        {
            if (!roleId.HasValue)
                return;

            var role = ClsRole.FindById(roleId.Value);
            if (role == null)
            {
                MessageBox.Show("Role not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtNameEn.Text = role.NameEn;
            txtNameAr.Text = role.NameAr;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nameEn = txtNameEn.Text.Trim();
            string nameAr = txtNameAr.Text.Trim();

            if (string.IsNullOrEmpty(nameEn))
            {
                MessageBox.Show("Please enter the English name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameEn.Focus();
                return;
            }

            if (string.IsNullOrEmpty(nameAr))
            {
                MessageBox.Show("Please enter the Arabic name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameAr.Focus();
                return;
            }

            ClsRole role = currentMode == FormMode.Add
                ? new ClsRole()
                : ClsRole.FindById(roleId.Value);

            role.NameEn = nameEn;
            role.NameAr = nameAr;

            bool saved = role.Save();

            if (saved)
            {
                MessageBox.Show("Role saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
