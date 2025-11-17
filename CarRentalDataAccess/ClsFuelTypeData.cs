using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsFuelTypeData
    {
        private static readonly string _connectionString = ClsDataAccessSettings.ConnectionString;

        // Insert a new fuel type and return the new ID or -1 on failure
        public static int AddNewFuelType(string name)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "INSERT INTO FuelType (Name) OUTPUT INSERTED.Id VALUES (@Name)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", name);

                conn.Open();
                int newId = (int)cmd.ExecuteScalar();
                return newId;
            }
            catch
            {
                return -1;
            }
        }

        // Update existing fuel type by Id, returns true if updated
        public static bool EditFuelType(int id, string newName)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "UPDATE FuelType SET Name = @Name WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", newName);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch
            {
                return false;
            }
        }

        // Delete fuel type by Id, returns true if deleted
        public static bool DeleteFuelType(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "DELETE FROM FuelType WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch
            {
                return false;
            }
        }

        // Get fuel type info by Id, returns false if not found
        public static bool GetFuelTypeById(int id, ref string name)
        {
            name = null;
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "SELECT Name FROM FuelType WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    name = reader["Name"].ToString();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Get all fuel types as DataTable
        public static DataTable GetAllFuelTypes()
        {
            string query = "SELECT * FROM FuelType";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Check if fuel type exists by name (case-insensitive)
        public static bool FuelTypeExistsByName(string name)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "SELECT COUNT(1) FROM FuelType WHERE LOWER(Name) = LOWER(@Name)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", name);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
