using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsTestType
    {
        public enum enTestType {Vision = 1 , Written =2,  Street = 3};
        public int TestTypeID
        {
            get; set;
        }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescribtion { get; set; }
        public decimal TestTypeFees { get; set; }

        public clsTestType(int TestTypeID, string TestTypeTitle,string TestTypeDescribtion, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescribtion= TestTypeDescribtion;
            this.TestTypeFees = TestTypeFees;
        }
        public clsTestType()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = string.Empty;
            this.TestTypeDescribtion = string.Empty;
            this.TestTypeFees = 0;
        }



        public static clsTestType GetTestType(int TestTypeID)
        {
            string TestTypeTitle = string.Empty;
            string TestTypeDescribtion = string.Empty;
            decimal TestTypeFees = 0;

            if (clsTestTypesDataAccess.GetTestTypeByID(TestTypeID, ref TestTypeTitle,ref TestTypeDescribtion, ref TestTypeFees))
                return new clsTestType(TestTypeID, TestTypeTitle,TestTypeDescribtion, TestTypeFees);
            else return null;
        }
        public bool UpdateTestType()
        {
            return clsTestTypesDataAccess.UpdateTestType(TestTypeID,TestTypeTitle,TestTypeDescribtion,TestTypeFees);
        }
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }
    }
}
