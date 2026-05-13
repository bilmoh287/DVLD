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

        public class MarkAttendanceDTO
        {
            public int ApplicationID { get; set; }
            public int BatchID { get; set; }
            public DateTime Date { get; set; }
            public bool IsPresent { get; set; }
            public int MarkedByUserID { get; set; }
        }

        // POST: api/DrivingInstitutes/attendance/mark
        [HttpPost("attendance/mark")]
        public IActionResult MarkAttendance([FromBody] MarkAttendanceDTO request)
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

        public class CreateAnnouncementDTO
        {
            public int InstituteID { get; set; }
            public int? BatchID { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public int CreatedByUserID { get; set; }
        }

        // POST: api/DrivingInstitutes/announcements
        [HttpPost("announcements")]
        public IActionResult PostAnnouncement([FromBody] CreateAnnouncementDTO request)
        {
            if (request == null) return BadRequest();

            if (clsAnnouncement.CreateAnnouncement(request.InstituteID, request.BatchID, request.Title, request.Content, request.CreatedByUserID))
            {
                return Ok(new { message = "Announcement broadcasted successfully." });
            }
            return StatusCode(500, "Error broadcasting announcement.");
        }
        public class EnrollmentRequestDTO
        {
            public int PersonID { get; set; }
            public int InstituteID { get; set; }
            public int CreatedByUserID { get; set; }
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
    }
}
