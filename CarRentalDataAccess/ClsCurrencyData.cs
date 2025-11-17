using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsCurrencyData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewCurrency(string nameEn, string nameAr)
        {
            string query = @"
                INSERT INTO Currencies (nameEn, nameAr)
                VALUES (@NameEn, @NameAr);
                SELECT CAST(scope_identity() AS int);";

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

        public static bool EditCurrency(int currencyId, string nameEn, string nameAr)
        {
            string query = @"
                UPDATE Currencies SET
                    nameEn = @NameEn,
                    nameAr = @NameAr
                WHERE Id = @CurrencyId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CurrencyId", currencyId);
                cmd.Parameters.AddWithValue("@NameEn", nameEn);
                cmd.Parameters.AddWithValue("@NameAr", nameAr);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteCurrency(int currencyId)
        {
            string query = "DELETE FROM Currencies WHERE Id = @CurrencyId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CurrencyId", currencyId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsCurrencyExist(int currencyId)
        {
            string query = "SELECT COUNT(1) FROM Currencies WHERE Id = @CurrencyId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CurrencyId", currencyId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetAllCurrencies()
        {
            string query = "SELECT * FROM Currencies";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetCurrencyInfoById(int currencyId, ref string nameEn, ref string nameAr)
        {
            string query = "SELECT * FROM Currencies WHERE Id = @CurrencyId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CurrencyId", currencyId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nameEn = reader["nameEn"]?.ToString();
                        nameAr = reader["nameAr"]?.ToString();

                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CurrencyExistsByEnglishName(string nameEn)
        {
            string query = "SELECT COUNT(1) FROM Currencies WHERE nameEn = @NameEn";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameEn", nameEn);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static bool CurrencyExistsByArabicName(string nameAr)
        {
            string query = "SELECT COUNT(1) FROM Currencies WHERE nameAr = @NameAr";

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
