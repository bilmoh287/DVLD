using DVLDDataAccessLayer.DTOs;
using DVLDBussinessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            DataTable dt = clsCountries.GetAllCountriesList();
            List<CountryDTO> countries = new List<CountryDTO>();

            foreach (DataRow row in dt.Rows)
            {
                countries.Add(new CountryDTO(
                    (int)row["CountryID"],
                    (string)row["CountryName"]
                ));
            }

            // Sort by name for better UI experience
            return Ok(countries.OrderBy(c => c.CountryName).ToList());
        }
    }
}
