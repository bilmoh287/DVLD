namespace DVLDDataAccessLayer.DTOs
{
    public class MarkAttendanceRequestDTO
    {
        public int ApplicationID { get; set; }
        public int BatchID { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public bool IsLate { get; set; }
        public int MarkedByUserID { get; set; }
    }

    public class CreateAnnouncementRequestDTO
    {
        public int InstituteID { get; set; }
        public int? BatchID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CreatedByUserID { get; set; }
    }

    public class EnrollmentRequestDTO
    {
        public int PersonID { get; set; }
        public int InstituteID { get; set; }
        public int CreatedByUserID { get; set; }
    }

    public class CreateCourseRequestDTO
    {
        public int InstituteID { get; set; }
        public string CourseName { get; set; }
        public int DurationInDays { get; set; }
        public decimal CourseFee { get; set; }
    }

    public class UpdateCourseRequestDTO
    {
        public int InstituteID { get; set; }
        public string CourseName { get; set; }
        public int DurationInDays { get; set; }
        public decimal CourseFee { get; set; }
    }

    public class CreateBatchRequestDTO
    {
        public int InstituteID { get; set; }
        public string BatchName { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int MaxCapacity { get; set; }
    }

    public class UpdateBatchRequestDTO
    {
        public int InstituteID { get; set; }
        public string BatchName { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int MaxCapacity { get; set; }
    }

    public class AssignStudentRequestDTO
    {
        public int ApplicationID { get; set; }
    }

    public class CreateVehicleRequestDTO
    {
        public int VehicleID { get; set; }
        public string PlateNumber { get; set; }
        public string VIN { get; set; }
        public string Color { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public int CreatedByUserID { get; set; }
    }

    public class UpdateInstituteRequestDTO
    {
        public string InstituteName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CommercialLicenseNo { get; set; }
        public System.DateTime LicenseExpiryDate { get; set; }
        public string ManagerName { get; set; }
        public int Capacity { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public bool IsActive { get; set; }
    }
}
