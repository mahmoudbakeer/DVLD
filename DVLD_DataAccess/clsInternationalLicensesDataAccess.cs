using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsInternationalLicensesDataAccess
    {
        public static bool GetInternationalLicenseByID(
       int InternationalLicenseID,
       ref int LicenseID,
       ref DateTime IssueDate,
       ref DateTime ExpirationDate,
       ref int CreatedByUserID,
       ref int DriverID,
       ref int ApplicationID,
       ref bool IsActive)
        {
            bool isFound = false;

            string query =
            "select * from InternationalLicenses where InternationalLicenseID = @InternationalLicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                LicenseID = (int)reader["LicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                DriverID = (int)reader["DriverID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error :" + ex.Message);
                        clsEventLogger.LogError(ex.Message);
                    }
                }
            }

            return isFound;
        }
        public static bool GetInternationalLicenseByLicesneID(
       ref int InternationalLicenseID,
       int LicenseID,
       ref DateTime IssueDate,
       ref DateTime ExpirationDate,
       ref int CreatedByUserID,
       ref int DriverID,
       ref int ApplicationID,
       ref bool IsActive)
        {
            bool isFound = false;

            string query =
            "select * from InternationalLicenses where LicenseID = @LicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                InternationalLicenseID = (int)reader["InternationalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                DriverID = (int)reader["DriverID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error :" + ex.Message);
                        clsEventLogger.LogError(ex.Message);
                    }
                }
            }

            return isFound;
        }
        public static int AddNewLicense(
     int LicenseID,
     DateTime IssueDate,
     DateTime ExpirationDate,
     int CreatedByUserID,
     int DriverID,
     int ApplicationID,
     bool IsActive)
        {
            int licenseID = -1;

            string query = @"INSERT INTO InternationalLicenses 
        (LicenseID, IssueDate, ExpirationDate, CreatedByUserID, DriverID, 
         ApplicationID, IsActive)
        VALUES 
        (@LicenseID, @IssueDate, @ExpirationDate, @CreatedByUserID, @DriverID, 
         @ApplicationID, @IsActive);
        SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        licenseID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    clsEventLogger.LogError(ex.Message);
                }
            }

            return licenseID;
        }
        public static bool IsLicenseHasInternationalLicnese(int LicenseID)
        {
            bool IsFound = false;
            string query = "select FOUND = 1 from InternationalLicenses where LicenseID = @LicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IsFound = reader.HasRows;
                    }
                }
            }
            return IsFound;
        }
        public static DataTable GetAllLicensesForPerson(int PersonID)
        {
            DataTable table = new DataTable();
            string query = "SELECT InternationalLicenseID as 'Int.License ID' , LicenseID as 'License ID' , InternationalLicenses.ApplicationID as 'App.ID' , IssueDate as 'Issue Date' , ExpirationDate as 'Exp.Date' , IsActive as 'Is Active' from InternationalLicenses join Applications on Applications.ApplicationID = InternationalLicenses.ApplicationID where Applications.ApplicantPersonID = @PersonID;";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }
            return table;
        }
        
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable table = new DataTable();
            string query = "select InternationalLicenseID as 'Int.License ID' , LicenseID as 'License ID' ,DriverID as 'Driver ID',ApplicationID as 'App.ID' , IssueDate as 'Issue Date' , ExpirationDate as 'Exp.Date' , IsActive as 'Is Active' from InternationalLicenses;";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }
            return table;
        }
    }
}
