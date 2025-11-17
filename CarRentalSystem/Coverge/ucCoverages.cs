using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.Coverge
{
    public partial class ucCoverages : UserControl
    {
        private DataTable coveragesTable;

        public ucCoverages()
        {
            InitializeComponent();
        }

        private void ucCoverages_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCoverages();
        }

        private void SetupDataGridView()
        {
            dgvCoverage.AutoGenerateColumns = false;
            dgvCoverage.Columns.Clear();

            dgvCoverage.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvCoverage.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        public void LoadCoverages()
        {
            try
            {
                coveragesTable = ClsCoverage.GetAll();
                dgvCoverage.DataSource = coveragesTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading coverages: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddCoverage_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAddUpdateCoverge(null);
            frmAdd.ShowDialog();
            
            LoadCoverages();
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCoverage.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvCoverage.SelectedRows[0].Cells["id"].Value);

            var frmEdit = new frmAddUpdateCoverge(id);
            frmEdit.ShowDialog();
            
            LoadCoverages();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCoverage.SelectedRows.Count == 0) return;

            int coverageId = Convert.ToInt32(dgvCoverage.SelectedRows[0].Cells["id"].Value);
            string coverageName = dgvCoverage.SelectedRows[0].Cells["Name"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the coverage '{coverageName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (ClsCoverage.Delete(coverageId))
                    {
                        MessageBox.Show("Coverage deleted successfully.", "Done",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCoverages();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete coverage.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCoverage_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvCoverage.ClearSelection();
                dgvCoverage.Rows[e.RowIndex].Selected = true;
                dgvCoverage.CurrentCell = dgvCoverage.Rows[e.RowIndex].Cells[1];
            }
        }
    }
}
