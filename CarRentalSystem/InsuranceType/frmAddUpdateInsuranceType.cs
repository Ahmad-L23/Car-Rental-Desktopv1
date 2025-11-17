using CarRentalBusiness;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalSystem.InsuranceType
{
    public partial class frmAddUpdateInsuranceType : Form
    {
        private int? _insuranceTypeId = null;
        private string _currentImagePath = null;    // relative image filename from DB (if editing)
        private string _tempSelectedImagePath = null; // temp full path from OpenFileDialog before save

        public frmAddUpdateInsuranceType(int? insuranceTypeId = null)
        {
            InitializeComponent();

            _insuranceTypeId = insuranceTypeId;

            LoadComboBoxes();

            if (_insuranceTypeId.HasValue)
            {
                this.Text = "Edit Insurance Type";
                label1.Text = "Edit Insurance Type";
                btnSave.Text = "Update";

                LoadInsuranceTypeData(_insuranceTypeId.Value);
            }
            else
            {
                this.Text = "Add New Insurance Type";
                label1.Text = "Add New Insurance Type";
                btnSave.Text = "Save";
                chkIsActive.Checked = true;
            }
        }

        private void LoadComboBoxes()
        {
            // Load Coverage data from database
            var dtCoverage = ClsCoverage.GetAll();
            cmbCoverage.DataSource = null;
            cmbCoverage.DisplayMember = "name"; // Change these according to your DB schema
            cmbCoverage.ValueMember = "id";
            cmbCoverage.DataSource = dtCoverage;

          

            // Load TargetClient data from database
            var dtTargetClients = ClsTargetClient.GetAll();
            cmbTargetClient.DataSource = null;
            cmbTargetClient.DisplayMember = "name"; // Change accordingly
            cmbTargetClient.ValueMember = "id";
            cmbTargetClient.DataSource = dtTargetClients;

            
        }

        private void LoadInsuranceTypeData(int id)
        {
            var insuranceType = ClsInsuranceType.FindById(id);
            if (insuranceType == null)
            {
                MessageBox.Show("Insurance type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtName.Text = insuranceType.Name;
            txtDescription.Text = insuranceType.Description;

            // Set Coverage by ValueMember
            
                cmbCoverage.SelectedValue = insuranceType.CoverageID;
           

            // Set Target Client by ValueMember
            
                cmbTargetClient.SelectedValue = insuranceType.TargetClientID;
            
          

            chkIsActive.Checked = insuranceType.IsActive;

            _currentImagePath = insuranceType.InsuranceImage;

            LoadImageFromPath(_currentImagePath);
        }

        private void LoadImageFromPath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                pbInsurance.Image = null;
                return;
            }

            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "insuranceImages");
                string fullPath = Path.Combine(imagesFolder, relativePath);
                if (File.Exists(fullPath))
                {
                    pbInsurance.Image?.Dispose();
                    pbInsurance.Image = Image.FromFile(fullPath);
                }
                else
                {
                    pbInsurance.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pbInsurance.Image = null;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Please fix validation errors.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Name is required.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }

            // Validate ComboBoxes selected values
            if (cmbCoverage.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbCoverage, "Please select a coverage.");
                return;
            }
            else
            {
                errorProvider1.SetError(cmbCoverage, "");
            }

            if (cmbTargetClient.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbTargetClient, "Please select a target client.");
                return;
            }
            else
            {
                errorProvider1.SetError(cmbTargetClient, "");
            }

            ClsInsuranceType insuranceType;

            if (_insuranceTypeId.HasValue)
            {
                insuranceType = ClsInsuranceType.FindById(_insuranceTypeId.Value);
                if (insuranceType == null)
                {
                    MessageBox.Show("Insurance type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                insuranceType = new ClsInsuranceType();
            }

            insuranceType.Name = txtName.Text.Trim();
            insuranceType.Description = txtDescription.Text.Trim();
            insuranceType.CoverageID = Convert.ToInt32(cmbCoverage.SelectedValue);
            insuranceType.TargetClientID = Convert.ToInt32(cmbTargetClient.SelectedValue);
            insuranceType.IsActive = chkIsActive.Checked;

            // Image saving logic
            if (pbInsurance.Image != null && !string.IsNullOrEmpty(_tempSelectedImagePath))
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "insuranceImages");
                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                // Delete old image if exists
                if (!string.IsNullOrEmpty(_currentImagePath))
                {
                    string oldImageFullPath = Path.Combine(imagesFolder, _currentImagePath);
                    if (File.Exists(oldImageFullPath))
                    {
                        try
                        {
                            File.Delete(oldImageFullPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to delete old image: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                string imageExt = Path.GetExtension(_tempSelectedImagePath);
                string newImageName = Guid.NewGuid().ToString() + imageExt;
                string newImageFullPath = Path.Combine(imagesFolder, newImageName);

                try
                {
                    pbInsurance.Image.Save(newImageFullPath);
                    insuranceType.InsuranceImage = newImageName;

                    _currentImagePath = newImageName;
                    _tempSelectedImagePath = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            bool success;

            if (_insuranceTypeId.HasValue)
            {
                success = insuranceType.Save();
            }
            else
            {
                success = insuranceType.Save();
                if (success)
                    _insuranceTypeId = insuranceType.InsuranceTypeID;
            }

            if (success)
            {
                MessageBox.Show("Insurance type saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save insurance type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llSetImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            menu.Items.Add("📷 Browse Image", null, (s, ev) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    ofd.Title = "Select Insurance Image";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            pbInsurance.Image?.Dispose();
                            pbInsurance.Image = Image.FromFile(ofd.FileName);

                            _tempSelectedImagePath = ofd.FileName;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            });

            menu.Show(llSetImage, new Point(0, llSetImage.Height));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
