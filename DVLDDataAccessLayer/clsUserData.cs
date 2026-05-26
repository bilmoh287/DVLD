using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsUserData
    {
        public static DataTable GetAllUsersList()
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = @"SELECT Users.UserID, Users.PersonID, FullName = People.FirstName + ' ' + People.SecondName + ' ' + 
		                             ISNULL(People.ThirdName, '') + ' ' +  People.LastName, Users.UserName, Users.Password, Users.IsActive
                             FROM     Users INNER JOIN
                                              People ON Users.PersonID = People.PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.HasRows)
                {
                    dtPeople.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }

            return dtPeople;
        }

        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref string PassWord, ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"
                                SELECT * FROM Users 
                                WHERE PersonID = @PersonID";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        if (Reader.Read())
                        {
                            PersonID = (int)Reader["PersonID"];
                            UserName = (string)Reader["UserName"];
                            PassWord = (string)Reader["Password"];
                            IsActive = (bool)Reader["IsActive"];

                            IsFound = true;

                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                    }
                }
            }

            return IsFound;
        }

        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = "SELECT * FROM Users WHERE UserID = @UserID;";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        if (Reader.Read())
                        {
                            PersonID = (int)Reader["PersonID"];    
                            UserName = (string)Reader["UserName"];
                            Password = (string)Reader["Password"];
                            IsActive = (bool)Reader["IsActive"];

                            IsFound = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                    }
                }
            }

            return IsFound;
        }

        public static bool GetUserInfoByUsername(string UserName, ref int UserID, ref int PersonID, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = "SELECT * FROM Users WHERE UserName = @UserName;";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        if (Reader.Read())
                        {
                            UserID = (int)Reader["UserID"];
                            PersonID = (int)Reader["PersonID"];
                            Password = (string)Reader["Password"];
                            IsActive = (bool)Reader["IsActive"];

                            IsFound = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                    }
                }
            }

            return IsFound;
        }

        public static bool GetUserInfoByUsernameAndPassword(string UserName,  string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password;";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@UserName", UserName);
                    Command.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        if (Reader.Read())
                        {
                            UserID = (int)Reader["UserID"];
                            PersonID = (int)Reader["PersonID"];
                            IsActive = (bool)Reader["IsActive"];

                            IsFound = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                    }
                }
            }

            return IsFound;
        }

        public static int AddNewUser(int PersonID, string UserName, string PassWord, bool IsActive)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"
                                INSERT INTO [dbo].[Users]
                                           ([PersonID], [UserName], [PassWord], [IsActive])
                                VALUES
                                           (@PersonID, @UserName, @PassWord, @IsActive);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@PassWord", PassWord);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                            ID = insertedID;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return ID;
        }


        public static bool UpdateUser(int UserID, int PersonID, string UserName, string PassWord, bool IsActive)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"
                                UPDATE [dbo].[Users]
                                SET PersonID = @PersonID,                                
                                    UserName = @UserName,
                                    PassWord = @PassWord,
                                    IsActive = @IsActive
                                WHERE UserID = @UserID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@PassWord", PassWord);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        int rows = command.ExecuteNonQuery();
                        isUpdated = rows > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isUpdated;
        }


        public static bool DeleteUser(int ID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = "DELETE Users WHERE UserID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("ID", ID);

            try
            {
                connection.Open();
                int res = command.ExecuteNonQuery();

                if (res > 0)
                {
                    IsDeleted = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsDeleted;
        }

        public static bool IsUserExist(int UserID)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"SELECT 1 FROM Users WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        object res = command.ExecuteScalar();
                        IsExists = res != null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return IsExists;
        }

        public static bool IsUserExist(string UserName)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"SELECT 1 FROM Users WHERE  UserName= @UserName";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        connection.Open();
                        object res = command.ExecuteScalar();
                        IsExists = res != null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return IsExists;
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"SELECT 1 FROM Users WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        object res = command.ExecuteScalar();
                        IsExists = res != null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return IsExists;
        }
    }
}