using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.Customer
{
    public partial class ctrlCustomerDetalis : UserControl
    {
        public ctrlCustomerDetalis()
        {
            InitializeComponent();
        }

        // Method to load and display customer info by ID
        public void LoadCustomerById(int customerId)
        {
            var customer = ClsCustomer.FindById(customerId);

            if (customer == null)
            {
                MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearLabels();
                return;
            }

            // Set labels' text to customer data
            lblCustomerType.Text = customer.CustomerType ?? "N/A";
            lblCustomerNameEn.Text = customer.CustomerNameEn ?? "N/A";
            lblCustomerNameAr.Text = customer.CustomerNameAr ?? "N/A";
            lblPhoneNumber.Text = customer.PhoneNumber ?? "N/A";
            lblEmail.Text = customer.Email ?? "N/A";
            lblAddressEn.Text = customer.AddressEn ?? "N/A";
            lblAddressAr.Text = customer.AddressAr ?? "N/A";
            lblBlacklist.Text = customer.Blacklist ? "Blacklisted" : "Active";
        }

        // Optional: method to clear all labels
        private void ClearLabels()
        {
            lblCustomerType.Text = "";
            lblCustomerNameEn.Text = "";
            lblCustomerNameAr.Text = "";
            lblPhoneNumber.Text = "";
            lblEmail.Text = "";
            lblAddressEn.Text = "";
            lblAddressAr.Text = "";
            lblBlacklist.Text = "";
        }
    }
}
