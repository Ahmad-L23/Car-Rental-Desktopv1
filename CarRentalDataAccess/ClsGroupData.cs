using CarRentalBusiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalDataAccess
{
    public static class ClsGroupData
    {
        private static readonly string conn = ClsDataAccessSettings.ConnectionString;

        public static int AddNewGroup(string name, string image)
        {
            string query = @"
                INSERT INTO Groups (name, image)
                VALUES (@Name, @Image);
                SELECT CAST(scope_identity() AS int);";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Image", (object)image ?? DBNull.Value);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;

                return -1;
            }
        }

        public static bool EditGroup(int groupId, string name, string image)
        {
            string query = @"
                UPDATE Groups SET
                    name = @Name,
                    image = @Image
                WHERE GroupId = @GroupId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@GroupId", groupId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Image", (object)image ?? DBNull.Value);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool DeleteGroup(int groupId)
        {
            string query = "DELETE FROM Groups WHERE GroupId = @GroupId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@GroupId", groupId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public static bool IsGroupExist(int groupId)
        {
            string query = "SELECT COUNT(1) FROM Groups WHERE GroupId = @GroupId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@GroupId", groupId);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        public static DataTable GetAllGroups()
        {
            string query = "SELECT * FROM Groups";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool GetGroupInfoById(int groupId, ref string name, ref string image)
        {
            string query = "SELECT * FROM Groups WHERE GroupID = @GroupId";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@GroupID", groupId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader["name"]?.ToString();
                        image = reader["image"]?.ToString();

                        return true;
                    }
                }
            }
            return false;
        }

        public static bool GroupExistsByName(string name)
        {
            string query = "SELECT COUNT(1) FROM Groups WHERE name = @Name";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);

                connection.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && Convert.ToInt32(result) > 0);
            }
        }
    }
}
