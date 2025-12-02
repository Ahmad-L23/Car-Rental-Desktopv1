using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.RentalInsurance
{
    public partial class ListRentalInsuranceCtrl : UserControl
    {
        private DataTable _insuranceRentalTable;
        public ListRentalInsuranceCtrl()
        {
            InitializeComponent();

        }


        void setupDataGridViewColmuns()
        {
            dgvRentalInsurance.AutoGenerateColumns = false;
            dgvRentalInsurance.Rows.Clear();

            dgvRentalInsurance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "RentalinsuranceId",
                Visible = false

            });

            dgvRentalInsurance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name"
            });

            dgvRentalInsurance.Columns.Add(new DataGridViewTextBoxColumn

            {
                Name = "MethodName",
                HeaderText = "Payment Method",
                DataPropertyName= "MethodName"

            });

            dgvRentalInsurance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price",
                DataPropertyName = "Price"

            });

            dgvRentalInsurance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Satus",
                HeaderText = "Status",
                DataPropertyName = "Status"
            });

            dgvRentalInsurance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Active",
                HeaderText = "Active",
                DataPropertyName = "isActice"
            });

            dgvRentalInsurance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IncludeTax",
                HeaderText = "Include Tax",
                DataPropertyName = "Includetax"
            });

            dgvRentalInsurance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Notes",
                HeaderText = "Notes",
                DataPropertyName = "Notes"

            });

        }
        public void LoadRentalInsurance()
        {
            try
            {
                _insuranceRentalTable = clsRentalInsurance.GetAllRentalInsurance();
                dgvRentalInsurance.DataSource = _insuranceRentalTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Rental Insurance types:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListRentalInsuranceCtrl_Load(object sender, EventArgs e)
        {
            setupDataGridViewColmuns();
            LoadRentalInsurance();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvRentalInsurance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32 (dgvRentalInsurance.SelectedRows[0].Cells["id"].Value);

            using (frmAddUpdateRentalInsuranc frm = new frmAddUpdateRentalInsuranc(id))
            {
                frm.ShowDialog();
                LoadRentalInsurance();
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvRentalInsurance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pleas Select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvRentalInsurance.SelectedRows[0].Cells["id"].Value);

            string name = dgvRentalInsurance.SelectedRows [0].Cells["Name"].Value.ToString();

            var confirmation = MessageBox.Show($"Dlete Rental Insurance {name}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(confirmation == DialogResult.Yes)
            {
                if(clsRentalInsurance.DeleteRentalInsurance(id))
                {
                    MessageBox.Show($"Rental Insurance {name} Deleted Successfully");
                    LoadRentalInsurance() ;
                }
                else
                {
                    MessageBox.Show($"Something went wrong while deleting rental insurance {name}");
                }
            }
        }

        private void BtnAddMaintenanceType_Click(object sender, EventArgs e)
        {
            using(frmAddUpdateRentalInsuranc frm = new frmAddUpdateRentalInsuranc())
            {
                frm.ShowDialog();
                LoadRentalInsurance();
            }
        }

        private void dgvRentalInsurance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRentalInsurance.Columns[e.ColumnIndex].Name == "Active" && e.Value != null || (dgvRentalInsurance.Columns[e.ColumnIndex].Name == "IncludeTax" && e.Value != null))
            {
                bool isActive;
                if (bool.TryParse(e.Value.ToString(), out isActive))
                {
                    e.Value = isActive ? "✔" : "❌";
                    e.CellStyle.ForeColor = isActive ? Color.Green : Color.Red;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Make font bigger for this cell
                    e.CellStyle.Font = new Font(dgvRentalInsurance.Font.FontFamily, 14, FontStyle.Bold);
                }

                bool IncludeTax;
                if (bool.TryParse(e.Value.ToString(), out IncludeTax))
                {
                    e.Value = IncludeTax ? "✔" : "❌";
                    e.CellStyle.ForeColor = IncludeTax ? Color.Green : Color.Red;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Make font bigger for this cell
                    e.CellStyle.Font = new Font(dgvRentalInsurance.Font.FontFamily, 14, FontStyle.Bold);
                }
            }
        }
    }
}
