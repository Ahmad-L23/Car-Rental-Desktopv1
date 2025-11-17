using CarRentalBusiness;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalSystem.CompanyInsurance
{
    public partial class frmListCompanyInsurances : Form
    {
        private DataTable companyInsuranceTable;

        // Pagination fields
        private int pageSize = 10;
        private int currentPage = 1;
        private int totalPages = 1;

        public frmListCompanyInsurances()
        {
            InitializeComponent();

        }

        private void frmListCompanyInsurances_Load_1(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCompanyInsurances();
        }

        private void SetupDataGridView()
        {
            dgvCompanyInsurance.AutoGenerateColumns = false;
            dgvCompanyInsurance.Columns.Clear();

          
            // Hidden ID column
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "CompanyInsuranceID",
                DataPropertyName = "CompanyInsuranceID",
                Visible = false
            };
            dgvCompanyInsurance.Columns.Add(colId);

            // Company Name column
            var colCompanyName = new DataGridViewTextBoxColumn
            {
                Name = "InsuranceCompanyName",
                HeaderText = "Company Name",
                DataPropertyName = "InsuranceCompanyName",
            };
            dgvCompanyInsurance.Columns.Add(colCompanyName);

            // Phone column
            var colPhone = new DataGridViewTextBoxColumn
            {
                Name = "Phone",
                HeaderText = "Phone",
                DataPropertyName = "Phone",
                Width = 120
            };
            dgvCompanyInsurance.Columns.Add(colPhone);

            // Email column
            var colEmail = new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 150
            };
            dgvCompanyInsurance.Columns.Add(colEmail);

            // Insurance Type Name column
            var colInsuranceTypeName = new DataGridViewTextBoxColumn
            {
                Name = "InsuranceTypeName",
                HeaderText = "Insurance Type",
                DataPropertyName = "InsuranceTypeName",
                Width = 150
            };
            dgvCompanyInsurance.Columns.Add(colInsuranceTypeName);

            // IsActive checkbox column
            var colIsActive = new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Active",
                DataPropertyName = "IsActive",
                Width = 60
            };
            dgvCompanyInsurance.Columns.Add(colIsActive);
        }

        
        private void LoadCompanyInsurances()
        {
            try
            {
                companyInsuranceTable = ClsCompanyInsurance.GetAllCompanyInsurancesWithTypeName();

                ApplyFilterAndPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading company insurances: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilterAndPaging()
        {
            if (companyInsuranceTable == null)
                return;

            string filterText = txtcmpinsuraName.Text.Trim();

            // Filter rows by InsuranceCompanyName containing filterText (case-insensitive)
            var filteredRows = string.IsNullOrEmpty(filterText)
                ? companyInsuranceTable.AsEnumerable()
                : companyInsuranceTable.AsEnumerable()
                    .Where(row => row.Field<string>("InsuranceCompanyName") != null &&
                                  row.Field<string>("InsuranceCompanyName").IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0);

            // Calculate pagination
            int rowCount = filteredRows.Count();
            totalPages = (int)Math.Ceiling(rowCount / (double)pageSize);

            // Clamp currentPage
            if (currentPage > totalPages)
                currentPage = totalPages;
            if (currentPage < 1)
                currentPage = 1;

            // Get current page data
            var rowsToShow = filteredRows
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize);

            // Clear and add rows to grid
            dgvCompanyInsurance.Rows.Clear();

            foreach (var row in rowsToShow)
            {
                AddRowToGrid(row);
            }

            UpdatePaginationControls();
        }

        private void AddRowToGrid(DataRow row)
        {
            int id = Convert.ToInt32(row["CompanyInsuranceID"]);
            string companyName = row["InsuranceCompanyName"]?.ToString() ?? "";
            string phone = row["Phone"]?.ToString() ?? "";
            string email = row["Email"]?.ToString() ?? "";
            string insuranceTypeName = row["InsuranceTypeName"]?.ToString() ?? "";
            bool isActive = Convert.ToBoolean(row["IsActive"]);

            dgvCompanyInsurance.Rows.Add(id, companyName, phone, email, insuranceTypeName, isActive);
        }

        private void UpdatePaginationControls()
        {
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";

            btnFirst.Enabled = currentPage > 1;
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnLast.Enabled = currentPage < totalPages;
        }

        // Pagination button handlers
        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            ApplyFilterAndPaging();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ApplyFilterAndPaging();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                ApplyFilterAndPaging();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            ApplyFilterAndPaging();
        }

        // Search box text changed
        private void txtcmpinsuraName_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1; // reset to first page when filtering
            ApplyFilterAndPaging();
        }

        // The rest of your edit/delete/add code remains the same, just use LoadCompanyInsurances() or ApplyFilterAndPaging() to reload data as needed
        // For example:
        private void btnAddCmpInsur_Click(object sender, EventArgs e)
        {
            frmAddEditCompanyInsurance frm = new frmAddEditCompanyInsurance();
            frm.ShowDialog();
            LoadCompanyInsurances();
            
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvCompanyInsurance.SelectedRows.Count == 0)
                return;

            var cellValue = dgvCompanyInsurance.SelectedRows[0].Cells["CompanyInsuranceID"].Value;
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int id) || id <= 0)
            {
                MessageBox.Show("Please select a valid company insurance record.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frmEdit = new frmAddEditCompanyInsurance(id);
            frmEdit.ShowDialog();            
            LoadCompanyInsurances();
            
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvCompanyInsurance.SelectedRows.Count == 0)
                return;

            var cellValue = dgvCompanyInsurance.SelectedRows[0].Cells["CompanyInsuranceID"].Value;
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int id) || id <= 0)
            {
                MessageBox.Show("Please select a valid company insurance record.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string companyName = dgvCompanyInsurance.SelectedRows[0].Cells["InsuranceCompanyName"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the company insurance '{companyName}'?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClsCompanyInsurance.DeleteCompanyInsurance(id);
                    if (deleted)
                    {
                        MessageBox.Show("Company insurance deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCompanyInsurances();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the company insurance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during deletion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCompanyInsurance_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvCompanyInsurance.ClearSelection();
                dgvCompanyInsurance.Rows[e.RowIndex].Selected = true;
                dgvCompanyInsurance.CurrentCell = dgvCompanyInsurance.Rows[e.RowIndex].Cells[1];
            }
        }
    }
}
