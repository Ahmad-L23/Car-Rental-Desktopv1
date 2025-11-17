using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.Box
{
    public partial class frmAddEditBox : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _mode = enMode.AddNew;
        private int _boxId;
        private ClsBox _box;

        public frmAddEditBox(int? boxId = null)
        {
            InitializeComponent();

            if (boxId.HasValue)
            {
                _mode = enMode.Update;
                _boxId = boxId.Value;
                this.Text = "Update Box";
                btnSave.Text = "Update";
            }
            else
            {
                _mode = enMode.AddNew;
                this.Text = "Add New Box";
                btnSave.Text = "Save";
            }

            LoadBranches();

            if (_mode == enMode.Update)
                LoadBoxData();
        }

        private void LoadBranches()
        {
            DataTable dtBranches = ClsBranch.GetBranchesDataTable();
            cbBranches.DataSource = dtBranches;
            cbBranches.DisplayMember = "name";
            cbBranches.ValueMember = "branch_id";
            cbBranches.SelectedIndex = -1;
        }

        private void LoadBoxData()
        {
            _box = ClsBox.Find(_boxId);

            if (_box == null)
            {
                MessageBox.Show("Box not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtBoxNameEn.Text = _box.Name;
            cbBranches.SelectedValue = _box.Branch?.BranchId ?? -1;
            txtAccountNumber.Text = _box.AccountNumber;
            chkIsActive.Checked = _box.IsActive;
            txtNotes.Text = _box.Notes;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtBoxNameEn.Text))
            {
                MessageBox.Show("Please enter the English Box Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxNameEn.Focus();
                return false;
            }

            if (cbBranches.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a branch.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbBranches.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAccountNumber.Text))
            {
                MessageBox.Show("Please enter the Account Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccountNumber.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            if (_mode == enMode.AddNew)
                _box = new ClsBox();

            _box.Name = txtBoxNameEn.Text.Trim();
            _box.AccountNumber = txtAccountNumber.Text.Trim();
            _box.Branch = ClsBranch.FindById(Convert.ToInt32(cbBranches.SelectedValue));
            _box.IsActive = chkIsActive.Checked;
            _box.Notes = txtNotes.Text.Trim();

            bool result = _box.Save();

            if (result)
            {
                if (_mode == enMode.AddNew)
                {
                    MessageBox.Show("Box added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Box updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("An error occurred while saving the box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtBoxNameEn.Clear();
            txtAccountNumber.Clear();
            cbBranches.SelectedIndex = -1;
            chkIsActive.Checked = true;
            txtNotes.Clear();
            txtBoxNameEn.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
