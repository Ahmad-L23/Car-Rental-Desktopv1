using System;
using System.ComponentModel;

namespace CarRentalSystem.Car
{
    partial class frmAddUpdateVehicle
    {
        private System.ComponentModel.IContainer components = null;

        // Labels
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCarNameEn;
        private System.Windows.Forms.Label lblCarNameAr;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblFuelType;
        private System.Windows.Forms.Label lblInitialCounter;
        private System.Windows.Forms.Label lblNumberOfRiders;
        private System.Windows.Forms.Label lblNumberOfLoads;
        private System.Windows.Forms.Label lblLicenseDate;
        private System.Windows.Forms.Label lblExpiryLicenseDate;
        private System.Windows.Forms.Label lblNumberOfRegistration;
        private System.Windows.Forms.Label lblCarNumber;
        private System.Windows.Forms.Label lblEngineSize;
        private System.Windows.Forms.Label lblChassisNumber;
        private System.Windows.Forms.Label lblCurrentCounter;
        private System.Windows.Forms.Label lblNumberOfSeats;
        private System.Windows.Forms.Label lblEngineNumber;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.Label lblNumberOfDoors;
        private System.Windows.Forms.Label lblGasolineType;
        private System.Windows.Forms.Label lblCarPrice;
        private System.Windows.Forms.Label lblLicenseType;
        private System.Windows.Forms.Label lblUsedFor;
        private System.Windows.Forms.Label lblDamagesNumber;
        private System.Windows.Forms.Label lblDescription;

        // TextBoxes
        private System.Windows.Forms.TextBox txtCarNameEn;
        private System.Windows.Forms.TextBox txtCarNameAr;
        private System.Windows.Forms.TextBox txtNumberOfRegistration;
        private System.Windows.Forms.TextBox txtCarNumber;
        private System.Windows.Forms.TextBox txtChassisNumber;
        private System.Windows.Forms.TextBox txtEngineNumber;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.TextBox txtGasolineType;
        private System.Windows.Forms.TextBox txtLicenseType;
        private System.Windows.Forms.TextBox txtUsedFor;
        private System.Windows.Forms.TextBox txtDescription;

        // NumericUpDowns
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.NumericUpDown numInitialCounter;
        private System.Windows.Forms.NumericUpDown numNumberOfRiders;
        private System.Windows.Forms.NumericUpDown numNumberOfLoads;
        private System.Windows.Forms.NumericUpDown numEngineSize;
        private System.Windows.Forms.NumericUpDown numCurrentCounter;
        private System.Windows.Forms.NumericUpDown numNumberOfSeats;
        private System.Windows.Forms.NumericUpDown numNumberOfDoors;
        private System.Windows.Forms.NumericUpDown numCarPrice;
        private System.Windows.Forms.NumericUpDown numDamagesNumber;

        // DateTimePickers
        private System.Windows.Forms.DateTimePicker dtpLicenseDate;
        private System.Windows.Forms.DateTimePicker dtpExpiryLicenseDate;

        // ComboBoxes
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbFuelType;

