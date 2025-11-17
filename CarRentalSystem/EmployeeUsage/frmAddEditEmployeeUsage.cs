using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.EmployeeUsageForms
{
    public partial class frmAddEditEmployeeUsage : Form
    {
        private int? _usageId;
        private ClsEmployeeUsage _usage;

        // Define enum for status
        public enum UsageStatus
        {
            Pending = 0,
            Delivered = 1,
            InProgress = 2
        }

        public frmAddEditEmployeeUsage(int? usageId = null)
        {
            InitializeComponent();
            _usageId = usageId;
            dtExitDate.CustomFormat = "yyyy-MM-dd // HH:mm:ss";
            dtpEntry.CustomFormat = "yyyy-MM-dd // HH:mm:ss";

            // Set DateTimePickers to show date and time
            dtExitDate.Format = DateTimePickerFormat.Custom;
            dtpEntry.Format = DateTimePickerFormat.Custom;
        }

        private void LoadEmployees()
        {
            DataTable dt = ClsUser.GetUsersDataTable();
            cbEmployee.DisplayMember = "NameEn";
            cbEmployee.ValueMember = "UserId";
            cbEmployee.DataSource = dt;
            cbEmployee.SelectedIndex = -1;
        }

        private void LoadCars()
        {
            DataTable dt = ClsCar.GetAllCars();
            cbCar.DisplayMember = "PlateNumber";
            cbCar.ValueMember = "CarID";
            cbCar.DataSource = dt;
            cbCar.SelectedIndex = -1;
        }

        private void LoadBranches()
        {
            DataTable dt = ClsBranch.GetBranchesDataTable();

            // For exit branch combo box
            cbBranch.DisplayMember = "name";
            cbBranch.ValueMember = "branch_id";
            cbBranch.DataSource = dt;
            cbBranch.SelectedIndex = -1;

            // For entry branch combo box
            cmbEntrybranch.DisplayMember = "name";
            cmbEntrybranch.ValueMember = "branch_id";
            cmbEntrybranch.DataSource = dt.Copy(); // Copy to avoid cross-binding issues
            cmbEntrybranch.SelectedIndex = -1;
        }

        private void LoadStatusEnum()
        {
            // Bind enum values directly to ComboBox
            cbStatus.DataSource = Enum.GetValues(typeof(UsageStatus));
            cbStatus.SelectedIndex = -1;
        }

        private void LoadUsageData(int usageId)
        {
            _usage = ClsEmployeeUsage.Find(usageId);

            if (_usage == null)
            {
                MessageBox.Show("Employee usage record not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            cbEmployee.SelectedValue = _usage.EmployeeId;
            cbCar.SelectedValue = _usage.CarId;
            cbBranch.SelectedValue = _usage.ExitBranchId;
            txtReason.Text = _usage.UsageReason;
            dtExitDate.Value = _usage.ExitDate;

            // Cast stored int status to enum for selection
            cbStatus.SelectedItem = (UsageStatus)_usage.Status;

            // New fields binding
            nudExitCounter.Value = _usage.ExitCounter;
            txtExitFuel.Text = _usage.ExitFuel ?? "";

            cmbEntrybranch.SelectedValue = _usage.EntryBranchId;
            dtpEntry.Value = _usage.EntryDate;

            nupEntryCounter.Value = _usage.EntryCountre;
            txtEnteryFuel.Text = _usage.EntryFuel ?? "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the validation errors.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_usageId.HasValue)
                _usage = ClsEmployeeUsage.Find(_usageId.Value);
            else
                _usage = new ClsEmployeeUsage();

            _usage.EmployeeId = Convert.ToInt32(cbEmployee.SelectedValue);
            _usage.CarId = Convert.ToInt32(cbCar.SelectedValue);
            _usage.ExitBranchId = Convert.ToInt32(cbBranch.SelectedValue);
            _usage.UsageReason = txtReason.Text.Trim();
            _usage.ExitDate = dtExitDate.Value;

            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a status.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _usage.Status = (int)(UsageStatus)cbStatus.SelectedItem;

            // Save new fields from controls
            _usage.ExitCounter = (int)nudExitCounter.Value;
            _usage.ExitFuel = txtExitFuel.Text.Trim();

            _usage.EntryBranchId = cmbEntrybranch.SelectedValue != null ? Convert.ToInt32(cmbEntrybranch.SelectedValue) : 0;
            _usage.EntryDate = dtpEntry.Value;

            _usage.EntryCountre = (int)nupEntryCounter.Value;
            _usage.EntryFuel = txtEnteryFuel.Text.Trim();

            bool success = _usage.Save();

            if (success)
            {
                MessageBox.Show("Employee Usage saved successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save Employee Usage.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // VALIDATIONS

        private void cbEmployee_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbEmployee.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbEmployee, "Select an employee.");
            }
            else
            {
                errorProvider1.SetError(cbEmployee, "");
            }
        }

        private void cbCar_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbCar.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbCar, "Select a car.");
            }
            else
            {
                errorProvider1.SetError(cbCar, "");
            }
        }

        private void cbBranch_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbBranch.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbBranch, "Select a branch.");
            }
            else
            {
                errorProvider1.SetError(cbBranch, "");
            }
        }

        private void cmbEntrybranch_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbEntrybranch.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbEntrybranch, "Select an entry branch.");
            }
            else
            {
                errorProvider1.SetError(cmbEntrybranch, "");
            }
        }

        private void txtReason_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                errorProvider1.SetError(txtReason, "Usage reason is required.");
            }
            else
            {
                errorProvider1.SetError(txtReason, "");
            }
        }

        private void cbStatus_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbStatus.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbStatus, "Select a status.");
            }
            else
            {
                errorProvider1.SetError(cbStatus, "");
            }
        }

        private void nudExitCounter_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nudExitCounter.Value < 0)
            {
                errorProvider1.SetError(nudExitCounter, "Exit counter cannot be negative.");
            }
            else
            {
                errorProvider1.SetError(nudExitCounter, "");
            }
        }

        private void nupEntryCounter_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nupEntryCounter.Value < 0)
            {
                errorProvider1.SetError(nupEntryCounter, "Entry counter cannot be negative.");
            }
            else
            {
                errorProvider1.SetError(nupEntryCounter, "");
            }
        }

        private void txtExitFuel_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExitFuel.Text))
            {
                errorProvider1.SetError(txtExitFuel, "Exit fuel cannot be empty.");
            }
            else
            {
                errorProvider1.SetError(txtExitFuel, "");
            }
        }

        private void txtEntryFuel_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnteryFuel.Text))
            {
                errorProvider1.SetError(txtEnteryFuel, "Entry fuel cannot be empty.");
            }
            else
            {
                errorProvider1.SetError(txtEnteryFuel, "");
            }
        }

        private void frmAddEditEmployeeUsage_Load_1(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadCars();
            LoadBranches();
            LoadStatusEnum();

            if (_usageId.HasValue)
            {
                this.Text = "Edit Employee Usage";
                lblTitle.Text = "Edit Employee Usage";
                btnSave.Text = "Update";
                LoadUsageData(_usageId.Value);
            }
            else
            {
                this.Text = "Add New Employee Usage";
                lblTitle.Text = "Add New Employee Usage";
                btnSave.Text = "Save";
                dtExitDate.Value = DateTime.Now;
                dtpEntry.Value = DateTime.Now;
            }
        }
    }
}
