using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsDriverVehicleData
    {
        public static DataTable GetDriverVehicleHistory(int DriverID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    // Cross-database query joining Driver history with the Vehicle catalog
                    string query = @"
                        SELECT 
                            DV.OwnershipID,
                            DV.PlateNumber,
                            DV.VIN,
                            DV.Color,
                            VM.Make,
                            VM.ModelName,
                            VM.Year,
                            VM.Vehicle_Display_Name,
                            DV.PurchaseDate,
                            DV.SaleDate,
                            DV.PurchasePrice,
                            Status = CASE WHEN DV.SaleDate IS NULL THEN 'Currently Owned' ELSE 'Sold' END
                        FROM My_DVLD.dbo.DriverVehicles DV
                        INNER JOIN VehicleMakesDB.dbo.VehicleMasterDetails VM ON DV.VehicleID = VM.ID
                        WHERE DV.DriverID = @DriverID
                        ORDER BY DV.PurchaseDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriverID", DriverID);
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

        public static DataTable GetAllVehiclesCatalog()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = "SELECT ID, Vehicle_Display_Name, Year, Make, ModelName FROM VehicleMakesDB.dbo.VehicleMasterDetails ORDER BY Vehicle_Display_Name";
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

        public static int AddNewOwnership(int DriverID, int VehicleID, string PlateNumber, string VIN, string Color, DateTime PurchaseDate, decimal PurchasePrice, int CreatedByUserID)
        {
            int OwnershipID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = @"
                        INSERT INTO DriverVehicles (DriverID, VehicleID, PlateNumber, VIN, Color, PurchaseDate, PurchasePrice, CreatedByUserID)
                        VALUES (@DriverID, @VehicleID, @PlateNumber, @VIN, @Color, @PurchaseDate, @PurchasePrice, @CreatedByUserID);
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
                        command.Parameters.AddWithValue("@VIN", (object)VIN ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Color", (object)Color ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
                        command.Parameters.AddWithValue("@PurchasePrice", PurchasePrice);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            OwnershipID = id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return OwnershipID;
        }
    }
}
