using System;
using System.Data;
using CarRentalDataAccess;

namespace CarRentalBusiness
{
    public class ClsRole
    {
        private enum enMode { AddNew, Update }
        private enMode mode = enMode.AddNew;

        public int? Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        // 🔹 Default constructor (for adding new role)
        public ClsRole()
        {
            Id = null;
            NameEn = "";
            NameAr = "";
            mode = enMode.AddNew;
        }

        // 🔹 Private constructor (for existing role)
        private ClsRole(int id, string nameEn, string nameAr)
        {
            Id = id;
            NameEn = nameEn;
            NameAr = nameAr;
            mode = enMode.Update;
        }

        // 🔹 Save method (decides whether to insert or update)
        public bool Save()
        {
            bool result = false;

            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewRole();
                    break;
                case enMode.Update:
                    result = UpdateRole();
                    break;
            }

            return result;
        }

        // 🔹 Add new role
        private bool AddNewRole()
        {
            int id = ClsRoleData.AddNewRole(NameEn, NameAr);

            if (id != -1)
            {
                Id = id;
                mode = enMode.Update; // Now it becomes existing
                return true;
            }

            return false;
        }

        // 🔹 Update existing role
        private bool UpdateRole()
        {
            if (!Id.HasValue)
                return false;

            bool result = ClsRoleData.EditRole(Id.Value, NameEn, NameAr);
            return result;
        }

        // 🔹 Delete role
        public static bool DeleteRole(int roleId)
        {
            return ClsRoleData.DeleteRole(roleId);
        }

        // 🔹 Find by ID
        public static ClsRole FindById(int roleId)
        {
            string nameEn = "";
            string nameAr = "";

            bool found = ClsRoleData.GetRoleInfoById(roleId, ref nameEn, ref nameAr);

            if (!found)
                return null;

            return new ClsRole(roleId, nameEn, nameAr);
        }

        // 🔹 Get all roles
        public static DataTable GetAllRoles()
        {
            return ClsRoleData.GetAllRoles();
        }

        // 🔹 Check if role exists (by ID)
        public static bool IsRoleExist(int roleId)
        {
            return ClsRoleData.IsRoleExist(roleId);
        }

        // 🔹 Check existence by name (English)
        public static bool RoleExistsByEnglishName(string nameEn)
        {
            return ClsRoleData.RoleExistsByEnglishName(nameEn);
        }

        // 🔹 Check existence by name (Arabic)
        public static bool RoleExistsByArabicName(string nameAr)
        {
            return ClsRoleData.RoleExistsByArabicName(nameAr);
        }
    }
}
