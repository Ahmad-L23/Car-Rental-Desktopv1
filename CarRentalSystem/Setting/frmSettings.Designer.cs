namespace CarRentalSystem.Setting
{
    partial class frmSettings
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.ListBox listBoxSidebar;
        private System.Windows.Forms.Panel panelMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.listBoxSidebar = new System.Windows.Forms.ListBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panelSidebar.Controls.Add(this.listBoxSidebar);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(200, 600);
            this.panelSidebar.TabIndex = 1;
            // 
            // listBoxSidebar
            // 
            this.listBoxSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.listBoxSidebar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSidebar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.listBoxSidebar.ForeColor = System.Drawing.Color.White;
            this.listBoxSidebar.ItemHeight = 20;
            this.listBoxSidebar.Location = new System.Drawing.Point(0, 60);
            this.listBoxSidebar.Name = "listBoxSidebar";
            this.listBoxSidebar.Size = new System.Drawing.Size(200, 540);
            this.listBoxSidebar.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(650, 600);
            this.panelMain.TabIndex = 0;
            // 
            // frmSettings
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings Management";
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
