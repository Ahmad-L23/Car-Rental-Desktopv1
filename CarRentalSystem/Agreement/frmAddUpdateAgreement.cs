using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalSystem.Agreement
{
    public partial class frmAddUpdateAgreement : Form
    {
        private ClsAgreement _Agreement;
        private int? _AgreementId = null;
        private decimal _TotalAmount = 0;
        decimal totalIncludingTax = 0;

        public frmAddUpdateAgreement()
        {
            InitializeComponent();

            LoadCars();
            LoadCustomers();
            LoadBranches();
            LoadAdditions();
            LoadPaymentMethods();
            gbPremmitedKillo.Enabled = false;
            gbIncludetax.Enabled = false;

            dpRecivingDate.ValueChanged += DateValueChanged;
            dpDelveringDate.ValueChanged += DateValueChanged;

            chRequiredInsurance.ItemCheck += CheckedListBox_ItemCheck;
            chAdditionInsurance.ItemCheck += CheckedListBox_ItemCheck;
            chOtherAdditions.ItemCheck += CheckedListBox_ItemCheck;


            // Clear total labels when adding new
            lblAdditionContractTotal.Text = "Total: 0.00";
            lblRentalAdditionsTotal.Text = "Total: 0.00";
            lblRequiredInsuranceTotal.Text = "Total: 0.00";
            lbltotalAmountIncTax.Text = "0.00";
            this.Load += frmAddUpdateAgreement_Load;

            UpdateTotalAmountOfAdditions();
        }

        public frmAddUpdateAgreement(int agreementId) : this()
        {
            _AgreementId = agreementId;
            LoadAgreementData(agreementId);
            gbPremmitedKillo.Enabled = false;
            gbIncludetax.Enabled = false;
        }

        private void DateValueChanged(object sender, EventArgs e)
        {
            int days = (dpDelveringDate.Value.Date - dpRecivingDate.Value.Date).Days;
            txtRentalDays.Text = (days < 0) ? "0" : days.ToString();


            if (chIncludeTax.Checked)
            {
                totalIncludingTax = CalculateTotalIncludingTax();

                lbltotalAmountIncTax.Text = totalIncludingTax.ToString("0.00");

            }
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
            txtTotalPrice.Text = _Agreement.TotalAmountBeforeTax.ToString("F2");
            nuPremmitedMeters.Value = _Agreement.PermittedDailyKilometers;
            nuPricePerAddKilo.Value = _Agreement.AdditionalKilometerPrice;
            nuTaxrate.Value = _Agreement.TaxRate;
            nuPaidAmount.Value = _Agreement.InitialPaidAmount ?? 0m;
            txtCurrentCounter.Text = (_Agreement.Mileage ?? 0).ToString();
            txtExitFuel.Text = _Agreement.ExitFuel ?? "";

            // Check checked items based on saved IDs
            CheckItemsInCheckedListBox(chAdditionInsurance, _Agreement.AdditionContracts.Select(x => x.Id).ToList());
            CheckItemsInCheckedListBox(chOtherAdditions, _Agreement.RentalAdditions.Select(x => x.Id).ToList());
            CheckItemsInCheckedListBox(chRequiredInsurance, _Agreement.RequiredInsurances.Select(x => x.Id).ToList());

            // Show saved totals in labels
            lblAdditionContractTotal.Text = $"Total: {_Agreement.AdditionContractPrice?.ToString("F2") ?? "0.00"}";
            lblRentalAdditionsTotal.Text = $"Total: {_Agreement.RentalAdditionsPrice?.ToString("F2") ?? "0.00"}";
            lblRequiredInsuranceTotal.Text = $"Total: {_Agreement.RequiredInsurancePrice?.ToString("F2") ?? "0.00"}";

            // Also update combined total label
            UpdateTotalAmountOfAdditions();

        }

        private void CheckItemsInCheckedListBox(CheckedListBox clb, List<int> ids)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (clb.Items[i] is Item item)
                    clb.SetItemChecked(i, ids.Contains(item.Id));
            }
        }

        private void LoadCars()
        {
            var dt = ClsCar.GetAllCarsIdsAndPlateNubmers();
            cbCars.DataSource = dt;
            cbCars.DisplayMember = "PlateNumber";
            cbCars.ValueMember = "CarID";
            cbCars.SelectedIndex = -1;
        }

        private void LoadCustomers()
        {
            var dt = ClsCustomer.GetCustomersDataTable();
            cbCustomers.DataSource = dt;
            cbCustomers.DisplayMember = "customer_name_en";
            cbCustomers.ValueMember = "customer_id";
            cbCustomers.SelectedIndex = -1;
        }

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
            cbPaymentMethod.DisplayMember = "MethodName";  // اسم طريقة الدفع للعرض
            cbPaymentMethod.ValueMember = "MethodName";    // القيمة (يمكن تغييرها حسب جدولك)
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

        private decimal SumCheckedItemsPrices(CheckedListBox clb)
        {
            decimal total = 0m;
            foreach (var item in clb.CheckedItems)
                if (item is Item i)
                    total += i.Price;
            return total;
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(() => UpdateTotalAmountOfAdditions()));
            }
            else
            {
                // Either do nothing or call directly (if safe)
                UpdateTotalAmountOfAdditions();
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

            // Optional: update combined total label if you have one
            decimal combinedTotal = additionTotal + rentalTotal + requiredTotal;
            lblTotalAmountOfAdditions.Text = combinedTotal.ToString("F2");

        }

        private int GetLastSerialNumber() => ClsAgreement.GetLastSerialNumber() + 1;

        private void button1_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
                return;

            if (chRequiredInsurance.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one required insurance .");
                return;
            }
            if (nuPaidAmount.Value == 0 || cbPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Pleas Fill Payment and Financial authorization");
                return;
            }

            if (!ValidateTextBoxesInGroupBox(gbAgreementAndDuration))
                return; // Block progress if validation fails

            if (_AgreementId == null)
                _Agreement = new ClsAgreement();
            else
                _Agreement = ClsAgreement.FindById(_AgreementId.Value);

            _Agreement.CarID = cbCars.SelectedValue is int carId ? carId : 0;
            _Agreement.CustomerID = cbCustomers.SelectedValue is int custId ? custId : 0;
            _Agreement.PickupBranchID = cbPickBranch.SelectedValue is int pickId ? pickId : 0;
            _Agreement.DropOffBranchID = cbDropOfbranch.SelectedValue is int dropId ? dropId : 0;

            _Agreement.StartDate = dpRecivingDate.Value;
            _Agreement.EndDate = dpDelveringDate.Value;
            _Agreement.AgreedPrice = decimal.TryParse(txtAgreedPrice.Text, out var ap) ? ap : 0m;
            _Agreement.RentalPenaltyPerDay = decimal.TryParse(txtLatePenalty.Text, out var penalty) ? penalty : 0m;
            _Agreement.TotalAmountBeforeTax = (decimal.TryParse(txtTotalPrice.Text, out var total) ? total : 0m) + (decimal.TryParse(lblTotalAmountOfAdditions.Text, out var totalOfAdditions) ? totalOfAdditions : 0m);
            if (chIncludeTax.Checked)
            {
                _Agreement.TotalIncludetax = CalculateTotalIncludingTax();
            }
            else
            {
                _Agreement.TotalIncludetax = 0;
            }
            _Agreement.RentalDaysCost = (decimal.TryParse(txtTotalPrice.Text, out var RentalDaysCost) ? RentalDaysCost : 0m);
            _Agreement.PermittedDailyKilometers = (int)nuPremmitedMeters.Value;
            _Agreement.AdditionalKilometerPrice = nuPricePerAddKilo.Value;
            _Agreement.TaxRate = nuTaxrate.Value;
            _Agreement.InitialPaidAmount = nuPaidAmount.Value;
            _Agreement.PaymentMethod = cbPaymentMethod.SelectedValue?.ToString() ?? "";
            _Agreement.PaymentDate = dpPaymentDate.Value;
            _Agreement.ActualDeliveryDate = DateTime.Now;
            _Agreement.Mileage = int.TryParse(txtCurrentCounter.Text, out int mileage) ? mileage : 0;
            _Agreement.ExitFuel = txtExitFuel.Text.Trim();
            _Agreement.SerialNumber = GetLastSerialNumber();

            _Agreement.AdditionContractPrice = SumCheckedItemsPrices(chAdditionInsurance);
            _Agreement.RentalAdditionsPrice = SumCheckedItemsPrices(chOtherAdditions);
            _Agreement.RequiredInsurancePrice = SumCheckedItemsPrices(chRequiredInsurance);

            // Fill lists of additions
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

        private decimal CalculateTotalIncludingTax()
        {
            decimal.TryParse(txtTotalPrice.Text, out decimal basePrice);
            decimal taxRate = nuTaxrate.Value;

            decimal taxAmount = basePrice * (taxRate / 100);

            decimal.TryParse(lblTotalAmountOfAdditions.Text, out decimal additions);
            taxAmount += additions;

            return taxAmount;
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


        private void ClearCarTextBoxes()
        {
            txtCarPlate.Text = "";
            txtCarName.Text = "";
            txtCarCategory.Text = "";
            txtYear.Text = "";
            txtCurrentCounter.Text = "";
            txtExitFuel.Text = "";
        }


        private void ClearCustomerTextBoxes()
        {
            txtCustIdenetity.Text = "";
            txtCustName.Text = "";
            txtCustPhone.Text = "";
            txtCustmAddress.Text = "";
        }

        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public override string ToString() => $"{Name} ({Price:F2})";
        }

        private void chIncludePremitKillo_CheckedChanged(object sender, EventArgs e)
        {
            gbPremmitedKillo.Enabled = chIncludePremitKillo.Checked;
        }

        private void chIncludeTax_CheckedChanged(object sender, EventArgs e)
        {
            gbIncludetax.Enabled = chIncludeTax.Checked;

            if (decimal.TryParse(txtTotalPrice.Text, out decimal price) && chIncludeTax.Checked && nuTaxrate.Value == 0)
            {
                decimal taxRate = 16; // example: 16
                decimal taxAmount = price * (taxRate / 100);
                totalIncludingTax = price + taxAmount;
                decimal.TryParse(lblTotalAmountOfAdditions.Text, out decimal additions);
                totalIncludingTax += additions;

                lbltotalAmountIncTax.Text = totalIncludingTax.ToString("0.00");
            }

            else if (chIncludeTax.Checked && nuTaxrate.Value > 0)
            {
                if (decimal.TryParse(txtTotalPrice.Text, out decimal price1))
                {
                    decimal taxRate = nuTaxrate.Value; // example: 16
                    decimal taxAmount = price * (taxRate / 100);
                    totalIncludingTax = price + taxAmount;

                    decimal.TryParse(lblTotalAmountOfAdditions.Text, out decimal additions);
                    totalIncludingTax += additions;
                    lbltotalAmountIncTax.Text = totalIncludingTax.ToString("0.00");
                }
            }

            else if (!chIncludeTax.Checked)
            {
                totalIncludingTax = 0;
                lbltotalAmountIncTax.Text = "0.00";
            }

        }

        private void frmAddUpdateAgreement_Load(object sender, EventArgs e)
        {
            chRequiredInsurance.ItemCheck += CheckedListBox_ItemCheck;
            chAdditionInsurance.ItemCheck += CheckedListBox_ItemCheck;
            chOtherAdditions.ItemCheck += CheckedListBox_ItemCheck;
            if (_AgreementId == null)
            {
                lblAdditionContractTotal.Text = "Total: 0.00";
                lblRentalAdditionsTotal.Text = "Total: 0.00";
                lblRequiredInsuranceTotal.Text = "Total: 0.00";
            }
        }



        private void cbCars_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbCars.SelectedIndex == -1)
            {
                e.Cancel = true; // cancel validation
                MessageBox.Show("Please select a car.");
                return;
            }

            int selectedCarId = (int)cbCars.SelectedValue;

            if (!ClsCar.IsAvaliable(selectedCarId))
            {
                e.Cancel = true; // cancel validation
                MessageBox.Show("This car is not available due to: " + ClsCar.UnavaliableReason(selectedCarId));
            }
        }

        private void chRequiredInsurance_SelectedIndexChanged(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (chRequiredInsurance.CheckedItems.Count == 0)
            {
                e.Cancel = true;
                MessageBox.Show("Please select at least one insurance option.");
            }
        }


        private void UpdateTotalPrice()
        {
            if (int.TryParse(txtRentalDays.Text, out int days) &&
                decimal.TryParse(txtAgreedPrice.Text, out decimal price))
            {
                decimal total = days * price;
                txtTotalPrice.Text = total.ToString();
            }
            else
            {
                txtTotalPrice.Text = "";
            }
        }
        private void txtRentalDays_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void txtAgreedPrice_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();

            if (chIncludeTax.Checked)
            {
                totalIncludingTax = CalculateTotalIncludingTax();

                lbltotalAmountIncTax.Text = totalIncludingTax.ToString("0.00");

            }
        }

        private bool ValidateTextBoxesInGroupBox(GroupBox group)
        {
            foreach (Control control in group.Controls)
            {
                if (control is TextBox tb)
                {
                    if (string.IsNullOrWhiteSpace(tb.Text))
                    {
                        MessageBox.Show($"Please fill the field: {tb.Name}");
                        tb.Focus();
                        return false;
                    }
                }
            }

            return true;
        }



        private void cbCars_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void nuTaxrate_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotalPrice.Text))
            {
                MessageBox.Show("Pleas Fill the related data for the Agreement Duration and Pricing");
                return;
            }
            else if (chRequiredInsurance.CheckedItems.Count == 0)
            {
                MessageBox.Show("Pleas Select at least one required insurance");
                return;
            }

            if (nuTaxrate.Value > 0 && chIncludeTax.Checked)
            {

                totalIncludingTax = CalculateTotalIncludingTax();

                lbltotalAmountIncTax.Text = totalIncludingTax.ToString("0.00");
            }
        }

        private void nuTaxrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotalPrice.Text))
            {
                MessageBox.Show("Pleas Fill the related data for the Agreement Duration and Pricing");
                return;
            }
            else if (chRequiredInsurance.CheckedItems.Count == 0)
            {
                MessageBox.Show("Pleas Select at least one required insurance");
                return;
            }

            if (nuTaxrate.Value > 0 && chIncludeTax.Checked)
            {


                totalIncludingTax = CalculateTotalIncludingTax();

                lbltotalAmountIncTax.Text = totalIncludingTax.ToString("0.00");
            }
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            if (chIncludeTax.Checked)
            {
                totalIncludingTax = CalculateTotalIncludingTax();

                lbltotalAmountIncTax.Text = totalIncludingTax.ToString("0.00");

            }
        }
    }
}

