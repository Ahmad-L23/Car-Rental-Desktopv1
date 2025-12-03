using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
            LoadAgreements();
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

    

        private void UpdateMode(int agreementId)
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




            lblAdditionalInsurance.Text = "";
            foreach (var item in  _Agreement.AdditionContracts)
            {
                
                lblAdditionalInsurance.Text += item.Name + " (" + item.Price.ToString() + "), ";
            }

                      lblOtherAdditionsShow.Text = "";
            foreach (var item in  _Agreement.RentalAdditions)
            {
                
                lblOtherAdditionsShow.Text +=  item.Name + " (" + item.Price.ToString() + "), ";
            }

            lblShowRequiredInsurance.Text = "";
            foreach (var item in  _Agreement.RequiredInsurances)
            {
                
                lblShowRequiredInsurance.Text += item.Name + " (" + item.Price.ToString() + "), ";
            }




            txtLateFee.Text = _Agreement.RentalPenaltyPerDay.ToString();






            decimal totalAdditions = (decimal)((decimal)_Agreement.AdditionContractPrice + (decimal)_Agreement.RentalAdditionsPrice + _Agreement.RequiredInsurancePrice);
            
            
            lblShowBasePrice.Text = _Agreement.RentalDaysCost.ToString();





            lblSubTotalShow.Text = _Agreement.TotalAmountBeforeTax.ToString();


            lblShowTax.Text = _Agreement.TaxRate.ToString() + "%";

            if (_Agreement.PermittedDailyKilometers > 0)
            {
                
                lblShowAddionalKiloPrice.Text = _Agreement.AdditionalKilometerPrice.ToString();
            }

            lblShowLateFee.Text = "0.00";

            if (_Agreement.TaxRate > 0)
            {

                lblShowFinalTotala.Text = _Agreement.TotalIncludetax.ToString();
                txtEntryPrice.Text = _Agreement.TotalIncludetax?.ToString();
            }
            else
            {
                lblShowFinalTotala.Text = _Agreement.TotalAmountBeforeTax.ToString();
                txtEntryPrice.Text = (_Agreement.TotalAmountBeforeTax - _Agreement.InitialPaidAmount).ToString();
            }


            lblShowPaidAmount.Text = _Agreement.InitialPaidAmount.ToString();



           
            txtPaidAmount.Text = _Agreement.InitialPaidAmount?.ToString();



            if(_Agreement.ActualDeliveryDate != null)
            {
                dpEntryDate.Value = _Agreement.ActualDeliveryDate.Value;
            }

            if(_Agreement.ReceivingOdometer != null)
            {
                txtEntryCounter.Text = _Agreement.ReceivingOdometer.ToString();
            }

            if(_Agreement.ConsumedMileage != null)
            {
                txtMovedDistance.Text = _Agreement.ConsumedMileage.ToString();
            }

            if (_Agreement.Discount.HasValue)
                lblDisountShow.Text = _Agreement.Discount.ToString();
            else
                lblDisountShow.Text = "0.00";


            //RefreshAll();
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
            UpdateIncludeKilo();
            UpdateSideSectionTotals();
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


        private List<(int Id, decimal Price, string name)> GetCheckedItemsList(CheckedListBox clb)
        {
            var list = new List<(int Id, decimal Price,string name)>();
            foreach (var item in clb.CheckedItems)
            {
                if (item is Item i)
                    list.Add((i.Id, i.Price, i.Name));
            }
            return list;
        }

        private void GetNameAndPriceOfCheckedItem(Label text ,CheckedListBox clb)
        {
            text.Text = "";
            foreach (var item in clb.CheckedItems)
            {
                text.Text += item.ToString() + ", ";
                
            }
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

            if ((nuTaxrate.Value == 0 || string.IsNullOrEmpty(nuTaxrate.Value.ToString())) && chIncludeTax.Checked)
                taxRate = 16;

            else
                taxRate = nuTaxrate.Value;

            decimal TotalPrice = basePrice + additions;
            decimal taxAmount = TotalPrice * (taxRate / 100);

            decimal totalIncludingTax = basePrice + taxAmount + additions;
            lbltotalAmountIncTax.Text = totalIncludingTax.ToString("F2");

        }


        private void UpdateIncludeKilo()
        {
            if (!chIncludePremitKillo.Checked)
            {
                nuPremmitedMeters.Value = 0;
                nuPricePerAddKilo.Value = 0;
                //return;
            }
            if(string.IsNullOrEmpty(nuPremmitedMeters.Value.ToString()) &&  chIncludePremitKillo.Checked)
            {
                nuPremmitedMeters.Value = 0;
            }

            if(string.IsNullOrEmpty(nuPricePerAddKilo.Value.ToString()) && chIncludePremitKillo.Checked)
            {
                nuPricePerAddKilo.Value = 0; 
            }

            lblKiloPrice.Text = nuPricePerAddKilo.Value.ToString();
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



        private void ClearInputs()
        {

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


                _Agreement = new ClsAgreement();



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

            if(decimal.TryParse(txtDiscount.Text, out decimal Discount) && Discount>0)
            {
                _Agreement.Discount = Discount;
            }
            else
            {
                _Agreement.Discount = null;
            }


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
                
            }
            else
            {
                MessageBox.Show("Save failed, try again.");
            }

            LoadAgreements();

        }

        private void txtAgreedPrice_TextChanged_1(object sender, EventArgs e)
        {
            RefreshAll();
        }



        private void UpdateSideSectionTotals()
        {

            decimal subTotal = 0;
            lblDays.Text = txtRentalDays.Text + " Days";
            lblPrice.Text = txtTotalPrice.Text;

            lblRequired.Text = "";
            lblAdditionsInsurances.Text = "";
            lblAdditions.Text = "";

            GetNameAndPriceOfCheckedItem(lblRequired, chRequiredInsurance);
            GetNameAndPriceOfCheckedItem(lblAdditionsInsurances, chAdditionInsurance);
            GetNameAndPriceOfCheckedItem(lblAdditions, chOtherAdditions);


            if (decimal.TryParse(txtTotalPrice.Text, out decimal TotalPrice))
            {
                subTotal = TotalPrice + Convert.ToDecimal(lblTotalAmountOfAdditions.Text);
                lblSubTotPrice.Text = subTotal.ToString();
            }
            else
                lblSubTotPrice.Text = "0.00";

            if (chIncludeTax.Checked && nuTaxrate.Value > 0)
            {
                TaxPrice.Text = nuTaxrate.Value.ToString();
            }
            else if (chIncludeTax.Checked && nuTaxrate.Value == 0)
            {
                TaxPrice.Text = "16";
            }
            else
            {
                TaxPrice.Text = "0.00";
                nuTaxrate.Value = 0;
            }

            if (chIncludePremitKillo.Checked)
            {
                lblKiloPrice.Text = nuPricePerAddKilo.Value.ToString();
            }

            lblFeePrice.Text = txtLatePenalty.Text;

            int AdditonalKiloPrice = 0;
            if (int.TryParse(txtTotalPrice.Text, out AdditonalKiloPrice) && chIncludePremitKillo.Checked)
            {
                AdditonalKiloPrice += AdditonalKiloPrice;
            }


            else
                AdditonalKiloPrice = 0;



            if (chIncludeTax.Checked)
            {

                lblFinalPrice.Text = (Convert.ToDecimal(lbltotalAmountIncTax.Text) + AdditonalKiloPrice).ToString();
            }
            else
            {

                lblFinalPrice.Text = (subTotal + AdditonalKiloPrice).ToString();

            }//txtTotalPrice    lblTotalAmountOfAdditions

            if(string.IsNullOrEmpty(nuPaidAmount.Value.ToString()))
            {
                lblPaidAmountA.Text = "0.00";
            }
            else
                lblPaidAmountA.Text = nuPaidAmount.Value.ToString();

            decimal Discount = 0;

            decimal.TryParse(txtDiscount.Text, out Discount);

             lblDiscount.Text = Discount.ToString();

            decimal DueAmount = Convert.ToDecimal(lblFinalPrice.Text) - nuPaidAmount.Value - Discount;
            lblDueBalance.Text = DueAmount.ToString();

        }

        private void chIncludePremitKillo_CheckedChanged(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void txtLatePenalty_TextChanged(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void nuPaidAmount_ValueChanged(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void nuPricePerAddKilo_KeyPress(object sender, KeyPressEventArgs e)
        {
            RefreshAll();
        }

        private void nuPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            RefreshAll();
        }


        private void LoadAgreements()
        {
            var dt = ClsAgreement.GetAllAgreements();

            cbAgree.DataSource = dt;
            cbAgree.DisplayMember = "SerialNumber";
            cbAgree.ValueMember = "AgreementID";
            cbAgree.SelectedIndex = -1;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cbAgreement.SelectedValue == null) return;

            if (cbAgreement.SelectedValue == null || cbAgreement.SelectedIndex == -1)
                return;

            // Safe conversion
            if (!int.TryParse(cbAgreement.SelectedValue.ToString(), out int AgreementId))
                return;

           

            UpdateMode(AgreementId);
        }

    
    
        private void txtAgreedPrice_TextChanged_2(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void dpRecivingDate_ValueChanged_1(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void dpDelveringDate_ValueChanged_1(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void txtLatePenalty_TextChanged_1(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void txtTotalPrice_TextChanged_1(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void chIncludeTax_CheckedChanged_1(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void nuPricePerAddKilo_KeyDown(object sender, KeyEventArgs e)
        {
            RefreshAll();
        }

        private void chIncludePremitKillo_CheckedChanged_1(object sender, EventArgs e)
        {
            if(!chIncludePremitKillo.Checked)
            {
                nuPremmitedMeters.Enabled = false;
                nuPricePerAddKilo.Enabled = false;
            }
            else
            {
                nuPremmitedMeters.Enabled = true;
                nuPricePerAddKilo.Enabled = true;
            }
                RefreshAll();
        }

        private void nuPricePerAddKilo_ValueChanged(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void nuTaxrate_ValueChanged_2(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void nuPaidAmount_KeyDown(object sender, KeyEventArgs e)
        {
            RefreshAll();
        }



        decimal PriceOfAdditaonalDistance = 0;
        void UpdateSideSectionUpdateMode()
        {
            int latedays = (dpEntryDate.Value.Date - _Agreement.EndDate).Days;
            decimal lateFee = 0;

            if (_Agreement.RentalPenaltyPerDay > 0)
            {
                lateFee = (decimal)(latedays * (_Agreement.RentalPenaltyPerDay));
            }

            txtDiffrencesDays.Text = latedays.ToString();
            
            lblShowLateFee.Text = lateFee.ToString();

            // base price (with or without tax)
            decimal basePrice = (decimal)(_Agreement.TaxRate > 0
                ? _Agreement.TotalIncludetax
                : _Agreement.TotalAmountBeforeTax);

            lblShowFinalTotala.Text = basePrice.ToString();

            // Entry Price (what customer should pay now)
            txtEntryPrice.Text = (basePrice - _Agreement.InitialPaidAmount).ToString();

            // Distance calculation
            if (int.TryParse(txtEntryCounter.Text, out int eCounter))
            {
                int MovedDistance = (int)(eCounter - _Agreement.Mileage);
                MovedDistance = MovedDistance > 0 ? MovedDistance : 0;
                txtMovedDistance.Text = MovedDistance.ToString();


                int AdditonalDistance = (int)(MovedDistance - _Agreement?.PermittedDailyKilometers?? 0);
                txtAdditionalDistance.Text = AdditonalDistance.ToString();
                if (MovedDistance > _Agreement.PermittedDailyKilometers)
                {
                    PriceOfAdditaonalDistance = (decimal)(AdditonalDistance * _Agreement.AdditionalKilometerPrice);
                    lblShowAddionalKiloPrice.Text = PriceOfAdditaonalDistance.ToString();
                }
                else
                {
                    PriceOfAdditaonalDistance = 0;
                    lblShowAddionalKiloPrice.Text = "0.00";
                }
            }
            else
            {
                PriceOfAdditaonalDistance = 0;
                lblShowAddionalKiloPrice.Text = "0.00";
            }

            // Final price (base + late + additional KM)
            decimal FinalPrice = (decimal)(_Agreement.TotalAmountBeforeTax + lateFee + PriceOfAdditaonalDistance);
            decimal AddTax = 0;               
            if(_Agreement.TaxRate>0)
            {
                AddTax = FinalPrice * ( _Agreement.TaxRate / 100);
            }
            FinalPrice += AddTax;

            lblShowFinalTotala.Text = FinalPrice.ToString();
            if(_Agreement.Discount.HasValue)
             lblShowDueBalanceUpdate.Text = (FinalPrice - _Agreement.InitialPaidAmount - _Agreement.Discount).ToString();

            else
                lblShowDueBalanceUpdate.Text = (FinalPrice - _Agreement.InitialPaidAmount).ToString();

        }


        private void dpEntryDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateSideSectionUpdateMode();
        }

        private void txtEntryCounter_TextChanged(object sender, EventArgs e)
        {
            UpdateSideSectionUpdateMode();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmUpdates_Click(object sender, EventArgs e)
        {
            if (cbCarEntryFuel.SelectedIndex == -1|| string.IsNullOrEmpty(txtEntryCounter.Text) || dpEntryDate.Value.Date < DateTime.Now)
            {
                MessageBox.Show("Pleas Fill the Car entry information");
                return;
            }

            _Agreement = ClsAgreement.FindById((int)_AgreementId);

            _Agreement.ReceivingOdometer = Convert.ToInt32(txtEntryCounter.Text);
            _Agreement.ConsumedMileage = Convert.ToInt32(txtMovedDistance.Text);
            _Agreement.ActualDeliveryDate = dpEntryDate.Value;
            



            if(_Agreement.Save())
            {
                MessageBox.Show("Saved Successfull");
            }
            else
            {
                MessageBox.Show("Something went wrong while saving");
            }

        }

        private void cbAgree_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbAgree.SelectedValue == null) return;

            if (cbAgree.SelectedValue == null || cbAgree.SelectedIndex == -1)
                return;

            // Safe conversion
            if (!int.TryParse(cbAgree.SelectedValue.ToString(), out int AgreementId))
                return;


            UpdateMode(AgreementId);
            UpdateSideSectionUpdateMode();

        }

        private void label103_Click(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            RefreshAll();
            
        }

        private void txtAgreedPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; 
            }

          
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true; 
            }
        }

        private void txtLatePenalty_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true; 
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; 
            }

           
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
