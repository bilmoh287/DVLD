using System.Data;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsKPI
    {
        public static DataTable GetUnifiedRevenueReport()
        {
            return clsKPIData.GetUnifiedRevenueReport();
        }

        public static decimal GetSchoolRevenue(int InstituteID)
        {
            return clsKPIData.GetSchoolRevenue(InstituteID);
        }

        public static int GetTotalPeople()
        {
            return clsKPIData.GetTotalPeople();
        }

        public static int GetTotalMales()
        {
            return clsKPIData.GetTotalMales();
        }

        public static int GetTotalFemales()
        {
            return clsKPIData.GetTotalFemales();
        }

        public static int GetTotalApplicants()
        {
            return clsKPIData.GetTotalApplicants();
        }

        public static int GetTotalDrivers()
        {
            return clsKPIData.GetTotalDrivers();
        }

        public static int GetTotalUsers()
        {
            return clsKPIData.GetTotalUsers();
        }

        public static int GetActiveLicensesCount()
        {
            return clsKPIData.GetActiveLicensesCount();
        }

        public static int GetActiveApplicationsCount()
        {
            return clsKPIData.GetActiveApplicationsCount();
        }

        public static decimal GetGlobalTestPassRate()
        {
            return clsKPIData.GetGlobalTestPassRate();
        }

        public static decimal GetMonthToDateRevenue()
        {
            return clsKPIData.GetMonthToDateRevenue();
        }

        public static decimal GetAllTimeRevenue()
        {
            return clsKPIData.GetAllTimeRevenue();
        }

        public static int GetActiveDriversCount()
        {
            return clsKPIData.GetActiveDriversCount();
        }

        public static int GetCurrentlyOwnedVehiclesCount()
        {
            return clsKPIData.GetCurrentlyOwnedVehiclesCount();
        }

        public static int GetSoldVehiclesCount()
        {
            return clsKPIData.GetSoldVehiclesCount();
        }

        public static decimal GetTotalValueOwnedVehicles()
        {
            return clsKPIData.GetTotalValueOwnedVehicles();
        }

        public static DataTable GetTopVehicleMakes()
        {
            return clsKPIData.GetTopVehicleMakes();
        }

        public static int GetLicenseRenewalsCount()
        {
            return clsKPIData.GetLicenseRenewalsCount();
        }

        public static int GetLicenseReplacementsCount()
        {
            return clsKPIData.GetLicenseReplacementsCount();
        }

        public static int GetInternationalLicensesCount()
        {
            return clsKPIData.GetInternationalLicensesCount();
        }

        public static decimal GetTestPassRateByType(int testTypeID)
        {
            return clsKPIData.GetTestPassRateByType(testTypeID);
        }

        public static int GetActiveDrivingInstitutesCount()
        {
            return clsKPIData.GetActiveDrivingInstitutesCount();
        }

        public static int GetActiveStudentEnrollmentsCount()
        {
            return clsKPIData.GetActiveStudentEnrollmentsCount();
        }

        public static int GetActiveTrainingBatchesCount()
        {
            return clsKPIData.GetActiveTrainingBatchesCount();
        }

        public static int GetCurrentlyDetainedLicensesCount()
        {
            return clsKPIData.GetCurrentlyDetainedLicensesCount();
        }

        public static int GetReleasedLicensesCount()
        {
            return clsKPIData.GetReleasedLicensesCount();
        }

        public static decimal GetTotalFinesCollected()
        {
            return clsKPIData.GetTotalFinesCollected();
        }

        public static decimal GetOutstandingFinesAmount()
        {
            return clsKPIData.GetOutstandingFinesAmount();
        }
    }
}

