using CarRentalDataAccess;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRentalBusiness
{
    public class clsRentalInsurance
    {

        enum enMode { Add, Update}

        public int Id { get; set; }
        public string Name { get; set; }
        public int PaymentMethodId { get; set; }
        public double Price { get; set; }
        public string status {  get; set; }
        public bool isActive { get; set; }
        public bool includeTax { get; set; }
        public string Notes { get; set; }

        ClsPaymentMethod paymentMethod { get; set; }

        private enMode Mode = enMode.Add;



        public clsRentalInsurance()
        {
            Id = 0;
            Name = string.Empty;
            PaymentMethodId = 0;
            Price = 0;  
            status = string.Empty;
            isActive = false;
            includeTax = false;
            Notes = string.Empty;
            Mode = enMode.Add;

        }


        public clsRentalInsurance(int id, string name, int paymentMethodId, double price, string status, bool isActive, bool includeTax, string notes)
        {

           
            Id = id;
            Name = name??"";
            PaymentMethodId = paymentMethodId;
            paymentMethod = ClsPaymentMethod.FindById(paymentMethodId);
            Price = price;
            this.status = status??"";
            this.isActive = isActive;
            this.includeTax = includeTax;
            Notes = notes ?? "";
            Mode = enMode.Update;
        }




        private bool _AddRentalInsurance()
        {
            Id = clsRentalInsurancesData.AddNewRentalInsurance(Name, PaymentMethodId, Price, status, isActive, includeTax, Notes);

            return (Id != -1);
        }

        private bool _UpdateRentalInsurance()

        {
            return clsRentalInsurancesData.UpdateRentalInsurance(Id, Name, PaymentMethodId, Price, status, isActive, includeTax, Notes);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    return _AddRentalInsurance();

                case enMode.Update:
                    return _UpdateRentalInsurance();
                   
            }
            return false;
        }


        public static bool DeleteRentalInsurance(int RetnalInsuranceID)
        {
          return  clsRentalInsurancesData.DeleteRentalInsuracne (RetnalInsuranceID);
        }


        public static DataTable GetAllRentalInsuarance()
        {
            return clsRentalInsurancesData.GetAllRentalInsuracne();
        }

        public static clsRentalInsurance FindRentalInsuranceById(int id)
        {
            string name = "";
            int PaymentMethod =0;
            double Price = 0;
            string status = "";
            bool includeTax = false;
            bool Active = false;
            string notes = "";

            bool result = clsRentalInsurancesData.FindRentalInsuranceById(id, ref name, ref PaymentMethod, ref Price, ref status, ref includeTax, ref Active, ref notes);

            if (result)
            {
               return new clsRentalInsurance(id, name, PaymentMethod, Price, status, Active, includeTax, notes); 
            }
            return null; 
        }

        public static DataTable GetAllRentalInsurance()
        {
            return clsRentalInsurancesData.GetAllRentalInsuracne();
        }
    }
}
