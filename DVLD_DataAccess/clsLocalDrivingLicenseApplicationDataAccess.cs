using System;
using System.Collections.Generic;
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
        public static bool GetLocalDrivingLicenseApplicationByID(int ID , ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);

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
            return 0;
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

                        COUNT(DISTINCT CASE 
                            WHEN T.TestResult = 1 
                            THEN TA.TestAppointmentID 
                        END) AS [Passed Tests],

                        CASE 
                            WHEN A.ApplicationStatus = 1 THEN 'New'
                            WHEN A.ApplicationStatus = 2 THEN 'Canceled'
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
    }
}
