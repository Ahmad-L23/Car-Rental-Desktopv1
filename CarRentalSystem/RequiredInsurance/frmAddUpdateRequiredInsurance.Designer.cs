using System.Windows.Forms;

namespace CarRentalSystem.RequiredInsurance
{
    partial class frmAddUpdateRequiredInsurance
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblItemName;
        private TextBox txtItemName;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Button btnSave;
        private Button btnCancel;
        private ErrorProvider errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new Label();
            this.lblItemName = new Label();
            this.txtItemName = new TextBox();
            this.lblPrice = new Label();
            this.numPrice = new NumericUpDown();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.errorProvider1 = new ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(35, 55, 80);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(1, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(440, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Required Insurance";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblItemName
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblItemName.Location = new System.Drawing.Point(15, 80);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(120, 25);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "Item Name:";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // txtItemName
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtItemName.Location = new System.Drawing.Point(145, 80);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(250, 25);
            this.txtItemName.TabIndex = 2;
            this.txtItemName.Validating += new System.ComponentModel.CancelEventHandler(this.txtItemName_Validating);

            // lblPrice
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(15, 125);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(120, 25);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price:";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // numPrice
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPrice.Location = new System.Drawing.Point(145, 125);
            this.numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numPrice.Minimum = new decimal(new int[] { 1, 0, 0, 131072 }); // 0.01
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(120, 25);
            this.numPrice.TabIndex = 4;
            this.numPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPrice.Validating += new System.ComponentModel.CancelEventHandler(this.numPrice_Validating);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(100, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(250, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // errorProvider1
            this.errorProvider1.ContainerControl = this;

            // frmAddUpdateRequiredInsurance
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 250);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Required Insurance";
            this.Load += new System.EventHandler(this.frmAddUpdateRequiredInsurance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
