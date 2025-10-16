using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsCountriesData
    {
        public static DataTable GetAllCountriesList()
        {
            DataTable dtCountries = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = @"SELECT * FROM Countries;";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtCountries.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }

            return dtCountries;
        }

        public static string FindCountryByID(int CountryID)
        {
            string CountryName = "";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"SELECT CountryName FROM Countries WHERE CountryID = @CountryID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@CountryID", CountryID);

                    try
                    {
                        connection.Open();
                        object res = command.ExecuteScalar();
                        CountryName = (res != null) ? res.ToString() : "";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return CountryName;
        }
    }
}

