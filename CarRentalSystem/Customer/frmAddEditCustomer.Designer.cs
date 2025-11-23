namespace CarRentalSystem.Customer
{
    partial class frmAddEditCustomer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.lblCustomerNameEn = new System.Windows.Forms.Label();
            this.txtCustomerNameEn = new System.Windows.Forms.TextBox();
            this.lblCustomerNameAr = new System.Windows.Forms.Label();
            this.txtCustomerNameAr = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAddressEn = new System.Windows.Forms.Label();
            this.txtAddressEn = new System.Windows.Forms.TextBox();
            this.lblAddressAr = new System.Windows.Forms.Label();
            this.txtAddressAr = new System.Windows.Forms.TextBox();
            this.lblNotesEn = new System.Windows.Forms.Label();
            this.txtNotesEn = new System.Windows.Forms.TextBox();
            this.lblNotesAr = new System.Windows.Forms.Label();
            this.txtNotesAr = new System.Windows.Forms.TextBox();
            this.chkBlacklist = new System.Windows.Forms.CheckBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblNationality = new System.Windows.Forms.Label();
            this.cmbNationality = new System.Windows.Forms.ComboBox();
            this.lblMediator = new System.Windows.Forms.Label();
            this.cmbMediator = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.LicenseCategroyAr = new System.Windows.Forms.TextBox();
            this.txtLicensePlaceOfIssueAr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPlaceOfIssueEn = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.LicenseCategroyEn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dplicenseIssueDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.lable = new System.Windows.Forms.Label();
            this.dpLicenseExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.txtLicenseNubmer = new System.Windows.Forms.TextBox();
            this.txtIdNubmer = new System.Windows.Forms.TextBox();
            this.txtIdentityPlaceOfIssueAr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdentityPlaceOfIssueEn = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtIdentityNubmer = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbIdTypeEn = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbIdTypeAr = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCustomerType);
            this.groupBox1.Controls.Add(this.cmbCustomerType);
            this.groupBox1.Controls.Add(this.lblCustomerNameEn);
            this.groupBox1.Controls.Add(this.txtCustomerNameEn);
            this.groupBox1.Controls.Add(this.lblCustomerNameAr);
            this.groupBox1.Controls.Add(this.txtCustomerNameAr);
            this.groupBox1.Controls.Add(this.lblPhoneNumber);
            this.groupBox1.Controls.Add(this.txtPhoneNumber);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.lblAddressEn);
            this.groupBox1.Controls.Add(this.txtAddressEn);
            this.groupBox1.Controls.Add(this.lblAddressAr);
            this.groupBox1.Controls.Add(this.txtAddressAr);
            this.groupBox1.Controls.Add(this.lblNotesEn);
            this.groupBox1.Controls.Add(this.txtNotesEn);
            this.groupBox1.Controls.Add(this.lblNotesAr);
            this.groupBox1.Controls.Add(this.txtNotesAr);
            this.groupBox1.Controls.Add(this.chkBlacklist);
            this.groupBox1.Controls.Add(this.lblCompany);
            this.groupBox1.Controls.Add(this.cmbCompany);
            this.groupBox1.Controls.Add(this.lblNationality);
            this.groupBox1.Controls.Add(this.cmbNationality);
            this.groupBox1.Controls.Add(this.lblMediator);
            this.groupBox1.Controls.Add(this.cmbMediator);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 452);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Info";
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblCustomerType.Location = new System.Drawing.Point(10, 28);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(98, 17);
            this.lblCustomerType.TabIndex = 27;
            this.lblCustomerType.Text = "Customer Type:";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCustomerType.Items.AddRange(new object[] {
            "Individual",
            "Company"});
            this.cmbCustomerType.Location = new System.Drawing.Point(149, 25);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(200, 23);
            this.cmbCustomerType.TabIndex = 28;
            this.cmbCustomerType.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerType_SelectedIndexChanged);
            this.cmbCustomerType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCustomerType_Validating);
            // 
            // lblCustomerNameEn
            // 
            this.lblCustomerNameEn.AutoSize = true;
            this.lblCustomerNameEn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblCustomerNameEn.Location = new System.Drawing.Point(10, 63);
            this.lblCustomerNameEn.Name = "lblCustomerNameEn";
            this.lblCustomerNameEn.Size = new System.Drawing.Size(135, 17);
            this.lblCustomerNameEn.TabIndex = 29;
            this.lblCustomerNameEn.Text = "Customer Name (EN):";
            // 
            // txtCustomerNameEn
            // 
            this.txtCustomerNameEn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerNameEn.Location = new System.Drawing.Point(149, 60);
            this.txtCustomerNameEn.Name = "txtCustomerNameEn";
            this.txtCustomerNameEn.Size = new System.Drawing.Size(200, 23);
            this.txtCustomerNameEn.TabIndex = 30;
            this.txtCustomerNameEn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerNameEn_KeyPress);
            this.txtCustomerNameEn.Validating += new System.ComponentModel.CancelEventHandler(this.txtCustomerNameEn_Validating);
            // 
            // lblCustomerNameAr
            // 
            this.lblCustomerNameAr.AutoSize = true;
            this.lblCustomerNameAr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameAr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblCustomerNameAr.Location = new System.Drawing.Point(10, 98);
            this.lblCustomerNameAr.Name = "lblCustomerNameAr";
            this.lblCustomerNameAr.Size = new System.Drawing.Size(134, 17);
            this.lblCustomerNameAr.TabIndex = 31;
            this.lblCustomerNameAr.Text = "Customer Name (AR):";
            // 
            // txtCustomerNameAr
            // 
            this.txtCustomerNameAr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerNameAr.Location = new System.Drawing.Point(149, 95);
            this.txtCustomerNameAr.Name = "txtCustomerNameAr";
            this.txtCustomerNameAr.Size = new System.Drawing.Size(200, 23);
            this.txtCustomerNameAr.TabIndex = 32;
            this.txtCustomerNameAr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerNameAr_KeyPress);
            this.txtCustomerNameAr.Validating += new System.ComponentModel.CancelEventHandler(this.txtCustomerNameAr_Validating);
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblPhoneNumber.Location = new System.Drawing.Point(10, 133);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(99, 17);
            this.lblPhoneNumber.TabIndex = 33;
            this.lblPhoneNumber.Text = "Phone Number:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhoneNumber.Location = new System.Drawing.Point(149, 130);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(200, 23);
            this.txtPhoneNumber.TabIndex = 34;
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblEmail.Location = new System.Drawing.Point(10, 168);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 35;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(149, 165);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.TabIndex = 36;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // lblAddressEn
            // 
            this.lblAddressEn.AutoSize = true;
            this.lblAddressEn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblAddressEn.Location = new System.Drawing.Point(10, 203);
            this.lblAddressEn.Name = "lblAddressEn";
            this.lblAddressEn.Size = new System.Drawing.Size(88, 17);
            this.lblAddressEn.TabIndex = 37;
            this.lblAddressEn.Text = "Address (EN):";
            // 
            // txtAddressEn
            // 
            this.txtAddressEn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddressEn.Location = new System.Drawing.Point(149, 200);
            this.txtAddressEn.Name = "txtAddressEn";
            this.txtAddressEn.Size = new System.Drawing.Size(200, 23);
            this.txtAddressEn.TabIndex = 38;
            // 
            // lblAddressAr
            // 
            this.lblAddressAr.AutoSize = true;
            this.lblAddressAr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressAr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblAddressAr.Location = new System.Drawing.Point(10, 238);
            this.lblAddressAr.Name = "lblAddressAr";
            this.lblAddressAr.Size = new System.Drawing.Size(87, 17);
            this.lblAddressAr.TabIndex = 39;
            this.lblAddressAr.Text = "Address (AR):";
            // 
            // txtAddressAr
            // 
            this.txtAddressAr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddressAr.Location = new System.Drawing.Point(149, 235);
            this.txtAddressAr.Name = "txtAddressAr";
            this.txtAddressAr.Size = new System.Drawing.Size(200, 23);
            this.txtAddressAr.TabIndex = 40;
            // 
            // lblNotesEn
            // 
            this.lblNotesEn.AutoSize = true;
            this.lblNotesEn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotesEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblNotesEn.Location = new System.Drawing.Point(10, 273);
            this.lblNotesEn.Name = "lblNotesEn";
            this.lblNotesEn.Size = new System.Drawing.Size(75, 17);
            this.lblNotesEn.TabIndex = 41;
            this.lblNotesEn.Text = "Notes (EN):";
            // 
            // txtNotesEn
            // 
            this.txtNotesEn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotesEn.Location = new System.Drawing.Point(149, 270);
            this.txtNotesEn.Multiline = true;
            this.txtNotesEn.Name = "txtNotesEn";
            this.txtNotesEn.Size = new System.Drawing.Size(200, 60);
            this.txtNotesEn.TabIndex = 42;
            // 
            // lblNotesAr
            // 
            this.lblNotesAr.AutoSize = true;
            this.lblNotesAr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotesAr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblNotesAr.Location = new System.Drawing.Point(10, 343);
            this.lblNotesAr.Name = "lblNotesAr";
            this.lblNotesAr.Size = new System.Drawing.Size(74, 17);
            this.lblNotesAr.TabIndex = 43;
            this.lblNotesAr.Text = "Notes (AR):";
            // 
            // txtNotesAr
            // 
            this.txtNotesAr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotesAr.Location = new System.Drawing.Point(149, 340);
            this.txtNotesAr.Multiline = true;
            this.txtNotesAr.Name = "txtNotesAr";
            this.txtNotesAr.Size = new System.Drawing.Size(200, 60);
            this.txtNotesAr.TabIndex = 44;
            // 
            // chkBlacklist
            // 
            this.chkBlacklist.AutoSize = true;
            this.chkBlacklist.Location = new System.Drawing.Point(149, 410);
            this.chkBlacklist.Name = "chkBlacklist";
            this.chkBlacklist.Size = new System.Drawing.Size(69, 19);
            this.chkBlacklist.TabIndex = 45;
            this.chkBlacklist.Text = "Blacklist";
            this.chkBlacklist.UseVisualStyleBackColor = true;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblCompany.Location = new System.Drawing.Point(374, 28);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(66, 17);
            this.lblCompany.TabIndex = 46;
            this.lblCompany.Text = "Company:";
            // 
            // cmbCompany
            // 
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCompany.Location = new System.Drawing.Point(454, 25);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(200, 23);
            this.cmbCompany.Sorted = true;
            this.cmbCompany.TabIndex = 47;
            this.cmbCompany.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCompany_Validating);
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblNationality.Location = new System.Drawing.Point(374, 68);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(73, 17);
            this.lblNationality.TabIndex = 48;
            this.lblNationality.Text = "Nationality:";
            // 
            // cmbNationality
            // 
            this.cmbNationality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbNationality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNationality.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbNationality.Location = new System.Drawing.Point(454, 65);
            this.cmbNationality.Name = "cmbNationality";
            this.cmbNationality.Size = new System.Drawing.Size(200, 23);
            this.cmbNationality.Sorted = true;
            this.cmbNationality.TabIndex = 49;
            this.cmbNationality.Validating += new System.ComponentModel.CancelEventHandler(this.cmbNationality_Validating);
            // 
            // lblMediator
            // 
            this.lblMediator.AutoSize = true;
            this.lblMediator.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblMediator.Location = new System.Drawing.Point(374, 108);
            this.lblMediator.Name = "lblMediator";
            this.lblMediator.Size = new System.Drawing.Size(65, 17);
            this.lblMediator.TabIndex = 50;
            this.lblMediator.Text = "Mediator:";
            // 
            // cmbMediator
            // 
            this.cmbMediator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMediator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMediator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMediator.Location = new System.Drawing.Point(454, 105);
            this.cmbMediator.Name = "cmbMediator";
            this.cmbMediator.Size = new System.Drawing.Size(200, 23);
            this.cmbMediator.Sorted = true;
            this.cmbMediator.TabIndex = 51;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(454, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 42);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_2);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(564, 393);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 42);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1323, 74);
            this.panel1.TabIndex = 28;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(228, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(242, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Customer";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LicenseCategroyAr
            // 
            this.LicenseCategroyAr.Location = new System.Drawing.Point(894, 410);
            this.LicenseCategroyAr.Name = "LicenseCategroyAr";
            this.LicenseCategroyAr.Size = new System.Drawing.Size(200, 20);
            this.LicenseCategroyAr.TabIndex = 63;
            // 
            // txtLicensePlaceOfIssueAr
            // 
            this.txtLicensePlaceOfIssueAr.Location = new System.Drawing.Point(894, 530);
            this.txtLicensePlaceOfIssueAr.Name = "txtLicensePlaceOfIssueAr";
            this.txtLicensePlaceOfIssueAr.Size = new System.Drawing.Size(200, 20);
            this.txtLicensePlaceOfIssueAr.TabIndex = 67;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(729, 533);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 14);
            this.label9.TabIndex = 66;
            this.label9.Text = "License Place of Issue (AR):";
            // 
            // txtPlaceOfIssueEn
            // 
            this.txtPlaceOfIssueEn.Location = new System.Drawing.Point(894, 440);
            this.txtPlaceOfIssueEn.Name = "txtPlaceOfIssueEn";
            this.txtPlaceOfIssueEn.Size = new System.Drawing.Size(200, 20);
            this.txtPlaceOfIssueEn.TabIndex = 65;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(730, 443);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 14);
            this.label10.TabIndex = 64;
            this.label10.Text = "License Place of Issue (EN):";
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10.Location = new System.Drawing.Point(730, 413);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(133, 14);
            this.lbl10.TabIndex = 62;
            this.lbl10.Text = "License Category (AR):";
            // 
            // LicenseCategroyEn
            // 
            this.LicenseCategroyEn.Location = new System.Drawing.Point(894, 380);
            this.LicenseCategroyEn.Name = "LicenseCategroyEn";
            this.LicenseCategroyEn.Size = new System.Drawing.Size(200, 20);
            this.LicenseCategroyEn.TabIndex = 61;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(730, 470);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 14);
            this.label12.TabIndex = 68;
            this.label12.Text = "License Issue Date:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(730, 353);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 14);
            this.label13.TabIndex = 58;
            this.label13.Text = "License Number:";
            // 
            // dplicenseIssueDate
            // 
            this.dplicenseIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dplicenseIssueDate.Location = new System.Drawing.Point(894, 470);
            this.dplicenseIssueDate.Name = "dplicenseIssueDate";
            this.dplicenseIssueDate.Size = new System.Drawing.Size(200, 20);
            this.dplicenseIssueDate.TabIndex = 69;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(730, 506);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 14);
            this.label14.TabIndex = 70;
            this.label14.Text = "License Expiry Date:";
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable.Location = new System.Drawing.Point(730, 383);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(133, 14);
            this.lable.TabIndex = 60;
            this.lable.Text = "License Category (EN):";
            // 
            // dpLicenseExpiryDate
            // 
            this.dpLicenseExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpLicenseExpiryDate.Location = new System.Drawing.Point(894, 500);
            this.dpLicenseExpiryDate.Name = "dpLicenseExpiryDate";
            this.dpLicenseExpiryDate.Size = new System.Drawing.Size(200, 20);
            this.dpLicenseExpiryDate.TabIndex = 71;
            // 
            // txtLicenseNubmer
            // 
            this.txtLicenseNubmer.Location = new System.Drawing.Point(894, 350);
            this.txtLicenseNubmer.Name = "txtLicenseNubmer";
            this.txtLicenseNubmer.Size = new System.Drawing.Size(200, 20);
            this.txtLicenseNubmer.TabIndex = 59;
            // 
            // txtIdNubmer
            // 
            this.txtIdNubmer.Location = new System.Drawing.Point(914, 166);
            this.txtIdNubmer.Name = "txtIdNubmer";
            this.txtIdNubmer.Size = new System.Drawing.Size(200, 20);
            this.txtIdNubmer.TabIndex = 77;
            // 
            // txtIdentityPlaceOfIssueAr
            // 
            this.txtIdentityPlaceOfIssueAr.Location = new System.Drawing.Point(914, 261);
            this.txtIdentityPlaceOfIssueAr.Name = "txtIdentityPlaceOfIssueAr";
            this.txtIdentityPlaceOfIssueAr.Size = new System.Drawing.Size(200, 20);
            this.txtIdentityPlaceOfIssueAr.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(749, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 14);
            this.label1.TabIndex = 82;
            this.label1.Text = "Identity Place of Issue (AR):";
            // 
            // txtIdentityPlaceOfIssueEn
            // 
            this.txtIdentityPlaceOfIssueEn.Location = new System.Drawing.Point(914, 231);
            this.txtIdentityPlaceOfIssueEn.Name = "txtIdentityPlaceOfIssueEn";
            this.txtIdentityPlaceOfIssueEn.Size = new System.Drawing.Size(200, 20);
            this.txtIdentityPlaceOfIssueEn.TabIndex = 81;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(749, 234);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(162, 14);
            this.label16.TabIndex = 80;
            this.label16.Text = "Identity Place of Issue (EN):";
            // 
            // txtIdentityNubmer
            // 
            this.txtIdentityNubmer.Location = new System.Drawing.Point(914, 196);
            this.txtIdentityNubmer.Name = "txtIdentityNubmer";
            this.txtIdentityNubmer.Size = new System.Drawing.Size(200, 20);
            this.txtIdentityNubmer.TabIndex = 79;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(750, 108);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 14);
            this.label17.TabIndex = 72;
            this.label17.Text = "ID Type (EN):";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(750, 198);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 14);
            this.label18.TabIndex = 78;
            this.label18.Text = "Identity Number:";
            // 
            // cmbIdTypeEn
            // 
            this.cmbIdTypeEn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdTypeEn.FormattingEnabled = true;
            this.cmbIdTypeEn.Items.AddRange(new object[] {
            "Personal Id",
            "Passport"});
            this.cmbIdTypeEn.Location = new System.Drawing.Point(914, 106);
            this.cmbIdTypeEn.Name = "cmbIdTypeEn";
            this.cmbIdTypeEn.Size = new System.Drawing.Size(200, 21);
            this.cmbIdTypeEn.TabIndex = 73;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(750, 168);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 14);
            this.label19.TabIndex = 76;
            this.label19.Text = "ID Number:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(750, 138);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 14);
            this.label20.TabIndex = 74;
            this.label20.Text = "ID Type (AR):";
            // 
            // cmbIdTypeAr
            // 
            this.cmbIdTypeAr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdTypeAr.FormattingEnabled = true;
            this.cmbIdTypeAr.Items.AddRange(new object[] {
            "بطاقة شخصية",
            "جواز سفر"});
            this.cmbIdTypeAr.Location = new System.Drawing.Point(914, 136);
            this.cmbIdTypeAr.Name = "cmbIdTypeAr";
            this.cmbIdTypeAr.Size = new System.Drawing.Size(200, 21);
            this.cmbIdTypeAr.TabIndex = 75;
            // 
            // frmAddEditCustomer
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1323, 612);
            this.Controls.Add(this.txtIdNubmer);
            this.Controls.Add(this.txtIdentityPlaceOfIssueAr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdentityPlaceOfIssueEn);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtIdentityNubmer);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cmbIdTypeEn);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cmbIdTypeAr);
            this.Controls.Add(this.LicenseCategroyAr);
            this.Controls.Add(this.txtLicensePlaceOfIssueAr);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPlaceOfIssueEn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbl10);
            this.Controls.Add(this.LicenseCategroyEn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dplicenseIssueDate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lable);
            this.Controls.Add(this.dpLicenseExpiryDate);
            this.Controls.Add(this.txtLicenseNubmer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmAddEditCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Customer";
            this.Load += new System.EventHandler(this.frmAddEditCustomer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label lblCustomerNameEn;
        private System.Windows.Forms.TextBox txtCustomerNameEn;
        private System.Windows.Forms.Label lblCustomerNameAr;
        private System.Windows.Forms.TextBox txtCustomerNameAr;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddressEn;
        private System.Windows.Forms.TextBox txtAddressEn;
        private System.Windows.Forms.Label lblAddressAr;
        private System.Windows.Forms.TextBox txtAddressAr;
        private System.Windows.Forms.Label lblNotesEn;
        private System.Windows.Forms.TextBox txtNotesEn;
        private System.Windows.Forms.Label lblNotesAr;
        private System.Windows.Forms.TextBox txtNotesAr;
        private System.Windows.Forms.CheckBox chkBlacklist;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.ComboBox cmbNationality;
        private System.Windows.Forms.Label lblMediator;
        private System.Windows.Forms.ComboBox cmbMediator;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox LicenseCategroyAr;
        private System.Windows.Forms.TextBox txtLicensePlaceOfIssueAr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPlaceOfIssueEn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.TextBox LicenseCategroyEn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dplicenseIssueDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.DateTimePicker dpLicenseExpiryDate;
        private System.Windows.Forms.TextBox txtLicenseNubmer;
        private System.Windows.Forms.TextBox txtIdNubmer;
        private System.Windows.Forms.TextBox txtIdentityPlaceOfIssueAr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdentityPlaceOfIssueEn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtIdentityNubmer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbIdTypeEn;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbIdTypeAr;
    }
}
