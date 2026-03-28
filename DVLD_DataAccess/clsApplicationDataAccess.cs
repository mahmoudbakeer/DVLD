using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class clsApplicationDataAccess
    {
       
            public static bool GetApplicationByID(
        int ApplicationID,
        ref DateTime ApplicationDate,
        ref int ApplicationStatus,
        ref int ApplicantPersonID,
        ref int CreatedByUserID,
        ref int ApplicationTypeID,
        ref decimal PaidFees,
        ref DateTime lastStatusDate)
            {
                bool isFound = false;

                string query =
                "select * from Applications where ApplicationID = @ApplicationID;";

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        try
                        {
                            connection.Open();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    isFound = true;

                                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                                    ApplicationStatus = (int)reader["ApplicationStatus"];
                                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                                    CreatedByUserID = (int)reader["CreatedByUserID"] ;
                                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                                    PaidFees= (decimal)reader["PaidFees"];
                                    lastStatusDate = (DateTime)reader["LastStatusDate"];
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

        public static int AddNewApplication(
            DateTime ApplicationDate,
            int ApplicationStatus,
            int ApplicantPersonID,
            int CreatedByUserID,
            int ApplicationTypeID,
            decimal PaidFees,
            DateTime lastStatusDate)
        {
            int ApplicationID = -1;

            string query = @"INSERT INTO Applications 
                     (ApplicationDate, ApplicationStatus, ApplicantPersonID, CreatedByUserID, ApplicationTypeID, PaidFees, LastStatusDate)
                     VALUES 
                     (@ApplicationDate, @ApplicationStatus, @ApplicantPersonID, @CreatedByUserID, @ApplicationTypeID, @PaidFees, @LastStatusDate);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationDate", SqlDbType.DateTime).Value = ApplicationDate;
                command.Parameters.Add("@ApplicationStatus", SqlDbType.Int).Value = ApplicationStatus;
                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = ApplicantPersonID;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;
                command.Parameters.Add("@PaidFees", SqlDbType.Decimal).Value = PaidFees;
                command.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = lastStatusDate;

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

        public static bool UpdateApplications(
                int ApplicationID,
        DateTime ApplicationDate,
        int ApplicationStatus,
        int ApplicantPersonID,
        int CreatedByUserID,
        int ApplicationTypeID,
        decimal PaidFees,
        DateTime LastStatusDate)
            {

                int rowsAffected = 0;
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"Update  Applications  
                            set ApplicationDate = @ApplicationDate, 
                            ApplicationStatus = @ApplicationStatus, 
                            ApplicantPersonID = @ApplicantPersonID, 
                            CreatedByUserID = @CreatedByUserID, 
                            ApplicationTypeID = @ApplicationTypeID, 
                            PaidFees = @PaidFees, 
                            LastStatusDate = @LastStatusDate
                            where ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                            command.Parameters.AddWithValue("@PaidFees", PaidFees);
                            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                            rowsAffected = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                        clsEventLogger.LogError(ex.Message);

                    }

                }
                }

                return (rowsAffected > 0);
            }
        public static bool UpdateStatus(
            int ApplicationID,
            int ApplicationStatus)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Update  Applications  
                            set ApplicationStatus = @ApplicationStatus
                             where ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsEventLogger.LogError(ex.Message);
                    }

                }
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetAllApplicaions()
            {

                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = "SELECT ApplicationID, ApplicationDate,ApplicationStatus,ApplicantPersonID, CreatedByUserID, ApplicationTypeID, PaidFees, LastStatusDate FROM Applications";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)

                        {
                            dt.Load(reader);
                        }
                    }

                }
                return dt;

            }

            public static bool DeleteApplication(int ApplicationID)
            {

                int rowsAffected = 0;

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"Delete Applications 
                                where ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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
                        catch (SqlException)
                        {
                            throw; // preserve stack trace

                    }

                }
                }

                return (rowsAffected > 0);

            }
            public static bool IsApplicationExist(int ApplicationID)
            {
                bool isFound = false;

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = "SELECT Found=1 FROM Applications WHERE ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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
                                clsEventLogger.LogError(ex.Message);

                                isFound = false;
                        }
                    }
                }

                return isFound;
            }
            public static int GetActiveApplicationID(int ApplicatntPersonID , int ApplicationTypeID)
            {
                int ApplicationID = -1;
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"SELECT ActiveApplicationID = Applications.ApplicationID FROM Applications WHERE ApplicantPersonID = @ApplicantPersonID and ApplicationTypeID = @ApplicationTypeID and ApplicationStatus = 1;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ApplicantPersonID", ApplicatntPersonID);
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int insertedID))
                            {
                                ApplicationID = insertedID;
                            }
                        }
                        catch (Exception ex)
                        {
                                clsEventLogger.LogError(ex.Message);
                                Console.WriteLine("Error : " + ex.ToString());
                        }

                    }

                }
                return ApplicationID;
            }
    }
}
