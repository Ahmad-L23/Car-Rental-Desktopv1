using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsAdditionContractsData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewAdditionContract(string name, decimal price)
        {
            string query = @"
                INSERT INTO AdditionContracts
                (Name, Price)
                VALUES
                (@Name, @Price);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Price", price);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditAdditionContract(int id, string name, decimal price)
        {
            string query = @"
                UPDATE AdditionContracts SET
                    Name = @Name,
                    Price = @Price
                WHERE id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Price", price);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteAdditionContract(int id)
        {
            string query = "DELETE FROM AdditionContracts WHERE id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsAdditionContractExist(int id)
        {
            string query = "SELECT 1 FROM AdditionContracts WHERE id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetAllAdditionContracts()
        {
            string query = "SELECT * FROM AdditionContracts";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetAdditionContractById(int id, ref string name, ref decimal price)
        {
            string query = "SELECT * FROM AdditionContracts WHERE id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader["Name"]?.ToString();
                        price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
