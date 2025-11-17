using CarRentalBusiness;
using System;
using System.Windows.Forms;

namespace CarRentalSystem.Currency
{
    public partial class frmAddUpdateCurrency : Form
    {
        private int? currencyId;
        ClsCurrency _currency;
        private enum FormMode
        {
            Add,
            Edit
        }

        private FormMode currentMode;

        public frmAddUpdateCurrency(int? currencyId = null)
        {
            InitializeComponent();
            this.currencyId = currencyId;

            currentMode = currencyId.HasValue ? FormMode.Edit : FormMode.Add;

            SetupForm();
        }

        private void SetupForm()
        {
            if (currentMode == FormMode.Add)
            {
                this.Text = "Add New Currency";
                btnSave.Text = "Add";
            }
            else
            {
                this.Text = "Edit Currency";
                btnSave.Text = "Save";
                label1.Text = "Update";
                LoadCurrencyData();
            }
        }

        private void LoadCurrencyData()
        {
            if (!currencyId.HasValue)
                return;

            var currency = ClsCurrency.FindById(currencyId.Value);
            if (currency == null)
            {
                MessageBox.Show("Currency not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtNameEn.Text = currency.NameEn;
            txtNameAr.Text = currency.NameAr;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nameEn = txtNameEn.Text.Trim();
            string nameAr = txtNameAr.Text.Trim();

            if (string.IsNullOrEmpty(nameEn))
            {
                MessageBox.Show("Please enter the English name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameEn.Focus();
                return;
            }

            if (string.IsNullOrEmpty(nameAr))
            {
                MessageBox.Show("Please enter the Arabic name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameAr.Focus();
                return;
            }

            _currency = new ClsCurrency();

            if (currentMode == FormMode.Add)
            {
                _currency.NameAr = nameAr;
                _currency.NameEn = nameEn;
            }

            else
                _currency = new ClsCurrency(currencyId, nameEn, nameAr);

            bool saved = _currency.Save();

            if (saved)
            {
                MessageBox.Show("Currency saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save currency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
