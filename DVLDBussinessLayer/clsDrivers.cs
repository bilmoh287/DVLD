using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsDrivers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDrivers()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        private clsDrivers(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            Mode = enMode.Update;
        }

        public static clsDrivers Find(int driverID)
        {
            int personID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDriversData.GetDriverInfoByID(
                driverID,
                ref personID,
                ref createdByUserID,
                ref createdDate))
            {
                return new clsDrivers(driverID, personID, createdByUserID, createdDate);
            }

            return null;
        }

        public static clsDrivers FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDriversData.GetDriverInfoByPersonID(
                PersonID,
                ref DriverID,
                ref createdByUserID,
                ref createdDate))
            {
                return new clsDrivers(DriverID, PersonID, createdByUserID, createdDate);
            }

            return null;
        }

        private bool _AddNewDriver()
        {
            DriverID = clsDriversData.AddNewDriver(
                PersonID,
                CreatedByUserID,
                CreatedDate);

            return (DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriversData.UpdateDriver(
                DriverID,
                PersonID,
                CreatedByUserID,
                CreatedDate);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDriver();

                default:
                    return false;
            }
        }

        public static bool Delete(int driverID)
        {
            return clsDriversData.DeleteDriver(driverID);
        }

        public static bool Exists(int driverID)
        {
            return clsDriversData.IsDriverExist(driverID);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();
        }
    }
}
