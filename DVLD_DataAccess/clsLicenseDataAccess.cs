using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DataAccess
{
    public class clsLicenseDataAccess
    {
        public static bool GetLicenseByID(
       int LicenseID,
       ref int LicenseClassID,
       ref DateTime IssueDate,
       ref DateTime ExpirationDate,
       ref int CreatedByUserID,
       ref int DriverID,
       ref int ApplicationID,
       ref decimal PaidFees,
       ref bool IsActive,
       ref string Notes,
       ref string IssueReason)
        {
            bool isFound = false;

            string query =
            "select * from Licenses where LicenseID= @LicenseID;";

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

                                LicenseClassID = (int)reader["LicenseClassID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                DriverID = (int)reader["DriverID"];
                                ApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                PaidFees = (decimal)reader["PaidFees"];
                                IsActive = (bool)reader["IsActive"];
                                Notes = (reader["Notes"] == DBNull.Value) ? string.Empty : (string)reader["Notes"];
                                IssueReason = (reader["IssueReason"] == DBNull.Value) ? string.Empty : (string)reader["IssueReason"];
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

        public static int AddNewLicense(
     int LicenseClassID,
     DateTime IssueDate,
     DateTime ExpirationDate,
     int CreatedByUserID,
     int DriverID,
     int LocalDrivingLicenseApplicationID,
     decimal PaidFees,
     bool IsActive,
     string Notes,
     string IssueReason)
        {
            int licenseID = -1;

            string query = @"INSERT INTO Licenses 
        (LicenseClassID, IssueDate, ExpirationDate, CreatedByUserID, DriverID, 
         LocalDrivingLicenseApplicationID, PaidFees, IsActive, Notes, IssueReason)
        VALUES 
        (@LicenseClassID, @IssueDate, @ExpirationDate, @CreatedByUserID, @DriverID, 
         @LocalDrivingLicenseApplicationID, @PaidFees, @IsActive, @Notes, @IssueReason);

        SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                command.Parameters.AddWithValue("@Notes",
                    string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);

                command.Parameters.AddWithValue("@IssueReason",
                    string.IsNullOrEmpty(IssueReason) ? (object)DBNull.Value : IssueReason);

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
                }
            }

            return licenseID;
        }
        public static int GetLicenseByApplicationID(
     int LocalDrivingLicenseApplicationID)
        {
            int licenseID = -1;

            string query = @"SELECT LicenseID from Licenses where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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
                }
            }

            return licenseID;
        }
        public static bool UpdateLicense(
                int LicenseID,
                int LicenseClassID,
                DateTime IssueDate,
                DateTime ExpirationDate,
                int CreatedByUserID,
                int DriverID,
                int ApplicationID,
                decimal PaidFees,
                bool IsActive,
                string Notes,
                string IssueReason)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update  Licenses  
                            set LicenseClassID = @LicenseClassID, 
                            IssueDate = @IssueDate, 
                            ExpirationDate = @ExpirationDate, 
                            CreatedByUserID = @CreatedByUserID, 
                            LocalDrivingLicenseApplicationID = @ApplicationID, 
                            PaidFees = @PaidFees,                           
                            DriverID = @DriverID, 
                            IsActive = @IsActive,
                            Notes = @Notes,
                            IssueReason = @IssueReason 
                            where LicenseID = @LicenseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@Notes", (Notes == string.Empty) ? (object)DBNull.Value : IssueReason);
                        command.Parameters.AddWithValue("@IssueReason", (IssueReason == string.Empty) ? (object)DBNull.Value : IssueReason);
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
        public static DataTable GetAllLicenses()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "select * from Licenses";

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
        public static DataTable GetAllLicensesForPersonID(int PersonID)
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                        L.LicenseID AS [Lic.ID],
                            L.LocalDrivingLicenseApplicationID AS [App.ID],
                        LC.ClassName AS [Class Name],
                        L.IssueDate AS [Issue Date],
                        L.ExpirationDate AS [Expiration Date],
                        L.IsActive AS [Is Active]
                        FROM Licenses L
                        INNER JOIN LicenseClasses LC 
                        ON LC.LicenseClassID = L.LicenseClassID
                        INNER JOIN Drivers D 
                        ON D.DriverID = L.DriverID
                        WHERE D.PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;

        }
        public static bool DeleteLicense(int LicenseID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Delete from Licenses 
                                where LicenseID = @LicenseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
         public static bool DoesPersonHaveUnExpiredLicenseOfSameType(int PersonID , int LicenseID , int LicenseClassID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT 1 
                                WHERE EXISTS (
                                    SELECT 1
                                    FROM Licenses L 
                                    JOIN Drivers D ON L.DriverID = D.DriverID 
                                    WHERE D.PersonID = @PersonID 
                                    AND L.LicenseClassID = @LicenseClassID 
                                    AND L.LicenseID <> @LicenseID 
                                    AND CAST(L.ExpirationDate AS DATE) > CAST(GETDATE() AS DATE)
                                )";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

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


    }
}
