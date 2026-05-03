using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class RegisterApplicantDTO
    {
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }
        
        // For User Account creation
        public string Username { get; set; }
        public string Password { get; set; }

        public RegisterApplicantDTO() { }
    }
}
