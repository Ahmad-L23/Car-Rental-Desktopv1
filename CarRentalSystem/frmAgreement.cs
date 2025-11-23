
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CarRentalBusiness;

namespace CurtainDemo
{
    public partial class frmAgreement : Form
    {
        // Customer Toggle State and Animation Settings
        private bool customerPanelExpanded = false;
        private readonly int customerPanelMaxHeight = 170; // Height of pnlCustomerDetails

        // Car Toggle State and Animation Settings
        private bool carPanelExpanded = false;
        private readonly int carPanelMaxHeight = 215; // Height of pnlCarDetails

        private readonly int panelMinHeight = 0;
        private readonly Timer animationTimer;

        public frmAgreement()
        {
            InitializeComponent();

            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += AnimationTimer_Tick;

            // Customer Toggle Logic
            btnToggle.Click += (s, e) => { ToggleCustomerPanel(); };
            cmbCustomers.SelectedIndexChanged += CmbCustomers_SelectedIndexChanged;

            // Car Toggle Logic
            btnToggleCar.Click += (s, e) => { ToggleCarPanel(); };
            cmbCars.SelectedIndexChanged += CmbCars_SelectedIndexChanged;

            // Initialize panel heights to collapsed state
            pnlCustomerDetails.Height = panelMinHeight;
            pnlCarDetails.Height = panelMinHeight;
            pnlCarDetails.Top = pnlCustomerDetails.Bottom + 5; // Initial positioning

            btnToggle.Text = "Show Customer Details";
            btnToggleCar.Text = "Show Car Details";

            cmbCustomers.Enabled = false;
            cmbCars.Enabled = false;

            LoadData();
        }

        private void LoadData()
        {
            // Load Customer Data (Assumes ClsCustomer.GetCustomersDataTable exists)
            var dtCustomers = ClsCustomer.GetCustomersDataTable();
            if (dtCustomers != null && dtCustomers.Rows.Count > 0)
            {
                cmbCustomers.DataSource = dtCustomers;
                cmbCustomers.DisplayMember = "customer_name_en";
                cmbCustomers.ValueMember = "customer_id";
            }
            else
            {
                cmbCustomers.DataSource = null;
            }
            cmbCustomers.SelectedIndex = -1;

            // Load Car Data (Assumes ClsCar.GetAllCars exists and returns CarID/PlateNumber)
            var dtCars = ClsCar.GetAllCars();
            if (dtCars != null && dtCars.Rows.Count > 0)
            {
                cmbCars.DataSource = dtCars;
                cmbCars.DisplayMember = "PlateNumber";
                cmbCars.ValueMember = "CarID";
            }
            else
            {
                cmbCars.DataSource = null;
            }
            cmbCars.SelectedIndex = -1;
        }

        // --- Toggle Helpers ---

        private void ToggleCustomerPanel()
        {
            customerPanelExpanded = !customerPanelExpanded;
            btnToggle.Enabled = false;
            animationTimer.Start();
        }

        private void ToggleCarPanel()
        {
            carPanelExpanded = !carPanelExpanded;
            btnToggleCar.Enabled = false;
            animationTimer.Start();
        }


        // --- CUSTOMER LOGIC ---

        private void CmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedIndex == -1)
            {
                ClearCustomerDetails();
                return;
            }

            if (cmbCustomers.SelectedItem is DataRowView drv && drv["customer_id"] != DBNull.Value)
            {
                var id = Convert.ToInt32(drv["customer_id"]);
                var customer = ClsCustomer.FindById(id);
                if (customer != null) DisplayCustomerDetails(customer);
                else ClearCustomerDetails();
            }
            else ClearCustomerDetails();
        }

        private void DisplayCustomerDetails(ClsCustomer c)
        {
            txtIdentityNumber.Text = c.IdentityNumber ?? "";
            txtName.Text = c.CustomerNameEn ?? "";
            txtPhoneNumber.Text = c.PhoneNumber ?? "";
            txtAddress.Text = c.AddressEn ?? "";
        }

        private void ClearCustomerDetails()
        {
            txtIdentityNumber.Text = txtName.Text = txtPhoneNumber.Text = txtAddress.Text = "";
        }

        // --- CAR LOGIC ---

        private void CmbCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCars.SelectedIndex == -1)
            {
                ClearCarDetails();
                return;
            }

            if (cmbCars.SelectedItem is DataRowView drv && drv["CarID"] != DBNull.Value)
            {
                var id = Convert.ToInt32(drv["CarID"]);
                var car = ClsCar.FindById(id);
                if (car != null) DisplayCarDetails(car);
                else ClearCarDetails();
            }
            else ClearCarDetails();


        }

        private void DisplayCarDetails(ClsCar c)
        {
            txtPlateNumber.Text = c.PlateNumber ?? "";
            txtCarName.Text = c.CarNameEn ?? "";

            // Get Category Name from the composed object
            txtCarCategory.Text = c.Category?.NameEn ?? "N/A";

            txtCarYear.Text = c.Year.ToString();
            txtCurrentCounter.Text = c.CurrentCounter.ToString();
            txtFuelExit.Text = "";

            
        }

        private void ClearCarDetails()
        {
            txtPlateNumber.Text = txtCarName.Text = txtCarCategory.Text =
            txtCarYear.Text = txtCurrentCounter.Text = txtFuelExit.Text = "";
        }

        // --- ANIMATION LOGIC (Unified Timer) ---

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            const int step = 10;
            bool customerAnimationComplete = true;
            bool carAnimationComplete = true;

            // 1. Animate Customer Panel
            if (customerPanelExpanded)
            {
                pnlCustomerDetails.Height = Math.Min(pnlCustomerDetails.Height + step, customerPanelMaxHeight);
                if (pnlCustomerDetails.Height != customerPanelMaxHeight)
                    customerAnimationComplete = false;
                else
                {
                    btnToggle.Text = "Hide Customer Details";
                    btnToggle.Enabled = true;
                    cmbCustomers.Enabled = cmbCustomers.DataSource != null;
                }
            }
            else // Collapsing
            {
                pnlCustomerDetails.Height = Math.Max(pnlCustomerDetails.Height - step, panelMinHeight);
                if (pnlCustomerDetails.Height != panelMinHeight)
                    customerAnimationComplete = false;
                else
                {
                    btnToggle.Text = "Show Customer Details";
                    btnToggle.Enabled = true;
                    cmbCustomers.Enabled = false;
                }
            }

            // 2. Animate Car Panel
            if (carPanelExpanded)
            {
                pnlCarDetails.Height = Math.Min(pnlCarDetails.Height + step, carPanelMaxHeight);
                if (pnlCarDetails.Height != carPanelMaxHeight)
                    carAnimationComplete = false;
                else
                {
                    btnToggleCar.Text = "Hide Car Details";
                    btnToggleCar.Enabled = true;
                    cmbCars.Enabled = cmbCars.DataSource != null;
                }
            }
            else // Collapsing
            {
                pnlCarDetails.Height = Math.Max(pnlCarDetails.Height - step, panelMinHeight);
                if (pnlCarDetails.Height != panelMinHeight)
                    carAnimationComplete = false;
                else
                {
                    btnToggleCar.Text = "Show Car Details";
                    btnToggleCar.Enabled = true;
                    cmbCars.Enabled = false;
                }
            }

            // Reposition the Car Panel below the Customer Panel
            pnlCarDetails.Top = pnlCustomerDetails.Bottom + 5;

            // Stop the timer only when BOTH animations are complete
            if (customerAnimationComplete && carAnimationComplete)
            {
                animationTimer.Stop();
            }
        }
    }
}