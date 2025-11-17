using CarRentalSystem.Coverge;
using CarRentalSystem.Target_Clients;
using CarRentalSystem.PaymentMethods;  // <-- add this
using System;
using System.Windows.Forms;
using CarRentalSystem.MaintenanceTypes;
using CarRentalSystem.AdditionContracts;
using CarRentalSystem.RequiredInsurances;

namespace CarRentalSystem.Setting
{
    public partial class frmSettings : Form
    {
        private ucCoverages _ucCoverages;
        private ucTargetClients _ucTargetClients;
        private ucPaymentMethods _ucPaymentMethods;  // <-- add this
        private ucMaintenanceTypes _ucMaintenanceTypes;
        private ucAdditionContracts _ucAdditionContracts;
        private ucRequiredInsurances _ucRequiredInsurances;

        public frmSettings()
        {
            InitializeComponent();
            SetupSidebar();
        }

        private void SetupSidebar()
        {
            string[] sidebarItems = { "Coverages", "Target Clients", "Payment Methods", "Maintenance Types", "Additons Contracts", "Required Insurances" };

            listBoxSidebar.Items.Clear();

            foreach (var item in sidebarItems)
            {
                listBoxSidebar.Items.Add(item);
            }

            listBoxSidebar.SelectedIndexChanged += ListBoxSidebar_SelectedIndexChanged;

            // Instantiate UserControls once
            _ucCoverages = new ucCoverages();
            _ucTargetClients = new ucTargetClients();
            _ucPaymentMethods = new ucPaymentMethods();
            _ucMaintenanceTypes = new ucMaintenanceTypes();
            _ucAdditionContracts = new ucAdditionContracts();
            _ucRequiredInsurances = new ucRequiredInsurances();
            listBoxSidebar.SelectedIndex = 0;

        }

        private void ListBoxSidebar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = listBoxSidebar.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected)) return;

            panelMain.Controls.Clear();

            switch (selected)
            {
                case "Coverages":
                    _ucCoverages.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(_ucCoverages);
                    break;

                case "Target Clients":
                    _ucTargetClients.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(_ucTargetClients);
                    break;

                case "Payment Methods":
                    _ucPaymentMethods.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(_ucPaymentMethods);
                    break;

                case "Maintenance Types":
                    _ucMaintenanceTypes.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(_ucMaintenanceTypes);
                    break;
                
                case "Additons Contracts":
                    _ucAdditionContracts.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(_ucAdditionContracts);
                    break;

                case "Required Insurances":
                    _ucRequiredInsurances.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(_ucRequiredInsurances);
                    break;
            }
        }
    }
}
