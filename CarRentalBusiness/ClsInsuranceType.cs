using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsInsuranceType
    {
        private enum enMode { AddNew, Update }
        private enMode mode = enMode.AddNew;

        public int? InsuranceTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoverageID { get; set; }
        public int TargetClientID { get; set; }
        public bool IsActive { get; set; }
        public string InsuranceImage { get; set; }

        public ClsInsuranceType()
        {
            InsuranceTypeID = null;
            Name = "";
            Description = "";
            CoverageID = 0;
            TargetClientID = 0;
            IsActive = true;
            InsuranceImage = "";
            mode = enMode.AddNew;
        }

        public ClsInsuranceType(
            int insuranceTypeId,
            string name,
            string description,
            int coverageId,
            int targetClientId,
            bool isActive,
            string insuranceImage)
        {
            InsuranceTypeID = insuranceTypeId;
            Name = name;
            Description = description;
            CoverageID = coverageId;
            TargetClientID = targetClientId;
            IsActive = isActive;
            InsuranceImage = insuranceImage;
            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;

            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewInsuranceType();
                    break;
                case enMode.Update:
                    result = UpdateInsuranceType();
                    break;
            }

            return result;
        }

        private bool AddNewInsuranceType()
        {
            int id = ClsInsuranceTypeData.AddNewInsuranceType(
                Name,
                Description,
                CoverageID,
                TargetClientID,
                IsActive,
                InsuranceImage);

            if (id != -1)
            {
                InsuranceTypeID = id;
                mode = enMode.Update;
                return true;
            }
            return false;
        }

        private bool UpdateInsuranceType()
        {
            if (!InsuranceTypeID.HasValue)
                return false;

            bool result = ClsInsuranceTypeData.EditInsuranceType(
                InsuranceTypeID.Value,
                Name,
                Description,
                CoverageID,
                TargetClientID,
                IsActive,
                InsuranceImage);

            return result;
        }

        public static bool DeleteInsuranceType(int insuranceTypeId)
        {
            return ClsInsuranceTypeData.DeleteInsuranceType(insuranceTypeId);
        }

        public static ClsInsuranceType FindById(int insuranceTypeId)
        {
            string name = "";
            string description = "";
            int coverageId = 0;
            int targetClientId = 0;
            bool isActive = true;
            string insuranceImage = "";

            bool found = ClsInsuranceTypeData.GetInsuranceTypeById(
                insuranceTypeId,
                ref name,
                ref description,
                ref coverageId,
                ref targetClientId,
                ref isActive,
                ref insuranceImage);

            if (!found)
                return null;

            return new ClsInsuranceType(
                insuranceTypeId,
                name,
                description,
                coverageId,
                targetClientId,
                isActive,
                insuranceImage);
        }

        public static DataTable GetAllInsuranceTypes()
        {
            return ClsInsuranceTypeData.GetAllInsuranceTypes();
        }

        public static bool InsuranceExist(int insuranceTypeId)
        {
            return ClsInsuranceTypeData.InsuranceExist(insuranceTypeId);
        }

        public static bool InsuranceExist(string name)
        {
            return ClsInsuranceTypeData.InsuranceExist(name);
        }
    }
}
