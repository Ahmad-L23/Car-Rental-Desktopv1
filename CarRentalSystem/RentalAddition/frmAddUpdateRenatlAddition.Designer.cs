namespace CarRentalSystem.RentalAddition
{
    partial class frmAddUpdateRentalAddition
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRentalName;
        private System.Windows.Forms.TextBox txtRentalName;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblRentalNote;
        private System.Windows.Forms.TextBox txtRentalNote;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;

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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRentalName = new System.Windows.Forms.Label();
            this.txtRentalName = new System.Windows.Forms.TextBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblRentalNote = new System.Windows.Forms.Label();
            this.txtRentalNote = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(17, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add / Update Rental Addon";
            // 
            // lblRentalName
            // 
            this.lblRentalName.AutoSize = true;
            this.lblRentalName.Location = new System.Drawing.Point(17, 52);
            this.lblRentalName.Name = "lblRentalName";
            this.lblRentalName.Size = new System.Drawing.Size(72, 13);
            this.lblRentalName.TabIndex = 1;
            this.lblRentalName.Text = "Rental Name:";
            // 
            // txtRentalName
            // 
            this.txtRentalName.Location = new System.Drawing.Point(111, 49);
            this.txtRentalName.MaxLength = 150;
            this.txtRentalName.Name = "txtRentalName";
            this.txtRentalName.Size = new System.Drawing.Size(215, 20);
            this.txtRentalName.TabIndex = 2;
            this.txtRentalName.Validating += new System.ComponentModel.CancelEventHandler(this.txtRentalName_Validating_1);
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(17, 82);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(90, 13);
            this.lblPaymentMethod.TabIndex = 3;
            this.lblPaymentMethod.Text = "Payment Method:";
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(111, 80);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(215, 21);
            this.cbPaymentMethod.TabIndex = 4;
            this.cbPaymentMethod.Validating += new System.ComponentModel.CancelEventHandler(this.cbPaymentMethod_Validating_1);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(17, 113);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Price:";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(111, 111);
            this.numPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(103, 20);
            this.numPrice.TabIndex = 6;
            this.numPrice.ThousandsSeparator = true;
            this.numPrice.Validating += new System.ComponentModel.CancelEventHandler(this.numPrice_Validating_1);
            // 
            // lblRentalNote
            // 
            this.lblRentalNote.AutoSize = true;
            this.lblRentalNote.Location = new System.Drawing.Point(17, 143);
            this.lblRentalNote.Name = "lblRentalNote";
            this.lblRentalNote.Size = new System.Drawing.Size(67, 13);
            this.lblRentalNote.TabIndex = 7;
            this.lblRentalNote.Text = "Rental Note:";
            // 
            // txtRentalNote
            // 
            this.txtRentalNote.Location = new System.Drawing.Point(111, 140);
            this.txtRentalNote.Multiline = true;
            this.txtRentalNote.Name = "txtRentalNote";
            this.txtRentalNote.Size = new System.Drawing.Size(215, 70);
            this.txtRentalNote.TabIndex = 8;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(111, 221);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(67, 17);
            this.chkIsActive.TabIndex = 9;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(111, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 24);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(249, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 24);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateRentalAddition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 295);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRentalName);
            this.Controls.Add(this.txtRentalName);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.cbPaymentMethod);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblRentalNote);
            this.Controls.Add(this.txtRentalNote);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddUpdateRentalAddition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Update Rental Addition";
            this.Load += new System.EventHandler(this.frmAddUpdateRentalAddition_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
