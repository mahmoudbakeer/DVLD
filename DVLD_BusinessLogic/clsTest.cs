using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsTest
    {
        public int TestID
        {
            get; set;
        }
        public string Notes { get; set; }
        public bool TestResult { get; set; }
        public int CreatedByUserID { get; set; }
        public int TestAppointmentID { get; set; }

        private clsTest(int TestID, string Notes, bool TestResult, int CreatedByUserID , int TestAppointmentID)
        {
            this.TestID = TestID;
            this.Notes = Notes;
            this.TestResult = TestResult;
            this.CreatedByUserID = CreatedByUserID;
            this.TestAppointmentID = TestAppointmentID;
        }
        public clsTest()
        {
            this.TestID = -1;
            this.Notes = string.Empty;
            this.TestResult = false;
            this.CreatedByUserID = -1;
            this.TestAppointmentID = -1;
        }



        public static clsTest Find(int TestID)
        {
            int CreatedByUser = -1, TestAppointmentID = -1;
            string Notes = string.Empty;
            bool TestResult = false;

            if (clsTestDataAccess.GetTestByID(TestID, ref CreatedByUser, ref Notes, ref TestAppointmentID, ref TestResult))
                return new clsTest(TestID, Notes, TestResult, CreatedByUser, TestAppointmentID);
            else return null;
        }
        public bool UpdateTestType()
        {
            return clsTestTypesDataAccess.UpdateTestType(TestTypeID, TestTypeTitle, TestTypeDescribtion, TestTypeFees);
        }
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }
    }
}
