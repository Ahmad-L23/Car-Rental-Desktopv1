using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsAgreementRequiredInsuranceData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        // Add new record
        public static int AddNew(int agreementId, int requiredInsuranceId, decimal actualPrice)
        {
            string query = @"
                INSERT INTO AgreementRequiredInsurance (AgreementID, RequiredInsuranceID, ActualPrice)
                VALUES (@AgreementID, @RequiredInsuranceID, @ActualPrice);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);
                cmd.Parameters.AddWithValue("@RequiredInsuranceID", requiredInsuranceId);
                cmd.Parameters.AddWithValue("@ActualPrice", actualPrice);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        // Update existing record
        public static bool Update(int agreementRequiredInsuranceId, int agreementId, int requiredInsuranceId, decimal actualPrice)
        {
            string query = @"
                UPDATE AgreementRequiredInsurance SET
                    AgreementID = @AgreementID,
                    RequiredInsuranceID = @RequiredInsuranceID,
                    ActualPrice = @ActualPrice
                WHERE AgreementRequiredInsuranceID = @AgreementRequiredInsuranceID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementRequiredInsuranceID", agreementRequiredInsuranceId);
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);
                cmd.Parameters.AddWithValue("@RequiredInsuranceID", requiredInsuranceId);
                cmd.Parameters.AddWithValue("@ActualPrice", actualPrice);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Delete by primary key
        public static bool DeleteById(int agreementRequiredInsuranceId)
        {
            string query = "DELETE FROM AgreementRequiredInsurance WHERE AgreementRequiredInsuranceID = @AgreementRequiredInsuranceID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementRequiredInsuranceID", agreementRequiredInsuranceId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Delete all by AgreementID
        public static bool DeleteByAgreementId(int agreementId)
        {
            string query = "DELETE FROM AgreementRequiredInsurance WHERE AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Check if record exists by ID
        public static bool IsExist(int agreementRequiredInsuranceId)
        {
            string query = "SELECT COUNT(1) FROM AgreementRequiredInsurance WHERE AgreementRequiredInsuranceID = @AgreementRequiredInsuranceID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementRequiredInsuranceID", agreementRequiredInsuranceId);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        // Get all records by AgreementID
        public static DataTable GetAllByAgreementId(int agreementId)
        {
            string query = "SELECT * FROM AgreementRequiredInsurance WHERE AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Get all with RequiredInsurance name and price joined
        public static DataTable GetAllWithInsuranceDetails(int agreementId)
        {
            string query = @"
                SELECT ari.AgreementRequiredInsuranceID,
                       ari.AgreementID,
                       ari.RequiredInsuranceID,
                       ari.ActualPrice,
                       ri.ItemName,
                       ri.Price
                FROM AgreementRequiredInsurance ari
                INNER JOIN RequiredInsurance ri ON ari.RequiredInsuranceID = ri.Id
                WHERE ari.AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Get single record by ID (with ref parameters)
        public static bool GetById(int agreementRequiredInsuranceId, ref int agreementId, ref int requiredInsuranceId, ref decimal actualPrice)
        {
            string query = "SELECT * FROM AgreementRequiredInsurance WHERE AgreementRequiredInsuranceID = @AgreementRequiredInsuranceID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementRequiredInsuranceID", agreementRequiredInsuranceId);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agreementId = Convert.ToInt32(reader["AgreementID"]);
                        requiredInsuranceId = Convert.ToInt32(reader["RequiredInsuranceID"]);
                        actualPrice = Convert.ToDecimal(reader["ActualPrice"]);
                        return true;
                    }
                }
            }
            return false;
        }


        public static bool GetSingleByAgreementId(int agreementId, ref int agreementRequiredInsuranceId, ref int requiredInsuranceId, ref decimal actualPrice)
        {
            string query = "SELECT TOP 1 * FROM AgreementRequiredInsurance WHERE AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agreementRequiredInsuranceId = Convert.ToInt32(reader["AgreementRequiredInsuranceID"]);
                        requiredInsuranceId = Convert.ToInt32(reader["RequiredInsuranceID"]);
                        actualPrice = Convert.ToDecimal(reader["ActualPrice"]);
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
