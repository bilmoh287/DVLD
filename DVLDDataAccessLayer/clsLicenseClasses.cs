using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsLicenseClassesData
    {
        public static DataTable GetAllLicenseClassesList()
        {
            DataTable dtLicenseClasses = new DataTable();

            string query = "SELECT * FROM LicenseClasses;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dtLicenseClasses.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading License Classes: " + ex.Message);
                }
            }

            return dtLicenseClasses;
        }

        public static bool GetLicenseClassInfoByID(int LicenseClassID, ref string ClassName, ref string ClassDescription,
            ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            ClassName = (string)reader["ClassName"];
                            ClassDescription = (string)reader["ClassDescription"];
                            MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]);
                            DefaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]);
                            ClassFees = Convert.ToDecimal(reader["ClassFees"]);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error loading License Class Info: " + ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static bool GetLicenseClassInfoByName(string ClassName, ref int LicenseClassID, ref string ClassDescription,
            ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassName", ClassName);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            LicenseClassID = (int)reader["LicenseClassID"];
                            ClassDescription = (string)reader["ClassDescription"];
                            MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]);
                            DefaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]);
                            ClassFees = Convert.ToDecimal(reader["ClassFees"]);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error loading License Class Info: " + ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static int AddNewLicenseClass(string ClassName, string ClassDescription, byte MinimumAllowedAge,
            byte DefaultValidityLength, decimal ClassFees)
        {
            int newID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO LicenseClasses (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                                 VALUES (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassName", ClassName);
                    command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@ClassFees", ClassFees);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                            newID = Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error adding License Class: " + ex.Message);
                    }
                }
            }

            return newID;
        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE LicenseClasses
                                 SET ClassName = @ClassName,
                                     ClassDescription = @ClassDescription,
                                     MinimumAllowedAge = @MinimumAllowedAge,
                                     DefaultValidityLength = @DefaultValidityLength,
                                     ClassFees = @ClassFees
                                 WHERE LicenseClassID = @LicenseClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@ClassName", ClassName);
                    command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@ClassFees", ClassFees);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error updating License Class: " + ex.Message);
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "DELETE FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error deleting License Class: " + ex.Message);
                    }
                }
            }

            return (rowsAffected > 0);
        }
    }
}
