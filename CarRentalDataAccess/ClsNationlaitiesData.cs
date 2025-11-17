using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccessLayer
{
    public class clsNationalitiesData
    {
        private static string connectionString = ClsDataAccessSettings.ConnectionString;

        // Get All Nationalities
        public static DataTable GetAllNationalities()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT id, nationality_name_en, nationality_name_ar FROM Nationalities";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // TODO: Log exception
                }
            }

            return dt;
        }


        public static bool GetNationalityById(int id, ref int nationalityId, ref string nameEn, ref string nameAr)
        {
            nationalityId = 0;
            nameEn = string.Empty;
            nameAr = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, nationality_name_en, nationality_name_ar FROM Nationalities WHERE id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nationalityId = Convert.ToInt32(reader["id"]);
                                nameEn = reader["nationality_name_en"].ToString();
                                nameAr = reader["nationality_name_ar"].ToString();
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // TODO: Log exception
                    }
                }
            }
            return false;
        }

    }


}
