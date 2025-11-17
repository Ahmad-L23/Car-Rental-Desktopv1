using System.Data;
using CarRentalDataAccessLayer;

namespace CarRentalBusiness
{
    public class ClsNationlity
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        // Parameterless constructor
        public ClsNationlity()
        {
            Id = 0;
            NameEn = string.Empty;
            NameAr = string.Empty;
        }

        // Parameterized constructor
        public ClsNationlity(int id, string nameEn, string nameAr)
        {
            Id = id;
            NameEn = nameEn;
            NameAr = nameAr;
        }

        // Return nationalities directly as DataTable (calls DAL method)
        public static DataTable GetAllNationalities()
        {
            return clsNationalitiesData.GetAllNationalities();
        }

        public static ClsNationlity GetNationalityInfoById(int id)
        {
            int nationalityId = 0;
            string nameEn = string.Empty;
            string nameAr = string.Empty;

            bool found = clsNationalitiesData.GetNationalityById(id, ref nationalityId, ref nameEn, ref nameAr);

            if (!found)
                return null;

            return new ClsNationlity(nationalityId, nameEn, nameAr);
        }
    }
}
