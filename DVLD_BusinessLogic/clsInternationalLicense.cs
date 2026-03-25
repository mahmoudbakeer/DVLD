using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsInternationalLicense
    {
        private enum enMode { AddNew = 1, Update = 2 };

        private enMode Mode { get; set; }
        public clsApplication ApplicationInfo { get; set; }
        public int InternationalLicenseID { get; set; }
        public int LicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ApplicationID { get; set; }
        public int CreatedByUserID { get; set; }
        public int DriverID { get; set; }
        public bool IsActive { get; set; }
        public clsLicense LicenseInfo { get; set; }
        protected clsInternationalLicense(int InternationalLicenseID, int LicenseID,
            int ApplicationID,
            DateTime IssueDate, DateTime ExpirationDate,
            int CreatedByUserID, int DriverID,
            bool IsActive)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.LicenseID = LicenseID;
            this.LicenseInfo = clsLicense.Find(LicenseID);
            this.ApplicationID = ApplicationID;
            this.ApplicationInfo = clsApplication.Find(ApplicationID);
            this.CreatedByUserID = CreatedByUserID;
            this.DriverID = DriverID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.Mode = enMode.Update;
        }
        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.ApplicationInfo = new clsApplication();
            this.CreatedByUserID = -1;
            this.DriverID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.IsActive = false;
            this.Mode = enMode.AddNew;
        }
        private bool _AddNewInternationalLicense()
        {
            //call DataAccess Layer 

            this.InternationalLicenseID = clsInternationalLicensesDataAccess.AddNewLicense(
               this.LicenseID,
               this.IssueDate,
               this.ExpirationDate,
               this.CreatedByUserID,
               this.DriverID,
               this.ApplicationID,
               this.IsActive
                );

            return (this.InternationalLicenseID != -1);
        }

        //private bool _UpdateInternationalLicense()
        //{
        //    //call DataAccess Layer 

        //    return clsLicenseDataAccess.UpdateLicense(
        //       this.LicenseID,
        //       this.LicenseClassID,
        //       this.IssueDate,
        //       this.ExpirationDate,
        //       this.CreatedByUserID,
        //       this.DriverID,
        //       this.LocalDrivingLicenseApplicationID,
        //       this.PaidFees,
        //       this.IsActive,
        //       this.Notes,
        //       this.IssueReason
        //        );

        //}

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {

            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            int DriverID = -1;
            int LicenseID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1;
            bool IsActive = false;

            if (clsInternationalLicensesDataAccess.GetInternationalLicenseByID(
                 InternationalLicenseID,
                 ref LicenseID,
                 ref IssueDate,
                 ref ExpirationDate,
                 ref CreatedByUserID,
                 ref DriverID,
                 ref LocalDrivingLicenseApplicationID,
                 ref IsActive
                ))
            {
                return new clsInternationalLicense(InternationalLicenseID, LicenseID,
                                        LocalDrivingLicenseApplicationID,
                                        IssueDate, ExpirationDate,
                                        CreatedByUserID, DriverID,
                                        IsActive);
            }
            else
                return null;
        }
        public static clsInternationalLicense FindByLicenseID(int LicenseID)
        {

            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            int DriverID = -1;
            int InternationalLicenseID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1;
            bool IsActive = false;

            if (clsInternationalLicensesDataAccess.GetInternationalLicenseByLicesneID(
                 ref InternationalLicenseID,
                  LicenseID,
                 ref IssueDate,
                 ref ExpirationDate,
                 ref CreatedByUserID,
                 ref DriverID,
                 ref LocalDrivingLicenseApplicationID,
                 ref IsActive
                ))
            {
                return new clsInternationalLicense(InternationalLicenseID, LicenseID,
                                        LocalDrivingLicenseApplicationID,
                                        IssueDate, ExpirationDate,
                                        CreatedByUserID, DriverID,
                                        IsActive);
            }
            else
                return null;
        }
        //public static DataTable GetAllLicneses()
        //{
        //    return clsLicenseDataAccess.GetAllLicenses();
        //}
        //public static DataTable GetAllLicnesesForPersonID(int PersonID)
        //{
        //    return clsLicenseDataAccess.GetAllLicensesForPersonID(PersonID);
        //}
        //public static int GetLicenseIDByLocalDrivingLicenseID(int LDLAID)
        //{
        //    return clsLicenseDataAccess.GetLicenseByApplicationID(LDLAID);
        //}
        //public static bool DeleteLicense(int LicenseID)
        //{
        //    return clsLicenseDataAccess.DeleteLicense(LicenseID);
        //}
        public static bool IsLicenseHasInternationalLicense(int LicenseID)
        {
            return clsInternationalLicensesDataAccess.IsLicenseHasInternationalLicnese(LicenseID);
        }
        public static DataTable GetAllInternationalLicensesForPerson(int PersonID)
        {
            return clsInternationalLicensesDataAccess.GetAllLicensesForPerson(PersonID);
        }
        public static DataTable GetAllInternatioanLicenses()
        {
            return clsInternationalLicensesDataAccess.GetAllInternationalLicenses();
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                //case enMode.Update:

                //    return _UpdateInternationalLicense();
                default: return false;

            }
            return false;
        }
    }
}
