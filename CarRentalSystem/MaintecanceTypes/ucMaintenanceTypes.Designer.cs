namespace CarRentalSystem.MaintenanceTypes
{
    partial class ucMaintenanceTypes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvMaintenanceTypes;
        private System.Windows.Forms.Button BtnAddMaintenanceType;
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
            this.dgvMaintenanceTypes = new System.Windows.Forms.DataGridView();
            this.BtnAddMaintenanceType = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintenanceTypes)).BeginInit();
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
            // dgvMaintenanceTypes
            // 
            this.dgvMaintenanceTypes.AllowUserToAddRows = false;
            this.dgvMaintenanceTypes.AllowUserToDeleteRows = false;
            this.dgvMaintenanceTypes.AllowUserToResizeRows = false;
            this.dgvMaintenanceTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaintenanceTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaintenanceTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaintenanceTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaintenanceTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaintenanceTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvMaintenanceTypes.Location = new System.Drawing.Point(15, 115);
            this.dgvMaintenanceTypes.MultiSelect = false;
            this.dgvMaintenanceTypes.Name = "dgvMaintenanceTypes";
            this.dgvMaintenanceTypes.ReadOnly = true;
            this.dgvMaintenanceTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaintenanceTypes.Size = new System.Drawing.Size(600, 350);
            this.dgvMaintenanceTypes.TabIndex = 3;
            this.dgvMaintenanceTypes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMaintenanceTypes_CellMouseDown);
            // 
            // BtnAddMaintenanceType
            // 
            this.BtnAddMaintenanceType.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddMaintenanceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddMaintenanceType.ForeColor = System.Drawing.Color.White;
            this.BtnAddMaintenanceType.Location = new System.Drawing.Point(520, 75);
            this.BtnAddMaintenanceType.Name = "BtnAddMaintenanceType";
            this.BtnAddMaintenanceType.Size = new System.Drawing.Size(95, 30);
            this.BtnAddMaintenanceType.TabIndex = 2;
            this.BtnAddMaintenanceType.Text = "Add New";
            this.BtnAddMaintenanceType.UseVisualStyleBackColor = false;
            this.BtnAddMaintenanceType.Click += new System.EventHandler(this.BtnAddMaintenanceType_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(630, 60);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(180, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(305, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Maintenance Types Management";
            // 
            // ucMaintenanceTypes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.BtnAddMaintenanceType);
            this.Controls.Add(this.dgvMaintenanceTypes);
            this.Name = "ucMaintenanceTypes";
            this.Size = new System.Drawing.Size(630, 480);
            this.Load += new System.EventHandler(this.ucMaintenanceTypes_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintenanceTypes)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
