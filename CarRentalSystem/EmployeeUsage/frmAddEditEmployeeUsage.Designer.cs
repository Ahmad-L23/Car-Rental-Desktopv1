namespace CarRentalSystem.EmployeeUsageForms
{
    partial class frmAddEditEmployeeUsage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.lblCar = new System.Windows.Forms.Label();
            this.cbCar = new System.Windows.Forms.ComboBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblExitDate = new System.Windows.Forms.Label();
            this.dtExitDate = new System.Windows.Forms.DateTimePicker();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nudExitCounter = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExitFuel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEntrybranch = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEntry = new System.Windows.Forms.DateTimePicker();
            this.nupEntryCounter = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEnteryFuel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExitCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupEntryCounter)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(266, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(365, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add / Edit Employee Usage";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(16, 33);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(72, 16);
            this.lblEmployee.TabIndex = 1;
            this.lblEmployee.Text = "Employee:";
            // 
            // cbEmployee
            // 
            this.cbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEmployee.Location = new System.Drawing.Point(123, 28);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(300, 21);
            this.cbEmployee.TabIndex = 2;
            this.cbEmployee.Validating += new System.ComponentModel.CancelEventHandler(this.cbEmployee_Validating);
            // 
            // lblCar
            // 
            this.lblCar.AutoSize = true;
            this.lblCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCar.Location = new System.Drawing.Point(16, 78);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(31, 16);
            this.lblCar.TabIndex = 3;
            this.lblCar.Text = "Car:";
            // 
            // cbCar
            // 
            this.cbCar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCar.Location = new System.Drawing.Point(123, 75);
            this.cbCar.Name = "cbCar";
            this.cbCar.Size = new System.Drawing.Size(300, 21);
            this.cbCar.TabIndex = 4;
            this.cbCar.Validating += new System.ComponentModel.CancelEventHandler(this.cbCar_Validating);
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(16, 123);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(102, 16);
            this.lblReason.TabIndex = 5;
            this.lblReason.Text = "Usage Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(123, 122);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(300, 50);
            this.txtReason.TabIndex = 6;
            this.txtReason.Validating += new System.ComponentModel.CancelEventHandler(this.txtReason_Validating);
            // 
            // lblExitDate
            // 
            this.lblExitDate.AutoSize = true;
            this.lblExitDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExitDate.Location = new System.Drawing.Point(17, 47);
            this.lblExitDate.Name = "lblExitDate";
            this.lblExitDate.Size = new System.Drawing.Size(63, 16);
            this.lblExitDate.TabIndex = 7;
            this.lblExitDate.Text = "Exit Date:";
            // 
            // dtExitDate
            // 
            this.dtExitDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExitDate.Location = new System.Drawing.Point(104, 40);
            this.dtExitDate.Name = "dtExitDate";
            this.dtExitDate.Size = new System.Drawing.Size(293, 20);
            this.dtExitDate.TabIndex = 8;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.Location = new System.Drawing.Point(17, 88);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(76, 16);
            this.lblBranch.TabIndex = 9;
            this.lblBranch.Text = "Exit Branch:";
            // 
            // cbBranch
            // 
            this.cbBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbBranch.Location = new System.Drawing.Point(104, 85);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(293, 21);
            this.cbBranch.TabIndex = 10;
            this.cbBranch.Validating += new System.ComponentModel.CancelEventHandler(this.cbBranch_Validating);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(16, 201);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 16);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status:";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Location = new System.Drawing.Point(123, 198);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(300, 21);
            this.cbStatus.TabIndex = 12;
            this.cbStatus.Validating += new System.ComponentModel.CancelEventHandler(this.cbStatus_Validating);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(291, 565);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(458, 565);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Exit Counter";
            // 
            // nudExitCounter
            // 
            this.nudExitCounter.Location = new System.Drawing.Point(104, 126);
            this.nudExitCounter.Name = "nudExitCounter";
            this.nudExitCounter.Size = new System.Drawing.Size(293, 20);
            this.nudExitCounter.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Exit Fuel";
            // 
            // txtExitFuel
            // 
            this.txtExitFuel.Location = new System.Drawing.Point(104, 166);
            this.txtExitFuel.Name = "txtExitFuel";
            this.txtExitFuel.Size = new System.Drawing.Size(293, 20);
            this.txtExitFuel.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Entry Branch";
            // 
            // cmbEntrybranch
            // 
            this.cmbEntrybranch.FormattingEnabled = true;
            this.cmbEntrybranch.Location = new System.Drawing.Point(106, 38);
            this.cmbEntrybranch.Name = "cmbEntrybranch";
            this.cmbEntrybranch.Size = new System.Drawing.Size(305, 21);
            this.cmbEntrybranch.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Entry Date:";
            // 
            // dtpEntry
            // 
            this.dtpEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntry.Location = new System.Drawing.Point(106, 76);
            this.dtpEntry.Name = "dtpEntry";
            this.dtpEntry.Size = new System.Drawing.Size(305, 20);
            this.dtpEntry.TabIndex = 22;
            // 
            // nupEntryCounter
            // 
            this.nupEntryCounter.Location = new System.Drawing.Point(106, 117);
            this.nupEntryCounter.Name = "nupEntryCounter";
            this.nupEntryCounter.Size = new System.Drawing.Size(305, 20);
            this.nupEntryCounter.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Entry Counter";
            // 
            // txtEnteryFuel
            // 
            this.txtEnteryFuel.Location = new System.Drawing.Point(106, 159);
            this.txtEnteryFuel.Name = "txtEnteryFuel";
            this.txtEnteryFuel.Size = new System.Drawing.Size(305, 20);
            this.txtEnteryFuel.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Entry Fuel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nupEntryCounter);
            this.groupBox1.Controls.Add(this.txtEnteryFuel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbEntrybranch);
            this.groupBox1.Controls.Add(this.dtpEntry);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 189);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entry Info";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtExitFuel);
            this.groupBox2.Controls.Add(this.cbBranch);
            this.groupBox2.Controls.Add(this.lblBranch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtExitDate);
            this.groupBox2.Controls.Add(this.nudExitCounter);
            this.groupBox2.Controls.Add(this.lblExitDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(458, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 243);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exit Info";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtReason);
            this.groupBox3.Controls.Add(this.cbStatus);
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Controls.Add(this.lblReason);
            this.groupBox3.Controls.Add(this.lblEmployee);
            this.groupBox3.Controls.Add(this.cbCar);
            this.groupBox3.Controls.Add(this.cbEmployee);
            this.groupBox3.Controls.Add(this.lblCar);
            this.groupBox3.Location = new System.Drawing.Point(12, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 243);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General Info";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 70);
            this.panel1.TabIndex = 30;
            // 
            // frmAddEditEmployeeUsage
            // 
            this.ClientSize = new System.Drawing.Size(897, 631);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmAddEditEmployeeUsage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Employee Usage";
            this.Load += new System.EventHandler(this.frmAddEditEmployeeUsage_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExitCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupEntryCounter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.ComboBox cbCar;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblExitDate;
        private System.Windows.Forms.DateTimePicker dtExitDate;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cbBranch;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.NumericUpDown nudExitCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEntry;
        private System.Windows.Forms.ComboBox cmbEntrybranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExitFuel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupEntryCounter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEnteryFuel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
    }
}
