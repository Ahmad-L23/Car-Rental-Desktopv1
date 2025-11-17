using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsMaintenanceType
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? Id { get; set; }
        public string Name { get; set; }
        public int MileageInterval { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ClsMaintenanceType()
        {
            Id = null;
            Name = string.Empty;
            MileageInterval = 0;
            Description = string.Empty;
            IsActive = true;
            mode = enMode.AddNew;
        }

        public ClsMaintenanceType(
            int? id,
            string name,
            int mileageInterval,
            string description,
            bool isActive)
        {
            Id = id;
            Name = name;
            MileageInterval = mileageInterval;
            Description = description;
            IsActive = isActive;
            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;
            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewMaintenanceType();
                    break;
                case enMode.Update:
                    result = UpdateMaintenanceType();
                    break;
            }

            return result;
        }

        private bool AddNewMaintenanceType()
        {
            int newId = ClsMaintenanceTypeData.AddNewMaintenanceType(
                Name,
                MileageInterval,
                Description,
                IsActive);

            if (newId != -1)
            {
                Id = newId;
                return true;
            }
            return false;
        }

        private bool UpdateMaintenanceType()
        {
            if (!Id.HasValue)
                return false;

            bool result = ClsMaintenanceTypeData.EditMaintenanceType(
                Id.Value,
                Name,
                MileageInterval,
                Description,
                IsActive);

            return result;
        }

        public static bool DeleteMaintenanceType(int id)
        {
            return ClsMaintenanceTypeData.DeleteMaintenanceType(id);
        }

        public static ClsMaintenanceType FindById(int id)
        {
            string name = string.Empty;
            int mileageInterval = 0;
            string description = string.Empty;
            bool isActive = true;

            bool found = ClsMaintenanceTypeData.GetMaintenanceTypeById(
                id,
                ref name,
                ref mileageInterval,
                ref description,
                ref isActive);

            if (!found)
                return null;

            return new ClsMaintenanceType(
                id,
                name,
                mileageInterval,
                description,
                isActive);
        }

        public static DataTable GetMaintenanceTypesDataTable()
        {
            return ClsMaintenanceTypeData.GetAllMaintenanceTypes();
        }

        public static bool Exists(int id)
        {
            return ClsMaintenanceTypeData.MaintenanceTypeExists(id);
        }

        public static bool Exists(string name)
        {
            return ClsMaintenanceTypeData.MaintenanceTypeExists(name);
        }
    }
}
