using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsCategoryData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewCategory(string nameEn, string nameAr, string image)
        {
            string query = @"
                INSERT INTO Categories (NameEn, NameAr, Image)
                VALUES (@NameEn, @NameAr, @Image);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameEn", nameEn);
                cmd.Parameters.AddWithValue("@NameAr", nameAr);
                cmd.Parameters.AddWithValue("@Image", (object)image ?? DBNull.Value);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditCategory(int categoryId, string nameEn, string nameAr, string image)
        {
            string query = @"
                UPDATE Categories SET
                    NameEn = @NameEn,
                    NameAr = @NameAr,
                    Image = @Image
                WHERE CategoryID = @CategoryID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                cmd.Parameters.AddWithValue("@NameEn", nameEn);
                cmd.Parameters.AddWithValue("@NameAr", nameAr);
                cmd.Parameters.AddWithValue("@Image", (object)image ?? DBNull.Value);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteCategory(int categoryId)
        {
            string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsCategoryExist(int categoryId)
        {
            string query = "SELECT COUNT(1) FROM Categories WHERE CategoryID = @CategoryID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetAllCategories()
        {
            string query = "SELECT * FROM Categories";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetCategoryInfoById(int categoryId, ref string nameEn, ref string nameAr, ref string image)
        {
            string query = "SELECT * FROM Categories WHERE CategoryID = @CategoryID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nameEn = reader["NameEn"]?.ToString();
                        nameAr = reader["NameAr"]?.ToString();
                        image = reader["Image"]?.ToString();

                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CategoryExistsByNameEn(string nameEn)
        {
            string query = "SELECT COUNT(1) FROM Categories WHERE NameEn = @NameEn";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameEn", nameEn);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static bool CategoryExistsByNameAr(string nameAr)
        {
            string query = "SELECT COUNT(1) FROM Categories WHERE NameAr = @NameAr";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameAr", nameAr);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
    }
}
