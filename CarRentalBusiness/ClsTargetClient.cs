using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsTargetClient
    {
        private enum enMode { AddNew, Update }
        private enMode _mode = enMode.AddNew;

        public int? TargetClientId { get; set; }
        public string TargetClientName { get; set; }

        public ClsTargetClient()
        {
            TargetClientId = null;
            TargetClientName = "";
            _mode = enMode.AddNew;
        }

        public ClsTargetClient(int? id, string name)
        {
            TargetClientId = id;
            TargetClientName = name;
            _mode = enMode.Update;
        }

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.AddNew:
                    int newId = ClsTargetClientsData.AddNewTargetClient(TargetClientName);
                    if (newId != -1)
                    {
                        TargetClientId = newId;
                        _mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    if (!TargetClientId.HasValue)
                        return false;

                    return ClsTargetClientsData.UpdateTargetClient(TargetClientId.Value, TargetClientName);
            }

            return false;
        }

        public static bool Delete(int id)
        {
            return ClsTargetClientsData.DeleteTargetClient(id);
        }

        public static ClsTargetClient FindById(int id)
        {
            string name = "";
            bool found = ClsTargetClientsData.GetTargetClientById(id, ref name);

            if (!found)
                return null;

            return new ClsTargetClient(id, name);
        }

        public static DataTable GetAll()
        {
            return ClsTargetClientsData.GetAllTargetClients();
        }

        public static bool ExistsByName(string name)
        {
            return ClsTargetClientsData.IsTargetClientExist(name);
        }

        public static bool ExistsById(int id)
        {
            return ClsTargetClientsData.IsTargetClientExist(id);
        }
    }
}
