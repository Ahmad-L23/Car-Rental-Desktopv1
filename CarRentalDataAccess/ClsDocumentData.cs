using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsDocumentData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        #region Add New Document
        public static int AddNewDocument(
            int customerId,
            
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
            string query = @"
                INSERT INTO Documents
                (
                    customer_id,
                    
                    id_type_en,
                    id_type_ar,
                    id_number,
                    identity_number,
                    license_number,
                    license_category_en,
                    license_category_ar,
                    license_place_of_issue_en,
                    license_place_of_issue_ar,
                    license_issue_date,
                    license_expiry_date,
                    identity_place_of_issue_en,
                    identity_place_of_issue_ar
                )
                VALUES
                (
                    @CustomerId,
                   
                    @IdTypeEn,
                    @IdTypeAr,
                    @IdNumber,
                    @IdentityNumber,
                    @LicenseNumber,
                    @LicenseCategoryEn,
                    @LicenseCategoryAr,
                    @LicensePlaceOfIssueEn,
                    @LicensePlaceOfIssueAr,
                    @LicenseIssueDate,
                    @LicenseExpiryDate,
                    @IdentityPlaceOfIssueEn,
                    @IdentityPlaceOfIssueAr
                );
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
               
                cmd.Parameters.AddWithValue("@IdTypeEn", (object)idTypeEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdTypeAr", (object)idTypeAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdNumber", (object)idNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityNumber", (object)identityNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseNumber", (object)licenseNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseCategoryEn", (object)licenseCategoryEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseCategoryAr", (object)licenseCategoryAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicensePlaceOfIssueEn", (object)licensePlaceOfIssueEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicensePlaceOfIssueAr", (object)licensePlaceOfIssueAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseIssueDate", (object)licenseIssueDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseExpiryDate", (object)licenseExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityPlaceOfIssueEn", (object)identityPlaceOfIssueEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityPlaceOfIssueAr", (object)identityPlaceOfIssueAr ?? DBNull.Value);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && int.TryParse(result.ToString(), out int newId)) ? newId : -1;
            }
        }
        #endregion

        #region Edit Document
        public static bool EditDocument(
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
            string query = @"
                UPDATE Documents SET
                    customer_id = @CustomerId,
                   
                    id_type_en = @IdTypeEn,
                    id_type_ar = @IdTypeAr,
                    id_number = @IdNumber,
                    identity_number = @IdentityNumber,
                    license_number = @LicenseNumber,
                    license_category_en = @LicenseCategoryEn,
                    license_category_ar = @LicenseCategoryAr,
                    license_place_of_issue_en = @LicensePlaceOfIssueEn,
                    license_place_of_issue_ar = @LicensePlaceOfIssueAr,
                    license_issue_date = @LicenseIssueDate,
                    license_expiry_date = @LicenseExpiryDate,
                    identity_place_of_issue_en = @IdentityPlaceOfIssueEn,
                    identity_place_of_issue_ar = @IdentityPlaceOfIssueAr
                WHERE id = @DocumentId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@DocumentId", documentId);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@IdTypeEn", (object)idTypeEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdTypeAr", (object)idTypeAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdNumber", (object)idNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityNumber", (object)identityNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseNumber", (object)licenseNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseCategoryEn", (object)licenseCategoryEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseCategoryAr", (object)licenseCategoryAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicensePlaceOfIssueEn", (object)licensePlaceOfIssueEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicensePlaceOfIssueAr", (object)licensePlaceOfIssueAr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseIssueDate", (object)licenseIssueDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseExpiryDate", (object)licenseExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityPlaceOfIssueEn", (object)identityPlaceOfIssueEn ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdentityPlaceOfIssueAr", (object)identityPlaceOfIssueAr ?? DBNull.Value);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        #endregion

        #region Delete Document
        public static bool DeleteDocument(int documentId)
        {
            string query = "DELETE FROM Documents WHERE id = @DocumentId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@DocumentId", documentId);
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        #endregion

        #region Get All Documents
        public static DataTable GetAllDocuments()
        {
            string query = "SELECT * FROM Documents";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Get Documents By CustomerId
        public static DataTable GetDocumentsByCustomerId(int customerId)
        {
            string query = "SELECT * FROM Documents WHERE customer_id = @CustomerId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        #endregion

        #region Get Document Info By Id
        public static bool GetDocumentInfoById(
            int documentId,
            ref int? customerId,
            ref string idTypeEn,
            ref string idTypeAr,
            ref string idNumber,
            ref string identityNumber,
            ref string licenseNumber,
            ref string licenseCategoryEn,
            ref string licenseCategoryAr,
            ref string licensePlaceOfIssueEn,
            ref string licensePlaceOfIssueAr,
            ref DateTime? licenseIssueDate,
            ref DateTime? licenseExpiryDate,
            ref string identityPlaceOfIssueEn,
            ref string identityPlaceOfIssueAr)
        {
            string query = "SELECT * FROM Documents WHERE id = @DocumentId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@DocumentId", documentId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customerId = Convert.ToInt32(reader["customer_id"]);
                        idTypeEn = reader["id_type_en"]?.ToString();
                        idTypeAr = reader["id_type_ar"]?.ToString();
                        idNumber = reader["id_number"]?.ToString();
                        identityNumber = reader["identity_number"]?.ToString();
                        licenseNumber = reader["license_number"]?.ToString();
                        licenseCategoryEn = reader["license_category_en"]?.ToString();
                        licenseCategoryAr = reader["license_category_ar"]?.ToString();
                        licensePlaceOfIssueEn = reader["license_place_of_issue_en"]?.ToString();
                        licensePlaceOfIssueAr = reader["license_place_of_issue_ar"]?.ToString();
                        licenseIssueDate = reader["license_issue_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["license_issue_date"]);
                        licenseExpiryDate = reader["license_expiry_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["license_expiry_date"]);
                        identityPlaceOfIssueEn = reader["identity_place_of_issue_en"]?.ToString();
                        identityPlaceOfIssueAr = reader["identity_place_of_issue_ar"]?.ToString();

                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Check if Document Exists
        public static bool IsDocumentExist(int documentId)
        {
            string query = "SELECT COUNT(1) FROM Documents WHERE id = @DocumentId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@DocumentId", documentId);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
        #endregion
    }
}
