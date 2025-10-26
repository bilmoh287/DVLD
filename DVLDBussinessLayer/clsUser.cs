using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{

    public class clsUser
    {
        public enum enMode { AddNewMode = 0, UpdateMode = 1 };
        public enMode _Mode = enMode.UpdateMode;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        clsPerson PersonInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = true;

            _Mode = enMode.AddNewMode;
        }

        private clsUser(int UserID, int PersonID, string UserName, string PassWord, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = PassWord;
            this.IsActive = IsActive;

            _Mode = enMode.UpdateMode;
        }

        public static DataTable GetAllUser()
        {
            return clsUserData.GetAllUsersList();
        }

        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = true;

            if (clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID,PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = true;

            if (clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser Find(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = true;

            if (clsUserData.GetUserInfoByUsernameAndPassword(UserName,  Password, ref UserID, ref PersonID, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return this.UserID != -1;
        }

        // Update User
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.PersonID, this.UserName, this.Password, this.IsActive);
        }

        public static bool DeleteUserByID(int ID)
        {
            return clsUserData.DeleteUser(ID);
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUserData.IsUserExistByPersonID(PersonID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNewMode:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    return _UpdateUser();
            }
            return false;
        }
    }
}
