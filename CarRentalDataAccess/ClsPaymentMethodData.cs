using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsPaymentMethodData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        // ✅ Add new payment method
        public static int AddNewPaymentMethod(string methodName)
        {
            string query = @"
                INSERT INTO PaymentMethods (MethodName)
                VALUES (@MethodName);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@MethodName", methodName);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        // ✅ Edit payment method
        public static bool EditPaymentMethod(int id, string methodName)
        {
            string query = @"
                UPDATE PaymentMethods
                SET MethodName = @MethodName
                WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@MethodName", methodName);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // ✅ Delete payment method
        public static bool DeletePaymentMethod(int id)
        {
            string query = "DELETE FROM PaymentMethods WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // ✅ Check if payment method exists by name
        public static bool IsPaymentMethodExist(string methodName)
        {
            string query = "SELECT COUNT(1) FROM PaymentMethods WHERE MethodName = @MethodName";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@MethodName", methodName);

                connection.Open();
                object result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        // ✅ Get all payment methods
        public static DataTable GetAllPaymentMethods()
        {
            string query = "SELECT * FROM PaymentMethods ORDER BY MethodName";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // ✅ Get payment method info by Id
        public static bool GetPaymentMethodById(int id, ref string methodName)
        {
            string query = "SELECT MethodName FROM PaymentMethods WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        methodName = reader["MethodName"].ToString();
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
