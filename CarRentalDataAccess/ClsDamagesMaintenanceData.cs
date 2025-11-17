using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsDamagesMaintenanceData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        //==================================================
        // ADD NEW RECORD
        //==================================================
        public static int AddNewDamagesMaintenance(
            int CarId,
            DateTime DamageDate,
            decimal TotalAmount,
            int Status,
            decimal GasolineIn,
            decimal GasolineOut,
            string GarageName,
            int? EmployeeId,
            DateTime? RepairStartDate,
            DateTime? CompletionDate,
            string Description)   // <- إضافة البراميتر
        {
            string query = @"
                INSERT INTO DamagesMaintenance
                (CarID, DamageDate, TotalAmount, Status, GasolineIn, GasolineOut, GarageName, EmployeeID, RepairStartDate, CompletionDate, Description)
                VALUES
                (@CarId, @DamageDate, @TotalAmount, @Status, @GasolineIn, @GasolineOut, @GarageName, @EmployeeId, @RepairStartDate, @CompletionDate, @Description);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CarId", CarId);
                cmd.Parameters.AddWithValue("@DamageDate", DamageDate);
                cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@GasolineIn", GasolineIn);
                cmd.Parameters.AddWithValue("@GasolineOut", GasolineOut);
                cmd.Parameters.AddWithValue("@GarageName", GarageName);
                cmd.Parameters.AddWithValue("@EmployeeId", (object)EmployeeId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RepairStartDate", (object)RepairStartDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CompletionDate", (object)CompletionDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)Description ?? DBNull.Value);  // <- هنا

                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        //==================================================
        // UPDATE
        //==================================================
        public static bool UpdateDamagesMaintenance(
            int DamageId,
            int CarId,
            DateTime DamageDate,
            decimal TotalAmount,
            int Status,
            decimal GasolineIn,
            decimal GasolineOut,
            string GarageName,
            int? EmployeeId,
            DateTime? RepairStartDate,
            DateTime? CompletionDate,
            string Description)  // <- إضافة البراميتر
        {
            string query = @"
                UPDATE DamagesMaintenance SET
                    CarID = @CarId,
                    DamageDate = @DamageDate,
                    TotalAmount = @TotalAmount,
                    Status = @Status,
                    GasolineIn = @GasolineIn,
                    GasolineOut = @GasolineOut,
                    GarageName = @GarageName,
                    EmployeeID = @EmployeeID,
                    RepairStartDate = @RepairStartDate,
                    CompletionDate = @CompletionDate,
                    Description = @Description   -- <- إضافة التحديث هنا
                WHERE DamageID = @DamageID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@DamageID", DamageId);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                cmd.Parameters.AddWithValue("@DamageDate", DamageDate);
                cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@GasolineIn", GasolineIn);
                cmd.Parameters.AddWithValue("@GasolineOut", GasolineOut);
                cmd.Parameters.AddWithValue("@GarageName", GarageName);
                cmd.Parameters.AddWithValue("@EmployeeID", (object)EmployeeId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RepairStartDate", (object)RepairStartDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CompletionDate", (object)CompletionDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)Description ?? DBNull.Value);  // <- هنا

                connection.Open();
                int rows = cmd.ExecuteNonQuery();

                return rows > 0;
            }
        }

        //==================================================
        // DELETE
        //==================================================
        public static bool DeleteDamage(int DamageId)
        {
            string query = "DELETE FROM DamagesMaintenance WHERE DamageID = @DamageID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@DamageID", DamageId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        //==================================================
        // CHECK IF EXISTS
        //==================================================
        public static bool IsDamageExist(int DamageId)
        {
            string query = "SELECT COUNT(1) FROM DamagesMaintenance WHERE DamageID = @DamageID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@DamageID", DamageId);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        //==================================================
        // GET BY ID
        //==================================================
        public static bool GetDamageById(
            int DamageId,
            ref int CarId,
            ref DateTime DamageDate,
            ref decimal TotalAmount,
            ref int Status,
            ref decimal GasolineIn,
            ref decimal GasolineOut,
            ref string GarageName,
            ref int? EmployeeId,
            ref DateTime? RepairStartDate,
            ref DateTime? CompletionDate,
            ref string Description)  // <- إضافة البراميتر هنا
        {
            string query = "SELECT * FROM DamagesMaintenance WHERE DamageID = @DamageID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@DamageID", DamageId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        CarId = Convert.ToInt32(reader["CarID"]);
                        DamageDate = Convert.ToDateTime(reader["DamageDate"]);
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                        Status = Convert.ToInt32(reader["Status"]);
                        GasolineIn = Convert.ToDecimal(reader["GasolineIn"]);
                        GasolineOut = Convert.ToDecimal(reader["GasolineOut"]);
                        GarageName = reader["GarageName"]?.ToString();

                        EmployeeId = reader["EmployeeID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["EmployeeID"]);
                        RepairStartDate = reader["RepairStartDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["RepairStartDate"]);
                        CompletionDate = reader["CompletionDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["CompletionDate"]);
                        Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString();  // <- هنا

                        return true;
                    }
                }
            }

            return false;
        }

        //==================================================
        // GET ALL
        //==================================================
        public static DataTable GetAllDamages()
        {
            string query = "SELECT * FROM DamagesMaintenance";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetAllDamagesWithVehicleInfo()
        {
            string query = @"
        SELECT 
            dm.*,
            v.EngineNumber,
            v.EngineSize,
            v.ChassisNumber,
            v.PlateNumber
        FROM DamagesMaintenance dm
        JOIN vehicles v ON dm.CarID = v.CarID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static DataTable GetAllDamagesWithFullInfo()
        {
            string query = @"
                   SELECT 
                dm.DamageID,
                dm.CarID,
                dm.DamageDate,
                dm.TotalAmount,
                dm.Status,
                dm.GasolineIn,
                dm.GasolineOut,
                dm.GarageName,
                dm.EmployeeID,
                u.UserName AS EmployeeName,
                dm.RepairStartDate,
                dm.CompletionDate,
                dm.Description,
                v.PlateNumber,
                v.EngineNumber,
                v.EngineSize,
                v.ChassisNumber
            FROM DamagesMaintenance dm
            LEFT JOIN Users u ON dm.EmployeeID = u.UserId
            LEFT JOIN Vehicles v ON dm.CarID = v.CarID";

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
