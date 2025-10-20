using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsPersonData
    {
        public static DataTable GetAllPersonList()
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, 
		                            Case People.Gender
			                            WHEN 0 THEN 'Male'
			                            WHEN 1 THen 'Female'
			                            ELSE 'Uknown'
			                            END AS Gendor,
		                            Countries.CountryName AS Nationality, People.Phone, People.Email
                            FROM     People INNER JOIN
                                              Countries ON People.NationalityCountryID = Countries.CountryID;";

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

        public static bool FindByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
                                     ref DateTime DateOfBirth, ref int Gender, ref string Address,
                                     ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"
                                SELECT * FROM People 
                                WHERE NationalNo = @NationalNo";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        if (Reader.Read())
                        {
                            PersonID = (int)Reader["PersonID"];
                            FirstName = (string)Reader["FirstName"];
                            SecondName = (string)Reader["SecondName"];
                            ThirdName = Reader["ThirdName"] != DBNull.Value ? (string)Reader["ThirdName"] : "";  // nullable
                            LastName = (string)Reader["LastName"];
                            DateOfBirth = (DateTime)Reader["DateOfBirth"];
                            Gender = Convert.ToInt32(Reader["Gender"]);
                            Address = (string)Reader["Address"];
                            Phone = (string)Reader["Phone"];
                            Email = Reader["Email"] != DBNull.Value ? (string)Reader["Email"] : "";            // nullable
                            CountryID = (int)Reader["NationalityCountryID"];
                            ImagePath = Reader["ImagePath"] != DBNull.Value ? (string)Reader["ImagePath"] : ""; // nullable

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



        public static bool FindByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
                                    ref string LastName, ref DateTime DateOfBirth, ref int Gender,
                                    ref string Address, ref string Phone, ref string Email,
                                    ref int CountryID, ref string ImagePath)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = "SELECT * FROM People WHERE PersonID = @PersonID;";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        if (Reader.Read())
                        {
                            NationalNo = (string)Reader["NationalNo"];    
                            FirstName = (string)Reader["FirstName"];
                            SecondName = (string)Reader["SecondName"];
                            ThirdName = Reader["ThirdName"] != DBNull.Value ? (string)Reader["ThirdName"] : "";  // nullable
                            LastName = (string)Reader["LastName"];
                            DateOfBirth = (DateTime)Reader["DateOfBirth"];
                            Gender = Convert.ToInt32(Reader["Gender"]);
                            Address = (string)Reader["Address"];            
                            Phone = (string)Reader["Phone"];                
                            Email = Reader["Email"] != DBNull.Value ? (string)Reader["Email"] : "";            // nullable
                            CountryID = (int)Reader["NationalityCountryID"];
                            ImagePath = Reader["ImagePath"] != DBNull.Value ? (string)Reader["ImagePath"] : ""; // nullable

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


        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                       DateTime DateOfBirth, int Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"
                                INSERT INTO [dbo].[People]
                                           ([NationalNo], [FirstName], [SecondName], [ThirdName], [LastName], [DateOfBirth], [Gender], 
                                            [Address], [Phone], [Email], [NationalityCountryID], [ImagePath])
                                VALUES
                                           (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender,
                                            @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

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


        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                        DateTime DateOfBirth, int Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"
                                UPDATE [dbo].[People]
                                SET NationalNo = @NationalNo,                                
                                    FirstName = @FirstName,
                                    SecondName = @SecondName,
                                    ThirdName = @ThirdName,
                                    LastName = @LastName,
                                    DateOfBirth = @DateOfBirth,
                                    Gender = @Gender,
                                    Address = @Address,
                                    Phone = @Phone,
                                    Email = @Email,
                                    NationalityCountryID = @NationalityCountryID,
                                    ImagePath = @ImagePath
                                WHERE PersonID = @PersonID;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

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


        public static bool DeletePerson(int ID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = "DELETE People WHERE PersonID = @ID";

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

        public static bool IsPersonExist(String NationalNumber)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"SELECT 1 FROM People WHERE NationalNo = @NationalNo";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNumber);

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
