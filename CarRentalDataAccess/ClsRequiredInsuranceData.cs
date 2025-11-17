using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsRequiredInsuranceData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        // ✅ Add new record
        public static int AddNewRequiredInsurance(string itemName, decimal price)
        {
            string query = @"
                INSERT INTO RequiredInsurance (ItemName, Price)
                VALUES (@ItemName, @Price);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                cmd.Parameters.AddWithValue("@Price", price);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        // ✅ Edit existing record
        public static bool EditRequiredInsurance(int id, string itemName, decimal price)
        {
            string query = @"
                UPDATE RequiredInsurance
                SET ItemName = @ItemName,
                    Price = @Price
                WHERE Id = @Id;";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                cmd.Parameters.AddWithValue("@Price", price);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // ✅ Delete record
        public static bool DeleteRequiredInsurance(int id)
        {
            string query = "DELETE FROM RequiredInsurance WHERE Id = @Id;";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // ✅ Check existence
        public static bool IsRequiredInsuranceExist(int id)
        {
            string query = "SELECT 1 FROM RequiredInsurance WHERE Id = @Id;";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        // ✅ Get all records
        public static DataTable GetAllRequiredInsurance()
        {
            string query = "SELECT * FROM RequiredInsurance ORDER BY Id DESC;";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // ✅ Get single record by ID
        public static bool GetRequiredInsuranceById(
            int id,
            ref string itemName,
            ref decimal price)
        {
            string query = "SELECT * FROM RequiredInsurance WHERE Id = @Id;";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        itemName = reader["ItemName"].ToString();
                        price = Convert.ToDecimal(reader["Price"]);
                        return true;
                    }
                }
            }

            return false;
        }

        // ✅ Check if an item name already exists
        public static bool IsItemNameExist(string itemName)
        {
            string query = "SELECT 1 FROM RequiredInsurance WHERE ItemName = @ItemName;";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ItemName", itemName);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
    }
}
