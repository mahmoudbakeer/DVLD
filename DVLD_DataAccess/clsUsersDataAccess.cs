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
    public static class clsUsersDataAccess
    {
        public static bool GetUserByID(
    int UserID,
    ref int PersonID,
    
    ref string UserName,
    ref string Password,
    ref bool IsActive
   )
        {
            bool isFound = false;

            string query =
            "SELECT PersonID, UserName, Password ,IsActive " +
            "FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                PersonID = (int)reader["PersonID"];
                                UserName = reader["UserName"] as string ?? "";
                                Password = reader["Password"] as string ?? "";
                                IsActive = (bool)reader["IsActive"];

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

        public static int AddNewUser(
            int PersonID,
            string UserName,
            string Password,
            bool IsActive
            )
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int UserID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"INSERT INTO Users (PersonID,UserName,Password,IsActive)
                             VALUES (@PersonID,@UserName,@Password,@IsActive);
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            UserID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.ToString());
                    }

                }
            }


            return UserID;
        }

        public static bool UpdateUser(
            int UserID,
            string UserName,
            string Password,
            bool IsActive
            )
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {


                string query = @"Update  Users
                            set UserName = @UserName, 
                            Password = @Password, 
                            IsActive = @IsActive  
                            where UserID= @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@Password", Password);
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

        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT A.UserID , B.PersonID ,A.UserName , B.FirstName + ' ' +B.LastName AS FullName , A.IsActive " +
                                "FROM Users A Inner Join People B on A.PersonID = B.PersonID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)

                        {
                            dt.Load(reader);
                        }
                    }
                }

            }
            return dt;

        }

        public static bool DeleteUser(int UserID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Delete from Users
                                where UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@UserID", UserID);

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
        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@UserID", UserID);

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
