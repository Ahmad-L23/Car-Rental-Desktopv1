using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsPaymentMethod
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? Id { get; set; }
        public string MethodName { get; set; }

        public ClsPaymentMethod()
        {
            Id = null;
            MethodName = "";
            mode = enMode.AddNew;
        }

        public ClsPaymentMethod(int? id, string methodName)
        {
            Id = id;
            MethodName = methodName;
            mode = enMode.Update;
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    return AddNewPaymentMethod();
                case enMode.Update:
                    return UpdatePaymentMethod();
                default:
                    return false;
            }
        }

        private bool AddNewPaymentMethod()
        {
            int newId = ClsPaymentMethodData.AddNewPaymentMethod(MethodName);
            if (newId != -1)
            {
                Id = newId;
                mode = enMode.Update;
                return true;
            }
            return false;
        }

        private bool UpdatePaymentMethod()
        {
            if (!Id.HasValue)
                return false;

            return ClsPaymentMethodData.EditPaymentMethod(Id.Value, MethodName);
        }

        public static bool DeletePaymentMethod(int id)
        {
            return ClsPaymentMethodData.DeletePaymentMethod(id);
        }

        public static ClsPaymentMethod FindById(int id)
        {
            string methodName = "";

            bool found = ClsPaymentMethodData.GetPaymentMethodById(id, ref methodName);
            if (!found)
                return null;

            return new ClsPaymentMethod(id, methodName);
        }

        public static bool IsPaymentMethodExist(string methodName)
        {
            return ClsPaymentMethodData.IsPaymentMethodExist(methodName);
        }

        public static DataTable GetAllPaymentMethods()
        {
            return ClsPaymentMethodData.GetAllPaymentMethods();
        }
    }
}
