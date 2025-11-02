using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsTestTypesData
    {
        public static DataTable GetAllTestTypesList()
        {
            DataTable dtTestTypes = new DataTable();

            string query = "SELECT * FROM TestTypes;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dtTestTypes.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading TestTypes: " + ex.Message);
                }
            }

            return dtTestTypes;
        }

        public static bool GetTestTypeByID(
            int TestTypeID,
            ref string TestTypeTitle,
            ref string TestTypeDescription,
            ref decimal TestTypeFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            TestTypeTitle = reader["TestTypeTitle"].ToString();
                            TestTypeDescription = reader["TestTypeDescription"].ToString();
                            TestTypeFees = Convert.ToDecimal(reader["TestTypeFees"]);
                            isFound = true;
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error reading TestType: " + ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static int AddNewTestType(string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            int newID = -1;

            string query = @"
                INSERT INTO TestTypes (TestTypeTitle, TestTypeDescription, TestTypeFees)
                VALUES (@TestTypeTitle, @TestTypeDescription, @TestTypeFees);
                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        newID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding TestType: " + ex.Message);
                }
            }

            return newID;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            bool isUpdated = false;

            string query = @"
                UPDATE TestTypes
                SET 
                    TestTypeTitle = @TestTypeTitle,
                    TestTypeDescription = @TestTypeDescription,
                    TestTypeFees = @TestTypeFees
                WHERE TestTypeID = @TestTypeID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

                try
                {
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    isUpdated = rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating TestType: " + ex.Message);
                }
            }

            return isUpdated;
        }

        public static bool DeleteTestType(int TestTypeID)
        {
            bool isDeleted = false;

            string query = "DELETE FROM TestTypes WHERE TestTypeID = @TestTypeID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    isDeleted = rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting TestType: " + ex.Message);
                }
            }

            return isDeleted;
        }
    }
}
