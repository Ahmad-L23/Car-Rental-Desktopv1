using CarRentalDataAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace CarRentalBusiness
{
    public enum enCategoryMode
    {
        New,
        Updated
    }

    public class ClsCategory
    {
        public int? CategoryID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Image { get; set; }

        public enCategoryMode State { get; set; } = enCategoryMode.New;

        // Default constructor
        public ClsCategory() { }

        // Parameterized constructor
        public ClsCategory(int? categoryId, string nameEn, string nameAr, string image)
        {
            CategoryID = categoryId;
            NameEn = nameEn;
            NameAr = nameAr;
            Image = image;

            State = (categoryId == null || categoryId == 0) ? enCategoryMode.New : enCategoryMode.Updated;
        }

        // Add new category
        private bool AddCategory()
        {
            int newId = ClsCategoryData.AddNewCategory(NameEn, NameAr, Image);
            if (newId > 0)
            {
                CategoryID = newId;
                return true;
            }
            return false;
        }

        // Update existing category
        private bool UpdateCategory()
        {
            if (CategoryID == null) return false;
            return ClsCategoryData.EditCategory(CategoryID.Value, NameEn, NameAr, Image);
        }

        // Unified Save method based on entity state
        public bool Save()
        {
            if (State == enCategoryMode.New)
            {
                var success = AddCategory();
                if (success)
                    State = enCategoryMode.Updated;
                return success;
            }
            else if (State == enCategoryMode.Updated)
            {
                return UpdateCategory();
            }
            else
            {
                throw new InvalidOperationException("Unknown entity state.");
            }
        }

        // Delete category by ID
        public static bool DeleteCategory(int Id)
        {
            return ClsCategoryData.DeleteCategory(Id);
        }

        // Load category from DB and populate this instance
        public bool LoadByID(int id)
        {
            string nameEn = null, nameAr = null, image = null;
            bool found = ClsCategoryData.GetCategoryInfoById(id, ref nameEn, ref nameAr, ref image);
            if (!found) return false;

            CategoryID = id;
            NameEn = nameEn;
            NameAr = nameAr;
            Image = image;

            State = enCategoryMode.Updated;
            return true;
        }

        // Get all categories as list of objects
        public static DataTable GetAllCategories()
        {
            return ClsCategoryData.GetAllCategories();
            
        }

        // Find category by ID (returns null if not found)
        public static ClsCategory FindById(int id)
        {
            string nameEn = null, nameAr = null, image = null;

            bool found = ClsCategoryData.GetCategoryInfoById(id, ref nameEn, ref nameAr, ref image);
            if (!found)
                return null;

            return new ClsCategory(id, nameEn, nameAr, image)
            {
                State = enCategoryMode.Updated
            };
        }
    }
}
