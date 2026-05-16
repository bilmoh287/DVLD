using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsInstitutePaymentData
    {
        public static int AddNewPayment(int InstituteID, int EnrollmentID, decimal AmountPaid, string ChapaTransactionRef, int CreatedByUserID)
        {
            int PaymentID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = @"
                        INSERT INTO InstitutePayments (InstituteID, EnrollmentID, AmountPaid, PaymentDate, ChapaTransactionRef, CreatedByUserID)
                        VALUES (@InstituteID, @EnrollmentID, @AmountPaid, GETDATE(), @ChapaTransactionRef, @CreatedByUserID);
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InstituteID", InstituteID);
                        command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
                        command.Parameters.AddWithValue("@AmountPaid", AmountPaid);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        
                        if (string.IsNullOrEmpty(ChapaTransactionRef))
                            command.Parameters.AddWithValue("@ChapaTransactionRef", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ChapaTransactionRef", ChapaTransactionRef);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            PaymentID = insertedID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding Institute Payment: " + ex.Message);
            }
            return PaymentID;
        }

        public static DataTable GetPaymentsByInstituteID(int InstituteID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = @"
                        SELECT p.PaymentID, p.EnrollmentID, c.CourseName, p.AmountPaid, p.PaymentDate, p.ChapaTransactionRef
                        FROM InstitutePayments p
                        INNER JOIN Enrollments e ON p.EnrollmentID = e.EnrollmentID
                        INNER JOIN InstituteCourses c ON e.CourseID = c.CourseID
                        WHERE p.InstituteID = @InstituteID
                        ORDER BY p.PaymentDate DESC";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InstituteID", InstituteID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching payments: " + ex.Message);
            }
            return dt;
        }
    }
}
