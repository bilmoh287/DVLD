using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsPeople
    {
        public enum enMode { AddNewMode, UpdateMode };
        public enMode _Mode = enMode.UpdateMode;

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }

        public clsPeople()
        {
            PersonID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.MinValue;
            Gender = 0;
            Address = "";
            Phone = "";
            Email = "";
            CountryID = -1;
            ImagePath = "";

            _Mode = enMode.AddNewMode;
        }

        private clsPeople(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName
            , DateTime DateOfBirth, int Gender, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;

            _Mode = enMode.UpdateMode;
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }
    }
}
