using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsRoleData
    {
        public static DataTable GetAllRoles()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT RoleID, RoleName, PermissionsMask, Description FROM Roles";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    dt.Load(command.ExecuteReader());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading roles: " + ex.Message);
                }
            }
            return dt;
        }

        public static bool GetRoleByID(int RoleID, ref string RoleName, ref int PermissionsMask, ref string Description)
        {
            bool isFound = false;
            string query = @"SELECT * FROM Roles WHERE RoleID = @RoleID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleID", RoleID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        RoleName = (string)reader["RoleName"];
                        PermissionsMask = (int)reader["PermissionsMask"];
                        Description = reader["Description"]?.ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading role: " + ex.Message);
                }
            }

            return isFound;
        }

        public static int AddNewRole(string RoleName, int PermissionsMask, string Description)
        {
            int newID = -1;

            string query = @"INSERT INTO Roles (RoleName, PermissionsMask, Description)
                             VALUES (@RoleName, @PermissionsMask, @Description);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleName", RoleName);
                command.Parameters.AddWithValue("@PermissionsMask", PermissionsMask);
                command.Parameters.AddWithValue("@Description", (object)Description ?? DBNull.Value);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                        newID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding role: " + ex.Message);
                }
            }

            return newID;
        }

        public static bool UpdateRole(int RoleID, string RoleName, int PermissionsMask, string Description)
        {
            int rowsAffected = 0;

            string query = @"UPDATE Roles
                             SET RoleName = @RoleName,
                                 PermissionsMask = @PermissionsMask,
                                 Description = @Description
                             WHERE RoleID = @RoleID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@RoleName", RoleName);
                command.Parameters.AddWithValue("@PermissionsMask", PermissionsMask);
                command.Parameters.AddWithValue("@Description", (object)Description ?? DBNull.Value);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating role: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteRole(int RoleID)
        {
            int rowsAffected = 0;

            string query = @"DELETE FROM Roles WHERE RoleID = @RoleID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleID", RoleID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting role: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }
    }
}
