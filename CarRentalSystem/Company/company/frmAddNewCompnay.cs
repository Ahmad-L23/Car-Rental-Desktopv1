using CarRentalBusiness;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CarRentalSystem.Company
{
    public partial class frmAddNewCompnay : Form
    {
        private string selectedImagePath = null;
        private ClsCompany _currentCompany = null;
        private bool _isEditMode = false;

        // ✅ Constructor for Add Mode
        public frmAddNewCompnay()
        {
            InitializeComponent();
            this.Text = "Add New Company";

            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        // ✅ Constructor for Edit Mode
        public frmAddNewCompnay(int companyId)
        {
            InitializeComponent();
            LoadCompany(companyId);
            this.Text = "Edit Company";

            _isEditMode = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        // ✅ Load company info from database
        private void LoadCompany(int id)
        {
            _currentCompany = new ClsCompany();
            bool found = _currentCompany.LoadByID(id);

            if (!found)
            {
                MessageBox.Show("Company not found.");
                this.Close();
                return;
            }

            txtArabName.Text = _currentCompany.NameAr;
            txtEnglishName.Text = _currentCompany.NameEn;
            txtAddress.Text = _currentCompany.AddressEn;
            txtphoneNumber.Text = _currentCompany.PhoneNumber;
            txtEmail.Text = _currentCompany.Email;

            // Load image if available
            if (!string.IsNullOrEmpty(_currentCompany.Image))
            {
                string fullPath = Path.Combine(Application.StartupPath, _currentCompany.Image);
                if (File.Exists(fullPath))
                {
                    pbCompnay.ImageLocation = fullPath;
                    pbCompnay.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        // ✅ Choose new image
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Select an image";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    pbCompnay.ImageLocation = selectedImagePath;
                    pbCompnay.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        // ✅ Save image to project folder
        private string SaveImageToProjectFolder(string originalImagePath)
        {
            if (string.IsNullOrEmpty(originalImagePath) || !File.Exists(originalImagePath))
                throw new ArgumentException("Invalid image path");

            string imagesFolder = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);

            string ext = Path.GetExtension(originalImagePath);
            string guidFileName = $"{Guid.NewGuid()}{ext}";
            string destFilePath = Path.Combine(imagesFolder, guidFileName);

            File.Copy(originalImagePath, destFilePath, true);
            return Path.Combine("Images", guidFileName);
        }

        // ✅ ADD NEW company
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChildren()) return;

                string relativePath = null;
                if (!string.IsNullOrEmpty(selectedImagePath))
                    relativePath = SaveImageToProjectFolder(selectedImagePath);

                _currentCompany = new ClsCompany
                {
                    NameAr = txtArabName.Text.Trim(),
                    NameEn = txtEnglishName.Text.Trim(),
                    AddressEn = txtAddress.Text.Trim(),
                    AddressAr = null,
                    PhoneNumber = txtphoneNumber.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Image = relativePath
                };

                bool success = _currentCompany.Save();

                MessageBox.Show(success
                    ? "✅ Company added successfully."
                    : "❌ Failed to add company.");
                
                ClearForm();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        

        // ✅ Validations
        private void txtArabName_Validating(object sender, CancelEventArgs e)
        {
            string input = txtArabName.Text.Trim();
            var arabicRegex = new Regex(@"^[\u0600-\u06FF\s]+$");

            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(txtArabName, "Arabic name is required.");
                e.Cancel = true;
            }
            else if (!arabicRegex.IsMatch(input))
            {
                errorProvider1.SetError(txtArabName, "Arabic letters only.");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtArabName, "");
        }

        private void txtEnglishName_Validating(object sender, CancelEventArgs e)
        {
            string input = txtEnglishName.Text.Trim();
            var englishRegex = new Regex(@"^[a-zA-Z\s]+$");

            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(txtEnglishName, "English name is required.");
                e.Cancel = true;
            }
            else if (!englishRegex.IsMatch(input))
            {
                errorProvider1.SetError(txtEnglishName, "English letters only.");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtEnglishName, "");
        }

        private void txtphoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string input = txtphoneNumber.Text.Trim();
            var digitsOnlyRegex = new Regex(@"^\d+$");

            if (!string.IsNullOrEmpty(input) && !digitsOnlyRegex.IsMatch(input))
                errorProvider1.SetError(txtphoneNumber, "Numbers only.");
            else
                errorProvider1.SetError(txtphoneNumber, "");
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool isValid = string.IsNullOrEmpty(email) || Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);

            errorProvider1.SetError(txtEmail, isValid ? "" : "Invalid email format.");
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChildren()) return;

                if (_currentCompany == null)
                {
                    MessageBox.Show("No company loaded for update.");
                    return;
                }

                string relativePath = null;
                if (!string.IsNullOrEmpty(selectedImagePath))
                    relativePath = SaveImageToProjectFolder(selectedImagePath);

                _currentCompany.NameAr = txtArabName.Text.Trim();
                _currentCompany.NameEn = txtEnglishName.Text.Trim();
                _currentCompany.AddressEn = txtAddress.Text.Trim();
                _currentCompany.PhoneNumber = txtphoneNumber.Text.Trim();
                _currentCompany.Email = txtEmail.Text.Trim();

                if (!string.IsNullOrEmpty(relativePath))
                    _currentCompany.Image = relativePath;

                bool success = _currentCompany.Save();

                MessageBox.Show(success
                    ? "✅ Company updated successfully."
                    : "❌ Failed to update company.");

                if (success)
                    ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            // Clear all TextBoxes
            txtArabName.Clear();
            txtEnglishName.Clear();
            txtAddress.Clear();
            txtphoneNumber.Clear();
            txtEmail.Clear();

            // Clear PictureBox image
            pbCompnay.Image = null;
            pbCompnay.ImageLocation = null;

            // Clear selected image path variable
            selectedImagePath = null;

            // Clear error provider messages
            errorProvider1.Clear();

            // Reset current company and edit mode
            _currentCompany = null;
            _isEditMode = false;

            // Focus first textbox
            txtArabName.Focus();
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
