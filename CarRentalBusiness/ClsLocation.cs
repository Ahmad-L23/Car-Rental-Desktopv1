using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsLocation
    {
        private enum enMode { AddNew, Update }
        private enMode mode = enMode.AddNew;

        public int? LocationId { get; set; }
        public int BranchId { get; set; }
        public string LocationName { get; set; }
        public string BranchName { get; private set; }  // read-only, populated when loading from DB

        public ClsLocation()
        {
            LocationId = null;
            BranchId = 0;
            LocationName = "";
            BranchName = "";
            mode = enMode.AddNew;
        }

        public ClsLocation(int locationId, int branchId, string locationName, string branchName = "")
        {
            LocationId = locationId;
            BranchId = branchId;
            LocationName = locationName;
            BranchName = branchName;
            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;
            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewLocation();
                    break;
                case enMode.Update:
                    result = UpdateLocation();
                    break;
            }
            return result;
        }

        private bool AddNewLocation()
        {
            int id = ClsLocationData.AddNewLocation(BranchId, LocationName);
            if (id != -1)
            {
                LocationId = id;
                mode = enMode.Update;
                return true;
            }
            return false;
        }

        private bool UpdateLocation()
        {
            if (!LocationId.HasValue)
                return false;

            return ClsLocationData.EditLocation(LocationId.Value, BranchId, LocationName);
        }

        public static bool DeleteLocation(int locationId)
        {
            return ClsLocationData.DeleteLocation(locationId);
        }

        public static ClsLocation FindById(int locationId)
        {
            int branchId = 0;
            string locationName = "";
            bool found = ClsLocationData.GetLocationInfoById(locationId, ref branchId, ref locationName);
            if (!found)
                return null;

            // Optionally, get BranchName from BranchData if needed (not shown here)
            string branchName = "";

            return new ClsLocation(locationId, branchId, locationName, branchName);
        }

        public static DataTable GetLocationsDataTable()
        {
            return ClsLocationData.GetAllLocations();
        }
    }
}
