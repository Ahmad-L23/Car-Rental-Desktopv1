namespace CarRentalSystem.mediator
{
    partial class frmMediatorDetalis
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.PictureBox picLogo;
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Label();
            this.lblMediatorId = new System.Windows.Forms.Label();
            this.lblMediatorIdValue = new System.Windows.Forms.Label();
            this.lblMediatorNameEn = new System.Windows.Forms.Label();
            this.lblMediatorNameEnValue = new System.Windows.Forms.Label();
            this.lblMediatorNameAr = new System.Windows.Forms.Label();
            this.lblMediatorNameArValue = new System.Windows.Forms.Label();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblEmailAddressValue = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblPercentageValue = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblPhoneNumberValue = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblActiveStatus = new System.Windows.Forms.Label();
            picLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(picLogo)).BeginInit();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Image = Properties.Resources.mediator_icon; // 🧩 Add your logo to Resources
            picLogo.Location = new System.Drawing.Point(25, 20);
            picLogo.Name = "picLogo";
            picLogo.Size = new System.Drawing.Size(64, 64);
            picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picLogo.TabStop = false;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.lblActiveStatus);
            this.pnlCard.Controls.Add(this.lblIsActive);
            this.pnlCard.Controls.Add(this.lblPhoneNumberValue);
            this.pnlCard.Controls.Add(this.lblPhoneNumber);
            this.pnlCard.Controls.Add(this.lblPercentageValue);
            this.pnlCard.Controls.Add(this.lblPercentage);
            this.pnlCard.Controls.Add(this.lblEmailAddressValue);
            this.pnlCard.Controls.Add(this.lblEmailAddress);
            this.pnlCard.Controls.Add(this.lblMediatorNameArValue);
            this.pnlCard.Controls.Add(this.lblMediatorNameAr);
            this.pnlCard.Controls.Add(this.lblMediatorNameEnValue);
            this.pnlCard.Controls.Add(this.lblMediatorNameEn);
            this.pnlCard.Controls.Add(this.lblMediatorIdValue);
            this.pnlCard.Controls.Add(this.lblMediatorId);
            this.pnlCard.Controls.Add(this.separator);
            this.pnlCard.Controls.Add(this.lblHeader);
            this.pnlCard.Controls.Add(picLogo);
            this.pnlCard.Location = new System.Drawing.Point(20, 20);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(460, 360);
            this.pnlCard.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(35, 55, 80);
            this.lblHeader.Location = new System.Drawing.Point(100, 35);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(197, 30);
            this.lblHeader.Text = "Mediator Details";
            // 
            // separator
            // 
            this.separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator.Location = new System.Drawing.Point(25, 95);
            this.separator.Size = new System.Drawing.Size(410, 2);
            // 
            // lblMediatorId
            // 
            this.lblMediatorId.AutoSize = true;
            this.lblMediatorId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMediatorId.Location = new System.Drawing.Point(50, 120);
            this.lblMediatorId.Text = "Mediator ID:";
            // 
            this.lblMediatorIdValue.AutoSize = true;
            this.lblMediatorIdValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMediatorIdValue.ForeColor = System.Drawing.Color.DimGray;
            this.lblMediatorIdValue.Location = new System.Drawing.Point(180, 120);
            this.lblMediatorIdValue.Text = "###";
            // 
            // lblMediatorNameEn
            // 
            this.lblMediatorNameEn.AutoSize = true;
            this.lblMediatorNameEn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMediatorNameEn.Location = new System.Drawing.Point(50, 155);
            this.lblMediatorNameEn.Text = "Name (EN):";
            // 
            this.lblMediatorNameEnValue.AutoSize = true;
            this.lblMediatorNameEnValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMediatorNameEnValue.ForeColor = System.Drawing.Color.DimGray;
            this.lblMediatorNameEnValue.Location = new System.Drawing.Point(180, 155);
            this.lblMediatorNameEnValue.Text = "???";
            // 
            // lblMediatorNameAr
            // 
            this.lblMediatorNameAr.AutoSize = true;
            this.lblMediatorNameAr.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMediatorNameAr.Location = new System.Drawing.Point(50, 190);
            this.lblMediatorNameAr.Text = "Name (AR):";
            // 
            this.lblMediatorNameArValue.AutoSize = true;
            this.lblMediatorNameArValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMediatorNameArValue.ForeColor = System.Drawing.Color.DimGray;
            this.lblMediatorNameArValue.Location = new System.Drawing.Point(180, 190);
            this.lblMediatorNameArValue.Text = "???";
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmailAddress.Location = new System.Drawing.Point(50, 225);
            this.lblEmailAddress.Text = "Email:";
            // 
            this.lblEmailAddressValue.AutoSize = true;
            this.lblEmailAddressValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmailAddressValue.ForeColor = System.Drawing.Color.DimGray;
            this.lblEmailAddressValue.Location = new System.Drawing.Point(180, 225);
            this.lblEmailAddressValue.Text = "???";
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPercentage.Location = new System.Drawing.Point(50, 260);
            this.lblPercentage.Text = "Percentage:";
            // 
            this.lblPercentageValue.AutoSize = true;
            this.lblPercentageValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPercentageValue.ForeColor = System.Drawing.Color.DimGray;
            this.lblPercentageValue.Location = new System.Drawing.Point(180, 260);
            this.lblPercentageValue.Text = "???";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhoneNumber.Location = new System.Drawing.Point(50, 295);
            this.lblPhoneNumber.Text = "Phone:";
            // 
            this.lblPhoneNumberValue.AutoSize = true;
            this.lblPhoneNumberValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhoneNumberValue.ForeColor = System.Drawing.Color.DimGray;
            this.lblPhoneNumberValue.Location = new System.Drawing.Point(180, 295);
            this.lblPhoneNumberValue.Text = "???";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIsActive.Location = new System.Drawing.Point(50, 330);
            this.lblIsActive.Text = "Status:";
            // 
            // lblActiveStatus
            // 
            this.lblActiveStatus.AutoSize = true;
            this.lblActiveStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblActiveStatus.ForeColor = System.Drawing.Color.Green;
            this.lblActiveStatus.Location = new System.Drawing.Point(180, 330);
            this.lblActiveStatus.Text = "Active";
            // 
            // frmMediatorDetalis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.pnlCard);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMediatorDetalis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mediator Details";
            this.Load += new System.EventHandler(this.frmMediatorDetalis_Load_1);
            ((System.ComponentModel.ISupportInitialize)(picLogo)).EndInit();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Label lblMediatorId;
        private System.Windows.Forms.Label lblMediatorIdValue;
        private System.Windows.Forms.Label lblMediatorNameEn;
        private System.Windows.Forms.Label lblMediatorNameEnValue;
        private System.Windows.Forms.Label lblMediatorNameAr;
        private System.Windows.Forms.Label lblMediatorNameArValue;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblEmailAddressValue;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label lblPercentageValue;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumberValue;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblActiveStatus;
    }
}
