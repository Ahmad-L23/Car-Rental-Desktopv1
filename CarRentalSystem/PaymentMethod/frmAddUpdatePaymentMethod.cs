using CarRentalBusiness;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarRentalSystem.PaymentMethod
{
    public partial class frmAddUpdatePaymentMethod : Form
    {
        private int? paymentMethodId;

        private enum FormMode
        {
            Add,
            Edit
        }

        private FormMode currentMode;

        public frmAddUpdatePaymentMethod(int? paymentMethodId = null)
        {
            InitializeComponent();
            this.paymentMethodId = paymentMethodId;

            currentMode = paymentMethodId.HasValue ? FormMode.Edit : FormMode.Add;

            SetupForm();
        }

        private void SetupForm()
        {
            if (currentMode == FormMode.Add)
            {
                this.Text = "Add New Payment Method";
                btnSave.Text = "Add";
            }
            else
            {
                this.Text = "Edit Payment Method";
                btnSave.Text = "Save";
                LoadPaymentMethodData();
            }
        }

        private void LoadPaymentMethodData()
        {
            if (!paymentMethodId.HasValue)
                return;

            var method = ClsPaymentMethod.FindById(paymentMethodId.Value);
            if (method == null)
            {
                MessageBox.Show("Payment method not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtMethodName.Text = method.MethodName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtMethodName.Text.Trim();

            if(!ValidateChildren())
                return;
            

            ClsPaymentMethod method;

            if (currentMode == FormMode.Add)
            {
                method = new ClsPaymentMethod();
                method.MethodName = name;
            }
            else
                method = new ClsPaymentMethod(paymentMethodId, name);

            bool saved = method.Save();

            if (saved)
            {
                MessageBox.Show("Payment method saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtMethodName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            string methodName = txtMethodName.Text.Trim();

            // Check empty
            if (string.IsNullOrEmpty(methodName))
            {
                errorProvider1.SetError(txtMethodName, "Please enter a payment method name.");
                e.Cancel = true;
                return;
            }

            // Check if exists (only when adding)
            if (currentMode == FormMode.Add && ClsPaymentMethod.IsPaymentMethodExist(methodName))
            {
                errorProvider1.SetError(txtMethodName, "This payment method already exists.");
                e.Cancel = true;
                return;
            }
        }
    }
}
