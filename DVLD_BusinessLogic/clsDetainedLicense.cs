using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsDetainedLicense
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode Mode { get; set; }
        public clsApplication ApplicationInfo{ get; set; }
        public int DetainedID { get; set; }
        public int LicenseID { get; set; }

        public DateTime DetainDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ApplicationID { get; set; }
        public int CreatedByUserID { get; set; }
        public int ReleasedByUserID { get; set; }
        public decimal FineFees { get; set; }
        
        public bool IsReleased { get; set; }
        protected clsDetainedLicense(int DetainedID , int LicenseID , int ApplicationID , int CreatedByUser , int ReleasedByUser , DateTime DetainDate , DateTime ReleaseDate , decimal FineFees , bool IsReleased)
        {
            this.DetainedID= DetainedID;
            this.LicenseID= LicenseID;
            this.ApplicationID= ApplicationID;
            this.CreatedByUserID = CreatedByUser;
            this.ReleasedByUserID = ReleasedByUser;
            this.DetainDate = DetainDate;
            this.ReleaseDate = ReleaseDate; 
            this.FineFees = FineFees;
            this.IsReleased = IsReleased;
            this.Mode = enMode.Update;
        }
        public clsDetainedLicense()
        {
            this.DetainedID = -1;
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.CreatedByUserID = -1;
            this.ReleasedByUserID = -1;
            this.DetainDate = DateTime.MinValue;
            this.ReleaseDate = DateTime.MinValue;
            this.FineFees = 0;
            this.IsReleased = false;
            this.Mode = enMode.AddNew;
        }
        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.DetainedID = clsDetainLicenseDataAccess.AddNewDetain(this.LicenseID,this.DetainDate,this.CreatedByUserID,this.FineFees);

            return (this.DetainedID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsDetainLicenseDataAccess.UpdateDetainLicense(this.DetainedID,this.LicenseID,this.DetainDate,this.ReleaseDate,this.CreatedByUserID,this.ReleasedByUserID,this.ApplicationID,this.FineFees,this.IsReleased);

        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainLicenseDataAccess.IsLicenseDetained(LicenseID);
        }
        public static clsDetainedLicense GetDetainedByLicenseID(int LicenseID)
        {
            DateTime DetainDate = DateTime.MinValue, ReleaseDate = DateTime.MinValue;
            int DetainedID = -1, CreatedByUser = -1, ReleasedByUser = -1, ApplicationID = -1;
            bool IsReleased = false;
            decimal FineFees = -1;

            if (clsDetainLicenseDataAccess.GetDetainByLicesneID(ref DetainedID,  LicenseID, ref DetainDate, ref ReleaseDate, ref CreatedByUser, ref ReleasedByUser, ref ApplicationID, ref FineFees, ref IsReleased))
            {
                return new clsDetainedLicense(DetainedID, LicenseID, ApplicationID, CreatedByUser, ReleasedByUser, DetainDate, ReleaseDate, FineFees, IsReleased);
            }
            else
                return null;
        }
        public static clsDetainedLicense Find(int DetainedID)
        {

            DateTime DetainDate = DateTime.MinValue, ReleaseDate = DateTime.MinValue;
            int LicenseID  = -1 , CreatedByUser = -1,ReleasedByUser = -1 ,ApplicationID = -1;
            bool IsReleased = false;
            decimal FineFees = -1;

            if (clsDetainLicenseDataAccess.GetDetainByID(DetainedID , ref LicenseID , ref DetainDate , ref ReleaseDate , ref CreatedByUser , ref ReleasedByUser ,ref ApplicationID ,ref FineFees , ref IsReleased))
            {
                return new clsDetainedLicense( DetainedID,  LicenseID,  ApplicationID,  CreatedByUser,  ReleasedByUser,  DetainDate,  ReleaseDate,  FineFees,  IsReleased);
            }
            else
                return null;
        }
        public static DataTable GetAllDetainedLicense()
        {
            return clsDetainLicenseDataAccess.GetAllDetainLicenses();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }
            return false;
        }
    }
}

