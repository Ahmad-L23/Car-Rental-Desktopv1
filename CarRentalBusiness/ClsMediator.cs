using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsMediator
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Email { get; set; }
        public double Precentage { get; set; }
        public string PhoneNumber { get; set; }
        public bool isActive { get; set; }
        public string StatusText { get; private set; } // for status text like Active/Inactive

        public ClsMediator()
        {
            this.id = null;
            this.ArabicName = "";
            this.EnglishName = "";
            this.Email = string.Empty;
            this.Precentage = 0.0;
            this.PhoneNumber = string.Empty;
            this.isActive = false;
            this.StatusText = "";
            this.mode = enMode.AddNew;
        }

        public ClsMediator(int? id, string arabicName, string englishName, string email, double precentage, string phoneNumber, bool isActive)
        {
            this.id = id;
            ArabicName = arabicName;
            EnglishName = englishName;
            Email = email;
            Precentage = precentage;
            PhoneNumber = phoneNumber;
            this.isActive = isActive;
            this.StatusText = isActive ? "Active" : "Inactive";
            this.mode = enMode.Update;
        }

        private bool _AddNewMediator()
        {
            int newId = ClsMediatorData.AddNewMediator(this.ArabicName, this.EnglishName, this.Email, this.Precentage, this.PhoneNumber, this.isActive);
            if (newId != -1)
            {
                this.id = newId;
                this.StatusText = this.isActive ? "Active" : "Inactive";
                return true;
            }
            return false;
        }

        private bool _UpdateMediator()
        {
            bool result = ClsMediatorData.EditMediator(this.id, this.ArabicName, this.EnglishName, this.Email, this.Precentage, this.PhoneNumber, this.isActive);
            if (result)
            {
                this.StatusText = this.isActive ? "Active" : "Inactive";
            }
            return result;
        }

        public bool Save()
        {
            switch (this.mode)
            {
                case enMode.AddNew:
                    return _AddNewMediator();

                case enMode.Update:
                    return _UpdateMediator();

                default:
                    return false;
            }
        }

        public static bool DeleteMediator(int id)
        {
            return ClsMediatorData.DeleteMediator(id);
        }

        public static DataTable GetAllMediators()
        {
            return ClsMediatorData.GetAllMediators();
        }

        public static bool isMedaitorExist(int id)
        {
            return ClsMediatorData.IsMediatorExist(id);
        }

        public static bool IsMediatorExistByEnglishName(string englishName)
        {
            return ClsMediatorData.IsMediatorExistByEnglishName(englishName);
        }

        public static bool IsMediatorExistByArabicName(string arabicName)
        {
            return ClsMediatorData.IsMediatorExistByArabicName(arabicName);
        }


        // === Integrated new methods with internal variables, no ref params for public API ===

        public static bool GetMediatorInfoById(int mediatorId, out ClsMediator mediator)
        {
            mediator = null;

            string mediatorEnName = "";
            string mediatorArName = "";
            string email = null;
            double percentage = 0.0;
            string phoneNumber = "";
            bool isActive = false;
            string statusText = "";

            bool found = ClsMediatorData.GetMediatorInfoById(mediatorId,
                ref mediatorEnName,
                ref mediatorArName,
                ref email,
                ref percentage,
                ref phoneNumber,
                ref isActive,
                ref statusText);

            if (!found)
                return false;

            mediator = new ClsMediator(mediatorId, mediatorArName, mediatorEnName, email, percentage, phoneNumber, isActive);
            mediator.StatusText = statusText;

            return true;
        }

        public static bool GetMediatorInfoByName(string englishName, string arabicName, out ClsMediator mediator)
        {
            mediator = null;

            int? mediatorId = null;  // Added id variable
            string mediatorEnName = englishName;
            string mediatorArName = arabicName;
            string email = null;
            double percentage = 0.0;
            string phoneNumber = "";
            bool isActive = false;
            string statusText = "";

            bool found = ClsMediatorData.GetMediatorInfoByName(ref mediatorId,   // <-- added here
                ref mediatorEnName,
                ref mediatorArName,
                ref email,
                ref percentage,
                ref phoneNumber,
                ref isActive,
                ref statusText);

            if (!found)
                return false;

            mediator = new ClsMediator(mediatorId, mediatorArName, mediatorEnName, email, percentage, phoneNumber, isActive);
            mediator.StatusText = statusText;

            return true;
        }


    }
}
