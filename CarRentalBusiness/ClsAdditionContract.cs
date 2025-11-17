using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsAdditionContract
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ClsAdditionContract()
        {
            Id = null;
            Name = "";
            Price = 0;
            mode = enMode.AddNew;
        }

        public ClsAdditionContract(int? id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;
            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewAdditionContract();
                    break;
                case enMode.Update:
                    result = UpdateAdditionContract();
                    break;
            }
            return result;
        }

        private bool AddNewAdditionContract()
        {
            int newId = ClsAdditionContractsData.AddNewAdditionContract(Name, Price);

            if (newId != -1)
            {
                Id = newId;
                return true;
            }
            return false;
        }

        private bool UpdateAdditionContract()
        {
            if (!Id.HasValue)
                return false;

            return ClsAdditionContractsData.EditAdditionContract(Id.Value, Name, Price);
        }

        public static bool DeleteAdditionContract(int id)
        {
            return ClsAdditionContractsData.DeleteAdditionContract(id);
        }

        public static ClsAdditionContract FindById(int id)
        {
            string name = "";
            decimal price = 0;

            bool found = ClsAdditionContractsData.GetAdditionContractById(id, ref name, ref price);

            if (!found)
                return null;

            return new ClsAdditionContract(id, name, price);
        }

        public static DataTable GetAdditionContractsDataTable()
        {
            return ClsAdditionContractsData.GetAllAdditionContracts();
        }

        public static bool IsAdditionContractExist(int id)
        {
            return ClsAdditionContractsData.IsAdditionContractExist(id);
        }
    }
}
