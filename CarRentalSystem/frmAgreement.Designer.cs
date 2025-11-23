namespace CurtainDemo
{
    partial class frmAgreement
    {
        private System.ComponentModel.IContainer components = null;

        // Main Controls
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnToggleCar;

        // Customer Controls
        private System.Windows.Forms.Panel pnlCustomerDetails;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.TextBox txtIdentityNumber;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtAddress;

        // Car Controls
        private System.Windows.Forms.Panel pnlCarDetails;
        private System.Windows.Forms.ComboBox cmbCars;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.TextBox txtCarName;
        private System.Windows.Forms.TextBox txtCarCategory;
        private System.Windows.Forms.TextBox txtCarYear;
        private System.Windows.Forms.TextBox txtCurrentCounter;
        private System.Windows.Forms.TextBox txtFuelExit;


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
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnToggleCar = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlCarDetails = new System.Windows.Forms.Panel();
            this.cmbCars = new System.Windows.Forms.ComboBox();
            this.txtFuelExit = new System.Windows.Forms.TextBox();
            this.txtCurrentCounter = new System.Windows.Forms.TextBox();
            this.txtCarYear = new System.Windows.Forms.TextBox();
            this.txtCarCategory = new System.Windows.Forms.TextBox();
            this.txtCarName = new System.Windows.Forms.TextBox();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.pnlCustomerDetails = new System.Windows.Forms.Panel();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIdentityNumber = new System.Windows.Forms.TextBox();
            this.pnlDetails.SuspendLayout();
            this.pnlCarDetails.SuspendLayout();
            this.pnlCustomerDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(20, 20);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(150, 30);
            this.btnToggle.TabIndex = 0;
            this.btnToggle.Text = "Show Customer Details";
            this.btnToggle.UseVisualStyleBackColor = true;
            // 
            // btnToggleCar
            // 
            this.btnToggleCar.Location = new System.Drawing.Point(180, 20);
            this.btnToggleCar.Name = "btnToggleCar";
            this.btnToggleCar.Size = new System.Drawing.Size(150, 30);
            this.btnToggleCar.TabIndex = 1;
            this.btnToggleCar.Text = "Show Car Details";
            this.btnToggleCar.UseVisualStyleBackColor = true;
            // 
            // pnlDetails
            // 
            this.pnlDetails.AutoScroll = true;
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.pnlCarDetails);
            this.pnlDetails.Controls.Add(this.pnlCustomerDetails);
            this.pnlDetails.Location = new System.Drawing.Point(20, 60);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(400, 450);
            this.pnlDetails.TabIndex = 2;
            // 
            // pnlCarDetails
            // 
            this.pnlCarDetails.Controls.Add(this.cmbCars);
            this.pnlCarDetails.Controls.Add(this.txtFuelExit);
            this.pnlCarDetails.Controls.Add(this.txtCurrentCounter);
            this.pnlCarDetails.Controls.Add(this.txtCarYear);
            this.pnlCarDetails.Controls.Add(this.txtCarCategory);
            this.pnlCarDetails.Controls.Add(this.txtCarName);
            this.pnlCarDetails.Controls.Add(this.txtPlateNumber);
            this.pnlCarDetails.Location = new System.Drawing.Point(5, 180);
            this.pnlCarDetails.Name = "pnlCarDetails";
            this.pnlCarDetails.Size = new System.Drawing.Size(390, 0);
            this.pnlCarDetails.TabIndex = 1;
            // 
            // cmbCars
            // 
            this.cmbCars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCars.FormattingEnabled = true;
            this.cmbCars.Location = new System.Drawing.Point(5, 5);
            this.cmbCars.Name = "cmbCars";
            this.cmbCars.Size = new System.Drawing.Size(380, 21);
            this.cmbCars.TabIndex = 0;
            // 
            // txtFuelExit
            // 
            this.txtFuelExit.Location = new System.Drawing.Point(5, 155);
            this.txtFuelExit.Name = "txtFuelExit";
            this.txtFuelExit.ReadOnly = true;
            this.txtFuelExit.Size = new System.Drawing.Size(380, 20);
            this.txtFuelExit.TabIndex = 6;
            // 
            // txtCurrentCounter
            // 
            this.txtCurrentCounter.Location = new System.Drawing.Point(5, 130);
            this.txtCurrentCounter.Name = "txtCurrentCounter";
            this.txtCurrentCounter.ReadOnly = true;
            this.txtCurrentCounter.Size = new System.Drawing.Size(380, 20);
            this.txtCurrentCounter.TabIndex = 5;
            // 
            // txtCarYear
            // 
            this.txtCarYear.Location = new System.Drawing.Point(5, 105);
            this.txtCarYear.Name = "txtCarYear";
            this.txtCarYear.ReadOnly = true;
            this.txtCarYear.Size = new System.Drawing.Size(380, 20);
            this.txtCarYear.TabIndex = 4;
            // 
            // txtCarCategory
            // 
            this.txtCarCategory.Location = new System.Drawing.Point(5, 80);
            this.txtCarCategory.Name = "txtCarCategory";
            this.txtCarCategory.ReadOnly = true;
            this.txtCarCategory.Size = new System.Drawing.Size(380, 20);
            this.txtCarCategory.TabIndex = 3;
            // 
            // txtCarName
            // 
            this.txtCarName.Location = new System.Drawing.Point(5, 55);
            this.txtCarName.Name = "txtCarName";
            this.txtCarName.ReadOnly = true;
            this.txtCarName.Size = new System.Drawing.Size(380, 20);
            this.txtCarName.TabIndex = 2;
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.Location = new System.Drawing.Point(5, 30);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.ReadOnly = true;
            this.txtPlateNumber.Size = new System.Drawing.Size(380, 20);
            this.txtPlateNumber.TabIndex = 1;
            // 
            // pnlCustomerDetails
            // 
            this.pnlCustomerDetails.Controls.Add(this.cmbCustomers);
            this.pnlCustomerDetails.Controls.Add(this.txtAddress);
            this.pnlCustomerDetails.Controls.Add(this.txtPhoneNumber);
            this.pnlCustomerDetails.Controls.Add(this.txtName);
            this.pnlCustomerDetails.Controls.Add(this.txtIdentityNumber);
            this.pnlCustomerDetails.Location = new System.Drawing.Point(5, 5);
            this.pnlCustomerDetails.Name = "pnlCustomerDetails";
            this.pnlCustomerDetails.Size = new System.Drawing.Size(390, 0);
            this.pnlCustomerDetails.TabIndex = 0;
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(5, 5);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(380, 21);
            this.cmbCustomers.TabIndex = 0;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(5, 105);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(380, 20);
            this.txtAddress.TabIndex = 4;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(5, 80);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.ReadOnly = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(380, 20);
            this.txtPhoneNumber.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(5, 55);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(380, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtIdentityNumber
            // 
            this.txtIdentityNumber.Location = new System.Drawing.Point(5, 30);
            this.txtIdentityNumber.Name = "txtIdentityNumber";
            this.txtIdentityNumber.ReadOnly = true;
            this.txtIdentityNumber.Size = new System.Drawing.Size(380, 20);
            this.txtIdentityNumber.TabIndex = 1;
            // 
            // frmAgreement
            // 
            this.ClientSize = new System.Drawing.Size(466, 550);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.btnToggleCar);
            this.Controls.Add(this.btnToggle);
            this.Name = "frmAgreement";
            this.Text = "Agreement Demo (Customer and Car)";
            this.pnlDetails.ResumeLayout(false);
            this.pnlCarDetails.ResumeLayout(false);
            this.pnlCarDetails.PerformLayout();
            this.pnlCustomerDetails.ResumeLayout(false);
            this.pnlCustomerDetails.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}