using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsUserData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewUser(
            string nameEn,
            string nameAr,
            string userName,
            string email,
            string password,
            string employeeNumber,
            string nationalId,
            int? nationalityId,
            int? roleId,
            int? branchId,
            string licenseNumber,
            DateTime? licenseExpiryDate,
            string primaryPhoneNumber,
            string secondaryPhoneNumber)
        {
            string query = @"
                INSERT INTO Users
                (NameEn, NameAr, UserName, Email, Password, EmployeeNumber, NationalId, NationalityId, RoleId, BranchId, LicenseNumber, LicenseExpiryDate, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedAt, UpdatedAt)
                VALUES
                (@NameEn, @NameAr, @UserName, @Email, @Password, @EmployeeNumber, @NationalId, @NationalityId, @RoleId, @BranchId, @LicenseNumber, @LicenseExpiryDate, @PrimaryPhoneNumber, @SecondaryPhoneNumber, GETDATE(), GETDATE());
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NameEn", nameEn);
                cmd.Parameters.AddWithValue("@NameAr", nameAr);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                cmd.Parameters.AddWithValue("@NationalId", nationalId);
                cmd.Parameters.AddWithValue("@NationalityId", (object)nationalityId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RoleId", (object)roleId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BranchId", (object)branchId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseNumber", licenseNumber);
                cmd.Parameters.AddWithValue("@LicenseExpiryDate", (object)licenseExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                cmd.Parameters.AddWithValue("@SecondaryPhoneNumber", secondaryPhoneNumber);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditUser(
            int userId,
            string nameEn,
            string nameAr,
            string userName,
            string email,
            string password,
            string employeeNumber,
            string nationalId,
            int? nationalityId,
            int? roleId,
            int? branchId,
            string licenseNumber,
            DateTime? licenseExpiryDate,
            string primaryPhoneNumber,
            string secondaryPhoneNumber)
        {
            string query = @"
                UPDATE Users SET
                    NameEn = @NameEn,
                    NameAr = @NameAr,
                    UserName = @UserName,
                    Email = @Email,
                    Password = @Password,
                    EmployeeNumber = @EmployeeNumber,
                    NationalId = @NationalId,
                    NationalityId = @NationalityId,
                    RoleId = @RoleId,
                    BranchId = @BranchId,
                    LicenseNumber = @LicenseNumber,
                    LicenseExpiryDate = @LicenseExpiryDate,
                    PrimaryPhoneNumber = @PrimaryPhoneNumber,
                    SecondaryPhoneNumber = @SecondaryPhoneNumber,
                    UpdatedAt = GETDATE()
                WHERE UserId = @UserId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@NameEn", nameEn);
                cmd.Parameters.AddWithValue("@NameAr", nameAr);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                cmd.Parameters.AddWithValue("@NationalId", nationalId);
                cmd.Parameters.AddWithValue("@NationalityId", (object)nationalityId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RoleId", (object)roleId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BranchId", (object)branchId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseNumber", licenseNumber);
                cmd.Parameters.AddWithValue("@LicenseExpiryDate", (object)licenseExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                cmd.Parameters.AddWithValue("@SecondaryPhoneNumber", secondaryPhoneNumber);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE UserId = @UserId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsUserExist(int userId)
        {
            string query = "SELECT 1 FROM Users WHERE UserId = @UserId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static bool IsUserExist(string userName)
        {
            const string query = "SELECT 1 FROM Users WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 100).Value = userName.Trim();

                connection.Open();
                var result = cmd.ExecuteScalar();

                // If result is not null → user exists
                return result != null;
            }
        }


        public static DataTable GetAllUsers()
        {
            string query = "SELECT * FROM Users";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetUserInfoById(
            int userId,
            ref string nameEn,
            ref string nameAr,
            ref string userName,
            ref string email,
            ref string password,
            ref string employeeNumber,
            ref string nationalId,
            ref int? nationalityId,
            ref int? roleId,
            ref int? branchId,
            ref string licenseNumber,
            ref DateTime? licenseExpiryDate,
            ref string primaryPhoneNumber,
            ref string secondaryPhoneNumber)
        {
            string query = "SELECT * FROM Users WHERE UserId = @UserId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nameEn = reader["NameEn"]?.ToString();
                        nameAr = reader["NameAr"]?.ToString();
                        userName = reader["UserName"]?.ToString();
                        email = reader["Email"]?.ToString();
                        password = reader["Password"]?.ToString();
                        employeeNumber = reader["EmployeeNumber"]?.ToString();
                        nationalId = reader["NationalId"]?.ToString();
                        nationalityId = reader["NationalityId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NationalityId"]);
                        roleId = reader["RoleId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["RoleId"]);
                        branchId = reader["BranchId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["BranchId"]);
                        licenseNumber = reader["LicenseNumber"]?.ToString();
                        licenseExpiryDate = reader["LicenseExpiryDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["LicenseExpiryDate"]);
                        primaryPhoneNumber = reader["PrimaryPhoneNumber"]?.ToString();
                        secondaryPhoneNumber = reader["SecondaryPhoneNumber"]?.ToString();

                        return true;
                    }
                }
            }
            return false;
        }

        public static int? ValidateUserCredentials(string userName, string password)
        {
            string query = @"
                SELECT UserId 
                FROM Users 
                WHERE UserName = @UserName AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int userId))
                    return userId;

                return null;
            }
        }
    }
}
