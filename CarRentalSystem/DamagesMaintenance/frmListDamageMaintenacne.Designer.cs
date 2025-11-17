namespace CarRentalSystem.DamagesMaintenance
{
    partial class frmListDamageMaintenance
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
            this.dgvDamaManten = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAllDamages = new System.Windows.Forms.Button();
            this.btnAddCDamagemain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamaManten)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDamaManten
            // 
            this.dgvDamaManten.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvDamaManten.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDamaManten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDamaManten.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDamaManten.BackgroundColor = System.Drawing.Color.White;
            this.dgvDamaManten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDamaManten.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDamaManten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDamaManten.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDamaManten.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDamaManten.EnableHeadersVisualStyles = false;
            this.dgvDamaManten.GridColor = System.Drawing.Color.LightGray;
            this.dgvDamaManten.Location = new System.Drawing.Point(0, 127);
            this.dgvDamaManten.MultiSelect = false;
            this.dgvDamaManten.Name = "dgvDamaManten";
            this.dgvDamaManten.ReadOnly = true;
            this.dgvDamaManten.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDamaManten.Size = new System.Drawing.Size(564, 309);
            this.dgvDamaManten.TabIndex = 4;
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
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click_1);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
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
            this.panel1.Size = new System.Drawing.Size(565, 70);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(123, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Damage Maintance Management";
            // 
            // btnAllDamages
            // 
            this.btnAllDamages.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAllDamages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllDamages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllDamages.ForeColor = System.Drawing.Color.White;
            this.btnAllDamages.Location = new System.Drawing.Point(0, 76);
            this.btnAllDamages.Name = "btnAllDamages";
            this.btnAllDamages.Size = new System.Drawing.Size(97, 45);
            this.btnAllDamages.TabIndex = 7;
            this.btnAllDamages.Text = "list All Damages Miantenacne";
            this.btnAllDamages.UseVisualStyleBackColor = false;
            this.btnAllDamages.Click += new System.EventHandler(this.btnAllDamages_Click);
            // 
            // btnAddCDamagemain
            // 
            this.btnAddCDamagemain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddCDamagemain.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddCDamagemain.BackgroundImage = global::CarRentalSystem.Properties.Resources.maintenacne;
            this.btnAddCDamagemain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCDamagemain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCDamagemain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCDamagemain.ForeColor = System.Drawing.Color.White;
            this.btnAddCDamagemain.Location = new System.Drawing.Point(489, 76);
            this.btnAddCDamagemain.Name = "btnAddCDamagemain";
            this.btnAddCDamagemain.Size = new System.Drawing.Size(75, 45);
            this.btnAddCDamagemain.TabIndex = 5;
            this.btnAddCDamagemain.UseVisualStyleBackColor = false;
            this.btnAddCDamagemain.Click += new System.EventHandler(this.btnAddCDamagemain_Click_1);
            // 
            // frmListDamageMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 450);
            this.Controls.Add(this.btnAllDamages);
            this.Controls.Add(this.dgvDamaManten);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddCDamagemain);
            this.Name = "frmListDamageMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListDamageMaintenacne";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamaManten)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDamaManten;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddCDamagemain;
        private System.Windows.Forms.Button btnAllDamages;
    }
}