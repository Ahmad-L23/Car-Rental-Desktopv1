using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsCompanyInsurance
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? CompanyInsuranceID { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int InsuranceTypeID { get; set; }
        public bool IsActive { get; set; }

        public ClsCompanyInsurance()
        {
            CompanyInsuranceID = null;
            InsuranceCompanyName = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            InsuranceTypeID = 0;
            IsActive = true;
            mode = enMode.AddNew;
        }

        public ClsCompanyInsurance(
            int? companyInsuranceId,
            string insuranceCompanyName,
            string phone,
            string email,
            int insuranceTypeId,
            bool isActive)
        {
            CompanyInsuranceID = companyInsuranceId;
            InsuranceCompanyName = insuranceCompanyName;
            Phone = phone;
            Email = email;
            InsuranceTypeID = insuranceTypeId;
            IsActive = isActive;

            mode = enMode.Update;
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    return AddNewCompanyInsurance();
                case enMode.Update:
                    return UpdateCompanyInsurance();
                default:
                    return false;
            }
        }

        private bool AddNewCompanyInsurance()
        {
            int newId = ClsCompanyInsuranceData.AddNewCompanyInsurance(
                InsuranceCompanyName,
                Phone,
                Email,
                InsuranceTypeID,
                IsActive);

            if (newId != -1)
            {
                CompanyInsuranceID = newId;
                return true;
            }
            return false;
        }

        private bool UpdateCompanyInsurance()
        {
            if (!CompanyInsuranceID.HasValue)
                return false;

            return ClsCompanyInsuranceData.EditCompanyInsurance(
                CompanyInsuranceID.Value,
                InsuranceCompanyName,
                Phone,
                Email,
                InsuranceTypeID,
                IsActive);
        }

        public static bool DeleteCompanyInsurance(int companyInsuranceId)
        {
            return ClsCompanyInsuranceData.DeleteCompanyInsurance(companyInsuranceId);
        }

        public static ClsCompanyInsurance FindById(int companyInsuranceId)
        {
            string insuranceCompanyName = "";
            string phone = "";
            string email = "";
            int insuranceTypeId = 0;
            bool isActive = true;

            bool found = ClsCompanyInsuranceData.GetCompanyInsuranceById(
                companyInsuranceId,
                ref insuranceCompanyName,
                ref phone,
                ref email,
                ref insuranceTypeId,
                ref isActive);

            if (!found)
                return null;

            return new ClsCompanyInsurance(
                companyInsuranceId,
                insuranceCompanyName,
                phone,
                email,
                insuranceTypeId,
                isActive);
        }

        public static DataTable GetCompanyInsurancesDataTable()
        {
            return ClsCompanyInsuranceData.GetAllCompanyInsurances();
        }

        public static DataTable GetAllCompanyInsurancesWithTypeName()
        {
            return ClsCompanyInsuranceData.GetAllCompanyInsurancesWithTypeName();
        }

        public static bool IsCompanyInsuranceExist(int companyInsuranceId)
        {
            return ClsCompanyInsuranceData.IsCompanyInsuranceExist(companyInsuranceId);
        }
    }
}
