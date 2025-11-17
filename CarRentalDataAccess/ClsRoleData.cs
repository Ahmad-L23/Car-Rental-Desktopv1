using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsRoleData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewRole(string nameEn, string nameAr)
        {
            string query = @"
                INSERT INTO Roles (NameEn, NameAr)
                VALUES (@NameEn, @NameAr);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameEn", nameEn);
                cmd.Parameters.AddWithValue("@NameAr", nameAr);

                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditRole(int roleId, string nameEn, string nameAr)
        {
            string query = @"
                UPDATE Roles
                SET NameEn = @NameEn,
                    NameAr = @NameAr
                WHERE Id = @RoleId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RoleId", roleId);
                cmd.Parameters.AddWithValue("@NameEn", nameEn);
                cmd.Parameters.AddWithValue("@NameAr", nameAr);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteRole(int roleId)
        {
            string query = "DELETE FROM Roles WHERE Id = @RoleId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RoleId", roleId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsRoleExist(int roleId)
        {
            string query = "SELECT COUNT(1) FROM Roles WHERE Id = @RoleId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RoleId", roleId);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static bool RoleExistsByEnglishName(string nameEn)
        {
            string query = "SELECT COUNT(1) FROM Roles WHERE NameEn = @NameEn";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameEn", nameEn);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static bool RoleExistsByArabicName(string nameAr)
        {
            string query = "SELECT COUNT(1) FROM Roles WHERE NameAr = @NameAr";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameAr", nameAr);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetAllRoles()
        {
            string query = "SELECT * FROM Roles ORDER BY Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetRoleInfoById(int roleId, ref string nameEn, ref string nameAr)
        {
            string query = "SELECT * FROM Roles WHERE Id = @RoleId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RoleId", roleId);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nameEn = reader["NameEn"]?.ToString();
                        nameAr = reader["NameAr"]?.ToString();
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
