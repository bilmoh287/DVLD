using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DVLDBussinessLayer;
using DVLDDataAccessLayer.DTOs;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingInstitutesController : ControllerBase
    {
        // GET: api/DrivingInstitutes
        [HttpGet]
        public IActionResult GetAllInstitutes()
        {
            DataTable dt = clsDrivingInstitute.GetAllInstitutes();
            var institutes = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                institutes.Add(new
                {
                    InstituteID = (int)row["InstituteID"],
                    InstituteName = (string)row["InstituteName"],
                    Address = row["Address"]?.ToString() ?? "",
                    Phone = row["Phone"]?.ToString() ?? "",
                    Email = row["Email"]?.ToString() ?? "",
                    City = row["City"]?.ToString() ?? "",
                    Region = row["Region"]?.ToString() ?? "",
                    Capacity = row["Capacity"] != DBNull.Value ? (int)row["Capacity"] : 0,
                    IsActive = (bool)row["IsActive"]
                });
            }

            return Ok(institutes);
        }

        // GET: api/DrivingInstitutes/{id}/batches
        [HttpGet("{id}/batches")]
        public IActionResult GetInstituteBatches(int id)
        {
            DataTable dt = clsTrainingBatch.GetBatchesByInstituteID(id);
            var batches = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                batches.Add(new
                {
                    BatchID = (int)row["TrainingBatchID"],
                    BatchName = (string)row["BatchName"],
                    StartDate = (DateTime)row["StartDate"],
                    EndDate = (DateTime)row["EndDate"],
                    MaxCapacity = (int)row["MaxCapacity"],
                    CurrentStudents = (int)row["CurrentStudents"]
                });
            }

            return Ok(batches);
        }

        // GET: api/DrivingInstitutes/batches/{batchId}/attendance
        [HttpGet("batches/{batchId}/attendance")]
        public IActionResult GetBatchAttendance(int batchId)
        {
            DataTable dt = clsAttendance.GetBatchAttendance(batchId);
            var attendance = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                attendance.Add(new
                {
                    AttendanceID = (int)row["AttendanceID"],
                    FullName = (string)row["FullName"],
                    Date = (DateTime)row["AttendanceDate"],
                    IsPresent = (bool)row["IsPresent"]
                });
            }

            return Ok(attendance);
        }

        // POST: api/DrivingInstitutes/attendance/mark
        [HttpPost("attendance/mark")]
        public IActionResult MarkAttendance([FromBody] MarkAttendanceRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request.");

            if (clsAttendance.MarkAttendance(request.ApplicationID, request.BatchID, request.Date, request.IsPresent, request.MarkedByUserID))
            {
                return Ok(new { message = "Attendance marked successfully." });
            }

            return StatusCode(500, "Error marking attendance.");
        }

        // GET: api/DrivingInstitutes/student/{personId}/status
        [HttpGet("student/{personId}/status")]
        public IActionResult GetStudentTrainingStatus(int personId)
        {
            // 1. Find Enrollment
            DataTable dtEnrollment = clsEnrollment.GetEnrollmentsByPersonID(personId);
            if (dtEnrollment.Rows.Count == 0) return NotFound("No enrollment found for this student.");

            DataRow enrollment = dtEnrollment.Rows[0];
            int instituteId = (int)enrollment["InstituteID"];

            // 2. Find Batch
            DataTable dtBatch = clsTrainingBatch.GetStudentBatch(personId);
            object batchInfo = null;
            if (dtBatch.Rows.Count > 0)
            {
                DataRow batch = dtBatch.Rows[0];
                batchInfo = new
                {
                    BatchID = (int)batch["TrainingBatchID"],
                    BatchName = batch["BatchName"].ToString(),
                    StartDate = (DateTime)batch["StartDate"],
                    EndDate = (DateTime)batch["EndDate"]
                };
            }

            return Ok(new
            {
                InstituteID = instituteId,
                InstituteName = enrollment["InstituteName"].ToString(),
                EnrollmentDate = (DateTime)enrollment["EnrollmentDate"],
                Status = (int)enrollment["Status"] == 1 ? "Active" : "Completed",
                Batch = batchInfo
            });
        }

        // GET: api/DrivingInstitutes/{id}/announcements
        [HttpGet("{id}/announcements")]
        public IActionResult GetAnnouncements(int id, [FromQuery] int? batchId)
        {
            DataTable dt;
            if (batchId.HasValue)
                dt = clsAnnouncement.GetBatchAnnouncements(batchId.Value);
            else
                dt = clsAnnouncement.GetInstituteAnnouncements(id);

            var list = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    AnnouncementID = (int)row["AnnouncementID"],
                    Title = row["Title"].ToString(),
                    Content = row["Content"].ToString(),
                    DateCreated = (DateTime)row["DateCreated"]
                });
            }
            return Ok(list);
        }

        // POST: api/DrivingInstitutes/announcements
        [HttpPost("announcements")]
        public IActionResult PostAnnouncement([FromBody] CreateAnnouncementRequestDTO request)
        {
            if (request == null) return BadRequest();

            if (clsAnnouncement.CreateAnnouncement(request.InstituteID, request.BatchID, request.Title, request.Content, request.CreatedByUserID))
            {
                return Ok(new { message = "Announcement broadcasted successfully." });
            }
            return StatusCode(500, "Error broadcasting announcement.");
        }
        // POST: api/DrivingInstitutes/enroll
        [HttpPost("enroll")]
        public IActionResult EnrollStudent([FromBody] EnrollmentRequestDTO request)
        {
            if (request == null) return BadRequest();

            // 1. Get default course for this institute
            int courseId = clsEnrollment.GetDefaultCourseIDForInstitute(request.InstituteID);
            if (courseId == -1) return BadRequest("Institute has no courses defined.");

            // 2. Check if already enrolled
            if (clsEnrollment.IsAlreadyEnrolled(request.PersonID, request.InstituteID, courseId))
            {
                return BadRequest("Student is already enrolled in this institute.");
            }

            // 3. Create Enrollment
            clsEnrollment enrollment = new clsEnrollment();
            enrollment.PersonID = request.PersonID;
            enrollment.InstituteID = request.InstituteID;
            enrollment.CourseID = courseId;
            enrollment.CreatedByUserID = request.CreatedByUserID;

            if (enrollment.Save())
            {
                return Ok(new { message = "Enrolled successfully.", enrollmentId = enrollment.EnrollmentID });
            }
            return StatusCode(500, "Error creating enrollment.");
        }

        // GET: api/DrivingInstitutes/{id}/stats
        [HttpGet("{id}/stats")]
        public IActionResult GetInstituteStats(int id)
        {
            try
            {
                clsSchoolDashboardStats stats = clsSchoolDashboardStats.Load(id);
                if (stats == null) return NotFound("Driving institute statistics not found.");

                // 1. Get recent students (top 8)
                DataTable dtEnrollments = clsEnrollment.GetAllByInstitute(id);
                var recentStudents = new List<object>();
                int count = 0;
                foreach (DataRow row in dtEnrollments.Rows)
                {
                    if (count >= 8) break;
                    recentStudents.Add(new
                    {
                        EnrollmentID = (int)row["EnrollmentID"],
                        PersonID = (int)row["PersonID"],
                        FullName = row["FullName"]?.ToString() ?? "",
                        Phone = row["Phone"]?.ToString() ?? "",
                        CourseName = row["CourseName"]?.ToString() ?? "",
                        EnrollmentDate = (DateTime)row["EnrollmentDate"],
                        IsActive = (bool)row["IsActive"]
                    });
                    count++;
                }

                // 2. Get monthly enrollment stats
                var monthlyEnrollmentStats = new List<object>();
                if (stats.MonthlyEnrollmentStats != null)
                {
                    foreach (DataRow row in stats.MonthlyEnrollmentStats.Rows)
                    {
                        monthlyEnrollmentStats.Add(new
                        {
                            MonthName = row["MonthName"]?.ToString() ?? "",
                            Count = row["Count"] != DBNull.Value ? Convert.ToInt32(row["Count"]) : 0
                        });
                    }
                }

                return Ok(new
                {
                    Kpis = new
                    {
                        TotalStudents = stats.TotalStudents,
                        NewStudentsThisMonth = stats.NewStudentsThisMonth,
                        ActiveCourses = stats.ActiveCourses,
                        TotalInstructors = stats.TotalInstructors,
                        TestsToday = stats.TestsToday,
                        TotalEarnings = stats.TotalEarnings,
                        ActiveBatches = stats.ActiveBatches,
                        WaitingList = stats.WaitingList,
                        TodayAttendanceRate = stats.TodayAttendanceRate
                    },
                    PassRates = new
                    {
                        Vision = stats.PassRateVision,
                        Theory = stats.PassRateTheory,
                        Road = stats.PassRateRoad
                    },
                    RecentStudents = recentStudents,
                    MonthlyEnrollmentStats = monthlyEnrollmentStats
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/DrivingInstitutes/{id}/courses
        [HttpGet("{id}/courses")]
        public IActionResult GetInstituteCourses(int id)
        {
            DataTable dt = clsInstituteCourses.GetCoursesList(id);
            var list = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    CourseID = (int)row["CourseID"],
                    CourseName = row["CourseName"]?.ToString() ?? "",
                    DurationInDays = (int)row["DurationInDays"],
                    CourseFee = (decimal)row["CourseFee"]
                });
            }
            return Ok(list);
        }

        // POST: api/DrivingInstitutes/courses
        [HttpPost("courses")]
        public IActionResult CreateCourse([FromBody] CreateCourseRequestDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.CourseName)) return BadRequest("Invalid request data.");

            clsInstituteCourses course = new clsInstituteCourses();
            course.InstituteID = request.InstituteID;
            course.CourseName = request.CourseName;
            course.DurationInDays = request.DurationInDays;
            course.CourseFee = request.CourseFee;

            if (course.Save())
            {
                return Ok(new { message = "Course created successfully.", courseId = course.CourseID });
            }
            return StatusCode(500, "Error creating course.");
        }

        // PUT: api/DrivingInstitutes/courses/{courseId}
        [HttpPut("courses/{courseId}")]
        public IActionResult UpdateCourse(int courseId, [FromBody] UpdateCourseRequestDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.CourseName)) return BadRequest("Invalid request data.");

            clsInstituteCourses course = clsInstituteCourses.Find(courseId);
            if (course == null) return NotFound("Course not found.");

            course.InstituteID = request.InstituteID;
            course.CourseName = request.CourseName;
            course.DurationInDays = request.DurationInDays;
            course.CourseFee = request.CourseFee;

            if (course.Save())
            {
                return Ok(new { message = "Course updated successfully." });
            }
            return StatusCode(500, "Error updating course.");
        }

        // DELETE: api/DrivingInstitutes/{id}/courses/{courseId}
        [HttpDelete("{id}/courses/{courseId}")]
        public IActionResult DeleteCourse(int id, int courseId)
        {
            if (clsInstituteCourses.DeleteCourse(courseId, id))
            {
                return Ok(new { message = "Course deleted successfully." });
            }
            return BadRequest("Error deleting course. It may be referenced by existing enrollments.");
        }

        // POST: api/DrivingInstitutes/batches
        [HttpPost("batches")]
        public IActionResult CreateBatch([FromBody] CreateBatchRequestDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.BatchName)) return BadRequest("Invalid request data.");

            clsTrainingBatch batch = new clsTrainingBatch();
            batch.InstituteID = request.InstituteID;
            batch.BatchName = request.BatchName;
            batch.StartDate = request.StartDate;
            batch.EndDate = request.EndDate;
            batch.MaxCapacity = request.MaxCapacity;

            if (batch.Save())
            {
                return Ok(new { message = "Batch created successfully.", batchId = batch.BatchID });
            }
            return StatusCode(500, "Error creating batch.");
        }

        // PUT: api/DrivingInstitutes/batches/{batchId}
        [HttpPut("batches/{batchId}")]
        public IActionResult UpdateBatch(int batchId, [FromBody] UpdateBatchRequestDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.BatchName)) return BadRequest("Invalid request data.");

            clsTrainingBatch batch = clsTrainingBatch.Find(batchId);
            if (batch == null) return NotFound("Batch not found.");

            batch.InstituteID = request.InstituteID;
            batch.BatchName = request.BatchName;
            batch.StartDate = request.StartDate;
            batch.EndDate = request.EndDate;
            batch.MaxCapacity = request.MaxCapacity;

            if (batch.Save())
            {
                return Ok(new { message = "Batch updated successfully." });
            }
            return StatusCode(500, "Error updating batch.");
        }

        // GET: api/DrivingInstitutes/batches/{batchId}/students
        [HttpGet("batches/{batchId}/students")]
        public IActionResult GetBatchStudents(int batchId)
        {
            clsTrainingBatch batch = clsTrainingBatch.Find(batchId);
            if (batch == null) return NotFound("Batch not found.");

            DataTable dt = batch.GetApplicants();
            var list = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    ApplicationID = (int)row["ApplicationID"],
                    PersonID = (int)row["PersonID"],
                    FullName = row["FullName"]?.ToString() ?? "",
                    Phone = row["Phone"]?.ToString() ?? "",
                    AssignedDate = (DateTime)row["AssignedDate"]
                });
            }
            return Ok(list);
        }

        // POST: api/DrivingInstitutes/batches/{batchId}/assign
        [HttpPost("batches/{batchId}/assign")]
        public IActionResult AssignStudent(int batchId, [FromBody] AssignStudentRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request data.");

            clsTrainingBatch batch = clsTrainingBatch.Find(batchId);
            if (batch == null) return NotFound("Batch not found.");

            if (batch.AssignApplicant(request.ApplicationID))
            {
                return Ok(new { message = "Student assigned to batch successfully." });
            }
            return BadRequest("Error assigning student. Check if batch is full or student is already assigned.");
        }

        // DELETE: api/DrivingInstitutes/batches/{batchId}/students/{applicationId}
        [HttpDelete("batches/{batchId}/students/{applicationId}")]
        public IActionResult RemoveStudentFromBatch(int batchId, int applicationId)
        {
            if (clsTrainingBatch.RemoveApplicant(applicationId, batchId))
            {
                return Ok(new { message = "Student removed from batch successfully." });
            }
            return StatusCode(500, "Error removing student from batch.");
        }

        // GET: api/DrivingInstitutes/{id}/eligible-students
        [HttpGet("{id}/eligible-students")]
        public IActionResult GetEligibleStudents(int id)
        {
            DataTable dt = clsTrainingBatch.GetEligibleStudents(id);
            var list = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    ApplicationID = (int)row["ApplicationID"],
                    PersonID = (int)row["PersonID"],
                    FullName = row["FullName"]?.ToString() ?? "",
                    Phone = row["Phone"]?.ToString() ?? "",
                    EnrollmentDate = (DateTime)row["EnrollmentDate"]
                });
            }
            return Ok(list);
        }
        // GET: api/DrivingInstitutes/{id}/students
        [HttpGet("{id}/students")]
        public IActionResult GetInstituteStudents(int id)
        {
            DataTable dt = clsEnrollment.GetAllByInstitute(id);
            var students = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                students.Add(new
                {
                    EnrollmentID = (int)row["EnrollmentID"],
                    PersonID = (int)row["PersonID"],
                    FullName = row["FullName"]?.ToString() ?? "",
                    Phone = row["Phone"]?.ToString() ?? "",
                    CourseName = row["CourseName"]?.ToString() ?? "",
                    EnrollmentDate = (DateTime)row["EnrollmentDate"],
                    IsActive = (bool)row["IsActive"]
                });
            }

            return Ok(students);
        }

        // GET: api/DrivingInstitutes/vehicles/catalog
        [HttpGet("vehicles/catalog")]
        public IActionResult GetVehiclesCatalog([FromQuery] string search = null, [FromQuery] int limit = 10)
        {
            DataTable dt = clsDriverVehicle.GetVehiclesCatalog(search, limit);
            var list = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    ID = (int)row["ID"],
                    VehicleDisplayName = row["Vehicle_Display_Name"]?.ToString() ?? "",
                    Year = row["Year"] != DBNull.Value ? Convert.ToInt32(row["Year"]) : 0,
                    Make = row["Make"]?.ToString() ?? "",
                    ModelName = row["ModelName"]?.ToString() ?? ""
                });
            }
            return Ok(list);
        }

        // GET: api/DrivingInstitutes/{id}/vehicles
        [HttpGet("{id}/vehicles")]
        public IActionResult GetInstituteVehicles(int id)
        {
            DataTable dt = clsDriverVehicle.GetDriverHistory(id);
            var list = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    OwnershipID = (int)row["OwnershipID"],
                    DriverID = id,
                    PlateNumber = row["PlateNumber"]?.ToString() ?? "",
                    VIN = row["VIN"]?.ToString() ?? "",
                    Color = row["Color"]?.ToString() ?? "",
                    Make = row["Make"]?.ToString() ?? "",
                    ModelName = row["ModelName"]?.ToString() ?? "",
                    Year = row["Year"] != DBNull.Value ? Convert.ToInt32(row["Year"]) : 0,
                    VehicleDisplayName = row["Vehicle_Display_Name"]?.ToString() ?? "",
                    PurchaseDate = (DateTime)row["PurchaseDate"],
                    SaleDate = row["SaleDate"] != DBNull.Value ? (DateTime?)row["SaleDate"] : null,
                    PurchasePrice = (decimal)row["PurchasePrice"],
                    Status = row["Status"]?.ToString() ?? ""
                });
            }
            return Ok(list);
        }

        // POST: api/DrivingInstitutes/{id}/vehicles
        [HttpPost("{id}/vehicles")]
        public IActionResult AddInstituteVehicle(int id, [FromBody] CreateVehicleRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid vehicle data.");

            clsDriverVehicle vehicle = new clsDriverVehicle();
            vehicle.DriverID = id; // Assuming InstituteID/Manager is tracked in DriverID for now
            vehicle.VehicleID = request.VehicleID;
            vehicle.PlateNumber = request.PlateNumber;
            vehicle.VIN = request.VIN;
            vehicle.Color = request.Color;
            vehicle.PurchaseDate = request.PurchaseDate;
            vehicle.PurchasePrice = request.PurchasePrice;
            vehicle.CreatedByUserID = request.CreatedByUserID;

            if (vehicle.Save())
            {
                return Ok(new { message = "Vehicle tracked successfully.", ownershipId = vehicle.OwnershipID });
            }
            return StatusCode(500, "Error tracking vehicle.");
        }

        // GET: api/DrivingInstitutes/{id}/payments
        [HttpGet("{id}/payments")]
        public IActionResult GetInstitutePayments(int id)
        {
            DataTable dt = clsInstitutePayment.GetPaymentsByInstituteID(id);
            var list = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    PaymentID = (int)row["PaymentID"],
                    EnrollmentID = (int)row["EnrollmentID"],
                    StudentName = row["StudentName"]?.ToString() ?? "",
                    CourseName = row["CourseName"]?.ToString() ?? "",
                    AmountPaid = (decimal)row["AmountPaid"],
                    PaymentDate = (DateTime)row["PaymentDate"],
                    ChapaTransactionRef = row["ChapaTransactionRef"]?.ToString() ?? ""
                });
            }
            return Ok(list);
        }

        // GET: api/DrivingInstitutes/{id}
        [HttpGet("{id}")]
        public IActionResult GetInstituteDetails(int id)
        {
            clsDrivingInstitute institute = clsDrivingInstitute.Find(id);
            if (institute == null) return NotFound("Driving institute not found.");

            return Ok(new
            {
                InstituteID = institute.InstituteID,
                InstituteName = institute.InstituteName,
                Address = institute.Address,
                Phone = institute.Phone,
                Email = institute.Email,
                CommercialLicenseNo = institute.CommercialLicenseNo,
                LicenseExpiryDate = institute.LicenseExpiryDate,
                ManagerName = institute.ManagerName,
                Capacity = institute.Capacity,
                City = institute.City,
                Region = institute.Region,
                IsActive = institute.IsActive,
                CreatedByUserID = institute.CreatedByUserID
            });
        }

        // PUT: api/DrivingInstitutes/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateInstitute(int id, [FromBody] UpdateInstituteRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request data.");

            clsDrivingInstitute institute = clsDrivingInstitute.Find(id);
            if (institute == null) return NotFound("Driving institute not found.");

            institute.InstituteName = request.InstituteName;
            institute.Address = request.Address;
            institute.Phone = request.Phone;
            institute.Email = request.Email;
            institute.CommercialLicenseNo = request.CommercialLicenseNo;
            institute.LicenseExpiryDate = request.LicenseExpiryDate;
            institute.ManagerName = request.ManagerName;
            institute.Capacity = request.Capacity;
            institute.City = request.City;
            institute.Region = request.Region;
            institute.IsActive = request.IsActive;

            if (institute.Save())
            {
                return Ok(new { message = "Institute profile updated successfully." });
            }
            return StatusCode(500, "Error updating institute profile.");
        }
    }
}
