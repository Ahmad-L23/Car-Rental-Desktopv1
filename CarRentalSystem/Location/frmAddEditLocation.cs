using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.Location
{
    public partial class frmAddEditLocation : Form
    {
        private int? locationId = null; // null means add new
        private ClsLocation currentLocation;

        public frmAddEditLocation(int? locationId = null)
        {
            InitializeComponent();

            this.locationId = locationId;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            LoadBranches();

            if (locationId.HasValue)
            {
                LoadLocationData(locationId.Value);
                this.Text = "Edit Location";
            }
            else
            {
                this.Text = "Add Location";
                currentLocation = new ClsLocation(); // new instance for add
            }
        }

        private void LoadBranches()
        {
            DataTable dtBranches = ClsBranch.GetBranchesDataTable();

            cmbBranches.DataSource = dtBranches;
            cmbBranches.DisplayMember = "name";
            cmbBranches.ValueMember = "branch_id";

            if (dtBranches.Rows.Count > 0)
                cmbBranches.SelectedIndex = 0;
        }

        private void LoadLocationData(int id)
        {
            currentLocation = ClsLocation.FindById(id);

            if (currentLocation == null)
            {
                MessageBox.Show("Location not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            txtLocationName.Text = currentLocation.LocationName;
            cmbBranches.SelectedValue = currentLocation.BranchId;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string locationName = txtLocationName.Text.Trim();

            if (string.IsNullOrEmpty(locationName))
            {
                MessageBox.Show("Please enter a location name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbBranches.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a branch.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int branchId = Convert.ToInt32(cmbBranches.SelectedValue);

            // Update currentLocation object
            currentLocation.LocationName = locationName;
            currentLocation.BranchId = branchId;

            // Call Save() method in your BLL to handle add or update
            bool success = currentLocation.Save();

            if (success)
            {
                MessageBox.Show("Location saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
