using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsCoverageData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewCoverage(string name)
        {
            string query = @"
                INSERT INTO Coverage (Name)
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

        public static bool UpdateCoverage(int id, string name)
        {
            string query = @"
                UPDATE Coverage
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

        public static bool DeleteCoverage(int id)
        {
            string query = "DELETE FROM Coverage WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static DataTable GetAllCoverage()
        {
            string query = "SELECT * FROM Coverage";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool GetCoverageById(int id, ref string name)
        {
            string query = "SELECT * FROM Coverage WHERE Id = @Id";

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

        public static bool IsCoverageExist(string name)
        {
            string query = "SELECT 1 FROM Coverage WHERE Name = @Name";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
    }
}
