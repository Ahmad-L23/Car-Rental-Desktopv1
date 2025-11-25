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

namespace CarRentalSystem.Agreement
{
    public partial class frmAddUpdatAgreement : Form
    {
        decimal taxRate = 0m;

        private ClsAgreement _Agreement;
        private int? _AgreementId = null;
        public frmAddUpdatAgreement()
        {
            InitializeComponent();
            LoadCars();
            LoadCustomers();
            LoadBranches();
            LoadAdditions();
            LoadPaymentMethods();
            dpRecivingDate.MinDate = DateTime.Now;
            dpDelveringDate.MinDate = DateTime.Now;

            cbCustomers.Focus();

            // Do NOT subscribe to events here - handled in Designer or manually.

            // Initialize labels
            lblAdditionContractTotal.Text = "Total: 0.00";
            lblRentalAdditionsTotal.Text = "Total: 0.00";
            lblRequiredInsuranceTotal.Text = "Total: 0.00";
            lbltotalAmountIncTax.Text = "0.00";
        }

        public frmAddUpdatAgreement(int agreementId) : this()
        {
            _AgreementId = agreementId;
            LoadAgreementData(agreementId);
        }



        private void LoadAgreementData(int id)
        {
            _Agreement = ClsAgreement.FindById(id);
            if (_Agreement == null)
            {
                MessageBox.Show("Agreement not found.");
                return;
            }

            cbCars.SelectedValue = _Agreement.CarID;
            cbCustomers.SelectedValue = _Agreement.CustomerID;
            cbPickBranch.SelectedValue = _Agreement.PickupBranchID;
            cbDropOfbranch.SelectedValue = _Agreement.DropOffBranchID;
            cbPaymentMethod.SelectedValue = _Agreement.PaymentMethod;

            dpRecivingDate.Value = _Agreement.StartDate;
            dpDelveringDate.Value = _Agreement.EndDate;
            if (_Agreement.PaymentDate.HasValue)
                dpPaymentDate.Value = _Agreement.PaymentDate.Value;

            txtAgreedPrice.Text = _Agreement.AgreedPrice.ToString("F2");
            txtLatePenalty.Text = (_Agreement.RentalPenaltyPerDay ?? 0).ToString("F2");
            txtTotalPrice.Text = _Agreement.TotalAmountBeforeTax?.ToString("F2") ?? "0.00";
            nuPremmitedMeters.Value = (decimal)_Agreement.PermittedDailyKilometers;
            nuPricePerAddKilo.Value = (decimal)_Agreement.AdditionalKilometerPrice;
            if (_Agreement.PermittedDailyKilometers.HasValue || _Agreement.AdditionalKilometerPrice.HasValue)
            {
                chIncludePremitKillo.Checked = true;
                gbPremmitedKillo.Enabled = true;
            }

            if (_Agreement.TaxRate > 0)
            {
                chIncludeTax.Checked = true;
                gbIncludetax.Enabled = true;
            }

            nuTaxrate.Value = _Agreement.TaxRate;
            nuPaidAmount.Value = _Agreement.InitialPaidAmount ?? 0m;
            txtCurrentCounter.Text = (_Agreement.Mileage ?? 0).ToString();
            txtExitFuel.Text = _Agreement.ExitFuel ?? "";

            CheckItemsInCheckedListBox(chAdditionInsurance, _Agreement.AdditionContracts.Select(x => x.Id).ToList());
            CheckItemsInCheckedListBox(chOtherAdditions, _Agreement.RentalAdditions.Select(x => x.Id).ToList());
            CheckItemsInCheckedListBox(chRequiredInsurance, _Agreement.RequiredInsurances.Select(x => x.Id).ToList());

            lblAdditionContractTotal.Text = $"Total: {_Agreement.AdditionContractPrice?.ToString("F2") ?? "0.00"}";
            lblRentalAdditionsTotal.Text = $"Total: {_Agreement.RentalAdditionsPrice?.ToString("F2") ?? "0.00"}";
            lblRequiredInsuranceTotal.Text = $"Total: {_Agreement.RequiredInsurancePrice?.ToString("F2") ?? "0.00"}";

            RefreshAll();
        }

