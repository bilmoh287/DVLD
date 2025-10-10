using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsCountries
    {
        public static DataTable GetAllCountriesList()
        {
            return clsCountriesData.GetAllCountriesList();
        }
    }
}
