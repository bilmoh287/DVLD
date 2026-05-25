using DVLDBussinessLayer;
using DVLDDataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        // GET: api/Payments/receipt/{applicationID}
        // Returns a payment receipt for a specific DVLD application
        [HttpGet("receipt/{applicationID}")]
        public IActionResult GetApplicationReceipt(int applicationID)
        {
            var app = clsApplication.Find(applicationID);
            if (app == null)
                return NotFound(new { message = "Application not found." });

            var appType = clsApplicationTypes.FindApplicationType(app.ApplicationTypeID);
            var person  = clsPerson.Find(app.ApplicantPersonID);

            return Ok(new
            {
                receiptNumber      = $"REC-{app.ApplicationID:D6}",
                applicationID      = app.ApplicationID,
                personName         = person?.FullName ?? "N/A",
                nationalNo         = person?.NationalNo ?? "N/A",
                applicationType    = appType?.ApplicationTypeTitle ?? "N/A",
                applicationDate    = app.ApplicationDate.ToString("yyyy-MM-dd"),
                paidFees           = app.PaidFees,
                status             = app.StatusText,
                currency           = "ETB"
            });
        }

        // GET: api/Payments/school/{enrollmentID}
        // Returns the payment receipt for a school course enrollment
        [HttpGet("school/{enrollmentID}")]
        public IActionResult GetSchoolPaymentReceipt(int enrollmentID)
        {
            var payments = clsInstitutePaymentData.GetPaymentsByInstituteID(-1); // We'll filter below
            // Direct enrollment lookup
            int personID = -1, instituteID = -1, courseID = -1;
            bool isActive = false;
            int createdBy = -1;
            DateTime enrollDate = DateTime.Now;

            if (!clsEnrollmentData.GetEnrollmentInfoByID(enrollmentID, ref personID, ref instituteID,
                ref courseID, ref enrollDate, ref isActive, ref createdBy))
            {
                return NotFound(new { message = "Enrollment not found." });
            }

            var person = clsPerson.Find(personID);
            decimal courseFee = clsEnrollmentData.GetCourseFee(courseID);

            return Ok(new
            {
                receiptNumber  = $"SCH-{enrollmentID:D6}",
                enrollmentID   = enrollmentID,
                personName     = person?.FullName ?? "N/A",
                nationalNo     = person?.NationalNo ?? "N/A",
                enrollmentDate = enrollDate.ToString("yyyy-MM-dd"),
                courseFee      = courseFee,
                currency       = "ETB"
            });
        }

        // POST: api/Payments/confirm
        // Called by the Flutter app to confirm a payment was made (Cash at Branch flow)
        // For Chapa: this will be replaced by the Chapa webhook
        [HttpPost("confirm")]
        public IActionResult ConfirmPayment([FromBody] PaymentConfirmRequest request)
        {
            if (request == null || request.ApplicationID <= 0)
                return BadRequest(new { message = "Invalid request." });

            // Simply return the receipt — fees are already stored on the Application record
            var app = clsApplication.Find(request.ApplicationID);
            if (app == null)
                return NotFound(new { message = "Application not found." });

            // Send a payment notification to the applicant
            clsUserMessage.SendSystemMessage(
                app.ApplicantPersonID,
                "Payment Confirmed",
                $"Your payment of ETB {app.PaidFees} for application #{app.ApplicationID} has been confirmed. Thank you!",
                "Payment"
            );

            // Handle completing the application and issuing the new license if it's approved and paying
            if (app.ApplicationStatus == clsApplication.enApplicationStatus.Approved)
            {
                if (app.ApplicationTypeID == (int)clsApplication.enApplicationType.RenewDrivingLicense ||
                    app.ApplicationTypeID == (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense ||
                    app.ApplicationTypeID == (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense)
                {
                    clsDrivers driver = clsDrivers.FindByPersonID(app.ApplicantPersonID);
                    if (driver != null)
                    {
                        clsLicenses oldLicense = clsLicenses.GetActiveLicenseByDriverID(driver.DriverID);
                        if (oldLicense != null)
                        {
                            if (app.ApplicationTypeID == (int)clsApplication.enApplicationType.RenewDrivingLicense)
                            {
                                oldLicense.CompleteRenewalAfterPayment(app, "Renewed via Mobile App", app.CreatedByUserID);
                            }
                            else if (app.ApplicationTypeID == (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense)
                            {
                                oldLicense.CompleteReplacementDamagedAfterPayment(app, app.CreatedByUserID);
                            }
                            else if (app.ApplicationTypeID == (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense)
                            {
                                oldLicense.CompleteReplacementLostAfterPayment(app, app.CreatedByUserID);
                            }
                        }
                    }
                }
            }

            return Ok(new
            {
                success    = true,
                receiptNumber = $"REC-{app.ApplicationID:D6}",
                paidFees   = app.PaidFees,
                currency   = "ETB",
                message    = "Payment confirmed successfully."
            });
        }
    }

    public class PaymentConfirmRequest
    {
        public int ApplicationID { get; set; }
        public string? PaymentMethod { get; set; } = "Cash";
        public string? ChapaTransactionRef { get; set; } = null;
    }
}
