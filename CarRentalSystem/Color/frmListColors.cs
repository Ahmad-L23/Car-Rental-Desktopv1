using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem
{
    public partial class frmListColors : Form
    {
        private Panel currentSelectedPanel = null;
        private ToolTip colorNameToolTip = new ToolTip();  // Tooltip instance

        public frmListColors()
        {
            InitializeComponent();

            // Set FlowLayoutPanel wrap and size to ensure 4 colors per row
            flowLayoutPanelColors.WrapContents = true;
            flowLayoutPanelColors.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelColors.Padding = new Padding(10);
        }

        private void frmListColors_Load(object sender, EventArgs e)
        {
            LoadColors();
        }

        private void LoadColors()
        {
            flowLayoutPanelColors.Controls.Clear();
            currentSelectedPanel = null;

            DataTable colorsTable = ClsColor.GetAllColors();

            int totalWidth = flowLayoutPanelColors.ClientSize.Width;
            int containerWidth = (totalWidth - flowLayoutPanelColors.Padding.Left - flowLayoutPanelColors.Padding.Right - (8 * 3)) / 4;
            containerWidth = Math.Min(containerWidth, 100);  // widen a bit to fit buttons nicely
            int containerHeight = containerWidth + 60; // enough height for color, label, buttons

            foreach (DataRow row in colorsTable.Rows)
            {
                int colorId = Convert.ToInt32(row["Id"]);
                string colorHex = row["ColorHex"].ToString();
                string colorName = row["ColorName"].ToString();

                // Container panel for everything
                Panel container = new Panel()
                {
                    Width = containerWidth,
                    Height = containerHeight,
                    Margin = new Padding(4),
                    Tag = colorId,
                    Cursor = Cursors.Default,
                    BackColor = Color.Transparent
                };

                // Color square
                Panel colorPanel = new Panel()
                {
                    Width = containerWidth - 20,
                    Height = containerWidth - 20,
                    BackColor = ColorTranslator.FromHtml(colorHex),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(10, 5)
                };

                // Color name label with AutoEllipsis and tooltip
                if (string.IsNullOrWhiteSpace(colorName))
                {
                    colorName = "No Color Name";
                }
                Label lblName = new Label()
                {
                    Text = colorName,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Width = containerWidth,
                    Height = 20,
                    Location = new Point(0, colorPanel.Bottom + 2),
                    ForeColor = Color.Black,
                    AutoEllipsis = true  // Enable "..." when text too long
                };
                // Set the tooltip for full color name
                colorNameToolTip.SetToolTip(lblName, colorName);

                // Edit button
                Button btnEdit = new Button()
                {
                    Text = "Edit",
                    Width = (containerWidth / 2) - 3,
                    Height = 25,
                    Location = new Point(0, lblName.Bottom + 2),
                    Tag = colorId
                };
                btnEdit.Click += BtnEdit_Click;

                // Delete button
                Button btnDelete = new Button()
                {
                    Text = "Delete",
                    Width = (containerWidth / 2) - 3,
                    Height = 25,
                    Location = new Point(btnEdit.Right + 5, lblName.Bottom + 2),
                    Tag = colorId
                };
                btnDelete.Click += BtnDelete_Click;

                container.Controls.Add(colorPanel);
                container.Controls.Add(lblName);
                container.Controls.Add(btnEdit);
                container.Controls.Add(btnDelete);

                flowLayoutPanelColors.Controls.Add(container);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                int colorId = (int)btn.Tag;
                ClsColor color = ClsColor.FindById(colorId);
                if (color == null)
                {
                    MessageBox.Show("Color not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var frm = new frmAddUpdateColor(color.Id))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadColors();
                    }
                }
            }
            LoadColors();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                int colorId = (int)btn.Tag;
                ClsColor color = ClsColor.FindById(colorId);
                if (color == null)
                {
                    MessageBox.Show("Color not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Are you sure you want to delete this color ({color.ColorHex})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool deleted = ClsColor.DeleteColor(colorId);
                    if (deleted)
                    {
                        MessageBox.Show("Color deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadColors();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete color.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            Panel containerPanel = null;

            if (sender is Control ctrl)
            {
                // Find the container panel (parent of clicked control)
                if (ctrl.Parent is Panel parent && flowLayoutPanelColors.Controls.Contains(parent))
                    containerPanel = parent;
                else if (ctrl is Panel pnl && flowLayoutPanelColors.Controls.Contains(pnl))
                    containerPanel = pnl;
            }

            if (containerPanel != null)
            {
                currentSelectedPanel = containerPanel;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateColor frm = new frmAddUpdateColor();    
            frm.ShowDialog();
            LoadColors();
        }
    }
}
