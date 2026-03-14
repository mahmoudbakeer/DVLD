using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class clsTestAppointmentsDataAccess
    {

        public static bool GetTestAppointmentByID(
           int TestAppointmentID,
       ref int CreatedaByUserID,
       ref int LocalDrivingLicenseApplicationID,
       ref int TestClassID,
       ref DateTime AppointmentDate,
       ref decimal PaidFees,
       ref bool IsLocked,
       ref int RetakeTestApplicationID)
        {
            bool isFound = false;

            string query =
            "select * from TestAppointments where TestAppointment = @TestAppointmentID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                CreatedaByUserID = (int)reader["CreatedByUser"];
                                TestClassID = (int)reader["TestClassID"];
                                AppointmentDate= (DateTime)reader["AppointmentDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                IsLocked= (bool)reader["IsLocked"];
                                RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                if (reader["RetakeTestApplicationID"] == DBNull.Value)
                                    RetakeTestApplicationID = -1;
                                else
                                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
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
        public static bool GetlastTestAppointment(
       ref int TestAppointmentID,
       ref int CreatedaByUserID,
       int LocalDrivingLicenseApplicationID,
       int TestClassID,
       ref DateTime AppointmentDate,
       ref decimal PaidFees,
       ref bool IsLocked,
       ref int RetakeTestApplicationID)
        {
            bool isFound = false;

            string query =
            "select top 1 * from TestAppointments where (TestClassID = @TestClassID) and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestClassID", TestClassID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                CreatedaByUserID = (int)reader["CreatedByUser"];
                                TestClassID = (int)reader["TestClassID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                IsLocked = (bool)reader["IsLocked"];
                                RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                if (reader["RetakeTestApplicationID"] == DBNull.Value)
                                    RetakeTestApplicationID = -1;
                                else
                                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
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

        public static int AddNewTestAppointment(
            int CreatedaByUserID,
            int LocalDrivingLicenseApplicationID,
            int TestClassID,
            DateTime AppointmentDate,
            decimal PaidFees,
            bool IsLocked,
            int RetakeTestApplicationID)
        {
            int ApplicationID = -1;

            string query = @"INSERT INTO TestAppointments 
                     (CreatedaByUserID, LocalDrivingLicenseApplicationID, TestClassID, AppointmentDate, PaidFees, IsLocked, RetakeTestApplicationID)
                     VALUES 
                     (@CreatedaByUserID, @LocalDrivingLicenseApplicationID, @TestClassID, @AppointmentDate, @PaidFees, @IsLocked, @RetakeTestApplicationID);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CreatedaByUserID", CreatedaByUserID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestClassID", TestClassID);
                command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
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

        public static bool UpdateTestAppointment(
            int TestAppointmentID,
            int CreatedaByUserID,
            int LocalDrivingLicenseApplicationID,
            int TestClassID,
            DateTime AppointmentDate,
            decimal PaidFees,
            bool IsLocked,
            int RetakeTestApplicationID)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Update  TestAppointments  
                            set CreatedaByUserID = @CreatedaByUserID, 
                            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID, 
                            TestClassID = @TestClassID, 
                            AppointmentDate = @AppointmentDate, 
                            IsLocked = @IsLocked, 
                            PaidFees = @PaidFees, 
                            RetakeTestApplicationID = @RetakeTestApplicationID
                            where TestAppointmentID = @TestAppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                        command.Parameters.AddWithValue("@CreatedaByUserID", CreatedaByUserID);
                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestClassID", TestClassID);
                        command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@IsLocked", IsLocked);
                        command.Parameters.AddWithValue("@RetakeTestApplicationID",
                            RetakeTestApplicationID == -1 ? (object)DBNull.Value : RetakeTestApplicationID); rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error :" + ex.ToString());
                    }

                }
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetAllTestAppointmentsPerTestType(int ApplicationID,int TestType)
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT TestAppointmentID as 'Appointment ID', AppointmentDate as 'Appointment Date',PaidFees as 'Paid Fees',IsLocked as 'Is Locked' FROM TestAppointments where (TestClassID = @TestClassID) and LocalDrivingLicenseID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    connection.Open();
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@TestClassID", TestType);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)

                    {
                        dt.Load(reader);
                    }
                }

            }
            return dt;

        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Delete from TestAppointments
                                where TestAppointmentID = @TestAppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (SqlException ex) when (ex.Number == 547)
                    {
                        // Foreign key violation
                        return false;
                    }
                    catch (SqlException)
                    {
                        throw; // preserve stack trace
                    }

                }
            }

            return (rowsAffected > 0);

        }
        public static bool IsTestAppointmentExist(int LocalDrivingLicenseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT Found=1 FROM TestAppointments WHERE TestAppointmentID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            isFound = reader.HasRows;
                        }

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return TestID;

        }
    }
}
