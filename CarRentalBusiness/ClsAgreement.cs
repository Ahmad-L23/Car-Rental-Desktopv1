using CarRentalDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;

namespace CarRentalBusiness
{
    public class ClsAgreement
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? AgreementID { get; set; }
        public int CustomerID { get; set; }
        ClsCustomer CustomerInfo { get; set; }
        public int CarID { get; set; }
        ClsCar CarInfo { get; set; }
        public int PickupBranchID { get; set; }
        public int DropOffBranchID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal AgreedPrice { get; set; }
        public decimal? RentalPenaltyPerDay { get; set; }
        public decimal TotalAmountBeforeTax { get; set; }
        public int PermittedDailyKilometers { get; set; }
        public decimal AdditionalKilometerPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal? InitialPaidAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public int? ReceivingOdometer { get; set; }
        public int? ConsumedMileage { get; set; }
        public int? Mileage { get; set; }
        public string ExitFuel {  get; set; }
        public int SerialNumber { get; set; }
        public decimal? AdditionContractPrice { get; set; }
        public decimal? RentalAdditionsPrice { get; set; }
        public decimal? RequiredInsurancePrice { get; set; }

        public List<(int Id, decimal Price)> AdditionContracts { get; set; } = new List<(int, decimal)>();
        public List<(int Id, decimal Price)> RentalAdditions { get; set; } = new List<(int, decimal)>();
        public List<(int Id, decimal Price)> RequiredInsurances { get; set; } = new List<(int, decimal)>();


        public ClsAgreement()
        {
            AgreementID = null;
            CustomerID = 0;
            CustomerInfo = null; // or new ClsCustomer() if you want an instance
            CarID = 0;
            CarInfo = null; // or new ClsCar()
            PickupBranchID = 0;
            DropOffBranchID = 0;
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            AgreedPrice = 0m;
            RentalPenaltyPerDay = null;
            TotalAmountBeforeTax = 0m;
            PermittedDailyKilometers = 0;
            AdditionalKilometerPrice = 0m;
            TaxRate = 0m;
            InitialPaidAmount = null;
            PaymentMethod = string.Empty;
            PaymentDate = null;
            ActualDeliveryDate = null;
            ReceivingOdometer = null;
            ConsumedMileage = null;
            Mileage = null;
            SerialNumber = 0;
            AdditionContractPrice = null;
            RentalAdditionsPrice = null;
            RequiredInsurancePrice = null;

            AdditionContracts = new List<(int, decimal)>();
            RentalAdditions = new List<(int, decimal)>();
            RequiredInsurances = new List<(int, decimal)>();

            mode = enMode.AddNew;
        }


