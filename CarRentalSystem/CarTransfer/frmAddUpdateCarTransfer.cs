using CarRentalBusiness;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalSystem.CarTransfer
{
    public partial class frmAddUpdateCarTransfer : Form
    {
        private int? _transferId;
        private ClsCarTransfer _transfer;

        public delegate void TransferSavedHandler(int transferId);
        public event TransferSavedHandler TransferSaved;

        public frmAddUpdateCarTransfer(int? transferId = null)
        {
            InitializeComponent();

            _transferId = transferId;

            LoadCombos();

            if (_transferId.HasValue)
            {
                this.Text = "Edit Car Transfer";
                btnSave.Text = "Update";
                lblTitle.Text = "Edit Transfer Details";
                LoadTransferData(_transferId.Value);
            }
            else
            {
                this.Text = "Add New Car Transfer";
                btnSave.Text = "Save";
                lblTitle.Text = "Add New Car Transfer";
            }
        }

        private void LoadCombos()
        {
            // Load Cars
            var cars = ClsCar.GetAllCars();
            cmbCar.DataSource = cars;
            cmbCar.DisplayMember = "PlateNumber";
            cmbCar.ValueMember = "CarId";

            // Load Employees
            var employees = ClsUser.GetUsersDataTable();
            cmbEmployee.DataSource = employees;
            cmbEmployee.DisplayMember = "NameEn";
            cmbEmployee.ValueMember = "UserId";

            // Load Branches
            var branchesfrom = ClsBranch.GetBranchesDataTable();
            cmbExitBranch.DataSource = branchesfrom;
            cmbExitBranch.DisplayMember = "name";
            cmbExitBranch.ValueMember = "branch_id";

            var brancheTo = ClsBranch.GetBranchesDataTable();
            cmbToBranch.DataSource = brancheTo;
            cmbToBranch.DisplayMember = "name";
            cmbToBranch.ValueMember = "branch_id";

            // Status
            cmbStatus.Items.AddRange(new string[] { "Pending", "Delivered", "InProgress" });
         
        }

        private void LoadTransferData(int id)
        {
            _transfer = ClsCarTransfer.FindById(id);

            if (_transfer == null)
            {
                MessageBox.Show("Transfer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            cmbCar.SelectedValue = _transfer.CarId;
            cmbEmployee.SelectedValue = _transfer.EmployeeId;
            txtReason.Text = _transfer.TransferReason;
            cmbExitBranch.SelectedValue = _transfer.ExitBranchId;
            txtExitCounter.Text = _transfer.ExitCounter.ToString();
            txtFuelExit.Text = _transfer.ExitFuel;

            txtEntertyFuel.Text = _transfer.EntryFuel;
            txtEnteryCounter.Text = _transfer.EntryCounter.ToString();

            dtExitDate.Value = _transfer.ExitDate ?? DateTime.Now;

            cmbStatus.SelectedIndex = _transfer.Status;
            cmbToBranch.SelectedValue = _transfer.BranchTransferTo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (cmbCar.SelectedIndex == -1 ||
                cmbEmployee.SelectedIndex == -1 ||
                cmbExitBranch.SelectedIndex == -1 ||
                cmbToBranch.SelectedIndex == -1 ||
                cmbStatus.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_transferId.HasValue)
            {
                _transfer = ClsCarTransfer.FindById(_transferId.Value);
                if (_transfer == null)
                {
                    MessageBox.Show("Transfer not found, cannot update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                _transfer = new ClsCarTransfer();
            }

            // Fill object
            _transfer.CarId = (int)cmbCar.SelectedValue;
            _transfer.EmployeeId = (int)cmbEmployee.SelectedValue;
            _transfer.TransferReason = txtReason.Text.Trim();
            _transfer.ExitBranchId = (int)cmbExitBranch.SelectedValue;
            _transfer.ExitCounter = int.TryParse(txtExitCounter.Text, out int counter) ? counter : 0;
            _transfer.ExitFuel = txtFuelExit.Text;
            _transfer.ExitDate = dtExitDate.Value;
            _transfer.Status = cmbStatus.SelectedIndex;
            _transfer.BranchTransferTo = (int)cmbToBranch.SelectedValue;

            _transfer.EntryFuel = txtEntertyFuel.Text;
            _transfer.EntryCounter = Convert.ToDouble(txtEnteryCounter.Text);

            bool success = _transfer.Save();

            if (success)
            {
                MessageBox.Show("Transfer saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int savedId = _transfer.TransferId ?? _transferId.Value;

                TransferSaved?.Invoke(savedId);

                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save transfer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
