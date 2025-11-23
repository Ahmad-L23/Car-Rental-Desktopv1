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

namespace CarRentalSystem.Vehicle
{
    //PlateNumber, Chassis, Type, Groupname, model, EngineSize, status
    public partial class ucShowVehicleDetalis : UserControl
    {
        public ucShowVehicleDetalis()
        {
            InitializeComponent();
        }


        public void ShowCarDetalis(string plateNumber)
        {
            if (string.IsNullOrWhiteSpace(plateNumber))
            {
                ClearValues();
                return;
            }

            // Assuming you have this method to fetch one car by plate number in your BLL
            ClsCar car = ClsCar.FindCarSummaryByPlateNumber(plateNumber);

            if (car == null)
            {
                ClearValues();
                return;
            }

            // Set label texts, or ??? if null/empty
            valPlateNumber.Text = string.IsNullOrWhiteSpace(car.PlateNumber) ? "???" : car.PlateNumber;
            valChassis.Text = string.IsNullOrWhiteSpace(car.ChassisNumber) ? "???" : car.ChassisNumber;
            valType.Text = string.IsNullOrWhiteSpace(car.CarNameEn) ? "???" : car.CarNameEn;

            // Group name from the Group object if available
            valGroup.Text = car.Group != null && !string.IsNullOrWhiteSpace(car.Group.Name)
                ? car.Group.Name
                : "???";

            valModel.Text = car.Year > 0 ? car.Year.ToString() : "???";

            valEngineSize.Text = car.EngineSize > 0 ? car.EngineSize.ToString("0.##") : "???";

            valStatus.Text = car.IsAvailable ? "Available" : "Not Available";
            valStatus.ForeColor = car.IsAvailable ? Color.Green : Color.Red;
        }

        private void ClearValues()
        {
            valPlateNumber.Text = "???";
            valChassis.Text = "???";
            valType.Text = "???";
            valGroup.Text = "???";
            valModel.Text = "???";
            valEngineSize.Text = "???";
            valStatus.Text = "???";
        }

    }
}
