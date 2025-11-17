namespace CarRentalSystem.CarTransfer
{
    partial class frmAddUpdateCarTransfer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.ComboBox cmbCar;

        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;

        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;

        private System.Windows.Forms.Label lblExitBranch;
        private System.Windows.Forms.ComboBox cmbExitBranch;

        private System.Windows.Forms.Label lblExitCounter;
        private System.Windows.Forms.TextBox txtExitCounter;

        private System.Windows.Forms.Label lblFuel;

        private System.Windows.Forms.Label lblExitDate;
        private System.Windows.Forms.DateTimePicker dtExitDate;

        private System.Windows.Forms.Label lblToBranch;
        private System.Windows.Forms.ComboBox cmbToBranch;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCar = new System.Windows.Forms.Label();
            this.cmbCar = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblExitBranch = new System.Windows.Forms.Label();
            this.cmbExitBranch = new System.Windows.Forms.ComboBox();
            this.lblExitCounter = new System.Windows.Forms.Label();
            this.txtExitCounter = new System.Windows.Forms.TextBox();
            this.lblFuel = new System.Windows.Forms.Label();
            this.lblExitDate = new System.Windows.Forms.Label();
            this.dtExitDate = new System.Windows.Forms.DateTimePicker();
            this.lblToBranch = new System.Windows.Forms.Label();
            this.cmbToBranch = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFuelExit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(550, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Car Transfer";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCar
            // 
            this.lblCar.Location = new System.Drawing.Point(20, 60);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(100, 23);
            this.lblCar.TabIndex = 1;
            this.lblCar.Text = "Car:";
            // 
            // cmbCar
            // 
            this.cmbCar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCar.Location = new System.Drawing.Point(150, 60);
            this.cmbCar.Name = "cmbCar";
            this.cmbCar.Size = new System.Drawing.Size(250, 21);
            this.cmbCar.TabIndex = 2;
            // 
            // lblEmployee
            // 
            this.lblEmployee.Location = new System.Drawing.Point(20, 100);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(100, 23);
            this.lblEmployee.TabIndex = 3;
            this.lblEmployee.Text = "Employee:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmployee.Location = new System.Drawing.Point(150, 100);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(250, 21);
            this.cmbEmployee.TabIndex = 4;
            // 
            // lblReason
            // 
            this.lblReason.Location = new System.Drawing.Point(20, 140);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(100, 23);
            this.lblReason.TabIndex = 5;
            this.lblReason.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(150, 140);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(250, 74);
            this.txtReason.TabIndex = 6;
            // 
            // lblExitBranch
            // 
            this.lblExitBranch.Location = new System.Drawing.Point(20, 225);
            this.lblExitBranch.Name = "lblExitBranch";
            this.lblExitBranch.Size = new System.Drawing.Size(100, 23);
            this.lblExitBranch.TabIndex = 7;
            this.lblExitBranch.Text = "Exit Branch:";
            // 
            // cmbExitBranch
            // 
            this.cmbExitBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbExitBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbExitBranch.Location = new System.Drawing.Point(150, 225);
            this.cmbExitBranch.Name = "cmbExitBranch";
            this.cmbExitBranch.Size = new System.Drawing.Size(250, 21);
            this.cmbExitBranch.TabIndex = 8;
            // 
            // lblExitCounter
            // 
            this.lblExitCounter.Location = new System.Drawing.Point(20, 260);
            this.lblExitCounter.Name = "lblExitCounter";
            this.lblExitCounter.Size = new System.Drawing.Size(100, 23);
            this.lblExitCounter.TabIndex = 9;
            this.lblExitCounter.Text = "Exit Counter:";
            // 
            // txtExitCounter
            // 
            this.txtExitCounter.Location = new System.Drawing.Point(150, 260);
            this.txtExitCounter.Name = "txtExitCounter";
            this.txtExitCounter.Size = new System.Drawing.Size(150, 20);
            this.txtExitCounter.TabIndex = 10;
            // 
            // lblFuel
            // 
            this.lblFuel.Location = new System.Drawing.Point(20, 300);
            this.lblFuel.Name = "lblFuel";
            this.lblFuel.Size = new System.Drawing.Size(100, 23);
            this.lblFuel.TabIndex = 11;
            this.lblFuel.Text = "Fuel:";
            // 
            // lblExitDate
            // 
            this.lblExitDate.Location = new System.Drawing.Point(20, 340);
            this.lblExitDate.Name = "lblExitDate";
            this.lblExitDate.Size = new System.Drawing.Size(100, 23);
            this.lblExitDate.TabIndex = 13;
            this.lblExitDate.Text = "Exit Date:";
            // 
            // dtExitDate
            // 
            this.dtExitDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExitDate.Location = new System.Drawing.Point(150, 340);
            this.dtExitDate.Name = "dtExitDate";
            this.dtExitDate.Size = new System.Drawing.Size(200, 20);
            this.dtExitDate.TabIndex = 14;
            // 
            // lblToBranch
            // 
            this.lblToBranch.Location = new System.Drawing.Point(20, 380);
            this.lblToBranch.Name = "lblToBranch";
            this.lblToBranch.Size = new System.Drawing.Size(100, 23);
            this.lblToBranch.TabIndex = 15;
            this.lblToBranch.Text = "Transfer To:";
            // 
            // cmbToBranch
            // 
            this.cmbToBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbToBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbToBranch.Location = new System.Drawing.Point(150, 380);
            this.cmbToBranch.Name = "cmbToBranch";
            this.cmbToBranch.Size = new System.Drawing.Size(250, 21);
            this.cmbToBranch.TabIndex = 16;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(20, 420);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(150, 420);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 18;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 470);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 470);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFuelExit
            // 
            this.txtFuelExit.Location = new System.Drawing.Point(150, 297);
            this.txtFuelExit.Name = "txtFuelExit";
            this.txtFuelExit.Size = new System.Drawing.Size(150, 20);
            this.txtFuelExit.TabIndex = 21;
            // 
            // frmAddUpdateCarTransfer
            // 
            this.ClientSize = new System.Drawing.Size(550, 520);
            this.Controls.Add(this.txtFuelExit);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCar);
            this.Controls.Add(this.cmbCar);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblExitBranch);
            this.Controls.Add(this.cmbExitBranch);
            this.Controls.Add(this.lblExitCounter);
            this.Controls.Add(this.txtExitCounter);
            this.Controls.Add(this.lblFuel);
            this.Controls.Add(this.lblExitDate);
            this.Controls.Add(this.dtExitDate);
            this.Controls.Add(this.lblToBranch);
            this.Controls.Add(this.cmbToBranch);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmAddUpdateCarTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox txtFuelExit;
    }
}