using System;
using System.Windows.Forms;

namespace CarRentalSystem.Customer
{
    public partial class frmCustomerDetalis : Form
    {
        private int _customerId;

        public frmCustomerDetalis(int customerId)
        {
            InitializeComponent();

            _customerId = customerId;

            // Load customer details initially
            ctrlCustomerDetalis1.LoadCustomerById(_customerId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open the add/edit form to add new customer (no customerId)
            frmAddEditCustomer frmAdd = new frmAddEditCustomer();

            // Subscribe to the event to get notified when a customer is saved
            frmAdd.CustomerSaved += FrmAdd_CustomerSaved;

            frmAdd.ShowDialog();

            // Unsubscribe to avoid memory leaks
            frmAdd.CustomerSaved -= FrmAdd_CustomerSaved;
        }

        // Event handler to receive the new or updated customer ID
        private void FrmAdd_CustomerSaved(int newCustomerId)
        {
            // Update current customer ID and reload details
            _customerId = newCustomerId;

            // Refresh the displayed details
            ctrlCustomerDetalis1.LoadCustomerById(_customerId);
        }
    }
}
