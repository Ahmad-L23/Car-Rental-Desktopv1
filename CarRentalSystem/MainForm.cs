using CarRentalSystem.Box;
using CarRentalSystem.Branch;
using CarRentalSystem.CarTransfer;
using CarRentalSystem.Category;
using CarRentalSystem.Company;
using CarRentalSystem.CompanyInsurance;
using CarRentalSystem.Currency;
using CarRentalSystem.Customer;
using CarRentalSystem.DamagesMaintenance;
using CarRentalSystem.EmployeeUsage;
using CarRentalSystem.Group;
using CarRentalSystem.InsuranceType;
using CarRentalSystem.Location;
using CarRentalSystem.mediator;
using CarRentalSystem.Nationlity;
using CarRentalSystem.Quires;
using CarRentalSystem.RentalAddition;
using CarRentalSystem.Role;
using CarRentalSystem.Setting;
using CarRentalSystem.UserControls;
using CarRentalSystem.Users;
using CarRentalSystem.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        
        private void companiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmShowAndEditDeleteCompanies frmShow = new frmShowAndEditDeleteCompanies();
            
            frmShow.ShowDialog();
            
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListCustomers frmListCustomer = new frmListCustomers();
            frmListCustomer.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCustomerTypes frmShowCustomerTypes = new frmShowCustomerTypes();
            frmShowCustomerTypes.ShowDialog();
        }

        private void nationalityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListAllNationlites frmnation = new frmListAllNationlites();
            frmnation.ShowDialog();
        }

        private void companyManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mediatroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMediatorList frmMediator = new frmMediatorList();
            frmMediator.Show();
        }

        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListBranches frmListBranches = new frmListBranches();
            frmListBranches.ShowDialog();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocations frmListLocations = new frmListLocations();
            frmListLocations.ShowDialog();
        }

        private void groupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListgroups listGr = new frmListgroups();
            listGr.ShowDialog();
        }

        private void catedoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListCategories frmListCate = new frmListCategories();
            frmListCate.ShowDialog();
        }

        private void boxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListBoxs frmListBoxs = new frmListBoxs();
            frmListBoxs.ShowDialog();
        }

        private void currenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListCurrencies frmCurr = new frmListCurrencies();
            frmCurr.ShowDialog();
        }

        private void rolesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListRoles frmEmp = new frmListRoles();   
            frmEmp.ShowDialog();  
        }

        private void carsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListCar frmCars = new frmListCar();
            frmCars.ShowDialog();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frmListUsers = new frmListUsers(); 
            frmListUsers.ShowDialog();
        }

        private void insuranceTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInsuranceTypes frm = new frmListInsuranceTypes();
            frm.ShowDialog();
        }

        private void companyInsuranceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListCompanyInsurances frm = new frmListCompanyInsurances();
            frm.ShowDialog();
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListColors frm = new frmListColors();
            frm.ShowDialog();
        }

        private void rentalAdditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListRentalAdditions frm = new frmListRentalAdditions();
            frm.ShowDialog();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }
        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            // English
            lblTimeEnglish.Text = now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            lblDateEnglish.Text = now.ToString("dddd, MMMM dd yyyy", CultureInfo.InvariantCulture);

            // Arabic (customized to look like English format)
            CultureInfo arCulture = new CultureInfo("ar-SA");
            string dayName = arCulture.DateTimeFormat.GetDayName(now.DayOfWeek);
            string monthName = arCulture.DateTimeFormat.GetMonthName(now.Month);

            // Format manually to match English order: day name, month, day, year
            string dateArabic = $"{dayName}، {monthName} {now.Day} \\ {now.Year}";
            string timeArabic = now.ToString("hh:mm:ss tt", arCulture);

            // Convert digits (0–9) to Arabic-Indic digits (٠–٩)
            lblTimeArabic.Text = ConvertToArabicDigits(timeArabic);
            lblDateArabic.Text = ConvertToArabicDigits(dateArabic);
        }

        private string ConvertToArabicDigits(string input)
        {
            return input
                .Replace('0', '٠')
                .Replace('1', '١')
                .Replace('2', '٢')
                .Replace('3', '٣')
                .Replace('4', '٤')
                .Replace('5', '٥')
                .Replace('6', '٦')
                .Replace('7', '٧')
                .Replace('8', '٨')
                .Replace('9', '٩');
        }

        private void damageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDamageMaintenance frm =  new frmListDamageMaintenance();
            frm.ShowDialog();
        }

        private void employeeUsageCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListEmployeeUsage frm = new frmListEmployeeUsage();
            frm.ShowDialog();
        }

        private void carTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListCarTransfer frm = new frmListCarTransfer();
            frm.ShowDialog();
        }

        private void queryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmQuery frm = new frmQuery();
            frm.ShowDialog();
        }
    }
}
