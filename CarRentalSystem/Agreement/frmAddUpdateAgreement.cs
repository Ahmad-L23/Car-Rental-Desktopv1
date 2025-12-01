using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalSystem.Agreement
{
    public partial class frmAddUpdateAgreement : Form
    {
        private ClsAgreement _Agreement;
        private int? _AgreementId = null;
        decimal taxRate = 0m;

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

            // Do NOT subscribe to events here - handled in Designer or manually.

            // Initialize labels
            lblAdditionContractTotal.Text = "Total: 0.00";
            lblRentalAdditionsTotal.Text = "Total: 0.00";
            lblRequiredInsuranceTotal.Text = "Total: 0.00";
            lbltotalAmountIncTax.Text = "0.00";

            this.Load += frmAddUpdateAgreement_Load;
        }

        public frmAddUpdateAgreement(int agreementId) : this()
        {
            _AgreementId = agreementId;
            LoadAgreementData(agreementId);
            gbPremmitedKillo.Enabled = false;
            gbIncludetax.Enabled = false;
        }

        private void RefreshAll()
        {
            UpdateRentalDays();
            UpdateTotalPrice();
            UpdateTotalAmountOfAdditions();
            UpdateTotalIncludingTax();
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
            if(_Agreement.PermittedDailyKilometers.HasValue || _Agreement.AdditionalKilometerPrice.HasValue)
            {
                chIncludePremitKillo.Checked = true;
                gbPremmitedKillo.Enabled = true;
            }

            if(_Agreement.TaxRate > 0)
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

        private decimal SumCheckedItemsPrices(CheckedListBox clb)
        {
            decimal total = 0m;
            foreach (var item in clb.CheckedItems)
                if (item is Item i)
                    total += i.Price;
            return total;
        }

        private int GetLastSerialNumber() => ClsAgreement.GetLastSerialNumber() + 1;

        private void button1_Click(object sender, EventArgs e)
        {
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

        private decimal CalculateTotalIncludingTax()
        {
            decimal basePrice = 0m;
            decimal.TryParse(txtTotalPrice.Text, out basePrice);

            decimal additions = 0m;
            decimal.TryParse(lblTotalAmountOfAdditions.Text, out additions);

            decimal taxRate = nuTaxrate.Value;

            decimal taxAmount = basePrice * (taxRate / 100);

            return basePrice + taxAmount + additions;
        }

        private List<(int Id, decimal Price, string name)> GetCheckedItemsList(CheckedListBox clb)
        {
            var list = new List<(int Id, decimal Price, string name)>();
            foreach (var item in clb.CheckedItems)
            {
                if (item is Item i)
                    list.Add((i.Id, i.Price, i.Name));
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

        private void UpdateTotalIncludingTax()
        {
            if (!chIncludeTax.Checked)
            {
                lbltotalAmountIncTax.Text = "0.00";
                return;
            }

            decimal basePrice = 0m;
            decimal additions = 0m;
            

            decimal.TryParse(txtTotalPrice.Text, out basePrice);
            decimal.TryParse(lblTotalAmountOfAdditions.Text, out additions);

            if (nuTaxrate.Value == 0 && chIncludeTax.Checked)
                taxRate = 16;
            else if (!chIncludeTax.Checked)
                taxRate = 0;

            else
                taxRate = nuTaxrate.Value;


                decimal taxAmount = basePrice * (taxRate / 100);

                decimal totalIncludingTax = basePrice + taxAmount + additions;
                lbltotalAmountIncTax.Text = totalIncludingTax.ToString("F2");
            
        }

        private void frmAddUpdateAgreement_Load(object sender, EventArgs e)
        {
            if (_AgreementId == null)
            {
                lblAdditionContractTotal.Text = "Total: 0.00";
                lblRentalAdditionsTotal.Text = "Total: 0.00";
                lblRequiredInsuranceTotal.Text = "Total: 0.00";
            }
            RefreshAll();
        }

        // Then, inside all related control events, just call RefreshAll():
        private void dpRecivingDate_ValueChanged(object sender, EventArgs e) => RefreshAll();
        private void dpDelveringDate_ValueChanged(object sender, EventArgs e) => RefreshAll();

        
        private void chOtherAdditions_SelectedIndexChanged(object sender, EventArgs e) => RefreshAll();

        private void txtAgreedPrice_TextChanged(object sender, EventArgs e) => RefreshAll();
        private void txtRentalDays_TextChanged(object sender, EventArgs e) => RefreshAll();

        private void nuTaxrate_ValueChanged(object sender, EventArgs e) => RefreshAll();
        private void txtTotalPrice_TextChanged(object sender, EventArgs e) => RefreshAll();


       

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

        private void dpRecivingDate_ValueChanged_1(object sender, EventArgs e) => RefreshAll();

        private void dpDelveringDate_ValueChanged_1(object sender, EventArgs e) => RefreshAll();

        private void chRequiredInsurance_ItemCheck(object sender, ItemCheckEventArgs e)
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

        private void chAdditionInsurance_ItemCheck(object sender, ItemCheckEventArgs e)
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

        private void chOtherAdditions_ItemCheck(object sender, ItemCheckEventArgs e)
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

        private void chIncludeTax_CheckedChanged(object sender, EventArgs e)
        {
            gbIncludetax.Enabled = chIncludeTax.Checked;
            RefreshAll();
        }

        private void cbPickBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbDropOfbranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        // Other event handlers you already have can remain as is, just make sure to call RefreshAll() where necessary
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