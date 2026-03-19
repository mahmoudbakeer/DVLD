using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsDriver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        private clsDriver(int DriverID , int PersonID , int CreatedByUserID , DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;   
            this.CreatedDate = CreatedDate;
        }
        public clsDriver()
        {
            this.DriverID = -1;
            this.CreatedByUserID = -1;
            this.PersonID = -1;
            this.CreatedDate = DateTime.MinValue;
        }
        public static clsDriver GetByDriverID(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            if(clsDriversDataAccess.GetDriverByID(DriverID , ref PersonID , ref CreatedByUserID , ref CreatedDate))
            {
                return new clsDriver(DriverID,PersonID,CreatedByUserID,CreatedDate);
            }
            else return null;
        }
        public static DataTable GetAllDrivers()
        {
            return clsDriversDataAccess.GetAllDrivers();
        }
        public static clsDriver GetDriverByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            if (clsDriversDataAccess.GetDriverByPersonID(ref DriverID,  PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else return null;
        }
        public static bool IsPersonDriver(int PersonID)
        {
            return clsDriversDataAccess.IsPersonDriver(PersonID);
        }
        public bool IsPersonDriver()
        {
            return clsDriversDataAccess.IsPersonDriver(this.PersonID);
        }
        public bool AddNewDriver()
        {
            if (IsPersonDriver(this.PersonID))
            {
                return true;
            }// will always return true if the person is driver otherwise we will add it to the system
            else this.DriverID = clsDriversDataAccess.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);
            return this.DriverID != -1;
        }
    }
}
