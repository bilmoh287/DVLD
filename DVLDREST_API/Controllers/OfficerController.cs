using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DVLDBussinessLayer;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfficerController : ControllerBase
    {
        // GET /api/officer/driver-history
        [HttpGet("driver-history")]
        public IActionResult GetCombinedDriverHistory(
            [FromQuery] string nationalNo = null,
            [FromQuery] int? licenseId = null,
            [FromQuery] int? personId = null,
            [FromQuery] int? driverId = null)
        {
            clsPerson person = null;

            // 1. Resolve Person
            if (personId.HasValue)
            {
                person = clsPerson.Find(personId.Value);
            }
            else if (!string.IsNullOrEmpty(nationalNo))
            {
                person = clsPerson.Find(nationalNo);
            }
            else if (licenseId.HasValue)
            {
                clsLicenses license = clsLicenses.Find(licenseId.Value);
                if (license != null)
                {
                    clsDrivers driver = clsDrivers.Find(license.DriverID);
                    if (driver != null)
                    {
                        person = clsPerson.Find(driver.PersonID);
                    }
                }
            }
            else if (driverId.HasValue)
            {
                clsDrivers driver = clsDrivers.Find(driverId.Value);
                if (driver != null)
                {
                    person = clsPerson.Find(driver.PersonID);
                }
            }

            if (person == null)
            {
                return NotFound("No driver or person record could be resolved with the provided identifiers.");
            }

            // 2. Resolve Driver ID
            clsDrivers resolvedDriver = clsDrivers.FindByPersonID(person.PersonID);
            int resolvedDriverId = resolvedDriver?.DriverID ?? -1;

            // 3. Fetch License History
            var licensesList = new List<object>();
            DataTable dtLicenses = clsLicenses.GetPersonLicenses(person.PersonID);
            foreach (DataRow row in dtLicenses.Rows)
            {
                int licId = (int)row["LicenseID"];
                bool isDetained = clsDetainedLicenses.IsLicenseDetained(licId);
                licensesList.Add(new
                {
                    LicenseID = licId,
                    ApplicationID = (int)row["ApplicationID"],
                    ClassName = row["ClassName"].ToString(),
                    IssueDate = (DateTime)row["IssueDate"],
                    ExpirationDate = (DateTime)row["ExpirationDate"],
                    IsActive = (bool)row["IsActive"],
                    IsDetained = isDetained
                });
            }

            // 4. Fetch Applications & Exam History
            var applicationsList = new List<object>();
            var examsList = new List<object>();

            DataTable dtLDL = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLiceseApplications();
            foreach (DataRow row in dtLDL.Rows)
            {
                bool isMatch = false;
                if (dtLDL.Columns.Contains("NationalNo") && row["NationalNo"].ToString() == person.NationalNo)
                {
                    isMatch = true;
                }
                else if (dtLDL.Columns.Contains("PersonID") && (int)row["PersonID"] == person.PersonID)
                {
                    isMatch = true;
                }

                if (isMatch)
                {
                    int ldlAppId = (int)row["LocalDrivingLicenseApplicationID"];
                    applicationsList.Add(new
                    {
                        LocalDrivingLicenseApplicationID = ldlAppId,
                        ClassName = row["ClassName"].ToString(),
                        ApplicationDate = (DateTime)row["ApplicationDate"],
                        PaidFees = (decimal)row["PaidFees"],
                        PassedTests = (int)row["PassedChecks"], // Preserved typo/column mapping
                        Status = row["Status"].ToString()
                    });

                    // Fetch Tests
                    DataTable dtTests = clsTests.GetTestHistoryByLDLAppID(ldlAppId);
                    foreach (DataRow testRow in dtTests.Rows)
                    {
                        examsList.Add(new
                        {
                            LocalDrivingLicenseApplicationID = ldlAppId,
                            TestTypeTitle = testRow["TestTypeTitle"].ToString(),
                            TestResult = (bool)testRow["TestResult"],
                            Notes = testRow["Notes"].ToString(),
                            AppointmentDate = (DateTime)testRow["AppointmentDate"]
                        });
                    }
                }
            }

            // 5. Fetch Vehicle History
            var vehiclesList = new List<object>();
            if (resolvedDriverId != -1)
            {
                DataTable dtVehicles = clsDriverVehicle.GetDriverHistory(resolvedDriverId);
                foreach (DataRow row in dtVehicles.Rows)
                {
                    vehiclesList.Add(new
                    {
                        OwnershipID = (int)row["OwnershipID"],
                        PlateNumber = row["PlateNumber"].ToString(),
                        VIN = row["VIN"].ToString(),
                        Color = row["Color"].ToString(),
                        Make = row["Make"].ToString(),
                        ModelName = row["ModelName"].ToString(),
                        Year = (int)row["Year"],
                        VehicleDisplayName = row["Vehicle_Display_Name"].ToString(),
                        PurchaseDate = (DateTime)row["PurchaseDate"],
                        SaleDate = row["SaleDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["SaleDate"],
                        PurchasePrice = (decimal)row["PurchasePrice"],
                        Status = row["Status"].ToString()
                    });
                }
            }

            // 6. Fetch Detainment History (tied to person's licenses)
            var detainmentsList = new List<object>();
            foreach (var lic in licensesList)
            {
                int licId = ((dynamic)lic).LicenseID;
                clsDetainedLicenses detainInfo = clsDetainedLicenses.FindByLicenseID(licId);
                if (detainInfo != null)
                {
                    detainmentsList.Add(new
                    {
                        detainInfo.DetainID,
                        detainInfo.LicenseID,
                        ClassName = ((dynamic)lic).ClassName,
                        detainInfo.DetainDate,
                        detainInfo.FineFees,
                        detainInfo.IsReleased,
                        detainInfo.ReleaseDate,
                        detainInfo.ReleaseApplicationID,
                        detainInfo.DetainReason,
                        detainInfo.DetainPlace
                    });
                }
            }

            // Combine into one payload
            var response = new
            {
                Person = new
                {
                    person.PersonID,
                    person.NationalNo,
                    person.FullName,
                    person.Gender,
                    person.DateOfBirth,
                    person.Phone,
                    person.Email,
                    person.Address,
                    NationalityCountry = person.CountryInfo?.CountryName ?? "Unknown",
                    person.ImagePath,
                    DriverID = resolvedDriverId
                },
                Licenses = licensesList,
                Applications = applicationsList,
                Exams = examsList,
                Vehicles = vehiclesList,
                Detainments = detainmentsList
            };

            return Ok(response);
        }

        // GET /api/officer/license-history/{personId}
        [HttpGet("license-history/{personId}")]
        public IActionResult GetLicenseHistory(int personId)
        {
            DataTable dt = clsLicenses.GetPersonLicenses(personId);
            var history = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                int licenseID = (int)row["LicenseID"];
                history.Add(new
                {
                    LicenseID = licenseID,
                    ApplicationID = (int)row["ApplicationID"],
                    ClassName = row["ClassName"].ToString(),
                    IssueDate = (DateTime)row["IssueDate"],
                    ExpirationDate = (DateTime)row["ExpirationDate"],
                    IsActive = (bool)row["IsActive"],
                    IsDetained = clsDetainedLicenses.IsLicenseDetained(licenseID)
                });
            }

            return Ok(history);
        }

        // GET /api/officer/test-history/{ldlAppId}
        [HttpGet("test-history/{ldlAppId}")]
        public IActionResult GetTestHistory(int ldlAppId)
        {
            DataTable dt = clsTests.GetTestHistoryByLDLAppID(ldlAppId);
            var history = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                history.Add(new
                {
                    TestTypeTitle = row["TestTypeTitle"].ToString(),
                    TestResult = (bool)row["TestResult"],
                    Notes = row["Notes"].ToString(),
                    AppointmentDate = (DateTime)row["AppointmentDate"]
                });
            }

            return Ok(history);
        }

        // GET /api/officer/vehicle-history/{personId}
        [HttpGet("vehicle-history/{personId}")]
        public IActionResult GetVehicleHistory(int personId)
        {
            clsDrivers driver = clsDrivers.FindByPersonID(personId);
            if (driver == null)
            {
                return Ok(new List<object>()); // Person is not registered as a driver yet
            }

            DataTable dt = clsDriverVehicle.GetDriverHistory(driver.DriverID);
            var vehicles = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                vehicles.Add(new
                {
                    OwnershipID = (int)row["OwnershipID"],
                    PlateNumber = row["PlateNumber"].ToString(),
                    VIN = row["VIN"].ToString(),
                    Color = row["Color"].ToString(),
                    Make = row["Make"].ToString(),
                    ModelName = row["ModelName"].ToString(),
                    Year = (int)row["Year"],
                    VehicleDisplayName = row["Vehicle_Display_Name"].ToString(),
                    PurchaseDate = (DateTime)row["PurchaseDate"],
                    SaleDate = row["SaleDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["SaleDate"],
                    PurchasePrice = (decimal)row["PurchasePrice"],
                    Status = row["Status"].ToString()
                });
            }

            return Ok(vehicles);
        }

        // GET /api/officer/detain-history/{licenseId}
        [HttpGet("detain-history/{licenseId}")]
        public IActionResult GetDetainmentHistory(int licenseId)
        {
            DataTable dt = clsDetainedLicenses.GetDetainedLicensesByLicenseID(licenseId);
            var history = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                history.Add(new
                {
                    DetainID = (int)row["DetainID"],
                    LicenseID = (int)row["LicenseID"],
                    DetainDate = (DateTime)row["DetainDate"],
                    FineFees = (decimal)row["FineFees"],
                    IsReleased = (bool)row["IsReleased"],
                    ReleaseDate = row["ReleaseDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ReleaseDate"],
                    ReleaseApplicationID = row["ReleaseApplicationID"] == DBNull.Value ? (int?)null : (int)row["ReleaseApplicationID"],
                    DetainReason = row["DetainReason"].ToString(),
                    DetainPlace = row["DetainPlace"].ToString()
                });
            }

            return Ok(history);
        }

        // GET /api/officer/detained-list
        [HttpGet("detained-list")]
        public IActionResult GetDetainedList()
        {
            DataTable dt = clsDetainedLicenses.GetAllDetainedLicenses();
            var list = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    DetainID = (int)row["DetainID"],
                    LicenseID = (int)row["LicenseID"],
                    DetainDate = (DateTime)row["DetainDate"],
                    FineFees = (decimal)row["FineFees"],
                    IsReleased = (bool)row["IsReleased"],
                    ReleaseDate = row["ReleaseDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ReleaseDate"],
                    NationalNo = row["NationalNo"].ToString(),
                    FullName = row["FullName"].ToString()
                });
            }

            return Ok(list);
        }
    }
}
