namespace CarRentalSystem.Customer
{
    partial class frmCustomerDetalis
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
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.ctrlCustomerDetalis1 = new CarRentalSystem.Customer.ctrlCustomerDetalis();
            this.SuspendLayout();
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddNewCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCustomer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddNewCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(306, 36);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(120, 30);
            this.btnAddNewCustomer.TabIndex = 2;
            this.btnAddNewCustomer.Text = "Add New Customer";
            this.btnAddNewCustomer.UseVisualStyleBackColor = false;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlCustomerDetalis1
            // 
            this.ctrlCustomerDetalis1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ctrlCustomerDetalis1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ctrlCustomerDetalis1.Location = new System.Drawing.Point(12, 74);
            this.ctrlCustomerDetalis1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlCustomerDetalis1.Name = "ctrlCustomerDetalis1";
            this.ctrlCustomerDetalis1.Size = new System.Drawing.Size(414, 304);
            this.ctrlCustomerDetalis1.TabIndex = 3;
            // 
            // frmCustomerDetalis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(430, 380);
            this.Controls.Add(this.ctrlCustomerDetalis1);
            this.Controls.Add(this.btnAddNewCustomer);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmCustomerDetalis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Details";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewCustomer;
        private ctrlCustomerDetalis ctrlCustomerDetalis1;
    }
}
