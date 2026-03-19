using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationDataAccess
    {
        public static bool GetLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID , ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ApplicationID = (int)reader["ApplicationID"];
                            LicenseClassID = (int)reader["LicenseClassID"];
                        }
                    }
                }
            }
            return isFound;
        }
        public static bool UpdateLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID,  int ApplicationID,  int LicenseClassID)
        {
            int rowsAffected = -1;
            string query = "Update LocalDrivingLicenseApplications set ApplicationID = @ApplicationID , LicenseClassID = @LicenseClassID where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID; ";
            


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    rowsAffected = command.ExecuteNonQuery();
                    
                }
            }
            return (rowsAffected > 0);
        }
        public static int AddNewLocalDrivingLicenseApplication( int ApplicationID , int LicenseClassID) {
            int LDLID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID,LicenseClassID)
                             VALUES (@ApplicationID,@LicenseClassID);
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            LDLID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.ToString());
                    }

                }
            }

            return LDLID;
        }
        public static DataTable GetAllLocalDrivingApplications()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT 
                        LDL.LocalDrivingLicenseApplicationID AS [L.D.LAppID], 
                        LC.ClassName AS [Driving Class], 
                        P.NationalNo,

                        (P.FirstName + ' ' +
                         P.SecondName + ' ' +
                         P.ThirdName + ' ' +
                         P.LastName) AS [Full Name],

                        A.ApplicationDate,

                        COUNT(DISTINCT 
                                       CASE 
                                            WHEN T.TestResult = 1 
                                            THEN TA.TestAppointmentID 
                                       END
                                                ) AS [Passed Tests],

                        CASE 
                            WHEN A.ApplicationStatus = 1 THEN 'New'
                            WHEN A.ApplicationStatus = 2 THEN 'Cancelled'
                            WHEN A.ApplicationStatus = 3 THEN 'Completed'
                        END AS Status

                    FROM LocalDrivingLicenseApplications LDL

                    LEFT JOIN Applications A
                        ON LDL.ApplicationID = A.ApplicationID

                    LEFT JOIN LicenseClasses LC
                        ON LDL.LicenseClassID = LC.LicenseClassID

                    LEFT JOIN People P
                        ON A.ApplicantPersonID = P.PersonID

                    LEFT JOIN TestAppointments TA
                        ON LDL.LocalDrivingLicenseApplicationID =
                           TA.LocalDrivingLicenseApplicationID

                    LEFT JOIN Tests T
                        ON TA.TestAppointmentID = T.TestAppointmentID

                    GROUP BY 
                        LDL.LocalDrivingLicenseApplicationID,
                        LC.ClassName,
                        P.NationalNo,
                        (P.FirstName + ' ' +
                         P.SecondName + ' ' +
                         P.ThirdName + ' ' +
                         P.LastName),
                        A.ApplicationDate,
                        A.ApplicationStatus;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
           int rowsAffected = -1;


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE From LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
        public static bool isLocalDrivingLiCenseApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = -1;


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Select Fount = 1 from LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
        public static bool DoesPersonHaveUncompletedApplicationForSameLicenseClass(int PersonID, int LicenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1
                         FROM LocalDrivingLicenseApplications L
                         INNER JOIN Applications A 
                         ON A.ApplicationID = L.ApplicationID
                         WHERE A.ApplicantPersonID = @PersonID 
                         AND L.LicenseClassID = @LicenseClassID 
                         AND A.ApplicationStatus = 1;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    return result != null;
                }
            }
        }
        public static bool DoesThisPersonAttendTheTest(int LocalDrivingLicenseApplicationID, int TestClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT COUNT(*) 
                         FROM TestAppointments TA
                         JOIN Tests T
                         ON TA.TestAppointmentID = T.TestAppointmentID
                         WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                         AND TA.TestClassID = @TestClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestClassID", TestClassID);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        public static int HowManyTestsDidHeAttended(int LocalDrivingLicenseApplicationID, int TestClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT COUNT(*) 
                         FROM TestAppointments TA
                         JOIN Tests T
                         ON TA.TestAppointmentID = T.TestAppointmentID
                         WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                         AND TA.TestClassID = @TestClassID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestClassID", TestClassID);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    return count;
                }
            }
        }
        public static bool DoesApplicationHaveActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT COUNT(*) 
                         FROM TestAppointments
                         WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                           AND TestClassID = @TestClassID
                           AND IsLocked = 0;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestClassID", TestClassID);

                    connection.Open();

                    int count = (int)command.ExecuteScalar(); // returns the COUNT(*)

                    return count > 0;
                }
            }
        }
        
        public static bool DoesThisPersonPassTheTest(int LocalDrivingLicenseApplicationID, int TestClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT COUNT(*) 
                         FROM TestAppointments TA
                         JOIN Tests T
                         ON TA.TestAppointmentID = T.TestAppointmentID
                         WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                         AND TA.TestClassID = @TestClassID and T.TestResult = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestClassID", TestClassID);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        
        public static bool DoesThisPersonHaveActiveLicense(int PersonID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select count(*) from Licenses L join Drivers D on L.DriverID = D.DriverID where D.PersonID = @PersonID and L.IsActive =1;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        public static bool DoesThisPersonHaveLicenseOfSameClass(int PersonID,int LicenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select count(*) from Licenses L join Drivers D on L.DriverID = D.DriverID where D.PersonID = @PersonID and L.LicenseClassID = @LicenseClassID and L.IsActive =1;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        public static int HowManyTestsDidHePass(int LocalDrivingLicenseApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT COUNT(*) 
                         FROM TestAppointments TA
                         INNER JOIN Tests T
                         ON TA.TestAppointmentID = T.TestAppointmentID
                         WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                         AND T.TestResult = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    return count;
                }
            }
        }
    }
}
