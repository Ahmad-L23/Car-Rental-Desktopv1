using CarRentalSystem.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.Quires
{
    public partial class frmQuery : Form
    {
        private ucShowVehicleDetalis _vehicleDetalis;
        public frmQuery()
        {
            InitializeComponent();

        }

        //                Customer Mediator  Agreement
        private void cbQuiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQuiers.SelectedIndex == 0)
            {
                lblSearch.Text = "PlateNumber";

            }
            else if (cbQuiers.SelectedIndex == 1)
            {
                lblSearch.Text = "Customer Name";
            }

            else if (cbQuiers.SelectedIndex == 2)
            {
                lblSearch.Text = "Mediator Name";
            }
            else
            {
                lblSearch.Text = "Agreement Nubmer";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchFor = txtSearch.Text.Trim();

            if (cbQuiers.SelectedIndex == 0) // Car search by plate number
            {
                if (_vehicleDetalis == null)
                {
                    _vehicleDetalis = new ucShowVehicleDetalis();

                    _vehicleDetalis.Dock = DockStyle.Fill;
                    pDetalis.Controls.Add(_vehicleDetalis);
                  
                }

                _vehicleDetalis.ShowCarDetalis(searchFor);
            }
            else if (cbQuiers.SelectedIndex == 1)
            {
                MessageBox.Show("Not Implemented yet");
            }
            else if (cbQuiers.SelectedIndex == 2)
            {
                MessageBox.Show("Not Implemented yet");
            }
            else
            {
                MessageBox.Show("Not Implemented yet");
            }
        }
    }
}
