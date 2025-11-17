using CarRentalBusiness;
using System;
using System.Windows.Forms;

namespace CarRentalSystem.Coverge
{
    public partial class frmAddUpdateCoverge : Form
    {
        private int? _covergeId;
        private ClsCoverage _coverge;

        public frmAddUpdateCoverge(int? covergeId = null)
        {
            InitializeComponent();
            _covergeId = covergeId;

            if (_covergeId.HasValue)
            {
                this.Text = "Edit Coverge";
                lblTitle.Text = "Edit Coverge";
                btnSave.Text = "Update";
                LoadCovergeData(_covergeId.Value);
            }
            else
            {
                this.Text = "Add New Coverge";
                lblTitle.Text = "Add New Coverge";
                btnSave.Text = "Save";
            }
        }

        private void LoadCovergeData(int covergeId)
        {
            _coverge = ClsCoverage.FindById(covergeId);

            if (_coverge == null)
            {
                MessageBox.Show("Coverge not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtName.Text = _coverge.CoverageName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the validation errors.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtName.Text.Trim();

            if (_covergeId.HasValue)
                _coverge = ClsCoverage.FindById(_covergeId.Value);
            else
                _coverge = new ClsCoverage();

            _coverge.CoverageName = name;

            bool success = _coverge.Save();

            if (success)
            {
                MessageBox.Show("Coverge saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save Coverge.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Name is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }
        }
    }
}
