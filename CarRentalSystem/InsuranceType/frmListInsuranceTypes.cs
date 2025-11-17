using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.InsuranceType
{
    public partial class frmListInsuranceTypes : Form
    {
        public frmListInsuranceTypes()
        {
            InitializeComponent();
            InitializeDgvInsuranceTypes();
            LoadInsuranceTypes();
            
        }

        private void InitializeDgvInsuranceTypes()
        {
            dgvInsuranceTypes.Columns.Clear();

            dgvInsuranceTypes.AutoGenerateColumns = false; // Disable auto generation

            // Hidden ID column
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "colInsuranceTypeID",
                Visible = false
            };
            dgvInsuranceTypes.Columns.Add(colId);

            // Insurance Name
            var colName = new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Insurance Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvInsuranceTypes.Columns.Add(colName);

            // Description
            var colDescription = new DataGridViewTextBoxColumn
            {
                Name = "colDescription",
                HeaderText = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvInsuranceTypes.Columns.Add(colDescription);

            // Active
            var colActive = new DataGridViewCheckBoxColumn
            {
                Name = "colIsActive",
                HeaderText = "Active",
                Width = 60
            };
            dgvInsuranceTypes.Columns.Add(colActive);

            // Created At
            var colCreatedAt = new DataGridViewTextBoxColumn
            {
                Name = "colCreatedAt",
                HeaderText = "Created At",
                Width = 120
            };
            dgvInsuranceTypes.Columns.Add(colCreatedAt);

            // Image column
            var colImage = new DataGridViewImageColumn
            {
                Name = "colImage",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 100
            };
            dgvInsuranceTypes.Columns.Add(colImage);

            dgvInsuranceTypes.RowTemplate.Height = 40;
        }

        private void LoadInsuranceTypes()
        {
            try
            {
                DataTable dt = ClsInsuranceType.GetAllInsuranceTypes();

                dgvInsuranceTypes.Rows.Clear();

                string imagesFolder = System.IO.Path.Combine(Application.StartupPath, "insuranceImages");

                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["InsuranceTypeID"]);
                    string name = row["Name"].ToString();
                    string description = row["Description"].ToString();
                    bool isActive = Convert.ToBoolean(row["IsActive"]);
                    string createdAt = Convert.ToDateTime(row["CreatedAt"]).ToString("yyyy-MM-dd");
                    Image image = null;

                    try
                    {
                        string relativeImagePath = row["InsuranceImage"].ToString();
                        if (!string.IsNullOrEmpty(relativeImagePath))
                        {
                            string fullImagePath = System.IO.Path.Combine(imagesFolder, relativeImagePath);
                            if (System.IO.File.Exists(fullImagePath))
                            {
                                using (var bmpTemp = new Bitmap(fullImagePath))
                                {
                                    image = new Bitmap(bmpTemp);
                                }
                            }
                        }
                    }
                    catch
                    {
                        image = null;
                    }

                    dgvInsuranceTypes.Rows.Add(id, name, description, isActive, createdAt, image);
                }

                dgvInsuranceTypes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load insurance types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int _rightClickedRowIndex = -1;

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_rightClickedRowIndex < 0) return;

            DataGridViewRow selectedRow = dgvInsuranceTypes.Rows[_rightClickedRowIndex];
            if (selectedRow == null) return;

           
            if (selectedRow.Cells["colInsuranceTypeID"].Value is int id)
            {
                using (var frm = new frmAddUpdateInsuranceType(id))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadInsuranceTypes();
                    }
                }
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_rightClickedRowIndex < 0) return;

            DataGridViewRow selectedRow = dgvInsuranceTypes.Rows[_rightClickedRowIndex];
            if (selectedRow == null) return;

            if (selectedRow.Cells["colInsuranceTypeID"].Value is int id)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this insurance type?",
                                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        bool deleted = ClsInsuranceType.DeleteInsuranceType(id);
                        if (deleted)
                        {
                            MessageBox.Show("Insurance type deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadInsuranceTypes(); // refresh after delete
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete insurance type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting insurance type: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvInsuranceTypes_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvInsuranceTypes.ClearSelection();
                dgvInsuranceTypes.Rows[e.RowIndex].Selected = true;
                _rightClickedRowIndex = e.RowIndex;

                // Show context menu at mouse position
                var relativeMousePosition = dgvInsuranceTypes.PointToClient(Cursor.Position);
                contextMenuStrip1.Show(dgvInsuranceTypes, relativeMousePosition);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateInsuranceType frmadd = new frmAddUpdateInsuranceType();
            frmadd.ShowDialog();
            LoadInsuranceTypes();
        }
    }
}
