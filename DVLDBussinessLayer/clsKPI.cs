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
    }
}
