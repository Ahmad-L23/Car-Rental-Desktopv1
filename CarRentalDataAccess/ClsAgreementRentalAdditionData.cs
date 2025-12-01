using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{

    public class RentalAdditionsItems
    {
        public int id;
        public string name;
        public decimal price;
    }
    public static class ClsAgreementRentalAdditionData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        // Add new record
        public static int AddNew(int agreementId, int rentalAdditionId, decimal actualPrice)
        {
            string query = @"
                INSERT INTO AgreementRentalAddition (AgreementID, RentalAdditionID, ActualPrice)
                VALUES (@AgreementID, @RentalAdditionID, @ActualPrice);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);
                cmd.Parameters.AddWithValue("@RentalAdditionID", rentalAdditionId);
                cmd.Parameters.AddWithValue("@ActualPrice", actualPrice);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        // Update existing record
        public static bool Update(int agreementRentalAdditionId, int agreementId, int rentalAdditionId, decimal actualPrice)
        {
            string query = @"
                UPDATE AgreementRentalAddition SET
                    AgreementID = @AgreementID,
                    RentalAdditionID = @RentalAdditionID,
                    ActualPrice = @ActualPrice
                WHERE AgreementRentalAdditionID = @AgreementRentalAdditionID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementRentalAdditionID", agreementRentalAdditionId);
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);
                cmd.Parameters.AddWithValue("@RentalAdditionID", rentalAdditionId);
                cmd.Parameters.AddWithValue("@ActualPrice", actualPrice);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Delete by primary key
        public static bool DeleteById(int agreementRentalAdditionId)
        {
            string query = "DELETE FROM AgreementRentalAddition WHERE AgreementRentalAdditionID = @AgreementRentalAdditionID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementRentalAdditionID", agreementRentalAdditionId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Delete all by AgreementID
        public static bool DeleteByAgreementId(int agreementId)
        {
            string query = "DELETE FROM AgreementRentalAddition WHERE AgreementID = @AgreementID";

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
        public static bool IsExist(int agreementRentalAdditionId)
        {
            string query = "SELECT COUNT(1) FROM AgreementRentalAddition WHERE AgreementRentalAdditionID = @AgreementRentalAdditionID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementRentalAdditionID", agreementRentalAdditionId);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        // Get all records by AgreementID
        public static DataTable GetAllByAgreementId(int agreementId)
        {
            string query = @"
                SELECT arl.AgreementRentalAdditionID,
                       arl.AgreementID,
                       arl.RentalAdditionID,
                       arl.ActualPrice,
                       ra.RentalName,
                       ra.Price
                FROM AgreementRentalAddition arl
                INNER JOIN RentalAdditions ra ON arl.RentalAdditionID = ra.RentalAdditionID
                WHERE arl.AgreementID = @AgreementID";

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

        // Get all with RentalAddition name and price joined
        public static List<RentalAdditionsItems> GetAllWithRentalAdditionDetails(int agreementId)
        {
            List< RentalAdditionsItems > RenAddItems = new List<RentalAdditionsItems> ();
            string query = @"
                SELECT arl.AgreementRentalAdditionID,
                       arl.AgreementID,
                       arl.RentalAdditionID,
                       arl.ActualPrice,
                       ra.RentalName,
                       ra.Price
                FROM AgreementRentalAddition arl
                INNER JOIN RentalAdditions ra ON arl.RentalAdditionID = ra.RentalAdditionID
                WHERE arl.AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        RentalAdditionsItems items = new RentalAdditionsItems
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(4),
                            price = Convert.ToDecimal(reader.GetString(3))
                        };

                        RenAddItems.Add(items);
                    }
                }
            }
            return RenAddItems;
        }

        // Get single record by ID (with ref parameters)
        public static bool GetById(int agreementRentalAdditionId, ref int agreementId, ref int rentalAdditionId, ref decimal actualPrice)
        {
            string query = "SELECT * FROM AgreementRentalAddition WHERE AgreementRentalAdditionID = @AgreementRentalAdditionID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementRentalAdditionID", agreementRentalAdditionId);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        agreementId = Convert.ToInt32(reader["AgreementID"]);
                        rentalAdditionId = Convert.ToInt32(reader["RentalAdditionID"]);
                        actualPrice = Convert.ToDecimal(reader["ActualPrice"]);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
