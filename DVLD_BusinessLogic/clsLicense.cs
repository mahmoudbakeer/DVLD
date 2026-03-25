using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsLicense
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode Mode { get; set; }
        public clsLocalDrivingLicenseApplication LocalDrivingApplicationInfo {  get; set; }
        public int LicenseID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int CreatedByUserID { get; set; }
        public decimal PaidFees { get; set; }
        public int DriverID { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public string IssueReason { get; set; }
        protected clsLicense(int LicenseID, int LicenseClassID,
            int LocalDrivingLicenseApplicationID ,
            DateTime IssueDate,DateTime ExpirationDate,
            int CreatedByUserID, int DriverID, decimal PaidFees,
            bool IsActive , string Notes , string IssueReason)
        {
            this.LicenseID = LicenseID;
            this.LicenseClassID = LicenseClassID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LocalDrivingApplicationInfo = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
            this.CreatedByUserID = CreatedByUserID;
            this.DriverID = DriverID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.Notes = Notes;
            this.IssueReason = IssueReason;
            this.PaidFees = PaidFees;
            this.Mode = enMode.Update;
        }
        public clsLicense()
        {
            this.LicenseID = -1;
            this.LicenseClassID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.CreatedByUserID = -1;
            this.DriverID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.IsActive = false;
            this.Notes = string.Empty;
            this.IssueReason = string.Empty;
            this.PaidFees = 0;
            this.Mode = enMode.AddNew;
        }
        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsLicenseDataAccess.AddNewLicense(
               this.LicenseClassID,
               this.IssueDate,
               this.ExpirationDate,
               this.CreatedByUserID,
               this.DriverID,
               this.LocalDrivingLicenseApplicationID,
               this.PaidFees,
               this.IsActive,
               this.Notes,
               this.IssueReason
                );

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsLicenseDataAccess.UpdateLicense(
               this.LicenseID,
               this.LicenseClassID,
               this.IssueDate,
               this.ExpirationDate,
               this.CreatedByUserID,
               this.DriverID,
               this.LocalDrivingLicenseApplicationID,
               this.PaidFees,
               this.IsActive,
               this.Notes,
               this.IssueReason
                );

        }

        public static clsLicense Find(int LicenseID)
        {

            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            int DriverID = -1;
            int LicenseClassID= -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1;
            decimal PaidFees = 0;
            string IssueReason = string.Empty , Notes = string.Empty;
            bool IsActive = false;

            if (clsLicenseDataAccess.GetLicenseByID(
                 LicenseID,
                 ref LicenseClassID,
                 ref IssueDate,
                 ref ExpirationDate ,
                 ref CreatedByUserID,
                 ref DriverID,
                 ref LocalDrivingLicenseApplicationID,
                 ref PaidFees,
                 ref IsActive ,
                 ref Notes,
                 ref IssueReason
                ))
            {
                return new clsLicense( LicenseID,  LicenseClassID,
                                        LocalDrivingLicenseApplicationID,
                                        IssueDate,  ExpirationDate,
                                        CreatedByUserID,  DriverID,  PaidFees,
                                        IsActive,  Notes,  IssueReason);
            }
            else
                return null;
        }
        public static DataTable GetAllLicneses()
        {
            return clsLicenseDataAccess.GetAllLicenses();
        }
        public static DataTable GetAllLicnesesForPersonID(int PersonID)
        {
            return clsLicenseDataAccess.GetAllLicensesForPersonID(PersonID);
        }
        public static int GetLicenseIDByLocalDrivingLicenseID(int LDLAID)
        {
            return clsLicenseDataAccess.GetLicenseByApplicationID(LDLAID);
        }
        public static bool DeleteLicense(int LicenseID)
        {
            return clsLicenseDataAccess.DeleteLicense(LicenseID);
        }
        public static bool DoesPersonHaveUnExpiredLicenseOfSameType(int LicenseID , int PersonID ,int LicenseClassID)
        {
            return clsLicenseDataAccess.DoesPersonHaveUnExpiredLicenseOfSameType(PersonID, LicenseID , LicenseClassID);
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
