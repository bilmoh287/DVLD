using System;
using System.Data;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsDriverVehicle
    {
        public int OwnershipID { get; set; }
        public int DriverID { get; set; }
        public int VehicleID { get; set; }
        public string PlateNumber { get; set; }
        public string VIN { get; set; }
        public string Color { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public int CreatedByUserID { get; set; }

        public clsDriverVehicle()
        {
            this.OwnershipID = -1;
            this.DriverID = -1;
            this.VehicleID = -1;
            this.PlateNumber = "";
            this.VIN = "";
            this.Color = "";
            this.PurchaseDate = DateTime.Now;
            this.SaleDate = null;
            this.PurchasePrice = 0;
            this.CreatedByUserID = -1;
        }

        public bool Save()
        {
            this.OwnershipID = clsDriverVehicleData.AddNewOwnership(
                this.DriverID,
                this.VehicleID,
                this.PlateNumber,
                this.VIN,
                this.Color,
                this.PurchaseDate,
                this.PurchasePrice,
                this.CreatedByUserID
            );
            return (this.OwnershipID != -1);
        }

        public static DataTable GetDriverHistory(int DriverID)
        {
            return clsDriverVehicleData.GetDriverVehicleHistory(DriverID);
        }

        public static DataTable GetVehiclesCatalog()
        {
            return clsDriverVehicleData.GetAllVehiclesCatalog();
        }
    }
}
