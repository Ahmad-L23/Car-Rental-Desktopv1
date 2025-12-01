using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public class AdditionContract
    {
        public int id {  get; set; }
        public string name {  get; set; }
        public decimal price {  get; set; } 
    }
    public static class ClsAgreementAdditionContractData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        // Add new AgreementAdditionContract record
        public static int Add(int agreementId, int additionContractId, decimal actualPrice)
        {
            string query = @"
                INSERT INTO AgreementAdditionContract
                (AgreementID, AdditionContractID, ActualPrice)
                VALUES (@AgreementID, @AdditionContractID, @ActualPrice);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);
                cmd.Parameters.AddWithValue("@AdditionContractID", additionContractId);
                cmd.Parameters.AddWithValue("@ActualPrice", actualPrice);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1; // indicate failure
            }
        }

        // Update an existing AgreementAdditionContract by its ID
        public static bool Update(int agreementAdditionContractId, int agreementId, int additionContractId, decimal actualPrice)
        {
            string query = @"
                UPDATE AgreementAdditionContract SET
                    AgreementID = @AgreementID,
                    AdditionContractID = @AdditionContractID,
                    ActualPrice = @ActualPrice
                WHERE AgreementAdditionContractID = @AgreementAdditionContractID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementAdditionContractID", agreementAdditionContractId);
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);
                cmd.Parameters.AddWithValue("@AdditionContractID", additionContractId);
                cmd.Parameters.AddWithValue("@ActualPrice", actualPrice);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Delete all records by AgreementID (new method)
        public static bool DeleteByAgreementId(int agreementId)
        {
            string query = "DELETE FROM AgreementAdditionContract WHERE AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Get all records for a given AgreementID
        public static DataTable GetAllByAgreementId(int agreementId)
        {
            string query = @"
                SELECT 
                    aac.AgreementAdditionContractID,
                    aac.AgreementID,
                    aac.AdditionContractID,
                    aac.ActualPrice,
                    ac.Name,
                    ac.Price AS ContractPrice
                FROM AgreementAdditionContract aac
                INNER JOIN AdditionContracts ac ON aac.AdditionContractID = ac.id
                WHERE aac.AgreementID = @AgreementID";

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

        public static DataTable GetAllByAgreementIdWithAdditionContractDetails(int agreementId)
        {
            string query = @"
        SELECT 
            aac.AgreementAdditionContractID,
            aac.AgreementID,
            aac.AdditionContractID,
            aac.ActualPrice,
            ac.Name,
            ac.Price AS ContractPrice
        FROM AgreementAdditionContract aac
        INNER JOIN AdditionContracts ac ON aac.AdditionContractID = ac.id
        WHERE aac.AgreementID = @AgreementID";

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


        // (Optional) Delete single record by AgreementAdditionContractID
        public static bool Delete(int agreementAdditionContractId)
        {
            string query = "DELETE FROM AgreementAdditionContract WHERE AgreementAdditionContractID = @AgreementAdditionContractID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementAdditionContractID", agreementAdditionContractId);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // (Optional) Get single record by AgreementAdditionContractID
        public static bool GetById(int agreementAdditionContractId, out int agreementId, out int additionContractId, out decimal actualPrice)
        {
            agreementId = 0;
            additionContractId = 0;
            actualPrice = 0m;

            string query = "SELECT * FROM AgreementAdditionContract WHERE AgreementAdditionContractID = @AgreementAdditionContractID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementAdditionContractID", agreementAdditionContractId);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agreementId = Convert.ToInt32(reader["AgreementID"]);
                        additionContractId = Convert.ToInt32(reader["AdditionContractID"]);
                        actualPrice = Convert.ToDecimal(reader["ActualPrice"]);
                        return true;
                    }
                }
            }
            return false;
        }

        // (Optional) Check if record exists by AgreementAdditionContractID
        public static bool Exists(int agreementAdditionContractId)
        {
            string query = "SELECT COUNT(1) FROM AgreementAdditionContract WHERE AgreementAdditionContractID = @AgreementAdditionContractID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementAdditionContractID", agreementAdditionContractId);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
    }
}
