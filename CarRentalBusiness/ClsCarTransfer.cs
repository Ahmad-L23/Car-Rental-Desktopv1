using CarRentalDataAccess;
using CarRentalDataAccessLayer;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsCarTransfer
    {
        private enum enMode { AddNew, Update }
        private enMode mode = enMode.AddNew;

        public int? TransferId { get; set; }
        public int CarId { get; set; }
        public int EmployeeId { get; set; }
        public string TransferReason { get; set; }
        public int ExitBranchId { get; set; }
        public int ExitCounter { get; set; }
        public string ExitFuel { get; set; }
        public DateTime? ExitDate { get; set; }
        public int Status { get; set; }
        public int BranchTransferTo { get; set; }

        public string EntryFuel {  get; set; }
        public double? EntryCounter {  get; set; }

        // Composition
        public ClsCar Car { get; private set; }
        public ClsUser Employee { get; private set; }
        public ClsBranch ExitBranch { get; private set; }
        public ClsBranch ToBranch { get; private set; }

        public ClsCarTransfer()
        {
            TransferId = null;
            CarId = 0;
            EmployeeId = 0;
            TransferReason = string.Empty;
            ExitBranchId = 0;
            ExitCounter = 0;
            ExitFuel = "";
            ExitDate = null;
            Status = 0;
            BranchTransferTo = 0;
            EntryFuel = null;
            EntryCounter = null;

            mode = enMode.AddNew;
        }

        public ClsCarTransfer(
            int transferId,
            int carId,
            int employeeId,
            string transferReason,
            int exitBranchId,
            int exitCounter,
            string exitFuel,
            DateTime? exitDate,
            int status,
            int branchTransferTo,
            string EntryFuel,
            double? EntryCounter)
        {
            TransferId = transferId;
            CarId = carId;
            EmployeeId = employeeId;
            TransferReason = transferReason;
            ExitBranchId = exitBranchId;
            ExitCounter = exitCounter;
            ExitFuel = exitFuel;
            ExitDate = exitDate;
            Status = status;
            BranchTransferTo = branchTransferTo;
            this.EntryFuel = EntryFuel;
            this.EntryCounter = EntryCounter;

            mode = enMode.Update;

            // Load relations
            Car = ClsCar.FindById(CarId);
            Employee = ClsUser.FindById(EmployeeId);
            ExitBranch = ClsBranch.FindById(ExitBranchId);
            ToBranch = ClsBranch.FindById(BranchTransferTo);
        }

        public bool Save()
        {
            if (mode == enMode.AddNew)
                return Add();

            return Update();
        }

        private bool Add()
        {
            int newId = ClsCarTransferData.AddNewCarTransfer(
                CarId,
                EmployeeId,
                TransferReason,
                ExitBranchId,
                ExitCounter,
                ExitFuel,
                ExitDate,
                Status,
                BranchTransferTo,
                EntryFuel,
                EntryCounter

            );

            if (newId == -1)
                return false;

            TransferId = newId;
            mode = enMode.Update;
            return true;
        }

        private bool Update()
        {
            if (!TransferId.HasValue)
                return false;

            return ClsCarTransferData.UpdateCarTransfer(
                TransferId.Value,
                CarId,
                EmployeeId,
                TransferReason,
                ExitBranchId,
                ExitCounter,
                ExitFuel,
                ExitDate,
                Status,
                BranchTransferTo,
                EntryFuel,
                EntryCounter
            );
        }

        public static bool Delete(int id)
        {
            return ClsCarTransferData.DeleteCarTransfer(id);
        }

        public static ClsCarTransfer FindById(int id)
        {
            int carId = 0;
            int employeeId = 0;
            string reason = "";
            int exitBranchId = 0;
            int exitCounter = 0;
            string exitFuel = "";
            DateTime? exitDate = null;
            int status = 0;
            int toBranch = 0;
            string entryFuel = null;
            double? entryCounter = null;
            bool found = ClsCarTransferData.GetCarTransferById(
                id,
                ref carId,
                ref employeeId,
                ref reason,
                ref exitBranchId,
                ref exitCounter,
                ref exitFuel,
                ref exitDate,
                ref status,
                ref toBranch,
                ref entryFuel,
                ref entryCounter
            );

            if (!found)
                return null;

            return new ClsCarTransfer(
                id,
                carId,
                employeeId,
                reason,
                exitBranchId,
                exitCounter,
                exitFuel,
                exitDate,
                status,
                toBranch,
                entryFuel,
                entryCounter

            );
        }

        public static DataTable GetAll()
        {
            return ClsCarTransferData.GetAllCarTransfers();
        }

        public static DataTable GetAllCarTransferSummary()
        {
            return ClsCarTransferData.GetAllCarTransfersSummery();
        }
    }
}
