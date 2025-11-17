using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsRequiredInsurance
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }

        // Default constructor for new record
        public ClsRequiredInsurance()
        {
            Id = null;
            ItemName = string.Empty;
            Price = 0;
            mode = enMode.AddNew;
        }

        // Constructor for existing record
        public ClsRequiredInsurance(int id, string itemName, decimal price)
        {
            Id = id;
            ItemName = itemName;
            Price = price;
            mode = enMode.Update;
        }

        // Save method (Add or Update)
        public bool Save()
        {
            bool result = false;

            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewRequiredInsurance();
                    break;
                case enMode.Update:
                    result = UpdateRequiredInsurance();
                    break;
            }

            return result;
        }

        private bool AddNewRequiredInsurance()
        {
            int newId = ClsRequiredInsuranceData.AddNewRequiredInsurance(ItemName, Price);
            if (newId != -1)
            {
                Id = newId;
                mode = enMode.Update;
                return true;
            }
            return false;
        }

        private bool UpdateRequiredInsurance()
        {
            if (!Id.HasValue)
                return false;

            return ClsRequiredInsuranceData.EditRequiredInsurance(Id.Value, ItemName, Price);
        }

        public static bool Delete(int id)
        {
            return ClsRequiredInsuranceData.DeleteRequiredInsurance(id);
        }

        public static ClsRequiredInsurance FindById(int id)
        {
            string itemName = string.Empty;
            decimal price = 0;

            bool found = ClsRequiredInsuranceData.GetRequiredInsuranceById(id, ref itemName, ref price);

            if (!found)
                return null;

            return new ClsRequiredInsurance(id, itemName, price);
        }

        public static bool IsExist(int id)
        {
            return ClsRequiredInsuranceData.IsRequiredInsuranceExist(id);
        }

        public static bool IsItemNameExist(string itemName)
        {
            return ClsRequiredInsuranceData.IsItemNameExist(itemName);
        }

        public static DataTable GetAllInsurance()
        {
            return ClsRequiredInsuranceData.GetAllRequiredInsurance();
        }
    }
}
