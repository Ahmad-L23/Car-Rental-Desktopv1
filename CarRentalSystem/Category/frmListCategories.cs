using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalSystem.Category
{
    public partial class frmListCategories : Form
    {
        private DataTable categoriesTable;

        public frmListCategories()
        {
            InitializeComponent();

            // Form load event
            this.Load += FrmListCategories_Load;

            // Right-click on row event
            dgvCategory.CellMouseDown += dgvCategory_CellMouseDown;

            // Context menu bindings
            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;

            // Add new button click
            btnAddCategory.Click += BtnAddCategory_Click;
        }

        private void FrmListCategories_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCategories();
        }

        private void SetupDataGridView()
        {
            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.Columns.Clear();

            // Hidden ID column
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "CategoryID",
                DataPropertyName = "CategoryID",
                Visible = false
            };
            dgvCategory.Columns.Add(colId);

            // Name in English column
            var colNameEn = new DataGridViewTextBoxColumn
            {
                Name = "NameEn",
                HeaderText = "Name (English)",
                DataPropertyName = "NameEn",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvCategory.Columns.Add(colNameEn);

            // Name in Arabic column
            var colNameAr = new DataGridViewTextBoxColumn
            {
                Name = "NameAr",
                HeaderText = "Name (Arabic)",
                DataPropertyName = "NameAr",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvCategory.Columns.Add(colNameAr);

            // Image column (not directly bound to data)
            var colImage = new DataGridViewImageColumn
            {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 100
            };
            dgvCategory.Columns.Add(colImage);
        }

        private void LoadCategories()
        {
            try
            {
                categoriesTable = ClsCategory.GetAllCategories();

                // Clear DataGridView rows
                dgvCategory.Rows.Clear();

                // Display categories data with image loaded from path
                foreach (DataRow row in categoriesTable.Rows)
                {
                    int id = Convert.ToInt32(row["CategoryID"]);
                    string nameEn = row["NameEn"].ToString();
                    string nameAr = row["NameAr"].ToString();
                    Image img = null;

                    string imgPath = row["Image"]?.ToString();
                    if (!string.IsNullOrEmpty(imgPath))
                    {
                        string fullPath = Path.Combine(Application.StartupPath, imgPath);
                        if (File.Exists(fullPath))
                        {
                            try
                            {
                                img = Image.FromFile(fullPath);
                            }
                            catch
                            {
                                img = null;
                            }
                        }
                    }

                    dgvCategory.Rows.Add(id, nameEn, nameAr, img);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Enable row selection on right-click (to show context menu)
        private void dgvCategory_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvCategory.ClearSelection();
                dgvCategory.Rows[e.RowIndex].Selected = true;
                dgvCategory.CurrentCell = dgvCategory.Rows[e.RowIndex].Cells[1];
            }

        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAddEditCategory(null); // Open in add new mode (null = new)
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                LoadCategories();
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count == 0) return;

            int categoryId = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["CategoryID"].Value);

            var frmEdit = new frmAddEditCategory(categoryId); // Open in edit mode
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                LoadCategories();
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count == 0) return;

            int categoryId = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["CategoryID"].Value);
            string categoryName = dgvCategory.SelectedRows[0].Cells["NameEn"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the category '{categoryName}'?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClsCategory.DeleteCategory(categoryId);
                    if (deleted)
                    {
                        MessageBox.Show("Category deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during deletion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
