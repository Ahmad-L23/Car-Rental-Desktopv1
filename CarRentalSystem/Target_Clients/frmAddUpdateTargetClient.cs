using CarRentalBusiness;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarRentalSystem.Target_Clients
{
    public partial class frmAddUpdateTargetClient : Form
    {
        private int? _targetClientId;
        private ClsTargetClient _targetClient;

        public frmAddUpdateTargetClient(int? targetClientId = null)
        {
            InitializeComponent();
            _targetClientId = targetClientId;

            if (_targetClientId.HasValue)
            {
                this.Text = "Edit Target Client";
                lblTitle.Text = "Edit Target Client";
                btnSave.Text = "Update";
                LoadTargetClientData(_targetClientId.Value);
            }
            else
            {
                this.Text = "Add New Target Client";
                lblTitle.Text = "Add New Target Client";
                btnSave.Text = "Save";
            }
        }

        private void LoadTargetClientData(int targetClientId)
        {
            _targetClient = ClsTargetClient.FindById(targetClientId);

            if (_targetClient == null)
            {
                MessageBox.Show("Target Client not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtName.Text = _targetClient.TargetClientName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the validation errors.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtName.Text.Trim();

            if (_targetClientId.HasValue)
                _targetClient = ClsTargetClient.FindById(_targetClientId.Value);
            else
                _targetClient = new ClsTargetClient();

            _targetClient.TargetClientName = name;

            bool success = _targetClient.Save();

            if (success)
            {
                MessageBox.Show("Target Client saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save Target Client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
