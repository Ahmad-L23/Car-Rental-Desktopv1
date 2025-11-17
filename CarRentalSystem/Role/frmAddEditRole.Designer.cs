namespace CarRentalSystem.Role
{
    partial class frmAddEditRole
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNameEn;
        private System.Windows.Forms.Label lblNameAr;
        private System.Windows.Forms.TextBox txtNameEn;
        private System.Windows.Forms.TextBox txtNameAr;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBoxInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNameEn = new System.Windows.Forms.Label();
            this.lblNameAr = new System.Windows.Forms.Label();
            this.txtNameEn = new System.Windows.Forms.TextBox();
            this.txtNameAr = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(37, 22);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(270, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add / Edit Role";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNameEn
            // 
            this.lblNameEn.AutoSize = true;
            this.lblNameEn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNameEn.Location = new System.Drawing.Point(11, 23);
            this.lblNameEn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNameEn.Name = "lblNameEn";
            this.lblNameEn.Size = new System.Drawing.Size(68, 15);
            this.lblNameEn.TabIndex = 0;
            this.lblNameEn.Text = "Name (EN):";
            // 
            // lblNameAr
            // 
            this.lblNameAr.AutoSize = true;
            this.lblNameAr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNameAr.Location = new System.Drawing.Point(11, 49);
            this.lblNameAr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNameAr.Name = "lblNameAr";
            this.lblNameAr.Size = new System.Drawing.Size(68, 15);
            this.lblNameAr.TabIndex = 2;
            this.lblNameAr.Text = "Name (AR):";
            // 
            // txtNameEn
            // 
            this.txtNameEn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNameEn.Location = new System.Drawing.Point(90, 21);
            this.txtNameEn.Margin = new System.Windows.Forms.Padding(2);
            this.txtNameEn.Name = "txtNameEn";
            this.txtNameEn.Size = new System.Drawing.Size(227, 23);
            this.txtNameEn.TabIndex = 1;
            // 
            // txtNameAr
            // 
            this.txtNameAr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNameAr.Location = new System.Drawing.Point(90, 47);
            this.txtNameAr.Margin = new System.Windows.Forms.Padding(2);
            this.txtNameAr.Name = "txtNameAr";
            this.txtNameAr.Size = new System.Drawing.Size(227, 23);
            this.txtNameAr.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(136, 163);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(212, 163);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.lblNameEn);
            this.groupBoxInfo.Controls.Add(this.txtNameEn);
            this.groupBoxInfo.Controls.Add(this.lblNameAr);
            this.groupBoxInfo.Controls.Add(this.txtNameAr);
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxInfo.Location = new System.Drawing.Point(14, 68);
            this.groupBoxInfo.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxInfo.Size = new System.Drawing.Size(325, 84);
            this.groupBoxInfo.TabIndex = 1;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Role Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 65);
            this.panel1.TabIndex = 18;
            // 
            // frmAddEditRole
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(345, 204);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBoxInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Role";
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
    }
}
