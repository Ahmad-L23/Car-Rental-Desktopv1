using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public class ClsMediatorData
    {
        private static string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewMediator(string mediatorEnName, string mediatorArName, string email, double percentage, string phoneNumber, bool isActive)
        {
            int newMediatorId = -1;
            string query = @"
                INSERT INTO Mediators 
                    (mediator_name_en, mediator_name_ar, email_address, percentage, phone_number, is_active)
                VALUES 
                    (@MediatorEnName, @MediatorArName, @Email, @Percentage, @PhoneNumber, @IsActive);
                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MediatorEnName", mediatorEnName);
                command.Parameters.AddWithValue("@MediatorArName", mediatorArName);
                command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Percentage", percentage);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@IsActive", isActive);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    newMediatorId = Convert.ToInt32(result);
            }

            return newMediatorId;
        }

        public static bool EditMediator(int? mediatorId, string mediatorEnName, string mediatorArName, string email, double percentage, string phoneNumber, bool isActive)
        {
            string query = @"
                UPDATE Mediators SET
                    mediator_name_en = @MediatorEnName,
                    mediator_name_ar = @MediatorArName,
                    email_address = @Email,
                    percentage = @Percentage,
                    phone_number = @PhoneNumber,
                    is_active = @IsActive
                WHERE mediator_id = @MediatorId
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MediatorId", mediatorId);
                command.Parameters.AddWithValue("@MediatorEnName", mediatorEnName);
                command.Parameters.AddWithValue("@MediatorArName", mediatorArName);
                command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Percentage", percentage);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@IsActive", isActive);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static bool DeleteMediator(int mediatorId)
        {
            string query = "DELETE FROM Mediators WHERE mediator_id = @MediatorId";

            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MediatorId", mediatorId);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex) { 
                return false;
            }
        }

        /// <summary>
        /// Get mediator info by exact ID, fills ref params, returns true if found.
        /// Adds ref string statusText with 'Active'/'Inactive' value.
        /// </summary>
        public static bool GetMediatorInfoById(int mediatorId,
                                               ref string mediatorEnName,
                                               ref string mediatorArName,
                                               ref string email,
                                               ref double percentage,
                                               ref string phoneNumber,
                                               ref bool isActive,
                                               ref string statusText)  // New param
        {
            string query = @"
                SELECT mediator_name_en, mediator_name_ar, email_address, percentage, phone_number, is_active,
                    CASE WHEN is_active = 1 THEN 'Active' ELSE 'Inactive' END AS StatusText
                FROM Mediators
                WHERE mediator_id = @MediatorId
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MediatorId", mediatorId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mediatorEnName = reader.GetString(0);
                        mediatorArName = reader.GetString(1);
                        email = reader.IsDBNull(2) ? null : reader.GetString(2);
                        percentage = Convert.ToDouble(reader["percentage"]);
                        phoneNumber = reader.IsDBNull(4) ? null : reader.GetString(4);
                        isActive = reader.GetBoolean(5);
                        statusText = reader.GetString(6);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Get mediator info by exact name (English or Arabic), fills ref params, returns true if found.
        /// Adds ref string statusText with 'Active'/'Inactive' value.
        /// </summary>
        public static bool GetMediatorInfoByName(
      ref int? mediatorId,         // Added ID ref param
      ref string mediatorEnName,
      ref string mediatorArName,
      ref string email,
      ref double percentage,
      ref string phoneNumber,
      ref bool isActive,
      ref string statusText)  // New param
        {
            string query = @"
        SELECT TOP 1 mediator_id, mediator_name_en, mediator_name_ar, email_address, percentage, phone_number, is_active,
            CASE WHEN is_active = 1 THEN 'Active' ELSE 'Inactive' END AS StatusText
        FROM Mediators
        WHERE mediator_name_en = @MediatorEnName OR mediator_name_ar = @MediatorArName
    ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MediatorEnName", mediatorEnName);
                command.Parameters.AddWithValue("@MediatorArName", mediatorArName);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mediatorId = reader.GetInt32(0);              // mediator_id
                        mediatorEnName = reader.GetString(1);         // mediator_name_en
                        mediatorArName = reader.GetString(2);         // mediator_name_ar
                        email = reader.IsDBNull(3) ? null : reader.GetString(3);
                        percentage = reader.GetDouble(4);
                        phoneNumber = reader.GetString(5);
                        isActive = reader.GetBoolean(6);
                        statusText = reader.GetString(7);
                        return true;
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// Find mediators by partial name (English or Arabic), returns all matches as DataTable.
        /// Includes StatusText column for is_active.
        /// </summary>
        public static DataTable FindByNamePartial(string namePart)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT mediator_id, mediator_name_en, mediator_name_ar, email_address, percentage, phone_number, is_active,
                    CASE WHEN is_active = 1 THEN 'Active' ELSE 'Inactive' END AS StatusText
                FROM Mediators 
                WHERE mediator_name_en LIKE @NamePart OR mediator_name_ar LIKE @NamePart
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NamePart", "%" + namePart + "%");
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        /// <summary>
        /// Get all mediators, includes StatusText column for is_active.
        /// </summary>
        public static DataTable GetAllMediators()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT mediator_id, mediator_name_en, mediator_name_ar, email_address, percentage, phone_number, is_active,
                    CASE WHEN is_active = 1 THEN 'Active' ELSE 'Inactive' END AS StatusText
                FROM Mediators
                ORDER BY mediator_name_en
            ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Check if mediator exists by ID.
        /// </summary>
        public static bool IsMediatorExist(int mediatorId)
        {
            string query = "SELECT COUNT(1) FROM Mediators WHERE mediator_id = @MediatorId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MediatorId", mediatorId);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public static bool IsMediatorExistByEnglishName(string mediatorNameEn)
        {
            string query = @"
        SELECT COUNT(1) FROM Mediators 
        WHERE mediator_name_en = @MediatorNameEn
    ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MediatorNameEn", mediatorNameEn);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public static bool IsMediatorExistByArabicName(string mediatorNameAr)
        {
            string query = @"
        SELECT COUNT(1) FROM Mediators 
        WHERE mediator_name_ar = @MediatorNameAr
    ";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MediatorNameAr", mediatorNameAr);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
