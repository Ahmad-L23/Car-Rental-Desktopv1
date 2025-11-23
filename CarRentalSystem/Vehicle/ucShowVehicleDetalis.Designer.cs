namespace CarRentalSystem.Vehicle
{
    partial class ucShowVehicleDetalis
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBackground;

        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.Label lblChassis;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblEngineSize;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.Label valPlateNumber;
        private System.Windows.Forms.Label valChassis;
        private System.Windows.Forms.Label valType;
        private System.Windows.Forms.Label valGroup;
        private System.Windows.Forms.Label valModel;
        private System.Windows.Forms.Label valEngineSize;
        private System.Windows.Forms.Label valStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBackground = new System.Windows.Forms.Panel();

            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.lblChassis = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblEngineSize = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();

            this.valPlateNumber = new System.Windows.Forms.Label();
            this.valChassis = new System.Windows.Forms.Label();
            this.valType = new System.Windows.Forms.Label();
            this.valGroup = new System.Windows.Forms.Label();
            this.valModel = new System.Windows.Forms.Label();
            this.valEngineSize = new System.Windows.Forms.Label();
            this.valStatus = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // UserControl background
            this.BackColor = System.Drawing.Color.FromArgb(240, 243, 247);

            // Panel for card look
            this.pnlBackground.BackColor = System.Drawing.Color.White;
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackground.Location = new System.Drawing.Point(10, 50);
            this.pnlBackground.Size = new System.Drawing.Size(340, 230);
            this.pnlBackground.Padding = new System.Windows.Forms.Padding(10);

            // Title label
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.lblTitle.Location = new System.Drawing.Point(85, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Vehicle Information";

            // Left labels style
            System.Drawing.Font lblFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            System.Drawing.Color lblColor = System.Drawing.Color.FromArgb(80, 80, 80);

            // Value labels style
            System.Drawing.Font valFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            System.Drawing.Color valColor = System.Drawing.Color.FromArgb(30, 90, 160);

            // Left labels locations and properties
            this.lblPlateNumber.Location = new System.Drawing.Point(30, 20);
            this.lblPlateNumber.Size = new System.Drawing.Size(130, 23);
            this.lblPlateNumber.Font = lblFont;
            this.lblPlateNumber.ForeColor = lblColor;
            this.lblPlateNumber.Text = "License Plate:";
            this.lblPlateNumber.TabIndex = 1;

            this.lblChassis.Location = new System.Drawing.Point(30, 50);
            this.lblChassis.Size = new System.Drawing.Size(130, 23);
            this.lblChassis.Font = lblFont;
            this.lblChassis.ForeColor = lblColor;
            this.lblChassis.Text = "Chassis No.:";
            this.lblChassis.TabIndex = 2;

            this.lblType.Location = new System.Drawing.Point(30, 80);
            this.lblType.Size = new System.Drawing.Size(130, 23);
            this.lblType.Font = lblFont;
            this.lblType.ForeColor = lblColor;
            this.lblType.Text = "Vehicle Type:";
            this.lblType.TabIndex = 3;

            this.lblGroup.Location = new System.Drawing.Point(30, 110);
            this.lblGroup.Size = new System.Drawing.Size(130, 23);
            this.lblGroup.Font = lblFont;
            this.lblGroup.ForeColor = lblColor;
            this.lblGroup.Text = "Vehicle Group:";
            this.lblGroup.TabIndex = 4;

            this.lblModel.Location = new System.Drawing.Point(30, 140);
            this.lblModel.Size = new System.Drawing.Size(130, 23);
            this.lblModel.Font = lblFont;
            this.lblModel.ForeColor = lblColor;
            this.lblModel.Text = "Model Year:";
            this.lblModel.TabIndex = 5;

            this.lblEngineSize.Location = new System.Drawing.Point(30, 170);
            this.lblEngineSize.Size = new System.Drawing.Size(130, 23);
            this.lblEngineSize.Font = lblFont;
            this.lblEngineSize.ForeColor = lblColor;
            this.lblEngineSize.Text = "Engine Size:";
            this.lblEngineSize.TabIndex = 6;

            this.lblStatus.Location = new System.Drawing.Point(30, 200);
            this.lblStatus.Size = new System.Drawing.Size(130, 23);
            this.lblStatus.Font = lblFont;
            this.lblStatus.ForeColor = lblColor;
            this.lblStatus.Text = "Current Status:";
            this.lblStatus.TabIndex = 7;

            // Value labels locations and properties
            this.valPlateNumber.Location = new System.Drawing.Point(170, 20);
            this.valPlateNumber.Size = new System.Drawing.Size(150, 23);
            this.valPlateNumber.Font = valFont;
            this.valPlateNumber.ForeColor = valColor;
            this.valPlateNumber.Text = "???";
            this.valPlateNumber.TabIndex = 8;

            this.valChassis.Location = new System.Drawing.Point(170, 50);
            this.valChassis.Size = new System.Drawing.Size(150, 23);
            this.valChassis.Font = valFont;
            this.valChassis.ForeColor = valColor;
            this.valChassis.Text = "???";
            this.valChassis.TabIndex = 9;

            this.valType.Location = new System.Drawing.Point(170, 80);
            this.valType.Size = new System.Drawing.Size(150, 23);
            this.valType.Font = valFont;
            this.valType.ForeColor = valColor;
            this.valType.Text = "???";
            this.valType.TabIndex = 10;

            this.valGroup.Location = new System.Drawing.Point(170, 110);
            this.valGroup.Size = new System.Drawing.Size(150, 23);
            this.valGroup.Font = valFont;
            this.valGroup.ForeColor = valColor;
            this.valGroup.Text = "???";
            this.valGroup.TabIndex = 11;

            this.valModel.Location = new System.Drawing.Point(170, 140);
            this.valModel.Size = new System.Drawing.Size(150, 23);
            this.valModel.Font = valFont;
            this.valModel.ForeColor = valColor;
            this.valModel.Text = "???";
            this.valModel.TabIndex = 12;

            this.valEngineSize.Location = new System.Drawing.Point(170, 170);
            this.valEngineSize.Size = new System.Drawing.Size(150, 23);
            this.valEngineSize.Font = valFont;
            this.valEngineSize.ForeColor = valColor;
            this.valEngineSize.Text = "???";
            this.valEngineSize.TabIndex = 13;

            this.valStatus.Location = new System.Drawing.Point(170, 200);
            this.valStatus.Size = new System.Drawing.Size(150, 23);
            this.valStatus.Font = valFont;
            this.valStatus.ForeColor = valColor;
            this.valStatus.Text = "???";
            this.valStatus.TabIndex = 14;

            // Add labels to panel
            this.pnlBackground.Controls.Add(this.lblPlateNumber);
            this.pnlBackground.Controls.Add(this.valPlateNumber);
            this.pnlBackground.Controls.Add(this.lblChassis);
            this.pnlBackground.Controls.Add(this.valChassis);
            this.pnlBackground.Controls.Add(this.lblType);
            this.pnlBackground.Controls.Add(this.valType);
            this.pnlBackground.Controls.Add(this.lblGroup);
            this.pnlBackground.Controls.Add(this.valGroup);
            this.pnlBackground.Controls.Add(this.lblModel);
            this.pnlBackground.Controls.Add(this.valModel);
            this.pnlBackground.Controls.Add(this.lblEngineSize);
            this.pnlBackground.Controls.Add(this.valEngineSize);
            this.pnlBackground.Controls.Add(this.lblStatus);
            this.pnlBackground.Controls.Add(this.valStatus);

            // Add controls to UserControl
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlBackground);

            // UserControl size
            this.Name = "ucShowVehicleDetalis";
            this.Size = new System.Drawing.Size(360, 300);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
