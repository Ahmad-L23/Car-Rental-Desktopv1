using CarRentalBusiness;
using System;
using System.Windows.Forms;

namespace CarRentalSystem.Users
{
    public partial class frmAddEditUser : Form
    {
        private int? userId;
        private FormMode currentMode;

        private enum FormMode
        {
            Add,
            Edit
        }

        public frmAddEditUser(int? userId = null)
        {
            InitializeComponent();
            this.userId = userId;

            currentMode = userId.HasValue ? FormMode.Edit : FormMode.Add;

            LoadComboboxes();
            SetupForm();
        }

        private void LoadComboboxes()
        {
            // Example: load nationalities
            cmbNationlity.DisplayMember = "nationality_name_en";
            cmbNationlity.ValueMember = "id";
            cmbNationlity.DataSource = ClsNationlity.GetAllNationalities();

            cmbRole.DisplayMember = "NameEn";
            cmbRole.ValueMember = "Id";
            cmbRole.DataSource = ClsRole.GetAllRoles();

            cmbBranch.DisplayMember = "name";
            cmbBranch.ValueMember = "branch_id";
            cmbBranch.DataSource = ClsBranch.GetBranchesDataTable();
        }

        private void SetupForm()
        {
            if (currentMode == FormMode.Add)
            {
                this.Text = "Add New User";
                btnSave.Text = "Add";
                lblTitle.Text = "Add New User";
            }
            else
            {
                this.Text = "Edit User";
                btnSave.Text = "Save";
                lblTitle.Text = "Edit User";

                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            if (!userId.HasValue)
                return;

            var user = ClsUser.FindById(userId.Value);
            if (user == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtNamen.Text = user.NameEn;
            txtNameAr.Text = user.NameAr;
            txtUserName.Text = user.UserName;
            txtEmail.Text = user.Email;
            txtPasswrod.Text = user.Password;
            txtEmpNum.Text = user.EmployeeNumber;
            txtNatioalID.Text = user.NationalId;

            if (user.Nationality != null)
                cmbNationlity.SelectedValue = user.Nationality.Id;

            if (user.Role != null)
                cmbRole.SelectedValue = user.Role.Id;

            if (user.Branch != null)
                cmbBranch.SelectedValue = user.Branch.BranchId;

            txtlicenseNumber.Text = user.LicenseNumber;

            if (user.LicenseExpiryDate.HasValue)
                Licnsedtp.Value = user.LicenseExpiryDate.Value;

            txtPrimaryPhoneNumber.Text = user.PrimaryPhoneNumber;
            txtPhoneSecondey.Text = user.SecondaryPhoneNumber;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!ValidateChildren()) return;
            // Validation
            if (string.IsNullOrWhiteSpace(txtNamen.Text))
            {
                MessageBox.Show("Please enter the English name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNameAr.Text))
            {
                MessageBox.Show("Please enter the Arabic name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameAr.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Please enter the user name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPasswrod.Text))
            {
                MessageBox.Show("Please enter the password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswrod.Focus();
                return;
            }

            ClsUser user = currentMode == FormMode.Add
                ? new ClsUser()
                : ClsUser.FindById(userId.Value);

            user.NameEn = txtNamen.Text.Trim();
            user.NameAr = txtNameAr.Text.Trim();
            user.UserName = txtUserName.Text.Trim();
            user.Email = txtEmail.Text.Trim();
            user.Password = txtPasswrod.Text; // TODO: hash before saving
            user.EmployeeNumber = txtEmpNum.Text.Trim();
            user.NationalId = txtNatioalID.Text.Trim();

            // ✅ Get selected IDs from combo boxes
            if (cmbNationlity.SelectedValue != null)
                user.nationalityId = Convert.ToInt32(cmbNationlity.SelectedValue);

            if (cmbRole.SelectedValue != null)
                user.roleId = Convert.ToInt32(cmbRole.SelectedValue);

            if (cmbBranch.SelectedValue != null)
                user.branchId = Convert.ToInt32(cmbBranch.SelectedValue);

            user.LicenseNumber = txtlicenseNumber.Text.Trim();
            user.LicenseExpiryDate = Licnsedtp.Value.Date;
            user.PrimaryPhoneNumber = txtPrimaryPhoneNumber.Text.Trim();
            user.SecondaryPhoneNumber = txtPhoneSecondey.Text.Trim();

            bool saved = user.Save();

            if (saved)
            {
                MessageBox.Show("User saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string userName = txtUserName.Text.Trim();

         
            errorProvider1.SetError(txtUserName, string.Empty);

            if (string.IsNullOrWhiteSpace(userName))
            {
                errorProvider1.SetError(txtUserName, "Username is required.");
                e.Cancel = true; 
                return;
            }

         
            bool userExists = false;
            if (currentMode == FormMode.Add)
            {
                userExists = ClsUser.isuserExist(userName);
            }
            else if (currentMode == FormMode.Edit)
            {
                
                userExists = ClsUser.isuserExist(userName);
            }

            if (userExists)
            {
                errorProvider1.SetError(txtUserName, "This username already exists. Please choose another one.");
                e.Cancel = true;
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string email = txtEmail.Text.Trim();

            
            errorProvider1.SetError(txtEmail, string.Empty);

           
            if (string.IsNullOrWhiteSpace(email))
            {
                errorProvider1.SetError(txtEmail, "Email is required.");
                e.Cancel = true;
                return;
            }

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
            {
                errorProvider1.SetError(txtEmail, "Please enter a valid email address.");
                e.Cancel = true; 
            }
        }
        private void txtPrimaryPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block the character
            }
        }

        private void txtPhoneSecondey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block the character
            }
        }

        private void txtNatioalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block the character
            }
        }

        private void txtlicenseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block the character
            }
        }
    }
}
