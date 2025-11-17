using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.CompanyInsurance
{
    public partial class frmAddEditCompanyInsurance : Form
    {
        private int? _companyInsuranceId;
        private ClsCompanyInsurance _companyInsurance;

        public frmAddEditCompanyInsurance(int? companyInsuranceId = null)
        {
            InitializeComponent();
            _companyInsuranceId = companyInsuranceId;

            this.Load += FrmAddEditCompanyInsurance_Load;
        }

        private void FrmAddEditCompanyInsurance_Load(object sender, EventArgs e)
        {
            LoadInsuranceTypes();

            if (_companyInsuranceId.HasValue)
            {
                this.Text = "Edit Company Insurance";
                lblTitle.Text = "Edit Company Insurance";
                btnSave.Text = "Update";
                LoadCompanyInsuranceData(_companyInsuranceId.Value);
            }
            else
            {
                this.Text = "Add New Company Insurance";
                lblTitle.Text = "Add New Company Insurance";
                btnSave.Text = "Save";
            }
        }

        private void LoadInsuranceTypes()
        {
            DataTable dtInsuranceTypes = ClsInsuranceType.GetAllInsuranceTypes();

            cbInsuranceType.DisplayMember = "Name";
            cbInsuranceType.ValueMember = "InsuranceTypeID";
            cbInsuranceType.DataSource = dtInsuranceTypes;
            cbInsuranceType.SelectedIndex = -1;
        }

        private void LoadCompanyInsuranceData(int companyInsuranceId)
        {
            _companyInsurance = ClsCompanyInsurance.FindById(companyInsuranceId);

            if (_companyInsurance == null)
            {
                MessageBox.Show("Company Insurance not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtCompanyName.Text = _companyInsurance.InsuranceCompanyName;
            txtPhone.Text = _companyInsurance.Phone;
            txtEmail.Text = _companyInsurance.Email;
            cbInsuranceType.SelectedValue = _companyInsurance.InsuranceTypeID;
            chkIsActive.Checked = _companyInsurance.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the validation errors.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_companyInsuranceId.HasValue)
                _companyInsurance = ClsCompanyInsurance.FindById(_companyInsuranceId.Value);
            else
                _companyInsurance = new ClsCompanyInsurance();

            _companyInsurance.InsuranceCompanyName = txtCompanyName.Text.Trim();
            _companyInsurance.Phone = txtPhone.Text.Trim();
            _companyInsurance.Email = txtEmail.Text.Trim();
            _companyInsurance.IsActive = chkIsActive.Checked;

            if (cbInsuranceType.SelectedValue != null)
                _companyInsurance.InsuranceTypeID = Convert.ToInt32(cbInsuranceType.SelectedValue);

            bool success = _companyInsurance.Save();

            if (success)
            {
                MessageBox.Show("Company Insurance saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save Company Insurance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCompanyName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                errorProvider1.SetError(txtCompanyName, "Company name is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCompanyName, "");
            }
        }

        private void txtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(txtPhone.Text)) && !long.TryParse(txtPhone.Text, out _))
            {
                errorProvider1.SetError(txtPhone, "Enter a valid phone number.");
            }
            else
            {
                errorProvider1.SetError(txtPhone, "");
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (!IsValidEmail(email) && !string.IsNullOrEmpty(email))
            {
                errorProvider1.SetError(txtEmail, "Enter a valid email address.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
                e.Cancel = false;
            }

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void cbInsuranceType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbInsuranceType.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbInsuranceType, "Select an insurance type.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbInsuranceType, "");
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (like Backspace)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Allow only digits
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}
