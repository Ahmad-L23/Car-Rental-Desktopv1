using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsColor
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? Id { get; set; }
        public string ColorName { get; set; }
        public string ColorHex { get; set; }

        public ClsColor()
        {
            Id = null;
            ColorName = null;
            ColorHex = null;
            mode = enMode.AddNew;
        }

        public ClsColor(int id, string colorName, string colorHex)
        {
            Id = id;
            ColorName = colorName;
            ColorHex = colorHex;
            mode = enMode.Update;
        }

        /// <summary>
        /// Save color to database (insert or update depending on mode)
        /// </summary>
        /// <returns>True if success, otherwise false</returns>
        public bool Save()
        {
            bool result = false;

            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewColor();
                    break;

                case enMode.Update:
                    result = UpdateColor();
                    break;
            }

            return result;
        }

        private bool AddNewColor()
        {
            int newId = ClsColorData.AddNewColor(ColorName, ColorHex);

            if (newId != -1)
            {
                Id = newId;
                mode = enMode.Update; // switch mode since now it exists
                return true;
            }

            return false;
        }

        private bool UpdateColor()
        {
            if (!Id.HasValue)
                return false;

            return ClsColorData.EditColor(Id.Value, ColorName, ColorHex);
        }

        public static bool DeleteColor(int id)
        {
            return ClsColorData.DeleteColor(id);
        }

        public static ClsColor FindById(int id)
        {
            string colorName = null;
            string colorHex = null;

            bool found = ClsColorData.GetColorById(id, ref colorName, ref colorHex);

            if (!found)
                return null;

            return new ClsColor(id, colorName, colorHex);
        }

        public static DataTable GetAllColors()
        {
            return ClsColorData.GetAllColors();
        }

        public static bool ColorExistsByName(string colorName)
        {
            return ClsColorData.ColorExistsByName(colorName);
        }
    }
}
