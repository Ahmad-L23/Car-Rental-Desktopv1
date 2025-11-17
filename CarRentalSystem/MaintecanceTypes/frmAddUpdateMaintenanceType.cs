using CarRentalBusiness;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarRentalSystem.maintenance
{
    public partial class frmAddUpdateMaintenanceType : Form
    {
        private enum enFormMode { AddNew, Update }
        private enFormMode mode;
        private ClsMaintenanceType currentMaintenanceType;

        // Constructor for Add New
        public frmAddUpdateMaintenanceType()
        {
            InitializeComponent();
            mode = enFormMode.AddNew;
            currentMaintenanceType = new ClsMaintenanceType();
            InitializeForm();
        }

        // Constructor for Update - pass id to load data
        public frmAddUpdateMaintenanceType(int maintenanceTypeID)
        {
            InitializeComponent();
            mode = enFormMode.Update;

            currentMaintenanceType = ClsMaintenanceType.FindById(maintenanceTypeID);
            if (currentMaintenanceType == null)
            {
                MessageBox.Show("Maintenance Type not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            
            InitializeForm();
            loadMaintenaceType(currentMaintenanceType);
        }

        private void InitializeForm()
        {
            if (mode == enFormMode.AddNew)
            {
                this.Text = "Add New Maintenance Type";
                lblTitle.Text = "Add New Maintenance Type";
                btnAddNew.Visible = true;

                txtName.ReadOnly = false;
            }
            else
            {
                this.Text = "Update Maintenance Type";
                lblTitle.Text = "Update Maintenance Type";
                btnAddNew.Text = "Update";
                btnAddNew.Visible = true;

                txtName.ReadOnly = true; // prevent changing name in update for example
            }
        }

        private void loadMaintenaceType(ClsMaintenanceType maintenanceType)
        {
            txtName.Text = maintenanceType.Name;
            numMileageInterval.Value = maintenanceType.MileageInterval;
            txtDescription.Text = maintenanceType.Description;
            chkIsActive.Checked = maintenanceType.IsActive;
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mode == enFormMode.Update)
            {
                errorProvider1.SetError(txtName, "");
                return; // Skip validation in update mode
            }

            string input = txtName.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(txtName, "Name is required.");
                e.Cancel = true;
            }
            else if (ClsMaintenanceType.Exists(input))
            {
                errorProvider1.SetError(txtName, "This name already exists. Please choose another.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }
        }

        private void numMileageInterval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (numMileageInterval.Value <= 0)
            {
                errorProvider1.SetError(numMileageInterval, "Mileage Interval must be greater than zero.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(numMileageInterval, "");
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            currentMaintenanceType.Name = txtName.Text.Trim();
            currentMaintenanceType.MileageInterval = (int)numMileageInterval.Value;
            currentMaintenanceType.Description = txtDescription.Text.Trim();
            currentMaintenanceType.IsActive = chkIsActive.Checked;

            bool saved = currentMaintenanceType.Save();

            if (saved)
            {
                MessageBox.Show("Maintenance Type added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add Maintenance Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateMaintenanceType_Load(object sender, EventArgs e)
        {

        }
    }
}
