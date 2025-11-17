namespace CarRentalSystem.Target_Clients
{
    partial class ucTargetClients
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTargetClients;
        private System.Windows.Forms.Button BtnAddTargetClient;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTargetClients = new System.Windows.Forms.DataGridView();
            this.BtnAddTargetClient = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetClients)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // dgvTargetClients
            // 
            this.dgvTargetClients.AllowUserToAddRows = false;
            this.dgvTargetClients.AllowUserToDeleteRows = false;
            this.dgvTargetClients.AllowUserToResizeRows = false;
            this.dgvTargetClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTargetClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTargetClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvTargetClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTargetClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTargetClients.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTargetClients.Location = new System.Drawing.Point(0, 115);
            this.dgvTargetClients.MultiSelect = false;
            this.dgvTargetClients.Name = "dgvTargetClients";
            this.dgvTargetClients.ReadOnly = true;
            this.dgvTargetClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTargetClients.Size = new System.Drawing.Size(615, 350);
            this.dgvTargetClients.TabIndex = 3;
            this.dgvTargetClients.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTargetClients_CellMouseDown);
            // 
            // BtnAddTargetClient
            // 
            this.BtnAddTargetClient.Location = new System.Drawing.Point(520, 75);
            this.BtnAddTargetClient.Name = "BtnAddTargetClient";
            this.BtnAddTargetClient.Size = new System.Drawing.Size(95, 30);
            this.BtnAddTargetClient.TabIndex = 2;
            this.BtnAddTargetClient.Text = "Add Client";
            this.BtnAddTargetClient.Click += new System.EventHandler(this.BtnAddTargetClient_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(626, 60);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(180, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Target Clients Management";
            // 
            // ucTargetClients
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.BtnAddTargetClient);
            this.Controls.Add(this.dgvTargetClients);
            this.Name = "ucTargetClients";
            this.Size = new System.Drawing.Size(626, 468);
            this.Load += new System.EventHandler(this.ucTargetClients_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetClients)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
