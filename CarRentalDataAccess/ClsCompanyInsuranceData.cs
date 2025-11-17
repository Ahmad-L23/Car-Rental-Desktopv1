using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsCompanyInsuranceData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewCompanyInsurance(
            string insuranceCompanyName,
            string phone,
            string email,
            int insuranceTypeId,
            bool isActive)
        {
            string query = @"
                INSERT INTO CompanyInsurance
                (InsuranceCompanyName, Phone, Email, InsuranceTypeID, IsActive)
                VALUES
                (@InsuranceCompanyName, @Phone, @Email, @InsuranceTypeID, @IsActive);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@InsuranceCompanyName", insuranceCompanyName);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@InsuranceTypeID", insuranceTypeId);
                cmd.Parameters.AddWithValue("@IsActive", isActive);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditCompanyInsurance(
            int companyInsuranceId,
            string insuranceCompanyName,
            string phone,
            string email,
            int insuranceTypeId,
            bool isActive)
        {
            string query = @"
                UPDATE CompanyInsurance SET
                    InsuranceCompanyName = @InsuranceCompanyName,
                    Phone = @Phone,
                    Email = @Email,
                    InsuranceTypeID = @InsuranceTypeID,
                    IsActive = @IsActive
                WHERE CompanyInsuranceID = @CompanyInsuranceID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CompanyInsuranceID", companyInsuranceId);
                cmd.Parameters.AddWithValue("@InsuranceCompanyName", insuranceCompanyName);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@InsuranceTypeID", insuranceTypeId);
                cmd.Parameters.AddWithValue("@IsActive", isActive);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteCompanyInsurance(int companyInsuranceId)
        {
            string query = "DELETE FROM CompanyInsurance WHERE CompanyInsuranceID = @CompanyInsuranceID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CompanyInsuranceID", companyInsuranceId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsCompanyInsuranceExist(int companyInsuranceId)
        {
            string query = @"
                IF EXISTS (SELECT 1 FROM CompanyInsurance WHERE CompanyInsuranceID = @CompanyInsuranceID)
                    SELECT 1
                ELSE
                    SELECT 0";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CompanyInsuranceID", companyInsuranceId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) == 1);
            }
        }

        public static DataTable GetAllCompanyInsurances()
        {
            string query = "SELECT * FROM CompanyInsurance";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetCompanyInsuranceById(
            int companyInsuranceId,
            ref string insuranceCompanyName,
            ref string phone,
            ref string email,
            ref int insuranceTypeId,
            ref bool isActive)
        {
            string query = "SELECT * FROM CompanyInsurance WHERE CompanyInsuranceID = @CompanyInsuranceID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CompanyInsuranceID", companyInsuranceId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        insuranceCompanyName = reader["InsuranceCompanyName"]?.ToString();
                        phone = reader["Phone"]?.ToString();
                        email = reader["Email"]?.ToString();
                        insuranceTypeId = Convert.ToInt32(reader["InsuranceTypeID"]);
                        isActive = Convert.ToBoolean(reader["IsActive"]);

                        return true;
                    }
                }
            }
            return false;
        }


        public static DataTable GetAllCompanyInsurancesWithTypeName()
        {
            string query = @"
        SELECT 
            ci.CompanyInsuranceID,
            ci.InsuranceCompanyName,
            ci.Phone,
            ci.Email,
            ci.InsuranceTypeID,
            it.Name AS InsuranceTypeName,
            ci.IsActive
        FROM CompanyInsurance ci
        INNER JOIN InsuranceTypes it ON ci.InsuranceTypeID = it.InsuranceTypeID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

    }
}
