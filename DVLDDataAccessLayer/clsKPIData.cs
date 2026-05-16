using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsKPIData
    {
        public static DataTable GetUnifiedRevenueReport()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = @"
                        SELECT 'Applications' AS RevenueSource, SUM(PaidFees) AS TotalRevenue FROM Applications
                        UNION ALL
                        SELECT 'Tests' AS RevenueSource, SUM(PaidFees) AS TotalRevenue FROM TestAppointments
                        UNION ALL
                        SELECT 'Licenses' AS RevenueSource, SUM(PaidFees) AS TotalRevenue FROM Licenses
                        UNION ALL
                        SELECT 'Fines' AS RevenueSource, SUM(FineFees) AS TotalRevenue FROM DetainedLicenses";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }

        public static decimal GetSchoolRevenue(int InstituteID)
        {
            decimal totalRevenue = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = "SELECT ISNULL(SUM(AmountPaid), 0) FROM InstitutePayments WHERE InstituteID = @InstituteID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InstituteID", InstituteID);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && decimal.TryParse(result.ToString(), out decimal rev))
                        {
                            totalRevenue = rev;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return totalRevenue;
        }
    }
}
