namespace CarRentalSystem.Document
{
    partial class frmAddUpdateDocument
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCustomerIdLabel;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Label lblCustomerNameLabel;
        private System.Windows.Forms.Label lblCustomerName;

        private System.Windows.Forms.Label lblIdTypeEn;
        private System.Windows.Forms.ComboBox cmbIdTypeEn; // ComboBox for English ID Type
        private System.Windows.Forms.Label lblIdTypeAr;
        private System.Windows.Forms.ComboBox cmbIdTypeAr; // ComboBox for Arabic ID Type

        private System.Windows.Forms.Label lblIdNumber;
        private System.Windows.Forms.TextBox txtIdNumber;

        private System.Windows.Forms.Label lblIdentityNumber;
        private System.Windows.Forms.TextBox txtIdentityNumber;

        private System.Windows.Forms.Label lblLicenseNumber;
        private System.Windows.Forms.TextBox txtLicenseNumber;

        private System.Windows.Forms.Label lblLicenseCategoryEn;
        private System.Windows.Forms.TextBox txtLicenseCategoryEn;
        private System.Windows.Forms.Label lblLicenseCategoryAr;
        private System.Windows.Forms.TextBox txtLicenseCategoryAr;

        private System.Windows.Forms.Label lblLicensePlaceOfIssueEn;
        private System.Windows.Forms.TextBox txtLicensePlaceOfIssueEn;
        private System.Windows.Forms.Label lblLicensePlaceOfIssueAr;
        private System.Windows.Forms.TextBox txtLicensePlaceOfIssueAr;

        private System.Windows.Forms.Label lblLicenseIssueDate;
        private System.Windows.Forms.DateTimePicker dtpLicenseIssueDate;

        private System.Windows.Forms.Label lblLicenseExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpLicenseExpiryDate;

