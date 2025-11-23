using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsRentalAddition
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? RentalAdditionID { get; set; }
        public string RentalName { get; set; }
        public int PaymentMethodID { get; set; }
        public decimal Price { get; set; }
        public string RentalNote { get; set; }
        public bool IsActive { get; set; }
        public bool IsTaxIncluded { get; set; }   // NEW FIELD

        public ClsRentalAddition()
        {
            RentalAdditionID = null;
            RentalName = "";
            PaymentMethodID = 0;
            Price = 0m;
            RentalNote = "";
            IsActive = true;
            IsTaxIncluded = false;  // default
            mode = enMode.AddNew;
        }

        public ClsRentalAddition(
            int? rentalAdditionId,
            string rentalName,
            int paymentMethodId,
            decimal price,
            string rentalNote,
            bool isActive,
            bool isTaxIncluded)
        {
            RentalAdditionID = rentalAdditionId;
            RentalName = rentalName;
            PaymentMethodID = paymentMethodId;
            Price = price;
            RentalNote = rentalNote;
            IsActive = isActive;
            IsTaxIncluded = isTaxIncluded;
            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;
            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewRentalAddition();
                    break;
                case enMode.Update:
                    result = UpdateRentalAddition();
                    break;
            }
            return result;
        }

        private bool AddNewRentalAddition()
        {
            int id = ClsRentalAdditionsData.AddNewRentalAddition(
                RentalName,
                PaymentMethodID,
                Price,
                RentalNote,
                IsActive,
                IsTaxIncluded);

            if (id != -1)
            {
                RentalAdditionID = id;
                mode = enMode.Update;
                return true;
            }
            return false;
        }

        private bool UpdateRentalAddition()
        {
            if (!RentalAdditionID.HasValue)
                return false;

            bool result = ClsRentalAdditionsData.EditRentalAddition(
                RentalAdditionID.Value,
                RentalName,
                PaymentMethodID,
                Price,
                RentalNote,
                IsActive,
                IsTaxIncluded);

            return result;
        }

        public static bool DeleteRentalAddition(int rentalAdditionId)
        {
            return ClsRentalAdditionsData.DeleteRentalAddition(rentalAdditionId);
        }

        public static ClsRentalAddition FindById(int rentalAdditionId)
        {
            string rentalName = "";
            int paymentMethodId = 0;
            decimal price = 0m;
            string rentalNote = "";
            bool isActive = true;
            bool isTaxIncluded = false;

            bool found = ClsRentalAdditionsData.GetRentalAdditionInfoById(
                rentalAdditionId,
                ref rentalName,
                ref paymentMethodId,
                ref price,
                ref rentalNote,
                ref isActive,
                ref isTaxIncluded);

            if (!found)
                return null;

            return new ClsRentalAddition(
                rentalAdditionId,
                rentalName,
                paymentMethodId,
                price,
                rentalNote,
                isActive,
                isTaxIncluded);
        }

        public static DataTable GetRentalAdditionsDataTable()
        {
            return ClsRentalAdditionsData.GetAllRentalAdditions();
        }

        public static bool RentalAdditionExistsByName(string rentalName)
        {
            return ClsRentalAdditionsData.RentalAdditionExistsByName(rentalName);
        }
    }
}
