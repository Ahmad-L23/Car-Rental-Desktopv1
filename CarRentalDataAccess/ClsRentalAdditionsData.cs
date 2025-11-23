using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsRentalAdditionsData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewRentalAddition(
            string rentalName,
            int paymentMethodId,
            decimal price,
            string rentalNote,
            bool isActive,
            bool isTaxIncluded)
        {
            string query = @"
                INSERT INTO RentalAdditions
                (RentalName, PaymentMethodID, Price, RentalNote, IsActive, IsTaxIncluded)
                VALUES
                (@RentalName, @PaymentMethodID, @Price, @RentalNote, @IsActive, @IsTaxIncluded);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RentalName", rentalName);
                cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodId);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@RentalNote", string.IsNullOrEmpty(rentalNote) ? (object)DBNull.Value : rentalNote);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@IsTaxIncluded", isTaxIncluded);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditRentalAddition(
            int rentalAdditionId,
            string rentalName,
            int paymentMethodId,
            decimal price,
            string rentalNote,
            bool isActive,
            bool isTaxIncluded)
        {
            string query = @"
                UPDATE RentalAdditions SET
                    RentalName = @RentalName,
                    PaymentMethodID = @PaymentMethodID,
                    Price = @Price,
                    RentalNote = @RentalNote,
                    IsActive = @IsActive,
                    IsTaxIncluded = @IsTaxIncluded
                WHERE RentalAdditionID = @RentalAdditionID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RentalAdditionID", rentalAdditionId);
                cmd.Parameters.AddWithValue("@RentalName", rentalName);
                cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodId);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@RentalNote", string.IsNullOrEmpty(rentalNote) ? (object)DBNull.Value : rentalNote);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@IsTaxIncluded", isTaxIncluded);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteRentalAddition(int rentalAdditionId)
        {
            string query = "DELETE FROM RentalAdditions WHERE RentalAdditionID = @RentalAdditionID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RentalAdditionID", rentalAdditionId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsRentalAdditionExist(int rentalAdditionId)
        {
            string query = "SELECT 1 FROM RentalAdditions WHERE RentalAdditionID = @RentalAdditionID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RentalAdditionID", rentalAdditionId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetAllRentalAdditions()
        {
            string query = @"
                SELECT 
                    ra.RentalAdditionID, 
                    ra.RentalName, 
                    ra.PaymentMethodID, 
                    pm.MethodName, 
                    ra.Price, 
                    ra.RentalNote, 
                    ra.IsActive,
                    ra.IsTaxIncluded
                FROM RentalAdditions ra
                INNER JOIN PaymentMethods pm ON ra.PaymentMethodID = pm.Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetRentalAdditionInfoById(
            int rentalAdditionId,
            ref string rentalName,
            ref int paymentMethodId,
            ref decimal price,
            ref string rentalNote,
            ref bool isActive,
            ref bool isTaxIncluded)
        {
            string query = "SELECT * FROM RentalAdditions WHERE RentalAdditionID = @RentalAdditionID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RentalAdditionID", rentalAdditionId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rentalName = reader["RentalName"]?.ToString();
                        paymentMethodId = Convert.ToInt32(reader["PaymentMethodID"]);
                        price = Convert.ToDecimal(reader["Price"]);
                        rentalNote = reader["RentalNote"] == DBNull.Value ? null : reader["RentalNote"].ToString();
                        isActive = Convert.ToBoolean(reader["IsActive"]);
                        isTaxIncluded = Convert.ToBoolean(reader["IsTaxIncluded"]);
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool RentalAdditionExistsByName(string rentalName)
        {
            string query = "SELECT 1 FROM RentalAdditions WHERE RentalName = @RentalName";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RentalName", rentalName);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
    }
}