/*
 
  public int? AgreementID { get; set; }
        public int CustomerID { get; set; }
        ClsCustomer CustomerInfo { get; set; }
        public int CarID { get; set; }
        ClsCar CarInfo { get; set; }
        public int PickupBranchID { get; set; }
        public int DropOffBranchID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal AgreedPrice { get; set; }
        public decimal? RentalPenaltyPerDay { get; set; }
        public decimal TotalAmountBeforeTax { get; set; }
        public int PermittedDailyKilometers { get; set; }
        public decimal AdditionalKilometerPrice { get; set; }

        public decimal TaxRate { get; set; }
        public decimal? InitialPaidAmount { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime? PaymentDate { get; set; }

        public DateTime? ActualDeliveryDate { get; set; }
        public int? ReceivingOdometer { get; set; }
        public int? ConsumedMileage { get; set; }
        public int? Mileage { get; set; }

        string ExitFuel {  get; set; }
        public int SerialNumber { get; set; }
        public decimal? AdditionContractPrice { get; set; }
        public decimal? RentalAdditionsPrice { get; set; }
        public decimal? RequiredInsurancePrice { get; set; }

        public List<(int Id, decimal Price)> AdditionContracts { get; set; } = new List<(int, decimal)>();
        public List<(int Id, decimal Price)> RentalAdditions { get; set; } = new List<(int, decimal)>();
        public List<(int Id, decimal Price)> RequiredInsurances { get; set; } = new List<(int, decimal)>();
 
 */