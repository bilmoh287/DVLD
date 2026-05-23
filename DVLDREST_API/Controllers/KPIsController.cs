using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using DVLDBussinessLayer;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KPIsController : ControllerBase
    {
        // GET: api/kpis
        [HttpGet]
        public IActionResult GetGlobalKPIs()
        {
            try
            {
                var response = new
                {
                    People = new
                    {
                        Total = clsKPI.GetTotalPeople(),
                        Males = clsKPI.GetTotalMales(),
                        Females = clsKPI.GetTotalFemales()
                    },
                    Users = new
                    {
                        Total = clsKPI.GetTotalUsers(),
                        Drivers = clsKPI.GetTotalDrivers(),
                        Applicants = clsKPI.GetTotalApplicants()
                    },
                    Licenses = new
                    {
                        Active = clsKPI.GetActiveLicensesCount(),
                        Detained = clsKPI.GetCurrentlyDetainedLicensesCount(),
                        Released = clsKPI.GetReleasedLicensesCount(),
                        Renewals = clsKPI.GetLicenseRenewalsCount(),
                        Replacements = clsKPI.GetLicenseReplacementsCount(),
                        International = clsKPI.GetInternationalLicensesCount()
                    },
                    Applications = new
                    {
                        Active = clsKPI.GetActiveApplicationsCount()
                    },
                    Revenue = new
                    {
                        MonthToDate = clsKPI.GetMonthToDateRevenue(),
                        AllTime = clsKPI.GetAllTimeRevenue(),
                        FinesCollected = clsKPI.GetTotalFinesCollected(),
                        OutstandingFines = clsKPI.GetOutstandingFinesAmount()
                    },
                    Testing = new
                    {
                        PassRate = clsKPI.GetGlobalTestPassRate(),
                        PassRateVision = clsKPI.GetTestPassRateByType(1),
                        PassRateTheory = clsKPI.GetTestPassRateByType(2),
                        PassRateRoad = clsKPI.GetTestPassRateByType(3)
                    },
                    Institutes = new
                    {
                        Active = clsKPI.GetActiveDrivingInstitutesCount(),
                        EnrolledStudents = clsKPI.GetActiveStudentEnrollmentsCount(),
                        ActiveBatches = clsKPI.GetActiveTrainingBatchesCount()
                    },
                    Vehicles = new
                    {
                        OwnedCount = clsKPI.GetCurrentlyOwnedVehiclesCount(),
                        SoldCount = clsKPI.GetSoldVehiclesCount(),
                        TotalValueOwned = clsKPI.GetTotalValueOwnedVehicles()
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/kpis/revenue-report
        [HttpGet("revenue-report")]
        public IActionResult GetRevenueReport()
        {
            try
            {
                DataTable dt = clsKPI.GetUnifiedRevenueReport();
                var list = ConvertDataTableToList(dt);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/kpis/top-vehicles
        [HttpGet("top-vehicles")]
        public IActionResult GetTopVehicles()
        {
            try
            {
                DataTable dt = clsKPI.GetTopVehicleMakes();
                var list = ConvertDataTableToList(dt);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/kpis/school-revenue/{instituteId}
        [HttpGet("school-revenue/{instituteId}")]
        public IActionResult GetSchoolRevenue(int instituteId)
        {
            try
            {
                decimal revenue = clsKPI.GetSchoolRevenue(instituteId);
                return Ok(new { InstituteID = instituteId, Revenue = revenue });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private List<Dictionary<string, object>> ConvertDataTableToList(DataTable dt)
        {
            var list = new List<Dictionary<string, object>>();
            if (dt == null) return list;

            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    dict[col.ColumnName] = row[col] == DBNull.Value ? null : row[col];
                }
                list.Add(dict);
            }
            return list;
        }
    }
}
