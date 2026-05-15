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

            // Core Modules
            ViewPeople = 1,
            ManageUsers = 2,
            ManageApplications = 4,
            ManageTests = 8,
            IssueLicense = 16,
            ManageDetainedLicenses = 32,
            ManageInstitutes = 64,

            InstituteInstructor = 128,

            FullAccess = 255
        }

        public static List<string> GetAllRoles()
        {
            // If using enum
            return Enum.GetNames(typeof(enPermissions)).ToList();

            // If using DB table, fetch from DAL instead
            // return clsRolesDAL.GetAllRoles();
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
