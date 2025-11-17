using CarRentalBusiness;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CarRentalSystem.mediator
{
    public partial class frmAddUpdateMeditor : Form
    {
        enum enFormMode { AddNew, Update }
        private enFormMode mode;
        private ClsMediator currentMediator;

        // Constructor for Add New
        public frmAddUpdateMeditor()
        {
            InitializeComponent();
            mode = enFormMode.AddNew;
            currentMediator = new ClsMediator();
            InitializeForm();
        }

        // Constructor for Update - pass mediator id to load
        public frmAddUpdateMeditor(int mediatorId)
        {
            InitializeComponent();
            mode = enFormMode.Update;

            if (!ClsMediator.GetMediatorInfoById(mediatorId, out currentMediator))
            {
                MessageBox.Show("Mediator not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            InitializeForm();
        }

        private void InitializeForm()
        {
            if (mode == enFormMode.AddNew)
            {
                this.Text = "Add New Mediator";
                lblTitle.Text = "Add New Mediator";
                btnAddNew.Visible = true;
                btnUpdate.Visible = false;

                // Editable in AddNew mode
                txtNameEn.ReadOnly = false;
                txtNameAr.ReadOnly = false;
            }
            else
            {
                this.Text = "Update Mediator";
                lblTitle.Text = "Update Mediator";
                btnAddNew.Visible = false;
                btnUpdate.Visible = true;

                // Read-only in Update mode
                txtNameEn.ReadOnly = true;
                txtNameAr.ReadOnly = true;
            }

            // Bind data to controls
            txtNameEn.Text = currentMediator.EnglishName;
            txtNameAr.Text = currentMediator.ArabicName;
            txtEmail.Text = currentMediator.Email;
            numPercentage.Value = (decimal)currentMediator.Precentage;
            txtPhone.Text = currentMediator.PhoneNumber;
            chkIsActive.Checked = currentMediator.isActive;
        }

        private void txtNameEn_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mode == enFormMode.Update)
            {
                // Skip validation in update mode
                errorProvider1.SetError(txtNameEn, "");
                return;
            }

            string pattern = @"^[A-Za-z\s]+$"; // English letters and spaces allowed
            string input = txtNameEn.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(txtNameEn, "English Name is required.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(input, pattern))
            {
                errorProvider1.SetError(txtNameEn, "Only English letters and spaces are allowed.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNameEn, "");
            }
        }

        private void txtNameAr_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mode == enFormMode.Update)
            {
                // Skip validation in update mode
                errorProvider1.SetError(txtNameAr, "");
                return;
            }

            string pattern = @"^[\u0600-\u06FF\s]+$"; // Arabic letters and spaces allowed
            string input = txtNameAr.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(txtNameAr, "Arabic Name is required.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(input, pattern))
            {
                errorProvider1.SetError(txtNameAr, "Only Arabic letters and spaces are allowed.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNameAr, "");
            }
        }

        private void numPercentage_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (numPercentage.Value <= 0)
            {
                errorProvider1.SetError(numPercentage, "Percentage must be greater than zero.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(numPercentage, "");
            }
        }

        
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false; // Always allow form to close even if validation errors exist
        }

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            currentMediator.EnglishName = txtNameEn.Text.Trim();
            currentMediator.ArabicName = txtNameAr.Text.Trim();
            currentMediator.Email = txtEmail.Text.Trim();
            currentMediator.Precentage = (double)numPercentage.Value;
            currentMediator.PhoneNumber = txtPhone.Text.Trim();
            currentMediator.isActive = chkIsActive.Checked;

            bool saved = currentMediator.Save();

            if (saved)
            {
                MessageBox.Show("Mediator added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add mediator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            currentMediator.EnglishName = txtNameEn.Text.Trim();
            currentMediator.ArabicName = txtNameAr.Text.Trim();
            currentMediator.Email = txtEmail.Text.Trim();
            currentMediator.Precentage = (double)numPercentage.Value;
            currentMediator.PhoneNumber = txtPhone.Text.Trim();
            currentMediator.isActive = chkIsActive.Checked;

            bool updated = currentMediator.Save();

            if (updated)
            {
                MessageBox.Show("Mediator updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update mediator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
