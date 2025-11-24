using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsEmployeeUsageData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        // ADD NEW EMPLOYEE USAGE
        public static int AddEmployeeUsage(
            int employeeId,
            int carId,
            int branchId,
            string usageReason,
            DateTime exitDate,
            int status,

            int exitCounter,
            string exitFuel,

            int entryBranchId,
            DateTime entryDate,
            int entryCountre,
            string entryFuel)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert EmployeeUsage record
                        string insertQuery = @"
                    INSERT INTO EmployeeUsage
                    (EmployeeId, CarId, BranchId, UsageReason, ExitDate, Status,
                     ExitCounter, ExitFuel, EntryBranchId, EntryDate, EntryCountre, EntryFuel)
                    VALUES
                    (@EmployeeId, @CarId, @BranchId, @UsageReason, @ExitDate, @Status,
                     @ExitCounter, @ExitFuel, @EntryBranchId, @EntryDate, @EntryCountre, @EntryFuel);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection, transaction))
                        {
                            insertCmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                            insertCmd.Parameters.AddWithValue("@CarId", carId);
                            insertCmd.Parameters.AddWithValue("@BranchId", branchId);
                            insertCmd.Parameters.AddWithValue("@UsageReason", usageReason);
                            insertCmd.Parameters.AddWithValue("@ExitDate", exitDate);
                            insertCmd.Parameters.AddWithValue("@Status", status);

                            insertCmd.Parameters.AddWithValue("@ExitCounter", exitCounter);
                            insertCmd.Parameters.AddWithValue("@ExitFuel", exitFuel);

                            insertCmd.Parameters.AddWithValue("@EntryBranchId", entryBranchId);
                            insertCmd.Parameters.AddWithValue("@EntryDate", entryDate);
                            insertCmd.Parameters.AddWithValue("@EntryCountre", entryCountre);
                            insertCmd.Parameters.AddWithValue("@EntryFuel", entryFuel);

                            object result = insertCmd.ExecuteScalar();
                            int insertedId = result != null ? Convert.ToInt32(result) : -1;

                            if (insertedId == -1)
                                throw new Exception("Failed to insert EmployeeUsage record.");

                            // 2. Update vehicles.CurrentCounter with entryCounter value
                            string updateQuery = "UPDATE vehicles SET CurrentCounter = @CurrentCounter WHERE CarID = @CarID";

                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@CurrentCounter", entryCountre);
                                updateCmd.Parameters.AddWithValue("@CarID", carId);
                                updateCmd.ExecuteNonQuery();
                            }

                            // Commit transaction if both succeed
                            transaction.Commit();
                            return insertedId;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // EDIT EMPLOYEE USAGE
        public static bool EditEmployeeUsage(
            int usageId,
            int employeeId,
            int carId,
            int branchId,
            string usageReason,
            DateTime exitDate,
            int status,

            int exitCounter,
            string exitFuel,

            int entryBranchId,
            DateTime entryDate,
            int entryCountre,
            string entryFuel)
        {
            string query = @"
                UPDATE EmployeeUsage SET
                    EmployeeId = @EmployeeId,
                    CarId = @CarId,
                    BranchId = @BranchId,
                    UsageReason = @UsageReason,
                    ExitDate = @ExitDate,
                    Status = @Status,

                    ExitCounter = @ExitCounter,
                    ExitFuel = @ExitFuel,

                    EntryBranchId = @EntryBranchId,
                    EntryDate = @EntryDate,
                    EntryCountre = @EntryCountre,
                    EntryFuel = @EntryFuel
                WHERE UsageId = @UsageId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UsageId", usageId);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                cmd.Parameters.AddWithValue("@CarId", carId);
                cmd.Parameters.AddWithValue("@BranchId", branchId);
                cmd.Parameters.AddWithValue("@UsageReason", usageReason);
                cmd.Parameters.AddWithValue("@ExitDate", exitDate);
                cmd.Parameters.AddWithValue("@Status", status);

                cmd.Parameters.AddWithValue("@ExitCounter", exitCounter);
                cmd.Parameters.AddWithValue("@ExitFuel", exitFuel);

                cmd.Parameters.AddWithValue("@EntryBranchId", entryBranchId);
                cmd.Parameters.AddWithValue("@EntryDate", entryDate);
                cmd.Parameters.AddWithValue("@EntryCountre", entryCountre);
                cmd.Parameters.AddWithValue("@EntryFuel", entryFuel);

                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE EMPLOYEE USAGE
        public static bool DeleteEmployeeUsage(int usageId)
        {
            string query = "DELETE FROM EmployeeUsage WHERE UsageId = @UsageId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UsageId", usageId);

                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // CHECK IF EXISTS
        public static bool IsEmployeeUsageExist(int usageId)
        {
            string query = "SELECT COUNT(1) FROM EmployeeUsage WHERE UsageId = @UsageId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UsageId", usageId);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result) > 0;
            }
        }

        // GET ALL
        public static DataTable GetAllEmployeeUsage()
        {
            string query = "SELECT * FROM EmployeeUsage ORDER BY UsageId DESC";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // GET BY ID (load all fields)
        public static bool GetEmployeeUsageById(
            int usageId,
            ref int employeeId,
            ref int carId,
            ref int branchId,
            ref string usageReason,
            ref DateTime exitDate,
            ref int status,

            ref int exitCounter,
            ref string exitFuel,

            ref int entryBranchId,
            ref DateTime entryDate,
            ref int entryCountre,
            ref string entryFuel)
        {
            string query = "SELECT * FROM EmployeeUsage WHERE UsageId = @UsageId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UsageId", usageId);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employeeId = Convert.ToInt32(reader["EmployeeId"]);
                        carId = Convert.ToInt32(reader["CarId"]);
                        branchId = Convert.ToInt32(reader["BranchId"]);
                        usageReason = reader["UsageReason"]?.ToString();
                        exitDate = Convert.ToDateTime(reader["ExitDate"]);
                        status = Convert.ToInt32(reader["Status"]);

                        exitCounter = reader["ExitCounter"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ExitCounter"]);
                        exitFuel = reader["ExitFuel"]?.ToString() ?? "";

                        entryBranchId = reader["EntryBranchId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["EntryBranchId"]);
                        entryDate = reader["EntryDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["EntryDate"]);
                        entryCountre = reader["EntryCountre"] == DBNull.Value ? 0 : Convert.ToInt32(reader["EntryCountre"]);
                        entryFuel = reader["EntryFuel"]?.ToString() ?? "";

                        return true;
                    }
                }
            }

            return false;
        }


        public static DataTable GetEmployeeUsageSummary()
        {
            string query = @"
                    SELECT 
                        eu.UsageId,
                        u.NameEn AS EmployeeName,
                        v.PlateNumber,
                        cg.Nameen AS CarGroup,
                        eu.UsageReason,
                        eu.ExitDate,
                        b.name AS ExitBranchName,
                        eu.Status
                    FROM EmployeeUsage eu
                    INNER JOIN Users u ON eu.EmployeeId = u.UserId
                    INNER JOIN vehicles v ON eu.CarId = v.CarID
                    LEFT JOIN Categories cg ON v.categoryid = cg.CategoryID
                    INNER JOIN Branch b ON eu.BranchId = b.branch_id
                    ORDER BY eu.ExitDate DESC";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static DataTable GetEmployeeUsageFullData()
        {
            string query = @"
                   SELECT 
                    eu.UsageId,
                    u.NameEn AS EmployeeName,
                    v.PlateNumber,
                    c.NameEn AS CarCategory,
                    eu.UsageReason,
                    bExit.name AS ExitBranch,
                    eu.ExitDate,
                    eu.ExitCounter,
                    eu.ExitFuel,
                    eu.Status,
                    bEntry.name AS EntryBranch,
                    eu.EntryDate,
                    eu.EntryCountre AS EntryCounter,  -- looks like a typo in your table: EntryCountre should probably be EntryCounter
                    eu.EntryFuel
                FROM EmployeeUsage eu
                INNER JOIN Users u ON eu.EmployeeId = u.UserId
                INNER JOIN vehicles v ON eu.CarId = v.CarID
                INNER JOIN Categories c ON v.CategoryId = c.CategoryID
                LEFT JOIN Branch bExit ON eu.BranchId = bExit.branch_id       -- assuming BranchId is the Exit Branch
                LEFT JOIN Branch bEntry ON eu.EntryBranchId = bEntry.branch_id
                ";
            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


    }
}
