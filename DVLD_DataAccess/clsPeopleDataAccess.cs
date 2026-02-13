using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class clsPeopleDataAccess
    {
        public static bool GetPersonByID(
    int PersonID,
    ref string FirstName,
    ref string SecondName,
    ref string ThirdName,
    ref string LastName,
    ref string Email,
    ref string Phone,
    ref string Address,
    ref DateTime DateOfBirth,
    ref int NationalityCountryID,
    ref string NationalNo,
    ref string ImagePath)
        {
            bool isFound = false;

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

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

                                FirstName = reader["FirstName"] as string ?? "";
                                SecondName = reader["SecondName"] as string ?? "";
                                ThirdName = reader["ThirdName"] as string ?? "";
                                LastName = reader["LastName"] as string ?? "";
                                Email = reader["Email"] as string ?? "";
                                Phone = reader["Phone"] as string ?? "";
                                Address = reader["Address"] as string ?? "";
                                NationalNo = reader["NationalNo"] as string ?? "";

                                DateOfBirth = reader["DateOfBirth"] != DBNull.Value
                                    ? (DateTime)reader["DateOfBirth"]
                                    : DateTime.MinValue;

                                NationalityCountryID = reader["NationalityCountryID"] != DBNull.Value
                                    ? (int)reader["NationalityCountryID"]
                                    : -1;

                                ImagePath = reader["ImagePath"] as string ?? "";
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
        public static int AddNewPerson(
            string FirstName,
            string SecondName,
            string ThirdName,
            string LastName,
            string Email, 
            string Phone, 
            string Address,
            DateTime DateOfBirth, 
            int NationalityCountryID,
            string NationalNo, 
            string ImagePath)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int PersonID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) {

                string query = @"INSERT INTO People (FirstName,SecondName,ThirdName, LastName, Email, Phone, Address,DateOfBirth, NationalityCountryID,NationalNo,ImagePath)
                             VALUES (@FirstName,@SecondName,@ThirdName, @LastName, @Email, @Phone, @Address,@DateOfBirth, @NationalityCountryID,@NationalNo,@ImagePath);
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@NationalitCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    if (ImagePath != "" && ImagePath != null)
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    else
                        command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            PersonID = insertedID;
                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine("Error : " + ex.ToString());
                    }
                    
                }

            }


            return PersonID;
        }

        public static bool UpdatePerson(
            int PersonID, 
            string FirstName, 
            string SecondName, 
            string ThirdName,
            string LastName,
            string Email, 
            string Phone, 
            string Address, 
            DateTime DateOfBirth, 
            int NationalityCountryID, 
            string NationalNo,
            string ImagePath)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) {

                string query = @"Update  People  
                            set FirstName = @FirstName, 
                            SecondName = @SecondName, 
                            ThirdName = @ThirdName, 
                            LastName = @LastName, 
                            Email = @Email, 
                            Phone = @Phone, 
                            Address = @Address, 
                            DateOfBirth = @DateOfBirth,
                            NationalityCountryID = @NationalityCountryID,
                            NationalNo = @NationalNo,
                            ImagePath =@ImagePath
                            where PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@SecondName", SecondName);
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        if (ImagePath != "" && ImagePath != null)
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        else
                            command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
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

        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM People";

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

        public static bool DeletePerson(int PersonID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Delete People 
                                where PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);

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
        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)){

                string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);

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

