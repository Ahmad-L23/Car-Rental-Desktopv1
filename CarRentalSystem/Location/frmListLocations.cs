using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.Location
{
    public partial class frmListLocations : Form
    {
        private DataTable allLocations;

        public frmListLocations()
        {
            InitializeComponent();
            LoadLocations();

        }

        private void FrmListLocations_Load(object sender, EventArgs e)
        {
            LoadLocations();
        }

        private void LoadLocations()
        {
            allLocations = ClsLocation.GetLocationsDataTable();
            dgvLocations.DataSource = allLocations;

            // Set friendly column headers
            if (dgvLocations.Columns.Contains("location_id"))
                dgvLocations.Columns["location_id"].HeaderText = "ID";

            if (dgvLocations.Columns.Contains("location_name"))
                dgvLocations.Columns["location_name"].HeaderText = "Location Name";

            if (dgvLocations.Columns.Contains("branch_id"))
                dgvLocations.Columns["branch_id"].HeaderText = "Branch ID";

            if (dgvLocations.Columns.Contains("branch_name"))
                dgvLocations.Columns["branch_name"].HeaderText = "Branch Name";

            // Adjust columns width nicely
            dgvLocations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocations.AutoResizeColumns();
        }

        /// <summary>
        /// Attempts to get the location_id of the selected row in the DataGridView.
        /// Shows a message box if no row is selected.
        /// </summary>
        private bool TryGetSelectedLocationId(out int locationId)
        {
            locationId = -1;

            if (dgvLocations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a location first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                locationId = Convert.ToInt32(dgvLocations.SelectedRows[0].Cells["location_id"].Value);
                return true;
            }
            catch
            {
                MessageBox.Show("Failed to retrieve the selected location ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            frmAddEditLocation frmadd = new frmAddEditLocation();
            frmadd.ShowDialog();
            LoadLocations();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (allLocations == null)
                return;

            string filterText = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(filterText))
            {
                dgvLocations.DataSource = allLocations;
            }
            else
            {
                var dv = new DataView(allLocations);
                dv.RowFilter = $"location_name LIKE '%{filterText}%'";
                dgvLocations.DataSource = dv;
            }
        }

        private void dgvLocations_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvLocations.ClearSelection();
                dgvLocations.Rows[e.RowIndex].Selected = true;
                dgvLocations.CurrentCell = dgvLocations.Rows[e.RowIndex].Cells[0];
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!TryGetSelectedLocationId(out int locationId))
                return;

            string locationName = dgvLocations.SelectedRows[0].Cells["location_name"].Value.ToString();

            var result = MessageBox.Show(
                $"Are you sure you want to delete location '{locationName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            dgvLocations.CurrentCell = null;
            dgvLocations.ClearSelection();
            if (result == DialogResult.Yes)
            {
                bool deleted = ClsLocation.DeleteLocation(locationId);
                if (deleted)
                {
                    MessageBox.Show("Location deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLocations();
                }
                else
                {
                    MessageBox.Show("Failed to delete location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!TryGetSelectedLocationId(out int locationId))
                return;

            using (frmAddEditLocation editForm = new frmAddEditLocation(locationId))
            {
                var result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadLocations(); // Refresh the list after editing
                }
            }
        }

        private void frmListLocations_Load_1(object sender, EventArgs e)
        {

        }
    }
}
