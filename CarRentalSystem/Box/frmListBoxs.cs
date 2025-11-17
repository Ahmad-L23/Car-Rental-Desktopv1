using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.Box
{
    public partial class frmListBoxs : Form
    {
        private DataTable _boxesTable;

        public frmListBoxs()
        {
            InitializeComponent();
        }

      

        private void LoadBoxs()
        {
            try
            {
                _boxesTable = ClsBox.GetBoxesDataTable();

                dgvboxs.DataSource = _boxesTable;

                // Hide BoxID column if you want (optional)
                if (dgvboxs.Columns["BoxID"] != null)
                    dgvboxs.Columns["BoxID"].Visible = false;

                if (dgvboxs.Columns["Name"] != null)
                    dgvboxs.Columns["Name"].HeaderText = "Box Name";

                // Change from BranchID to BranchName since query returns BranchName
                if (dgvboxs.Columns["BranchName"] != null)
                    dgvboxs.Columns["BranchName"].HeaderText = "Branch";

                if (dgvboxs.Columns["AccountNumber"] != null)
                    dgvboxs.Columns["AccountNumber"].HeaderText = "Account Number";

                if (dgvboxs.Columns["IsActive"] != null)
                    dgvboxs.Columns["IsActive"].HeaderText = "Active";

                if (dgvboxs.Columns["Notes"] != null)
                    dgvboxs.Columns["Notes"].HeaderText = "Notes";

                dgvboxs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvboxs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvboxs.ReadOnly = true;
                dgvboxs.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading boxes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool TryGetCellValueAsInt(DataGridViewRow row, string columnName, out int result)
        {
            result = 0;
            if (row == null)
                return false;

            object value = row.Cells[columnName].Value;
            if (value == DBNull.Value || value == null)
                return false;

            return int.TryParse(value.ToString(), out result);
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            frmAddEditBox frmAddEditBox = new frmAddEditBox();
            frmAddEditBox.ShowDialog();
            LoadBoxs();
        }

        private void frmListBoxs_Load(object sender, EventArgs e)
        {
            LoadBoxs();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvboxs.CurrentRow == null)
            {
                MessageBox.Show("Please select a box to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryGetCellValueAsInt(dgvboxs.CurrentRow, "BoxID", out int boxId))
            {
                MessageBox.Show("Selected box has no valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddEditBox frm = new frmAddEditBox(boxId);
            frm.ShowDialog();

            LoadBoxs();
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvboxs.CurrentRow == null)
            {
                MessageBox.Show("Please select a box to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryGetCellValueAsInt(dgvboxs.CurrentRow, "BoxID", out int boxId))
            {
                MessageBox.Show("Selected box has no valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string boxName = dgvboxs.CurrentRow.Cells["Name"].Value?.ToString() ?? "Unknown";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete box '{boxName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool isDeleted = ClsBox.DeleteBox(boxId);

                if (isDeleted)
                {
                    MessageBox.Show("Box deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBoxs();
                }
                else
                {
                    MessageBox.Show("Failed to delete box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvboxs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmListBoxs_Load_1(object sender, EventArgs e)
        {
            LoadBoxs();
        }
    }
}


  