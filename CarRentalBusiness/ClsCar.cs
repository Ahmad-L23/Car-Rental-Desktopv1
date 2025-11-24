using CarRentalDataAccess;
using Microsoft.SqlServer.Server;
using System;
using System.ComponentModel.Design;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsCar
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? CarID { get; set; }
        public string CarNameEn { get; set; }
        public string CarNameAr { get; set; }
        public int Year { get; set; }
        public int ColorId { get; set; }
        public int CategoryId { get; set; }
        public int GroupId { get; set; }
        public int BranchId { get; set; }
        public int FuelTypeID { get; set; }

        public ClsCategory Category {  get; set; }
        public ClsGroup Group {  get; set; }
        public ClsBranch Branch {  get; set; }
        public ClsFuelType fuelType {  get; set; }

        public string CarImage { get; set; }
        public int InitialCounter { get; set; }
        public int NumberOfRiders { get; set; }
        public int NumberOfLoads { get; set; }
        public DateTime? LicenseDate { get; set; }
        public DateTime? ExpiryLicenseDate { get; set; }
        public string NumberOfRegistration { get; set; }
        public string CarNumber { get; set; }
        public decimal EngineSize { get; set; }
        public string ChassisNumber { get; set; }
        public int CurrentCounter { get; set; }
        public int NumberOfSeats { get; set; }
        public string EngineNumber { get; set; }
        public string PlateNumber { get; set; }
        public int NumberOfDoors { get; set; }
        public string GasolineType { get; set; }
        public decimal CarPrice { get; set; }
        public string LicenseType { get; set; }
        public bool IsAvailable { get; set; }
        public string UsedFor { get; set; }
        public int? DamagesNumber { get; set; }
        public string Description { get; set; }
        public string FuelExit {  get; set; }

        public ClsCar()
        {
            CarID = null;
            CarNameEn = "";
            CarNameAr = "";
            Year = DateTime.Now.Year;
            ColorId = 0;
            CategoryId = 0;
            GroupId = 0;
            BranchId = 0;
            FuelTypeID = 0;
            CarImage = null;
            InitialCounter = 0;
            NumberOfRiders = 0;
            NumberOfLoads = 0;
            LicenseDate = null;
            ExpiryLicenseDate = null;
            NumberOfRegistration = null;
            CarNumber = "";
            EngineSize = 0;
            ChassisNumber = "";
            CurrentCounter = 0;
            NumberOfSeats = 0;
            EngineNumber = "";
            PlateNumber = "";
            NumberOfDoors = 0;
            GasolineType = "";
            CarPrice = 0;
            LicenseType = "";
            IsAvailable = true;
            UsedFor = "";
            DamagesNumber = null;
            Description = "";
            FuelExit = "";

            mode = enMode.AddNew;
        }

        public ClsCar(
            int? carId,
            string carNameEn,
            string carNameAr,
            int year,
            int colorId,
            int categoryId,
            int groupId,
            int branchId,
            int fuelTypeId,
            string carImage,
            int initialCounter,
            int numberOfRiders,
            int numberOfLoads,
            DateTime? licenseDate,
            DateTime? expiryLicenseDate,
            string numberOfRegistration,
            string carNumber,
            decimal engineSize,
            string chassisNumber,
            int currentCounter,
            int numberOfSeats,
            string engineNumber,
            string plateNumber,
            int numberOfDoors,
            string gasolineType,
            decimal carPrice,
            string licenseType,
            bool isAvailable,
            string usedFor,
            int? damagesNumber,
            string description,
            string FuelExit)
        {
            CarID = carId;
            CarNameEn = carNameEn;
            CarNameAr = carNameAr;
            Year = year;
            ColorId = colorId;
            CategoryId = categoryId;
            GroupId = groupId;
            BranchId = branchId;
            FuelTypeID = fuelTypeId;

            Category = ClsCategory.FindById(categoryId);
            Group = ClsGroup.FindById(GroupId);
            Branch = ClsBranch.FindById(BranchId);
            fuelType = ClsFuelType.FindById(fuelTypeId);

            CarImage = carImage;
            InitialCounter = initialCounter;
            NumberOfRiders = numberOfRiders;
            NumberOfLoads = numberOfLoads;
            LicenseDate = licenseDate;
            ExpiryLicenseDate = expiryLicenseDate;
            NumberOfRegistration = numberOfRegistration;
            CarNumber = carNumber;
            EngineSize = engineSize;
            ChassisNumber = chassisNumber;
            CurrentCounter = currentCounter;
            NumberOfSeats = numberOfSeats;
            EngineNumber = engineNumber;
            PlateNumber = plateNumber;
            NumberOfDoors = numberOfDoors;
            GasolineType = gasolineType;
            CarPrice = carPrice;
            LicenseType = licenseType;
            IsAvailable = isAvailable;
            UsedFor = usedFor;
            DamagesNumber = damagesNumber;
            Description = description;
            this.FuelExit = FuelExit;

            mode = carId.HasValue ? enMode.Update : enMode.AddNew;
        }



        public ClsCar(
            string plateNumber,
            string chassisNumber,
            string carNameEn,
            int groupId,
            int year,
            decimal engineSize,
            bool isAvailable)
        {
            PlateNumber = plateNumber ?? "";
            ChassisNumber = chassisNumber ?? "";
            CarNameEn = carNameEn ?? "";
            GroupId = groupId;
            Year = year;
            EngineSize = engineSize;
            IsAvailable = isAvailable;

            if (groupId > 0)  // validate groupId is positive
            {
                var group = ClsGroup.FindById(groupId);
                if (group != null)
                {
                    Group = group;
                }
                else
                {
                    Group = null; 
                }
            }
            else
            {
                Group = null;
            }
        }



        public bool Save()
        {
            bool result = false;
            switch (mode)
            {
                case enMode.AddNew:
                    int newId = ClsCarData.AddNewCar(
                        CarNameEn,
                        CarNameAr,
                        Year,
                        ColorId,
                        CategoryId,
                        GroupId,
                        BranchId,
                        FuelTypeID,
                        CarImage,
                        InitialCounter,
                        NumberOfRiders,
                        NumberOfLoads,
                        LicenseDate,
                        ExpiryLicenseDate,
                        NumberOfRegistration,
                        CarNumber,
                        EngineSize,
                        ChassisNumber,
                        CurrentCounter,
                        NumberOfSeats,
                        EngineNumber,
                        PlateNumber,
                        NumberOfDoors,
                        GasolineType,
                        CarPrice,
                        LicenseType,
                        IsAvailable,
                        UsedFor,
                        DamagesNumber,
                        Description,
                        FuelExit);

                    if (newId != -1)
                    {
                        CarID = newId;
                        result = true;
                    }
                    break;

                case enMode.Update:
                    if (!CarID.HasValue)
                        return false;

                    result = ClsCarData.EditCar(
                        CarID.Value,
                        CarNameEn,
                        CarNameAr,
                        Year,
                        ColorId,
                        CategoryId,
                        GroupId,
                        BranchId,
                        FuelTypeID,
                        CarImage,
                        InitialCounter,
                        NumberOfRiders,
                        NumberOfLoads,
                        LicenseDate,
                        ExpiryLicenseDate,
                        NumberOfRegistration,
                        CarNumber,
                        EngineSize,
                        ChassisNumber,
                        CurrentCounter,
                        NumberOfSeats,
                        EngineNumber,
                        PlateNumber,
                        NumberOfDoors,
                        GasolineType,
                        CarPrice,
                        LicenseType,
                        IsAvailable,
                        UsedFor,
                        DamagesNumber,
                        Description,
                        FuelExit);
                    break;
            }

            return result;
        }

        public static bool DeleteCar(int carId)
        {
            return ClsCarData.DeleteCar(carId);
        }

        public static ClsCar FindById(int carId)
        {
            string carNameEn = "";
            string carNameAr = "";
            int year = 0;
            int ColorId = 0;
            int categoryId = 0;
            int groupId = 0;
            int branchId = 0;
            int fuelTypeId = 0;
            string carImage = null;
            int initialCounter = 0;
            int numberOfRiders = 0;
            int numberOfLoads = 0;
            DateTime? licenseDate = null;
            DateTime? expiryLicenseDate = null;
            string numberOfRegistration = null;
            string carNumber = "";
            decimal engineSize = 0;
            string chassisNumber = "";
            int currentCounter = 0;
            int numberOfSeats = 0;
            string engineNumber = "";
            string plateNumber = "";
            int numberOfDoors = 0;
            string gasolineType = "";
            decimal carPrice = 0;
            string licenseType = "";
            bool isAvailable = false;
            string usedFor = "";
            int? damagesNumber = null;
            string description = "";
            string FuelExit = "";

            bool found = ClsCarData.GetCarInfoById(
                carId,
                ref carNameEn,
                ref carNameAr,
                ref year,
                ref ColorId,
                ref categoryId,
                ref groupId,
                ref branchId,
                ref fuelTypeId,
                ref carImage,
                ref initialCounter,
                ref numberOfRiders,
                ref numberOfLoads,
                ref licenseDate,
                ref expiryLicenseDate,
                ref numberOfRegistration,
                ref carNumber,
                ref engineSize,
                ref chassisNumber,
                ref currentCounter,
                ref numberOfSeats,
                ref engineNumber,
                ref plateNumber,
                ref numberOfDoors,
                ref gasolineType,
                ref carPrice,
                ref licenseType,
                ref isAvailable,
                ref usedFor,
                ref damagesNumber,
                ref description,
                ref FuelExit);

            if (!found)
                return null;

            return new ClsCar(
                carId,
                carNameEn,
                carNameAr,
                year,
                ColorId,
                categoryId,
                groupId,
                branchId,
                fuelTypeId,
                carImage,
                initialCounter,
                numberOfRiders,
                numberOfLoads,
                licenseDate,
                expiryLicenseDate,
                numberOfRegistration,
                carNumber,
                engineSize,
                chassisNumber,
                currentCounter,
                numberOfSeats,
                engineNumber,
                plateNumber,
                numberOfDoors,
                gasolineType,
                carPrice,
                licenseType,
                isAvailable,
                usedFor,
                damagesNumber,
                description,
                FuelExit);
        }

        public static DataTable GetAllCars()
        {
            return ClsCarData.GetAllCars();
        }

        public static DataTable GetAllCarsWithColorName()
        {
           return ClsCarData.GetAllCarsWithColorName();
        }
        public static ClsCar FindCarSummaryByPlateNumber(string plateNumber)
        {
            string chassisNumber = "";
            string carNameEn = "";
            int groupId = 0;
            int year = 0;
            decimal engineSize = 0;
            bool isAvailable = false;

            bool found = ClsCarData.GetCarByPlateNumber(
                plateNumber,
                ref chassisNumber,
                ref carNameEn,
                ref groupId,
                ref year,
                ref engineSize,
                ref isAvailable);

            if (!found)
                return null;

            return new ClsCar(
                plateNumber,
                chassisNumber,
                carNameEn,
                groupId,
                year,
                engineSize,
                isAvailable);
        }

        public static DataTable GetAllCarsIdsAndPlateNubmers()
        {
            return ClsCarData.GetAllCarsIdAndPlateNumber();
        }

        public static bool IsAvaliable(int carId)
        {
            return ClsCarData.IsCarAvailable(carId);
        }

        public static string UnavaliableReason(int carId)
        {
            return ClsCarData.GetCarUnavailableReason(carId);
        }

    }
}
