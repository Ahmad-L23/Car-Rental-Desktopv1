using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsTargetClientsData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewTargetClient(string name)
        {
            string query = @"
                INSERT INTO TargetClients (Name)
                VALUES (@Name);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool UpdateTargetClient(int id, string name)
        {
            string query = @"
                UPDATE TargetClients
                SET Name = @Name
                WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);

                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool DeleteTargetClient(int id)
        {
            string query = "DELETE FROM TargetClients WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static DataTable GetAllTargetClients()
        {
            string query = "SELECT * FROM TargetClients";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool GetTargetClientById(int id, ref string name)
        {
            string query = "SELECT * FROM TargetClients WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader["Name"].ToString();
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsTargetClientExist(string name)
        {
            string query = "SELECT 1 FROM TargetClients WHERE Name = @Name";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
        public static bool IsTargetClientExist(int id)
        {
            string query = "SELECT 1 FROM TargetClients WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
    }
}
