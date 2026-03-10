using DVLD_DataAccess;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace DVLD_BusinessLogic
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum eMode { AddNew = 1, Update =2 };
        public eMode Mode { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }

        private clsLocalDrivingLicenseApplication(
            int LocalDrivingLicenseApplicationID,
            int LicenseClassID,
            int ApplicationID,
            DateTime ApplicationDate,
            eApplicationStatus ApplicationStatus,
            int ApplicantPersonID,
            int CreatedByUserID,
            int ApplicationTypeID,
            decimal PaidFees,
            DateTime LastStatusDate)

            : base(ApplicationID, ApplicationDate, ApplicationStatus,
                   ApplicantPersonID, CreatedByUserID,
                   ApplicationTypeID, PaidFees, LastStatusDate)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.GetLicenseClass(LicenseClassID);
            this.Mode = eMode.Update;
        }
        public clsLocalDrivingLicenseApplication() : base()
        {
            this.LicenseClassID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            Mode = eMode.AddNew;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationDataAccess.AddNewLocalDrivingLicenseApplication(ApplicationID, this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            return clsLocalDrivingLicenseApplicationDataAccess.UpdateLocalDrivingLicenseApplicationByID(this.LocalDrivingLicenseApplicationID,this.ApplicationID,this.LicenseClassID);

        }

        public static clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplicationID)
        {
            int LicenseClassID = -1,ApplicationID = -1;
            if (clsLocalDrivingLicenseApplicationDataAccess.GetLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                clsApplication Application = clsApplication.Find(ApplicationID);
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, LicenseClassID, Application.ApplicationID, Application.ApplicationDate, Application.ApplicationStatus
                   , Application.ApplicantPersonID, Application.CreatedByUserID, Application.ApplicationTypeID,
                   Application.PaidFees, Application.LastStatusDate);
            }
            else return null;
        }

        public bool Save()
        {
            if (!base.Save())
                return false;
            switch (this.Mode)
            {
                case eMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {

                        Mode = eMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case eMode.Update:

                    return _UpdateLocalDrivingLicenseApplication();

            }
            return false;
        }

        public static DataTable GetAllLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.GetAllLocalDrivingApplications();

        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }

        public static bool isLocalDrivingLicenseApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.isLocalDrivingLiCenseApplicationExist(LocalDrivingLicenseApplicationID);
        }
    }
}