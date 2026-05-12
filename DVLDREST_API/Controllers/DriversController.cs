using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DVLDBussinessLayer;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        // GET /api/drivers
        [HttpGet]
        public IActionResult GetAllDrivers()
        {
            DataTable dt = clsDrivers.GetAllDrivers();
            var drivers = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                drivers.Add(new
                {
                    DriverID = (int)row["DriverID"],
                    PersonID = (int)row["PersonID"],
                    NationalNo = row["NationalNo"].ToString(),
                    FullName = row["FullName"].ToString(),
                    CreatedDate = (DateTime)row["CreatedDate"],
                    ActiveLicenses = (int)row["NumberOfActiveLicenses"]
                });
            }

            return Ok(drivers);
        }

        // GET /api/drivers/{driverId}
        [HttpGet("{driverId}")]
        public IActionResult GetDriverById(int driverId)
        {
            clsDrivers driver = clsDrivers.Find(driverId);
            if (driver == null) return NotFound("Driver not found.");

            return Ok(new
            {
                driver.DriverID,
                driver.PersonID,
                FullName = driver.PersonInfo.FullName,
                NationalNo = driver.PersonInfo.NationalNo,
                driver.CreatedDate
            });
        }

        // GET /api/drivers/person/{personId}
        [HttpGet("person/{personId}")]
        public IActionResult GetDriverByPersonId(int personId)
        {
            clsDrivers driver = clsDrivers.FindByPersonID(personId);
            if (driver == null) return NotFound("Driver not found for this person.");

            return Ok(new
            {
                driver.DriverID,
                driver.PersonID,
                FullName = driver.PersonInfo.FullName,
                NationalNo = driver.PersonInfo.NationalNo,
                driver.CreatedDate
            });
        }

        // GET /api/drivers/history/{personId}
        [HttpGet("history/{personId}")]
        public IActionResult GetDriverHistory(int personId)
        {
            var history = new List<object>();

            // 1. Get Licenses
            DataTable dtLicenses = clsLicenses.GetPersonLicenses(personId);
            foreach (DataRow row in dtLicenses.Rows)
            {
                history.Add(new
                {
                    Type = "License " + ((bool)row["IsActive"] ? "Active" : "Inactive"),
                    Details = (string)row["ClassName"] + " (LIC# " + row["LicenseID"] + ")",
                    Date = (DateTime)row["IssueDate"],
                    Branch = "DVLD Main Office",
                    Category = "license"
                });
            }

            // 2. Get LDL Applications (The main ones)
            DataTable dtLDL = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLiceseApplications();
            // Note: In the view, the person ID column might be called "ApplicantPersonID" or we can filter by NationalNo if we had it.
            // However, usually the view has "NationalNo" or "FullName". 
            // Since we know the personId, we can get the person info to get the NationalNo if needed.
            clsPerson person = clsPerson.Find(personId);
            string nationalNo = person?.NationalNo ?? "";

            foreach (DataRow row in dtLDL.Rows)
            {
                // We check for NationalNo or ApplicationID linked to this person
                // In many DVLD views, "NationalNo" is the unique identifier used.
                bool isMatch = false;
                if (dtLDL.Columns.Contains("NationalNo") && row["NationalNo"].ToString() == nationalNo)
                {
                    isMatch = true;
                }
                else if (dtLDL.Columns.Contains("PersonID") && (int)row["PersonID"] == personId)
                {
                    isMatch = true;
                }

                if (isMatch)
                {
                    history.Add(new
                    {
                        Type = "Application " + row["Status"],
                        Details = row["ClassName"] + " — " + row["LocalDrivingLicenseApplicationID"],
                        Date = (DateTime)row["ApplicationDate"],
                        Branch = "Online Portal",
                        Category = "application"
                    });

                    // 3. Get Tests for this LDL application
                    int ldlAppId = (int)row["LocalDrivingLicenseApplicationID"];
                    DataTable dtTests = clsTests.GetTestHistoryByLDLAppID(ldlAppId);
                    foreach (DataRow testRow in dtTests.Rows)
                    {
                        history.Add(new
                        {
                            Type = testRow["TestTypeTitle"].ToString() + " " + ((bool)testRow["TestResult"] ? "Passed" : "Failed"),
                            Details = testRow["Notes"].ToString(),
                            Date = (DateTime)testRow["AppointmentDate"],
                            Branch = "Exam Center",
                            Category = "exam"
                        });
                    }
                }
            }

            // Sort by date descending
            var sortedHistory = history.OrderByDescending(h => ((dynamic)h).Date).ToList();

            return Ok(sortedHistory);
        }
    }
}
