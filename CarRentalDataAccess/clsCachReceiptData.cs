using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDataAccess
{
    public class clsCachReceiptData
    {

        private static string Conne = ClsDataAccessSettings.ConnectionString;


        public static int AddNewCashReceipt(int CashReceiptNubmer, DateTime CRDate, int PaymentMethodId, int BoxId, int CurrencyId, decimal ExchangePrice, decimal Amount, string Description)
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
                cmd.Parameters.AddWithValue("@Descrition", Description);

                con.Open();

                var result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int newId))
                    return newId;


                return -1;
            }

        }
    }
}
