namespace CarRentalSystem.PaymentMethods
{
    partial class ucPaymentMethods
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvPaymentMethods;
        private System.Windows.Forms.Button BtnAddPaymentMethod;
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
            this.dgvPaymentMethods = new System.Windows.Forms.DataGridView();
            this.BtnAddPaymentMethod = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentMethods)).BeginInit();
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
            // dgvPaymentMethods
            // 
            this.dgvPaymentMethods.AllowUserToAddRows = false;
            this.dgvPaymentMethods.AllowUserToDeleteRows = false;
            this.dgvPaymentMethods.AllowUserToResizeRows = false;
            this.dgvPaymentMethods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaymentMethods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymentMethods.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaymentMethods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPaymentMethods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentMethods.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPaymentMethods.Location = new System.Drawing.Point(15, 115);
            this.dgvPaymentMethods.MultiSelect = false;
            this.dgvPaymentMethods.Name = "dgvPaymentMethods";
            this.dgvPaymentMethods.ReadOnly = true;
            this.dgvPaymentMethods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentMethods.Size = new System.Drawing.Size(600, 350);
            this.dgvPaymentMethods.TabIndex = 3;
            this.dgvPaymentMethods.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPaymentMethods_CellMouseDown);
            // 
            // BtnAddPaymentMethod
            // 
            this.BtnAddPaymentMethod.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddPaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddPaymentMethod.ForeColor = System.Drawing.Color.White;
            this.BtnAddPaymentMethod.Location = new System.Drawing.Point(520, 75);
            this.BtnAddPaymentMethod.Name = "BtnAddPaymentMethod";
            this.BtnAddPaymentMethod.Size = new System.Drawing.Size(95, 30);
            this.BtnAddPaymentMethod.TabIndex = 2;
            this.BtnAddPaymentMethod.Text = "Add new";
            this.BtnAddPaymentMethod.UseVisualStyleBackColor = false;
            this.BtnAddPaymentMethod.Click += new System.EventHandler(this.BtnAddPaymentMethod_Click);
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
            this.lblTitle.Size = new System.Drawing.Size(296, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Payment Methods Management";
            // 
            // ucPaymentMethods
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.BtnAddPaymentMethod);
            this.Controls.Add(this.dgvPaymentMethods);
            this.Name = "ucPaymentMethods";
            this.Size = new System.Drawing.Size(630, 480);
            this.Load += new System.EventHandler(this.ucPaymentMethods_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentMethods)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
