using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNewMode, UpdateMode };
        public enMode _Mode = enMode.UpdateMode;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

        }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }

        public clsCountries CountryInfo;

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = "";
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

        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName
            , DateTime DateOfBirth, int Gender, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountries.FindCountry(CountryID);

            _Mode = enMode.UpdateMode;
        }

        public static DataTable GetAllPerson()
        {
            return clsPersonData.GetAllPersonList();
        }

        public static clsPerson Find(string FirstName)
        {
            int PersonID = -1;
            string NationalNo = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "";
            int Gender = 0, CountryID = -1;
            DateTime DateOfBirth = DateTime.Now;
            string ImagePath = "";

            if (clsPersonData.FindByName(FirstName, ref NationalNo, ref PersonID, ref SecondName, ref ThirdName, ref LastName,
                                         ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
                                         ref CountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                     DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            string Address = "", Phone = "", Email = "", ImagePath = "";
            int Gender = 0, CountryID = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPersonData.FindByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                       ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
                                       ref CountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                     DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                                                       this.LastName, this.DateOfBirth, this.Gender, this.Address,
                                                       this.Phone, this.Email, this.CountryID, this.ImagePath);

            return this.PersonID != -1;
        }

        // Update person
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                                              this.LastName, this.DateOfBirth, this.Gender, this.Address,
                                              this.Phone, this.Email, this.CountryID, this.ImagePath);
        }

        public static bool DeletePersonByID(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNewMode:
                    if(_AddNewPerson())
                    {
                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    return _UpdatePerson();
            }
            return false;
        }
    }
}
