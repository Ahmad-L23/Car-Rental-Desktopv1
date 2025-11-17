using CarRentalDataAccess;
using CarRentalDataAccessLayer;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsDamageMaintenance
    {
        public enum enMode { AddNew, Update }
        private enMode Mode = enMode.AddNew;

        public enum enStatus
        {
            Pending = 0,
            InProgress = 1,
            Completed = 2
        }

        // Properties mapping DB fields
        public int? DamageID { get; set; }
        public int CarID { get; set; }
        public DateTime DamageDate { get; set; }
        public decimal TotalAmount { get; set; }
        public enStatus Status { get; set; }
        public decimal GasolineIn { get; set; }
        public decimal GasolineOut { get; set; }
        public string GarageName { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? RepairStartDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        public string Description { get; set; }   // <- إضافة خاصية الوصف

        // Relations (composition)
        public ClsCar Vehicle { get; set; }
        public ClsUser Employee { get; set; }

        // Constructor (New)
        public ClsDamageMaintenance()
        {
            DamageID = null;
            CarID = 0;
            DamageDate = DateTime.Now;
            TotalAmount = 0;
            Status = enStatus.Pending;
            GasolineIn = 0;
            GasolineOut = 0;
            GarageName = "";
            EmployeeID = null;  // Nullable
            RepairStartDate = null;
            CompletionDate = null;
            Description = "";  // القيمة الافتراضية للوصف

            Mode = enMode.AddNew;
        }

        // Constructor (Existing)
        public ClsDamageMaintenance(int? damageID, int carID, DateTime damageDate,
            decimal totalAmount, int status, decimal gasolineIn, decimal gasolineOut,
            string garageName, int? employeeId, DateTime? repairStartDate, DateTime? completionDate,
            string description)  // <- إضافة البراميتر
        {
            DamageID = damageID;
            CarID = carID;
            DamageDate = damageDate;
            TotalAmount = totalAmount;
            Status = (enStatus)status;
            GasolineIn = gasolineIn;
            GasolineOut = gasolineOut;
            GarageName = garageName;
            EmployeeID = employeeId;
            RepairStartDate = repairStartDate;
            CompletionDate = completionDate;
            Description = description ?? "";  // تعيين الوصف

            // Load relations
            Vehicle = ClsCar.FindById(carID);

            if (employeeId.HasValue)
                Employee = ClsUser.FindById(employeeId.Value);
            else
                Employee = null;

            Mode = enMode.Update;
        }


        // Save
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return AddNew();
                case enMode.Update:
                    return Update();
            }
            return false;
        }

        // Add New
        private bool AddNew()
        {
            int id = ClsDamagesMaintenanceData.AddNewDamagesMaintenance(
                CarID,
                DamageDate,
                TotalAmount,
                (int)Status,
                GasolineIn,
                GasolineOut,
                GarageName,
                EmployeeID,
                RepairStartDate,
                CompletionDate,
                Description  // <- إضافة هنا
            );

            if (id != -1)
            {
                DamageID = id;
                Mode = enMode.Update;
                return true;
            }
            return false;
        }

        // Update
        private bool Update()
        {
            if (!DamageID.HasValue)
                return false;

            return ClsDamagesMaintenanceData.UpdateDamagesMaintenance(
                DamageID.Value,
                CarID,
                DamageDate,
                TotalAmount,
                (int)Status,
                GasolineIn,
                GasolineOut,
                GarageName,
                EmployeeID,
                RepairStartDate,
                CompletionDate,
                Description  // <- إضافة هنا
            );
        }

        // Delete
        public static bool Delete(int damageID)
        {
            return ClsDamagesMaintenanceData.DeleteDamage(damageID);
        }

        // Find by ID
        public static ClsDamageMaintenance FindById(int damageID)
        {
            int carID = 0;
            DateTime damageDate = DateTime.Now;
            decimal totalAmount = 0;
            int status = 0;
            decimal gasolineIn = 0;
            decimal gasolineOut = 0;
            string garageName = "";
            int? employeeID = null;
            DateTime? repairStartDate = null;
            DateTime? completionDate = null;
            string description = "";  // <- تعريف المتغير الجديد

            bool found = ClsDamagesMaintenanceData.GetDamageById(
                damageID,
                ref carID,
                ref damageDate,
                ref totalAmount,
                ref status,
                ref gasolineIn,
                ref gasolineOut,
                ref garageName,
                ref employeeID,
                ref repairStartDate,
                ref completionDate,
                ref description  // <- تمرير المتغير الجديد
            );

            if (!found)
                return null;

            return new ClsDamageMaintenance(
                damageID,
                carID,
                damageDate,
                totalAmount,
                status,
                gasolineIn,
                gasolineOut,
                garageName,
                employeeID,
                repairStartDate,
                completionDate,
                description  // <- تمرير المتغير الجديد
            );
        }


        public static DataTable AllDamages()
        {
            return ClsDamagesMaintenanceData.GetAllDamages();
        }

        public static DataTable GetDamagesWithCarInfo()
        {
            return ClsDamagesMaintenanceData.GetAllDamagesWithVehicleInfo();
        }


        public static DataTable GetDamagesWithEmpAndCarInfo()
        {
            return ClsDamagesMaintenanceData.GetAllDamagesWithFullInfo();
        }
    }
}
