namespace CarRentalSystem.RentalInsurance
{
    partial class ListRentalInsuranceCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.BtnAddMaintenanceType = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRentalInsurance = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalInsurance)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(113, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(283, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Rental Insurance Management";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(508, 60);
            this.panelHeader.TabIndex = 4;
            // 
            // BtnAddMaintenanceType
            // 
            this.BtnAddMaintenanceType.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAddMaintenanceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddMaintenanceType.ForeColor = System.Drawing.Color.White;
            this.BtnAddMaintenanceType.Location = new System.Drawing.Point(405, 125);
            this.BtnAddMaintenanceType.Name = "BtnAddMaintenanceType";
            this.BtnAddMaintenanceType.Size = new System.Drawing.Size(95, 30);
            this.BtnAddMaintenanceType.TabIndex = 5;
            this.BtnAddMaintenanceType.Text = "Add New";
            this.BtnAddMaintenanceType.UseVisualStyleBackColor = false;
            this.BtnAddMaintenanceType.Click += new System.EventHandler(this.BtnAddMaintenanceType_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 48);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // dgvRentalInsurance
            // 
            this.dgvRentalInsurance.AllowUserToAddRows = false;
            this.dgvRentalInsurance.AllowUserToDeleteRows = false;
            this.dgvRentalInsurance.AllowUserToResizeRows = false;
            this.dgvRentalInsurance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRentalInsurance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRentalInsurance.BackgroundColor = System.Drawing.Color.White;
            this.dgvRentalInsurance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRentalInsurance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalInsurance.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvRentalInsurance.Location = new System.Drawing.Point(6, 161);
            this.dgvRentalInsurance.MultiSelect = false;
            this.dgvRentalInsurance.Name = "dgvRentalInsurance";
            this.dgvRentalInsurance.ReadOnly = true;
            this.dgvRentalInsurance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentalInsurance.Size = new System.Drawing.Size(494, 390);
            this.dgvRentalInsurance.TabIndex = 9;
            this.dgvRentalInsurance.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRentalInsurance_CellFormatting);
            // 
            // ListRentalInsuranceCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvRentalInsurance);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.BtnAddMaintenanceType);
            this.Name = "ListRentalInsuranceCtrl";
            this.Size = new System.Drawing.Size(508, 554);
            this.Load += new System.EventHandler(this.ListRentalInsuranceCtrl_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalInsurance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button BtnAddMaintenanceType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvRentalInsurance;
    }
}
