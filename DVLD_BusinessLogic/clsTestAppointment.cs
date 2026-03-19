using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int TestID
        {
            get { return _GetTestID(); }

        }
        public int TestAppointmentID { set; get; }
        public clsTestType.enTestType TestClassID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestAppInfo { set; get; }
        clsTestAppointment(int testAppointmentID, clsTestType.enTestType testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate, decimal paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            Mode = enMode.Update;
            TestAppointmentID = testAppointmentID;
            TestClassID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
            RetakeTestAppInfo = clsApplication.Find(retakeTestApplicationID);
        }
        public clsTestAppointment()
        {
            Mode = enMode.AddNew;
            TestAppointmentID = -1;
            TestClassID = clsTestType.enTestType.Vision;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.MinValue;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;
            RetakeTestAppInfo = null;
        }


        private bool _AddNewTestAppointment()
        {
            //call DataAccess Layer 

            this.TestAppointmentID = clsTestAppointmentsDataAccess.AddNewTestAppointment(
                     CreatedByUserID,
                     LocalDrivingLicenseApplicationID,
                     (int)TestClassID,
                     AppointmentDate,
                     PaidFees,
                     IsLocked,
                     RetakeTestApplicationID
                );

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            //call DataAccess Layer 

            return clsTestAppointmentsDataAccess.UpdateTestAppointment(TestAppointmentID,
             CreatedByUserID,
             LocalDrivingLicenseApplicationID,
             (int)TestClassID,
             AppointmentDate,
             PaidFees,
             IsLocked,
             RetakeTestApplicationID);
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {

            int CreatedByUser = -1,TestClassID = -1 , LocalDrivingLicenseApplicationID = -1, RetakeApplicationID = -1;
            DateTime TestAppointmentDate = DateTime.MinValue;
            bool IsLocked = false;
            decimal PaidFees = 0;
            if (clsTestAppointmentsDataAccess.GetTestAppointmentByID(TestAppointmentID,ref CreatedByUser,ref LocalDrivingLicenseApplicationID,ref TestClassID,ref TestAppointmentDate,ref PaidFees , ref IsLocked,ref RetakeApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestClassID, LocalDrivingLicenseApplicationID, TestAppointmentDate, PaidFees, CreatedByUser, IsLocked, RetakeApplicationID);
            }
            else
                return null;
        }
        public static clsTestAppointment GetLastTestAppointmentPerTestType(int LocalDrivingLicenseID , clsTestType.enTestType Type)
        {

            int TestAppointmentID = -2 , CreatedByUser = -1, RetakeApplicationID = -1;
            DateTime TestAppointmentDate = DateTime.MinValue;
            bool IsLocked = false;
            decimal PaidFees = 0;
            if (clsTestAppointmentsDataAccess.GetlastTestAppointment(ref TestAppointmentID, ref CreatedByUser, LocalDrivingLicenseID, (int)Type, ref TestAppointmentDate, ref PaidFees, ref IsLocked, ref RetakeApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, Type, LocalDrivingLicenseID, TestAppointmentDate, PaidFees, CreatedByUser, IsLocked, RetakeApplicationID);
            }
            else
                return null;
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateTestAppointment();
            }
            return false;
        }

        public static DataTable GetAllTestAppointmentsPerTestType(int LocalDrinvingLicenseApplicationID , clsTestType.enTestType Type)
        {
            return  clsTestAppointmentsDataAccess.GetAllTestAppointmentsPerTestType(LocalDrinvingLicenseApplicationID,(int)Type);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentsDataAccess.DeleteTestAppointment(TestAppointmentID);
        }
        public static bool IsAppointmentsLocked(int TestAppointmentID)
        {
            return clsTestAppointmentsDataAccess.IsAppointmentLocked(TestAppointmentID);
        }
        public bool IsAppointmentsLocked()
        {
            return clsTestAppointmentsDataAccess.IsAppointmentLocked(TestAppointmentID);
        }
        private  int _GetTestID()
        {
            return clsTestAppointmentsDataAccess.GetTestID(this.TestAppointmentID);
        }
    }
}
