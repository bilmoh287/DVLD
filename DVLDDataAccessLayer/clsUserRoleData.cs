using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsUserRoleData
    {
        public static DataTable GetRolesByUserID(int UserID)
        {
            DataTable dt = new DataTable();

            string query = @"SELECT R.RoleID, R.RoleName, R.PermissionsMask
                             FROM UserRoles UR
                             INNER JOIN Roles R ON UR.RoleID = R.RoleID
                             WHERE UR.UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    dt.Load(command.ExecuteReader());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading user roles: " + ex.Message);
                }
            }

            return dt;
        }

        public static bool AssignRoleToUser(int UserID, int RoleID)
        {
            int rowsAffected = 0;

            string query = @"INSERT INTO UserRoles (UserID, RoleID)
                             VALUES (@UserID, @RoleID)";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@RoleID", RoleID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error assigning role: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }

        public static bool RemoveUserRoles(int UserID)
        {
            int rowsAffected = 0;

            string query = @"DELETE FROM UserRoles WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error removing roles: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }
    }
}
