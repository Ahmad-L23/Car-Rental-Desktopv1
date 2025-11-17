namespace CarRentalSystem.RentalAddition
{
    partial class frmListRentalAdditions
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRentalAddition = new System.Windows.Forms.DataGridView();
            this.cmsRentalAdditon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddRenAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalAddition)).BeginInit();
            this.cmsRentalAdditon.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRentalAddition
            // 
            this.dgvRentalAddition.AllowUserToAddRows = false;
            this.dgvRentalAddition.AllowUserToResizeColumns = false;
            this.dgvRentalAddition.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvRentalAddition.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRentalAddition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRentalAddition.BackgroundColor = System.Drawing.Color.White;
            this.dgvRentalAddition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRentalAddition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRentalAddition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalAddition.ContextMenuStrip = this.cmsRentalAdditon;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRentalAddition.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRentalAddition.EnableHeadersVisualStyles = false;
            this.dgvRentalAddition.GridColor = System.Drawing.Color.LightGray;
            this.dgvRentalAddition.Location = new System.Drawing.Point(2, 126);
            this.dgvRentalAddition.MultiSelect = false;
            this.dgvRentalAddition.Name = "dgvRentalAddition";
            this.dgvRentalAddition.ReadOnly = true;
            this.dgvRentalAddition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentalAddition.Size = new System.Drawing.Size(481, 321);
            this.dgvRentalAddition.TabIndex = 2;
            this.dgvRentalAddition.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRentalAddition_CellMouseDown);
            // 
            // cmsRentalAdditon
            // 
            this.cmsRentalAdditon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsRentalAdditon.Name = "cmsRentalAdditon";
            this.cmsRentalAdditon.Size = new System.Drawing.Size(181, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click_1);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 72);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rental Addition Management";
            // 
            // btnAddRenAdd
            // 
            this.btnAddRenAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddRenAdd.BackgroundImage = global::CarRentalSystem.Properties.Resources.RentalAdditon;
            this.btnAddRenAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddRenAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRenAdd.ForeColor = System.Drawing.Color.White;
            this.btnAddRenAdd.Location = new System.Drawing.Point(440, 90);
            this.btnAddRenAdd.Name = "btnAddRenAdd";
            this.btnAddRenAdd.Size = new System.Drawing.Size(43, 30);
            this.btnAddRenAdd.TabIndex = 4;
            this.btnAddRenAdd.UseVisualStyleBackColor = false;
            this.btnAddRenAdd.Click += new System.EventHandler(this.btnAddRenAdd_Click);
            // 
            // frmListRentalAdditions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddRenAdd);
            this.Controls.Add(this.dgvRentalAddition);
            this.Name = "frmListRentalAdditions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListRentalAdditions";
            this.Load += new System.EventHandler(this.frmListRentalAdditions_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalAddition)).EndInit();
            this.cmsRentalAdditon.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRentalAddition;
        private System.Windows.Forms.ContextMenuStrip cmsRentalAdditon;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnAddRenAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}