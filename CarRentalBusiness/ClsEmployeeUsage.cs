using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsEmployeeUsage
    {
        private enum enMode { AddNew, Update }
        private enMode mode = enMode.AddNew;

        public enum enStatus
        {
            Pending = 0,
            Delivered = 1,
            InProgress = 2
        }

        public int? UsageId { get; set; }
        public int EmployeeId { get; set; }
        public int CarId { get; set; }
        public int ExitBranchId { get; set; }
        public string UsageReason { get; set; }
        public DateTime ExitDate { get; set; }
        public int Status { get; set; }

        public int ExitCounter { get; set; }
        public string ExitFuel { get; set; }
        public int EntryBranchId { get; set; }
        public DateTime EntryDate { get; set; }
        public int EntryCountre { get; set; }
        public string EntryFuel { get; set; }

        // OPTIONAL related objects
        public ClsUser Employee { get; set; }
        public ClsCar Car { get; set; }
        public ClsBranch Branch { get; set; }

        // Default constructor
        public ClsEmployeeUsage()
        {
            UsageId = null;
            EmployeeId = 0;
            CarId = 0;
            ExitBranchId = 0;
            UsageReason = "";
            ExitDate = DateTime.Now;
            Status = 0;

            ExitCounter = 0;
            ExitFuel = "";

            EntryBranchId = 0;
            EntryDate = DateTime.Now;
            EntryCountre = 0;
            EntryFuel = "";

            Employee = null;
            Car = null;
            Branch = null;

            mode = enMode.AddNew;
        }

        // Full constructor with all fields
        public ClsEmployeeUsage(
            int usageId,
            int employeeId,
            int carId,
            int exitBranchId,
            string usageReason,
            DateTime exitDate,
            int status,

            int exitCounter,
            string exitFuel,

            int entryBranchId,
            DateTime entryDate,
            int entryCountre,
            string entryFuel)
        {
            UsageId = usageId;
            EmployeeId = employeeId;
            CarId = carId;
            ExitBranchId = exitBranchId;
            UsageReason = usageReason;
            ExitDate = exitDate;
            Status = status;

            ExitCounter = exitCounter;
            ExitFuel = exitFuel;

            EntryBranchId = entryBranchId;
            EntryDate = entryDate;
            EntryCountre = entryCountre;
            EntryFuel = entryFuel;

            Employee = ClsUser.FindById(employeeId);
            Car = ClsCar.FindById(carId);
            Branch = ClsBranch.FindById(exitBranchId);

            mode = enMode.Update;
        }

        // SAVE method (calls AddNew or Update accordingly)
        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    return AddNew();
                case enMode.Update:
                    return Update();
                default:
                    return false;
            }
        }

        // Add new record with all fields
        private bool AddNew()
        {
            int id = ClsEmployeeUsageData.AddEmployeeUsage(
                EmployeeId,
                CarId,
                ExitBranchId,
                UsageReason,
                ExitDate,
                Status,

                ExitCounter,
                ExitFuel,

                EntryBranchId,
                EntryDate,
                EntryCountre,
                EntryFuel);

            if (id != -1)
            {
                UsageId = id;
                mode = enMode.Update;
                return true;
            }

            return false;
        }

        // Update record with all fields
        private bool Update()
        {
            if (!UsageId.HasValue)
                return false;

            return ClsEmployeeUsageData.EditEmployeeUsage(
                UsageId.Value,
                EmployeeId,
                CarId,
                ExitBranchId,
                UsageReason,
                ExitDate,
                Status,

                ExitCounter,
                ExitFuel,

                EntryBranchId,
                EntryDate,
                EntryCountre,
                EntryFuel);
        }

        // DELETE
        public static bool Delete(int usageId)
        {
            return ClsEmployeeUsageData.DeleteEmployeeUsage(usageId);
        }

        // FIND BY ID - must load all fields from DAL
        public static ClsEmployeeUsage Find(int usageId)
        {
            int employeeId = 0;
            int carId = 0;
            int exitBranchId = 0;
            string usageReason = "";
            DateTime exitDate = DateTime.Now;
            int status = 0;

            int exitCounter = 0;
            string exitFuel = "";

            int entryBranchId = 0;
            DateTime entryDate = DateTime.Now;
            int entryCountre = 0;
            string entryFuel = "";

            bool found = ClsEmployeeUsageData.GetEmployeeUsageById(
                usageId,
                ref employeeId,
                ref carId,
                ref exitBranchId,
                ref usageReason,
                ref exitDate,
                ref status,

                ref exitCounter,
                ref exitFuel,

                ref entryBranchId,
                ref entryDate,
                ref entryCountre,
                ref entryFuel);

            if (!found)
                return null;

            return new ClsEmployeeUsage(
                usageId,
                employeeId,
                carId,
                exitBranchId,
                usageReason,
                exitDate,
                status,

                exitCounter,
                exitFuel,

                entryBranchId,
                entryDate,
                entryCountre,
                entryFuel);
        }

        // GET ALL
        public static DataTable GetAll()
        {
            return ClsEmployeeUsageData.GetAllEmployeeUsage();
        }

        public static DataTable GetEmployeeSummaryUsage()
        {
            return ClsEmployeeUsageData.GetEmployeeUsageSummary();
        }

        public static DataTable getFullEmployeeData()
        {
            return ClsEmployeeUsageData.GetEmployeeUsageFullData();
        }

        // CHECK EXISTS
        public static bool Exists(int usageId)
        {
            return ClsEmployeeUsageData.IsEmployeeUsageExist(usageId);
        }
    }
}
