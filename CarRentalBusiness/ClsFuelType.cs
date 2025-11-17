using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsFuelType
    {
        private enum enMode { AddNew, Update }
        private enMode mode = enMode.AddNew;

        public int? Id { get; set; }
        public string Name { get; set; }

        public ClsFuelType()
        {
            Id = null;
            Name = "";
            mode = enMode.AddNew;
        }

        public ClsFuelType(int? id, string name)
        {
            Id = id;
            Name = name ?? "";
            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;

            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewFuelType();
                    break;
                case enMode.Update:
                    result = UpdateFuelType();
                    break;
            }

            return result;
        }

        private bool AddNewFuelType()
        {
            int newId = ClsFuelTypeData.AddNewFuelType(Name);
            if (newId != -1)
            {
                Id = newId;
                mode = enMode.Update;  
                return true;
            }
            return false;
        }

        private bool UpdateFuelType()
        {
            if (!Id.HasValue)
                return false;

            return ClsFuelTypeData.EditFuelType(Id.Value, Name);
        }

        public static bool DeleteFuelType(int id)
        {
            return ClsFuelTypeData.DeleteFuelType(id);
        }

        public static ClsFuelType FindById(int id)
        {
            string name = null;
            bool found = ClsFuelTypeData.GetFuelTypeById(id, ref name);
            if (!found)
                return null;

            return new ClsFuelType(id, name);
        }

        public static DataTable GetFuelTypesDataTable()
        {
            return ClsFuelTypeData.GetAllFuelTypes();
        }

        public static bool FuelTypeExistsByName(string name)
        {
            return ClsFuelTypeData.FuelTypeExistsByName(name);
        }
    }
}



