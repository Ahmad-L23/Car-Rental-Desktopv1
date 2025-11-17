using CarRentalBusiness;
using CarRentalSystem.DamageMaintenance;
using CarRentalSystem.Setting;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.DamagesMaintenance
{
    public partial class frmListDamageMaintenance : Form
    {
        private DataTable damageMaintenanceTable;

        public frmListDamageMaintenance()
        {
            InitializeComponent();

            // Form Load event
            this.Load += FrmListDamageMaintenance_Load;

        }

        private void FrmListDamageMaintenance_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadDamageMaintenance();
        }

        private void SetupDataGridView()
        {
            dgvDamaManten.AutoGenerateColumns = false;
            dgvDamaManten.Columns.Clear();

            // Add columns - adjust names and headers as needed

            // DamageID (hidden)
            dgvDamaManten.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DamageID",
                DataPropertyName = "DamageID",
                Visible = false
            });

            dgvDamaManten.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PlateNumber",
                HeaderText = "Plate Nmuber",
                DataPropertyName = "PlateNumber",
                
            });

            // Damage Date
            dgvDamaManten.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DamageDate",
                HeaderText = "Damage Date",
                DataPropertyName = "DamageDate",
            });

            dgvDamaManten.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "StatusText",
                HeaderText = "Status",
                DataPropertyName = "StatusText",  // <-- Correct!
            });


            // Engine Number
            dgvDamaManten.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EngineNumber",
                HeaderText = "Engine Number",
                DataPropertyName = "EngineNumber",
            });

            // Engine Size
            dgvDamaManten.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EngineSize",
                HeaderText = "Engine Size",
                DataPropertyName = "EngineSize",
            });

            // Chassis Number
            dgvDamaManten.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ChassisNumber",
                HeaderText = "Chassis Number",
                DataPropertyName = "ChassisNumber",
            });

            dgvDamaManten.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Description",
                HeaderText = "Description",
                DataPropertyName = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDamaManten.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        private void LoadDamageMaintenance()
        {
            try
            {
                // افترض أن لديك طريقة جاهزة لجلب بيانات الصيانة مع اسم السيارة وحالة مفهومة
                damageMaintenanceTable = ClsDamageMaintenance.GetDamagesWithCarInfo();

                // أضف عمود لحالة نصية بناءً على القيمة الرقمية للحالة
                if (!damageMaintenanceTable.Columns.Contains("StatusText"))
                    damageMaintenanceTable.Columns.Add("StatusText", typeof(string));

                foreach (DataRow row in damageMaintenanceTable.Rows)
                {
                    int status = Convert.ToInt32(row["Status"]);
                    string statusText = "Unknown";

                    switch (status)
                    {
                        case 0:
                            statusText = "Pending";
                            break;
                        case 1:
                            statusText = "In Progress";
                            break;
                        case 2:
                            statusText = "Completed";
                            break;
                    }

                    row["StatusText"] = statusText;
                }

                dgvDamaManten.DataSource = damageMaintenanceTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading damage maintenance records: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Enable row selection on right click to show context menu
        private void dgvDamaManten_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvDamaManten.ClearSelection();
                dgvDamaManten.Rows[e.RowIndex].Selected = true;
                dgvDamaManten.CurrentCell = dgvDamaManten.Rows[e.RowIndex].Cells[1];
            }
        }
        

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvDamaManten.SelectedRows.Count == 0) return;

            int damageId = Convert.ToInt32(dgvDamaManten.SelectedRows[0].Cells["DamageID"].Value);

            var frmEdit = new frmAddEditDamageMaintenance(damageId);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                LoadDamageMaintenance();
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvDamaManten.SelectedRows.Count == 0) return;

            int damageId = Convert.ToInt32(dgvDamaManten.SelectedRows[0].Cells["DamageID"].Value);

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this damage maintenance record?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClsDamageMaintenance.Delete(damageId);
                    if (deleted)
                    {
                        MessageBox.Show("Record deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDamageMaintenance();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during deletion: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddCDamagemain_Click_1(object sender, EventArgs e)
        {
            var frmAdd = new frmAddEditDamageMaintenance(null); 
            frmAdd.ShowDialog();
            
                LoadDamageMaintenance();
            
        }

        private void btnAllDamages_Click(object sender, EventArgs e)
        {
            frmDamageMainCard frm = new frmDamageMainCard();
            frm.ShowDialog();
        }
    }
}
