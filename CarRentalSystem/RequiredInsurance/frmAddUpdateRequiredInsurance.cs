using CarRentalBusiness;
using System;
using System.Windows.Forms;

namespace CarRentalSystem.RequiredInsurance
{
    public partial class frmAddUpdateRequiredInsurance : Form
    {
        private enum enFormMode { AddNew, Update }
        private enFormMode mode;
        private ClsRequiredInsurance currentRequiredInsurance;

        // Constructor for Add New
        public frmAddUpdateRequiredInsurance()
        {
            InitializeComponent();
            mode = enFormMode.AddNew;
            currentRequiredInsurance = new ClsRequiredInsurance();
            InitializeForm();
        }

        // Constructor for Update
        public frmAddUpdateRequiredInsurance(int requiredInsuranceId)
        {
            InitializeComponent();
            mode = enFormMode.Update;

            currentRequiredInsurance = ClsRequiredInsurance.FindById(requiredInsuranceId);
            if (currentRequiredInsurance == null)
            {
                MessageBox.Show("Required Insurance not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            InitializeForm();
            LoadRequiredInsurance(currentRequiredInsurance);
        }

        private void InitializeForm()
        {
            if (mode == enFormMode.AddNew)
            {
                lblTitle.Text = "Add New Required Insurance";
                this.Text = "Add New Required Insurance";
                btnSave.Text = "Add";
            }
            else
            {
                lblTitle.Text = "Update Required Insurance";
                this.Text = "Update Required Insurance";
                btnSave.Text = "Update";
            }
        }

        private void LoadRequiredInsurance(ClsRequiredInsurance insurance)
        {
            txtItemName.Text = insurance.ItemName;
            numPrice.Value = insurance.Price > numPrice.Maximum ? numPrice.Maximum : insurance.Price;
        }

        private void txtItemName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string name = txtItemName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                errorProvider1.SetError(txtItemName, "Item name is required.");
                e.Cancel = true;
            }
            else if (mode == enFormMode.AddNew && ClsRequiredInsurance.IsItemNameExist(name))
            {
                errorProvider1.SetError(txtItemName, "This item already exists.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtItemName, "");
            }
        }

        private void numPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (numPrice.Value <= 0)
            {
                errorProvider1.SetError(numPrice, "Price must be greater than zero.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(numPrice, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            currentRequiredInsurance.ItemName = txtItemName.Text.Trim();
            currentRequiredInsurance.Price = numPrice.Value;

            bool saved = currentRequiredInsurance.Save();

            if (saved)
            {
                MessageBox.Show(
                    mode == enFormMode.AddNew
                        ? "Required Insurance added successfully!"
                        : "Required Insurance updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save Required Insurance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateRequiredInsurance_Load(object sender, EventArgs e)
        {

        }
    }
}
