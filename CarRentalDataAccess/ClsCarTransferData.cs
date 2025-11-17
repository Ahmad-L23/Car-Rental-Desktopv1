using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsCarTransferData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        // --------------------------------------------------------------------
        // ADD NEW CAR TRANSFER
        // --------------------------------------------------------------------
        public static int AddNewCarTransfer(
            int carId,
            int employeeId,
            string transferReason,
            int exitBranchId,
            int exitCounter,
            string exitFuel,
            DateTime? exitDate,
            int status,
            int branchTransferTo)
        {
            string query = @"
                INSERT INTO CarTransfer
                (CarId, EmployeeId, TransferReason, ExitBranchId, ExitCounter, ExitFuel, ExitDate, Status, BranchTransferTo, CreatedAt, UpdatedAt)
                VALUES
                (@CarId, @EmployeeId, @TransferReason, @ExitBranchId, @ExitCounter, @ExitFuel, @ExitDate, @Status, @BranchTransferTo, GETDATE(), GETDATE());

                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CarId", carId);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                cmd.Parameters.AddWithValue("@TransferReason", (object)transferReason ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ExitBranchId", exitBranchId);
                cmd.Parameters.AddWithValue("@ExitCounter", exitCounter);
                cmd.Parameters.AddWithValue("@ExitFuel", exitFuel);
                cmd.Parameters.AddWithValue("@ExitDate", (object)exitDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@BranchTransferTo", branchTransferTo);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && int.TryParse(result.ToString(), out int newId))
                    ? newId
                    : -1;
            }
        }

        // --------------------------------------------------------------------
        // UPDATE CAR TRANSFER
        // --------------------------------------------------------------------
        public static bool UpdateCarTransfer(
            int transferId,
            int carId,
            int employeeId,
            string transferReason,
            int exitBranchId,
            int exitCounter,
            string exitFuel,
            DateTime? exitDate,
            int status,
            int branchTransferTo)
        {
            string query = @"
                UPDATE CarTransfer SET
                    CarId            = @CarId,
                    EmployeeId       = @EmployeeId,
                    TransferReason   = @TransferReason,
                    ExitBranchId     = @ExitBranchId,
                    ExitCounter      = @ExitCounter,
                    ExitFuel         = @ExitFuel,
                    ExitDate         = @ExitDate,
                    Status           = @Status,
                    BranchTransferTo = @BranchTransferTo,
                    UpdatedAt        = GETDATE()
                WHERE TransferId = @TransferId;
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@TransferId", transferId);
                cmd.Parameters.AddWithValue("@CarId", carId);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                cmd.Parameters.AddWithValue("@TransferReason", (object)transferReason ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ExitBranchId", exitBranchId);
                cmd.Parameters.AddWithValue("@ExitCounter", exitCounter);
                cmd.Parameters.AddWithValue("@ExitFuel", exitFuel);
                cmd.Parameters.AddWithValue("@ExitDate", (object)exitDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@BranchTransferTo", branchTransferTo);

                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // --------------------------------------------------------------------
        // DELETE
        // --------------------------------------------------------------------
        public static bool DeleteCarTransfer(int transferId)
        {
            string query = "DELETE FROM CarTransfer WHERE TransferId = @TransferId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@TransferId", transferId);

                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // --------------------------------------------------------------------
        // GET ALL
        // --------------------------------------------------------------------
        public static DataTable GetAllCarTransfers()
        {
            string query = "SELECT * FROM CarTransfer ORDER BY CreatedAt DESC";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetAllCarTransfersSummery()
        {
            string query = @"
                    SELECT
                        ct.TransferId,
                        ct.TransferReason,
                        v.PlateNumber,
                        u.NameEn AS EmployeeName,
                        ct.ExitDate,
                        bExit.name AS ExitBranchName,
                        bTo.name AS TransferToBranchName,
                        ct.Status
                    FROM CarTransfer ct
                    LEFT JOIN vehicles v ON ct.CarId = v.CarID
                    LEFT JOIN Users u ON ct.EmployeeId = u.UserId
                    LEFT JOIN Branch bExit ON ct.ExitBranchId = bExit.branch_id
                    LEFT JOIN Branch bTo ON ct.BranchTransferTo = bTo.branch_id
                    ORDER BY ct.CreatedAt DESC
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


        // --------------------------------------------------------------------
        // GET BY ID
        // --------------------------------------------------------------------
        public static bool GetCarTransferById(
            int transferId,
            ref int carId,
            ref int employeeId,
            ref string transferReason,
            ref int exitBranchId,
            ref int exitCounter,
            ref string exitFuel,
            ref DateTime? exitDate,
            ref int status,
            ref int branchTransferTo)
        {
            string query = "SELECT * FROM CarTransfer WHERE TransferId = @TransferId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@TransferId", transferId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        carId = Convert.ToInt32(reader["CarId"]);
                        employeeId = Convert.ToInt32(reader["EmployeeId"]);
                        transferReason = reader["TransferReason"] == DBNull.Value ? null : reader["TransferReason"].ToString();
                        exitBranchId = Convert.ToInt32(reader["ExitBranchId"]);
                        exitCounter = Convert.ToInt32(reader["ExitCounter"]);
                        exitFuel = reader["ExitFuel"] == DBNull.Value ? null : reader["ExitFuel"].ToString(); 
                        exitDate = reader["ExitDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["ExitDate"]);
                        status = Convert.ToInt32(reader["Status"]);
                        branchTransferTo = Convert.ToInt32(reader["BranchTransferTo"]);

                        return true;
                    }
                }
            }

            return false;
        }

        // --------------------------------------------------------------------
        // GET TRANSFERS BY CAR
        // --------------------------------------------------------------------
        public static DataTable GetTransfersByCar(int carId)
        {
            string query = @"
                SELECT * FROM CarTransfer 
                WHERE CarId = @CarId 
                ORDER BY ExitDate DESC";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@CarId", carId);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
