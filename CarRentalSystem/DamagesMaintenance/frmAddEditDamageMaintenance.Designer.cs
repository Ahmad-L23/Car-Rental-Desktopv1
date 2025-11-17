namespace CarRentalSystem.DamageMaintenance
{
    partial class frmAddEditDamageMaintenance
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbCar;
        private System.Windows.Forms.DateTimePicker dtpDamageDate;
        private System.Windows.Forms.NumericUpDown numTotalAmount;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.NumericUpDown numGasolineIn;
        private System.Windows.Forms.NumericUpDown numGasolineOut;
        private System.Windows.Forms.TextBox txtGarageName;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.DateTimePicker dtpRepairStartDate;
        private System.Windows.Forms.DateTimePicker dtpCompletionDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.Label lblDamageDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblGasolineIn;
        private System.Windows.Forms.Label lblGasolineOut;
        private System.Windows.Forms.Label lblGarageName;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblRepairStartDate;
        private System.Windows.Forms.Label lblCompletionDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbCar = new System.Windows.Forms.ComboBox();
            this.dtpDamageDate = new System.Windows.Forms.DateTimePicker();
            this.numTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.numGasolineIn = new System.Windows.Forms.NumericUpDown();
            this.numGasolineOut = new System.Windows.Forms.NumericUpDown();
            this.txtGarageName = new System.Windows.Forms.TextBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.dtpRepairStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCompletionDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCar = new System.Windows.Forms.Label();
            this.lblDamageDate = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblGasolineIn = new System.Windows.Forms.Label();
            this.lblGasolineOut = new System.Windows.Forms.Label();
            this.lblGarageName = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblRepairStartDate = new System.Windows.Forms.Label();
            this.lblCompletionDate = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGasolineIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGasolineOut)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCar
            // 
            this.cmbCar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCar.FormattingEnabled = true;
            this.cmbCar.Location = new System.Drawing.Point(130, 91);
            this.cmbCar.Name = "cmbCar";
            this.cmbCar.Size = new System.Drawing.Size(200, 21);
            this.cmbCar.TabIndex = 0;
            // 
            // dtpDamageDate
            // 
            this.dtpDamageDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDamageDate.Location = new System.Drawing.Point(130, 131);
            this.dtpDamageDate.Name = "dtpDamageDate";
            this.dtpDamageDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDamageDate.TabIndex = 1;
            // 
            // numTotalAmount
            // 
            this.numTotalAmount.DecimalPlaces = 2;
            this.numTotalAmount.Location = new System.Drawing.Point(130, 171);
            this.numTotalAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTotalAmount.Name = "numTotalAmount";
            this.numTotalAmount.Size = new System.Drawing.Size(200, 20);
            this.numTotalAmount.TabIndex = 2;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "InProgress",
            "Completed"});
            this.cmbStatus.Location = new System.Drawing.Point(130, 211);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 21);
            this.cmbStatus.TabIndex = 3;
            // 
            // numGasolineIn
            // 
            this.numGasolineIn.DecimalPlaces = 2;
            this.numGasolineIn.Location = new System.Drawing.Point(130, 251);
            this.numGasolineIn.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numGasolineIn.Name = "numGasolineIn";
            this.numGasolineIn.Size = new System.Drawing.Size(200, 20);
            this.numGasolineIn.TabIndex = 4;
            // 
            // numGasolineOut
            // 
            this.numGasolineOut.DecimalPlaces = 2;
            this.numGasolineOut.Location = new System.Drawing.Point(130, 291);
            this.numGasolineOut.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numGasolineOut.Name = "numGasolineOut";
            this.numGasolineOut.Size = new System.Drawing.Size(200, 20);
            this.numGasolineOut.TabIndex = 5;
            // 
            // txtGarageName
            // 
            this.txtGarageName.Location = new System.Drawing.Point(130, 331);
            this.txtGarageName.Name = "txtGarageName";
            this.txtGarageName.Size = new System.Drawing.Size(200, 20);
            this.txtGarageName.TabIndex = 6;
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(461, 91);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(200, 21);
            this.cmbEmployee.TabIndex = 7;
            // 
            // dtpRepairStartDate
            // 
            this.dtpRepairStartDate.Checked = false;
            this.dtpRepairStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRepairStartDate.Location = new System.Drawing.Point(461, 131);
            this.dtpRepairStartDate.Name = "dtpRepairStartDate";
            this.dtpRepairStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpRepairStartDate.TabIndex = 8;
            // 
            // dtpCompletionDate
            // 
            this.dtpCompletionDate.Checked = false;
            this.dtpCompletionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCompletionDate.Location = new System.Drawing.Point(461, 171);
            this.dtpCompletionDate.Name = "dtpCompletionDate";
            this.dtpCompletionDate.Size = new System.Drawing.Size(200, 20);
            this.dtpCompletionDate.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(197, 387);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(307, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 40);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCar
            // 
            this.lblCar.AutoSize = true;
            this.lblCar.Location = new System.Drawing.Point(20, 94);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(26, 13);
            this.lblCar.TabIndex = 12;
            this.lblCar.Text = "Car:";
            // 
            // lblDamageDate
            // 
            this.lblDamageDate.AutoSize = true;
            this.lblDamageDate.Location = new System.Drawing.Point(20, 137);
            this.lblDamageDate.Name = "lblDamageDate";
            this.lblDamageDate.Size = new System.Drawing.Size(76, 13);
            this.lblDamageDate.TabIndex = 13;
            this.lblDamageDate.Text = "Damage Date:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 173);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(73, 13);
            this.lblTotalAmount.TabIndex = 14;
            this.lblTotalAmount.Text = "Total Amount:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 214);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Status:";
            // 
            // lblGasolineIn
            // 
            this.lblGasolineIn.AutoSize = true;
            this.lblGasolineIn.Location = new System.Drawing.Point(20, 253);
            this.lblGasolineIn.Name = "lblGasolineIn";
            this.lblGasolineIn.Size = new System.Drawing.Size(63, 13);
            this.lblGasolineIn.TabIndex = 16;
            this.lblGasolineIn.Text = "Gasoline In:";
            // 
            // lblGasolineOut
            // 
            this.lblGasolineOut.AutoSize = true;
            this.lblGasolineOut.Location = new System.Drawing.Point(20, 293);
            this.lblGasolineOut.Name = "lblGasolineOut";
            this.lblGasolineOut.Size = new System.Drawing.Size(71, 13);
            this.lblGasolineOut.TabIndex = 17;
            this.lblGasolineOut.Text = "Gasoline Out:";
            // 
            // lblGarageName
            // 
            this.lblGarageName.AutoSize = true;
            this.lblGarageName.Location = new System.Drawing.Point(20, 334);
            this.lblGarageName.Name = "lblGarageName";
            this.lblGarageName.Size = new System.Drawing.Size(76, 13);
            this.lblGarageName.TabIndex = 18;
            this.lblGarageName.Text = "Garage Name:";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(351, 94);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(56, 13);
            this.lblEmployee.TabIndex = 19;
            this.lblEmployee.Text = "Employee:";
            // 
            // lblRepairStartDate
            // 
            this.lblRepairStartDate.AutoSize = true;
            this.lblRepairStartDate.Location = new System.Drawing.Point(351, 134);
            this.lblRepairStartDate.Name = "lblRepairStartDate";
            this.lblRepairStartDate.Size = new System.Drawing.Size(92, 13);
            this.lblRepairStartDate.TabIndex = 20;
            this.lblRepairStartDate.Text = "Repair Start Date:";
            // 
            // lblCompletionDate
            // 
            this.lblCompletionDate.AutoSize = true;
            this.lblCompletionDate.Location = new System.Drawing.Point(351, 174);
            this.lblCompletionDate.Name = "lblCompletionDate";
            this.lblCompletionDate.Size = new System.Drawing.Size(88, 13);
            this.lblCompletionDate.TabIndex = 21;
            this.lblCompletionDate.Text = "Completion Date:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(461, 207);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 77);
            this.txtDescription.TabIndex = 22;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Desription:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 66);
            this.panel1.TabIndex = 25;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(196, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(279, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Damage Maintenance";
            // 
            // frmAddEditDamageMaintenance
            // 
            this.ClientSize = new System.Drawing.Size(670, 445);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblCar);
            this.Controls.Add(this.cmbCar);
            this.Controls.Add(this.lblDamageDate);
            this.Controls.Add(this.dtpDamageDate);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.numTotalAmount);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblGasolineIn);
            this.Controls.Add(this.numGasolineIn);
            this.Controls.Add(this.lblGasolineOut);
            this.Controls.Add(this.numGasolineOut);
            this.Controls.Add(this.lblGarageName);
            this.Controls.Add(this.txtGarageName);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblRepairStartDate);
            this.Controls.Add(this.dtpRepairStartDate);
            this.Controls.Add(this.lblCompletionDate);
            this.Controls.Add(this.dtpCompletionDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddEditDamageMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Damage Maintenance";
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGasolineIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGasolineOut)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
    }
}
