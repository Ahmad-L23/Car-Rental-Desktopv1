using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsInsuranceTypeData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewInsuranceType(
            string name,
            string description,
            int coverageId,
            int targetClientId,
            bool isActive,
            string insuranceImage)
        {
            string query = @"
                INSERT INTO InsuranceTypes
                (Name, Description, CoverageID, TargetClientID, IsActive, InsuranceImage, CreatedAt)
                VALUES
                (@Name, @Description, @CoverageID, @TargetClientID, @IsActive, @InsuranceImage, GETDATE());
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CoverageID", coverageId);
                cmd.Parameters.AddWithValue("@TargetClientID", targetClientId);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@InsuranceImage", insuranceImage ?? (object)DBNull.Value);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditInsuranceType(
            int insuranceTypeId,
            string name,
            string description,
            int coverageId,
            int targetClientId,
            bool isActive,
            string insuranceImage)
        {
            string query = @"
                UPDATE InsuranceTypes SET
                    Name = @Name,
                    Description = @Description,
                    CoverageID = @CoverageID,
                    TargetClientID = @TargetClientID,
                    IsActive = @IsActive,
                    InsuranceImage = @InsuranceImage
                WHERE InsuranceTypeID = @InsuranceTypeID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@InsuranceTypeID", insuranceTypeId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CoverageID", coverageId);
                cmd.Parameters.AddWithValue("@TargetClientID", targetClientId);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@InsuranceImage", insuranceImage ?? (object)DBNull.Value);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }



        public static bool DeleteInsuranceType(int insuranceTypeId)
        {
            string query = "DELETE FROM InsuranceTypes WHERE InsuranceTypeID = @InsuranceTypeID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@InsuranceTypeID", insuranceTypeId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static DataTable GetAllInsuranceTypes()
        {
            string query = "SELECT * FROM InsuranceTypes";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetInsuranceTypeById(
            int insuranceTypeId,
            ref string name,
            ref string description,
            ref int coverageId,
            ref int targetClientId,
            ref bool isActive,
            ref string insuranceImage)
        {
            string query = "SELECT * FROM InsuranceTypes WHERE InsuranceTypeID = @InsuranceTypeID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@InsuranceTypeID", insuranceTypeId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader["Name"]?.ToString();
                        description = reader["Description"]?.ToString();
                        coverageId = reader["CoverageID"] != DBNull.Value ? Convert.ToInt32(reader["CoverageID"]) : 0;
                        targetClientId = reader["TargetClientID"] != DBNull.Value ? Convert.ToInt32(reader["TargetClientID"]) : 0;
                        isActive = reader["IsActive"] != DBNull.Value && (bool)reader["IsActive"];
                        insuranceImage = reader["InsuranceImage"]?.ToString();

                        return true;
                    }
                }
            }
            return false;
        }

        public static bool InsuranceExist(int insuranceTypeId)
        {
            string query = "SELECT 1 FROM InsuranceTypes WHERE InsuranceTypeID = @InsuranceTypeID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@InsuranceTypeID", insuranceTypeId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return result != null;
            }
        }

        public static bool InsuranceExist(string name)
        {
            string query = "SELECT 1 FROM InsuranceTypes WHERE Name = @Name";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = name.Trim();

                connection.Open();
                object result = cmd.ExecuteScalar();

                return result != null;
            }
        }
    }
}
