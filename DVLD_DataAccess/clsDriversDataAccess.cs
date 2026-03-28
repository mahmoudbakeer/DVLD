using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DataAccess
{
    public class clsDriversDataAccess
    {
        public static bool GetDriverByID(
        int DriverID,
        ref int PersonID,
        ref int CreatedByUserID,
        ref DateTime CreatedDate
       )
        {
            bool isFound = false;

            string query =
            "SELECT * from Drivers where DriverID = @DriverID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                PersonID = (int)reader["PersonID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
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
        public static bool GetDriverByPersonID(
        ref  int DriverID,
         int PersonID,
        ref int CreatedByUserID,
        ref DateTime CreatedDate)
        {
            bool isFound = false;

            string query =
            "SELECT * from Drivers where PersonID = @PersonID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                DriverID = (int)reader["DriverID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
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
        public static int AddNewDriver(
            int PersonID ,
            int CreatedByUserID,
            DateTime CreatedDate
            )
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int DriverID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Drivers (PersonID,CreatedByUserID,CreatedDate)
                             VALUES (@PersonID,@CreatedByUserID,@CreatedDate);
                             SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            DriverID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                        clsEventLogger.LogError(ex.Message);

                    }
                }

            }
            return DriverID;
        }
        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT 
                                 D.DriverID AS 'Driver ID',
                                 P.PersonID AS 'Person ID',
                                 P.NationalNo AS 'National No',
                                 (P.FirstName + ' ' + P.LastName) AS 'Person Name',
                                 D.CreatedDate AS 'Date',
                                 COUNT(L.LicenseID) AS 'Active Licenses'
                                FROM Drivers D
                                JOIN People P ON D.PersonID = P.PersonID
                                LEFT JOIN Licenses L
                                 ON L.DriverID = D.DriverID
                                 AND L.IsActive = 1
                                GROUP BY
                                 D.DriverID, P.PersonID, P.NationalNo,
                                 P.FirstName, P.LastName, D.CreatedDate;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        dt.Load(reader);
                }

            }
            return dt;

        }
        public static bool IsPersonDriver(int PersonID)
        {
            string query = @"SELECT CASE 
                     WHEN EXISTS (SELECT 1 FROM Drivers WHERE PersonID = @PersonID) 
                     THEN 1 ELSE 0 END";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);

                connection.Open();

                object obj = command.ExecuteScalar();

                return obj != null && obj != DBNull.Value && Convert.ToInt32(obj) == 1;
            }
        }
    }
}
