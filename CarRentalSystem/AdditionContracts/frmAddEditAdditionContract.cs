using CarRentalBusiness;
using System;
using System.Windows.Forms;

namespace CarRentalSystem.AdditionContracts
{
    public partial class frmAddEditAdditionContract : Form
    {
        private int? additionContractId;
        ClsAdditionContract _contract;
        private enum FormMode { Add, Edit }
        private FormMode currentMode;

        public frmAddEditAdditionContract(int? id = null)
        {
            InitializeComponent();
            additionContractId = id;
            currentMode = id.HasValue ? FormMode.Edit : FormMode.Add;

            SetupForm();
        }

        private void SetupForm()
        {
            if (currentMode == FormMode.Add)
            {
                this.Text = "Add New Addition Contract";
                btnSave.Text = "Add";
                _contract = new ClsAdditionContract();
            }
            else
            {
                this.Text = "Edit Addition Contract";
                btnSave.Text = "Save";
                LoadAdditionContractData();
            }
        }

        private void LoadAdditionContractData()
        {
            if (!additionContractId.HasValue)
                return;

            _contract = ClsAdditionContract.FindById(additionContractId.Value);
            if (_contract == null)
            {
                MessageBox.Show("Addition Contract not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtName.Text = _contract.Name;
            nudPrice.Value = _contract.Price;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            decimal price = nudPrice.Value;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter the contract name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Please enter a valid price greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudPrice.Focus();
                return;
            }

            _contract.Name = name;
            _contract.Price = price;

            bool saved = _contract.Save();

            if (saved)
            {
                MessageBox.Show("Addition Contract saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save Addition Contract.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
