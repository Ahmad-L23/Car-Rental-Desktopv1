using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDataAccess
{
    public class ClsBranchData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        
        public static int AddNewBranch(string name, decimal tax, decimal rate)
        {
            string query = @"
                INSERT INTO Branch (name, tax, rate)
                VALUES (@Name, @Tax, @Rate);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Tax", tax);
                cmd.Parameters.AddWithValue("@Rate", rate);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

       
        public static bool EditBranch(int branchId, string name, decimal tax, decimal rate)
        {
            string query = @"
                UPDATE Branch SET
                    name = @Name,
                    tax = @Tax,
                    rate = @Rate
                WHERE branch_id = @BranchId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BranchId", branchId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Tax", tax);
                cmd.Parameters.AddWithValue("@Rate", rate);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Delete branch by id, returns true if deleted
        public static bool DeleteBranch(int branchId)
        {
            string query = "DELETE FROM Branch WHERE branch_id = @BranchId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BranchId", branchId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Check if branch exists by id
        public static bool IsBranchExist(int branchId)
        {
            string query = "SELECT COUNT(1) FROM Branch WHERE branch_id = @BranchId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BranchId", branchId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        // Get all branches as DataTable
        public static DataTable GetAllBranches()
        {
            string query = "SELECT * FROM Branch";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Get branch info by id, returns true if found, ref parameters filled
        public static bool GetBranchInfoById(int branchId, ref string name, ref decimal tax, ref decimal rate)
        {
            string query = "SELECT * FROM Branch WHERE branch_id = @BranchId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BranchId", branchId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader["name"]?.ToString();
                        tax = reader["tax"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["tax"]);
                        rate = reader["rate"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["rate"]);

                        return true;
                    }
                }
            }
            return false;
        }
    }
}