        private System.Windows.Forms.Label lblIdentityPlaceOfIssueEn;
        private System.Windows.Forms.TextBox txtIdentityPlaceOfIssueEn;
        private System.Windows.Forms.Label lblIdentityPlaceOfIssueAr;
        private System.Windows.Forms.TextBox txtIdentityPlaceOfIssueAr;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCustomerIdLabel = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.lblCustomerNameLabel = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblIdTypeEn = new System.Windows.Forms.Label();
            this.cmbIdTypeEn = new System.Windows.Forms.ComboBox();
            this.lblIdTypeAr = new System.Windows.Forms.Label();
            this.cmbIdTypeAr = new System.Windows.Forms.ComboBox();
            this.lblIdNumber = new System.Windows.Forms.Label();
            this.txtIdNumber = new System.Windows.Forms.TextBox();
            this.lblIdentityNumber = new System.Windows.Forms.Label();
            this.txtIdentityNumber = new System.Windows.Forms.TextBox();
            this.lblLicenseNumber = new System.Windows.Forms.Label();
            this.txtLicenseNumber = new System.Windows.Forms.TextBox();
            this.lblLicenseCategoryEn = new System.Windows.Forms.Label();
            this.txtLicenseCategoryEn = new System.Windows.Forms.TextBox();
            this.lblLicenseCategoryAr = new System.Windows.Forms.Label();
            this.txtLicenseCategoryAr = new System.Windows.Forms.TextBox();
            this.lblLicensePlaceOfIssueEn = new System.Windows.Forms.Label();
            this.txtLicensePlaceOfIssueEn = new System.Windows.Forms.TextBox();
            this.lblLicensePlaceOfIssueAr = new System.Windows.Forms.Label();
            this.txtLicensePlaceOfIssueAr = new System.Windows.Forms.TextBox();
            this.lblLicenseIssueDate = new System.Windows.Forms.Label();
            this.dtpLicenseIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblLicenseExpiryDate = new System.Windows.Forms.Label();
            this.dtpLicenseExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lblIdentityPlaceOfIssueEn = new System.Windows.Forms.Label();
            this.txtIdentityPlaceOfIssueEn = new System.Windows.Forms.TextBox();
            this.lblIdentityPlaceOfIssueAr = new System.Windows.Forms.Label();
            this.txtIdentityPlaceOfIssueAr = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCustomerIdLabel
            // 
            this.lblCustomerIdLabel.AutoSize = true;
            this.lblCustomerIdLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerIdLabel.Location = new System.Drawing.Point(12, 94);
            this.lblCustomerIdLabel.Name = "lblCustomerIdLabel";
            this.lblCustomerIdLabel.Size = new System.Drawing.Size(97, 18);
            this.lblCustomerIdLabel.TabIndex = 0;
            this.lblCustomerIdLabel.Text = "Customer ID:";
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerId.Location = new System.Drawing.Point(132, 94);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(52, 18);
            this.lblCustomerId.TabIndex = 1;
            this.lblCustomerId.Text = "labelID";
            // 
            // lblCustomerNameLabel
            // 
            this.lblCustomerNameLabel.AutoSize = true;
            this.lblCustomerNameLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameLabel.Location = new System.Drawing.Point(12, 119);
            this.lblCustomerNameLabel.Name = "lblCustomerNameLabel";
            this.lblCustomerNameLabel.Size = new System.Drawing.Size(120, 18);
            this.lblCustomerNameLabel.TabIndex = 2;
            this.lblCustomerNameLabel.Text = "Customer Name:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(132, 119);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(75, 18);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "labelName";
            // 
            // lblIdTypeEn
            // 
            this.lblIdTypeEn.AutoSize = true;
            this.lblIdTypeEn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdTypeEn.Location = new System.Drawing.Point(3, 33);
            this.lblIdTypeEn.Name = "lblIdTypeEn";
            this.lblIdTypeEn.Size = new System.Drawing.Size(84, 14);
            this.lblIdTypeEn.TabIndex = 8;
            this.lblIdTypeEn.Text = "ID Type (EN):";
            // 
            // cmbIdTypeEn
            // 
            this.cmbIdTypeEn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdTypeEn.FormattingEnabled = true;
            this.cmbIdTypeEn.Items.AddRange(new object[] {
            "Personal Id",
            "Passport"});
            this.cmbIdTypeEn.Location = new System.Drawing.Point(167, 31);
            this.cmbIdTypeEn.Name = "cmbIdTypeEn";
            this.cmbIdTypeEn.Size = new System.Drawing.Size(200, 21);
            this.cmbIdTypeEn.TabIndex = 9;
            this.cmbIdTypeEn.Validating += new System.ComponentModel.CancelEventHandler(this.cmbIdTypeEn_Validating);
            // 
            // lblIdTypeAr
            // 
            this.lblIdTypeAr.AutoSize = true;
            this.lblIdTypeAr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdTypeAr.Location = new System.Drawing.Point(3, 63);
            this.lblIdTypeAr.Name = "lblIdTypeAr";
            this.lblIdTypeAr.Size = new System.Drawing.Size(84, 14);
            this.lblIdTypeAr.TabIndex = 10;
            this.lblIdTypeAr.Text = "ID Type (AR):";
            // 
            // cmbIdTypeAr
            // 
            this.cmbIdTypeAr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdTypeAr.FormattingEnabled = true;
            this.cmbIdTypeAr.Items.AddRange(new object[] {
            "بطاقة شخصية",
            "جواز سفر"});
            this.cmbIdTypeAr.Location = new System.Drawing.Point(167, 61);
            this.cmbIdTypeAr.Name = "cmbIdTypeAr";
            this.cmbIdTypeAr.Size = new System.Drawing.Size(200, 21);
            this.cmbIdTypeAr.TabIndex = 11;
            this.cmbIdTypeAr.Validating += new System.ComponentModel.CancelEventHandler(this.cmbIdTypeAr_Validating);
            // 
            // lblIdNumber
            // 
            this.lblIdNumber.AutoSize = true;
            this.lblIdNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdNumber.Location = new System.Drawing.Point(3, 93);
            this.lblIdNumber.Name = "lblIdNumber";
            this.lblIdNumber.Size = new System.Drawing.Size(70, 14);
            this.lblIdNumber.TabIndex = 12;
            this.lblIdNumber.Text = "ID Number:";
            // 
            // txtIdNumber
            // 
            this.txtIdNumber.Location = new System.Drawing.Point(167, 91);
            this.txtIdNumber.Name = "txtIdNumber";
            this.txtIdNumber.Size = new System.Drawing.Size(200, 20);
            this.txtIdNumber.TabIndex = 13;
            this.txtIdNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdNumber_Validating);
            // 
            // lblIdentityNumber
            // 
            this.lblIdentityNumber.AutoSize = true;
            this.lblIdentityNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentityNumber.Location = new System.Drawing.Point(3, 123);
            this.lblIdentityNumber.Name = "lblIdentityNumber";
            this.lblIdentityNumber.Size = new System.Drawing.Size(101, 14);
            this.lblIdentityNumber.TabIndex = 14;
            this.lblIdentityNumber.Text = "Identity Number:";
            // 
            // txtIdentityNumber
            // 
            this.txtIdentityNumber.Location = new System.Drawing.Point(167, 121);
            this.txtIdentityNumber.Name = "txtIdentityNumber";
            this.txtIdentityNumber.Size = new System.Drawing.Size(200, 20);
            this.txtIdentityNumber.TabIndex = 15;
            this.txtIdentityNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdentityNumber_Validating);
            // 
            // lblLicenseNumber
            // 
            this.lblLicenseNumber.AutoSize = true;
            this.lblLicenseNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseNumber.Location = new System.Drawing.Point(10, 27);
            this.lblLicenseNumber.Name = "lblLicenseNumber";
            this.lblLicenseNumber.Size = new System.Drawing.Size(98, 14);
            this.lblLicenseNumber.TabIndex = 16;
            this.lblLicenseNumber.Text = "License Number:";
            // 
            // txtLicenseNumber
            // 
            this.txtLicenseNumber.Location = new System.Drawing.Point(174, 24);
            this.txtLicenseNumber.Name = "txtLicenseNumber";
            this.txtLicenseNumber.Size = new System.Drawing.Size(200, 20);
            this.txtLicenseNumber.TabIndex = 17;
            this.txtLicenseNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicenseNumber_Validating);
            // 
            // lblLicenseCategoryEn
            // 
            this.lblLicenseCategoryEn.AutoSize = true;
            this.lblLicenseCategoryEn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseCategoryEn.Location = new System.Drawing.Point(10, 57);
            this.lblLicenseCategoryEn.Name = "lblLicenseCategoryEn";
            this.lblLicenseCategoryEn.Size = new System.Drawing.Size(133, 14);
            this.lblLicenseCategoryEn.TabIndex = 18;
            this.lblLicenseCategoryEn.Text = "License Category (EN):";
            // 
            // txtLicenseCategoryEn
            // 
            this.txtLicenseCategoryEn.Location = new System.Drawing.Point(174, 54);
            this.txtLicenseCategoryEn.Name = "txtLicenseCategoryEn";
            this.txtLicenseCategoryEn.Size = new System.Drawing.Size(200, 20);
            this.txtLicenseCategoryEn.TabIndex = 19;
            this.txtLicenseCategoryEn.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicenseCategoryEn_Validating);
            // 
            // lblLicenseCategoryAr
            // 
            this.lblLicenseCategoryAr.AutoSize = true;
            this.lblLicenseCategoryAr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseCategoryAr.Location = new System.Drawing.Point(10, 87);
            this.lblLicenseCategoryAr.Name = "lblLicenseCategoryAr";
            this.lblLicenseCategoryAr.Size = new System.Drawing.Size(133, 14);
            this.lblLicenseCategoryAr.TabIndex = 20;
            this.lblLicenseCategoryAr.Text = "License Category (AR):";
            // 
            // txtLicenseCategoryAr
            // 
            this.txtLicenseCategoryAr.Location = new System.Drawing.Point(174, 84);
            this.txtLicenseCategoryAr.Name = "txtLicenseCategoryAr";
            this.txtLicenseCategoryAr.Size = new System.Drawing.Size(200, 20);
            this.txtLicenseCategoryAr.TabIndex = 21;
            this.txtLicenseCategoryAr.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicenseCategoryAr_Validating);
            // 
            // lblLicensePlaceOfIssueEn
            // 
            this.lblLicensePlaceOfIssueEn.AutoSize = true;
            this.lblLicensePlaceOfIssueEn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicensePlaceOfIssueEn.Location = new System.Drawing.Point(10, 117);
            this.lblLicensePlaceOfIssueEn.Name = "lblLicensePlaceOfIssueEn";
            this.lblLicensePlaceOfIssueEn.Size = new System.Drawing.Size(159, 14);
            this.lblLicensePlaceOfIssueEn.TabIndex = 22;
            this.lblLicensePlaceOfIssueEn.Text = "License Place of Issue (EN):";
            // 
            // txtLicensePlaceOfIssueEn
            // 
            this.txtLicensePlaceOfIssueEn.Location = new System.Drawing.Point(174, 114);
            this.txtLicensePlaceOfIssueEn.Name = "txtLicensePlaceOfIssueEn";
            this.txtLicensePlaceOfIssueEn.Size = new System.Drawing.Size(200, 20);
            this.txtLicensePlaceOfIssueEn.TabIndex = 23;
            this.txtLicensePlaceOfIssueEn.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicensePlaceOfIssueEn_Validating);
            // 
            // lblLicensePlaceOfIssueAr
            // 
            this.lblLicensePlaceOfIssueAr.AutoSize = true;
            this.lblLicensePlaceOfIssueAr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicensePlaceOfIssueAr.Location = new System.Drawing.Point(9, 207);
            this.lblLicensePlaceOfIssueAr.Name = "lblLicensePlaceOfIssueAr";
            this.lblLicensePlaceOfIssueAr.Size = new System.Drawing.Size(159, 14);
            this.lblLicensePlaceOfIssueAr.TabIndex = 24;
            this.lblLicensePlaceOfIssueAr.Text = "License Place of Issue (AR):";
            // 
            // txtLicensePlaceOfIssueAr
            // 
            this.txtLicensePlaceOfIssueAr.Location = new System.Drawing.Point(174, 204);
            this.txtLicensePlaceOfIssueAr.Name = "txtLicensePlaceOfIssueAr";
            this.txtLicensePlaceOfIssueAr.Size = new System.Drawing.Size(200, 20);
            this.txtLicensePlaceOfIssueAr.TabIndex = 25;
            this.txtLicensePlaceOfIssueAr.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicensePlaceOfIssueAr_Validating);
            // 
            // lblLicenseIssueDate
            // 
            this.lblLicenseIssueDate.AutoSize = true;
            this.lblLicenseIssueDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseIssueDate.Location = new System.Drawing.Point(10, 144);
            this.lblLicenseIssueDate.Name = "lblLicenseIssueDate";
            this.lblLicenseIssueDate.Size = new System.Drawing.Size(113, 14);
            this.lblLicenseIssueDate.TabIndex = 26;
            this.lblLicenseIssueDate.Text = "License Issue Date:";
            // 
            // dtpLicenseIssueDate
            // 
            this.dtpLicenseIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLicenseIssueDate.Location = new System.Drawing.Point(174, 144);
            this.dtpLicenseIssueDate.Name = "dtpLicenseIssueDate";
            this.dtpLicenseIssueDate.Size = new System.Drawing.Size(200, 20);
            this.dtpLicenseIssueDate.TabIndex = 27;
            this.dtpLicenseIssueDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpLicenseIssueDate_Validating);
            // 
            // lblLicenseExpiryDate
            // 
            this.lblLicenseExpiryDate.AutoSize = true;
            this.lblLicenseExpiryDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseExpiryDate.Location = new System.Drawing.Point(10, 180);
            this.lblLicenseExpiryDate.Name = "lblLicenseExpiryDate";
            this.lblLicenseExpiryDate.Size = new System.Drawing.Size(117, 14);
            this.lblLicenseExpiryDate.TabIndex = 28;
            this.lblLicenseExpiryDate.Text = "License Expiry Date:";
            // 
            // dtpLicenseExpiryDate
            // 
            this.dtpLicenseExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLicenseExpiryDate.Location = new System.Drawing.Point(174, 174);
            this.dtpLicenseExpiryDate.Name = "dtpLicenseExpiryDate";
            this.dtpLicenseExpiryDate.Size = new System.Drawing.Size(200, 20);
            this.dtpLicenseExpiryDate.TabIndex = 29;
            this.dtpLicenseExpiryDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpLicenseExpiryDate_Validating);
            // 
            // lblIdentityPlaceOfIssueEn
            // 
            this.lblIdentityPlaceOfIssueEn.AutoSize = true;
            this.lblIdentityPlaceOfIssueEn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentityPlaceOfIssueEn.Location = new System.Drawing.Point(2, 159);
            this.lblIdentityPlaceOfIssueEn.Name = "lblIdentityPlaceOfIssueEn";
            this.lblIdentityPlaceOfIssueEn.Size = new System.Drawing.Size(162, 14);
            this.lblIdentityPlaceOfIssueEn.TabIndex = 30;
            this.lblIdentityPlaceOfIssueEn.Text = "Identity Place of Issue (EN):";
            // 
            // txtIdentityPlaceOfIssueEn
            // 
            this.txtIdentityPlaceOfIssueEn.Location = new System.Drawing.Point(167, 156);
            this.txtIdentityPlaceOfIssueEn.Name = "txtIdentityPlaceOfIssueEn";
            this.txtIdentityPlaceOfIssueEn.Size = new System.Drawing.Size(200, 20);
            this.txtIdentityPlaceOfIssueEn.TabIndex = 31;
            this.txtIdentityPlaceOfIssueEn.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdentityPlaceOfIssueEn_Validating);
            // 
            // lblIdentityPlaceOfIssueAr
            // 
            this.lblIdentityPlaceOfIssueAr.AutoSize = true;
            this.lblIdentityPlaceOfIssueAr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentityPlaceOfIssueAr.Location = new System.Drawing.Point(2, 189);
            this.lblIdentityPlaceOfIssueAr.Name = "lblIdentityPlaceOfIssueAr";
            this.lblIdentityPlaceOfIssueAr.Size = new System.Drawing.Size(162, 14);
            this.lblIdentityPlaceOfIssueAr.TabIndex = 32;
            this.lblIdentityPlaceOfIssueAr.Text = "Identity Place of Issue (AR):";
            // 
            // txtIdentityPlaceOfIssueAr
            // 
            this.txtIdentityPlaceOfIssueAr.Location = new System.Drawing.Point(167, 186);
            this.txtIdentityPlaceOfIssueAr.Name = "txtIdentityPlaceOfIssueAr";
            this.txtIdentityPlaceOfIssueAr.Size = new System.Drawing.Size(200, 20);
            this.txtIdentityPlaceOfIssueAr.TabIndex = 33;
            this.txtIdentityPlaceOfIssueAr.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdentityPlaceOfIssueAr_Validating);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(15, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(131, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 35;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdNumber);
            this.groupBox1.Controls.Add(this.txtIdentityPlaceOfIssueAr);
            this.groupBox1.Controls.Add(this.lblIdentityPlaceOfIssueAr);
            this.groupBox1.Controls.Add(this.txtIdentityPlaceOfIssueEn);
            this.groupBox1.Controls.Add(this.lblIdentityPlaceOfIssueEn);
            this.groupBox1.Controls.Add(this.txtIdentityNumber);
            this.groupBox1.Controls.Add(this.lblIdTypeEn);
            this.groupBox1.Controls.Add(this.lblIdentityNumber);
            this.groupBox1.Controls.Add(this.cmbIdTypeEn);
            this.groupBox1.Controls.Add(this.lblIdNumber);
            this.groupBox1.Controls.Add(this.lblIdTypeAr);
            this.groupBox1.Controls.Add(this.cmbIdTypeAr);
            this.groupBox1.Location = new System.Drawing.Point(10, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 241);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "identity Information";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLicenseCategoryAr);
            this.groupBox2.Controls.Add(this.txtLicensePlaceOfIssueAr);
            this.groupBox2.Controls.Add(this.lblLicensePlaceOfIssueAr);
            this.groupBox2.Controls.Add(this.txtLicensePlaceOfIssueEn);
            this.groupBox2.Controls.Add(this.lblLicensePlaceOfIssueEn);
            this.groupBox2.Controls.Add(this.lblLicenseCategoryAr);
            this.groupBox2.Controls.Add(this.txtLicenseCategoryEn);
            this.groupBox2.Controls.Add(this.lblLicenseIssueDate);
            this.groupBox2.Controls.Add(this.lblLicenseNumber);
            this.groupBox2.Controls.Add(this.dtpLicenseIssueDate);
            this.groupBox2.Controls.Add(this.lblLicenseExpiryDate);
            this.groupBox2.Controls.Add(this.lblLicenseCategoryEn);
            this.groupBox2.Controls.Add(this.dtpLicenseExpiryDate);
            this.groupBox2.Controls.Add(this.txtLicenseNumber);
            this.groupBox2.Location = new System.Drawing.Point(534, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 241);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "License Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 74);
            this.panel1.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(339, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Documents Information";
            // 
            // frmAddUpdateDocument
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(941, 460);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCustomerIdLabel);
            this.Controls.Add(this.lblCustomerId);
            this.Controls.Add(this.lblCustomerNameLabel);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdateDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Update Document";
            this.Load += new System.EventHandler(this.frmAddUpdateDocument_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
