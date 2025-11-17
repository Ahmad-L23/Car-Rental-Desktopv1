using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace CarRentalDataAccess
{
    public static class ClsBoxData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        #region Add

        public static int AddNewBox(
            string Name,
            int branchId,
            string accountNumber,
            bool isActive,
            string notes)
        {
            string query = @"
                INSERT INTO Boxes
                (Name, BranchID, AccountNumber, IsActive, Notes)
                VALUES
                (@Name, @BranchID, @AccountNumber, @IsActive, @Notes);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@BranchID", branchId);
                cmd.Parameters.AddWithValue("@AccountNumber", (object)accountNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@Notes", (object)notes ?? DBNull.Value);

                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        #endregion

        #region Edit

        public static bool EditBox(
            int boxId,
            string Name,
            int branchId,
            string accountNumber,
            bool isActive,
            string notes)
        {
            string query = @"
                UPDATE Boxes SET
                    Name,
                    BranchID = @BranchID,
                    AccountNumber = @AccountNumber,
                    IsActive = @IsActive,
                    Notes = @Notes
                WHERE BoxID = @BoxID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BoxID", boxId);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@BranchID", branchId);
                cmd.Parameters.AddWithValue("@AccountNumber", (object)accountNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@Notes", (object)notes ?? DBNull.Value);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        #endregion

        #region Delete

        public static bool DeleteBox(int boxId)
        {
            string query = "DELETE FROM Boxes WHERE BoxID = @BoxID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BoxID", boxId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        #endregion

        #region Get Methods

        public static DataTable GetAllBoxes()
        {
            string query = @"
                SELECT 
                    B.BoxID,
                    B.Name,
                    BR.name AS BranchName,
                    B.AccountNumber,
                    B.IsActive,
                    B.Notes
                FROM Boxes B
                INNER JOIN Branch BR ON B.BranchID = BR.branch_id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool GetBoxInfoById(
            int boxId,
            ref string Name,
            ref int branchId,
            ref string accountNumber,
            ref bool isActive,
            ref string notes)
        {
            string query = "SELECT * FROM Boxes WHERE BoxID = @BoxID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BoxID", boxId);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Name = reader["Name"]?.ToString();
                        branchId = Convert.ToInt32(reader["BranchID"]);
                        accountNumber = reader["AccountNumber"]?.ToString();
                        isActive = Convert.ToBoolean(reader["IsActive"]);
                        notes = reader["Notes"]?.ToString();

                        return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region Exists

        public static bool IsBoxExist(int boxId)
        {
            string query = "SELECT COUNT(1) FROM Boxes WHERE BoxID = @BoxID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BoxID", boxId);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static bool BoxExistsByEnglishName(string Name)
        {
            string query = "SELECT COUNT(1) FROM Boxes WHERE Name = @Name";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", Name);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static bool BoxExistsByArabicName(string nameAr)
        {
            string query = "SELECT COUNT(1) FROM Boxes WHERE Name = @Name";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", nameAr);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        #endregion
    }
}
