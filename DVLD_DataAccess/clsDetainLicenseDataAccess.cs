using Microsoft.SqlServer.Server;
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
    public static class clsDetainLicenseDataAccess
    {
        public static bool GetDetainByID(
      int DetainedID,
      ref int LicenseID,
      ref DateTime DetainDate,
      ref DateTime ReleaseDate,
      ref int CreatedByUserID,
      ref int ReleasedByUserID,
      ref int ReleaseApplicationID,
      ref decimal FineFees,
      ref bool IsReleased)
        {
            bool isFound = false;

            string query =
                "select * from DetainedLicenses where DetainedID= @DeteinedID and IsReleased = 0;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DeteinedID", DetainedID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                LicenseID = (int)reader["LicenseID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                                ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
                                FineFees = (decimal)reader["FineFees"];
                                IsReleased = (bool)reader["IsRealesed"];
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
        public static bool GetDetainByLicesneID(
     ref int DetainedID,
     int LicenseID,
     ref DateTime DetainDate,
     ref DateTime ReleaseDate,
     ref int CreatedByUserID,
     ref int ReleasedByUserID,
     ref int ReleaseApplicationID,
     ref decimal FineFees,
     ref bool IsReleased)
        {
            bool isFound = false;

            string query =
                "select * from DetainedLicenses where LicenseID= @LicenseID and IsReleased = 0;";

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
                                DetainedID = (int)reader["DetainedID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                                ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
                                FineFees = (decimal)reader["FineFees"];
                                IsReleased = (bool)reader["IsReleased"];
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
        public static int AddNewDetain(
       int LicenseID,
      DateTime DetainDate,
      int CreatedByUserID,
      decimal FineFees)
        {
            int licenseID = -1;

            string query = @"INSERT INTO DetainedLicenses 
        (LicenseID, DetainDate, CreatedByUserID,FineFees,IsReleased)
        VALUES 
        (@LicenseID, @DetainDate, @CreatedByUserID, @FineFees,@IsReleased);
        SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@DetainDate", DetainDate);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@FineFees", FineFees);
                command.Parameters.AddWithValue("@IsReleased", false);
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
     //   public static int GetLicenseByApplicationID(
     //int LocalDrivingLicenseApplicationID)
     //   {
     //       int licenseID = -1;

     //       string query = @"SELECT LicenseID from Licenses where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

     //       using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
     //       using (SqlCommand command = new SqlCommand(query, connection))
     //       {
     //           command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
     //           try
     //           {
     //               connection.Open();
     //               object result = command.ExecuteScalar();

     //               if (result != null && result != DBNull.Value)
     //               {
     //                   licenseID = Convert.ToInt32(result);
     //               }
     //           }
     //           catch (Exception ex)
     //           {
     //               Console.WriteLine("Error: " + ex.Message);
     //           }
     //       }

     //       return licenseID;
     //   }
        public static bool UpdateDetainLicense(
          int DetainedID,
          int LicenseID,
          DateTime DetainDate,
          DateTime ReleaseDate,
          int CreatedByUserID,
          int ReleasedByUserID,
          int ReleaseApplicationID,
          decimal FineFees,
          bool IsReleased)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update  DetainedLicenses  
                            set LicenseID = @LicenseID, 
                            DetainDate = @DetainDate, 
                            ReleaseDate = @ReleaseDate, 
                            CreatedByUserID = @CreatedByUserID, 
                            ReleasedByUserID = @ReleasedByUserID, 
                            ReleaseApplicationID = @ReleaseApplicationID,                           
                            FineFees = @FineFees, 
                            IsReleased = @IsReleased 
                            where DetainedID = @DetainedID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@DetainedID", DetainedID);
                        command.Parameters.AddWithValue("@DetainDate", DetainDate);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                        command.Parameters.AddWithValue("@FineFees", FineFees);
                        command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error :" + ex.ToString());
                        clsEventLogger.LogError(ex.Message);

                    }

                }
            }

            return (rowsAffected > 0);
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsFound = false;
            string query = @"SELECT FOUND =1 from DetainedLicenses where LicenseID = @LicenseID and IsReleased = 0;";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            IsFound = true;
                        }
                    }
                }
            }
           return IsFound;
        }
        public static DataTable GetAllDetainLicenses()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                                SELECT 
                                DL.DetainedID AS 'D.ID',
                                DL.LicenseID AS 'L.ID',
                                DL.DetainDate AS 'D.Date',
                                DL.IsReleased AS 'Is Released',
                                DL.FineFees AS 'Fine Fees',
                                DL.ReleaseDate AS 'Release Date',
                                P.NationalNo as 'N.NO',
                                P.FirstName + ' ' + P.LastName AS 'Full Name',
                                DL.ReleaseApplicationID AS 'App.ID'
                                FROM DetainedLicenses DL
                                JOIN Licenses L ON DL.LicenseID = L.LicenseID
                                JOIN Drivers D ON L.DriverID = D.DriverID
                                JOIN People P ON D.PersonID = P.PersonID;";
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
    }
}
