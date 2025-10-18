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
        public int CountryID { set; get; }
        public string CountryName { set; get; }

        public clsCountries()
        {
            CountryID = -1;
            CountryName = string.Empty;
        }

        private clsCountries(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public static DataTable GetAllCountriesList()
        {
            return clsCountriesData.GetAllCountriesList();
        }

        public static clsCountries FindCountry(int CountryID)
        {
            string CountryName = "";
            return (clsCountriesData.GetCountryInfoByID(CountryID, ref CountryName) ? new clsCountries(CountryID, CountryName) : null);
        }

        public static clsCountries FindCountry(string CountryName)
        {
            int CountryID = -1;
            return (clsCountriesData.GetCountryInfoByName(CountryName, ref CountryID) ? new clsCountries(CountryID, CountryName) : null);
        }
    }
}
