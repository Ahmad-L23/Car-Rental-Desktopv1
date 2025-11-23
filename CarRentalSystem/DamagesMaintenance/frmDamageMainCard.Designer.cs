namespace CarRentalSystem.DamagesMaintenance
{
    partial class frmDamageMainCard
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
            this.ucDamageMaintenanceCard1 = new CarRentalSystem.DamagesMaintenance.ucDamageMaintenanceCard();
            this.SuspendLayout();
            // 
            // ucDamageMaintenanceCard1
            // 
            this.ucDamageMaintenanceCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDamageMaintenanceCard1.Location = new System.Drawing.Point(12, 12);
            this.ucDamageMaintenanceCard1.Name = "ucDamageMaintenanceCard1";
            this.ucDamageMaintenanceCard1.Size = new System.Drawing.Size(459, 373);
            this.ucDamageMaintenanceCard1.TabIndex = 0;
            // 
            // frmDamageMainCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 402);
            this.Controls.Add(this.ucDamageMaintenanceCard1);
            this.Name = "frmDamageMainCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDamageMainCard";
            this.Load += new System.EventHandler(this.frmDamageMainCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucDamageMaintenanceCard ucDamageMaintenanceCard1;
    }
}