using CarRentalDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace CarRentalBusiness
{
    public enum EntityState
    {
        New,
        Updated
    }

    public class ClsCompany
    {
        public int? ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string AddressEn { get; set; }
        public string AddressAr { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public EntityState State { get; set; } = EntityState.New;

        // Default constructor
        public ClsCompany() { }

        // Parameterized constructor
        public ClsCompany(int? id, string nameEn, string nameAr, string addressEn, string addressAr,
                          string phoneNumber, string email, string image)
        {
            ID = id;
            NameEn = nameEn;
            NameAr = nameAr;
            AddressEn = addressEn;
            AddressAr = addressAr;
            PhoneNumber = phoneNumber;
            Email = email;
            Image = image;

            // Set state based on presence of ID
            State = (id == null || id == 0) ? EntityState.New : EntityState.Updated;
        }

        // Add new company
        private bool AddCompany()
        {
            return clsCompaniesData.AddNewCompany(NameEn, NameAr, AddressEn, AddressAr, PhoneNumber, Email, Image);
        }

        // Update existing company
        private bool UpdateCompany()
        {
            if (ID == null) return false;
            return clsCompaniesData.UpdateCompany(ID.Value, NameEn, NameAr, AddressEn, AddressAr, PhoneNumber, Email, Image);
        }

        // Unified save method based on state
        public bool Save()
        {
            if (State == EntityState.New)
            {
                var success = AddCompany();
                if (success)
                    State = EntityState.Updated; // Switch state after successful add
                return success;
            }
            else if (State == EntityState.Updated)
            {
                return UpdateCompany();
            }
            else
            {
                throw new InvalidOperationException("Unknown entity state.");
            }
        }

        // Delete company by ID
        public bool DeleteCompany()
        {
            if (ID == null) return false;
            return clsCompaniesData.DeleteCompany(ID.Value);
        }

        // Load company data from database by ID and fill this instance
        public bool LoadByID(int id)
        {
            var row = clsCompaniesData.FindCompanyByID(id);
            if (row == null) return false;

            ID = Convert.ToInt32(row["companyid"]);
            NameEn = row["company_name_en"].ToString();
            NameAr = row["company_name_ar"].ToString();
            AddressEn = row["address_en"] == DBNull.Value ? null : row["address_en"].ToString();
            AddressAr = row["address_ar"] == DBNull.Value ? null : row["address_ar"].ToString();
            PhoneNumber = row["phone_number"] == DBNull.Value ? null : row["phone_number"].ToString();
            Email = row["email"] == DBNull.Value ? null : row["email"].ToString();
            Image = row["image"] == DBNull.Value ? null : row["image"].ToString();

            State = EntityState.Updated; // Loaded from DB means existing entity
            return true;
        }


        public static List<ClsCompany> GetAllCompanies()
        {
            var dt = clsCompaniesData.GetAllCompanies();
            var companies = new List<ClsCompany>();

            foreach (DataRow row in dt.Rows)
            {
                var company = new ClsCompany
                {
                    ID = Convert.ToInt32(row["companyid"]),
                    NameEn = row["company_name_en"].ToString(),
                    NameAr = row["company_name_ar"].ToString(),
                    AddressEn = row["address_en"] == DBNull.Value ? null : row["address_en"].ToString(),
                    AddressAr = row["address_ar"] == DBNull.Value ? null : row["address_ar"].ToString(),
                    PhoneNumber = row["phone_number"] == DBNull.Value ? null : row["phone_number"].ToString(),
                    Email = row["email"] == DBNull.Value ? null : row["email"].ToString(),
                    Image = row["image"] == DBNull.Value ? null : row["image"].ToString(),
                    State = EntityState.Updated
                };

                companies.Add(company);
            }

            return companies;
        }

        public static ClsCompany FindById(int id)
        {
            int companyId = 0;
            string nameEn = string.Empty;
            string nameAr = string.Empty;
            string addressEn = null;
            string addressAr = null;
            string phoneNumber = null;
            string email = null;
            string image = null;

            bool found = clsCompaniesData.FindCompanyByID(
                id,
                ref companyId,
                ref nameEn,
                ref nameAr,
                ref addressEn,
                ref addressAr,
                ref phoneNumber,
                ref email,
                ref image);

            if (!found)
                return null;

            return new ClsCompany(companyId, nameEn, nameAr, addressEn, addressAr, phoneNumber, email, image)
            {
                State = EntityState.Updated
            };
        }


    }
}
