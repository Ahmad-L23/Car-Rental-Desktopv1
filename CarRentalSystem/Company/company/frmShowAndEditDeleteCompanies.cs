using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalSystem.Company
{
    public partial class frmShowAndEditDeleteCompanies : Form
    {
        public frmShowAndEditDeleteCompanies()
        {
            InitializeComponent();
            this.Load += FrmShowAndEditDeleteCompanies_Load;
        }

        private void FrmShowAndEditDeleteCompanies_Load(object sender, EventArgs e)
        {
            LoadCompanies();
        }

        private void LoadCompanies()
        {
            flowLayoutPanel1.Controls.Clear();

            List<ClsCompany> companies = ClsCompany.GetAllCompanies();

            foreach (var company in companies)
            {
                var companyCard = new CompanyCardUserControl1
                {
                    CompanyId = company.ID,
                    CompanyName = company.NameEn,
                    Width = 200,
                    Height = 250
                };

                if (!string.IsNullOrEmpty(company.Image))
                {
                    string fullPath = Path.Combine(Application.StartupPath, company.Image);
                    if (File.Exists(fullPath))
                    {
                        companyCard.CompanyLogo = Image.FromFile(fullPath);
                    }
                }

                // Subscribe to events with lambdas or methods
                companyCard.EditClicked += CompanyCard_EditClicked;
                companyCard.DeleteClicked += CompanyCard_DeleteClicked;

                flowLayoutPanel1.Controls.Add(companyCard);
            }
        }

        // Edit event handler receives company ID directly
        private void CompanyCard_EditClicked(object sender, int companyId)
        {
             var editForm = new frmAddNewCompnay(companyId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadCompanies(); // Refresh after edit
            }
        }

        // Delete event handler receives company ID directly
        private void CompanyCard_DeleteClicked(object sender, int companyId)
        {
            var company = ClsCompany.GetAllCompanies().FirstOrDefault(c => c.ID == companyId);
            if (company == null) return;

            var confirm = MessageBox.Show($"Are you sure you want to delete company '{company.NameEn}'?",
                                          "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                var companyToDelete = new ClsCompany { ID = companyId };
                if (companyToDelete.DeleteCompany())
                {
                    MessageBox.Show("Company deleted successfully.");
                    LoadCompanies();
                }
                else
                {
                    MessageBox.Show("Failed to delete the company.");
                }
            }
        }

        private void btnAddNewComp_Click(object sender, EventArgs e)
        {
            frmAddNewCompnay frmCompany = new frmAddNewCompnay();
            this.Hide();
            frmCompany.ShowDialog();
        }
    }
}
