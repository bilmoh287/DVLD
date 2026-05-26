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
                    // Cross-database query joining Driver history with base Vehicle tables (not the heavy view)
                    string query = @"
                        SELECT 
                            DV.OwnershipID,
                            DV.PlateNumber,
                            DV.VIN,
                            DV.Color,
                            M.Make,
                            MM.ModelName,
                            VD.Year,
                            VD.Vehicle_Display_Name,
                            DV.PurchaseDate,
                            DV.SaleDate,
                            DV.PurchasePrice,
                            Status = CASE WHEN DV.SaleDate IS NULL THEN 'Currently Owned' ELSE 'Sold' END
                        FROM My_DVLD.dbo.DriverVehicles DV
                        INNER LOOP JOIN VehicleMakesDB.dbo.VehicleDetails VD ON DV.VehicleID = VD.ID
                        INNER LOOP JOIN VehicleMakesDB.dbo.Makes M ON VD.MakeID = M.MakeID
                        INNER LOOP JOIN VehicleMakesDB.dbo.MakeModels MM ON VD.ModelID = MM.ModelID
                        WHERE DV.DriverID = @DriverID
                        ORDER BY DV.PurchaseDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandTimeout = 30;
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
                string connString = clsDataAccessSetting.ConnectionString.Replace("Database=My_DVLD", "Database=VehicleMakesDB");
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    // Query base tables directly in local VehicleMakesDB context
                    string query = @"
                        SELECT TOP 100 VD.ID, VD.Vehicle_Display_Name, VD.Year, M.Make, MM.ModelName 
                        FROM VehicleDetails VD
                        INNER JOIN Makes M ON VD.MakeID = M.MakeID
                        INNER JOIN MakeModels MM ON VD.ModelID = MM.ModelID
                        ORDER BY VD.ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandTimeout = 30;
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

        public static DataTable GetVehiclesCatalog(string search, int limit)
        {
            DataTable dt = new DataTable();
            try
            {
                string connString = clsDataAccessSetting.ConnectionString.Replace("Database=My_DVLD", "Database=VehicleMakesDB");
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    string query;
                    if (string.IsNullOrWhiteSpace(search))
                    {
                        query = @"
                            SELECT TOP (@Limit) VD.ID, VD.Vehicle_Display_Name, VD.Year, M.Make, MM.ModelName 
                            FROM VehicleDetails VD
                            INNER JOIN Makes M ON VD.MakeID = M.MakeID
                            INNER JOIN MakeModels MM ON VD.ModelID = MM.ModelID
                            ORDER BY VD.ID";
                    }
                    else
                    {
                        query = @"
                            SELECT TOP (@Limit) VD.ID, VD.Vehicle_Display_Name, VD.Year, M.Make, MM.ModelName 
                            FROM VehicleDetails VD
                            INNER JOIN Makes M ON VD.MakeID = M.MakeID
                            INNER JOIN MakeModels MM ON VD.ModelID = MM.ModelID
                            WHERE (VD.Vehicle_Display_Name LIKE '%' + @Search + '%' OR M.Make LIKE '%' + @Search + '%')
                            ORDER BY VD.ID";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandTimeout = 30;
                        command.Parameters.AddWithValue("@Limit", limit);
                        if (!string.IsNullOrWhiteSpace(search))
                        {
                            command.Parameters.AddWithValue("@Search", search);
                        }
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

        public static DataTable GetVehiclesCatalog(string filterColumn, string search, int limit)
        {
            DataTable dt = new DataTable();
            try
            {
                string connString = clsDataAccessSetting.ConnectionString.Replace("Database=My_DVLD", "Database=VehicleMakesDB");
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    string query;
                    if (string.IsNullOrWhiteSpace(search) || string.IsNullOrWhiteSpace(filterColumn) || filterColumn == "None")
                    {
                        query = @"
                            SELECT TOP (@Limit) VD.ID, VD.Vehicle_Display_Name, VD.Year, M.Make, MM.ModelName 
                            FROM VehicleDetails VD
                            INNER JOIN Makes M ON VD.MakeID = M.MakeID
                            INNER JOIN MakeModels MM ON VD.ModelID = MM.ModelID
                            ORDER BY VD.ID";
                    }
                    else
                    {
                        string whereClause = "";
                        if (filterColumn == "Vehicle ID" || filterColumn == "ID")
                        {
                            if (int.TryParse(search, out _))
                                whereClause = "WHERE VD.ID = @Search";
                            else
                                return dt;
                        }
                        else if (filterColumn == "Make")
                        {
                            whereClause = "WHERE M.Make LIKE @Search + '%'";
                        }
                        else if (filterColumn == "Model")
                        {
                            whereClause = "WHERE VD.Vehicle_Display_Name LIKE '%' + @Search + '%'";
                        }
                        else
                        {
                            whereClause = "WHERE (VD.Vehicle_Display_Name LIKE '%' + @Search + '%' OR M.Make LIKE '%' + @Search + '%')";
                        }

                        query = $@"
                            SELECT TOP (@Limit) VD.ID, VD.Vehicle_Display_Name, VD.Year, M.Make, MM.ModelName 
                            FROM VehicleDetails VD
                            INNER JOIN Makes M ON VD.MakeID = M.MakeID
                            INNER JOIN MakeModels MM ON VD.ModelID = MM.ModelID
                            {whereClause}
                            ORDER BY VD.ID";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandTimeout = 30;
                        command.Parameters.AddWithValue("@Limit", limit);
                        if (!string.IsNullOrWhiteSpace(search) && filterColumn != "None")
                        {
                            command.Parameters.AddWithValue("@Search", search);
                        }
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

        public static bool ReleaseVehicle(int OwnershipID, DateTime SaleDate)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = @"
                        UPDATE DriverVehicles 
                        SET SaleDate = @SaleDate
                        WHERE OwnershipID = @OwnershipID AND SaleDate IS NULL";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleDate", SaleDate);
                        command.Parameters.AddWithValue("@OwnershipID", OwnershipID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return (rowsAffected > 0);
        }
    }
}
