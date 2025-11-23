using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsCustomerData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewCustomer(
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

            // New fields added here:
            string idTypeEn,
            string idTypeAr,
            string idNumber,
            string identityNumber,
            string identityPlaceOfIssueEn,
            string identityPlaceOfIssueAr,
            string licenseNumber,
            string licenseCategoryEn,
            string licenseCategoryAr,
            string licensePlaceOfIssueEn,
            DateTime? licenseIssueDate,
            DateTime? licenseExpiryDate,
            string licensePlaceOfIssueAr)
        {
            string query = @"
                INSERT INTO Customers
                (
                    customer_type, customer_name_en, customer_name_ar, phone_number, email, address_en, address_ar,
                    notes_en, notes_ar, blacklist, company_id, nationality_id, mediator_id,
                    id_type_en, id_type_ar, id_number, identity_number, identity_place_of_issue_en, identity_place_of_issue_ar,
                    license_number, license_category_en, license_category_ar, license_place_of_issue_en, license_issue_date,
                    license_expiry_date, license_place_of_issue_ar,
                    created_at, updated_at
                )
                VALUES
                (
                    @CustomerType, @CustomerNameEn, @CustomerNameAr, @PhoneNumber, @Email, @AddressEn, @AddressAr,
                    @NotesEn, @NotesAr, @Blacklist, @CompanyId, @NationalityId, @MediatorId,
                    @IdTypeEn, @IdTypeAr, @IdNumber, @IdentityNumber, @IdentityPlaceOfIssueEn, @IdentityPlaceOfIssueAr,
                    @LicenseNumber, @LicenseCategoryEn, @LicenseCategoryAr, @LicensePlaceOfIssueEn, @LicenseIssueDate,
                    @LicenseExpiryDate, @LicensePlaceOfIssueAr,
                    GETDATE(), GETDATE()
                );
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                // existing params
                cmd.Parameters.AddWithValue("@CustomerType", customerType);
                cmd.Parameters.AddWithValue("@CustomerNameEn", customerNameEn);
                cmd.Parameters.AddWithValue("@CustomerNameAr", customerNameAr);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@AddressEn", addressEn);
                cmd.Parameters.AddWithValue("@AddressAr", addressAr);
                cmd.Parameters.AddWithValue("@NotesEn", notesEn);
                cmd.Parameters.AddWithValue("@NotesAr", notesAr);
                cmd.Parameters.AddWithValue("@Blacklist", blacklist);
                cmd.Parameters.AddWithValue("@CompanyId", (object)companyId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NationalityId", (object)nationalityId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MediatorId", (object)mediatorId ?? DBNull.Value);

                // new params
                cmd.Parameters.AddWithValue("@IdTypeEn", (object)idTypeEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdTypeAr", (object)idTypeAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdNumber", (object)idNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityNumber", (object)identityNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityPlaceOfIssueEn", (object)identityPlaceOfIssueEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityPlaceOfIssueAr", (object)identityPlaceOfIssueAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseNumber", (object)licenseNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseCategoryEn", (object)licenseCategoryEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseCategoryAr", (object)licenseCategoryAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicensePlaceOfIssueEn", (object)licensePlaceOfIssueEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseIssueDate", (object)licenseIssueDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseExpiryDate", (object)licenseExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicensePlaceOfIssueAr", (object)licensePlaceOfIssueAr ?? DBNull.Value);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditCustomer(
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

            // New fields added here:
            string idTypeEn,
            string idTypeAr,
            string idNumber,
            string identityNumber,
            string identityPlaceOfIssueEn,
            string identityPlaceOfIssueAr,
            string licenseNumber,
            string licenseCategoryEn,
            string licenseCategoryAr,
            string licensePlaceOfIssueEn,
            DateTime? licenseIssueDate,
            DateTime? licenseExpiryDate,
            string licensePlaceOfIssueAr)
        {
            string query = @"
                UPDATE Customers SET
                    customer_type = @CustomerType,
                    customer_name_en = @CustomerNameEn,
                    customer_name_ar = @CustomerNameAr,
                    phone_number = @PhoneNumber,
                    email = @Email,
                    address_en = @AddressEn,
                    address_ar = @AddressAr,
                    notes_en = @NotesEn,
                    notes_ar = @NotesAr,
                    blacklist = @Blacklist,
                    company_id = @CompanyId,
                    nationality_id = @NationalityId,
                    mediator_id = @MediatorId,

                    id_type_en = @IdTypeEn,
                    id_type_ar = @IdTypeAr,
                    id_number = @IdNumber,
                    identity_number = @IdentityNumber,
                    identity_place_of_issue_en = @IdentityPlaceOfIssueEn,
                    identity_place_of_issue_ar = @IdentityPlaceOfIssueAr,

                    license_number = @LicenseNumber,
                    license_category_en = @LicenseCategoryEn,
                    license_category_ar = @LicenseCategoryAr,
                    license_place_of_issue_en = @LicensePlaceOfIssueEn,
                    license_issue_date = @LicenseIssueDate,
                    license_expiry_date = @LicenseExpiryDate,
                    license_place_of_issue_ar = @LicensePlaceOfIssueAr,

                    updated_at = GETDATE()
                WHERE customer_id = @CustomerId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@CustomerType", customerType);
                cmd.Parameters.AddWithValue("@CustomerNameEn", customerNameEn);
                cmd.Parameters.AddWithValue("@CustomerNameAr", customerNameAr);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@AddressEn", addressEn);
                cmd.Parameters.AddWithValue("@AddressAr", addressAr);
                cmd.Parameters.AddWithValue("@NotesEn", notesEn);
                cmd.Parameters.AddWithValue("@NotesAr", notesAr);
                cmd.Parameters.AddWithValue("@Blacklist", blacklist);
                cmd.Parameters.AddWithValue("@CompanyId", (object)companyId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NationalityId", (object)nationalityId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MediatorId", (object)mediatorId ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@IdTypeEn", (object)idTypeEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdTypeAr", (object)idTypeAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdNumber", (object)idNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityNumber", (object)identityNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityPlaceOfIssueEn", (object)identityPlaceOfIssueEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityPlaceOfIssueAr", (object)identityPlaceOfIssueAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseNumber", (object)licenseNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseCategoryEn", (object)licenseCategoryEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseCategoryAr", (object)licenseCategoryAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicensePlaceOfIssueEn", (object)licensePlaceOfIssueEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseIssueDate", (object)licenseIssueDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseExpiryDate", (object)licenseExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicensePlaceOfIssueAr", (object)licensePlaceOfIssueAr ?? DBNull.Value);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteCustomer(int customerId)
        {
            try
            {
                string query = "DELETE FROM Customers WHERE customer_id = @CustomerId";

                using (SqlConnection connection = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }

            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsCustomerExist(int customerId)
        {
            string query = "SELECT COUNT(1) FROM Customers WHERE customer_id = @CustomerId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetAllCustomers()
        {
            string query = "SELECT * FROM Customers";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetCustomerInfoById(
            int customerId,
            ref string customerType,
            ref string customerNameEn,
            ref string customerNameAr,
            ref string phoneNumber,
            ref string email,
            ref string addressEn,
            ref string addressAr,
            ref string notesEn,
            ref string notesAr,
            ref bool blacklist,
            ref int? companyId,
            ref int? nationalityId,
            ref int? mediatorId,

            // New fields added here as ref params
            ref string idTypeEn,
            ref string idTypeAr,
            ref string idNumber,
            ref string identityNumber,
            ref string identityPlaceOfIssueEn,
            ref string identityPlaceOfIssueAr,
            ref string licenseNumber,
            ref string licenseCategoryEn,
            ref string licenseCategoryAr,
            ref string licensePlaceOfIssueEn,
            ref DateTime? licenseIssueDate,
            ref DateTime? licenseExpiryDate,
            ref string licensePlaceOfIssueAr)
        {
            string query = "SELECT * FROM Customers WHERE customer_id = @CustomerId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customerType = reader["customer_type"]?.ToString();
                        customerNameEn = reader["customer_name_en"]?.ToString();
                        customerNameAr = reader["customer_name_ar"]?.ToString();
                        phoneNumber = reader["phone_number"]?.ToString();
                        email = reader["email"]?.ToString();
                        addressEn = reader["address_en"]?.ToString();
                        addressAr = reader["address_ar"]?.ToString();
                        notesEn = reader["notes_en"]?.ToString();
                        notesAr = reader["notes_ar"]?.ToString();
                        blacklist = Convert.ToBoolean(reader["blacklist"]);

                        companyId = reader["company_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["company_id"]);
                        nationalityId = reader["nationality_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["nationality_id"]);
                        mediatorId = reader["mediator_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["mediator_id"]);

                        // New fields assigned here:
                        idTypeEn = reader["id_type_en"]?.ToString();
                        idTypeAr = reader["id_type_ar"]?.ToString();
                        idNumber = reader["id_number"]?.ToString();
                        identityNumber = reader["identity_number"]?.ToString();
                        identityPlaceOfIssueEn = reader["identity_place_of_issue_en"]?.ToString();
                        identityPlaceOfIssueAr = reader["identity_place_of_issue_ar"]?.ToString();

                        licenseNumber = reader["license_number"]?.ToString();
                        licenseCategoryEn = reader["license_category_en"]?.ToString();
                        licenseCategoryAr = reader["license_category_ar"]?.ToString();
                        licensePlaceOfIssueEn = reader["license_place_of_issue_en"]?.ToString();

                        licenseIssueDate = reader["license_issue_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["license_issue_date"]);
                        licenseExpiryDate = reader["license_expiry_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["license_expiry_date"]);

                        licensePlaceOfIssueAr = reader["license_place_of_issue_ar"]?.ToString();

                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CustomerExistsByEnglishName(string nameEn)
        {
            string query = "SELECT COUNT(1) FROM Customers WHERE customer_name_en = @NameEn";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameEn", nameEn);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static bool CustomerExistsByArabicName(string nameAr)
        {
            string query = "SELECT COUNT(1) FROM Customers WHERE customer_name_ar = @NameAr";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameAr", nameAr);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetCustomerTypes()
        {
            DataTable dt = new DataTable();

            string query = @"
                        SELECT 
                            customer_type,
                            COUNT(*) AS CustomerCount
                        FROM Customers
                        GROUP BY customer_type;
                    ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                connection.Open();
                da.Fill(dt);
            }

            return dt;
        }

        public static bool GetCustomerInfoByName(
            string customerNameEn,
            string customerNameAr,
            ref int? customerId,
            ref string customerType,
            ref string phoneNumber,
            ref string email,
            ref string addressEn,
            ref string addressAr,
            ref string notesEn,
            ref string notesAr,
            ref bool blacklist,
            ref int? companyId,
            ref int? nationalityId,
            ref int? mediatorId,

            // New fields added here as ref params
            ref string idTypeEn,
            ref string idTypeAr,
            ref string idNumber,
            ref string identityNumber,
            ref string identityPlaceOfIssueEn,
            ref string identityPlaceOfIssueAr,
            ref string licenseNumber,
            ref string licenseCategoryEn,
            ref string licenseCategoryAr,
            ref string licensePlaceOfIssueEn,
            ref DateTime? licenseIssueDate,
            ref DateTime? licenseExpiryDate,
            ref string licensePlaceOfIssueAr)
        {
            string query = @"
                SELECT * FROM Customers 
                WHERE (customer_name_en = @NameEn OR customer_name_ar = @NameAr)";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameEn", customerNameEn ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NameAr", customerNameAr ?? (object)DBNull.Value);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customerId = Convert.ToInt32(reader["customer_id"]);
                        customerType = reader["customer_type"]?.ToString();
                        phoneNumber = reader["phone_number"]?.ToString();
                        email = reader["email"]?.ToString();
                        addressEn = reader["address_en"]?.ToString();
                        addressAr = reader["address_ar"]?.ToString();
                        notesEn = reader["notes_en"]?.ToString();
                        notesAr = reader["notes_ar"]?.ToString();
                        blacklist = Convert.ToBoolean(reader["blacklist"]);

                        companyId = reader["company_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["company_id"]);
                        nationalityId = reader["nationality_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["nationality_id"]);
                        mediatorId = reader["mediator_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["mediator_id"]);

                        // New fields assigned here:
                        idTypeEn = reader["id_type_en"]?.ToString();
                        idTypeAr = reader["id_type_ar"]?.ToString();
                        idNumber = reader["id_number"]?.ToString();
                        identityNumber = reader["identity_number"]?.ToString();
                        identityPlaceOfIssueEn = reader["identity_place_of_issue_en"]?.ToString();
                        identityPlaceOfIssueAr = reader["identity_place_of_issue_ar"]?.ToString();

                        licenseNumber = reader["license_number"]?.ToString();
                        licenseCategoryEn = reader["license_category_en"]?.ToString();
                        licenseCategoryAr = reader["license_category_ar"]?.ToString();
                        licensePlaceOfIssueEn = reader["license_place_of_issue_en"]?.ToString();

                        licenseIssueDate = reader["license_issue_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["license_issue_date"]);
                        licenseExpiryDate = reader["license_expiry_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["license_expiry_date"]);

                        licensePlaceOfIssueAr = reader["license_place_of_issue_ar"]?.ToString();

                        return true;                                                                                                                                                                                                                                                                      
                    }
                }
            }
            return false;
        }
    }
}

