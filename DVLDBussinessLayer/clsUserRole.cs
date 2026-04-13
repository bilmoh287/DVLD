using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsUserRole
    {
        public static DataTable GetRolesByUserID(int UserID)
        {
            return clsUserRoleData.GetRolesByUserID(UserID);
        }

        public static bool AssignRole(int UserID, int RoleID)
        {
            return clsUserRoleData.AssignRoleToUser(UserID, RoleID);
        }

        public static bool ResetUserRoles(int UserID)
        {
            return clsUserRoleData.RemoveUserRoles(UserID);
        }
    }
}
