using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsApplication
    {
        private enum enMode {AddNew =1 ,Update = 2};
        public enum eApplicationType  {NewLocalDrivingLicenseService =1 ,RenewDrivingLicenseService = 2,
                    ReplacementForALostDrivingLicense =3 , ReplacmentForDamagedDrivingLicense = 4,ReleaseDetainedDrivingLicense = 5,
                    NewInterNationalLicense = 6,RetakeTest =  7};
        public enum eApplicationStatus { New  = 1 , Cancelled = 2 , Completed = 3 };
        public string getStatusText {
            get {
                switch(ApplicationStatus)
                {
                    case eApplicationStatus.New: return "New";
                    case eApplicationStatus.Cancelled: return "Cancelled";
                    case eApplicationStatus.Completed: return "Completed";
                    default: return "Unknown";
                }
            }
            }
        private enMode Mode {  get; set; }
        public int ApplicationID {  get; set; }
        public DateTime ApplicationDate { get; set; }
        public eApplicationStatus ApplicationStatus {  get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo { get; set; }
        public clsUser UserInfo { get; set; }
        public clsPerson PersonInfo { get; set; }
        public int ApplicantPersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public decimal PaidFees { get; set; }
        public DateTime LastStatusDate { get; set; }
        protected clsApplication(int ApplicationID, DateTime ApplicationDate,
            eApplicationStatus ApplicationStatus, int ApplicantPersonID,
            int CreatedByUserID, int ApplicationTypeID, decimal PaidFees,
            DateTime LastStatusDate)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationStatus = ApplicationStatus;

            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);

            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.Find(CreatedByUserID);

            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.GetApplicationType(ApplicationTypeID);

            this.PaidFees = PaidFees;
            this.LastStatusDate = LastStatusDate;

            this.Mode = enMode.Update;
        }
        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicantPersonID = -1;
            this.ApplicationTypeID = -1;
            this.PersonInfo = null;
            this.UserInfo = null;
            this.ApplicationTypeInfo = null;
            this.CreatedByUserID = -1;
            this.PaidFees = 0;
            this.LastStatusDate = DateTime.MinValue;
            this.Mode= enMode.AddNew;
        }
        private bool _AddNewApplication()
        {
            //call DataAccess Layer 

            this.ApplicationID = clsApplicationDataAccess.AddNewApplication(
                this.ApplicationDate,
                (int)this.ApplicationStatus,
                this.ApplicantPersonID,
                this.CreatedByUserID,
                this.ApplicationTypeID,
                this.PaidFees,
                this.LastStatusDate
                );

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsApplicationDataAccess.UpdateApplications(
                this.ApplicationID,
                this.ApplicationDate,
                (int)this.ApplicationStatus,
                this.ApplicantPersonID,
                this.CreatedByUserID,
                this.ApplicationTypeID,
                this.PaidFees,
                this.LastStatusDate
                );

        }

        public static clsApplication Find(int ApplicationID)
        {

           DateTime ApplicationDate = DateTime.MinValue, LastStatusDate = DateTime.MinValue;
            int ApplicationStatus = -1;
            int ApplicationTypeID = -1,ApplicantPersonID = -1,CreatedByUserID = -1;
            decimal PaidFees = 0;

            if (clsApplicationDataAccess.GetApplicationByID(ApplicationID, ref ApplicationDate,
                ref ApplicationStatus, ref ApplicantPersonID,
                ref CreatedByUserID, ref ApplicationTypeID,
               ref PaidFees, ref LastStatusDate))
            {
                return  new clsApplication( ApplicationID,  ApplicationDate
            ,  (eApplicationStatus)ApplicationStatus,  ApplicantPersonID
            ,  CreatedByUserID,  ApplicationTypeID,  PaidFees
            ,  LastStatusDate);
            }
            else
                return null;
        }
        public static bool UpdateStatus(int ApplicationID,int NewApplicationStatus)
        {
            clsApplication ap = clsApplication.Find(ApplicationID);
            if ( ap == null ) return false;
            return clsApplicationDataAccess.UpdateStatus(ApplicationID, NewApplicationStatus);
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }




            return false;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationDataAccess.GetAllApplicaions();

        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationDataAccess.DeleteApplication(ApplicationID);
        }

        public static bool isApplicationExist(int ApplicationID)
        {
            return clsApplicationDataAccess.IsApplicationExist(ApplicationID);
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID,int ApplicationTypeID)
        {
            return (clsApplicationDataAccess.GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }
        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID , (int)ApplicationTypeID);
        }
        public static int GetActiveApplication(int PersonID, int ApplicationTypeID) {
                return clsApplicationDataAccess.GetActiveApplicationID(PersonID, ApplicationTypeID);
        }
        public int GetActiveApplicationID(int ApplicationTypeID) {
            return GetActiveApplication(this.ApplicantPersonID,ApplicationTypeID);
        }


    }
}
