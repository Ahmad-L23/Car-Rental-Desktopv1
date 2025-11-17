using System.Windows.Forms;
using System.Drawing;

namespace CarRentalSystem.Category
{
    partial class frmAddEditCategory
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblNameEn;
        private TextBox txtNameEn;
        private Label lblNameAr;
        private TextBox txtNameAr;
        private PictureBox picImage;
        private LinkLabel lnkBrowseImage;
        private Button btnSave;
        private Button btnCancel;

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
            this.lblNameEn = new System.Windows.Forms.Label();
            this.txtNameEn = new System.Windows.Forms.TextBox();
            this.lblNameAr = new System.Windows.Forms.Label();
            this.txtNameAr = new System.Windows.Forms.TextBox();
            this.lnkBrowseImage = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNameEn
            // 
            this.lblNameEn.AutoSize = true;
            this.lblNameEn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNameEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblNameEn.Location = new System.Drawing.Point(16, 42);
            this.lblNameEn.Name = "lblNameEn";
            this.lblNameEn.Size = new System.Drawing.Size(109, 19);
            this.lblNameEn.TabIndex = 0;
            this.lblNameEn.Text = "Name (English)";
            // 
            // txtNameEn
            // 
            this.txtNameEn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNameEn.Location = new System.Drawing.Point(128, 42);
            this.txtNameEn.Name = "txtNameEn";
            this.txtNameEn.Size = new System.Drawing.Size(167, 25);
            this.txtNameEn.TabIndex = 1;
            // 
            // lblNameAr
            // 
            this.lblNameAr.AutoSize = true;
            this.lblNameAr.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNameAr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblNameAr.Location = new System.Drawing.Point(16, 82);
            this.lblNameAr.Name = "lblNameAr";
            this.lblNameAr.Size = new System.Drawing.Size(107, 19);
            this.lblNameAr.TabIndex = 2;
            this.lblNameAr.Text = "Name (Arabic)";
            // 
            // txtNameAr
            // 
            this.txtNameAr.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNameAr.Location = new System.Drawing.Point(129, 79);
            this.txtNameAr.Name = "txtNameAr";
            this.txtNameAr.Size = new System.Drawing.Size(167, 25);
            this.txtNameAr.TabIndex = 3;
            // 
            // lnkBrowseImage
            // 
            this.lnkBrowseImage.AutoSize = true;
            this.lnkBrowseImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnkBrowseImage.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lnkBrowseImage.Location = new System.Drawing.Point(326, 201);
            this.lnkBrowseImage.Name = "lnkBrowseImage";
            this.lnkBrowseImage.Size = new System.Drawing.Size(104, 19);
            this.lnkBrowseImage.TabIndex = 5;
            this.lnkBrowseImage.TabStop = true;
            this.lnkBrowseImage.Text = "Browse Image...";
            this.lnkBrowseImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBrowseImage_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(83, 184);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(193, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(308, 38);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(150, 150);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 4;
            this.picImage.TabStop = false;
            // 
            // frmAddEditCategory
            // 
            this.ClientSize = new System.Drawing.Size(470, 258);
            this.Controls.Add(this.lblNameEn);
            this.Controls.Add(this.txtNameEn);
            this.Controls.Add(this.lblNameAr);
            this.Controls.Add(this.txtNameAr);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.lnkBrowseImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
