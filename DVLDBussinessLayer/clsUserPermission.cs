using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsUserPermission
    {
        [Flags]
        public enum enPermissions
        {
            None = 0,
            View = 1,
            Add = 2,
            Edit = 4,
            Delete = 8,
            IssueLicense = 16,
            ManageUsers = 32,
            FullAccess = 127
        }

        public static int GetUserPermissions(int UserID)
        {
            int permissions = 0;

            DataTable dtRoles = clsUserRoleData.GetRolesByUserID(UserID);

            foreach (DataRow row in dtRoles.Rows)
            {
                permissions |= Convert.ToInt32(row["PermissionsMask"]);
            }

            return permissions;
        }

        public static bool HasPermission(int UserPermissions, enPermissions Permission)
        {
            return (UserPermissions & (int)Permission) == (int)Permission;
        }
    }
}
