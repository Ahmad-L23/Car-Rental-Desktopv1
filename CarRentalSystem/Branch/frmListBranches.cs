using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.Branch
{
    public partial class frmListBranches : Form
    {
        private DataTable branchesTable;

        public frmListBranches()
        {
            InitializeComponent();

            this.Load += FrmListBranches_Load;
            btnRefresh.Click += btnRefresh_Click_1;
            txtSearch.TextChanged += txtSearch_TextChanged_1;
        }

        private void FrmListBranches_Load(object sender, EventArgs e)
        {
            LoadBranches();
        }

        private void LoadBranches()
        {
            try
            {
                branchesTable = ClsBranch.GetBranchesDataTable();

                dgvBranches.DataSource = branchesTable;

                // Set friendly column headers
                if (dgvBranches.Columns["branch_id"] != null)
                    dgvBranches.Columns["branch_id"].HeaderText = "Branch ID";

                if (dgvBranches.Columns["name"] != null)
                    dgvBranches.Columns["name"].HeaderText = "Branch Name";

                if (dgvBranches.Columns["tax"] != null)
                {
                    dgvBranches.Columns["tax"].HeaderText = "Tax (%)";
                    dgvBranches.Columns["tax"].DefaultCellStyle.Format = "N2";
                }

                if (dgvBranches.Columns["rate"] != null)
                {
                    dgvBranches.Columns["rate"].HeaderText = "Rate (%)";
                    dgvBranches.Columns["rate"].DefaultCellStyle.Format = "N2";
                }

                txtSearch.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading branches: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadBranches();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (branchesTable == null)
                return;

            string filterText = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(filterText))
            {
                dgvBranches.DataSource = branchesTable;
            }
            else
            {
                string filterExpression = $"name LIKE '%{filterText}%'";
                DataView dv = new DataView(branchesTable) { RowFilter = filterExpression };
                dgvBranches.DataSource = dv;
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
