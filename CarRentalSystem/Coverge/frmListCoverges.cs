using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.Coverge
{
    public partial class frmListCoverges : Form
    {
        private DataTable covergesTable;

        public frmListCoverges()
        {
            InitializeComponent();

        }

        private void SetupDataGridView()
        {
            dgvCoverge.AutoGenerateColumns = false;
            dgvCoverge.Columns.Clear();

            // Hidden ID column
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "CovergeID",
                Visible = false
            };
            dgvCoverge.Columns.Add(colId);

            // Name column
            var colName = new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvCoverge.Columns.Add(colName);
        }

        private void LoadCoverges()
        {
            try
            {
                covergesTable = ClsCoverage.GetAll();

                dgvCoverge.Rows.Clear();

                foreach (DataRow row in covergesTable.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string name = row["Name"].ToString();

                    dgvCoverge.Rows.Add(id, name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading coverges: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmListCoverges_Load_1(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCoverges();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvCoverge.SelectedRows.Count == 0) return;

            int covergeId = Convert.ToInt32(dgvCoverge.SelectedRows[0].Cells["id"].Value);

            var frmEdit = new frmAddUpdateCoverge(covergeId);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                LoadCoverges();
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvCoverge.SelectedRows.Count == 0) return;

            int covergeId = Convert.ToInt32(dgvCoverge.SelectedRows[0].Cells["id"].Value);
            string covergeName = dgvCoverge.SelectedRows[0].Cells["Name"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the coverge '{covergeName}'?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClsCoverage.Delete(covergeId);
                    if (deleted)
                    {
                        MessageBox.Show("Coverge deleted successfully.", "Done",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCoverges();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the coverge.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during deletion: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAddTargetClient_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAddUpdateCoverge(null);
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                LoadCoverges();
            }
            LoadCoverges();
        }

        private void dgvCoverge_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvCoverge.ClearSelection();
                dgvCoverge.Rows[e.RowIndex].Selected = true;
                dgvCoverge.CurrentCell = dgvCoverge.Rows[e.RowIndex].Cells[1];
            }
        }
    }
}
