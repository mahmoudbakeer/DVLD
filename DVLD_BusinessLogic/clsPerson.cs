using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsPerson
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }
        public int NationalityCountryID { set; get; }
        public string ImagePath { set; get; }
        public string Gendor {  set; get; }
        public string NationalNo { set; get; }

       

        public clsPerson()

        {
            this.ID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.NationalityCountryID = -1;
            this.NationalNo = "";
            this.ImagePath = "";
            this.Gendor = "";
            Mode = enMode.AddNew;

        }

        private clsPerson(int ID, 
            string FirstName, 
            string LastName,
            string SecondName, 
            string ThirdName,
            string Email, 
            string Phone, 
            string Address, 
            DateTime DateOfBirth,
            int NationalityCountryID, 
            string NationalNo,
            string ImagePath)

        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.NationalNo = NationalNo;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;

        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.ID = clsPeopleDataAccess.AddNewPerson(FirstName,
             SecondName,
             ThirdName,
             LastName,
             Email,
             Phone,
             Address,
             DateOfBirth,
             NationalityCountryID,
             NationalNo,
             ImagePath,
             Gendor);

            return (this.ID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPeopleDataAccess.UpdatePerson( ID,
             FirstName,
             SecondName,
             ThirdName,
             LastName,
             Email,
             Phone,
             Address,
             DateOfBirth,
             NationalityCountryID,
             NationalNo,
             ImagePath,Gendor);

        }

        public static clsPerson Find(int ID)
        {

            string FirstName = "",SecondName = "" , ThirdName = "" , LastName = "", Email = "", Phone = "", Address = "", ImagePath = "" , NationalNo = "",Gendor = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;

            if (clsPeopleDataAccess.GetPersonByID(ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                          ref Email, ref Phone, ref Address, ref DateOfBirth, ref NationalityCountryID,ref NationalNo, ref ImagePath,ref Gendor))

                return new clsPerson(ID,
             FirstName,
             SecondName,
             ThirdName,
             LastName,
             Email,
             Phone,
             Address,
             DateOfBirth,
             NationalityCountryID,
             NationalNo,
             ImagePath);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }




            return false;
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPeople();

        }

        public static bool DeletePerson(int ID)
        {
            return clsPeopleDataAccess.DeletePerson(ID);
        }

        public static bool isPersonExist(int ID)
        {
            return clsPeopleDataAccess.IsPersonExist(ID);
        }
        public static bool isPersonExist(string NationalNo)
        {
            return clsPeopleDataAccess.IsPersonExist(NationalNo);
        }

    }
}
