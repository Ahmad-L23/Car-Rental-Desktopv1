using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
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

                // Add computed "BlacklistStatus" column to display friendly blacklist status if missing
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
                string[] hiddenColumns = { "customer_id", "company_id", "nationality_id", "mediator_id" };
                foreach (var col in hiddenColumns)
                {
                    if (dgvListCustomers.Columns.Contains(col))
                        dgvListCustomers.Columns[col].Visible = false;
                }

                // Rename headers for readability
                var headers = new (string column, string header)[]
                {
                    ("customer_type", "Customer Type"),
                    ("customer_name_en", "Name (English)"),
                    ("customer_name_ar", "Name (Arabic)"),
                    ("phone_number", "Phone Number"),
                    ("email", "Email"),
                    ("address_en", "Address (English)"),
                    ("address_ar", "Address (Arabic)"),
                    ("notes_en", "Notes (English)"),
                    ("notes_ar", "Notes (Arabic)"),
                    ("id_type_en", "ID Type (English)"),
                    ("id_type_ar", "ID Type (Arabic)"),
                    ("id_number", "ID Number"),
                    ("identity_number", "Identity Number"),
                    ("identity_place_of_issue_en", "ID Place of Issue (English)"),
                    ("identity_place_of_issue_ar", "ID Place of Issue (Arabic)"),
                    ("license_number", "License Number"),
                    ("license_category_en", "License Category (English)"),
                    ("license_category_ar", "License Category (Arabic)"),
                    ("license_place_of_issue_en", "License Place of Issue (English)"),
                    ("license_place_of_issue_ar", "License Place of Issue (Arabic)"),
                    ("license_issue_date", "License Issue Date"),
                    ("license_expiry_date", "License Expiry Date"),
                    ("created_at", "Created At"),
                    ("updated_at", "Updated At"),
                };

                foreach (var (column, header) in headers)
                {
                    if (dgvListCustomers.Columns.Contains(column))
                    {
                        dgvListCustomers.Columns[column].HeaderText = header;

                        // Format dates nicely
                        if (column == "license_issue_date" || column == "license_expiry_date" ||
                            column == "created_at" || column == "updated_at")
                        {
                            dgvListCustomers.Columns[column].DefaultCellStyle.Format = "yyyy-MM-dd";
                        }
                    }
                }

                // Style and format BlacklistStatus column with color coding
                if (dgvListCustomers.Columns.Contains("BlacklistStatus"))
                {
                    var col = dgvListCustomers.Columns["BlacklistStatus"];
                    col.HeaderText = "Blacklist Status";
                    col.Width = 110;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.ReadOnly = true;
                    dgvListCustomers.CellFormatting -= DgvListCustomers_CellFormatting; // remove if already attached
                    dgvListCustomers.CellFormatting += DgvListCustomers_CellFormatting;
                }

                // Auto resize columns
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

        private void DgvListCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvListCustomers.Columns[e.ColumnIndex].Name == "BlacklistStatus" && e.Value != null)
            {
                string status = e.Value.ToString().ToLowerInvariant();
                if (status == "blacklisted")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgvListCustomers.Font, FontStyle.Bold);
                }
                else if (status == "active")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new Font(dgvListCustomers.Font, FontStyle.Regular);
                }
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
                    MessageBox.Show("Failed to delete the customer because there is a document related to this customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            using (var frmDetails = new frmCustomerDetalis(customerId.Value))
            {
                frmDetails.ShowDialog();
            }
            LoadCustomers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var frmAdd = new frmAddEditCustomer())
            {
                frmAdd.ShowDialog();
            }
            LoadCustomers();
        }
    }
}
