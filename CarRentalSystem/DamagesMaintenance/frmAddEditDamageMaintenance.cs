using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.DamageMaintenance
{
    public enum StatusEnum
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2
    }

    public partial class frmAddEditDamageMaintenance : Form
    {
        private int? _damageId;

        private DataTable dtCars;
        private DataTable dtEmployees;

        public delegate void DamageSavedHandler(int damageId);
        public event DamageSavedHandler DamageSaved;

        public frmAddEditDamageMaintenance(int? damageId = null)
        {
            InitializeComponent();

            _damageId = damageId;

            LoadCombos();
            LoadStatusCombo();

            if (_damageId.HasValue)
            {
                Text = "Edit Damage Maintenance";
                btnSave.Text = "Update";
                lblTitle.Text = "Edit Damage Maintenance";
                LoadDamageData(_damageId.Value);
            }
            else
            {
                Text = "Add New Damage Maintenance";
                lblTitle.Text = "Add New Damage Maintenance";
                btnSave.Text = "Save";
            }
        }

        private void LoadCombos()
        {
            // Load Cars for selection
            dtCars = ClsCar.GetAllCars();
            cmbCar.DataSource = null;
            cmbCar.DisplayMember = "PlateNumber"; 
            cmbCar.ValueMember = "CarID";
            cmbCar.DataSource = dtCars;
            cmbCar.SelectedIndex = -1;

            
            dtEmployees = ClsUser.GetUsersDataTable(); 
            cmbEmployee.DataSource = null;
            cmbEmployee.DisplayMember = "NameEn"; 
            cmbEmployee.ValueMember = "UserId";
            cmbEmployee.DataSource = dtEmployees;
            cmbEmployee.SelectedIndex = -1;
        }

        private void LoadStatusCombo()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add(StatusEnum.Pending.ToString());
            cmbStatus.Items.Add(StatusEnum.InProgress.ToString());
            cmbStatus.Items.Add(StatusEnum.Completed.ToString());
            cmbStatus.SelectedIndex = -1;
        }

        private void LoadDamageData(int damageId)
        {
            ClsDamageMaintenance damage = ClsDamageMaintenance.FindById(damageId);
            if (damage == null)
            {
                MessageBox.Show("Damage record not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            cmbCar.SelectedValue = damage.CarID;
            dtpDamageDate.Value = damage.DamageDate;
            numTotalAmount.Value = damage.TotalAmount;
            cmbStatus.SelectedIndex = (int)damage.Status;
            numGasolineIn.Value = damage.GasolineIn;
            numGasolineOut.Value = damage.GasolineOut;
            txtGarageName.Text = damage.GarageName;
            txtDescription.Text = damage.Description;

            if (damage.EmployeeID!= null)
                cmbEmployee.SelectedValue = damage.EmployeeID;
            else
                cmbEmployee.SelectedIndex = -1;

            if (damage.RepairStartDate!= null)
            {
                dtpRepairStartDate.Value = (DateTime)damage.RepairStartDate;
                dtpRepairStartDate.Checked = true;
            }
            else
            {
                dtpRepairStartDate.Checked = false;
            }

            if (damage.CompletionDate!= null)
            {
                dtpCompletionDate.Value = (DateTime)damage.CompletionDate;
                dtpCompletionDate.Checked = true;
            }
            else
            {
                dtpCompletionDate.Checked = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            if (cmbCar.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int carId = (int)cmbCar.SelectedValue;
            DateTime damageDate = dtpDamageDate.Value;
            decimal totalAmount = numTotalAmount.Value;
            StatusEnum status = (StatusEnum)cmbStatus.SelectedIndex;
            decimal gasolineIn = numGasolineIn.Value;
            decimal gasolineOut = numGasolineOut.Value;
            string garageName = txtGarageName.Text.Trim();
            int? employeeId = (cmbEmployee.SelectedIndex != -1) ? (int?)cmbEmployee.SelectedValue : null;
            DateTime? repairStartDate = dtpRepairStartDate!=null ? dtpRepairStartDate.Value : (DateTime?)null;
            DateTime? completionDate = dtpCompletionDate!=null ? dtpCompletionDate.Value : (DateTime?)null;
            string Description = txtDescription.Text.Trim();

            ClsDamageMaintenance damage;
            if (_damageId.HasValue)
            {
                damage = ClsDamageMaintenance.FindById(_damageId.Value);
                if (damage == null)
                {
                    MessageBox.Show("Damage record not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                damage = new ClsDamageMaintenance();
            }

            damage.CarID = carId;
            damage.DamageDate = damageDate;
            damage.TotalAmount = totalAmount;
            damage.Status = (ClsDamageMaintenance.enStatus)status;
            damage.GasolineIn = gasolineIn;
            damage.GasolineOut = gasolineOut;
            damage.GarageName = garageName;
            damage.EmployeeID = employeeId;
            damage.RepairStartDate = repairStartDate;
            damage.CompletionDate = completionDate;
            damage.Description = Description;

            bool success = damage.Save();

            if (success)
            {
                MessageBox.Show("Damage maintenance saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int savedId = (int)(_damageId ?? damage.DamageID);
                DamageSaved?.Invoke(savedId);
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save damage maintenance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
