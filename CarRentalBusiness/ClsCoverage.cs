using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsCoverage
    {
        private enum enMode { AddNew, Update }
        private enMode _mode = enMode.AddNew;

        public int? CoverageId { get; set; }
        public string CoverageName { get; set; }

        public ClsCoverage()
        {
            CoverageId = null;
            CoverageName = "";
            _mode = enMode.AddNew;
        }

        public ClsCoverage(int? coverageId, string coverageName)
        {
            CoverageId = coverageId;
            CoverageName = coverageName;
            _mode = enMode.Update;
        }

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.AddNew:
                    int newId = ClsCoverageData.AddNewCoverage(CoverageName);
                    if (newId != -1)
                    {
                        CoverageId = newId;
                        _mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    if (!CoverageId.HasValue)
                        return false;

                    return ClsCoverageData.UpdateCoverage(CoverageId.Value, CoverageName);
            }

            return false;
        }

        public static bool Delete(int coverageId)
        {
            return ClsCoverageData.DeleteCoverage(coverageId);
        }

        public static ClsCoverage FindById(int coverageId)
        {
            string name = "";
            bool found = ClsCoverageData.GetCoverageById(coverageId, ref name);

            if (!found)
                return null;

            return new ClsCoverage(coverageId, name);
        }

        public static DataTable GetAll()
        {
            return ClsCoverageData.GetAllCoverage();
        }

        public static bool ExistsByName(string name)
        {
            return ClsCoverageData.IsCoverageExist(name);
        }
    }
}
