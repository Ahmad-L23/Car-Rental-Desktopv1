using CarRentalDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusiness
{
    public class clsCashReceipt
    {
        enum enMode { add, update}

        public int id {  get; set; }
        public int CashREceiptNumber {  get; set; }
        public DateTime CashReceiptDate {  get; set; }
        public int paymentMethodid {  get; set; }
        public ClsPaymentMethod PaymentMethod {  get; set; }
        public int boxid { get; set; }
        public ClsBox box { get; set; }       
        public int Currencyid {  get; set; }
        ClsCurrency currency { get; set; }
        public double ExchangePrice {  get; set; }
        public double Amount { get; set; }
        public string Description {  get; set; }

        enMode mode = enMode.add;


        public clsCashReceipt()
        {
            id = 0;
            CashREceiptNumber = 0;
            CashReceiptDate = DateTime.Now;
            paymentMethodid = 0;
            boxid = 0;
            Currencyid = 0;
            ExchangePrice = 0;
            Amount = 0;
            Description = null;
            mode = enMode.add;
        }


        public clsCashReceipt(int id, int cashREceiptNumber, DateTime cashReceiptDate, int paymentMethodid, int boxid, int currencyid, double exchangePrice, double amount, string description)
        {
            this.id = id;
            CashREceiptNumber = cashREceiptNumber;
            CashReceiptDate = cashReceiptDate;
            this.paymentMethodid = paymentMethodid;
            PaymentMethod = ClsPaymentMethod.FindById(paymentMethodid);
            this.boxid = boxid;
            box = ClsBox.Find(boxid);
            Currencyid = currencyid;
            currency = ClsCurrency.FindById(currencyid);
            ExchangePrice = exchangePrice;
            Amount = amount;
            Description = description;
            this.mode = enMode.update;
        }


        private bool _AddNew()
        {
            id = clsCachReceiptData.AddNewCashReceipt(CashREceiptNumber, CashReceiptDate, paymentMethodid, boxid, Currencyid, ExchangePrice, Amount, Description);

            if(id == -1)
                return false;

            mode = enMode.update;
            return true;
        }


        private bool _UpdateCashReceipt()
        {
            if(id == 0)
                return false;

            return clsCachReceiptData.UpdateCashReceipt(id, CashREceiptNumber, CashReceiptDate, paymentMethodid, boxid, Currencyid, ExchangePrice, Amount, Description); 
        }


        public bool Save()
        {
            switch(mode)
            {
                case enMode.add:
                    return _AddNew();

                case enMode.update:
                   return _UpdateCashReceipt();
            }
            return false;
        }

        public static clsCashReceipt findCashReceipt(int id)
        {
            int cashReceiptNubmer = 0, PaymentMethodid = 0, Boxid = 0, Currencyid = 0;
            DateTime CashReceDate= DateTime.Now;
            double ExchangePrice = 0, Amount = 0;
            string description = null;

            clsCachReceiptData.findCashReceiptById(id, ref cashReceiptNubmer, ref CashReceDate, ref PaymentMethodid, ref Boxid, ref Currencyid, ref ExchangePrice, ref Amount, ref description);

            return new clsCashReceipt(id, cashReceiptNubmer, CashReceDate, PaymentMethodid, Boxid, Currencyid, ExchangePrice, Amount, description);
        }



        public static int GetLastNumber()
        {
            return clsCachReceiptData.GetLastSerialNumber();
        }



    }
}
