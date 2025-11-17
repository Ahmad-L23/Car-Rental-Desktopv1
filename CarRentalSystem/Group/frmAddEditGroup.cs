using CarRentalBusiness;
using System;
using System.IO;
using System.Windows.Forms;

namespace CarRentalSystem.Group
{
    public partial class frmAddEditGroup : Form
    {
        private int? groupId = null;
        private bool isUpdateMode = false;
        private string imageRelativePath = "";
        private string selectedImagePath = null;
        public frmAddEditGroup(int? groupId = null)
        {
            InitializeComponent();

            this.groupId = groupId;
            isUpdateMode = groupId.HasValue;

            if (isUpdateMode)
            {
                this.Text = "Edit Group";
                btnSave.Text = "Update";
                LoadGroupData(groupId.Value);
            }
            else
            {
                this.Text = "Add New Group";
                btnSave.Text = "Add";
            }
        }

        private void LoadGroupData(int groupId)
        {
            ClsGroup group = ClsGroup.FindById(groupId);
            if (group == null)
            {
                MessageBox.Show("Group not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtName.Text = group.Name;
            imageRelativePath = group.Image ?? "";

            string imagePath = Path.Combine(Application.StartupPath, imageRelativePath);
            if (!string.IsNullOrWhiteSpace(imageRelativePath) && File.Exists(imagePath))
            {
                picPreview.Image?.Dispose();
                picPreview.Image = System.Drawing.Image.FromFile(imagePath);
            }
            else
            {
                picPreview.Image = null;
            }
        }

        private void lnkBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName; // Just store the path for now

                    picPreview.Image?.Dispose();
                    picPreview.Image = System.Drawing.Image.FromFile(selectedImagePath);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            // Copy image only here
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                string ext = Path.GetExtension(selectedImagePath);
                string newFileName = Guid.NewGuid().ToString() + ext;
                string destPath = Path.Combine(imagesFolder, newFileName);

                try
                {
                    File.Copy(selectedImagePath, destPath, true);
                    imageRelativePath = Path.Combine("Images", newFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving image: " + ex.Message);
                    return;
                }
            }

            ClsGroup group;
            if (isUpdateMode)
            {
                group = new ClsGroup(groupId, txtName.Text.Trim(), imageRelativePath);
            }
            else
            {
                group = new ClsGroup()
                {
                    Name = txtName.Text.Trim(),
                    Image = imageRelativePath
                };
            }

            bool success = group.Save();

            if (success)
            {
                MessageBox.Show(isUpdateMode ? "Group updated successfully." : "Group added successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save group. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a group name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
