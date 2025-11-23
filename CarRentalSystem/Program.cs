
using CarRentalSystem.AdditionContracts;
using CarRentalSystem.Agreement;
using CarRentalSystem.Box;
using CarRentalSystem.Branch;
using CarRentalSystem.Car;
using CarRentalSystem.CarTransfer;
using CarRentalSystem.Category;
using CarRentalSystem.Company;
using CarRentalSystem.CompanyInsurance;
using CarRentalSystem.Coverge;
using CarRentalSystem.Currency;
using CarRentalSystem.Customer;
using CarRentalSystem.DamageMaintenance;
using CarRentalSystem.DamagesMaintenance;
using CarRentalSystem.EmployeeUsage;
using CarRentalSystem.EmployeeUsageForms;
using CarRentalSystem.Group;
using CarRentalSystem.InsuranceType;
using CarRentalSystem.Location;
using CarRentalSystem.maintenance;
using CarRentalSystem.mediator;
using CarRentalSystem.Nationlity;
using CarRentalSystem.PaymentMethod;
using CarRentalSystem.Quires;
using CarRentalSystem.RentalAddition;
using CarRentalSystem.RequiredInsurance;
using CarRentalSystem.Role;
using CarRentalSystem.Setting;
using CarRentalSystem.Target_Clients;
using CarRentalSystem.Users;
using CarRentalSystem.Vehicle;
using CurtainDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmAddUpdateAgreement()); 
        }
    }
}
