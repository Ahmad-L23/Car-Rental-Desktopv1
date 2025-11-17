using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.Customer
{
    public partial class frmListCustomers : Form
    {
        public frmListCustomers()
        {
            InitializeComponent();

            // Load customers on form load
            this.Load += FrmListCustomers_Load;

        }

        private void FrmListCustomers_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                DataTable dt = ClsCustomer.GetCustomersDataTable();

                // Add computed "BlacklistStatus" column to display friendly blacklist status
                if (!dt.Columns.Contains("BlacklistStatus"))
                    dt.Columns.Add("BlacklistStatus", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    bool isBlacklisted = false;
                    if (dt.Columns.Contains("blacklist") && row["blacklist"] != DBNull.Value)
                        isBlacklisted = Convert.ToBoolean(row["blacklist"]);

                    row["BlacklistStatus"] = isBlacklisted ? "Blacklisted" : "Active";
                }

                dgvListCustomers.DataSource = dt;

                // Hide technical columns
                if (dgvListCustomers.Columns.Contains("customer_id"))
                    dgvListCustomers.Columns["customer_id"].Visible = false;
                if (dgvListCustomers.Columns.Contains("company_id"))
                    dgvListCustomers.Columns["company_id"].Visible = false;
                if (dgvListCustomers.Columns.Contains("nationality_id"))
                    dgvListCustomers.Columns["nationality_id"].Visible = false;
                if (dgvListCustomers.Columns.Contains("mediator_id"))
                    dgvListCustomers.Columns["mediator_id"].Visible = false;

                // Rename headers for readability
                if (dgvListCustomers.Columns.Contains("customer_type"))
                    dgvListCustomers.Columns["customer_type"].HeaderText = "Customer Type";
                if (dgvListCustomers.Columns.Contains("customer_name_en"))
                    dgvListCustomers.Columns["customer_name_en"].HeaderText = "Name (English)";
                if (dgvListCustomers.Columns.Contains("customer_name_ar"))
                    dgvListCustomers.Columns["customer_name_ar"].HeaderText = "Name (Arabic)";
                if (dgvListCustomers.Columns.Contains("phone_number"))
                    dgvListCustomers.Columns["phone_number"].HeaderText = "Phone Number";
                if (dgvListCustomers.Columns.Contains("email"))
                    dgvListCustomers.Columns["email"].HeaderText = "Email";
                if (dgvListCustomers.Columns.Contains("address_en"))
                    dgvListCustomers.Columns["address_en"].HeaderText = "Address (English)";
                if (dgvListCustomers.Columns.Contains("address_ar"))
                    dgvListCustomers.Columns["address_ar"].HeaderText = "Address (Arabic)";
                if (dgvListCustomers.Columns.Contains("notes_en"))
                    dgvListCustomers.Columns["notes_en"].HeaderText = "Notes (English)";
                if (dgvListCustomers.Columns.Contains("notes_ar"))
                    dgvListCustomers.Columns["notes_ar"].HeaderText = "Notes (Arabic)";

                // Style and format BlacklistStatus column
                if (dgvListCustomers.Columns.Contains("BlacklistStatus"))
                {
                    dgvListCustomers.Columns["BlacklistStatus"].HeaderText = "Blacklist Status";
                    dgvListCustomers.Columns["BlacklistStatus"].Width = 100;
                    dgvListCustomers.Columns["BlacklistStatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvListCustomers.Columns["BlacklistStatus"].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    dgvListCustomers.Columns["BlacklistStatus"].ReadOnly = true;
                }

                if (dgvListCustomers.Columns.Contains("created_at"))
                    dgvListCustomers.Columns["created_at"].HeaderText = "Created At";
                if (dgvListCustomers.Columns.Contains("updated_at"))
                    dgvListCustomers.Columns["updated_at"].HeaderText = "Updated At";

                // Auto resize all columns for better appearance
                dgvListCustomers.AutoResizeColumns();

                // Update total count label
                lblCount.Text = $"Total Customers: {dt.Rows.Count}";

                // Clear any selection by default
                if (dgvListCustomers.Rows.Count > 0)
                    dgvListCustomers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load customers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedCustomerId()
        {
            if (dgvListCustomers.CurrentRow != null)
            {
                object val = dgvListCustomers.CurrentRow.Cells["customer_id"].Value;
                if (val != null && int.TryParse(val.ToString(), out int id))
                {
                    return id;
                }
            }
            return null;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? customerId = GetSelectedCustomerId();
            if (customerId == null)
            {
                MessageBox.Show("Please select a customer to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new frmAddEditCustomer(customerId.Value))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
            LoadCustomers();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? customerId = GetSelectedCustomerId();
            if (customerId == null)
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvListCustomers.CurrentCell = null;
            dgvListCustomers.ClearSelection();
            var confirm = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
               
                bool deleted = ClsCustomer.DeleteCustomer(customerId.Value);
                if (deleted)
                {
                    LoadCustomers();
                }
                else
                {
                    MessageBox.Show("Failed to delete the customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }
        }

        private void detalisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? customerId = GetSelectedCustomerId();
            if (customerId == null)
            {
                MessageBox.Show("Please select a customer first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open the customer details form with the selected ID
            frmCustomerDetalis frmDetails = new frmCustomerDetalis(customerId.Value);
            frmDetails.ShowDialog();
            LoadCustomers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer frmadd = new frmAddEditCustomer();
            frmadd.ShowDialog();
            LoadCustomers();
        }

    }
}
