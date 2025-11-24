using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsAgreementData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewAgreement(
            int customerId,

            int carId,
            int pickupBranchId,
            int dropOffBranchId,
            DateTime startDate,
            DateTime endDate,
            decimal agreedPrice,
            decimal rentalPenaltyPerDay,
            decimal totalAmountBeforeTax,
            int permittedDailyKilometers,
            decimal additionalKilometerPrice,
            decimal taxRate,
            decimal initialPaidAmount,
            string paymentMethod,
            DateTime paymentDate,
            DateTime? actualDeliveryDate,
            int receivingOdometer,
            int consumedMileage,
            int mileage,
            string ExitFuel,
            int serialNumber,
            decimal additionContractPrice,
            decimal rentalAdditionsPrice,
            decimal requiredInsurancePrice, decimal rentalDaysCost, decimal TotalAmountIncludeTax
        )
        {
            string query = @"
                INSERT INTO Agreement
                (
                    CustomerID, CarID, PickupBranchID, DropOffBranchID, StartDate, EndDate, AgreedPrice,
                    RentalPenaltyPerDay, TotalAmountBeforeTax, PermittedDailyKilometers, AdditionalKilometerPrice,
                    TaxRate, InitialPaidAmount, PaymentMethod, PaymentDate, ActualDeliveryDate,
                    ReceivingOdometer, ConsumedMileage, Mileage, ExitFuel, SerialNumber,
                    additionContractPrice, RentalAdditionsPrice, RequiredInsurancePrice,rentalDaysCost,TotalAmountIncludeTax
                )
                VALUES
                (
                    @CustomerID, @CarID, @PickupBranchID, @DropOffBranchID, @StartDate, @EndDate, @AgreedPrice,
                    @RentalPenaltyPerDay, @TotalAmountBeforeTax, @PermittedDailyKilometers, @AdditionalKilometerPrice,
                    @TaxRate, @InitialPaidAmount, @PaymentMethod, @PaymentDate, @ActualDeliveryDate,
                    @ReceivingOdometer, @ConsumedMileage, @Mileage, @ExitFuel, @SerialNumber,
                    @AdditionContractPrice, @RentalAdditionsPrice, @RequiredInsurancePrice, @rentalDaysCost,@TotalAmountIncludeTax
                );
                SELECT CAST(scope_identity() AS int);
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@CarID", carId);
                cmd.Parameters.AddWithValue("@PickupBranchID", pickupBranchId);
                cmd.Parameters.AddWithValue("@DropOffBranchID", dropOffBranchId);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@AgreedPrice", agreedPrice);
                cmd.Parameters.AddWithValue("@RentalPenaltyPerDay", rentalPenaltyPerDay);
                cmd.Parameters.AddWithValue("@TotalAmountBeforeTax", totalAmountBeforeTax);
                cmd.Parameters.AddWithValue("@PermittedDailyKilometers", permittedDailyKilometers);
                cmd.Parameters.AddWithValue("@AdditionalKilometerPrice", additionalKilometerPrice);
                cmd.Parameters.AddWithValue("@TaxRate", taxRate);
                cmd.Parameters.AddWithValue("@InitialPaidAmount", initialPaidAmount);
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                cmd.Parameters.AddWithValue("@ActualDeliveryDate", (object)actualDeliveryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ReceivingOdometer", receivingOdometer);
                cmd.Parameters.AddWithValue("@ConsumedMileage", consumedMileage);
                cmd.Parameters.AddWithValue("@Mileage", mileage);
                cmd.Parameters.AddWithValue("@rentalDaysCost", rentalDaysCost);
                cmd.Parameters.AddWithValue("@TotalAmountIncludeTax", TotalAmountIncludeTax);
                cmd.Parameters.AddWithValue("@ExitFuel", ExitFuel ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                cmd.Parameters.AddWithValue("@AdditionContractPrice", additionContractPrice);
                cmd.Parameters.AddWithValue("@RentalAdditionsPrice", rentalAdditionsPrice);
                cmd.Parameters.AddWithValue("@RequiredInsurancePrice", requiredInsurancePrice);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditAgreement( 
            int agreementId,
            int customerId,
            int carId,
            int pickupBranchId,
            int dropOffBranchId,
            DateTime startDate,
            DateTime endDate,
            decimal agreedPrice,
            decimal rentalPenaltyPerDay,
            decimal totalAmountBeforeTax,
            int permittedDailyKilometers,
            decimal additionalKilometerPrice,
            decimal taxRate,
            decimal initialPaidAmount,
            string paymentMethod,
            DateTime paymentDate,
            DateTime? actualDeliveryDate,
            int receivingOdometer,
            int consumedMileage,
            int mileage,
            string ExitFuel,
            int serialNumber,
            decimal additionContractPrice,
            decimal rentalAdditionsPrice,
            decimal requiredInsurancePrice,
             decimal rentalDaysCost, decimal TotalAmountIncludeTax
        )
        {
            string query = @"
                UPDATE Agreement SET
                    CustomerID = @CustomerID,
                    CarID = @CarID,
                    PickupBranchID = @PickupBranchID,
                    DropOffBranchID = @DropOffBranchID,
                    StartDate = @StartDate,
                    EndDate = @EndDate,
                    AgreedPrice = @AgreedPrice,
                    RentalPenaltyPerDay = @RentalPenaltyPerDay,
                    TotalAmountBeforeTax = @TotalAmountBeforeTax,
                    PermittedDailyKilometers = @PermittedDailyKilometers,
                    AdditionalKilometerPrice = @AdditionalKilometerPrice,
                    TaxRate = @TaxRate,
                    InitialPaidAmount = @InitialPaidAmount,
                    PaymentMethod = @PaymentMethod,
                    PaymentDate = @PaymentDate,
                    ActualDeliveryDate = @ActualDeliveryDate,
                    ReceivingOdometer = @ReceivingOdometer,
                    ConsumedMileage = @ConsumedMileage,
                    Mileage = @Mileage,
                    ExitFuel = @ExitFuel,
                    SerialNumber = @SerialNumber,
                    additionContractPrice = @AdditionContractPrice,
                    RentalAdditionsPrice = @RentalAdditionsPrice,
                    RequiredInsurancePrice = @RequiredInsurancePrice,
                    rentalDaysCost = @rentalDaysCost,
                    TotalAmountIncludeTax = @TotalAmountIncludeTax
                WHERE AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@CarID", carId);
                cmd.Parameters.AddWithValue("@PickupBranchID", pickupBranchId);
                cmd.Parameters.AddWithValue("@DropOffBranchID", dropOffBranchId);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@AgreedPrice", agreedPrice);
                cmd.Parameters.AddWithValue("@RentalPenaltyPerDay", rentalPenaltyPerDay);
                cmd.Parameters.AddWithValue("@TotalAmountBeforeTax", totalAmountBeforeTax);
                cmd.Parameters.AddWithValue("@PermittedDailyKilometers", permittedDailyKilometers);
                cmd.Parameters.AddWithValue("@AdditionalKilometerPrice", additionalKilometerPrice);
                cmd.Parameters.AddWithValue("@TaxRate", taxRate);
                cmd.Parameters.AddWithValue("@InitialPaidAmount", initialPaidAmount);
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                cmd.Parameters.AddWithValue("@ActualDeliveryDate", (object)actualDeliveryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ReceivingOdometer", receivingOdometer);
                cmd.Parameters.AddWithValue("@ConsumedMileage", consumedMileage);
                cmd.Parameters.AddWithValue("@Mileage", mileage);
                cmd.Parameters.AddWithValue("@rentalDaysCost", rentalDaysCost);
                cmd.Parameters.AddWithValue("@TotalAmountIncludeTax", TotalAmountIncludeTax);
                cmd.Parameters.AddWithValue("@ExitFuel", ExitFuel ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                cmd.Parameters.AddWithValue("@AdditionContractPrice", additionContractPrice);
                cmd.Parameters.AddWithValue("@RentalAdditionsPrice", rentalAdditionsPrice);
                cmd.Parameters.AddWithValue("@RequiredInsurancePrice", requiredInsurancePrice);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteAgreement(int agreementId)
        {
            string query = "DELETE FROM Agreement WHERE AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsAgreementExist(int agreementId)
        {
            string query = "SELECT COUNT(1) FROM Agreement WHERE AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetAllAgreements()
        {
            string query = "SELECT * FROM Agreement";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetAgreementById(int agreementId, ref int customerId, ref int carId, ref int pickupBranchId,
            ref int dropOffBranchId, ref DateTime startDate, ref DateTime endDate, ref decimal agreedPrice,
            ref decimal rentalPenaltyPerDay, ref decimal totalAmountBeforeTax, ref int permittedDailyKilometers,
            ref decimal additionalKilometerPrice, ref decimal taxRate, ref decimal initialPaidAmount,
            ref string paymentMethod, ref DateTime paymentDate, ref DateTime? actualDeliveryDate,
            ref int receivingOdometer, ref int consumedMileage, ref int mileage, ref string ExitFuel, ref int serialNumber,
            ref decimal additionContractPrice, ref decimal rentalAdditionsPrice, ref decimal requiredInsurancePrice, ref decimal rentalDaysCost, ref decimal TotalAmountIncludeTax)
        {
            string query = "SELECT * FROM Agreement WHERE AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customerId = Convert.ToInt32(reader["CustomerID"]);
                        carId = Convert.ToInt32(reader["CarID"]);
                        pickupBranchId = Convert.ToInt32(reader["PickupBranchID"]);
                        dropOffBranchId = Convert.ToInt32(reader["DropOffBranchID"]);
                        startDate = Convert.ToDateTime(reader["StartDate"]);
                        endDate = Convert.ToDateTime(reader["EndDate"]);
                        agreedPrice = Convert.ToDecimal(reader["AgreedPrice"]);
                        rentalPenaltyPerDay = Convert.ToDecimal(reader["RentalPenaltyPerDay"]);
                        totalAmountBeforeTax = Convert.ToDecimal(reader["TotalAmountBeforeTax"]);
                        permittedDailyKilometers = Convert.ToInt32(reader["PermittedDailyKilometers"]);
                        additionalKilometerPrice = Convert.ToDecimal(reader["AdditionalKilometerPrice"]);
                        taxRate = Convert.ToDecimal(reader["TaxRate"]);
                        initialPaidAmount = Convert.ToDecimal(reader["InitialPaidAmount"]);
                        paymentMethod = reader["PaymentMethod"]?.ToString();
                        paymentDate = Convert.ToDateTime(reader["PaymentDate"]);
                        actualDeliveryDate = reader["ActualDeliveryDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ActualDeliveryDate"]);
                        receivingOdometer = Convert.ToInt32(reader["ReceivingOdometer"]);
                        consumedMileage = Convert.ToInt32(reader["ConsumedMileage"]);
                        mileage = Convert.ToInt32(reader["Mileage"]);
                        ExitFuel = reader["ExitFuel"]?.ToString();
                        serialNumber =Convert.ToInt32 (reader["SerialNumber"]);
                        additionContractPrice = Convert.ToDecimal(reader["additionContractPrice"]);
                        rentalAdditionsPrice = Convert.ToDecimal(reader["RentalAdditionsPrice"]);
                        requiredInsurancePrice = Convert.ToDecimal(reader["RequiredInsurancePrice"]);
                        rentalDaysCost = Convert.ToDecimal(reader["rentalDaysCost"]);
                        TotalAmountIncludeTax = Convert.ToDecimal(reader["TotalAmountIncludeTax"]);

                        return true;
                    }
                }
            }
            return false;
        }


        public static DataTable GetAgreementFullInfoAsDataTable(int agreementId)
        {
            string query = @"
        SELECT 
            a.AgreementID,
            a.CustomerID,
            a.CarID,
            a.PickupBranchID,
            a.DropOffBranchID,
            a.StartDate,
            a.EndDate,
            a.AgreedPrice,
            a.RentalPenaltyPerDay,
            a.TotalAmountBeforeTax,
            a.PermittedDailyKilometers,
            a.AdditionalKilometerPrice,
            a.TaxRate,
            a.InitialPaidAmount,
            a.PaymentMethod,
            a.PaymentDate,
            a.ActualDeliveryDate,
            a.ReceivingOdometer,
            a.ConsumedMileage,
            a.Mileage,
            a.rentalDaysCost,
            a.TotalAmountIncludeTax,
            ExitFuel,
            a.SerialNumber,
            a.additionContractPrice,
            a.RentalAdditionsPrice,
            a.RequiredInsurancePrice,

            c.customer_name_en,
            c.identity_number,
            c.phone_number,
            c.address_en,

            v.CarNameEn,
            v.PlateNumber,
            cat.NameEn AS CarCategory,
            v.Year,
            v.CurrentCounter,
            v.FuelExit
        FROM Agreement a
        INNER JOIN Customers c ON a.CustomerID = c.customer_id
        INNER JOIN vehicles v ON a.CarID = v.CarID
        INNER JOIN Categories cat ON v.CategoryId = cat.CategoryID
        WHERE a.AgreementID = @AgreementID";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AgreementID", agreementId);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }


        public static DataTable GetAllAgreementsFullInfo()
        {
            string query = @"
        SELECT 
            a.AgreementID,
            a.CustomerID,
            a.CarID,
            a.PickupBranchID,
            a.DropOffBranchID,
            a.StartDate,
            a.EndDate,
            a.AgreedPrice,
            a.RentalPenaltyPerDay,
            a.TotalAmountBeforeTax,
            a.PermittedDailyKilometers,
            a.AdditionalKilometerPrice,
            a.TaxRate,
            a.InitialPaidAmount,
            a.PaymentMethod,
            a.PaymentDate,
            a.ActualDeliveryDate,
            a.ReceivingOdometer,
            a.ConsumedMileage,
            a.Mileage,
            a.rentalDaysCost,
            a.TotalAmountIncludeTax,
            ExitFuel,
            a.SerialNumber,
            a.additionContractPrice,
            a.RentalAdditionsPrice,
            a.RequiredInsurancePrice,

            c.customer_name_en,
            c.identity_number,
            c.phone_number,
            c.address_en,

            v.CarNameEn,
            v.PlateNumber,
            cat.NameEn AS CarCategory,
            v.Year,
            v.CurrentCounter,
            v.FuelExit
        FROM Agreement a
        INNER JOIN Customers c ON a.CustomerID = c.customer_id
        INNER JOIN vehicles v ON a.CarID = v.CarID
        INNER JOIN Categories cat ON v.CategoryId = cat.CategoryID
        ORDER BY a.AgreementID DESC";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static int GetLastSerialNumber()
        {
            string query = "SELECT ISNULL(MAX(SerialNumber), 0) FROM Agreement";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int lastSerial))
                {
                    return lastSerial;
                }
                return 0; // if no rows, return 0 as default
            }
        }



    }
}
