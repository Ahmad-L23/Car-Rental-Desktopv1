using System.Windows.Forms;

namespace CarRentalSystem.Quires
{
    partial class frmQuery
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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.cbQuiers = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pDetalis = new System.Windows.Forms.Panel();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.cbQuiers);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Location = new System.Drawing.Point(20, 20);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(580, 70);
            this.panelSearch.TabIndex = 0;
            // 
            // cbQuiers
            // 
            this.cbQuiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuiers.FormattingEnabled = true;
            this.cbQuiers.Items.AddRange(new object[] {
            "Car",
            "Customer",
            "Mediator",
            "Agreement"});
            this.cbQuiers.Location = new System.Drawing.Point(15, 22);
            this.cbQuiers.Name = "cbQuiers";
            this.cbQuiers.Size = new System.Drawing.Size(160, 23);
            this.cbQuiers.TabIndex = 0;
            this.cbQuiers.SelectedIndexChanged += new System.EventHandler(this.cbQuiers_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.Location = new System.Drawing.Point(190, 25);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(76, 15);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search Value:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(280, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(180, 23);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(480, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pDetalis
            // 
            this.pDetalis.Location = new System.Drawing.Point(20, 126);
            this.pDetalis.Name = "pDetalis";
            this.pDetalis.Size = new System.Drawing.Size(580, 412);
            this.pDetalis.TabIndex = 2;
            // 
            // frmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 550);
            this.Controls.Add(this.pDetalis);
            this.Controls.Add(this.panelSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmQuery";
            this.Text = "Search Queries";
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cbQuiers;
        private Panel panelSearch;
        private Panel pDetalis;
    }
}