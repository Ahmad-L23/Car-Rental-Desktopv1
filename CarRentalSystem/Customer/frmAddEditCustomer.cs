using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net.Mail;

namespace CarRentalSystem.Customer
{
    public partial class frmAddEditCustomer : Form
    {
        private int? _customerId; // nullable int, null means add new, otherwise update

        private List<ClsCompany> allCompanies;
        private DataTable dtNationalities;
        private DataTable dtMediators;

        public delegate void CustomerSavedHandler(int customerId);

        // Event based on delegate
        public event CustomerSavedHandler CustomerSaved;

        public frmAddEditCustomer(int? customerId = null)
        {
            InitializeComponent();

            _customerId = customerId;

            LoadCombos();

            if (_customerId.HasValue)
            {
                // Update mode
                this.Text = "Edit Customer";
                btnSave.Text = "Update";
                lblTitle.Text = "Edit Customer Details";

                LoadCustomerData(_customerId.Value);
            }
            else
            {
                // Add new mode
                this.Text = "Add New Customer";
                btnSave.Text = "Save";

                lblTitle.Text = "Add New Customer";
            }

            
            // Also make combo boxes editable for text input (important)
            cmbCompany.DropDownStyle = ComboBoxStyle.DropDown;
            cmbNationality.DropDownStyle = ComboBoxStyle.DropDown;
            cmbMediator.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void LoadCombos()
        {
            // Customer Type
            cmbCustomerType.Items.Clear();
            cmbCustomerType.Items.AddRange(new string[] { "Individual", "Company" });

            // Companies - from business layer list
            allCompanies = ClsCompany.GetAllCompanies();
            cmbCompany.DataSource = null;
            cmbCompany.DisplayMember = "NameEn";
            cmbCompany.ValueMember = "ID";
            cmbCompany.DataSource = allCompanies;

            // Nationalities - DataTable
            dtNationalities = ClsNationlity.GetAllNationalities();
            cmbNationality.DataSource = null;
            cmbNationality.DisplayMember = "nationality_name_en";  // adjust column name if needed
            cmbNationality.ValueMember = "id";       // adjust column name if needed
            cmbNationality.DataSource = dtNationalities;

            // Mediators - DataTable
            dtMediators = ClsMediator.GetAllMediators();
            cmbMediator.DataSource = null;
            cmbMediator.DisplayMember = "mediator_name_en"; // adjust column name if needed
            cmbMediator.ValueMember = "mediator_id";       // adjust column name if needed
            cmbMediator.DataSource = dtMediators;
        }

        private void LoadCustomerData(int customerId)
        {
            ClsCustomer customer = ClsCustomer.FindById(customerId);
            if (customer == null)
            {
                MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtCustomerNameEn.Text = customer.CustomerNameEn;
            txtCustomerNameAr.Text = customer.CustomerNameAr;
            cmbCustomerType.SelectedItem = customer.CustomerType;

            txtPhoneNumber.Text = customer.PhoneNumber;
            txtEmail.Text = customer.Email;
            txtAddressEn.Text = customer.AddressEn;
            txtAddressAr.Text = customer.AddressAr;
            txtNotesEn.Text = customer.NotesEn;
            txtNotesAr.Text = customer.NotesAr;
            chkBlacklist.Checked = customer.Blacklist;

            // Set ComboBoxes selections by IDs
            if (customer.Company != null)
                cmbCompany.SelectedValue = customer.Company.ID;
            else
                cmbCompany.SelectedIndex = -1;

            if (customer.Nationality != null)
                cmbNationality.SelectedValue = customer.Nationality.Id;
            else
                cmbNationality.SelectedIndex = -1;

            if (customer.Mediator != null)
                cmbMediator.SelectedValue = customer.Mediator.id;
            else
                cmbMediator.SelectedIndex = -1;
        }

                

        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {
            cmbCompany.SelectedIndex = -1;
            cmbCustomerType.SelectedIndex = -1;
            cmbMediator.SelectedIndex = -1;
            cmbNationality.SelectedIndex = -1;
            cmbCompany.Visible = false;
            lblCompany.Visible = false;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }

            // Only one '+' at start
            if (e.KeyChar == '+' && (sender as TextBox).SelectionStart != 0)
            {
                e.Handled = true;
            }
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                errorProvider1.SetError(txtEmail, "Please enter a valid email address.");
            }
            else
            {
                errorProvider1.SetError(txtEmail, ""); // clear error if valid or empty
            }
        }

        private void txtCustomerNameEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace, Delete, arrows, etc.
            if (char.IsControl(e.KeyChar))
                return;

