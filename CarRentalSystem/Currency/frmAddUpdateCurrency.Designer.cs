namespace CarRentalSystem.Currency
{
    partial class frmAddUpdateCurrency
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNameEn;
        private System.Windows.Forms.Label lblNameAr;
        private System.Windows.Forms.TextBox txtNameEn;
        private System.Windows.Forms.TextBox txtNameAr;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNameEn = new System.Windows.Forms.Label();
            this.lblNameAr = new System.Windows.Forms.Label();
            this.txtNameEn = new System.Windows.Forms.TextBox();
            this.txtNameAr = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNameEn
            // 
            this.lblNameEn.AutoSize = true;
            this.lblNameEn.Location = new System.Drawing.Point(35, 79);
            this.lblNameEn.Name = "lblNameEn";
            this.lblNameEn.Size = new System.Drawing.Size(88, 15);
            this.lblNameEn.TabIndex = 0;
            this.lblNameEn.Text = "Name (English)";
            // 
            // lblNameAr
            // 
            this.lblNameAr.AutoSize = true;
            this.lblNameAr.Location = new System.Drawing.Point(35, 124);
            this.lblNameAr.Name = "lblNameAr";
            this.lblNameAr.Size = new System.Drawing.Size(84, 15);
            this.lblNameAr.TabIndex = 2;
            this.lblNameAr.Text = "Name (Arabic)";
            // 
            // txtNameEn
            // 
            this.txtNameEn.Location = new System.Drawing.Point(150, 76);
            this.txtNameEn.Name = "txtNameEn";
            this.txtNameEn.Size = new System.Drawing.Size(250, 23);
            this.txtNameEn.TabIndex = 1;
            // 
            // txtNameAr
            // 
            this.txtNameAr.Location = new System.Drawing.Point(150, 121);
            this.txtNameAr.Name = "txtNameAr";
            this.txtNameAr.Size = new System.Drawing.Size(250, 23);
            this.txtNameAr.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(150, 174);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(310, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 49);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(140, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Currency";
            // 
            // frmAddUpdateCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 214);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNameAr);
            this.Controls.Add(this.lblNameAr);
            this.Controls.Add(this.txtNameEn);
            this.Controls.Add(this.lblNameEn);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddUpdateCurrency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Currency";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
