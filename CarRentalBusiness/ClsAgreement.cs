using CarRentalDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CarRentalBusiness
{

  public class item
    {
        public int id;
        public string name;
        public decimal price;
    }
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
        public decimal? TotalAmountBeforeTax { get; set; }
        public int? PermittedDailyKilometers { get; set; }
        public decimal? AdditionalKilometerPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal? InitialPaidAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public int? ReceivingOdometer { get; set; }
        public int? ConsumedMileage { get; set; }
        public int? Mileage { get; set; }
        public string ExitFuel { get; set; }
        public int SerialNumber { get; set; }
        public decimal? AdditionContractPrice { get; set; }
        public decimal? RentalAdditionsPrice { get; set; }
        public decimal? RequiredInsurancePrice { get; set; }
        public decimal? RentalDaysCost { get; set; }
        public decimal? TotalIncludetax { get; set; }
        public decimal? Discount {  get; set; }

        public string entryFuel {  get; set; }

        public List<(int Id, decimal Price, string Name)> AdditionContracts { get; set; } = new List<(int, decimal, string)>();
        public List<(int Id, decimal Price, string Name)> RentalAdditions { get; set; } = new List<(int, decimal,string)>();
        public List<(int Id, decimal Price, string Name)> RequiredInsurances { get; set; } = new List<(int, decimal,string)>();

  


        
        public ClsAgreement()
        {
            AgreementID = null;
            CustomerID = 0;
            CustomerInfo = null;
            CarID = 0;
            CarInfo = null;
            PickupBranchID = 0;
            DropOffBranchID = 0;
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            AgreedPrice = 0m;
            RentalPenaltyPerDay = null;
            TotalAmountBeforeTax = 0m;
            PermittedDailyKilometers = null;
            AdditionalKilometerPrice = null;
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
            RentalDaysCost = null;
            TotalIncludetax = null;

            AdditionContracts = new List<(int, decimal, string)>();
            RentalAdditions = new List<(int, decimal,string)>();
            RequiredInsurances = new List<(int, decimal,string)>();
            Discount = null;
            entryFuel = null;

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
            decimal? totalAmountBeforeTax,
            int? permittedDailyKilometers,
            decimal? additionalKilometerPrice,
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
            decimal? requiredInsurancePrice,
            decimal? rentalDaysCost,
            decimal? totalIncludetax,
            decimal? Discount,
            string entryFuel)
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
            TotalAmountBeforeTax = totalAmountBeforeTax ;
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
            RentalDaysCost = rentalDaysCost;
            TotalIncludetax = totalIncludetax;
            this.Discount = Discount;
            this.entryFuel = entryFuel;

            mode = enMode.Update;
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    return AddNewAgreement();

                case enMode.Update:
                    return UpdateAgreement();

                default:
                    return false;
            }
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
                RentalPenaltyPerDay,
                TotalAmountBeforeTax,
                PermittedDailyKilometers,
                AdditionalKilometerPrice,
                TaxRate,
                InitialPaidAmount,
                PaymentMethod,
                PaymentDate ?? DateTime.Now,
                ActualDeliveryDate,
                ReceivingOdometer,
                ConsumedMileage,
                Mileage,
                ExitFuel,
                SerialNumber,
                AdditionContractPrice,
                RentalAdditionsPrice,
                RequiredInsurancePrice,
                RentalDaysCost,
                TotalIncludetax,
                Discount
            );

            if (newId > 0)
            {
                AgreementID = newId;
                mode = enMode.Update;

                foreach (var item in AdditionContracts)
                    ClsAgreementAdditionContractData.Add(newId, item.Id, item.Price);

                foreach (var item in RentalAdditions)
                    ClsAgreementRentalAdditionData.AddNew(newId, item.Id, item.Price);

                foreach (var item in RequiredInsurances)
                    ClsAgreementRequiredInsuranceData.AddNew(newId, item.Id, item.Price);

                return true;
            }
            return false;
        }

        private bool UpdateAgreement()
        {
            if (!AgreementID.HasValue)
                return false;

            int id = AgreementID.Value;

            // Remove old linked items before update
            ClsAgreementAdditionContractData.DeleteByAgreementId(id);
            ClsAgreementRentalAdditionData.DeleteByAgreementId(id);
            ClsAgreementRequiredInsuranceData.DeleteByAgreementId(id);

            bool updated = ClsAgreementData.EditAgreement(
                id,
                CustomerID,
                CarID,
                PickupBranchID,
                DropOffBranchID,
                StartDate,
                EndDate,
                AgreedPrice,
                RentalPenaltyPerDay,
                TotalAmountBeforeTax,
                PermittedDailyKilometers,
                AdditionalKilometerPrice,
                TaxRate,
                InitialPaidAmount,
                PaymentMethod,
                PaymentDate ?? DateTime.Now,
                ActualDeliveryDate,
                ReceivingOdometer,
                ConsumedMileage,
                Mileage,
                ExitFuel,
                SerialNumber,
                AdditionContractPrice,
                RentalAdditionsPrice,
                RequiredInsurancePrice,
                RentalDaysCost,
                TotalIncludetax,
                Discount,
                entryFuel
            );

            if (!updated)
                return false;

            // Add new linked items after update
            foreach (var item in AdditionContracts)
                ClsAgreementAdditionContractData.Add(id, item.Id, item.Price);

            foreach (var item in RentalAdditions)
                ClsAgreementRentalAdditionData.AddNew(id, item.Id, item.Price);

            foreach (var item in RequiredInsurances)
                ClsAgreementRequiredInsuranceData.AddNew(id, item.Id, item.Price);

            return true;
        }

        public static bool DeleteAgreement(int agreementId)
        {
            ClsAgreementAdditionContractData.DeleteByAgreementId(agreementId);
            ClsAgreementRentalAdditionData.DeleteByAgreementId(agreementId);
            ClsAgreementRequiredInsuranceData.DeleteByAgreementId(agreementId);

            return ClsAgreementData.DeleteAgreement(agreementId);
        }

        public static ClsAgreement FindById(int agreementId)
        {
            int customerID = 0, carID = 0, pickupBranchID = 0, dropOffBranchID = 0, serialNumber = 0;
            DateTime startDate = DateTime.MinValue, endDate = DateTime.MinValue, paymentDate = DateTime.MinValue;
            DateTime? actualDeliveryDate = null;
            decimal agreedPrice = 0, taxRate = 0;
            decimal? rentalPenaltyPerDay = null, initialPaidAmount = null,
                additionContractPrice = null, rentalAdditionsPrice = null,
                requiredInsurancePrice = null, rentalDaysCost = null,
                totalIncludetax = null, additionalKilometerPrice = null, totalAmountBeforeTax = null, Discount = null;
            int? permittedDailyKilometers = null, receivingOdometer = null, consumedMileage = null, mileage = null;
            string paymentMethod = null, exitFuel = null, entryFuel = null;

            bool found = ClsAgreementData.GetAgreementById(
                agreementId,
                ref customerID,
                ref carID,
                ref pickupBranchID,
                ref dropOffBranchID,
                ref startDate,
                ref endDate,
                ref agreedPrice,
                ref rentalPenaltyPerDay,
                ref totalAmountBeforeTax,
                ref permittedDailyKilometers,
                ref additionalKilometerPrice,
                ref taxRate,
                ref initialPaidAmount,
                ref paymentMethod,
                ref paymentDate,
                ref actualDeliveryDate,
                ref receivingOdometer,
                ref consumedMileage,
                ref mileage,
                ref exitFuel,
                ref serialNumber,
                ref additionContractPrice,
                ref rentalAdditionsPrice,
                ref requiredInsurancePrice,
                ref rentalDaysCost,
                ref totalIncludetax,
                ref Discount,
                ref entryFuel
            );

            if (!found)
                return null;

            var agreement = new ClsAgreement(
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
                paymentMethod ?? string.Empty,
                paymentDate,
                actualDeliveryDate,
                receivingOdometer,
                consumedMileage,
                mileage,
                serialNumber,
                additionContractPrice,
                rentalAdditionsPrice,
                requiredInsurancePrice,
                rentalDaysCost,
                totalIncludetax,
                Discount,
                entryFuel
            );



           

            // Load linked items
            DataTable dtAdditionContracts = ClsAgreementAdditionContractData.GetAllByAgreementId(agreementId);
            agreement.AdditionContracts = dtAdditionContracts.AsEnumerable()
                .Select(row => (Id: row.Field<int>("AdditionContractID"), Price: row.Field<decimal>("ActualPrice"), Name: row.Field<string>("name")))
                .ToList();

            DataTable dtRentalAdditions = ClsAgreementRentalAdditionData.GetAllByAgreementId(agreementId);
            agreement.RentalAdditions = dtRentalAdditions.AsEnumerable()
                .Select(row => (Id: row.Field<int>("RentalAdditionID"), Price: row.Field<decimal>("ActualPrice"), Name: row.Field<string>("RentalName")))
                .ToList();

            DataTable dtRequiredInsurances = ClsAgreementRequiredInsuranceData.GetAllByAgreementId(agreementId);
            agreement.RequiredInsurances = dtRequiredInsurances.AsEnumerable()
                .Select(row => (Id: row.Field<int>("RequiredInsuranceID"), Price: row.Field<decimal>("ActualPrice"), Name: row.Field<string>("ItemName")))
                .ToList();

            return agreement;
        }

        public static DataTable GetAllAgreements()
        {
            return ClsAgreementData.GetAllAgreements();
        }

        public static DataTable GetAllAgreementsFullInfo()
        {
            return ClsAgreementData.GetAllAgreementsFullInfo();
        }

        public static int GetLastSerialNumber()
        {
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
