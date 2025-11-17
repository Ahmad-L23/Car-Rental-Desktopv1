using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsUser
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? UserId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmployeeNumber { get; set; }
        public string NationalId { get; set; }
        public ClsNationlity Nationality { get; set; }  // Assuming ClsNationality class exists
        public ClsRole Role { get; set; }                // Assuming ClsRole class exists
        public ClsBranch Branch { get; set; }            // Assuming ClsBranch class exists
        public string LicenseNumber { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }

        public int? nationalityId { get; set; }
        public int? roleId {  get; set; }
        public int? branchId { get; set; }
        public ClsUser()
        {
            UserId = null;
            NameEn = "";
            NameAr = "";
            UserName = "";
            Email = "";
            Password = "";
            EmployeeNumber = "";
            NationalId = "";
            Nationality = null;
            Role = null;
            Branch = null;
            LicenseNumber = "";
            LicenseExpiryDate = null;
            PrimaryPhoneNumber = "";
            SecondaryPhoneNumber = "";
            mode = enMode.AddNew;
        }

        public ClsUser(
            int? userId,
            string nameEn,
            string nameAr,
            string userName,
            string email,
            string password,
            string employeeNumber,
            string nationalId,
            int? nationalityId,
            int? roleId,
            int? branchId,
            string licenseNumber,
            DateTime? licenseExpiryDate,
            string primaryPhoneNumber,
            string secondaryPhoneNumber)
        {
            UserId = userId;
            NameEn = nameEn;
            NameAr = nameAr;
            UserName = userName;
            Email = email;
            Password = password;
            EmployeeNumber = employeeNumber;
            NationalId = nationalId;
            this.nationalityId = nationalityId;
            this.roleId = roleId;
            this.branchId = branchId;
            Nationality = (nationalityId.HasValue && nationalityId.Value > 0)
                ? ClsNationlity.GetNationalityInfoById(nationalityId.Value)
                : null;

            Role = (roleId.HasValue && roleId.Value > 0)
                ? ClsRole.FindById(roleId.Value)
                : null;

            Branch = (branchId.HasValue && branchId.Value > 0)
                ? ClsBranch.FindById(branchId.Value)
                : null;

            LicenseNumber = licenseNumber;
            LicenseExpiryDate = licenseExpiryDate;
            PrimaryPhoneNumber = primaryPhoneNumber;
            SecondaryPhoneNumber = secondaryPhoneNumber;

            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;
            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewUser();
                    break;
                case enMode.Update:
                    result = UpdateUser();
                    break;
            }
            return result;
        }

        private bool AddNewUser()
        {
            int id = ClsUserData.AddNewUser(
                NameEn,
                NameAr,
                UserName,
                Email,
                Password,
                EmployeeNumber,
                NationalId,
                nationalityId,
                roleId,
                branchId,
                LicenseNumber,
                LicenseExpiryDate,
                PrimaryPhoneNumber,
                SecondaryPhoneNumber);

            if (id != -1)
            {
                UserId = id;
                return true;
            }
            return false;
        }

        private bool UpdateUser()
        {
            if (!UserId.HasValue)
                return false;

            return ClsUserData.EditUser(
                UserId.Value,
                NameEn,
                NameAr,
                UserName,
                Email,
                Password,
                EmployeeNumber,
                NationalId,
                Nationality?.Id,
                Role?.Id,
                Branch?.BranchId,
                LicenseNumber,
                LicenseExpiryDate,
                PrimaryPhoneNumber,
                SecondaryPhoneNumber);
        }

        public static bool DeleteUser(int userId)
        {
            return ClsUserData.DeleteUser(userId);
        }

        public static ClsUser FindById(int userId)
        {
            string nameEn = "";
            string nameAr = "";
            string userName = "";
            string email = "";
            string password = "";
            string employeeNumber = "";
            string nationalId = "";
            int? nationalityId = null;
            int? roleId = null;
            int? branchId = null;
            string licenseNumber = "";
            DateTime? licenseExpiryDate = null;
            string primaryPhoneNumber = "";
            string secondaryPhoneNumber = "";

            bool found = ClsUserData.GetUserInfoById(
                userId,
                ref nameEn,
                ref nameAr,
                ref userName,
                ref email,
                ref password,
                ref employeeNumber,
                ref nationalId,
                ref nationalityId,
                ref roleId,
                ref branchId,
                ref licenseNumber,
                ref licenseExpiryDate,
                ref primaryPhoneNumber,
                ref secondaryPhoneNumber);

            if (!found)
                return null;

            return new ClsUser(
                userId,
                nameEn,
                nameAr,
                userName,
                email,
                password,
                employeeNumber,
                nationalId,
                nationalityId,
                roleId,
                branchId,
                licenseNumber,
                licenseExpiryDate,
                primaryPhoneNumber,
                secondaryPhoneNumber);
        }

        public static DataTable GetUsersDataTable()
        {
            return ClsUserData.GetAllUsers();
        }

        public static int? ValidateUserLogin(string userName, string password)
        {
            return ClsUserData.ValidateUserCredentials(userName, password);
        }

        public static bool isuserExist(string UserName)
        {
            return ClsUserData.IsUserExist(UserName);
        }
    }
}
