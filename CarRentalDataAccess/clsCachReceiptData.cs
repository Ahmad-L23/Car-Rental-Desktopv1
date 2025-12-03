using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDataAccess
{
    public class clsCachReceiptData
    {

        private static string Conne = ClsDataAccessSettings.ConnectionString;


        public static int AddNewCashReceipt(int CashReceiptNubmer, DateTime CRDate, int PaymentMethodId, int BoxId, int CurrencyId, double ExchangePrice, double Amount, string Description)
        {

            string query = @"insert into cashReceipts(cashReceiptNumber, cashReceiptDate, PaymentMethodid, boxid, CurrencyId, ExchangePrice, Amount, Description)
                              values(@CashReceiptNubmer, @CRDate, @PaymentMethodId, @BoxId, @CurrencyId, @ExchangePrice, @Amount, @Descrition);
                               select cast(scope_identuty() as int)";

            using(SqlConnection con = new SqlConnection(Conne))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@CashReceiptNubmer", CashReceiptNubmer);
                cmd.Parameters.AddWithValue("@CRDate", CRDate);
                cmd.Parameters.AddWithValue("@PaymentMethodId", PaymentMethodId);
                cmd.Parameters.AddWithValue("@BoxId", BoxId);
                cmd.Parameters.AddWithValue("@CurrencyId", CurrencyId);
                cmd.Parameters.AddWithValue("@ExchangePrice", ExchangePrice);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@Descrition", (object)Description?? DBNull.Value);

                con.Open();

                var result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;


                return -1;
            }

        }


        public static bool UpdateCashReceipt(int cashReceiptid, int CashReceiptNubmer, DateTime CRDate, int PaymentMethodId, int BoxId, int CurrencyId, double ExchangePrice, double Amount, string Description)
        {
            
            string query = @"update cashReceipts set cashReceiptNumber= @CashReceiptNubmer, cashReceiptDate= @CRDate, PaymentMethodid = @PaymentMethodId, boxid = @BoxId, 
                                                                        CurrencyId = @CurrencyId, ExchangePrice = @ExchangePrice, Amount = @Amount, Description = @Description where cashReceiptId = @cashReceiptid";
            try
            {
                using (SqlConnection con = new SqlConnection(Conne))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@CashReceiptNubmer", CashReceiptNubmer);
                    cmd.Parameters.AddWithValue(" @CRDate", CRDate);
                    cmd.Parameters.AddWithValue("@BoxId", BoxId);
                    cmd.Parameters.AddWithValue("@CurrencyId", CurrencyId);
                    cmd.Parameters.AddWithValue("@ExchangePrice", ExchangePrice);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@Description", (object)Description?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cashReceiptid", cashReceiptid);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool findCashReceiptById(int id, ref int CashReceiptNumber, ref DateTime CrDate, ref int paymentid, ref int BoxId, ref int Currencyid, ref double ExchangePrice, ref double Amount, ref string Desciortion)
        {
            string query = @"select * from cashReceipts where cashReceiptId = @id";

            try
            {
                using (SqlConnection con = new SqlConnection(Conne))
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["cashReceiptId"]);
                            CashReceiptNumber = Convert.ToInt32(reader["cashReceiptNumber"]);
                            CrDate = Convert.ToDateTime(reader["cashReceiptDate"]);
                            paymentid = Convert.ToInt32(reader["PaymentMethodid"]);
                            BoxId = Convert.ToInt32(reader["boxid"]);
                            Currencyid = Convert.ToInt32(reader["CurrencyId"]);
                            ExchangePrice = Convert.ToDouble(reader["ExchangePrice"]);
                            Amount = Convert.ToDouble(reader["Amount"]);
                            Desciortion = reader["Description"]?.ToString();

                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static int GetLastSerialNumber()
        {
            string query = "SELECT ISNULL(MAX(cashReceiptNumber), 0) FROM Agreement";

            using (SqlConnection connection = new SqlConnection(Conne))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int serial))
                    return serial;
                return 0;
            }
        }
    }

}
