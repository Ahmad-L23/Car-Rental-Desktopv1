using CarRentalDataAccess;
using System;
using System.Data;

namespace CarRentalBusiness
{
    public class ClsGroup
    {
        private enum enMode { AddNew, Update }

        private enMode mode = enMode.AddNew;

        public int? GroupId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ClsGroup()
        {
            GroupId = null;
            Name = "";
            Image = null;
            mode = enMode.AddNew;
        }

        public ClsGroup(int? groupId, string name, string image)
        {
            GroupId = groupId;
            Name = name;
            Image = image;
            mode = enMode.Update;
        }

        public bool Save()
        {
            bool result = false;
            switch (mode)
            {
                case enMode.AddNew:
                    result = AddNewGroup();
                    break;
                case enMode.Update:
                    result = UpdateGroup();
                    break;
            }
            return result;
        }

        private bool AddNewGroup()
        {
            int id = ClsGroupData.AddNewGroup(Name, Image);
            if (id != -1)
            {
                GroupId = id;
                return true;
            }
            return false;
        }

        private bool UpdateGroup()
        {
            if (!GroupId.HasValue)
                return false;

            return ClsGroupData.EditGroup(GroupId.Value, Name, Image);
        }

        public static bool DeleteGroup(int groupId)
        {
            return ClsGroupData.DeleteGroup(groupId);
        }

        public static ClsGroup FindById(int groupId)
        {
            string name = "";
            string image = null;

            bool found = ClsGroupData.GetGroupInfoById(groupId, ref name, ref image);

            if (!found)
                return null;

            return new ClsGroup(groupId, name, image);
        }

        public static DataTable GetGroupsDataTable()
        {
            return ClsGroupData.GetAllGroups();
        }

        public static bool GroupExistsByName(string name)
        {
            return ClsGroupData.GroupExistsByName(name);
        }
    }
}
