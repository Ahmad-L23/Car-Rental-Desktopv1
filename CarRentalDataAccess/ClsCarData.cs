using CarRentalBusiness;
using System;
using System.Data;

namespace CarRentalDataAccess
{
    public static class ClsCarData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewCar(
            string carNameEn,
            string carNameAr,
            int year,
            int colorID,
            int categoryId,
            int groupId,
            int branchId,
            int fuelTypeId,
            string carImage,
            int initialCounter,
            int numberOfRiders,
            int numberOfLoads,
            System.DateTime? licenseDate,
            System.DateTime? expiryLicenseDate,
            string numberOfRegistration,
            string carNumber,
            decimal engineSize,
            string chassisNumber,
            int currentCounter,
            int numberOfSeats,
            string engineNumber,
            string plateNumber,
            int numberOfDoors,
            string gasolineType,
            decimal carPrice,
            string licenseType,
            bool isAvailable,
            string usedFor,
            int? damagesNumber,
            string description,
            string FuelExit)
        {
            string query = @"
                INSERT INTO vehicles
                (CarNameEn, CarNameAr, Year, colorID, CategoryId, GroupId, BranchId, FuelTypeID, CarImage, InitialCounter, NumberOfRiders,
                 NumberOfLoads, LicenseDate, ExpiryLicenseDate, NumberOfRegistration, CarNumber, EngineSize, ChassisNumber, CurrentCounter,
                 NumberOfSeats, EngineNumber, PlateNumber, NumberOfDoors, GasolineType, CarPrice, LicenseType, IsAvailable, UsedFor,
                 DamagesNumber, Description, FuelExit)
                VALUES
                (@CarNameEn, @CarNameAr, @Year, @colorID, @CategoryId, @GroupId, @BranchId, @FuelTypeID, @CarImage, @InitialCounter, @NumberOfRiders,
                 @NumberOfLoads, @LicenseDate, @ExpiryLicenseDate, @NumberOfRegistration, @CarNumber, @EngineSize, @ChassisNumber, @CurrentCounter,
                 @NumberOfSeats, @EngineNumber, @PlateNumber, @NumberOfDoors, @GasolineType, @CarPrice, @LicenseType, @IsAvailable, @UsedFor,
                 @DamagesNumber, @Description, @FuelExit);
                SELECT CAST(scope_identity() AS int);";

            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(conn);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@CarNameEn", carNameEn);
            cmd.Parameters.AddWithValue("@CarNameAr", carNameAr);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@colorID", colorID);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.Parameters.AddWithValue("@GroupId", groupId);
            cmd.Parameters.AddWithValue("@BranchId", branchId);
            cmd.Parameters.AddWithValue("@FuelTypeID", fuelTypeId);
            cmd.Parameters.AddWithValue("@CarImage", (object)carImage ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@InitialCounter", initialCounter);
            cmd.Parameters.AddWithValue("@NumberOfRiders", numberOfRiders);
            cmd.Parameters.AddWithValue("@NumberOfLoads", (object)numberOfLoads ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LicenseDate", (object)licenseDate ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@ExpiryLicenseDate", (object)expiryLicenseDate ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@NumberOfRegistration", (object)numberOfRegistration ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CarNumber", carNumber);
            cmd.Parameters.AddWithValue("@EngineSize", engineSize);
            cmd.Parameters.AddWithValue("@ChassisNumber", chassisNumber);
            cmd.Parameters.AddWithValue("@CurrentCounter", currentCounter);
            cmd.Parameters.AddWithValue("@NumberOfSeats", numberOfSeats);
            cmd.Parameters.AddWithValue("@EngineNumber", engineNumber);
            cmd.Parameters.AddWithValue("@PlateNumber", plateNumber);
            cmd.Parameters.AddWithValue("@FuelExit", FuelExit);
            cmd.Parameters.AddWithValue("@NumberOfDoors", numberOfDoors);
            cmd.Parameters.AddWithValue("@GasolineType", gasolineType);
            cmd.Parameters.AddWithValue("@CarPrice", carPrice);
            cmd.Parameters.AddWithValue("@LicenseType", licenseType);
            cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
            cmd.Parameters.AddWithValue("@UsedFor", usedFor);
            cmd.Parameters.AddWithValue("@DamagesNumber", (object)damagesNumber ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", (object)description ?? System.DBNull.Value);

            connection.Open();
            object result = cmd.ExecuteScalar();
            if (result != null && int.TryParse(result.ToString(), out int newId))
                return newId;

            return -1;
        }

        public static bool EditCar(
            int carId,
            string carNameEn,
            string carNameAr,
            int year,
            int colorID,
            int categoryId,
            int groupId,
            int branchId,
            int fuelTypeId,
            string carImage,
            int initialCounter,
            int numberOfRiders,
            int numberOfLoads,
            System.DateTime? licenseDate,
            System.DateTime? expiryLicenseDate,
            string numberOfRegistration,
            string carNumber,
            decimal engineSize,
            string chassisNumber,
            int currentCounter,
            int numberOfSeats,
            string engineNumber,
            string plateNumber,
            int numberOfDoors,
            string gasolineType,
            decimal carPrice,
            string licenseType,
            bool isAvailable,
            string usedFor,
            int? damagesNumber,
            string description,
            string FuelExit)
        {
            string query = @"
                UPDATE vehicles SET
                    CarNameEn = @CarNameEn,
                    CarNameAr = @CarNameAr,
                    Year = @Year,
                    Color = @colorID,
                    CategoryId = @CategoryId,
                    GroupId = @GroupId,
                    BranchId = @BranchId,
                    FuelTypeID = @FuelTypeID,
                    CarImage = @CarImage,
                    InitialCounter = @InitialCounter,
                    NumberOfRiders = @NumberOfRiders,
                    NumberOfLoads = @NumberOfLoads,
                    LicenseDate = @LicenseDate,
                    ExpiryLicenseDate = @ExpiryLicenseDate,
                    NumberOfRegistration = @NumberOfRegistration,
                    CarNumber = @CarNumber,
                    EngineSize = @EngineSize,
                    ChassisNumber = @ChassisNumber,
                    CurrentCounter = @CurrentCounter,
                    NumberOfSeats = @NumberOfSeats,
                    EngineNumber = @EngineNumber,
                    PlateNumber = @PlateNumber,
                    NumberOfDoors = @NumberOfDoors,
                    GasolineType = @GasolineType,
                    CarPrice = @CarPrice,
                    LicenseType = @LicenseType,
                    IsAvailable = @IsAvailable,
                    UsedFor = @UsedFor,
                    DamagesNumber = @DamagesNumber,
                    Description = @Description,
                    FuelExit = @FuelExit
                WHERE CarID = @CarID";

            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(conn);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@CarID", carId);
            cmd.Parameters.AddWithValue("@CarNameEn", carNameEn);
            cmd.Parameters.AddWithValue("@CarNameAr", carNameAr);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Color", colorID);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.Parameters.AddWithValue("@GroupId", groupId);
            cmd.Parameters.AddWithValue("@BranchId", branchId);
            cmd.Parameters.AddWithValue("@FuelTypeID", fuelTypeId);
            cmd.Parameters.AddWithValue("@CarImage", (object)carImage ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@InitialCounter", initialCounter);
            cmd.Parameters.AddWithValue("@NumberOfRiders", numberOfRiders);
            cmd.Parameters.AddWithValue("@NumberOfLoads", numberOfLoads);
            cmd.Parameters.AddWithValue("@LicenseDate", (object)licenseDate ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@ExpiryLicenseDate", (object)expiryLicenseDate ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@NumberOfRegistration", (object)numberOfRegistration ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@CarNumber", carNumber);
            cmd.Parameters.AddWithValue("@EngineSize", engineSize);
            cmd.Parameters.AddWithValue("@ChassisNumber", chassisNumber);
            cmd.Parameters.AddWithValue("@CurrentCounter", currentCounter);
            cmd.Parameters.AddWithValue("@NumberOfSeats", numberOfSeats);
            cmd.Parameters.AddWithValue("@EngineNumber", engineNumber);
            cmd.Parameters.AddWithValue("@PlateNumber", plateNumber);
            cmd.Parameters.AddWithValue("@NumberOfDoors", numberOfDoors);
            cmd.Parameters.AddWithValue("@GasolineType", gasolineType);
            cmd.Parameters.AddWithValue("@CarPrice", carPrice);
            cmd.Parameters.AddWithValue("@LicenseType", licenseType);
            cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
            cmd.Parameters.AddWithValue("@UsedFor", usedFor);
            cmd.Parameters.AddWithValue("@FuelExit", FuelExit);
            cmd.Parameters.AddWithValue("@DamagesNumber", (object)damagesNumber ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", (object)description ?? System.DBNull.Value);

            connection.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }

        public static bool DeleteCar(int carId)
        {
            string query = "DELETE FROM vehicles WHERE CarID = @CarID";

            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(conn);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CarID", carId);

            connection.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }

        public static DataTable GetAllCars()
        {
            string query = "SELECT * FROM vehicles";

            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(conn);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, connection);
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);

            System.Data.DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            return dt;
        }


        public static DataTable GetAllCarsWithColorName()
        {
            string query = @"
        SELECT 
            v.CarID,
            v.CarNameEn,
            v.CarNameAr,
            v.Year,
            c.ColorName AS ColorName,
            v.CategoryId,
            v.GroupId,
            v.BranchId,
            v.FuelTypeID,
            v.CarImage,
            v.InitialCounter,
            v.NumberOfRiders,
            v.NumberOfLoads,
            v.LicenseDate,
            v.ExpiryLicenseDate,
            v.NumberOfRegistration,
            v.CarNumber,
            v.EngineSize,
            v.ChassisNumber,
            v.CurrentCounter,
            v.NumberOfSeats,
            v.EngineNumber,
            v.PlateNumber,
            v.NumberOfDoors,
            v.GasolineType,
            v.CarPrice,
            v.LicenseType,
            v.IsAvailable,
            v.UsedFor,
            v.DamagesNumber,
            v.Description,  
            v.FuelExit
        FROM vehicles v
        LEFT JOIN Colors c ON v.ColorId = c.Id;";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(conn))
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, connection))
            using (System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd))
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetAllCarsIdAndPlateNumber()
        {
            string query = @"
        SELECT 
            CarID,
            PlateNumber
        FROM vehicles;";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(conn))
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, connection))
            using (System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd))
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }



        public static bool GetCarInfoById(
            int carId,
            ref string carNameEn,
            ref string carNameAr,
            ref int year,
            ref int colorID,
            ref int categoryId,
            ref int groupId,
            ref int branchId,
            ref int fuelTypeId,
            ref string carImage,
            ref int initialCounter,
            ref int numberOfRiders,
            ref int numberOfLoads,
            ref System.DateTime? licenseDate,
            ref System.DateTime? expiryLicenseDate,
            ref string numberOfRegistration,
            ref string carNumber,
            ref decimal engineSize,
            ref string chassisNumber,
            ref int currentCounter,
            ref int numberOfSeats,
            ref string engineNumber,
            ref string plateNumber,
            ref int numberOfDoors,
            ref string gasolineType,
            ref decimal carPrice,
            ref string licenseType,
            ref bool isAvailable,
            ref string usedFor,
            ref int? damagesNumber,
            ref string description,
            ref string FuelExit)
        {
            string query = "SELECT * FROM vehicles WHERE CarID = @CarID";

            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(conn);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CarID", carId);

            connection.Open();
            System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                carNameEn = reader["CarNameEn"].ToString();
                carNameAr = reader["CarNameAr"].ToString();
                year = Convert.ToInt32(reader["Year"]);
                colorID = Convert.ToInt32(reader[colorID]);
                categoryId = Convert.ToInt32(reader["CategoryId"]);
                groupId = Convert.ToInt32(reader["GroupId"]);
                branchId = Convert.ToInt32(reader["BranchId"]);
                fuelTypeId = Convert.ToInt32(reader["FuelTypeID"]);
                carImage = reader["CarImage"] == System.DBNull.Value ? null : reader["CarImage"].ToString();
                initialCounter = Convert.ToInt32(reader["InitialCounter"]);
                numberOfRiders = Convert.ToInt32(reader["NumberOfRiders"]);
                numberOfLoads = Convert.ToInt32(reader["NumberOfLoads"]);
                licenseDate = reader["LicenseDate"] == System.DBNull.Value ? (System.DateTime?)null : Convert.ToDateTime(reader["LicenseDate"]);
                expiryLicenseDate = reader["ExpiryLicenseDate"] == System.DBNull.Value ? (System.DateTime?)null : Convert.ToDateTime(reader["ExpiryLicenseDate"]);
                numberOfRegistration = reader["NumberOfRegistration"] == System.DBNull.Value ? null : reader["NumberOfRegistration"].ToString();
                carNumber = reader["CarNumber"].ToString();
                engineSize = Convert.ToDecimal(reader["EngineSize"]);
                chassisNumber = reader["ChassisNumber"].ToString();
                currentCounter = Convert.ToInt32(reader["CurrentCounter"]);
                numberOfSeats = Convert.ToInt32(reader["NumberOfSeats"]);
                engineNumber = reader["EngineNumber"].ToString();
                plateNumber = reader["PlateNumber"].ToString();
                numberOfDoors = Convert.ToInt32(reader["NumberOfDoors"]);
                gasolineType = reader["GasolineType"].ToString();
                carPrice = Convert.ToDecimal(reader["CarPrice"]);
                licenseType = reader["LicenseType"].ToString();
                isAvailable = Convert.ToBoolean(reader["IsAvailable"]);
                usedFor = reader["UsedFor"].ToString();
                FuelExit = reader["FuelExit"].ToString();
                damagesNumber = reader["DamagesNumber"] == System.DBNull.Value ? (int?)null : Convert.ToInt32(reader["DamagesNumber"]);
                description = reader["Description"] == System.DBNull.Value ? null : reader["Description"].ToString();

                return true;
            }
            return false;
        }

        public static bool GetCarByPlateNumber(
                string plateNumber,
                ref string chassisNumber,
                ref string carNameEn,
                ref int groupId,
                ref int year,
                ref decimal engineSize,
                ref bool isAvailable)
                    {
                        string query = @"
                    SELECT TOP 1
                        ChassisNumber,
                        CarNameEn,
                        GroupId,
                        Year,
                        EngineSize,
                        IsAvailable
                    FROM vehicles
                    WHERE PlateNumber LIKE @PlateNumber
                    ORDER BY PlateNumber
                ";

            using (var connection = new System.Data.SqlClient.SqlConnection(conn))
            using (var cmd = new System.Data.SqlClient.SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@PlateNumber", "%" + plateNumber + "%");

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
  
                        chassisNumber = reader["ChassisNumber"]?.ToString() ?? "";
                        carNameEn = reader["CarNameEn"]?.ToString() ?? "";
                        groupId = reader["GroupId"] != DBNull.Value ? Convert.ToInt32(reader["GroupId"]) : 0;
                        year = reader["Year"] != DBNull.Value ? Convert.ToInt32(reader["Year"]) : 0;
                        engineSize = reader["EngineSize"] != DBNull.Value ? Convert.ToDecimal(reader["EngineSize"]) : 0;
                        isAvailable = reader["IsAvailable"] != DBNull.Value && Convert.ToBoolean(reader["IsAvailable"]);

                        return true;
                    }
                }
            }

            return false;
        }



        public static bool IsCarAvailable(int carId)
        {
            string query = "SELECT IsAvailable FROM vehicles WHERE CarID = @CarID";

            using (var connection = new System.Data.SqlClient.SqlConnection(conn))
            using (var cmd = new System.Data.SqlClient.SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CarID", carId);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToBoolean(result);
                }
                else
                {
                    // If car not found or availability not set, return false
                    return false;
                }
            }
        }


        public static string GetCarUnavailableReason(int carId)
        {
            string query = @"
        SELECT 
            CASE 
                WHEN IsAvailable = 1 AND Status = 0 THEN 'Car is available.'
                WHEN Status = 1 THEN 'Car is currently rented.'
                WHEN Status = 2 THEN 'Car is in employee usage.'
                WHEN Status = 3 THEN 'Car is under maintenance.'
                WHEN Status = 4 THEN 'Car is under Transfer.'
                ELSE 'Car status unknown or not available.'
            END AS AvailabilityReason
        FROM vehicles
        WHERE CarID = @CarID";

            using (var connection = new System.Data.SqlClient.SqlConnection(conn))
            using (var cmd = new System.Data.SqlClient.SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CarID", carId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
            }

            return "Car not found.";
        }


    }
}
