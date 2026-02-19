using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsUser
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public int PersonID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        bool IsActive { set; get; }



        public clsUser(int PersonID)

        {
            this.ID = -1;
            this.PersonID = PersonID;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;
            Mode = enMode.AddNew;

        }

        private clsUser(int ID,
            int PersonID,
            string UserName,
            string Pssword,
            bool IsActive
            )

        {
            this.ID = ID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Pssword;
            this.IsActive = IsActive;
            Mode = enMode.Update;

        }

        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.ID = clsUsersDataAccess.AddNewUser(PersonID, UserName, Password, IsActive);

            return (this.ID != -1);
        }

        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUsersDataAccess.UpdateUser(ID, UserName, Password, IsActive);

        }

        public static clsUser Find(int ID)
        {

            int PersonID = -1;
            string UserName = string.Empty, Password = string.Empty;
            bool IsActive = false;

            if (clsUsersDataAccess.GetUserByID(ID, ref PersonID, ref UserName, ref Password, ref IsActive))

                return new clsUser(ID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersDataAccess.GetAllUsers();

        }

        public static bool DeleteUser(int ID)
        {
            return clsUsersDataAccess.DeleteUser(ID);
        }

        public static bool isUserExist(int ID)
        {
            return clsUsersDataAccess.IsUserExist(ID);
        }
    }
}
