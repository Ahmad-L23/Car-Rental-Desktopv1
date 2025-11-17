using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsLocationData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewLocation(int branchId, string locationName)
        {
            string query = @"
                INSERT INTO Locations (branch_id, location_name)
                VALUES (@BranchId, @LocationName);
                SELECT CAST(SCOPE_IDENTITY() AS int);
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BranchId", branchId);
                cmd.Parameters.AddWithValue("@LocationName", locationName);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;
                return -1;
            }
        }

        public static bool EditLocation(int locationId, int branchId, string locationName)
        {
            string query = @"
                UPDATE Locations SET
                    branch_id = @BranchId,
                    location_name = @LocationName
                WHERE location_id = @LocationId
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@LocationId", locationId);
                cmd.Parameters.AddWithValue("@BranchId", branchId);
                cmd.Parameters.AddWithValue("@LocationName", locationName);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteLocation(int locationId)
        {
            string query = "DELETE FROM Locations WHERE location_id = @LocationId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@LocationId", locationId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsLocationExist(int locationId)
        {
            string query = "SELECT COUNT(1) FROM Locations WHERE location_id = @LocationId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@LocationId", locationId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetAllLocations()
        {
            string query = @"
                SELECT 
                    l.location_id,
                    l.location_name,
                    l.branch_id,
                    b.name AS branch_name
                FROM Locations l
                INNER JOIN Branch b ON l.branch_id = b.branch_id
                ORDER BY b.name, l.location_name
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetLocationInfoById(int locationId, ref int branchId, ref string locationName)
        {
            string query = "SELECT branch_id, location_name FROM Locations WHERE location_id = @LocationId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@LocationId", locationId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        branchId = Convert.ToInt32(reader["branch_id"]);
                        locationName = reader["location_name"].ToString();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