        public ClsAgreement(
            int agreementID,
            int customerID,
            int carID,
            int pickupBranchID,
            int dropOffBranchID,
            DateTime startDate,
            DateTime endDate,
            decimal agreedPrice,
            decimal? rentalPenaltyPerDay,
            decimal totalAmountBeforeTax,
            int permittedDailyKilometers,
            decimal additionalKilometerPrice,
            decimal taxRate,
            decimal? initialPaidAmount,
            string paymentMethod,
            DateTime? paymentDate,
            DateTime? actualDeliveryDate,
            int? receivingOdometer,
            int? consumedMileage,
            int? mileage,
            int serialNumber,
            decimal? additionContractPrice,
            decimal? rentalAdditionsPrice,
            decimal? requiredInsurancePrice)
        {
            AgreementID = agreementID;
            CustomerID = customerID;
            CustomerInfo = ClsCustomer.FindById(customerID);
            CarID = carID;
            CarInfo = ClsCar.FindById(carID);
            PickupBranchID = pickupBranchID;
            DropOffBranchID = dropOffBranchID;
            StartDate = startDate;
            EndDate = endDate;
            AgreedPrice = agreedPrice;
            RentalPenaltyPerDay = rentalPenaltyPerDay;
            TotalAmountBeforeTax = totalAmountBeforeTax;
            PermittedDailyKilometers = permittedDailyKilometers;
            AdditionalKilometerPrice = additionalKilometerPrice;
            TaxRate = taxRate;
            InitialPaidAmount = initialPaidAmount;
            PaymentMethod = paymentMethod;
            PaymentDate = paymentDate;
            ActualDeliveryDate = actualDeliveryDate;
            ReceivingOdometer = receivingOdometer;
            ConsumedMileage = consumedMileage;
            Mileage = mileage;
            SerialNumber = serialNumber;
            AdditionContractPrice = additionContractPrice;
            RentalAdditionsPrice = rentalAdditionsPrice;
            RequiredInsurancePrice = requiredInsurancePrice;

            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;
            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewAgreement();
                    break;

                case enMode.Update:
                    result = UpdateAgreement();
                    break;
            }
            return result;
        }

        private bool AddNewAgreement()
        {
            int newId = ClsAgreementData.AddNewAgreement(
                CustomerID,
                CarID,
                PickupBranchID,
                DropOffBranchID,
                StartDate,
                EndDate,
                AgreedPrice,
                RentalPenaltyPerDay ?? 0m,
                TotalAmountBeforeTax,
                PermittedDailyKilometers,
                AdditionalKilometerPrice,
                TaxRate,
                InitialPaidAmount ?? 0m,
                PaymentMethod,
                PaymentDate ?? DateTime.Now,
                ActualDeliveryDate,
                ReceivingOdometer ?? 0,
                ConsumedMileage ?? 0,
                Mileage ?? 0,
                ExitFuel = "",
                SerialNumber,
                AdditionContractPrice ?? 0m,
                RentalAdditionsPrice ?? 0m,
                RequiredInsurancePrice ?? 0m);

            if (newId > 0)
            {
                AgreementID = newId;
                mode = enMode.Update;

                // Add AdditionContracts entries
                foreach (var item in AdditionContracts)
                {
                    ClsAgreementAdditionContractData.Add(newId, item.Id, item.Price);
                }

                // Add RentalAdditions entries
                foreach (var item in RentalAdditions)
                {
                    ClsAgreementRentalAdditionData.AddNew(newId, item.Id, item.Price);
                }

                // Add RequiredInsurances entries
                foreach (var item in RequiredInsurances)
                {
                    ClsAgreementRequiredInsuranceData.AddNew(newId, item.Id, item.Price);
                }

                return true;
            }
            return false;
        }

        private bool UpdateAgreement()
        {
            if (!AgreementID.HasValue)
                return false;

            // Delete old additions
            ClsAgreementAdditionContractData.DeleteByAgreementId(AgreementID.Value);
            ClsAgreementRentalAdditionData.DeleteByAgreementId(AgreementID.Value);
            ClsAgreementRequiredInsuranceData.DeleteByAgreementId(AgreementID.Value);

            bool mainUpdated = ClsAgreementData.EditAgreement(
                AgreementID.Value,
                CustomerID,
                CarID,
                PickupBranchID,
                DropOffBranchID,
                StartDate,
                EndDate,
                AgreedPrice,
                RentalPenaltyPerDay ?? 0m,
                TotalAmountBeforeTax,
                PermittedDailyKilometers,
                AdditionalKilometerPrice,
                TaxRate,
                InitialPaidAmount ?? 0m,
                PaymentMethod,
                PaymentDate ?? DateTime.Now,
                ActualDeliveryDate,
                ReceivingOdometer ?? 0,
                ConsumedMileage ?? 0,
                Mileage ?? 0,
                ExitFuel,
                SerialNumber,
                AdditionContractPrice ?? 0m,
                RentalAdditionsPrice ?? 0m,
                RequiredInsurancePrice ?? 0m);

            if (!mainUpdated)
                return false;

            int id = AgreementID.Value;

            // First delete existing related additions for this agreement
            ClsAgreementAdditionContractData.DeleteByAgreementId(id);
            ClsAgreementRentalAdditionData.DeleteByAgreementId(id);
            ClsAgreementRequiredInsuranceData.DeleteByAgreementId(id);

            // Now re-insert all AdditionContracts
            foreach (var item in AdditionContracts)
            {
                ClsAgreementAdditionContractData.Add(id, item.Id, item.Price);
            }

            // Re-insert all RentalAdditions
            foreach (var item in RentalAdditions)
            {
                ClsAgreementRentalAdditionData.AddNew(id, item.Id, item.Price);
            }

            // Re-insert all RequiredInsurances
            foreach (var item in RequiredInsurances)
            {
                ClsAgreementRequiredInsuranceData.AddNew(id, item.Id, item.Price);
            }

            return true;
        }


        public static bool DeleteAgreement(int agreementId)
        {
            // First delete all related additions
            ClsAgreementAdditionContractData.DeleteByAgreementId(agreementId);
            ClsAgreementRentalAdditionData.DeleteByAgreementId(agreementId);
            ClsAgreementRequiredInsuranceData.DeleteByAgreementId(agreementId);

            // Then delete the main agreement
            return ClsAgreementData.DeleteAgreement(agreementId);
        }


        public static ClsAgreement FindById(int agreementId)
        {
            int customerID = 0;
            int carID = 0;
            int pickupBranchID = 0;
            int dropOffBranchID = 0;
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            decimal agreedPrice = 0m;
            decimal rentalPenaltyPerDay = 0m;  // NON-nullable here
            decimal totalAmountBeforeTax = 0m;
            int permittedDailyKilometers = 0;
            decimal additionalKilometerPrice = 0m;
            decimal taxRate = 0m;
            decimal initialPaidAmount = 0m;   // NON-nullable
            string paymentMethod = string.Empty; // string, not int
            DateTime paymentDate = DateTime.MinValue; // NON-nullable
            DateTime? actualDeliveryDate = null; // nullable stays nullable
            int receivingOdometer = 0;        // NON-nullable
            int consumedMileage = 0;          // NON-nullable
            int mileage = 0;                  // NON-nullable
            string ExitFuel = "";
            int serialNumber = 0;
            decimal additionContractPrice = 0m;
            decimal rentalAdditionsPrice = 0m;
            decimal requiredInsurancePrice = 0m;

            bool found = ClsAgreementData.GetAgreementById(
                agreementId,
                ref customerID,
                ref carID,
                ref pickupBranchID,
                ref dropOffBranchID,
                ref startDate,
                ref endDate,
                ref agreedPrice,
                ref rentalPenaltyPerDay,          // pass non-nullable decimal
                ref totalAmountBeforeTax,
                ref permittedDailyKilometers,
                ref additionalKilometerPrice,
                ref taxRate,
                ref initialPaidAmount,            // non-nullable decimal
                ref paymentMethod,
                ref paymentDate,                  // non-nullable DateTime
                ref actualDeliveryDate,           // nullable DateTime - keep nullable here if DAL supports it
                ref receivingOdometer,
                ref consumedMileage,
                ref mileage,
                ref ExitFuel,
                ref serialNumber,
                ref additionContractPrice,
                ref rentalAdditionsPrice,
                ref requiredInsurancePrice);

            if (!found)
                return null;

            return new ClsAgreement(
                agreementId,
                customerID,
                carID,
                pickupBranchID,
                dropOffBranchID,
                startDate,
                endDate,
                agreedPrice,
                rentalPenaltyPerDay,
                totalAmountBeforeTax,
                permittedDailyKilometers,
                additionalKilometerPrice,
                taxRate,
                initialPaidAmount,
                paymentMethod,
                paymentDate,
                actualDeliveryDate,
                receivingOdometer,
                consumedMileage,
                mileage,
                serialNumber,
                additionContractPrice,
                rentalAdditionsPrice,
                requiredInsurancePrice);
        }


        public static DataTable GetAllAgreements()
        {
            return ClsAgreementData.GetAllAgreements();
        }

        // Optionally, add method to get all agreements with full info from DAL if you want
        public static DataTable GetAllAgreementsFullInfo()
        {
            return ClsAgreementData.GetAllAgreementsFullInfo();
        }

        public static int GetLastSerialNumber()
        {
            // نستخدم دالة الـ DAL للحصول على آخر رقم تسلسلي
            return ClsAgreementData.GetLastSerialNumber();
        }

        public List<int> GetAdditionContractIdsByAgreement(int agreementId)
        {
            DataTable dt = ClsAgreementAdditionContractData.GetAllByAgreementId(agreementId);
            return dt.AsEnumerable()
                     .Select(row => row.Field<int>("AdditionContractID"))
                     .ToList();
        }

        public List<int> GetRentalAdditionIdsByAgreement(int agreementId)
        {
            DataTable dt = ClsAgreementRentalAdditionData.GetAllByAgreementId(agreementId);
            return dt.AsEnumerable()
                     .Select(row => row.Field<int>("RentalAdditionID"))
                     .ToList();
        }

        public List<int> GetRequiredInsuranceIdsByAgreement(int agreementId)
        {
            DataTable dt = ClsAgreementRequiredInsuranceData.GetAllByAgreementId(agreementId);
            return dt.AsEnumerable()
                     .Select(row => row.Field<int>("RequiredInsuranceID"))
                     .ToList();
        }

    }
}
