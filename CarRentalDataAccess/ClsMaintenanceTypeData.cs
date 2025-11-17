using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsMaintenanceTypeData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewMaintenanceType(
            string name,
            int mileageInterval,
            string description,
            bool isActive)
        {
            string query = @"
                INSERT INTO MaintenanceTypes
                (Name, MileageInterval, Description, IsActive)
                VALUES
                (@Name, @MileageInterval, @Description, @IsActive);
                SELECT CAST(scope_identity() AS int);";

             SqlConnection connection = new SqlConnection(conn);
             SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@MileageInterval", mileageInterval);
            cmd.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsActive", isActive);

            connection.Open();
            object result = cmd.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int newId))
                return newId;

            return -1;
        }

        public static bool EditMaintenanceType(
            int maintenanceTypeId,
            string name,
            int mileageInterval,
            string description,
            bool isActive)
        {
            string query = @"
                UPDATE MaintenanceTypes SET
                    Name = @Name,
                    MileageInterval = @MileageInterval,
                    Description = @Description,
                    IsActive = @IsActive
                WHERE Id = @MaintenanceTypeId";

             SqlConnection connection = new SqlConnection(conn);
             SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@MaintenanceTypeId", maintenanceTypeId);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@MileageInterval", mileageInterval);
            cmd.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsActive", isActive);

            connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public static bool DeleteMaintenanceType(int maintenanceTypeId)
        {
            string query = "DELETE FROM MaintenanceTypes WHERE Id = @MaintenanceTypeId";

             SqlConnection connection = new SqlConnection(conn);
             SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@MaintenanceTypeId", maintenanceTypeId);

            connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public static bool MaintenanceTypeExists(int maintenanceTypeId)
        {
            string query = "SELECT 1 FROM MaintenanceTypes WHERE Id = @MaintenanceTypeId";

             SqlConnection connection = new SqlConnection(conn);
             SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@MaintenanceTypeId", maintenanceTypeId);

            connection.Open();
            object result = cmd.ExecuteScalar();

            return (result != null && Convert.ToInt32(result) > 0);
        }

        public static bool MaintenanceTypeExists(string name)
        {
            string query = "SELECT 1 FROM MaintenanceTypes WHERE Name = @Name";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
        public static DataTable GetAllMaintenanceTypes()
        {
            string query = "SELECT * FROM MaintenanceTypes";

             SqlConnection connection = new SqlConnection(conn);
             SqlCommand cmd = new SqlCommand(query, connection);
             SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public static bool GetMaintenanceTypeById(
            int maintenanceTypeId,
            ref string name,
            ref int mileageInterval,
            ref string description,
            ref bool isActive)
        {
            string query = "SELECT * FROM MaintenanceTypes WHERE Id = @MaintenanceTypeId";

             SqlConnection connection = new SqlConnection(conn);
             SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@MaintenanceTypeId", maintenanceTypeId);

            connection.Open();

             SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                name = reader["Name"]?.ToString();
                mileageInterval = reader["MileageInterval"] != DBNull.Value ? Convert.ToInt32(reader["MileageInterval"]) : 0;
                description = reader["Description"]?.ToString();
                isActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]);

                return true;
            }
            return false;
        }
    }
}
