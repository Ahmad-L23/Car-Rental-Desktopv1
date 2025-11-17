namespace CarRentalSystem.RequiredInsurances
{
    partial class ucRequiredInsurances
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvRequiredInsurances;
        private System.Windows.Forms.Button BtnAddRequiredInsurance;
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
            this.dgvRequiredInsurances = new System.Windows.Forms.DataGridView();
            this.BtnAddRequiredInsurance = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            // contextMenuStrip1
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.editToolStripMenuItem,
                this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);

            // editToolStripMenuItem
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);

            // deleteToolStripMenuItem
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);

            // dgvRequiredInsurances
            this.dgvRequiredInsurances.AllowUserToAddRows = false;
            this.dgvRequiredInsurances.AllowUserToDeleteRows = false;
            this.dgvRequiredInsurances.AllowUserToResizeRows = false;
            this.dgvRequiredInsurances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequiredInsurances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequiredInsurances.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequiredInsurances.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequiredInsurances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequiredInsurances.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvRequiredInsurances.Location = new System.Drawing.Point(15, 115);
            this.dgvRequiredInsurances.MultiSelect = false;
            this.dgvRequiredInsurances.Name = "dgvRequiredInsurances";
            this.dgvRequiredInsurances.ReadOnly = true;
            this.dgvRequiredInsurances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequiredInsurances.Size = new System.Drawing.Size(600, 350);
            this.dgvRequiredInsurances.TabIndex = 3;
            this.dgvRequiredInsurances.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRequiredInsurances_CellMouseDown);

            // BtnAddRequiredInsurance
            this.BtnAddRequiredInsurance.Location = new System.Drawing.Point(520, 75);
            this.BtnAddRequiredInsurance.Name = "BtnAddRequiredInsurance";
            this.BtnAddRequiredInsurance.Size = new System.Drawing.Size(95, 30);
            this.BtnAddRequiredInsurance.TabIndex = 2;
            this.BtnAddRequiredInsurance.Text = "Add New";
            this.BtnAddRequiredInsurance.UseVisualStyleBackColor = true;
            this.BtnAddRequiredInsurance.Click += new System.EventHandler(this.BtnAddRequiredInsurance_Click);

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(35, 55, 80);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(630, 60);
            this.panelHeader.TabIndex = 1;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(180, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(275, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Required Insurances Management";

            // ucRequiredInsurances
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.BtnAddRequiredInsurance);
            this.Controls.Add(this.dgvRequiredInsurances);
            this.Name = "ucRequiredInsurances";
            this.Size = new System.Drawing.Size(630, 480);
            this.Load += new System.EventHandler(this.ucRequiredInsurances_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvRequiredInsurances)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
