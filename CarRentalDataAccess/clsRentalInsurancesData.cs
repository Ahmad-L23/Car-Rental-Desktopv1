using CarRentalBusiness;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDataAccess
{
    public class clsRentalInsurancesData
    {

        private readonly static string  conn= ClsDataAccessSettings.ConnectionString;
        


        public static int AddNewRentalInsurance(string name, int PaymentId, double price, string status, bool Active, bool IncludeTax, string Notes)
        {
            int newId = -1;


            string query = @"insert into RentalInsurances (name, PaymentMethodId, price, status, isActice, IncludeTax, notes)
                             values(@name, @PaymentMethodId, @price, @status, @Active, @includetax, @Notes);
                              select cast (scope_identity() as int);";

            using(SqlConnection connection = new SqlConnection(conn))
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@PaymentMethodId", PaymentId);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@status", (object)status?? DBNull.Value);
                command.Parameters.AddWithValue("@Active", Active);
                command.Parameters.AddWithValue("@includetax", IncludeTax);
                command.Parameters.AddWithValue("@Notes", (object)Notes?? DBNull.Value);

                connection.Open();

                object resutl = command.ExecuteScalar();

                if(resutl != null && int.TryParse(resutl.ToString(), out newId))
                    return newId;

                return -1;
            }
                   
        }



        public static bool UpdateRentalInsurance(int id, string name, int paymentMethodId, double price, string status, bool Active, bool Includetax, string Notes)
        {
            string Query = @"update RentalInsurances 
                              set name = @name,paymentMethodId = @paymentMethodId, price = @price, status = @status, isActice = @Active, Includetax = @includetax, Notes = @notes where RentalinsuranceId = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@paymentMethodId", paymentMethodId);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@status", (object)status ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Active", Active);
                    command.Parameters.AddWithValue("@Includetax", Includetax);
                    command.Parameters.AddWithValue("@Notes", (object)Notes??DBNull.Value);

                    connection.Open();

                    int rows = command.ExecuteNonQuery();

                    return rows > 0;
                }
            }
            catch
            {
                return false;
            }
        }


        public static bool DeleteRentalInsuracne(int rentalInsuracneId)
        {
            

            try
            {
                string query = @"Delete from RentalInsurances where RentalinsuranceId = @rentalInsuracneId";

                using (SqlConnection connection = new SqlConnection(conn))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@rentalInsuracneId", rentalInsuracneId);
                    connection.Open();

                    int rows = command.ExecuteNonQuery();

                    return rows > 0;
                }
            }

            catch
            {
                return false;
            }
        }


       


        public static DataTable GetAllRentalInsuracne()
        {
            string query = @"select ri.RentalinsuranceId, ri.name, ri.price, ri.status, ri.isActice, ri.includetax, ri.notes, pm.MethodName
                            from RentalInsurances ri join PaymentMethods pm on ri.PaymentMethodId = pm.Id";

            try
            {

                using (SqlConnection connection = new SqlConnection(conn))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter ada = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    return dt;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
        }


        public static bool FindRentalInsuranceById(int id, ref string name, ref int PaymentMethod, ref double price, ref string status, ref bool isActive, ref bool IncludeTax, ref string notes)
        {
            string query = @"select * from RentalInsurances where RentalinsuranceId = @id";

            using( SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        name = reader["Name"].ToString();
                        PaymentMethod = Convert.ToInt32(reader["PaymentMethodId"]);
                        price = Convert.ToDouble(reader["price"]);
                        status = reader["status"].ToString();
                        isActive = Convert.ToBoolean(reader["isActice"]);
                        IncludeTax = Convert.ToBoolean(reader["includetax"]);
                        notes = reader["notes"].ToString();
                        return true;
                    }
                }
            }
            return false;
        }


        public static DataTable GetAllRentalInsurance()
        {
            string query = @"select ri.* pm.MethodName from RentalInsurances ri
                              join PaymentMethods pm on ri.PaymentMethodId = pm.Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
