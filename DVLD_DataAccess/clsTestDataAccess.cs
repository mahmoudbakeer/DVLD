using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestDataAccess
    {
        public static bool GetTestByID(
       int TestID,
       ref int CreatedByUserID,
       ref string Notes,
       ref int TestAppointmentID ,
       ref bool TestResult )
        {
            bool isFound = false;

            string query =
            "select * from Tests where TestID = @TestID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestID", TestID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestResult = (bool)reader["TestResult"];
                                Notes = reader["Notes"] == DBNull.Value ? string.Empty : (string)reader["Notes"];
 
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error :" + ex.Message);
                    }
                }
            }

            return isFound;
        }
       

        public static int AddNewTest(
      int CreatedByUserID,
      string Notes,
      int TestAppointmentID,
      bool TestResult)
        {
            int ApplicationID = -1;

            string query = @"INSERT INTO Tests 
                     (TestResult, Notes, CreatedByUserID, TestAppointmentID)
                     VALUES 
                     (@TestResult, @Notes, @CreatedByUserID, @TestAppointmentID);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestResult", TestResult);
                command.Parameters.AddWithValue("@Notes", (Notes == string.Empty) ? (object)DBNull.Value : string.Empty);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        ApplicationID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    // Use a proper logging framework in production
                    Console.WriteLine("Error : " + ex.ToString());
                }
            }

            return ApplicationID;
        }

        public static bool UpdateTest(
       int TestID,
       int CreatedByUserID,
       string Notes,
       int TestAppointmentID,
       bool TestResult)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Update  Tests  
                            set CreatedByUserID = @CreatedByUserID, 
                            TestAppointmentID = @TestAppointmentID, 
                            Notes = @Notes, 
                            AppointmentDate = @AppointmentDate, 
                            TestResult = @TestResult, 
                            where TestID = @TestID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@TestResult", TestResult);
                        command.Parameters.AddWithValue("@TestID", TestID);
                        command.Parameters.AddWithValue("@Notes", (Notes == string.Empty) ? (object)DBNull.Value : string.Empty);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error :" + ex.ToString());
                    }

                }
            }

            return (rowsAffected > 0);
        }
    }
}
