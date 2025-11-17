using System.Windows.Forms;

namespace CarRentalSystem.mediator
{
    partial class frmAddUpdateMeditor
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private GroupBox groupBoxMediatorDetails;
        private Label lblNameEn;
        private TextBox txtNameEn;
        private Label lblNameAr;
        private TextBox txtNameAr;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPercentage;
        private NumericUpDown numPercentage;
        private Label lblPhone;
        private TextBox txtPhone;
        private CheckBox chkIsActive;
        private Button btnAddNew;
        private Button btnUpdate;
        private ErrorProvider errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBoxMediatorDetails = new System.Windows.Forms.GroupBox();
            this.lblNameEn = new System.Windows.Forms.Label();
            this.txtNameEn = new System.Windows.Forms.TextBox();
            this.lblNameAr = new System.Windows.Forms.Label();
            this.txtNameAr = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.numPercentage = new System.Windows.Forms.NumericUpDown();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxMediatorDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Mediator";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxMediatorDetails
            // 
            this.groupBoxMediatorDetails.Controls.Add(this.lblNameEn);
            this.groupBoxMediatorDetails.Controls.Add(this.txtNameEn);
            this.groupBoxMediatorDetails.Controls.Add(this.lblNameAr);
            this.groupBoxMediatorDetails.Controls.Add(this.txtNameAr);
            this.groupBoxMediatorDetails.Controls.Add(this.lblEmail);
            this.groupBoxMediatorDetails.Controls.Add(this.txtEmail);
            this.groupBoxMediatorDetails.Controls.Add(this.lblPercentage);
            this.groupBoxMediatorDetails.Controls.Add(this.numPercentage);
            this.groupBoxMediatorDetails.Controls.Add(this.lblPhone);
            this.groupBoxMediatorDetails.Controls.Add(this.txtPhone);
            this.groupBoxMediatorDetails.Controls.Add(this.chkIsActive);
            this.groupBoxMediatorDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxMediatorDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.groupBoxMediatorDetails.Location = new System.Drawing.Point(12, 60);
            this.groupBoxMediatorDetails.Name = "groupBoxMediatorDetails";
            this.groupBoxMediatorDetails.Size = new System.Drawing.Size(420, 250);
            this.groupBoxMediatorDetails.TabIndex = 1;
            this.groupBoxMediatorDetails.TabStop = false;
            this.groupBoxMediatorDetails.Text = "Mediator Details";
            // 
            // lblNameEn
            // 
            this.lblNameEn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNameEn.Location = new System.Drawing.Point(15, 30);
            this.lblNameEn.Name = "lblNameEn";
            this.lblNameEn.Size = new System.Drawing.Size(120, 25);
            this.lblNameEn.TabIndex = 0;
            this.lblNameEn.Text = "Name (English):";
            this.lblNameEn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNameEn
            // 
            this.txtNameEn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNameEn.Location = new System.Drawing.Point(145, 30);
            this.txtNameEn.Name = "txtNameEn";
            this.txtNameEn.Size = new System.Drawing.Size(250, 25);
            this.txtNameEn.TabIndex = 1;
            this.txtNameEn.Validating += new System.ComponentModel.CancelEventHandler(this.txtNameEn_Validating);
            // 
            // lblNameAr
            // 
            this.lblNameAr.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNameAr.Location = new System.Drawing.Point(15, 70);
            this.lblNameAr.Name = "lblNameAr";
            this.lblNameAr.Size = new System.Drawing.Size(120, 25);
            this.lblNameAr.TabIndex = 2;
            this.lblNameAr.Text = "Name (Arabic):";
            this.lblNameAr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNameAr
            // 
            this.txtNameAr.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNameAr.Location = new System.Drawing.Point(145, 70);
            this.txtNameAr.Name = "txtNameAr";
            this.txtNameAr.Size = new System.Drawing.Size(250, 25);
            this.txtNameAr.TabIndex = 3;
            this.txtNameAr.Validating += new System.ComponentModel.CancelEventHandler(this.txtNameAr_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(15, 110);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(120, 25);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(145, 110);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 25);
            this.txtEmail.TabIndex = 5;
            // 
            // lblPercentage
            // 
            this.lblPercentage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPercentage.Location = new System.Drawing.Point(15, 150);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(120, 25);
            this.lblPercentage.TabIndex = 6;
            this.lblPercentage.Text = "Percentage (%):";
            this.lblPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numPercentage
            // 
            this.numPercentage.DecimalPlaces = 2;
            this.numPercentage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPercentage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numPercentage.Location = new System.Drawing.Point(145, 150);
            this.numPercentage.Name = "numPercentage";
            this.numPercentage.Size = new System.Drawing.Size(100, 25);
            this.numPercentage.TabIndex = 7;
            this.numPercentage.Validating += new System.ComponentModel.CancelEventHandler(this.numPercentage_Validating);
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhone.Location = new System.Drawing.Point(15, 190);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(120, 25);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Phone Number:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(145, 190);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 25);
            this.txtPhone.TabIndex = 9;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkIsActive.Location = new System.Drawing.Point(145, 220);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(100, 30);
            this.chkIsActive.TabIndex = 10;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(100, 325);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(110, 35);
            this.btnAddNew.TabIndex = 11;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(250, 325);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 35);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateMeditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 380);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBoxMediatorDetails);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnUpdate);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddUpdateMeditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mediator";
            this.groupBoxMediatorDetails.ResumeLayout(false);
            this.groupBoxMediatorDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