            // Allow English letters (A-Z, a-z), digits (0-9), and space
            if (!((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
                  (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                  (e.KeyChar >= '0' && e.KeyChar <= '9') ||
                  e.KeyChar == ' '))  // allow space
            {
                e.Handled = true; // block other chars
            }

        }

        private void txtCustomerNameAr_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits and space
            if (char.IsDigit(e.KeyChar) || e.KeyChar == ' ')
                return;

            // Allow Arabic letters Unicode range
            if (e.KeyChar >= '\u0600' && e.KeyChar <= '\u06FF')
                return;

            // If not Arabic letter, digit, or space, block
            e.Handled = true;
        }

        private void txtCustomerNameEn_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerNameEn.Text))
            {
                errorProvider1.SetError(txtCustomerNameEn, "English customer name is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCustomerNameEn, "");
            }
        }

        private void txtCustomerNameAr_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerNameAr.Text))
            {
                errorProvider1.SetError(txtCustomerNameAr, "Arabic customer name is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCustomerNameAr, "");
            }

        }

        private ClsCustomer _customer;
        private void btnSave_Click_2(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                
                string customerType = cmbCustomerType.SelectedItem?.ToString() ?? "";
                string customerNameEn = txtCustomerNameEn.Text.Trim();
                string customerNameAr = txtCustomerNameAr.Text.Trim();
                string phone = txtPhoneNumber.Text.Trim();
                string email = txtEmail.Text.Trim();
                string addressEn = txtAddressEn.Text.Trim();
                string addressAr = txtAddressAr.Text.Trim();
                string notesEn = txtNotesEn.Text.Trim();
                string notesAr = txtNotesAr.Text.Trim();
                bool blacklist = chkBlacklist.Checked;

                int? companyId = cmbCompany.SelectedValue as int?;
                if (companyId == null || (int)companyId == 0 || cmbCustomerType.SelectedIndex == 0)
                    companyId = null;

                int? nationalityId = cmbNationality.SelectedValue as int?;
                if (nationalityId == null || (int)nationalityId == 0)
                    nationalityId = null;

                int? mediatorId = cmbMediator.SelectedValue as int?;
                if (mediatorId == null || (int)mediatorId == 0)
                    mediatorId = null;


                if (_customerId.HasValue)
                {
                    // update existing
                    _customer = ClsCustomer.FindById(_customerId.Value);
                    if (_customer == null)
                    {
                        MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    _customer = new ClsCustomer();
                }

                // Set properties
                _customer.CustomerType = customerType;
                _customer.CustomerNameEn = customerNameEn;
                _customer.CustomerNameAr = customerNameAr;
                _customer.PhoneNumber = phone;
                _customer.Email = email;
                _customer.AddressEn = addressEn;
                _customer.AddressAr = addressAr;
                _customer.NotesEn = notesEn;
                _customer.NotesAr = notesAr;
                _customer.Blacklist = blacklist;

                // Set related entities minimally (only IDs)
                _customer.Company = companyId.HasValue ? new ClsCompany { ID = companyId.Value } : null;
                _customer.Nationality = nationalityId.HasValue ? new ClsNationlity { Id = nationalityId.Value } : null;
                _customer.Mediator = mediatorId.HasValue ? new ClsMediator { id = mediatorId.Value } : null;

                bool success = _customer.Save();

                if (success)
                {
                    MessageBox.Show("Customer saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int savedId = (int)(_customerId ?? _customer.CustomerId);  // customer.ID should be set on Save() if new
                    CustomerSaved?.Invoke(savedId);
                    if (!_customerId.HasValue) // New customer
                    {
                        using (var frmDoc = new CarRentalSystem.Document.frmAddUpdateDocument(savedId))
                        {
                            frmDoc.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to save customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Some fields are requried pleas fill them");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomerType.SelectedIndex == 0)
            {
                lblCompany.Visible = false;
                cmbCompany.Visible = false;
            }
            else
            {
                lblCompany.Visible = true;
                cmbCompany.Visible = true;
            }
        }

        private void cmbNationality_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
         
            if (cmbNationality.SelectedIndex == -1)
            {
                // Show error
                errorProvider1.SetError(cmbNationality, "Please select a nationality.");
                e.Cancel = true; // Prevent focus from leaving the control
            }
            else
            {
                // Clear error if something is selected
                errorProvider1.SetError(cmbNationality, "");
            }
        
        }

        private void cmbCustomerType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbCustomerType.SelectedIndex == -1)
            {
                // Show error
                errorProvider1.SetError(cmbCustomerType, "Please select a customer type");
                e.Cancel = true; // Prevent focus from leaving the control
            }
            else
            {
                // Clear error if something is selected
                errorProvider1.SetError(cmbCustomerType, "");
            }
        }

        private void cmbCompany_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbCompany.SelectedIndex == -1)
            {
                // Show error
                errorProvider1.SetError(cmbCompany, "Please select a company.");
                e.Cancel = true; // Prevent focus from leaving the control
            }
            else
            {
                // Clear error if something is selected
                errorProvider1.SetError(cmbCompany, "");
            }
        }
    }
}
