using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.RentalAddition
{
    public partial class frmAddUpdateRentalAddition : Form
    {
        private int? _rentalAdditionId;
        private ClsRentalAddition _rentalAddition;

        public frmAddUpdateRentalAddition(int? rentalAdditionId = null)
        {
            InitializeComponent();
            _rentalAdditionId = rentalAdditionId;                                                                             
        }
        private void frmAddUpdateRentalAddition_Load_1(object sender, EventArgs e)
        {
            LoadPaymentMethods();

            if (_rentalAdditionId.HasValue)
            {
                this.Text = "Edit Rental Addition";
                lblTitle.Text = "Edit Rental Addition";
                btnSave.Text = "Update";
                LoadRentalAdditionData(_rentalAdditionId.Value);
            }
            else
            {
                this.Text = "Add New Rental Addition";
                lblTitle.Text = "Add New Rental Addition";
                btnSave.Text = "Save";
                chkIsActive.Checked = true; // Default to active
            }
        }

        private void LoadPaymentMethods()
        {
            DataTable dtPaymentMethods = ClsPaymentMethod.GetAllPaymentMethods();

            cbPaymentMethod.DisplayMember = "MethodName";  
            cbPaymentMethod.ValueMember = "Id";
            cbPaymentMethod.DataSource = dtPaymentMethods;
            cbPaymentMethod.SelectedIndex = -1;
        }

        private void LoadRentalAdditionData(int rentalAdditionId)
        {
            _rentalAddition = ClsRentalAddition.FindById(rentalAdditionId);

            if (_rentalAddition == null)
            {
                MessageBox.Show("Rental addition not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtRentalName.Text = _rentalAddition.RentalName;
            cbPaymentMethod.SelectedValue = _rentalAddition.PaymentMethodID;
            numPrice.Value = _rentalAddition.Price;
            txtRentalNote.Text = _rentalAddition.RentalNote;
            chkIsActive.Checked = _rentalAddition.IsActive;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the validation errors.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_rentalAdditionId.HasValue)
                _rentalAddition = ClsRentalAddition.FindById(_rentalAdditionId.Value);
            else
                _rentalAddition = new ClsRentalAddition();

            _rentalAddition.RentalName = txtRentalName.Text.Trim();
            _rentalAddition.PaymentMethodID = (int)(cbPaymentMethod.SelectedValue != null ? Convert.ToInt32(cbPaymentMethod.SelectedValue) : (int?)null);
            _rentalAddition.Price = numPrice.Value;
            _rentalAddition.RentalNote = txtRentalNote.Text.Trim();
            _rentalAddition.IsActive = chkIsActive.Checked;

            bool success = _rentalAddition.Save();

            if (success)
            {
                MessageBox.Show("Rental addition saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save rental addition.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numPrice_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void cbPaymentMethod_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbPaymentMethod.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbPaymentMethod, "Select a payment method.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbPaymentMethod, "");
            }
        }

        private void txtRentalName_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRentalName.Text))
            {
                errorProvider1.SetError(txtRentalName, "Rental name is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtRentalName, "");
            }
        }
    }
}
