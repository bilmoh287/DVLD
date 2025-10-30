using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsApplicationTypesData
    {
        public static DataTable GetAllApplicationTypesList()
        {
            DataTable dtApplications = new DataTable();
            string Query = "SELECT * FROM ApplicationTypes;";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dtApplications.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dtApplications;
        }

        public static bool GetApplicationTypeByID(int ApplicationTypeID, ref string ApplicationTitle, ref decimal Fee)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        if (Reader.Read())
                        {
                            ApplicationTitle = (string)Reader["ApplicationTypeTitle"];
                            Fee = Convert.ToDecimal(Reader["ApplicationFees"]);
                            IsFound = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                    }
                }
            }

            return IsFound;
        }


        public static bool UpdateApplicationFees(int ApplicationTypeID, decimal ApplicationFees)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"
                                UPDATE [dbo].[ApplicationTypes]
                                SET ApplicationFees = @ApplicationFees                              
                                WHERE ApplicationTypeID = @ApplicationTypeID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

                    try
                    {
                        connection.Open();
                        int rows = command.ExecuteNonQuery();
                        isUpdated = rows > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isUpdated;
        }
    }
}
