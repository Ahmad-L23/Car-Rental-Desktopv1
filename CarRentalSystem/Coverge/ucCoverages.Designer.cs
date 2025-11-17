namespace CarRentalSystem.Coverge
{
    partial class ucCoverages
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button BtnAddCoverage;
        private System.Windows.Forms.DataGridView dgvCoverage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
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
            this.BtnAddCoverage = new System.Windows.Forms.Button();
            this.dgvCoverage = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoverage)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAddCoverage
            // 
            this.BtnAddCoverage.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddCoverage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddCoverage.ForeColor = System.Drawing.Color.White;
            this.BtnAddCoverage.Location = new System.Drawing.Point(520, 75);
            this.BtnAddCoverage.Name = "BtnAddCoverage";
            this.BtnAddCoverage.Size = new System.Drawing.Size(110, 32);
            this.BtnAddCoverage.TabIndex = 0;
            this.BtnAddCoverage.Text = "Add Coverage";
            this.BtnAddCoverage.UseVisualStyleBackColor = false;
            this.BtnAddCoverage.Click += new System.EventHandler(this.BtnAddCoverage_Click);
            // 
            // dgvCoverage
            // 
            this.dgvCoverage.AllowUserToAddRows = false;
            this.dgvCoverage.AllowUserToDeleteRows = false;
            this.dgvCoverage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCoverage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCoverage.BackgroundColor = System.Drawing.Color.White;
            this.dgvCoverage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCoverage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoverage.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCoverage.Location = new System.Drawing.Point(15, 120);
            this.dgvCoverage.MultiSelect = false;
            this.dgvCoverage.Name = "dgvCoverage";
            this.dgvCoverage.ReadOnly = true;
            this.dgvCoverage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCoverage.Size = new System.Drawing.Size(615, 360);
            this.dgvCoverage.TabIndex = 1;
            this.dgvCoverage.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCoverage_CellMouseDown);
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
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(650, 60);
            this.panelHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(200, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(219, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Coverage Management";
            // 
            // ucCoverages
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.BtnAddCoverage);
            this.Controls.Add(this.dgvCoverage);
            this.Name = "ucCoverages";
            this.Size = new System.Drawing.Size(650, 520);
            this.Load += new System.EventHandler(this.ucCoverages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoverage)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
