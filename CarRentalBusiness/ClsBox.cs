using CarRentalDataAccess;
using CarRentalDataAccessLayer;
using System;
using System.Data;
using System.Xml.Linq;

namespace CarRentalBusiness
{
    public class ClsBox
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? BoxID { get; set; }
        public string Name { get; set; }
        public ClsBranch Branch { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }

        public ClsBox()
        {
            BoxID = null;
            Name = "";
            Branch = null;
            AccountNumber = "";
            IsActive = true;
            Notes = "";
            mode = enMode.AddNew;
        }

        public ClsBox(
            int? boxId,
            string name,
            int? branchId,
            string accountNumber,
            bool isActive,
            string notes)
        {
            BoxID = boxId;
            Name = name;
            Branch = (branchId.HasValue && branchId.Value > 0)
                ? ClsBranch.FindById(branchId.Value)
                : null;
            AccountNumber = accountNumber;
            IsActive = isActive;
            Notes = notes;

            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;

            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewBox();
                    break;

                case enMode.Update:
                    result = UpdateBox();
                    break;
            }

            return result;
        }

        private bool AddNewBox()
        {
            int id = ClsBoxData.AddNewBox(
                Name,
                (int)(Branch?.BranchId),
                AccountNumber,
                IsActive,
                Notes);

            if (id != -1)
            {
                BoxID = id;
                mode = enMode.Update;
                return true;
            }

            return false;
        }

        private bool UpdateBox()
        {
            if (!BoxID.HasValue)
                return false;

            bool result = ClsBoxData.EditBox(
                (int)BoxID,
                Name,
                (int)(Branch?.BranchId),
                AccountNumber,
                IsActive,
                Notes);

            return result;
        }

        public static bool DeleteBox(int boxId)
        {
            return ClsBoxData.DeleteBox(boxId);
        }

        public static ClsBox Find(int boxId)
        {
            string Name = "";
            int branchId = 0; // normal int for DataAccess layer
            string accountNumber = "";
            bool isActive = true;
            string notes = "";

            bool found = ClsBoxData.GetBoxInfoById(
                boxId,
                ref Name,
                ref branchId,
                ref accountNumber,
                ref isActive,
                ref notes);

            if (!found)
                return null;

            int? branchIdNullable = branchId > 0 ? branchId : (int?)null;

            return new ClsBox(
                boxId,
                Name,
                branchIdNullable,
                accountNumber,
                isActive,
                notes);
        }

        public static DataTable GetBoxesDataTable()
        {
            return ClsBoxData.GetAllBoxes();
        }

        public static bool BoxExistsByEnglishName(string nameEn)
        {
            return ClsBoxData.BoxExistsByEnglishName(nameEn);
        }

        public static bool BoxExistsByArabicName(string nameAr)
        {
            return ClsBoxData.BoxExistsByArabicName(nameAr);
        }

        public static bool IsBoxExist(int boxId)
        {
            return ClsBoxData.IsBoxExist(boxId);
        }


    }
}