        // CheckBox
        private System.Windows.Forms.CheckBox chkIsAvailable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        // ErrorProvider
        private System.Windows.Forms.ErrorProvider errorProvider1;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCarNameEn = new System.Windows.Forms.Label();
            this.txtCarNameEn = new System.Windows.Forms.TextBox();
            this.lblCarNameAr = new System.Windows.Forms.Label();
            this.txtCarNameAr = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.lblFuelType = new System.Windows.Forms.Label();
            this.cmbFuelType = new System.Windows.Forms.ComboBox();
            this.lblInitialCounter = new System.Windows.Forms.Label();
            this.numInitialCounter = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfRiders = new System.Windows.Forms.Label();
            this.numNumberOfRiders = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfLoads = new System.Windows.Forms.Label();
            this.numNumberOfLoads = new System.Windows.Forms.NumericUpDown();
            this.lblLicenseDate = new System.Windows.Forms.Label();
            this.dtpLicenseDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpiryLicenseDate = new System.Windows.Forms.Label();
            this.dtpExpiryLicenseDate = new System.Windows.Forms.DateTimePicker();
            this.lblNumberOfRegistration = new System.Windows.Forms.Label();
            this.txtNumberOfRegistration = new System.Windows.Forms.TextBox();
            this.lblCarNumber = new System.Windows.Forms.Label();
            this.txtCarNumber = new System.Windows.Forms.TextBox();
            this.lblEngineSize = new System.Windows.Forms.Label();
            this.numEngineSize = new System.Windows.Forms.NumericUpDown();
            this.lblChassisNumber = new System.Windows.Forms.Label();
            this.txtChassisNumber = new System.Windows.Forms.TextBox();
            this.lblCurrentCounter = new System.Windows.Forms.Label();
            this.numCurrentCounter = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfSeats = new System.Windows.Forms.Label();
            this.numNumberOfSeats = new System.Windows.Forms.NumericUpDown();
            this.lblEngineNumber = new System.Windows.Forms.Label();
            this.txtEngineNumber = new System.Windows.Forms.TextBox();
            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.lblNumberOfDoors = new System.Windows.Forms.Label();
            this.numNumberOfDoors = new System.Windows.Forms.NumericUpDown();
            this.lblGasolineType = new System.Windows.Forms.Label();
            this.txtGasolineType = new System.Windows.Forms.TextBox();
            this.lblCarPrice = new System.Windows.Forms.Label();
            this.numCarPrice = new System.Windows.Forms.NumericUpDown();
            this.lblLicenseType = new System.Windows.Forms.Label();
            this.txtLicenseType = new System.Windows.Forms.TextBox();
            this.chkIsAvailable = new System.Windows.Forms.CheckBox();
            this.lblUsedFor = new System.Windows.Forms.Label();
            this.txtUsedFor = new System.Windows.Forms.TextBox();
            this.lblDamagesNumber = new System.Windows.Forms.Label();
            this.numDamagesNumber = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbCar = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfRiders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfLoads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEngineSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfDoors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCarPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDamagesNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCar)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(594, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(164, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Car";
            // 
            // lblCarNameEn
            // 
            this.lblCarNameEn.AutoSize = true;
            this.lblCarNameEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarNameEn.Location = new System.Drawing.Point(13, 32);
            this.lblCarNameEn.Name = "lblCarNameEn";
            this.lblCarNameEn.Size = new System.Drawing.Size(101, 16);
            this.lblCarNameEn.TabIndex = 1;
            this.lblCarNameEn.Text = "Car Name (EN):";
            // 
            // txtCarNameEn
            // 
            this.txtCarNameEn.Location = new System.Drawing.Point(138, 29);
            this.txtCarNameEn.Name = "txtCarNameEn";
            this.txtCarNameEn.Size = new System.Drawing.Size(200, 20);
            this.txtCarNameEn.TabIndex = 2;
            // 
            // lblCarNameAr
            // 
            this.lblCarNameAr.AutoSize = true;
            this.lblCarNameAr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarNameAr.Location = new System.Drawing.Point(13, 74);
            this.lblCarNameAr.Name = "lblCarNameAr";
            this.lblCarNameAr.Size = new System.Drawing.Size(101, 16);
            this.lblCarNameAr.TabIndex = 3;
            this.lblCarNameAr.Text = "Car Name (AR):";
            // 
            // txtCarNameAr
            // 
            this.txtCarNameAr.Location = new System.Drawing.Point(138, 71);
            this.txtCarNameAr.Name = "txtCarNameAr";
            this.txtCarNameAr.Size = new System.Drawing.Size(200, 20);
            this.txtCarNameAr.TabIndex = 4;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(13, 116);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(39, 16);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "Year:";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(138, 113);
            this.numYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(100, 20);
            this.numYear.TabIndex = 6;
            this.numYear.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(13, 158);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(42, 16);
            this.lblColor.TabIndex = 7;
            this.lblColor.Text = "Color:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(13, 197);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 16);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(138, 197);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 21);
            this.cmbCategory.TabIndex = 10;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(15, 243);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(47, 16);
            this.lblGroup.TabIndex = 11;
            this.lblGroup.Text = "Group:";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.Location = new System.Drawing.Point(138, 239);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(200, 21);
            this.cmbGroup.TabIndex = 12;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.Location = new System.Drawing.Point(366, 31);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(52, 16);
            this.lblBranch.TabIndex = 13;
            this.lblBranch.Text = "Branch:";
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Location = new System.Drawing.Point(514, 26);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(200, 21);
            this.cmbBranch.TabIndex = 14;
            // 
            // lblFuelType
            // 
            this.lblFuelType.AutoSize = true;
            this.lblFuelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuelType.Location = new System.Drawing.Point(368, 74);
            this.lblFuelType.Name = "lblFuelType";
            this.lblFuelType.Size = new System.Drawing.Size(71, 16);
            this.lblFuelType.TabIndex = 15;
            this.lblFuelType.Text = "Fuel Type:";
            // 
            // cmbFuelType
            // 
            this.cmbFuelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFuelType.Location = new System.Drawing.Point(514, 69);
            this.cmbFuelType.Name = "cmbFuelType";
            this.cmbFuelType.Size = new System.Drawing.Size(200, 21);
            this.cmbFuelType.TabIndex = 16;
            // 
            // lblInitialCounter
            // 
            this.lblInitialCounter.AutoSize = true;
            this.lblInitialCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialCounter.Location = new System.Drawing.Point(8, 183);
            this.lblInitialCounter.Name = "lblInitialCounter";
            this.lblInitialCounter.Size = new System.Drawing.Size(89, 16);
            this.lblInitialCounter.TabIndex = 20;
            this.lblInitialCounter.Text = "Initial Counter:";
            // 
            // numInitialCounter
            // 
            this.numInitialCounter.Location = new System.Drawing.Point(133, 180);
            this.numInitialCounter.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numInitialCounter.Name = "numInitialCounter";
            this.numInitialCounter.Size = new System.Drawing.Size(100, 20);
            this.numInitialCounter.TabIndex = 21;
            // 
            // lblNumberOfRiders
            // 
            this.lblNumberOfRiders.AutoSize = true;
            this.lblNumberOfRiders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRiders.Location = new System.Drawing.Point(268, 183);
            this.lblNumberOfRiders.Name = "lblNumberOfRiders";
            this.lblNumberOfRiders.Size = new System.Drawing.Size(117, 16);
            this.lblNumberOfRiders.TabIndex = 22;
            this.lblNumberOfRiders.Text = "Number Of Riders:";
            // 
            // numNumberOfRiders
            // 
            this.numNumberOfRiders.Location = new System.Drawing.Point(391, 178);
            this.numNumberOfRiders.Name = "numNumberOfRiders";
            this.numNumberOfRiders.Size = new System.Drawing.Size(97, 20);
            this.numNumberOfRiders.TabIndex = 23;
            // 
            // lblNumberOfLoads
            // 
            this.lblNumberOfLoads.AutoSize = true;
            this.lblNumberOfLoads.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfLoads.Location = new System.Drawing.Point(10, 145);
            this.lblNumberOfLoads.Name = "lblNumberOfLoads";
            this.lblNumberOfLoads.Size = new System.Drawing.Size(115, 16);
            this.lblNumberOfLoads.TabIndex = 24;
            this.lblNumberOfLoads.Text = "Number Of Loads:";
            // 
            // numNumberOfLoads
            // 
            this.numNumberOfLoads.Location = new System.Drawing.Point(133, 142);
            this.numNumberOfLoads.Name = "numNumberOfLoads";
            this.numNumberOfLoads.Size = new System.Drawing.Size(100, 20);
            this.numNumberOfLoads.TabIndex = 25;
            // 
            // lblLicenseDate
            // 
            this.lblLicenseDate.AutoSize = true;
            this.lblLicenseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseDate.Location = new System.Drawing.Point(6, 74);
            this.lblLicenseDate.Name = "lblLicenseDate";
            this.lblLicenseDate.Size = new System.Drawing.Size(89, 16);
            this.lblLicenseDate.TabIndex = 26;
            this.lblLicenseDate.Text = "License Date:";
            // 
            // dtpLicenseDate
            // 
            this.dtpLicenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLicenseDate.Location = new System.Drawing.Point(141, 72);
            this.dtpLicenseDate.Name = "dtpLicenseDate";
            this.dtpLicenseDate.Size = new System.Drawing.Size(200, 20);
            this.dtpLicenseDate.TabIndex = 27;
            // 
            // lblExpiryLicenseDate
            // 
            this.lblExpiryLicenseDate.AutoSize = true;
            this.lblExpiryLicenseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiryLicenseDate.Location = new System.Drawing.Point(7, 116);
            this.lblExpiryLicenseDate.Name = "lblExpiryLicenseDate";
            this.lblExpiryLicenseDate.Size = new System.Drawing.Size(129, 16);
            this.lblExpiryLicenseDate.TabIndex = 28;
            this.lblExpiryLicenseDate.Text = "Expiry License Date:";
            // 
            // dtpExpiryLicenseDate
            // 
            this.dtpExpiryLicenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiryLicenseDate.Location = new System.Drawing.Point(141, 114);
            this.dtpExpiryLicenseDate.Name = "dtpExpiryLicenseDate";
            this.dtpExpiryLicenseDate.Size = new System.Drawing.Size(200, 20);
            this.dtpExpiryLicenseDate.TabIndex = 29;
            // 
            // lblNumberOfRegistration
            // 
            this.lblNumberOfRegistration.AutoSize = true;
            this.lblNumberOfRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRegistration.Location = new System.Drawing.Point(362, 114);
            this.lblNumberOfRegistration.Name = "lblNumberOfRegistration";
            this.lblNumberOfRegistration.Size = new System.Drawing.Size(149, 16);
            this.lblNumberOfRegistration.TabIndex = 30;
            this.lblNumberOfRegistration.Text = "Number Of Registration:";
            // 
            // txtNumberOfRegistration
            // 
            this.txtNumberOfRegistration.Location = new System.Drawing.Point(514, 111);
            this.txtNumberOfRegistration.Name = "txtNumberOfRegistration";
            this.txtNumberOfRegistration.Size = new System.Drawing.Size(200, 20);
            this.txtNumberOfRegistration.TabIndex = 31;
            // 
            // lblCarNumber
            // 
            this.lblCarNumber.AutoSize = true;
            this.lblCarNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarNumber.Location = new System.Drawing.Point(13, 331);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new System.Drawing.Size(82, 16);
            this.lblCarNumber.TabIndex = 32;
            this.lblCarNumber.Text = "Car Number:";
            // 
            // txtCarNumber
            // 
            this.txtCarNumber.Location = new System.Drawing.Point(138, 330);
            this.txtCarNumber.Name = "txtCarNumber";
            this.txtCarNumber.Size = new System.Drawing.Size(200, 20);
            this.txtCarNumber.TabIndex = 33;
            // 
            // lblEngineSize
            // 
            this.lblEngineSize.AutoSize = true;
            this.lblEngineSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngineSize.Location = new System.Drawing.Point(8, 107);
            this.lblEngineSize.Name = "lblEngineSize";
            this.lblEngineSize.Size = new System.Drawing.Size(81, 16);
            this.lblEngineSize.TabIndex = 34;
            this.lblEngineSize.Text = "Engine Size:";
            // 
            // numEngineSize
            // 
            this.numEngineSize.DecimalPlaces = 2;
            this.numEngineSize.Location = new System.Drawing.Point(133, 104);
            this.numEngineSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numEngineSize.Name = "numEngineSize";
            this.numEngineSize.Size = new System.Drawing.Size(100, 20);
            this.numEngineSize.TabIndex = 35;
            // 
            // lblChassisNumber
            // 
            this.lblChassisNumber.AutoSize = true;
            this.lblChassisNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChassisNumber.Location = new System.Drawing.Point(259, 23);
            this.lblChassisNumber.Name = "lblChassisNumber";
            this.lblChassisNumber.Size = new System.Drawing.Size(109, 16);
            this.lblChassisNumber.TabIndex = 36;
            this.lblChassisNumber.Text = "Chassis Number:";
            // 
            // txtChassisNumber
            // 
            this.txtChassisNumber.Location = new System.Drawing.Point(388, 22);
            this.txtChassisNumber.Name = "txtChassisNumber";
            this.txtChassisNumber.Size = new System.Drawing.Size(200, 20);
            this.txtChassisNumber.TabIndex = 37;
            // 
            // lblCurrentCounter
            // 
            this.lblCurrentCounter.AutoSize = true;
            this.lblCurrentCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCounter.Location = new System.Drawing.Point(263, 143);
            this.lblCurrentCounter.Name = "lblCurrentCounter";
            this.lblCurrentCounter.Size = new System.Drawing.Size(101, 16);
            this.lblCurrentCounter.TabIndex = 38;
            this.lblCurrentCounter.Text = "Current Counter:";
            // 
            // numCurrentCounter
            // 
            this.numCurrentCounter.Location = new System.Drawing.Point(388, 139);
            this.numCurrentCounter.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCurrentCounter.Name = "numCurrentCounter";
            this.numCurrentCounter.Size = new System.Drawing.Size(100, 20);
            this.numCurrentCounter.TabIndex = 39;
            // 
            // lblNumberOfSeats
            // 
            this.lblNumberOfSeats.AutoSize = true;
            this.lblNumberOfSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfSeats.Location = new System.Drawing.Point(13, 31);
            this.lblNumberOfSeats.Name = "lblNumberOfSeats";
            this.lblNumberOfSeats.Size = new System.Drawing.Size(112, 16);
            this.lblNumberOfSeats.TabIndex = 40;
            this.lblNumberOfSeats.Text = "Number Of Seats:";
            // 
            // numNumberOfSeats
            // 
            this.numNumberOfSeats.Location = new System.Drawing.Point(133, 28);
            this.numNumberOfSeats.Name = "numNumberOfSeats";
            this.numNumberOfSeats.Size = new System.Drawing.Size(100, 20);
            this.numNumberOfSeats.TabIndex = 41;
            // 
            // lblEngineNumber
            // 
            this.lblEngineNumber.AutoSize = true;
            this.lblEngineNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngineNumber.Location = new System.Drawing.Point(261, 63);
            this.lblEngineNumber.Name = "lblEngineNumber";
            this.lblEngineNumber.Size = new System.Drawing.Size(103, 16);
            this.lblEngineNumber.TabIndex = 42;
            this.lblEngineNumber.Text = "Engine Number:";
            // 
            // txtEngineNumber
            // 
            this.txtEngineNumber.Location = new System.Drawing.Point(388, 61);
            this.txtEngineNumber.Name = "txtEngineNumber";
            this.txtEngineNumber.Size = new System.Drawing.Size(200, 20);
            this.txtEngineNumber.TabIndex = 43;
            // 
            // lblPlateNumber
            // 
            this.lblPlateNumber.AutoSize = true;
            this.lblPlateNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlateNumber.Location = new System.Drawing.Point(6, 31);
            this.lblPlateNumber.Name = "lblPlateNumber";
            this.lblPlateNumber.Size = new System.Drawing.Size(92, 16);
            this.lblPlateNumber.TabIndex = 44;
            this.lblPlateNumber.Text = "Plate Number:";
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.Location = new System.Drawing.Point(141, 30);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.Size = new System.Drawing.Size(200, 20);
            this.txtPlateNumber.TabIndex = 45;
            // 
            // lblNumberOfDoors
            // 
            this.lblNumberOfDoors.AutoSize = true;
            this.lblNumberOfDoors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfDoors.Location = new System.Drawing.Point(8, 69);
            this.lblNumberOfDoors.Name = "lblNumberOfDoors";
            this.lblNumberOfDoors.Size = new System.Drawing.Size(114, 16);
            this.lblNumberOfDoors.TabIndex = 46;
            this.lblNumberOfDoors.Text = "Number Of Doors:";
            // 
            // numNumberOfDoors
            // 
            this.numNumberOfDoors.Location = new System.Drawing.Point(133, 66);
            this.numNumberOfDoors.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numNumberOfDoors.Name = "numNumberOfDoors";
            this.numNumberOfDoors.Size = new System.Drawing.Size(100, 20);
            this.numNumberOfDoors.TabIndex = 47;
            // 
            // lblGasolineType
            // 
            this.lblGasolineType.AutoSize = true;
            this.lblGasolineType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGasolineType.Location = new System.Drawing.Point(263, 103);
            this.lblGasolineType.Name = "lblGasolineType";
            this.lblGasolineType.Size = new System.Drawing.Size(99, 16);
            this.lblGasolineType.TabIndex = 48;
            this.lblGasolineType.Text = "Gasoline Type:";
            // 
            // txtGasolineType
            // 
            this.txtGasolineType.Location = new System.Drawing.Point(388, 100);
            this.txtGasolineType.Name = "txtGasolineType";
            this.txtGasolineType.Size = new System.Drawing.Size(200, 20);
            this.txtGasolineType.TabIndex = 49;
            // 
            // lblCarPrice
            // 
            this.lblCarPrice.AutoSize = true;
            this.lblCarPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarPrice.Location = new System.Drawing.Point(13, 289);
            this.lblCarPrice.Name = "lblCarPrice";
            this.lblCarPrice.Size = new System.Drawing.Size(65, 16);
            this.lblCarPrice.TabIndex = 50;
            this.lblCarPrice.Text = "Car Price:";
            // 
            // numCarPrice
            // 
            this.numCarPrice.DecimalPlaces = 2;
            this.numCarPrice.Location = new System.Drawing.Point(138, 286);
            this.numCarPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numCarPrice.Name = "numCarPrice";
            this.numCarPrice.Size = new System.Drawing.Size(200, 20);
            this.numCarPrice.TabIndex = 51;
            // 
            // lblLicenseType
            // 
            this.lblLicenseType.AutoSize = true;
            this.lblLicenseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseType.Location = new System.Drawing.Point(366, 215);
            this.lblLicenseType.Name = "lblLicenseType";
            this.lblLicenseType.Size = new System.Drawing.Size(92, 16);
            this.lblLicenseType.TabIndex = 52;
            this.lblLicenseType.Text = "License Type:";
            // 
            // txtLicenseType
            // 
            this.txtLicenseType.Location = new System.Drawing.Point(493, 211);
            this.txtLicenseType.Name = "txtLicenseType";
            this.txtLicenseType.Size = new System.Drawing.Size(200, 20);
            this.txtLicenseType.TabIndex = 53;
            // 
            // chkIsAvailable
            // 
            this.chkIsAvailable.AutoSize = true;
            this.chkIsAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsAvailable.Location = new System.Drawing.Point(138, 368);
            this.chkIsAvailable.Name = "chkIsAvailable";
            this.chkIsAvailable.Size = new System.Drawing.Size(99, 22);
            this.chkIsAvailable.TabIndex = 54;
            this.chkIsAvailable.Text = "Is Available";
            this.chkIsAvailable.UseVisualStyleBackColor = true;
            // 
            // lblUsedFor
            // 
            this.lblUsedFor.AutoSize = true;
            this.lblUsedFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedFor.Location = new System.Drawing.Point(366, 32);
            this.lblUsedFor.Name = "lblUsedFor";
            this.lblUsedFor.Size = new System.Drawing.Size(66, 16);
            this.lblUsedFor.TabIndex = 55;
            this.lblUsedFor.Text = "Used For:";
            // 
            // txtUsedFor
            // 
            this.txtUsedFor.Location = new System.Drawing.Point(497, 29);
            this.txtUsedFor.Multiline = true;
            this.txtUsedFor.Name = "txtUsedFor";
            this.txtUsedFor.Size = new System.Drawing.Size(200, 53);
            this.txtUsedFor.TabIndex = 56;
            // 
            // lblDamagesNumber
            // 
            this.lblDamagesNumber.AutoSize = true;
            this.lblDamagesNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDamagesNumber.Location = new System.Drawing.Point(366, 248);
            this.lblDamagesNumber.Name = "lblDamagesNumber";
            this.lblDamagesNumber.Size = new System.Drawing.Size(121, 16);
            this.lblDamagesNumber.TabIndex = 57;
            this.lblDamagesNumber.Text = "Damages Number:";
            // 
            // numDamagesNumber
            // 
            this.numDamagesNumber.Location = new System.Drawing.Point(493, 248);
            this.numDamagesNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDamagesNumber.Name = "numDamagesNumber";
            this.numDamagesNumber.Size = new System.Drawing.Size(89, 20);
            this.numDamagesNumber.TabIndex = 58;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(366, 88);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(78, 16);
            this.lblDescription.TabIndex = 59;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(497, 88);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 100);
            this.txtDescription.TabIndex = 60;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(633, 691);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 50);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(754, 691);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 50);
            this.btnCancel.TabIndex = 62;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pbCar
            // 
            this.pbCar.Location = new System.Drawing.Point(16, 223);
            this.pbCar.Name = "pbCar";
            this.pbCar.Size = new System.Drawing.Size(178, 103);
            this.pbCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCar.TabIndex = 63;
            this.pbCar.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(78, 347);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 64;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Set Image";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1353, 74);
            this.panel1.TabIndex = 65;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.cmbColor);
            this.groupBox1.Controls.Add(this.lblCarNameEn);
            this.groupBox1.Controls.Add(this.numYear);
            this.groupBox1.Controls.Add(this.lblYear);
            this.groupBox1.Controls.Add(this.txtCarNameAr);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.lblColor);
            this.groupBox1.Controls.Add(this.lblDamagesNumber);
            this.groupBox1.Controls.Add(this.numDamagesNumber);
            this.groupBox1.Controls.Add(this.lblLicenseType);
            this.groupBox1.Controls.Add(this.lblGroup);
            this.groupBox1.Controls.Add(this.txtLicenseType);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.lblUsedFor);
            this.groupBox1.Controls.Add(this.chkIsAvailable);
            this.groupBox1.Controls.Add(this.txtUsedFor);
            this.groupBox1.Controls.Add(this.cmbGroup);
            this.groupBox1.Controls.Add(this.lblCarNameAr);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtCarNameEn);
            this.groupBox1.Controls.Add(this.numCarPrice);
            this.groupBox1.Controls.Add(this.lblCarNumber);
            this.groupBox1.Controls.Add(this.lblCarPrice);
            this.groupBox1.Controls.Add(this.txtCarNumber);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(7, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 409);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Car Basic Info";
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(138, 158);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(203, 21);
            this.cmbColor.TabIndex = 61;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.txtPlateNumber);
            this.groupBox2.Controls.Add(this.lblPlateNumber);
            this.groupBox2.Controls.Add(this.dtpLicenseDate);
            this.groupBox2.Controls.Add(this.dtpExpiryLicenseDate);
            this.groupBox2.Controls.Add(this.lblExpiryLicenseDate);
            this.groupBox2.Controls.Add(this.lblLicenseDate);
            this.groupBox2.Controls.Add(this.cmbBranch);
            this.groupBox2.Controls.Add(this.lblFuelType);
            this.groupBox2.Controls.Add(this.lblBranch);
            this.groupBox2.Controls.Add(this.cmbFuelType);
            this.groupBox2.Controls.Add(this.txtNumberOfRegistration);
            this.groupBox2.Controls.Add(this.lblNumberOfRegistration);
            this.groupBox2.Location = new System.Drawing.Point(7, 495);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(720, 157);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Car Registration Info";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox3.Controls.Add(this.numNumberOfSeats);
            this.groupBox3.Controls.Add(this.lblNumberOfSeats);
            this.groupBox3.Controls.Add(this.numNumberOfDoors);
            this.groupBox3.Controls.Add(this.lblNumberOfDoors);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Controls.Add(this.numEngineSize);
            this.groupBox3.Controls.Add(this.pbCar);
            this.groupBox3.Controls.Add(this.lblEngineSize);
            this.groupBox3.Controls.Add(this.lblNumberOfRiders);
            this.groupBox3.Controls.Add(this.lblNumberOfLoads);
            this.groupBox3.Controls.Add(this.txtChassisNumber);
            this.groupBox3.Controls.Add(this.lblInitialCounter);
            this.groupBox3.Controls.Add(this.numNumberOfLoads);
            this.groupBox3.Controls.Add(this.lblChassisNumber);
            this.groupBox3.Controls.Add(this.numNumberOfRiders);
            this.groupBox3.Controls.Add(this.txtEngineNumber);
            this.groupBox3.Controls.Add(this.lblEngineNumber);
            this.groupBox3.Controls.Add(this.lblGasolineType);
            this.groupBox3.Controls.Add(this.numInitialCounter);
            this.groupBox3.Controls.Add(this.txtGasolineType);
            this.groupBox3.Controls.Add(this.numCurrentCounter);
            this.groupBox3.Controls.Add(this.lblCurrentCounter);
            this.groupBox3.Location = new System.Drawing.Point(733, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(608, 409);
            this.groupBox3.TabIndex = 68;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Specifications";
            // 
            // frmAddUpdateVehicle
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1353, 756);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdateVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Car";
            this.Load += new System.EventHandler(this.frmAddUpdateVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfRiders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfLoads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEngineSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfDoors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCarPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDamagesNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pbCar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbColor;
    }
}
