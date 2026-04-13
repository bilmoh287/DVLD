using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsRole
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int PermissionsMask { get; set; }
        public string Description { get; set; }

        public clsRole()
        {
            RoleID = -1;
            RoleName = "";
            PermissionsMask = 0;
            Description = "";
            Mode = enMode.AddNew;
        }

        private clsRole(int RoleID, string RoleName, int PermissionsMask, string Description)
        {
            this.RoleID = RoleID;
            this.RoleName = RoleName;
            this.PermissionsMask = PermissionsMask;
            this.Description = Description;
            Mode = enMode.Update;
        }

        public static clsRole Find(int RoleID)
        {
            string RoleName = "";
            int PermissionsMask = 0;
            string Description = "";

            if (clsRoleData.GetRoleByID(RoleID, ref RoleName, ref PermissionsMask, ref Description))
            {
                return new clsRole(RoleID, RoleName, PermissionsMask, Description);
            }
            return null;
        }

        private bool _AddNew()
        {
            this.RoleID = clsRoleData.AddNewRole(RoleName, PermissionsMask, Description);
            return (this.RoleID != -1);
        }

        private bool _Update()
        {
            return clsRoleData.UpdateRole(RoleID, RoleName, PermissionsMask, Description);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static DataTable GetAllRoles()
        {
            return clsRoleData.GetAllRoles();
        }

        public static bool DeleteRole(int RoleID)
        {
            return clsRoleData.DeleteRole(RoleID);
        }
    }
        
}