        private void CheckItemsInCheckedListBox(CheckedListBox clb, List<int> ids)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (clb.Items[i] is Item item)
                    clb.SetItemChecked(i, ids.Contains(item.Id));
            }
        }
        private void RefreshAll()
        {
            UpdateRentalDays();
            UpdateTotalPrice();
            UpdateTotalAmountOfAdditions();
            UpdateTotalIncludingTax();
        }

        //Customer Detalis(Load and Show)

        private void LoadCustomers()
        {
            var dt = ClsCustomer.GetCustomersDataTable();
            cbCustomers.DataSource = dt;
            cbCustomers.DisplayMember = "customer_name_en";
            cbCustomers.ValueMember = "customer_id";
            cbCustomers.SelectedIndex = -1;
        }

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCustomers.SelectedValue == null) return;

            if (int.TryParse(cbCustomers.SelectedValue.ToString(), out int selectedCustId))
            {
                ClsCustomer customer = ClsCustomer.FindById(selectedCustId);
                if (customer != null)
                {
                    txtCustIdenetity.Text = customer.IdentityNumber ?? "";
                    txtCustName.Text = customer.CustomerNameEn ?? "";
                    txtCustPhone.Text = customer.PhoneNumber ?? "";
                    txtCustmAddress.Text = customer.AddressEn ?? "";
                }
                else
                {
                    ClearCustomerTextBoxes();
                }
            }
        }
        private void ClearCustomerTextBoxes()
        {
            txtCustIdenetity.Text = "";
            txtCustName.Text = "";
            txtCustPhone.Text = "";
            txtCustmAddress.Text = "";
        }



        //Car Detalis (Load And show)
        private void LoadCars()
        {
            var dt = ClsCar.GetAllCarsIdsAndPlateNubmers();
            cbCars.DataSource = dt;
            cbCars.DisplayMember = "PlateNumber";
            cbCars.ValueMember = "CarID";
            cbCars.SelectedIndex = -1;
        }

        private void cbCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCars.SelectedValue == null) return;

            if (cbCars.SelectedValue == null || cbCars.SelectedIndex == -1)
                return;

            // Safe conversion
            if (!int.TryParse(cbCars.SelectedValue.ToString(), out int carId))
                return;

            if (!ClsCar.IsAvaliable(carId))
            {
                MessageBox.Show("This car is not available due to: " +
                                ClsCar.UnavaliableReason(carId));
                return;
            }

            if (int.TryParse(cbCars.SelectedValue.ToString(), out int selectedCarId))
            {
                ClsCar car = ClsCar.FindById(selectedCarId);
                if (car != null)
                {
                    txtCarPlate.Text = car.PlateNumber ?? "";
                    txtCarName.Text = car.CarNameAr ?? "";
                    txtCarCategory.Text = car.Category?.NameEn ?? "";
                    txtYear.Text = car.Year.ToString();
                    txtCurrentCounter.Text = car.CurrentCounter.ToString();
                    txtExitFuel.Text = car.FuelExit ?? "";
                }
                else
                {
                    ClearCarTextBoxes();
                }
            }

        }

        private void ClearCarTextBoxes()
        {
            txtCarPlate.Text = "";
            txtCarName.Text = "";
            txtCarCategory.Text = "";
            txtYear.Text = "";
            txtCurrentCounter.Text = "";
            txtExitFuel.Text = "";
        }

        //load Branchs

        private void LoadBranches()
        {
            var dt = ClsBranch.GetBranchesDataTable();
            cbPickBranch.DataSource = dt.Copy();
            cbPickBranch.DisplayMember = "name";
            cbPickBranch.ValueMember = "branch_id";
            cbPickBranch.SelectedIndex = -1;

            cbDropOfbranch.DataSource = dt;
            cbDropOfbranch.DisplayMember = "name";
            cbDropOfbranch.ValueMember = "branch_id";
            cbDropOfbranch.SelectedIndex = -1;
        }


        private void LoadPaymentMethods()
        {
            var dt = ClsPaymentMethod.GetAllPaymentMethods();
            cbPaymentMethod.DataSource = dt;
            cbPaymentMethod.DisplayMember = "MethodName";
            cbPaymentMethod.ValueMember = "MethodName";
            cbPaymentMethod.SelectedIndex = -1;
        }

        private void LoadAdditions()
        {
            chRequiredInsurance.Items.Clear();
            foreach (DataRow r in ClsRequiredInsurance.GetAllInsurance().Rows)
                chRequiredInsurance.Items.Add(new Item { Id = Convert.ToInt32(r["Id"]), Name = r["ItemName"].ToString(), Price = Convert.ToDecimal(r["Price"]) }, false);

            chAdditionInsurance.Items.Clear();
            foreach (DataRow r in ClsAdditionContract.GetAdditionContractsDataTable().Rows)
                chAdditionInsurance.Items.Add(new Item { Id = Convert.ToInt32(r["Id"]), Name = r["Name"].ToString(), Price = Convert.ToDecimal(r["Price"]) }, false);

            chOtherAdditions.Items.Clear();
            foreach (DataRow r in ClsRentalAddition.GetRentalAdditionsDataTable().Rows)
                chOtherAdditions.Items.Add(new Item { Id = Convert.ToInt32(r["RentalAdditionID"]), Name = r["RentalName"].ToString(), Price = Convert.ToDecimal(r["Price"]) }, false);
        }

        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public override string ToString() => $"{Name} ({Price:F2})";
        }


        private List<(int Id, decimal Price)> GetCheckedItemsList(CheckedListBox clb)
        {
            var list = new List<(int Id, decimal Price)>();
            foreach (var item in clb.CheckedItems)
            {
                if (item is Item i)
                    list.Add((i.Id, i.Price));
            }
            return list;
        }


        private void UpdateRentalDays()
        {
            int days = (dpDelveringDate.Value.Date - dpRecivingDate.Value.Date).Days;
            txtRentalDays.Text = (days < 0) ? "0" : days.ToString();
        }

        private void UpdateTotalPrice()
        {
            if (int.TryParse(txtRentalDays.Text, out int days) &&
                decimal.TryParse(txtAgreedPrice.Text, out decimal price))
            {
                decimal total = days * price;
                txtTotalPrice.Text = total.ToString("F2");
            }
            else
            {
                txtTotalPrice.Text = "";
            }
        }

        private void UpdateTotalAmountOfAdditions()
        {
            decimal additionTotal = SumCheckedItemsPrices(chAdditionInsurance);
            decimal rentalTotal = SumCheckedItemsPrices(chOtherAdditions);
            decimal requiredTotal = SumCheckedItemsPrices(chRequiredInsurance);

            lblAdditionContractTotal.Text = $"Total: {additionTotal:F2}";
            lblRentalAdditionsTotal.Text = $"Total: {rentalTotal:F2}";
            lblRequiredInsuranceTotal.Text = $"Total: {requiredTotal:F2}";

            decimal combinedTotal = additionTotal + rentalTotal + requiredTotal;
            lblTotalAmountOfAdditions.Text = combinedTotal.ToString("F2");
        }

        private decimal SumCheckedItemsPrices(CheckedListBox clb)
        {
            decimal total = 0m;
            foreach (var item in clb.CheckedItems)
                if (item is Item i)
                    total += i.Price;
            return total;
        }

        private void UpdateTotalIncludingTax()
        {
            if (!chIncludeTax.Checked)
            {
                lbltotalAmountIncTax.Text = "0.00";
                taxRate = 0;
                return;
            }

            decimal basePrice = 0m;
            decimal additions = 0m;


            decimal.TryParse(txtTotalPrice.Text, out basePrice);
            decimal.TryParse(lblTotalAmountOfAdditions.Text, out additions);

            if (nuTaxrate.Value == 0 && chIncludeTax.Checked)
                taxRate = 16;

            else
                taxRate = nuTaxrate.Value;


            decimal taxAmount = basePrice * (taxRate / 100);

            decimal totalIncludingTax = basePrice + taxAmount + additions;
            lbltotalAmountIncTax.Text = totalIncludingTax.ToString("F2");

        }

        private void chRequiredInsurance_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(() => RefreshAll()));
            }
            else
            {
                // Either do nothing or call directly (if safe)
                RefreshAll();
            }
        }

        private void chAdditionInsurance_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(() => RefreshAll()));
            }
            else
            {
                // Either do nothing or call directly (if safe)
                RefreshAll();
            }
        }

        private void chOtherAdditions_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(() => RefreshAll()));
            }
            else
            {
                // Either do nothing or call directly (if safe)
                RefreshAll();
            }
        }

        private void txtAgreedPrice_TextChanged(object sender, EventArgs e) => RefreshAll();
        private void txtRentalDays_TextChanged(object sender, EventArgs e) => RefreshAll();

        private void nuTaxrate_ValueChanged(object sender, EventArgs e) => RefreshAll();
        private void txtTotalPrice_TextChanged(object sender, EventArgs e) => RefreshAll();

        private int GetLastSerialNumber() => ClsAgreement.GetLastSerialNumber() + 1;

        private void dpRecivingDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void dpDelveringDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void txtRentalDays_TextChanged_1(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void nuTaxrate_ValueChanged_1(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(txtTotalPrice.Text.Trim()))
            {
                MessageBox.Show("Pleas Fill Agreement duration and pricing Data");
                return;
            }
            if(IsRequiredInuranceNotSelectedOneAtLeast())
            {
                MessageBox.Show("Pleas Select One Required Insurance");
                return;
            }

            RefreshAll();
        }

        private void chIncludeTax_CheckedChanged(object sender, EventArgs e)
        {
            RefreshAll();
        }





        //valdiations

        private bool ValidateComboBoxes()
        {
            bool isValid = true;

            // cbPickBranch
            if (cbPickBranch.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbPickBranch, "Please select a branch");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(cbPickBranch, "");
            }

            // cbDropOfbranch
            if (cbDropOfbranch.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbDropOfbranch, "Please select a drop-off branch");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(cbDropOfbranch, "");
            }

            // cbPaymentMethod
            if (cbPaymentMethod.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbPaymentMethod, "Please select a payment method");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(cbPaymentMethod, "");
            }

            return isValid;
        }

        //private void cbPickBranch_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ValidateComboBoxes();
        //}

        //private void cbDropOfbranch_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ValidateComboBoxes();
        //}

        //private void cbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ValidateComboBoxes();
        //}

        private bool ValidateForm()
        {
            bool isValid = true;

            // Validate ComboBoxes
            if (cbPickBranch.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbPickBranch, "Please select a pick branch");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(cbPickBranch, "");
            }

            if (cbDropOfbranch.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbDropOfbranch, "Please select a drop-off branch");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(cbDropOfbranch, "");
            }

            if (cbPaymentMethod.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbPaymentMethod, "Please select a payment method");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(cbPaymentMethod, "");
            }

            // Validate DateTimePickers

            // Delivery date cannot be before receiving date
            if (dpDelveringDate.Value.Date < dpRecivingDate.Value.Date)
            {
                errorProvider1.SetError(dpDelveringDate, "Delivery date cannot be before receiving date");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(dpDelveringDate, "");
            }

            // Payment date cannot be before receiving date

            return isValid;
        }


        private bool ValidateNumericInputs()
        {
            bool isValid = true;

            // Helper local function to check numeric textboxes
            bool IsNumeric(string s) => decimal.TryParse(s, out _);

            // txtRentalDays - must be numeric and not empty
            if (string.IsNullOrWhiteSpace(txtRentalDays.Text))
            {
                errorProvider1.SetError(txtRentalDays, "Please fill the Rental Days");
                isValid = false;
            }
            else if (!IsNumeric(txtRentalDays.Text))
            {
                errorProvider1.SetError(txtRentalDays, "Please enter a valid number for Rental Days");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtRentalDays, "");
            }

            // txtAgreedPrice - must be numeric and not empty
            if (string.IsNullOrWhiteSpace(txtAgreedPrice.Text))
            {
                errorProvider1.SetError(txtAgreedPrice, "Please fill the Agreed Price");
                isValid = false;
            }
            else if (!IsNumeric(txtAgreedPrice.Text))
            {
                errorProvider1.SetError(txtAgreedPrice, "Please enter a valid number for Agreed Price");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtAgreedPrice, "");
            }

            // txtLatePenalty - must be numeric and not empty
            if (string.IsNullOrWhiteSpace(txtLatePenalty.Text))
            {
                errorProvider1.SetError(txtLatePenalty, "Please fill the Late Penalty");
                isValid = false;
            }
            else if (!IsNumeric(txtLatePenalty.Text))
            {
                errorProvider1.SetError(txtLatePenalty, "Please enter a valid number for Late Penalty");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtLatePenalty, "");
            }

            // nuPaidAmount (NumericUpDown) - check value > 0 or as per your logic
            if (nuPaidAmount.Value <= 0)
            {
                errorProvider1.SetError(nuPaidAmount, "Please enter a paid amount greater than zero");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(nuPaidAmount, "");
            }

            return isValid;
        }

        private void HandleNumericKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            TextBox tb = sender as TextBox;

            if (e.KeyChar == '.')
            {
                if (tb.Text.Contains('.'))
                {
                    e.Handled = true;
                    MessageBox.Show("Please enter only one decimal point.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            // If we reached here, the char is invalid
            e.Handled = true;
            MessageBox.Show("Please enter numbers only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void txtRentalDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleNumericKeyPress(sender, e);
        }

        private void txtAgreedPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleNumericKeyPress(sender, e);
        }

        private void txtLatePenalty_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleNumericKeyPress(sender, e);
        }

        private bool IsRequiredInuranceNotSelectedOneAtLeast()
        {
            return chRequiredInsurance.Items.Count == 0;
        }

        private void btnConfirmAgreement_Click(object sender, EventArgs e)
        {
            if (!ValidateForm() || !ValidateNumericInputs() || !ValidateComboBoxes())
            {
                MessageBox.Show("Please fix validation errors before savingn hover On the error icon to see the problem", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Prevent saving
            }


            if (!ValidateChildren())
                return;

            if (chRequiredInsurance.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one required insurance.");
                return;
            }
            if (nuPaidAmount.Value == 0 || cbPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Please Fill Payment and Financial authorization");
                return;
            }


            if (_AgreementId == null)
                _Agreement = new ClsAgreement();
            else
                _Agreement = ClsAgreement.FindById(_AgreementId.Value);



            // Required selections with fallback to 0 (non-nullable int)
            _Agreement.CustomerID = cbCustomers.SelectedValue is int custId ? custId : 0;
            _Agreement.CarID = cbCars.SelectedValue is int carId ? carId : 0;
            _Agreement.PickupBranchID = cbPickBranch.SelectedValue is int pickId ? pickId : 0;
            _Agreement.DropOffBranchID = cbDropOfbranch.SelectedValue is int dropId ? dropId : 0;

            // Dates (non-nullable DateTime)
            _Agreement.StartDate = dpRecivingDate.Value;
            _Agreement.EndDate = dpDelveringDate.Value;

            // Prices and penalties (decimal), try parse with fallback to 0
            _Agreement.AgreedPrice = decimal.TryParse(txtAgreedPrice.Text, out var agreedPrice) ? agreedPrice : 0m;
            _Agreement.RentalPenaltyPerDay = decimal.TryParse(txtLatePenalty.Text, out var penalty) ? penalty : 0m;

            // Calculate total before tax = total price + additions
            decimal totalPrice = decimal.TryParse(txtTotalPrice.Text, out var total) ? total : 0m;
            decimal totalAdditions = decimal.TryParse(lblTotalAmountOfAdditions.Text, out var totalOfAdditions) ? totalOfAdditions : 0m;
            _Agreement.TotalAmountBeforeTax = totalPrice + totalAdditions;

            // Total including tax, depends on checkbox, fallback 0
            if (chIncludeTax.Checked)
                _Agreement.TotalIncludetax = decimal.TryParse(lbltotalAmountIncTax.Text, out var totIncTax) ? totIncTax : 0m;
            else
                _Agreement.TotalIncludetax = 0m;

            // Rental days cost (decimal)
            _Agreement.RentalDaysCost = totalPrice;

            // Nullable int: PermittedDailyKilometers based on checkbox and numeric input
            if (chIncludePremitKillo.Checked && nuPremmitedMeters.Value > 0)
                _Agreement.PermittedDailyKilometers = (int)nuPremmitedMeters.Value;
            else
                _Agreement.PermittedDailyKilometers = null;

            // Nullable decimal: AdditionalKilometerPrice based on checkbox and numeric input
            if (chIncludePremitKillo.Checked && nuPricePerAddKilo.Value > 0)
                _Agreement.AdditionalKilometerPrice = nuPricePerAddKilo.Value; // keep decimal type
            else
                _Agreement.AdditionalKilometerPrice = null;

            // TaxRate (decimal, non-nullable)
            _Agreement.TaxRate = taxRate;

            // InitialPaidAmount (decimal, non-nullable)
            _Agreement.InitialPaidAmount = nuPaidAmount.Value;

            // Payment info
            _Agreement.PaymentMethod = cbPaymentMethod.SelectedValue?.ToString() ?? "";
            _Agreement.PaymentDate = dpPaymentDate.Value;
            _Agreement.ActualDeliveryDate = null;

            // Nullable ints - set to null or assign when available
            _Agreement.ReceivingOdometer = null;
            _Agreement.ConsumedMileage = null;

            // Nullable int: Mileage from text input
            if (int.TryParse(txtCurrentCounter.Text, out var mileage))
                _Agreement.Mileage = mileage;
            else
                _Agreement.Mileage = null;

            // ExitFuel (string), nullable, trim whitespace and check empty
            _Agreement.ExitFuel = string.IsNullOrWhiteSpace(txtExitFuel.Text) ? null : txtExitFuel.Text.Trim();

            // SerialNumber (int, non-nullable)
            _Agreement.SerialNumber = GetLastSerialNumber();






            _Agreement.AdditionContractPrice = SumCheckedItemsPrices(chAdditionInsurance);
            _Agreement.RentalAdditionsPrice = SumCheckedItemsPrices(chOtherAdditions);
            _Agreement.RequiredInsurancePrice = SumCheckedItemsPrices(chRequiredInsurance);

            _Agreement.AdditionContracts = GetCheckedItemsList(chAdditionInsurance);
            _Agreement.RentalAdditions = GetCheckedItemsList(chOtherAdditions);
            _Agreement.RequiredInsurances = GetCheckedItemsList(chRequiredInsurance);

            bool saved = _Agreement.Save();

            if (saved)
            {
                MessageBox.Show("Saved successfully!");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Save failed, try again.");
            }


        }

        private void txtAgreedPrice_TextChanged_1(object sender, EventArgs e)
        {
            RefreshAll();
        }

       
    }
}
