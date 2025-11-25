namespace CarRentalSystem.Agreement
{
    partial class frmAddUpdateAgreement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbCars = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCar = new System.Windows.Forms.GroupBox();
            this.txtExitFuel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCurrentCounter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCarCategory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCarName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCarPlate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.txtCustmAddress = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCustPhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCustIdenetity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblRentalAdditionsTotal = new System.Windows.Forms.Label();
            this.lblAdditionContractTotal = new System.Windows.Forms.Label();
            this.lblRequiredInsuranceTotal = new System.Windows.Forms.Label();
            this.lblTotalAmountOfAdditions = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.otherAdditions = new System.Windows.Forms.Label();
            this.chOtherAdditions = new System.Windows.Forms.CheckedListBox();
            this.label23 = new System.Windows.Forms.Label();
            this.chAdditionInsurance = new System.Windows.Forms.CheckedListBox();
            this.label22 = new System.Windows.Forms.Label();
            this.chRequiredInsurance = new System.Windows.Forms.CheckedListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gbIncludetax = new System.Windows.Forms.GroupBox();
            this.lbltotalAmountIncTax = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.nuTaxrate = new System.Windows.Forms.NumericUpDown();
            this.gbPremmitedKillo = new System.Windows.Forms.GroupBox();
            this.nuPricePerAddKilo = new System.Windows.Forms.NumericUpDown();
            this.nuPremmitedMeters = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.chIncludePremitKillo = new System.Windows.Forms.CheckBox();
            this.chIncludeTax = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.dpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.nuPaidAmount = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dpRecivingDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.dpDelveringDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRentalDays = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAgreedPrice = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtLatePenalty = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.gbAgreementAndDuration = new System.Windows.Forms.GroupBox();
            this.cbDropOfbranch = new System.Windows.Forms.ComboBox();
            this.cbPickBranch = new System.Windows.Forms.ComboBox();
            this.gbCar.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbIncludetax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTaxrate)).BeginInit();
            this.gbPremmitedKillo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPricePerAddKilo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuPremmitedMeters)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPaidAmount)).BeginInit();
            this.gbAgreementAndDuration.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCars
            // 
            this.cbCars.FormattingEnabled = true;
            this.cbCars.Location = new System.Drawing.Point(103, 43);
            this.cbCars.Name = "cbCars";
            this.cbCars.Size = new System.Drawing.Size(157, 21);
            this.cbCars.TabIndex = 0;
            this.cbCars.SelectedIndexChanged += new System.EventHandler(this.cbCars_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Car";
            // 
            // gbCar
            // 
            this.gbCar.Controls.Add(this.txtExitFuel);
            this.gbCar.Controls.Add(this.label9);
            this.gbCar.Controls.Add(this.txtCurrentCounter);
            this.gbCar.Controls.Add(this.label8);
            this.gbCar.Controls.Add(this.txtYear);
            this.gbCar.Controls.Add(this.label7);
            this.gbCar.Controls.Add(this.txtCarCategory);
            this.gbCar.Controls.Add(this.label6);
            this.gbCar.Controls.Add(this.txtCarName);
            this.gbCar.Controls.Add(this.label5);
            this.gbCar.Controls.Add(this.txtCarPlate);
            this.gbCar.Controls.Add(this.label2);
            this.gbCar.Location = new System.Drawing.Point(12, 81);
            this.gbCar.Name = "gbCar";
            this.gbCar.Size = new System.Drawing.Size(352, 329);
            this.gbCar.TabIndex = 2;
            this.gbCar.TabStop = false;
            this.gbCar.Text = "Selected Car Info";
            // 
            // txtExitFuel
            // 
            this.txtExitFuel.Location = new System.Drawing.Point(102, 286);
            this.txtExitFuel.Name = "txtExitFuel";
            this.txtExitFuel.Size = new System.Drawing.Size(133, 20);
            this.txtExitFuel.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 289);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Exit Fuel";
            // 
            // txtCurrentCounter
            // 
            this.txtCurrentCounter.Location = new System.Drawing.Point(102, 237);
            this.txtCurrentCounter.Name = "txtCurrentCounter";
            this.txtCurrentCounter.Size = new System.Drawing.Size(133, 20);
            this.txtCurrentCounter.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Current Counter";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(102, 194);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(133, 20);
            this.txtYear.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Car Year";
            // 
            // txtCarCategory
            // 
            this.txtCarCategory.Location = new System.Drawing.Point(102, 145);
            this.txtCarCategory.Name = "txtCarCategory";
            this.txtCarCategory.Size = new System.Drawing.Size(133, 20);
            this.txtCarCategory.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Car Category";
            // 
            // txtCarName
            // 
            this.txtCarName.Location = new System.Drawing.Point(102, 101);
            this.txtCarName.Name = "txtCarName";
            this.txtCarName.Size = new System.Drawing.Size(133, 20);
            this.txtCarName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Car Name";
            // 
            // txtCarPlate
            // 
            this.txtCarPlate.Location = new System.Drawing.Point(102, 52);
            this.txtCarPlate.Name = "txtCarPlate";
            this.txtCarPlate.Size = new System.Drawing.Size(133, 20);
            this.txtCarPlate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Car Plate Number";
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.txtCustmAddress);
            this.gbCustomer.Controls.Add(this.label12);
            this.gbCustomer.Controls.Add(this.txtCustPhone);
            this.gbCustomer.Controls.Add(this.label11);
            this.gbCustomer.Controls.Add(this.txtCustName);
            this.gbCustomer.Controls.Add(this.label10);
            this.gbCustomer.Controls.Add(this.txtCustIdenetity);
            this.gbCustomer.Controls.Add(this.label3);
            this.gbCustomer.Location = new System.Drawing.Point(399, 81);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(352, 306);
            this.gbCustomer.TabIndex = 5;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Selected Customer Info";
            // 
            // txtCustmAddress
            // 
            this.txtCustmAddress.Location = new System.Drawing.Point(102, 197);
            this.txtCustmAddress.Name = "txtCustmAddress";
            this.txtCustmAddress.Size = new System.Drawing.Size(133, 20);
            this.txtCustmAddress.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Address";
            // 
            // txtCustPhone
            // 
            this.txtCustPhone.Location = new System.Drawing.Point(102, 148);
            this.txtCustPhone.Name = "txtCustPhone";
            this.txtCustPhone.Size = new System.Drawing.Size(133, 20);
            this.txtCustPhone.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Phone Nubmer";
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(102, 104);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(133, 20);
            this.txtCustName.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Customer Name";
            // 
            // txtCustIdenetity
            // 
            this.txtCustIdenetity.Location = new System.Drawing.Point(102, 52);
            this.txtCustIdenetity.Name = "txtCustIdenetity";
            this.txtCustIdenetity.Size = new System.Drawing.Size(133, 20);
            this.txtCustIdenetity.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Identity Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Select Custmer";
            // 
            // cbCustomers
            // 
            this.cbCustomers.FormattingEnabled = true;
            this.cbCustomers.Location = new System.Drawing.Point(489, 43);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(157, 21);
            this.cbCustomers.TabIndex = 3;
            this.cbCustomers.SelectedIndexChanged += new System.EventHandler(this.cbCustomers_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblRentalAdditionsTotal);
            this.groupBox4.Controls.Add(this.lblAdditionContractTotal);
            this.groupBox4.Controls.Add(this.lblRequiredInsuranceTotal);
            this.groupBox4.Controls.Add(this.lblTotalAmountOfAdditions);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.otherAdditions);
            this.groupBox4.Controls.Add(this.chOtherAdditions);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.chAdditionInsurance);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.chRequiredInsurance);
            this.groupBox4.Location = new System.Drawing.Point(1, 429);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(594, 360);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Insurances and Additions";
            // 
            // lblRentalAdditionsTotal
            // 
            this.lblRentalAdditionsTotal.AutoSize = true;
            this.lblRentalAdditionsTotal.Location = new System.Drawing.Point(378, 274);
            this.lblRentalAdditionsTotal.Name = "lblRentalAdditionsTotal";
            this.lblRentalAdditionsTotal.Size = new System.Drawing.Size(25, 13);
            this.lblRentalAdditionsTotal.TabIndex = 28;
            this.lblRentalAdditionsTotal.Text = "???";
            // 
            // lblAdditionContractTotal
            // 
            this.lblAdditionContractTotal.AutoSize = true;
            this.lblAdditionContractTotal.Location = new System.Drawing.Point(204, 274);
            this.lblAdditionContractTotal.Name = "lblAdditionContractTotal";
            this.lblAdditionContractTotal.Size = new System.Drawing.Size(25, 13);
            this.lblAdditionContractTotal.TabIndex = 27;
            this.lblAdditionContractTotal.Text = "???";
            // 
            // lblRequiredInsuranceTotal
            // 
            this.lblRequiredInsuranceTotal.AutoSize = true;
            this.lblRequiredInsuranceTotal.Location = new System.Drawing.Point(58, 273);
            this.lblRequiredInsuranceTotal.Name = "lblRequiredInsuranceTotal";
            this.lblRequiredInsuranceTotal.Size = new System.Drawing.Size(25, 13);
            this.lblRequiredInsuranceTotal.TabIndex = 26;
            this.lblRequiredInsuranceTotal.Text = "???";
            // 
            // lblTotalAmountOfAdditions
            // 
            this.lblTotalAmountOfAdditions.AutoSize = true;
            this.lblTotalAmountOfAdditions.Font = new System.Drawing.Font("Microsoft Yi Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountOfAdditions.Location = new System.Drawing.Point(121, 321);
            this.lblTotalAmountOfAdditions.Name = "lblTotalAmountOfAdditions";
            this.lblTotalAmountOfAdditions.Size = new System.Drawing.Size(37, 15);
            this.lblTotalAmountOfAdditions.TabIndex = 25;
            this.lblTotalAmountOfAdditions.Text = "???";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Yi Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(19, 321);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(88, 15);
            this.label25.TabIndex = 24;
            this.label25.Text = "Total Amount";
            // 
            // otherAdditions
            // 
            this.otherAdditions.AutoSize = true;
            this.otherAdditions.Location = new System.Drawing.Point(359, 26);
            this.otherAdditions.Name = "otherAdditions";
            this.otherAdditions.Size = new System.Drawing.Size(79, 13);
            this.otherAdditions.TabIndex = 23;
            this.otherAdditions.Text = "Other Additions";
            // 
            // chOtherAdditions
            // 
            this.chOtherAdditions.FormattingEnabled = true;
            this.chOtherAdditions.Location = new System.Drawing.Point(394, 55);
            this.chOtherAdditions.Name = "chOtherAdditions";
            this.chOtherAdditions.Size = new System.Drawing.Size(185, 199);
            this.chOtherAdditions.TabIndex = 22;
            this.chOtherAdditions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chOtherAdditions_ItemCheck);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(171, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(93, 13);
            this.label23.TabIndex = 21;
            this.label23.Text = "Additon Insurance";
            // 
            // chAdditionInsurance
            // 
            this.chAdditionInsurance.FormattingEnabled = true;
            this.chAdditionInsurance.HorizontalScrollbar = true;
            this.chAdditionInsurance.Location = new System.Drawing.Point(202, 55);
            this.chAdditionInsurance.Name = "chAdditionInsurance";
            this.chAdditionInsurance.Size = new System.Drawing.Size(144, 199);
            this.chAdditionInsurance.TabIndex = 20;
            this.chAdditionInsurance.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chAdditionInsurance_ItemCheck);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(105, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "Required Insurances";
            // 
            // chRequiredInsurance
            // 
            this.chRequiredInsurance.CheckOnClick = true;
            this.chRequiredInsurance.FormattingEnabled = true;
            this.chRequiredInsurance.Location = new System.Drawing.Point(6, 55);
            this.chRequiredInsurance.Name = "chRequiredInsurance";
            this.chRequiredInsurance.Size = new System.Drawing.Size(190, 199);
            this.chRequiredInsurance.TabIndex = 0;
            this.chRequiredInsurance.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chRequiredInsurance_ItemCheck);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.gbIncludetax);
            this.groupBox5.Controls.Add(this.gbPremmitedKillo);
            this.groupBox5.Controls.Add(this.chIncludePremitKillo);
            this.groupBox5.Controls.Add(this.chIncludeTax);
            this.groupBox5.Location = new System.Drawing.Point(601, 429);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(700, 306);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "KilloMeters and Total Amount";
            // 
            // gbIncludetax
            // 
            this.gbIncludetax.Controls.Add(this.lbltotalAmountIncTax);
            this.gbIncludetax.Controls.Add(this.label31);
            this.gbIncludetax.Controls.Add(this.label30);
            this.gbIncludetax.Controls.Add(this.label29);
            this.gbIncludetax.Controls.Add(this.nuTaxrate);
            this.gbIncludetax.Location = new System.Drawing.Point(316, 38);
            this.gbIncludetax.Name = "gbIncludetax";
            this.gbIncludetax.Size = new System.Drawing.Size(373, 227);
            this.gbIncludetax.TabIndex = 1;
            this.gbIncludetax.TabStop = false;
            this.gbIncludetax.Text = "Include Addition Tax(VAT)";
            // 
            // lbltotalAmountIncTax
            // 
            this.lbltotalAmountIncTax.AutoSize = true;
            this.lbltotalAmountIncTax.Location = new System.Drawing.Point(220, 174);
            this.lbltotalAmountIncTax.Name = "lbltotalAmountIncTax";
            this.lbltotalAmountIncTax.Size = new System.Drawing.Size(25, 13);
            this.lbltotalAmountIncTax.TabIndex = 5;
            this.lbltotalAmountIncTax.Text = "???";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(14, 172);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(187, 16);
            this.label31.TabIndex = 4;
            this.label31.Text = "Total amount including tax";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Sitka Banner", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(13, 106);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(349, 21);
            this.label30.TabIndex = 3;
            this.label30.Text = "Total Amount is (Basic Price + Additions + Appling Tax)";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(14, 57);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(65, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "Tax Rate(%)";
            // 
            // nuTaxrate
            // 
            this.nuTaxrate.Location = new System.Drawing.Point(82, 55);
            this.nuTaxrate.Name = "nuTaxrate";
            this.nuTaxrate.Size = new System.Drawing.Size(141, 20);
            this.nuTaxrate.TabIndex = 1;
            this.nuTaxrate.ValueChanged += new System.EventHandler(this.nuTaxrate_ValueChanged);
            // 
            // gbPremmitedKillo
            // 
            this.gbPremmitedKillo.Controls.Add(this.nuPricePerAddKilo);
            this.gbPremmitedKillo.Controls.Add(this.nuPremmitedMeters);
            this.gbPremmitedKillo.Controls.Add(this.label28);
            this.gbPremmitedKillo.Controls.Add(this.label27);
            this.gbPremmitedKillo.Location = new System.Drawing.Point(6, 38);
            this.gbPremmitedKillo.Name = "gbPremmitedKillo";
            this.gbPremmitedKillo.Size = new System.Drawing.Size(304, 227);
            this.gbPremmitedKillo.TabIndex = 0;
            this.gbPremmitedKillo.TabStop = false;
            this.gbPremmitedKillo.Text = "Permitted kilometers";
            // 
            // nuPricePerAddKilo
            // 
            this.nuPricePerAddKilo.Location = new System.Drawing.Point(150, 92);
            this.nuPricePerAddKilo.Name = "nuPricePerAddKilo";
            this.nuPricePerAddKilo.Size = new System.Drawing.Size(142, 20);
            this.nuPricePerAddKilo.TabIndex = 17;
            // 
            // nuPremmitedMeters
            // 
            this.nuPremmitedMeters.Location = new System.Drawing.Point(149, 50);
            this.nuPremmitedMeters.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nuPremmitedMeters.Name = "nuPremmitedMeters";
            this.nuPremmitedMeters.Size = new System.Drawing.Size(142, 20);
            this.nuPremmitedMeters.TabIndex = 16;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(2, 94);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(142, 13);
            this.label28.TabIndex = 14;
            this.label28.Text = "Price per additional kilometer";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(2, 52);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(112, 13);
            this.label27.TabIndex = 12;
            this.label27.Text = "Premmited killo Meters";
            // 
            // chIncludePremitKillo
            // 
            this.chIncludePremitKillo.AutoSize = true;
            this.chIncludePremitKillo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chIncludePremitKillo.Location = new System.Drawing.Point(295, 18);
            this.chIncludePremitKillo.Name = "chIncludePremitKillo";
            this.chIncludePremitKillo.Size = new System.Drawing.Size(15, 14);
            this.chIncludePremitKillo.TabIndex = 0;
            this.chIncludePremitKillo.UseVisualStyleBackColor = true;
            this.chIncludePremitKillo.CheckedChanged += new System.EventHandler(this.chIncludePremitKillo_CheckedChanged);
            // 
            // chIncludeTax
            // 
            this.chIncludeTax.AutoSize = true;
            this.chIncludeTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chIncludeTax.Location = new System.Drawing.Point(674, 19);
            this.chIncludeTax.Name = "chIncludeTax";
            this.chIncludeTax.Size = new System.Drawing.Size(15, 14);
            this.chIncludeTax.TabIndex = 0;
            this.chIncludeTax.UseVisualStyleBackColor = true;
            this.chIncludeTax.CheckedChanged += new System.EventHandler(this.chIncludeTax_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label36);
            this.groupBox8.Controls.Add(this.dpPaymentDate);
            this.groupBox8.Controls.Add(this.cbPaymentMethod);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Controls.Add(this.nuPaidAmount);
            this.groupBox8.Controls.Add(this.label34);
            this.groupBox8.Controls.Add(this.label33);
            this.groupBox8.Location = new System.Drawing.Point(1321, 429);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(369, 265);
            this.groupBox8.TabIndex = 18;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Payment and Financial authorization";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(27, 228);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(74, 13);
            this.label36.TabIndex = 22;
            this.label36.Text = "Payment Date";
            // 
            // dpPaymentDate
            // 
            this.dpPaymentDate.Location = new System.Drawing.Point(120, 222);
            this.dpPaymentDate.Name = "dpPaymentDate";
            this.dpPaymentDate.Size = new System.Drawing.Size(186, 20);
            this.dpPaymentDate.TabIndex = 21;
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(120, 181);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(186, 21);
            this.cbPaymentMethod.TabIndex = 20;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(27, 181);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(87, 13);
            this.label35.TabIndex = 19;
            this.label35.Text = "Payment Method";
            // 
            // nuPaidAmount
            // 
            this.nuPaidAmount.Location = new System.Drawing.Point(120, 134);
            this.nuPaidAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nuPaidAmount.Name = "nuPaidAmount";
            this.nuPaidAmount.Size = new System.Drawing.Size(186, 20);
            this.nuPaidAmount.TabIndex = 18;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(27, 136);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(67, 13);
            this.label34.TabIndex = 1;
            this.label34.Text = "Paid Amount";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(26, 73);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(183, 16);
            this.label33.TabIndex = 0;
            this.label33.Text = "Insurance/ Initial payment";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(678, 750);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(437, 67);
            this.button1.TabIndex = 19;
            this.button1.Text = "Confirm The Resrivation";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Pickup Branch";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Drop Of Branch";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Reciving Date";
            // 
            // dpRecivingDate
            // 
            this.dpRecivingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpRecivingDate.Location = new System.Drawing.Point(102, 145);
            this.dpRecivingDate.Name = "dpRecivingDate";
            this.dpRecivingDate.Size = new System.Drawing.Size(178, 20);
            this.dpRecivingDate.TabIndex = 7;
            this.dpRecivingDate.ValueChanged += new System.EventHandler(this.dpRecivingDate_ValueChanged_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 192);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Delvring Date";
            // 
            // dpDelveringDate
            // 
            this.dpDelveringDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDelveringDate.Location = new System.Drawing.Point(102, 188);
            this.dpDelveringDate.Name = "dpDelveringDate";
            this.dpDelveringDate.Size = new System.Drawing.Size(178, 20);
            this.dpDelveringDate.TabIndex = 9;
            this.dpDelveringDate.ValueChanged += new System.EventHandler(this.dpDelveringDate_ValueChanged_1);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(305, 55);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "Number of rental days";
            // 
            // txtRentalDays
            // 
            this.txtRentalDays.Enabled = false;
            this.txtRentalDays.Location = new System.Drawing.Point(425, 52);
            this.txtRentalDays.Name = "txtRentalDays";
            this.txtRentalDays.Size = new System.Drawing.Size(178, 20);
            this.txtRentalDays.TabIndex = 11;
            this.txtRentalDays.TextChanged += new System.EventHandler(this.txtRentalDays_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(305, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 12;
            this.label19.Text = "Agreed price";
            // 
            // txtAgreedPrice
            // 
            this.txtAgreedPrice.Location = new System.Drawing.Point(425, 97);
            this.txtAgreedPrice.Name = "txtAgreedPrice";
            this.txtAgreedPrice.Size = new System.Drawing.Size(178, 20);
            this.txtAgreedPrice.TabIndex = 13;
            this.txtAgreedPrice.TextChanged += new System.EventHandler(this.txtAgreedPrice_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(305, 144);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 13);
            this.label20.TabIndex = 14;
            this.label20.Text = "Late penalty per day";
            // 
            // txtLatePenalty
            // 
            this.txtLatePenalty.Location = new System.Drawing.Point(425, 141);
            this.txtLatePenalty.Name = "txtLatePenalty";
            this.txtLatePenalty.Size = new System.Drawing.Size(178, 20);
            this.txtLatePenalty.TabIndex = 15;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(305, 197);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 16;
            this.label21.Text = "Total Price";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Enabled = false;
            this.txtTotalPrice.Location = new System.Drawing.Point(425, 194);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(178, 20);
            this.txtTotalPrice.TabIndex = 17;
            this.txtTotalPrice.TextChanged += new System.EventHandler(this.txtTotalPrice_TextChanged);
            // 
            // gbAgreementAndDuration
            // 
            this.gbAgreementAndDuration.Controls.Add(this.cbDropOfbranch);
            this.gbAgreementAndDuration.Controls.Add(this.cbPickBranch);
            this.gbAgreementAndDuration.Controls.Add(this.txtTotalPrice);
            this.gbAgreementAndDuration.Controls.Add(this.label21);
            this.gbAgreementAndDuration.Controls.Add(this.txtLatePenalty);
            this.gbAgreementAndDuration.Controls.Add(this.label20);
            this.gbAgreementAndDuration.Controls.Add(this.txtAgreedPrice);
            this.gbAgreementAndDuration.Controls.Add(this.label19);
            this.gbAgreementAndDuration.Controls.Add(this.txtRentalDays);
            this.gbAgreementAndDuration.Controls.Add(this.label18);
            this.gbAgreementAndDuration.Controls.Add(this.dpDelveringDate);
            this.gbAgreementAndDuration.Controls.Add(this.label17);
            this.gbAgreementAndDuration.Controls.Add(this.dpRecivingDate);
            this.gbAgreementAndDuration.Controls.Add(this.label13);
            this.gbAgreementAndDuration.Controls.Add(this.label15);
            this.gbAgreementAndDuration.Controls.Add(this.label16);
            this.gbAgreementAndDuration.Location = new System.Drawing.Point(778, 81);
            this.gbAgreementAndDuration.Name = "gbAgreementAndDuration";
            this.gbAgreementAndDuration.Size = new System.Drawing.Size(628, 257);
            this.gbAgreementAndDuration.TabIndex = 8;
            this.gbAgreementAndDuration.TabStop = false;
            this.gbAgreementAndDuration.Text = "Agreement Duration and Pricing";
            // 
            // cbDropOfbranch
            // 
            this.cbDropOfbranch.FormattingEnabled = true;
            this.cbDropOfbranch.Location = new System.Drawing.Point(102, 103);
            this.cbDropOfbranch.Name = "cbDropOfbranch";
            this.cbDropOfbranch.Size = new System.Drawing.Size(178, 21);
            this.cbDropOfbranch.TabIndex = 19;
            this.cbDropOfbranch.SelectedIndexChanged += new System.EventHandler(this.cbDropOfbranch_SelectedIndexChanged);
            // 
            // cbPickBranch
            // 
            this.cbPickBranch.FormattingEnabled = true;
            this.cbPickBranch.Location = new System.Drawing.Point(102, 52);
            this.cbPickBranch.Name = "cbPickBranch";
            this.cbPickBranch.Size = new System.Drawing.Size(178, 21);
            this.cbPickBranch.TabIndex = 18;
            this.cbPickBranch.SelectedIndexChanged += new System.EventHandler(this.cbPickBranch_SelectedIndexChanged);
            // 
            // frmAddUpdateAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 820);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbAgreementAndDuration);
            this.Controls.Add(this.gbCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbCar);
            this.Controls.Add(this.cbCustomers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCars);
            this.Name = "frmAddUpdateAgreement";
            this.Text = "frmAddUpdateAgreement";
            this.Load += new System.EventHandler(this.frmAddUpdateAgreement_Load);
            this.gbCar.ResumeLayout(false);
            this.gbCar.PerformLayout();
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbIncludetax.ResumeLayout(false);
            this.gbIncludetax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTaxrate)).EndInit();
            this.gbPremmitedKillo.ResumeLayout(false);
            this.gbPremmitedKillo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPricePerAddKilo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuPremmitedMeters)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPaidAmount)).EndInit();
            this.gbAgreementAndDuration.ResumeLayout(false);
            this.gbAgreementAndDuration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCar;
        private System.Windows.Forms.TextBox txtCarCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCarName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCarPlate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.TextBox txtCustIdenetity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.TextBox txtExitFuel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCurrentCounter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCustmAddress;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label otherAdditions;
        private System.Windows.Forms.CheckedListBox chOtherAdditions;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckedListBox chAdditionInsurance;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckedListBox chRequiredInsurance;
        private System.Windows.Forms.Label lblTotalAmountOfAdditions;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox gbPremmitedKillo;
        private System.Windows.Forms.CheckBox chIncludePremitKillo;
        private System.Windows.Forms.GroupBox gbIncludetax;
        private System.Windows.Forms.CheckBox chIncludeTax;
        private System.Windows.Forms.NumericUpDown nuPricePerAddKilo;
        private System.Windows.Forms.NumericUpDown nuPremmitedMeters;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown nuTaxrate;
        private System.Windows.Forms.Label lbltotalAmountIncTax;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.DateTimePicker dpPaymentDate;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown nuPaidAmount;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dpRecivingDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dpDelveringDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtRentalDays;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtAgreedPrice;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtLatePenalty;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.GroupBox gbAgreementAndDuration;
        private System.Windows.Forms.ComboBox cbPickBranch;
        private System.Windows.Forms.ComboBox cbDropOfbranch;
        private System.Windows.Forms.Label lblRequiredInsuranceTotal;
        private System.Windows.Forms.Label lblAdditionContractTotal;
        private System.Windows.Forms.Label lblRentalAdditionsTotal;
    }
}