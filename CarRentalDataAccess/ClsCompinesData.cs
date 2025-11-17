using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccessLayer
{
    public class clsCompaniesData
    {
        private static string connectionString = ClsDataAccessSettings.ConnectionString;

        // Create Company
        public static bool AddNewCompany(string companyNameEn, string companyNameAr, string addressEn,
                                         string addressAr, string phoneNumber, string email, string image)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"
                        INSERT INTO Companies 
                        (company_name_en, company_name_ar, address_en, address_ar, phone_number, email, image)
                        VALUES 
                        (@companyNameEn, @companyNameAr, @addressEn, @addressAr, @phoneNumber, @email, @image)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@companyNameEn", companyNameEn);
                    cmd.Parameters.AddWithValue("@companyNameAr", companyNameAr);
                    cmd.Parameters.AddWithValue("@addressEn", (object)addressEn ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@addressAr", (object)addressAr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@phoneNumber", (object)phoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@image", (object)image ?? DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // TODO: Log exception
                    return false;
                }
            }
        }

        // Get All Companies
        public static DataTable GetAllCompanies()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT companyid, company_name_en, company_name_ar, address_en, address_ar, phone_number, email, image FROM Companies";
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

        // Update Company
        public static bool UpdateCompany(int id, string companyNameEn, string companyNameAr, string addressEn,
                                         string addressAr, string phoneNumber, string email, string image)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"
                        UPDATE Companies SET 
                            company_name_en = @companyNameEn,
                            company_name_ar = @companyNameAr,
                            address_en = @addressEn,
                            address_ar = @addressAr,
                            phone_number = @phoneNumber,
                            email = @email,
                            image = @image
                        WHERE companyid = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@companyNameEn", companyNameEn);
                    cmd.Parameters.AddWithValue("@companyNameAr", companyNameAr);
                    cmd.Parameters.AddWithValue("@addressEn", (object)addressEn ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@addressAr", (object)addressAr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@phoneNumber", (object)phoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@image", (object)image ?? DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // TODO: Log exception
                    return false;
                }
            }
        }

        // Delete Company
        public static bool DeleteCompany(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM Companies WHERE companyid = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // TODO: Log exception
                    return false;
                }
            }
        }

        // Find Company By ID
        public static DataRow FindCompanyByID(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT companyid, company_name_en, company_name_ar, address_en, address_ar, phone_number, email, image FROM Companies WHERE companyid = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                                return dt.Rows[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    // TODO: Log exception
                }
            }

            return null;
        }

        public static bool FindCompanyByID(
    int id,
    ref int companyId,
    ref string nameEn,
    ref string nameAr,
    ref string addressEn,
    ref string addressAr,
    ref string phoneNumber,
    ref string email,
    ref string image)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT companyid, company_name_en, company_name_ar, address_en, address_ar, phone_number, email, image FROM Companies WHERE companyid = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                companyId = Convert.ToInt32(reader["companyid"]);
                                nameEn = reader["company_name_en"].ToString();
                                nameAr = reader["company_name_ar"].ToString();
                                addressEn = reader["address_en"] == DBNull.Value ? null : reader["address_en"].ToString();
                                addressAr = reader["address_ar"] == DBNull.Value ? null : reader["address_ar"].ToString();
                                phoneNumber = reader["phone_number"] == DBNull.Value ? null : reader["phone_number"].ToString();
                                email = reader["email"] == DBNull.Value ? null : reader["email"].ToString();
                                image = reader["image"] == DBNull.Value ? null : reader["image"].ToString();

                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // TODO: Log exception
                }
            }
            return false;
        }

    }
}
