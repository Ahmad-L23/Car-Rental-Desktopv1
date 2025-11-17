using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsDocument
    {
        private enum enMode { AddNew, Update }
        private enMode mode = enMode.AddNew;

        public int? DocumentId { get; set; }
        public string DocumentTypeEn { get; set; }
        public string DocumentTypeAr { get; set; }
        public string IdTypeEn { get; set; }
        public string IdTypeAr { get; set; }
        public string IdNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseCategoryEn { get; set; }
        public string LicenseCategoryAr { get; set; }
        public string LicensePlaceOfIssueEn { get; set; }
        public string LicensePlaceOfIssueAr { get; set; }
        public DateTime? LicenseIssueDate { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public string IdentityPlaceOfIssueEn { get; set; }
        public string IdentityPlaceOfIssueAr { get; set; }

        // ✅ Composition: each Document belongs to one Customer
        public ClsCustomer Customer { get; set; }

        public ClsDocument()
        {
            DocumentId = null;
            DocumentTypeEn = "";
            DocumentTypeAr = "";
            IdTypeEn = "";
            IdTypeAr = "";
            IdNumber = "";
            IdentityNumber = "";
            LicenseNumber = "";
            LicenseCategoryEn = "";
            LicenseCategoryAr = "";
            LicensePlaceOfIssueEn = "";
            LicensePlaceOfIssueAr = "";
            LicenseIssueDate = null;
            LicenseExpiryDate = null;
            IdentityPlaceOfIssueEn = "";
            IdentityPlaceOfIssueAr = "";
            Customer = null; // initially no customer assigned
            mode = enMode.AddNew;
        }

        public ClsDocument(
            int documentId,
            int customerId,
            string documentTypeEn,
            string documentTypeAr,
            string idTypeEn,
            string idTypeAr,
            string idNumber,
            string identityNumber,
            string licenseNumber,
            string licenseCategoryEn,
            string licenseCategoryAr,
            string licensePlaceOfIssueEn,
            string licensePlaceOfIssueAr,
            DateTime? licenseIssueDate,
            DateTime? licenseExpiryDate,
            string identityPlaceOfIssueEn,
            string identityPlaceOfIssueAr)
        {
            DocumentId = documentId;
            DocumentTypeEn = documentTypeEn;
            DocumentTypeAr = documentTypeAr;
            IdTypeEn = idTypeEn;
            IdTypeAr = idTypeAr;
            IdNumber = idNumber;
            IdentityNumber = identityNumber;
            LicenseNumber = licenseNumber;
            LicenseCategoryEn = licenseCategoryEn;
            LicenseCategoryAr = licenseCategoryAr;
            LicensePlaceOfIssueEn = licensePlaceOfIssueEn;
            LicensePlaceOfIssueAr = licensePlaceOfIssueAr;
            LicenseIssueDate = licenseIssueDate;
            LicenseExpiryDate = licenseExpiryDate;
            IdentityPlaceOfIssueEn = identityPlaceOfIssueEn;
            IdentityPlaceOfIssueAr = identityPlaceOfIssueAr;
            Customer = ClsCustomer.FindById(customerId); // ✅ load customer composition
            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;

            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewDocument();
                    break;

                case enMode.Update:
                    result = UpdateDocument();
                    break;
            }

            return result;
        }

        private bool AddNewDocument()
        {
            if (Customer == null || !Customer.CustomerId.HasValue)
                throw new Exception("Cannot save document without a valid customer.");

            int newId = ClsDocumentData.AddNewDocument(
                Customer.CustomerId.Value,
                
                IdTypeEn,
                IdTypeAr,
                IdNumber,
                IdentityNumber,
                LicenseNumber,
                LicenseCategoryEn,
                LicenseCategoryAr,
                LicensePlaceOfIssueEn,
                LicensePlaceOfIssueAr,
                LicenseIssueDate,
                LicenseExpiryDate,
                IdentityPlaceOfIssueEn,
                IdentityPlaceOfIssueAr
            );

            if (newId != -1)
            {
                DocumentId = newId;
                mode = enMode.Update;
                return true;
            }

            return false;
        }

        private bool UpdateDocument()
        {
            if (!DocumentId.HasValue)
                return false;

            return ClsDocumentData.EditDocument(
                DocumentId.Value,
                Customer?.CustomerId ?? -1,
                DocumentTypeEn,
                DocumentTypeAr,
                IdTypeEn,
                IdTypeAr,
                IdNumber,
                IdentityNumber,
                LicenseNumber,
                LicenseCategoryEn,
                LicenseCategoryAr,
                LicensePlaceOfIssueEn,
                LicensePlaceOfIssueAr,
                LicenseIssueDate,
                LicenseExpiryDate,
                IdentityPlaceOfIssueEn,
                IdentityPlaceOfIssueAr
            );
        }

        public static ClsDocument FindById(int documentId)
        {
            int? customerId = null;
            string documentTypeEn = "", documentTypeAr = "", idTypeEn = "", idTypeAr = "", idNumber = "";
            string identityNumber = "", licenseNumber = "", licenseCategoryEn = "", licenseCategoryAr = "";
            string licensePlaceOfIssueEn = "", licensePlaceOfIssueAr = "", identityPlaceOfIssueEn = "", identityPlaceOfIssueAr = "";
            DateTime? licenseIssueDate = null, licenseExpiryDate = null;

            bool found = ClsDocumentData.GetDocumentInfoById(
                documentId,
                ref customerId,
                ref idTypeEn,
                ref idTypeAr,
                ref idNumber,
                ref identityNumber,
                ref licenseNumber,
                ref licenseCategoryEn,
                ref licenseCategoryAr,
                ref licensePlaceOfIssueEn,
                ref licensePlaceOfIssueAr,
                ref licenseIssueDate,
                ref licenseExpiryDate,
                ref identityPlaceOfIssueEn,
                ref identityPlaceOfIssueAr
            );

            if (!found)
                return null;

            return new ClsDocument(
                documentId,
                customerId ?? 0,
                documentTypeEn,
                documentTypeAr,
                idTypeEn,
                idTypeAr,
                idNumber,
                identityNumber,
                licenseNumber,
                licenseCategoryEn,
                licenseCategoryAr,
                licensePlaceOfIssueEn,
                licensePlaceOfIssueAr,
                licenseIssueDate,
                licenseExpiryDate,
                identityPlaceOfIssueEn,
                identityPlaceOfIssueAr
            );
        }

        public static DataTable GetDocumentsByCustomerId(int customerId)
        {
            return ClsDocumentData.GetDocumentsByCustomerId(customerId);
        }
    }
}
