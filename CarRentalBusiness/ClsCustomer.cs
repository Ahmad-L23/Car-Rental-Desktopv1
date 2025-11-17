using CarRentalDataAccess;
using CarRentalDataAccessLayer;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsCustomer
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? CustomerId { get; set; }
        public string CustomerType { get; set; }
        public string CustomerNameEn { get; set; }
        public string CustomerNameAr { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressEn { get; set; }
        public string AddressAr { get; set; }
        public string NotesEn { get; set; }
        public string NotesAr { get; set; }
        public bool Blacklist { get; set; }
        public string BlacklistStatus { get; set; }

        // Composition: Related entities
        public ClsCompany Company { get; set; }        // Null if no company
        public ClsNationlity Nationality { get; set; } // Null if no nationality
        public ClsMediator Mediator { get; set; }      // Null if no mediator

        public ClsCustomer()
        {
            CustomerId = null;
            CustomerType = "";
            CustomerNameEn = "";
            CustomerNameAr = "";
            PhoneNumber = "";
            Email = "";
            AddressEn = "";
            AddressAr = "";
            NotesEn = "";
            NotesAr = "";
            Blacklist = false;
            BlacklistStatus = "Active";
            Company = null;
            Nationality = null;
            Mediator = null;
            mode = enMode.AddNew;
        }

        public ClsCustomer(
            int? customerId,
            string customerType,
            string customerNameEn,
            string customerNameAr,
            string phoneNumber,
            string email,
            string addressEn,
            string addressAr,
            string notesEn,
            string notesAr,
            bool blacklist,
            int? companyId,
            int? nationalityId,
            int? mediatorId,
            string blacklistStatus = null)
        {
            CustomerId = customerId;
            CustomerType = customerType;
            CustomerNameEn = customerNameEn;
            CustomerNameAr = customerNameAr;
            PhoneNumber = phoneNumber;
            Email = email;
            AddressEn = addressEn;
            AddressAr = addressAr;
            NotesEn = notesEn;
            NotesAr = notesAr;
            Blacklist = blacklist;
            BlacklistStatus = blacklistStatus ?? (blacklist ? "Blacklisted" : "Active");
            mode = enMode.Update;

            // Load related entities if their IDs are present
            Company = (companyId.HasValue && companyId.Value > 0)
                ? ClsCompany.FindById(companyId.Value)
                : null;

            Nationality = (nationalityId.HasValue && nationalityId.Value > 0)
                ? ClsNationlity.GetNationalityInfoById(nationalityId.Value)
                : null;

            Mediator = null;
            if (mediatorId.HasValue && mediatorId.Value > 0)
            {
                ClsMediator mediator;
                if (ClsMediator.GetMediatorInfoById(mediatorId.Value, out mediator))
                {
                    Mediator = mediator;
                }
            }
        }

        public bool Save()
        {
            bool result = false;
            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewCustomer();
                    break;
                case enMode.Update:
                    result = UpdateCustomer();
                    break;
            }

            BlacklistStatus = Blacklist ? "Blacklisted" : "Active";
            return result;
        }

        private bool AddNewCustomer()
        {
            int id = ClsCustomerData.AddNewCustomer(
                CustomerType,
                CustomerNameEn,
                CustomerNameAr,
                PhoneNumber,
                Email,
                AddressEn,
                AddressAr,
                NotesEn,
                NotesAr,
                Blacklist,
                Company?.ID,
                Nationality?.Id,
                Mediator?.id);

            if (id != -1)
            {
                CustomerId = id;
                return true;
            }
            return false;
        }

        private bool UpdateCustomer()
        {
            if (!CustomerId.HasValue)
                return false;

            bool result = ClsCustomerData.EditCustomer(
                CustomerId.Value,
                CustomerType,
                CustomerNameEn,
                CustomerNameAr,
                PhoneNumber,
                Email,
                AddressEn,
                AddressAr,
                NotesEn,
                NotesAr,
                Blacklist,
                Company?.ID,
                Nationality?.Id,
                Mediator?.id);

            return result;
        }

        public static bool DeleteCustomer(int customerId)
        {
            return ClsCustomerData.DeleteCustomer(customerId);
        }

        public static ClsCustomer FindById(int customerId)
        {
            string customerType = "";
            string customerNameEn = "";
            string customerNameAr = "";
            string phoneNumber = "";
            string email = "";
            string addressEn = "";
            string addressAr = "";
            string notesEn = "";
            string notesAr = "";
            bool blacklist = false;
            string blacklistStatus = null;
            int? companyId = null;
            int? nationalityId = null;
            int? mediatorId = null;

            bool found = ClsCustomerData.GetCustomerInfoById(
                customerId,
                ref customerType,
                ref customerNameEn,
                ref customerNameAr,
                ref phoneNumber,
                ref email,
                ref addressEn,
                ref addressAr,
                ref notesEn,
                ref notesAr,
                ref blacklist,
                ref companyId,
                ref nationalityId,
                ref mediatorId);

            if (!found)
                return null;

            return new ClsCustomer(
                customerId,
                customerType,
                customerNameEn,
                customerNameAr,
                phoneNumber,
                email,
                addressEn,
                addressAr,
                notesEn,
                notesAr,
                blacklist,
                companyId,
                nationalityId,
                mediatorId,
                blacklistStatus);
        }

        

        public static DataTable GetCustomersDataTable()
        {
            return ClsCustomerData.GetAllCustomers();
        }

        public static bool CustomerExistsByEnglishName(string nameEn)
        {
            return ClsCustomerData.CustomerExistsByEnglishName(nameEn);
        }

        public static bool CustomerExistsByArabicName(string nameAr)
        {
            return ClsCustomerData.CustomerExistsByArabicName(nameAr);
        }

        public static DataTable GetAllCustomersTypes()
        {
            return ClsCustomerData.GetCustomerTypes();
        }
    }
}
