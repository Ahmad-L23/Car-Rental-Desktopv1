using CarRentalBusiness;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalSystem.Category
{
    public partial class frmAddEditCategory : Form
    {
        private int? categoryId;
        private string imageRelativePath = null;

        private enum FormMode
        {
            Add,
            Edit
        }

        private FormMode currentMode;

        public frmAddEditCategory(int? categoryId = null)
        {
            InitializeComponent();
            this.categoryId = categoryId;

            currentMode = categoryId.HasValue ? FormMode.Edit : FormMode.Add;

            SetupForm();
        }

        private void SetupForm()
        {
            if (currentMode == FormMode.Add)
            {
                this.Text = "Add New Category";
                btnSave.Text = "Add";
            }
            else
            {
                this.Text = "Edit Category";
                btnSave.Text = "Save";
                LoadCategoryData();
            }
        }

        private void LoadCategoryData()
        {
            if (!categoryId.HasValue)
                return;

            var category = ClsCategory.FindById(categoryId.Value);
            if (category == null)
            {
                MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtNameEn.Text = category.NameEn;
            txtNameAr.Text = category.NameAr;
            imageRelativePath = category.Image;

            if (!string.IsNullOrEmpty(imageRelativePath) && File.Exists(Path.Combine(Application.StartupPath, imageRelativePath)))
            {
                picImage.Image?.Dispose();
                picImage.Image = Image.FromFile(Path.Combine(Application.StartupPath, imageRelativePath));
            }
        }

        private void lnkBrowseImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = ofd.FileName;
                string imagesFolder = Path.Combine(Application.StartupPath, "Images");

                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                string ext = Path.GetExtension(selectedFilePath);
                string newFileName = Guid.NewGuid().ToString() + ext;
                string destPath = Path.Combine(imagesFolder, newFileName);

                try
                {
                    File.Copy(selectedFilePath, destPath);
                    imageRelativePath = Path.Combine("Images", newFileName);

                    picImage.Image?.Dispose();
                    picImage.Image = Image.FromFile(destPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error copying image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

            ClsCategory category;

            if (currentMode == FormMode.Add)
            {
                category = new ClsCategory(null, nameEn, nameAr, imageRelativePath);
            }
            else
            {
                category = new ClsCategory(categoryId, nameEn, nameAr, imageRelativePath);
            }

            bool saved = category.Save();

            if (saved)
            {
                MessageBox.Show("Category saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
