namespace CarRentalSystem
{
    partial class frmAddUpdateColor
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelColorPreview;
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
            this.panelColorPreview = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llSetColor = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // panelColorPreview
            // 
            this.panelColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColorPreview.Location = new System.Drawing.Point(30, 20);
            this.panelColorPreview.Name = "panelColorPreview";
            this.panelColorPreview.Size = new System.Drawing.Size(200, 100);
            this.panelColorPreview.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(37, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(135, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // llSetColor
            // 
            this.llSetColor.AutoSize = true;
            this.llSetColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llSetColor.Location = new System.Drawing.Point(90, 135);
            this.llSetColor.Name = "llSetColor";
            this.llSetColor.Size = new System.Drawing.Size(80, 16);
            this.llSetColor.TabIndex = 4;
            this.llSetColor.TabStop = true;
            this.llSetColor.Text = "Select Color";
            this.llSetColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmAddUpdateColor
            // 
            this.ClientSize = new System.Drawing.Size(258, 237);
            this.Controls.Add(this.llSetColor);
            this.Controls.Add(this.panelColorPreview);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdateColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Color";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.LinkLabel llSetColor;
    }
}
