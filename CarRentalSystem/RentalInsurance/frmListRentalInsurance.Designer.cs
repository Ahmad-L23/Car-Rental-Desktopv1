namespace CarRentalSystem.RentalInsurance
{
    partial class frmListRentalInsurance
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
            this.listRentalInsuranceCtrl1 = new CarRentalSystem.RentalInsurance.ListRentalInsuranceCtrl();
            this.SuspendLayout();
            // 
            // listRentalInsuranceCtrl1
            // 
            this.listRentalInsuranceCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listRentalInsuranceCtrl1.Location = new System.Drawing.Point(3, 7);
            this.listRentalInsuranceCtrl1.Name = "listRentalInsuranceCtrl1";
            this.listRentalInsuranceCtrl1.Size = new System.Drawing.Size(508, 547);
            this.listRentalInsuranceCtrl1.TabIndex = 0;
            // 
            // frmListRentalInsurance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 566);
            this.Controls.Add(this.listRentalInsuranceCtrl1);
            this.Name = "frmListRentalInsurance";
            this.Text = "frmListRentalInsurance";
            this.ResumeLayout(false);

        }

        #endregion

        private ListRentalInsuranceCtrl listRentalInsuranceCtrl1;
    }
}