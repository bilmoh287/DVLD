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

        private static int _ExecuteScalarCountQuery(string query)
        {
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int res))
                        {
                            count = res;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return count;
        }

        public static int GetTotalPeople()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM People");
        }

        public static int GetTotalMales()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM People WHERE Gender = 0");
        }

        public static int GetTotalFemales()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM People WHERE Gender = 1");
        }

        public static int GetTotalApplicants()
        {
            // Usually, an applicant is anyone in the Applications table
            return _ExecuteScalarCountQuery("SELECT COUNT(DISTINCT ApplicantPersonID) FROM Applications");
        }

        public static int GetTotalDrivers()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM Drivers");
        }

        public static int GetTotalUsers()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM Users");
        }

        private static decimal _ExecuteScalarDecimalQuery(string query)
        {
            decimal value = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && decimal.TryParse(result.ToString(), out decimal res))
                        {
                            value = res;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return value;
        }

        public static int GetActiveLicensesCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM Licenses WHERE IsActive = 1");
        }

        public static int GetActiveApplicationsCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM Applications WHERE ApplicationStatus = 1 OR ApplicationStatus = 4");
        }

        public static decimal GetGlobalTestPassRate()
        {
            return _ExecuteScalarDecimalQuery("SELECT COALESCE(CAST((SUM(CASE WHEN TestResult = 1 THEN 1 ELSE 0 END) * 100.0) / NULLIF(COUNT(*), 0) AS DECIMAL(5,2)), 0) FROM Tests");
        }

        public static decimal GetMonthToDateRevenue()
        {
            return _ExecuteScalarDecimalQuery("SELECT ISNULL(SUM(PaidFees), 0) FROM Applications WHERE MONTH(ApplicationDate) = MONTH(GETDATE()) AND YEAR(ApplicationDate) = YEAR(GETDATE())");
        }

        public static decimal GetAllTimeRevenue()
        {
            return _ExecuteScalarDecimalQuery("SELECT ISNULL(SUM(PaidFees), 0) FROM Applications");
        }

        public static int GetActiveDriversCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(DISTINCT DriverID) FROM Licenses WHERE IsActive = 1");
        }

        public static int GetCurrentlyOwnedVehiclesCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM DriverVehicles WHERE SaleDate IS NULL");
        }

        public static int GetSoldVehiclesCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM DriverVehicles WHERE SaleDate IS NOT NULL");
        }

        public static decimal GetTotalValueOwnedVehicles()
        {
            return _ExecuteScalarDecimalQuery("SELECT ISNULL(SUM(PurchasePrice), 0) FROM DriverVehicles WHERE SaleDate IS NULL");
        }

        public static DataTable GetTopVehicleMakes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = @"
                        SELECT TOP 3 
                            VM.Make, 
                            COUNT(*) AS VehicleCount
                        FROM My_DVLD.dbo.DriverVehicles DV
                        INNER JOIN VehicleMakesDB.dbo.VehicleMasterDetails VM ON DV.VehicleID = VM.ID
                        WHERE DV.SaleDate IS NULL
                        GROUP BY VM.Make
                        ORDER BY VehicleCount DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
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

        public static int GetLicenseRenewalsCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM Applications WHERE ApplicationTypeID = 2 AND ApplicationStatus = 3");
        }

        public static int GetLicenseReplacementsCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM Applications WHERE ApplicationTypeID IN (3, 4) AND ApplicationStatus = 3");
        }

        public static int GetInternationalLicensesCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM InternationalLicenses");
        }

        public static decimal GetTestPassRateByType(int testTypeID)
        {
            decimal rate = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = @"
                        SELECT COALESCE(CAST((SUM(CASE WHEN T.TestResult = 1 THEN 1 ELSE 0 END) * 100.0) / NULLIF(COUNT(*), 0) AS DECIMAL(5,2)), 0) 
                        FROM Tests T 
                        INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                        WHERE TA.TestTypeID = @TestTypeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && decimal.TryParse(result.ToString(), out decimal res))
                        {
                            rate = res;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return rate;
        }

        public static int GetActiveDrivingInstitutesCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM DrivingInstitutes WHERE IsActive = 1");
        }

        public static int GetActiveStudentEnrollmentsCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM Enrollments WHERE IsActive = 1");
        }

        public static int GetActiveTrainingBatchesCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM TrainingBatches WHERE EndDate >= GETDATE()");
        }

        public static int GetCurrentlyDetainedLicensesCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM DetainedLicenses WHERE IsReleased = 0");
        }

        public static int GetReleasedLicensesCount()
        {
            return _ExecuteScalarCountQuery("SELECT COUNT(*) FROM DetainedLicenses WHERE IsReleased = 1");
        }

        public static decimal GetTotalFinesCollected()
        {
            return _ExecuteScalarDecimalQuery("SELECT ISNULL(SUM(FineFees), 0) FROM DetainedLicenses WHERE IsReleased = 1");
        }

        public static decimal GetOutstandingFinesAmount()
        {
            return _ExecuteScalarDecimalQuery("SELECT ISNULL(SUM(FineFees), 0) FROM DetainedLicenses WHERE IsReleased = 0");
        }
    }
}

