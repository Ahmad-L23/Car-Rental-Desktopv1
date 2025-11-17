using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsCurrency
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public ClsCurrency()
        {
            Id = null;
            NameEn = "";
            NameAr = "";
            mode = enMode.AddNew;
        }

        public ClsCurrency(int? id, string nameEn, string nameAr)
        {
            Id = id;
            NameEn = nameEn;
            NameAr = nameAr;
            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;

            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewCurrency();
                    break;
                case enMode.Update:
                    result = UpdateCurrency();
                    break;
            }

            return result;
        }

        private bool AddNewCurrency()
        {
            int newId = ClsCurrencyData.AddNewCurrency(NameEn, NameAr);

            if (newId != -1)
            {
                Id = newId;
                mode = enMode.Update;
                return true;
            }

            return false;
        }

        private bool UpdateCurrency()
        {
            if (!Id.HasValue)
                return false;

            return ClsCurrencyData.EditCurrency(Id.Value, NameEn, NameAr);
        }

        public static bool DeleteCurrency(int currencyId)
        {
            return ClsCurrencyData.DeleteCurrency(currencyId);
        }

        public static ClsCurrency FindById(int id)
        {
            string nameEn = "";
            string nameAr = "";

            bool found = ClsCurrencyData.GetCurrencyInfoById(id, ref nameEn, ref nameAr);

            if (!found)
                return null;

            return new ClsCurrency(id, nameEn, nameAr);
        }

        public static DataTable GetCurrenciesDataTable()
        {
            return ClsCurrencyData.GetAllCurrencies();
        }

        public static bool CurrencyExistsByEnglishName(string nameEn)
        {
            return ClsCurrencyData.CurrencyExistsByEnglishName(nameEn);
        }

        public static bool CurrencyExistsByArabicName(string nameAr)
        {
            return ClsCurrencyData.CurrencyExistsByArabicName(nameAr);
        }
    }
}
