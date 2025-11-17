using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.Group
{
    public partial class frmListgroups : Form
    {
        public frmListgroups()
        {
            InitializeComponent();
            
        }

      
        private void SetupDataGridView()
        {
            dgvGroups.AllowUserToAddRows = false;
            dgvGroups.AllowUserToDeleteRows = false;
            dgvGroups.ReadOnly = true;
            dgvGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGroups.MultiSelect = false;

            dgvGroups.Columns.Clear();

            // Hidden ID column
            var colGroupId = new DataGridViewTextBoxColumn
            {
                Name = "colGroupId",
                HeaderText = "Group ID",
                DataPropertyName = "GroupID",
                Visible = false
            };
            dgvGroups.Columns.Add(colGroupId);

            // Name column
            var colGroupName = new DataGridViewTextBoxColumn
            {
                Name = "colGroupName",
                HeaderText = "Group Name",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvGroups.Columns.Add(colGroupName);

            // Image column
            var colGroupImage = new DataGridViewImageColumn
            {
                Name = "colGroupImage",
                HeaderText = "Image",
                DataPropertyName = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 100
            };
            dgvGroups.Columns.Add(colGroupImage);

            dgvGroups.CellMouseDown += dgvGroups_CellMouseDown;
        }

        

        private void SetupContextMenu()
        {
            

            var tsmiEdit = new ToolStripMenuItem("Edit");
            tsmiEdit.Click += tsmiEdit_Click;
            contextMenuStrip1.Items.Add(tsmiEdit);

            var tsmiDelete = new ToolStripMenuItem("Delete");
            tsmiDelete.Click += tsmiDelete_Click;
            contextMenuStrip1.Items.Add(tsmiDelete);

            dgvGroups.ContextMenuStrip = contextMenuStrip1;
        }

        private void LoadGroups()
        {
            DataTable dt = ClsGroup.GetGroupsDataTable();

            dgvGroups.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["GroupID"]);
                string name = row["Name"].ToString();
                Image image = null;

                try
                {
                    string imgPath = row["Image"].ToString();
                    if (!string.IsNullOrEmpty(imgPath) && System.IO.File.Exists(imgPath))
                        image = Image.FromFile(imgPath);
                }
                catch
                {
                    image = null;
                }

                dgvGroups.Rows.Add(id, name, image);
            }
        }

       

        private void dgvGroups_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Select row on right-click before showing context menu
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvGroups.ClearSelection();
                dgvGroups.Rows[e.RowIndex].Selected = true;
                dgvGroups.CurrentCell = dgvGroups.Rows[e.RowIndex].Cells[1]; // focus on name cell
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count == 0) return;

            int groupId = Convert.ToInt32(dgvGroups.SelectedRows[0].Cells["colGroupId"].Value);

            using (var frmEdit = new frmAddEditGroup(groupId)) // Edit mode
            {

                dgvGroups.ClearSelection();
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    LoadGroups();
                }
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count == 0) return;

            int groupId = Convert.ToInt32(dgvGroups.SelectedRows[0].Cells["colGroupId"].Value);
            string groupName = dgvGroups.SelectedRows[0].Cells["colGroupName"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the group '{groupName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClsGroup.DeleteGroup(groupId);

                    dgvGroups.ClearSelection();
                    if (deleted)
                    {
                        MessageBox.Show("Group deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGroups();
                        dgvGroups.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting group: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmListgroups_Load_1(object sender, EventArgs e)
        {
            SetupDataGridView();
            SetupContextMenu();
            LoadGroups();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (var frmAddEdit = new frmAddEditGroup()) // Add new mode (no ID passed)
            {
                if (frmAddEdit.ShowDialog() == DialogResult.OK)
                {
                    LoadGroups();
                }
            }
        }
    }
}
