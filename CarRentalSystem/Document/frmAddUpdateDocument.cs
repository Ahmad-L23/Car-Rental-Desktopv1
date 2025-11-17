using CarRentalBusiness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CarRentalSystem.Document
{
    public partial class frmAddUpdateDocument : Form
    {
        private ClsDocument _document;
        private bool _isUpdateMode;
        private int _CustomerId = 0;

        // Constructor for adding new document - receives customerId
        public frmAddUpdateDocument(int customerId)
        {
            InitializeComponent();
            _isUpdateMode = false;
            InitializeIdTypeComboBoxes();
            _CustomerId = customerId;
            LoadCustomer(customerId);
            InitializeFormForAdd();
        }

        // Constructor for updating document - receives documentId
        public frmAddUpdateDocument(int documentId, bool update = true)
        {
            InitializeComponent();
            _isUpdateMode = update;
            InitializeIdTypeComboBoxes();
            LoadDocument(documentId);
        }

        // Initialize ComboBoxes with fixed items for ID Types (can be customized)
        private void InitializeIdTypeComboBoxes()
        {
            cmbIdTypeEn.Items.Clear();
            cmbIdTypeEn.Items.AddRange(new string[] { "Personal Id", "Passport" });
            cmbIdTypeAr.Items.Clear();
            cmbIdTypeAr.Items.AddRange(new string[] { "بطاقة شخصية", "جواز سفر" });
        }

        private void LoadCustomer(int customerId)
        {
            var customer = ClsCustomer.FindById(customerId);
            if (customer == null)
            {
                MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            _document = new ClsDocument
            {
                Customer = customer
            };

            lblCustomerId.Text = customer.CustomerId?.ToString() ?? "";
            lblCustomerName.Text = customer.CustomerNameEn ?? "";
        }

        private void LoadDocument(int documentId)
        {
            _document = ClsDocument.FindById(documentId);
            if (_document == null)
            {
                MessageBox.Show("Document not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblCustomerId.Text = _document.Customer?.CustomerId?.ToString() ?? "";
            lblCustomerName.Text = _document.Customer?.CustomerNameEn ?? "";


            SetComboBoxSelectedItem(cmbIdTypeEn, _document.IdTypeEn);
            SetComboBoxSelectedItem(cmbIdTypeAr, _document.IdTypeAr);

            txtIdNumber.Text = _document.IdNumber;
            txtIdentityNumber.Text = _document.IdentityNumber;
            txtLicenseNumber.Text = _document.LicenseNumber;
            txtLicenseCategoryEn.Text = _document.LicenseCategoryEn;
            txtLicenseCategoryAr.Text = _document.LicenseCategoryAr;
            txtLicensePlaceOfIssueEn.Text = _document.LicensePlaceOfIssueEn;
            txtLicensePlaceOfIssueAr.Text = _document.LicensePlaceOfIssueAr;
            dtpLicenseIssueDate.Value = _document.LicenseIssueDate ?? DateTime.Now;
            dtpLicenseExpiryDate.Value = _document.LicenseExpiryDate ?? DateTime.Now;
            txtIdentityPlaceOfIssueEn.Text = _document.IdentityPlaceOfIssueEn;
            txtIdentityPlaceOfIssueAr.Text = _document.IdentityPlaceOfIssueAr;
        }

        private void InitializeFormForAdd()
        {
            cmbIdTypeEn.SelectedIndex = -1;
            cmbIdTypeAr.SelectedIndex = -1;
            txtIdNumber.Text = "";
            txtIdentityNumber.Text = "";
            txtLicenseNumber.Text = "";
            txtLicenseCategoryEn.Text = "";
            txtLicenseCategoryAr.Text = "";
            txtLicensePlaceOfIssueEn.Text = "";
            txtLicensePlaceOfIssueAr.Text = "";
            dtpLicenseIssueDate.Value = DateTime.Now;
            dtpLicenseExpiryDate.Value = DateTime.Now;
            txtIdentityPlaceOfIssueEn.Text = "";
            txtIdentityPlaceOfIssueAr.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_document.Customer == null || !_document.Customer.CustomerId.HasValue)
            {
                MessageBox.Show("Customer is not assigned or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateChildren())
            {
                return; // Stop saving if validation failed
            }

            _document.IdTypeEn = cmbIdTypeEn.SelectedItem?.ToString() ?? "";
            _document.IdTypeAr = cmbIdTypeAr.SelectedItem?.ToString() ?? "";
            _document.IdNumber = txtIdNumber.Text.Trim();
            _document.IdentityNumber = txtIdentityNumber.Text.Trim();
            _document.LicenseNumber = txtLicenseNumber.Text.Trim();
            _document.LicenseCategoryEn = txtLicenseCategoryEn.Text.Trim();
            _document.LicenseCategoryAr = txtLicenseCategoryAr.Text.Trim();
            _document.LicensePlaceOfIssueEn = txtLicensePlaceOfIssueEn.Text.Trim();
            _document.LicensePlaceOfIssueAr = txtLicensePlaceOfIssueAr.Text.Trim();
            _document.LicenseIssueDate = dtpLicenseIssueDate.Value;
            _document.LicenseExpiryDate = dtpLicenseExpiryDate.Value;
            _document.IdentityPlaceOfIssueEn = txtIdentityPlaceOfIssueEn.Text.Trim();
            _document.IdentityPlaceOfIssueAr = txtIdentityPlaceOfIssueAr.Text.Trim();

            try
            {
                if (_document.Save())
                {
                    MessageBox.Show("Document saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to save document.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving document: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetComboBoxSelectedItem(ComboBox comboBox, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                comboBox.SelectedIndex = -1;
                return;
            }

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (string.Equals(comboBox.Items[i]?.ToString(), value, StringComparison.OrdinalIgnoreCase))
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }
            comboBox.SelectedIndex = -1;
        }

        // Validation handlers for input controls

      
        private void cmbIdTypeEn_Validating(object sender, CancelEventArgs e)
        {
            if (cmbIdTypeEn.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbIdTypeEn, "Please select an ID type.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbIdTypeEn, "");
            }
        }

        private void cmbIdTypeAr_Validating(object sender, CancelEventArgs e)
        {
            if (cmbIdTypeAr.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbIdTypeAr, "يرجى اختيار نوع الهوية.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbIdTypeAr, "");
            }
        }

        private void txtIdNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdNumber.Text))
            {
                errorProvider1.SetError(txtIdNumber, "Please enter ID Number.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIdNumber, "");
            }
        }

        private void txtIdentityNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdentityNumber.Text))
            {
                errorProvider1.SetError(txtIdentityNumber, "Please enter Identity Number.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIdentityNumber, "");
            }
        }

        private void txtLicenseNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                errorProvider1.SetError(txtLicenseNumber, "Please enter License Number.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLicenseNumber, "");
            }
        }

        private void txtLicenseCategoryEn_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicenseCategoryEn.Text))
            {
                errorProvider1.SetError(txtLicenseCategoryEn, "Please enter License Category (English).");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLicenseCategoryEn, "");
            }
        }

        private void txtLicenseCategoryAr_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicenseCategoryAr.Text))
            {
                errorProvider1.SetError(txtLicenseCategoryAr, "Please enter License Category (Arabic).");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLicenseCategoryAr, "");
            }
        }

        private void txtLicensePlaceOfIssueEn_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicensePlaceOfIssueEn.Text))
            {
                errorProvider1.SetError(txtLicensePlaceOfIssueEn, "Please enter License Place Of Issue (English).");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLicensePlaceOfIssueEn, "");
            }
        }

        private void txtLicensePlaceOfIssueAr_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicensePlaceOfIssueAr.Text))
            {
                errorProvider1.SetError(txtLicensePlaceOfIssueAr, "Please enter License Place Of Issue (Arabic).");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLicensePlaceOfIssueAr, "");
            }
        }

        private void dtpLicenseIssueDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpLicenseIssueDate.Value == DateTime.MinValue)
            {
                errorProvider1.SetError(dtpLicenseIssueDate, "Please select License Issue Date.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dtpLicenseIssueDate, "");
            }
        }

        private void dtpLicenseExpiryDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpLicenseExpiryDate.Value == DateTime.MinValue)
            {
                errorProvider1.SetError(dtpLicenseExpiryDate, "Please select License Expiry Date.");
                e.Cancel = true;
            }
            else if (dtpLicenseExpiryDate.Value <= dtpLicenseIssueDate.Value)
            {
                errorProvider1.SetError(dtpLicenseExpiryDate, "Expiry Date must be after Issue Date.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dtpLicenseExpiryDate, "");
            }
        }

        private void txtIdentityPlaceOfIssueEn_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdentityPlaceOfIssueEn.Text))
            {
                errorProvider1.SetError(txtIdentityPlaceOfIssueEn, "Please enter Identity Place Of Issue (English).");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIdentityPlaceOfIssueEn, "");
            }
        }

        private void txtIdentityPlaceOfIssueAr_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdentityPlaceOfIssueAr.Text))
            {
                errorProvider1.SetError(txtIdentityPlaceOfIssueAr, "Please enter Identity Place Of Issue (Arabic).");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIdentityPlaceOfIssueAr, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ClsCustomer.DeleteCustomer(_CustomerId))
            {
                MessageBox.Show("Customer Deleted due there is no document related for" + lblCustomerName.Text);
            }
            this.Close();
        }

        private void frmAddUpdateDocument_Load(object sender, EventArgs e)
        {

        }
    }
}
