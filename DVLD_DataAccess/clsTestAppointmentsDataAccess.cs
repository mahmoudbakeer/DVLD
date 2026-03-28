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
            "select * from TestAppointments where TestAppointmentID = @TestAppointmentID;";

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

                                CreatedaByUserID = (int)reader["CreatedByUserID"];
                                TestClassID = (int)reader["TestClassID"];
                                AppointmentDate= (DateTime)reader["AppointmentDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                IsLocked= (bool)reader["IsLocked"];
                                RetakeTestApplicationID = reader["RetakeTestApplicationID"] == DBNull.Value ? -1 : (int)reader["RetakeTestApplicationID"];
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
                        clsEventLogger.LogError(ex.Message);

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
                        clsEventLogger.LogError(ex.Message);

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
                     (CreatedByUserID, LocalDrivingLicenseApplicationID, TestClassID, AppointmentDate, PaidFees, IsLocked, RetakeTestApplicationID)
                     VALUES 
                     (@CreatedByUserID, @LocalDrivingLicenseApplicationID, @TestClassID, @AppointmentDate, @PaidFees, @IsLocked, @RetakeTestApplicationID);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedaByUserID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestClassID", TestClassID);
                command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);
                command.Parameters.AddWithValue(
                "@RetakeTestApplicationID",
                 RetakeTestApplicationID == -1 ? (object)DBNull.Value : RetakeTestApplicationID
);
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
                    clsEventLogger.LogError(ex.Message);

                }
            }

            return ApplicationID;
        }

        public static bool UpdateTestAppointment(
            int TestAppointmentID,
            int CreatedByUserID,
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
                            set CreatedByUserID = @CreatedByUserID, 
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
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
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
                        clsEventLogger.LogError(ex.Message);

                    }

                }
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetAllTestAppointmentsPerTestType(int ApplicationID, int TestType)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                            TestAppointmentID AS [Appointment ID], 
                            AppointmentDate AS [Appointment Date],
                            PaidFees AS [Paid Fees],
                            IsLocked AS [Is Locked]
                         FROM TestAppointments
                         WHERE TestClassID = @TestClassID 
                         AND LocalDrivingLicenseApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                    command.Parameters.Add("@TestClassID", SqlDbType.Int).Value = TestType;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader); // no condition
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
                        clsEventLogger.LogError(ex.Message);

                        return false;
                    }
                    catch (SqlException ex)
                    {
                        clsEventLogger.LogError(ex.Message);

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
                        clsEventLogger.LogError(ex.Message);

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
                 clsEventLogger.LogError(ex.Message);


            }

            finally
            {
                connection.Close();
            }


            return TestID;

        }
        public static bool IsAppointmentLocked(int TestAppointmentID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT COUNT(*) 
                         FROM TestAppointments where IsLocked = 1 and TestAppointmentID = @TestAppointmentID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
    }
}
