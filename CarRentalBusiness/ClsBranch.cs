using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsBranch
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? BranchId { get; set; }
        public string Name { get; set; }
        public decimal Tax { get; set; }
        public decimal Rate { get; set; }

        public ClsBranch()
        {
            BranchId = null;
            Name = "";
            Tax = 0m;
            Rate = 0m;
            mode = enMode.AddNew;
        }

        public ClsBranch(int? branchId, string name, decimal tax, decimal rate)
        {
            BranchId = branchId;
            Name = name;
            Tax = tax;
            Rate = rate;
            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;
            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewBranch();
                    break;
                case enMode.Update:
                    result = UpdateBranch();
                    break;
            }
            return result;
        }

        private bool AddNewBranch()
        {
            int id = ClsBranchData.AddNewBranch(Name, Tax, Rate);
            if (id != -1)
            {
                BranchId = id;
                mode = enMode.Update;
                return true;
            }
            return false;
        }

        private bool UpdateBranch()
        {
            if (!BranchId.HasValue)
                return false;

            bool result = ClsBranchData.EditBranch(BranchId.Value, Name, Tax, Rate);
            return result;
        }

        public static bool DeleteBranch(int branchId)
        {
            return ClsBranchData.DeleteBranch(branchId);
        }

        public static ClsBranch FindById(int branchId)
        {
            string name = "";
            decimal tax = 0m;
            decimal rate = 0m;

            bool found = ClsBranchData.GetBranchInfoById(branchId, ref name, ref tax, ref rate);
            if (!found)
                return null;

            return new ClsBranch(branchId, name, tax, rate);
        }

        public static DataTable GetBranchesDataTable()
        {
            return ClsBranchData.GetAllBranches();
        }

        public static bool IsBranchExist(int branchId)
        {
            return ClsBranchData.IsBranchExist(branchId);
        }
    }
}
