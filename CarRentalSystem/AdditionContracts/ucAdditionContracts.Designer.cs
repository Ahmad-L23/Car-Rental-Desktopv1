namespace CarRentalSystem.AdditionContracts
{
    partial class ucAdditionContracts
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvAdditionContracts;
        private System.Windows.Forms.Button BtnAddAdditionContract;
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
            this.dgvAdditionContracts = new System.Windows.Forms.DataGridView();
            this.BtnAddAdditionContract = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdditionContracts)).BeginInit();
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
            // dgvAdditionContracts
            // 
            this.dgvAdditionContracts.AllowUserToAddRows = false;
            this.dgvAdditionContracts.AllowUserToDeleteRows = false;
            this.dgvAdditionContracts.AllowUserToResizeRows = false;
            this.dgvAdditionContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdditionContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdditionContracts.BackgroundColor = System.Drawing.Color.White;
            this.dgvAdditionContracts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAdditionContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdditionContracts.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAdditionContracts.Location = new System.Drawing.Point(3, 115);
            this.dgvAdditionContracts.MultiSelect = false;
            this.dgvAdditionContracts.Name = "dgvAdditionContracts";
            this.dgvAdditionContracts.ReadOnly = true;
            this.dgvAdditionContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdditionContracts.Size = new System.Drawing.Size(635, 350);
            this.dgvAdditionContracts.TabIndex = 3;
            this.dgvAdditionContracts.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAdditionContracts_CellMouseDown);
            // 
            // BtnAddAdditionContract
            // 
            this.BtnAddAdditionContract.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddAdditionContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddAdditionContract.ForeColor = System.Drawing.Color.White;
            this.BtnAddAdditionContract.Location = new System.Drawing.Point(542, 79);
            this.BtnAddAdditionContract.Name = "BtnAddAdditionContract";
            this.BtnAddAdditionContract.Size = new System.Drawing.Size(95, 30);
            this.BtnAddAdditionContract.TabIndex = 2;
            this.BtnAddAdditionContract.Text = "Add New";
            this.BtnAddAdditionContract.UseVisualStyleBackColor = false;
            this.BtnAddAdditionContract.Click += new System.EventHandler(this.BtnAddAdditionContract_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(641, 60);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(180, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(303, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Addition Contracts Management";
            // 
            // ucAdditionContracts
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.BtnAddAdditionContract);
            this.Controls.Add(this.dgvAdditionContracts);
            this.Name = "ucAdditionContracts";
            this.Size = new System.Drawing.Size(641, 480);
            this.Load += new System.EventHandler(this.ucAdditionContracts_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdditionContracts)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
