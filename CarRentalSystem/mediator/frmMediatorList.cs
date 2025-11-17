using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.mediator
{
    public partial class frmMediatorList : Form
    {
        public frmMediatorList()
        {
            InitializeComponent();
            LoadMediators();
        }

        private void LoadMediators()
        {
            try
            {
                DataTable dt = ClsMediator.GetAllMediators();

                if(dt == null)
                {
                    lblCount.Text = "Therث are no data";
                }
                // Add Status column with 'X' for inactive mediators
                if (!dt.Columns.Contains("Status"))
                    dt.Columns.Add("Status", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    bool isActive = false;
                    if (dt.Columns.Contains("is_active") && row["is_active"] != DBNull.Value)
                        isActive = Convert.ToBoolean(row["is_active"]);

                    row["Status"] = isActive ? "" : "X";
                }

                dgvMediators.DataSource = dt;

                lblCount.Text = $"Total Mediators: {dt.Rows.Count}";

                // Hide technical columns
                if (dgvMediators.Columns.Contains("mediator_id"))
                    dgvMediators.Columns["mediator_id"].Visible = false;
                if (dgvMediators.Columns.Contains("is_active"))
                    dgvMediators.Columns["is_active"].Visible = false;

                // Customize column headers
                if (dgvMediators.Columns.Contains("mediator_name_ar"))
                    dgvMediators.Columns["mediator_name_ar"].HeaderText = "Arabic Name";
                if (dgvMediators.Columns.Contains("mediator_name_en"))
                    dgvMediators.Columns["mediator_name_en"].HeaderText = "English Name";
                if (dgvMediators.Columns.Contains("email_address"))
                    dgvMediators.Columns["email_address"].HeaderText = "Email Address";
                if (dgvMediators.Columns.Contains("percentage"))
                {
                    dgvMediators.Columns["percentage"].HeaderText = "Percentage (%)";
                    dgvMediators.Columns["percentage"].DefaultCellStyle.Format = "N2"; // 2 decimal places
                    dgvMediators.Columns["percentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvMediators.Columns.Contains("phone_number"))
                    dgvMediators.Columns["phone_number"].HeaderText = "Phone Number";

                if (dgvMediators.Columns.Contains("Status"))
                {
                    dgvMediators.Columns["Status"].HeaderText = "Status";
                    dgvMediators.Columns["Status"].Width = 50;
                    dgvMediators.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvMediators.Columns["Status"].DefaultCellStyle.ForeColor = Color.Red;
                    dgvMediators.Columns["Status"].ReadOnly = true;
                }

                dgvMediators.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load mediators: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedMediatorId()
        {
            if (dgvMediators.SelectedRows.Count == 0)
                return null;

            DataRowView drv = dgvMediators.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv == null)
                return null;

            if (drv["mediator_id"] == DBNull.Value)
                return null;

            return Convert.ToInt32(drv["mediator_id"]);
        }

        
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int? mediatorId = GetSelectedMediatorId();
            if (mediatorId == null)
            {
                MessageBox.Show("Please select a mediator to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvMediators.CurrentCell = null;
            dgvMediators.ClearSelection();
            var confirm = MessageBox.Show("Are you sure you want to delete the selected mediator?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool deleted = ClsMediator.DeleteMediator(mediatorId.Value);
                if (deleted)
                {
                    MessageBox.Show("Mediator deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMediators();
                }
                else
                {
                    MessageBox.Show("Failed to delete mediator, cause there is Customer related to him.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int? mediatorId = GetSelectedMediatorId();
            if (mediatorId == null)
            {
                MessageBox.Show("Please select a mediator to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new frmAddUpdateMeditor(mediatorId.Value))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadMediators(); // Refresh list after update
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateMeditor frmAddUpdateMeditor = new frmAddUpdateMeditor();
            frmAddUpdateMeditor.ShowDialog();
            LoadMediators();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.Trim().Replace("'", "''"); // escape single quotes if any

            if (dgvMediators.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;

                if (string.IsNullOrEmpty(filterText))
                {
                    dv.RowFilter = ""; // show all if search box is empty
                }
                else
                {
                    // Assuming column names are mediator_name_en and mediator_name_ar
                    dv.RowFilter = $"mediator_name_en LIKE '%{filterText}%' OR mediator_name_ar LIKE '%{filterText}%'";
                }

                lblCount.Text = $"Total Mediators: {dv.Count}";
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int? mediatorId = GetSelectedMediatorId();
            if (mediatorId == null)
            {
                MessageBox.Show("Please select a mediator to view details.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new frmMediatorDetalis(mediatorId.Value);
            frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
