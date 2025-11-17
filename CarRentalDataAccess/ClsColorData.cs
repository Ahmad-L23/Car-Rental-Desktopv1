using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsColorData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewColor(string colorName, string colorHex)
        {
            string query = @"
                INSERT INTO Colors (ColorName, ColorHex)
                VALUES (@ColorName, @ColorHex);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ColorName", (object)colorName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ColorHex", colorHex);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditColor(int colorId, string colorName, string colorHex)
        {
            string query = @"
                UPDATE Colors SET
                    ColorName = @ColorName,
                    ColorHex = @ColorHex
                WHERE Id = @ColorId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ColorId", colorId);
                cmd.Parameters.AddWithValue("@ColorName", (object)colorName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ColorHex", colorHex);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteColor(int colorId)
        {
            string query = "DELETE FROM Colors WHERE Id = @ColorId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ColorId", colorId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsColorExist(int colorId)
        {
            string query = "SELECT 1 FROM Colors WHERE Id = @ColorId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ColorId", colorId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetAllColors()
        {
            string query = "SELECT * FROM Colors";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetColorById(int colorId, ref string colorName, ref string colorHex)
        {
            string query = "SELECT * FROM Colors WHERE Id = @ColorId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ColorId", colorId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        colorName = reader["ColorName"] == DBNull.Value ? null : reader["ColorName"].ToString();
                        colorHex = reader["ColorHex"].ToString();
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ColorExistsByName(string colorName)
        {
            string query = "SELECT 1 FROM Colors WHERE ColorName = @ColorName";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ColorName", colorName);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
    }
}
