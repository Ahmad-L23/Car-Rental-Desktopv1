using System;
using System.Data;
using System.Windows.Forms;
using CarRentalBusiness; // Assuming your ClsCustomer class is here

namespace CarRentalSystem.Customer
{
    public partial class frmShowCustomerTypes : Form
    {
        public frmShowCustomerTypes()
        {
            InitializeComponent();
            this.Load += frmShowCustomerTypes_Load_1;
        }


        private void LoadCustomerTypes()
        {
            try
            {
                DataTable dt = ClsCustomer.GetAllCustomersTypes();

                // Check if we have data
                if (dt == null || dt.Rows.Count == 0)
                {
                    dgvCustomerTypes.DataSource = null;
                    lblTotal.Text = "No customer data found.";
                    return;
                }

                // Rename columns for display
                if (dt.Columns.Contains("customer_type"))
                    dt.Columns["customer_type"].ColumnName = "Customer Type";

                if (dt.Columns.Contains("CustomerCount"))
                    dt.Columns["CustomerCount"].ColumnName = "Number of Customers";

                dgvCustomerTypes.DataSource = dt;

                // Center header text
                dgvCustomerTypes.Columns["Customer Type"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomerTypes.Columns["Number of Customers"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Center cells of number column
                dgvCustomerTypes.Columns["Number of Customers"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Calculate total
                int total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToInt32(row["Number of Customers"]);
                }
                lblTotal.Text = $"Total Customers: {total}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void frmShowCustomerTypes_Load_1(object sender, EventArgs e)
        {
            LoadCustomerTypes();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadCustomerTypes();
        }
    }
}
