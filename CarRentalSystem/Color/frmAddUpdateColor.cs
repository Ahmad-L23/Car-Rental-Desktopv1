using CarRentalBusiness;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem
{
    public partial class frmAddUpdateColor : Form
    {
        private int? colorId;
        private ClsColor currentColor;

        public frmAddUpdateColor(int? colorId = null)
        {
            InitializeComponent();

            this.colorId = colorId;

            if (colorId.HasValue)
            {
                LoadColor(colorId.Value);
                btnSave.Text = "Save";
                this.Text = "Edit Color";
                llSetColor.Text = "Update Color";
            }
            else
            {
                currentColor = new ClsColor();
                btnSave.Text = "Add";
                this.Text = "Add New Color";
                panelColorPreview.BackColor = SystemColors.Control; 

            }
        }

        private void LoadColor(int id)
        {
            currentColor = ClsColor.FindById(id);

            if (currentColor == null)
            {
                MessageBox.Show("Color not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                panelColorPreview.BackColor = ColorTranslator.FromHtml(currentColor.ColorHex);
            }
            catch
            {
                panelColorPreview.BackColor = SystemColors.Control;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save the color values behind the scenes (using panelColorPreview.BackColor)
            string hex = ColorToHex(panelColorPreview.BackColor);

            if (string.IsNullOrEmpty(hex) || hex == "#FFFFFF" || hex == "#000000")
            {
                // Optional: warn if no color or default white/black selected
                var res = MessageBox.Show("You selected white or black. Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;
            }

            currentColor.ColorHex = hex;
            currentColor.ColorName = panelColorPreview.BackColor.IsKnownColor
    ? panelColorPreview.BackColor.Name
    : "";  // Empty if not known named color

            bool saved = currentColor.Save();

            if (saved)
            {
                MessageBox.Show("Color saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save color.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ColorToHex(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    panelColorPreview.BackColor = dlg.Color;
                }
            }
        }
    }
}
