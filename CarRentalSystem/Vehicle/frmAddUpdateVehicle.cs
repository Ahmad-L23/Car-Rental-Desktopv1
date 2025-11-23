using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalSystem.Car
{
    public partial class frmAddUpdateVehicle : Form
    {
        private int? _carId; // null = Add new, otherwise = Edit
        private DataTable dtCategories;
        private DataTable dtGroups;
        private DataTable dtBranches;
        private DataTable dtFuelTypes;
        private DataTable dtColors;

        public delegate void CarSavedHandler(int carId);
        public event CarSavedHandler CarSaved;

        private string _currentImagePath = null;

        public frmAddUpdateVehicle()
        {
            InitializeComponent();
            LoadCombos();
            _carId = null;
        }
        public frmAddUpdateVehicle(int? carId = null)
        {
            InitializeComponent();

            _carId = carId;
            LoadCombos();

            if (_carId.HasValue)
            {
                this.Text = "Edit Car";
                lblTitle.Text = "Edit Car Details";
                btnSave.Text = "Update";
                LoadCarData(_carId.Value);
            }
            else
            {
                this.Text = "Add New Car";
                lblTitle.Text = "Add New Car";
                btnSave.Text = "Save";
                chkIsAvailable.Checked = true;
                numYear.Value = DateTime.Now.Year;
            }
        }

        private void LoadCombos()
        {
            // Categories
            dtCategories = ClsCategory.GetAllCategories();
            cmbCategory.DataSource = dtCategories;
            cmbCategory.DisplayMember = "NameEn";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.SelectedIndex = -1;

            //Colors
            dtColors = ClsColor.GetAllColors();
            cmbColor.DataSource = dtColors;
            cmbColor.DisplayMember = "ColorName";
            cmbColor.ValueMember = "Id";
            cmbColor.SelectedIndex = -1;

            // Groups
            dtGroups = ClsGroup.GetGroupsDataTable();
            cmbGroup.DataSource = dtGroups;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "GroupID";
            cmbGroup.SelectedIndex = -1;

            // Branches
            dtBranches = ClsBranch.GetBranchesDataTable();
            cmbBranch.DataSource = dtBranches;
            cmbBranch.DisplayMember = "name";
            cmbBranch.ValueMember = "branch_id";
            cmbBranch.SelectedIndex = -1;

            dtFuelTypes = ClsFuelType.GetFuelTypesDataTable();
            cmbFuelType.DataSource = dtFuelTypes;
            cmbFuelType.DisplayMember = "Name";
            cmbFuelType.ValueMember = "Id";
            cmbFuelType.SelectedIndex = -1;
        }

        private void LoadCarData(int carId)
        {
            ClsCar car = ClsCar.FindById(carId);
            if (car == null)
            {
                MessageBox.Show("Car not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtCarNameEn.Text = car.CarNameEn;
            txtCarNameAr.Text = car.CarNameAr;
            numYear.Value = car.Year;

            cmbColor.SelectedValue = car.CarID;
            cmbCategory.SelectedValue = car.CategoryId;
            cmbGroup.SelectedValue = car.GroupId;
            cmbBranch.SelectedValue = car.BranchId;
            cmbFuelType.SelectedValue = car.FuelTypeID;

            txtPlateNumber.Text = car.PlateNumber;
            numCarPrice.Value = car.CarPrice;
            chkIsAvailable.Checked = car.IsAvailable;

            numInitialCounter.Value = car.InitialCounter;
            numNumberOfRiders.Value = car.NumberOfRiders;
            dtpLicenseDate.Value = (DateTime)car.LicenseDate;
            dtpExpiryLicenseDate.Value = (DateTime)car.ExpiryLicenseDate;
            numEngineSize.Value = (decimal)car.EngineSize;
            txtCarNumber.Text = car.CarNumber;
            numCurrentCounter.Value = car.CurrentCounter;
            txtChassisNumber.Text = car.ChassisNumber;
            txtEngineNumber.Text = car.EngineNumber;
            numNumberOfSeats.Value = car.NumberOfSeats;
            numNumberOfDoors.Value = car.NumberOfDoors;
            txtGasolineType.Text = car.GasolineType;
            txtLicenseType.Text = car.LicenseType;
            txtUsedFor.Text = car.UsedFor;
            numDamagesNumber.Value = (decimal)car.DamagesNumber;
            txtDescription.Text = car.Description;
            txtFuelExit.Text = car.FuelExit;

            // Load image if exists
            if (!string.IsNullOrEmpty(car.CarImage))
            {
                string imageFullPath = Path.Combine(Application.StartupPath, "carImages", car.CarImage);
                if (File.Exists(imageFullPath))
                {
                    pbCar.Image = Image.FromFile(imageFullPath);
                    _currentImagePath = car.CarImage;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Please correct the input errors.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string carNameEn = txtCarNameEn.Text.Trim();
            string carNameAr = txtCarNameAr.Text.Trim();
            int year = (int)numYear.Value;
            int? colorId = cmbColor.SelectedValue as int?;

            int? categoryId = cmbCategory.SelectedValue as int?;
            int? groupId = cmbGroup.SelectedValue as int?;
            int? branchId = cmbBranch.SelectedValue as int?;
            int? fuelTypeId = cmbFuelType.SelectedValue as int?;

            string plateNumber = txtPlateNumber.Text.Trim();
            decimal carPrice = numCarPrice.Value;
            bool isAvailable = chkIsAvailable.Checked;
            int initialCouter = (int)numInitialCounter.Value;
            int NumberOfRiders = (int)numNumberOfRiders.Value;
            DateTime License = dtpLicenseDate.Value;
            DateTime LicenseExpiryDate = dtpExpiryLicenseDate.Value;
            decimal EngineSize = (decimal)numEngineSize.Value;
            string CarNumber = txtCarNumber.Text.Trim();
            int currentCounter = (int)numCurrentCounter.Value;
            string ChassisNumber = txtChassisNumber.Text.Trim();
            string EngineNubmer = txtEngineNumber.Text.Trim();
            int nubmerOfSeats = (int)numNumberOfSeats.Value;
            int NubmerOfDoros = (int)numNumberOfDoors.Value;
            string gaslionType = txtGasolineType.Text.Trim();
            string LicenseType = txtLicenseType.Text.Trim();
            string UsedFor = txtUsedFor.Text.Trim();
            int DamagesNubmer = (int)numDamagesNumber.Value;
            string Descripton = txtDescription.Text.Trim();
            string FuelExit = txtFuelExit.Text.Trim();
            int NubmerOfLoads = (int)numNumberOfLoads.Value;
            string NumberOfResgistation = txtNumberOfRegistration.Text.Trim();

            if (string.IsNullOrEmpty(carNameEn))
            {
                errorProvider1.SetError(txtCarNameEn, "Car English name is required.");
                return;
            }
            else
                errorProvider1.SetError(txtCarNameEn, "");

            if (categoryId == null)
            {
                errorProvider1.SetError(cmbCategory, "Please select a category.");
                return;
            }
            else
                errorProvider1.SetError(cmbCategory, "");

            if (groupId == null)
            {
                errorProvider1.SetError(cmbGroup, "Please select a group.");
                return;
            }
            else
                errorProvider1.SetError(cmbGroup, "");

            if (branchId == null)
            {
                errorProvider1.SetError(cmbBranch, "Please select a branch.");
                return;
            }
            else
                errorProvider1.SetError(cmbBranch, "");

            if (fuelTypeId == null)
            {
                errorProvider1.SetError(cmbFuelType, "Please select a fuel type.");
                return;
            }
            else
                errorProvider1.SetError(cmbFuelType, "");

            ClsCar car;

            if (_carId.HasValue)
            {
                car = ClsCar.FindById(_carId.Value);
                if (car == null)
                {
                    MessageBox.Show("Car not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                car = new ClsCar();
            }

            // Save data to object
            car.CarNameEn = carNameEn;
            car.CarNameAr = carNameAr;
            car.Year = year;
            car.ColorId = (int)colorId;
            car.CategoryId = categoryId.Value;
            car.GroupId = groupId.Value;
            car.BranchId = branchId.Value;
            car.FuelTypeID = fuelTypeId.Value;
            car.PlateNumber = plateNumber;
            car.CarPrice = carPrice;
            car.IsAvailable = isAvailable;

            car.InitialCounter = initialCouter;
            car.NumberOfRiders = NumberOfRiders;
            car.LicenseDate = License;
            car.ExpiryLicenseDate = LicenseExpiryDate;
            car.EngineSize = (decimal)EngineSize;
            car.CarNumber = CarNumber;
            car.CurrentCounter = currentCounter;
            car.ChassisNumber = ChassisNumber;
            car.EngineNumber = EngineNubmer;
            car.NumberOfSeats = nubmerOfSeats;
            car.NumberOfDoors = NubmerOfDoros;
            car.GasolineType = gaslionType;
            car.LicenseType = LicenseType;
            car.UsedFor = UsedFor;
            car.DamagesNumber = DamagesNubmer;
            car.Description = Descripton;
            car.FuelExit = FuelExit;
            car.NumberOfRegistration = NumberOfResgistation;
            car.NumberOfLoads = NubmerOfLoads;

            // Save image
            if (pbCar.Image != null)
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "carImages");
                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                // If editing and image exists, delete old one
                if (!string.IsNullOrEmpty(_currentImagePath))
                {
                    string oldImageFull = Path.Combine(imagesFolder, _currentImagePath);
                    if (File.Exists(oldImageFull))
                        File.Delete(oldImageFull);
                }

                string imageName = Guid.NewGuid().ToString() + ".jpg";
                string imagePath = Path.Combine(imagesFolder, imageName);
                pbCar.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                car.CarImage = imageName;
            }

            bool success = car.Save();

            if (success)
            {
                MessageBox.Show("Car saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarSaved?.Invoke((int)car.CarID);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save car.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 🧩 The LinkLabel replaces the Browse button
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            menu.Items.Add("📷 Browse Image", null, (s, ev) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    ofd.Title = "Select Car Image";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            pbCar.Image = Image.FromFile(ofd.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            });

            menu.Items.Add("📁 Open Image Folder", null, (s, ev) =>
            {
                string folderPath = Path.Combine(Application.StartupPath, "carImages");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                System.Diagnostics.Process.Start("explorer.exe", folderPath);
            });

            menu.Show(Cursor.Position);
        }

        private void frmAddUpdateVehicle_Load(object sender, EventArgs e)
        {

        }
    }
}
