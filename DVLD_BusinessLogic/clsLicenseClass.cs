using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    internal class clsLicenseClass
    {
            int LicenseClassID
        {
            get; set;
        }
            string ClassName
        {
            get; set;
        }
            string ClassDescription { get; set; }
            int MinimumAllowedAge {  get; set; }
            int DefaultValiditLength {  get; set; }
            decimal ClassFees {  get; set; }
        clsLicenseClass(int LicenseClassID,string ClassName,string ClassDescription,int MinimumAllowedAge , int DefaultValiditLength , decimal ClassFees)
        {
            this.ClassName = ClassName;
            this.LicenseClassID = LicenseClassID;
            this.DefaultValiditLength = DefaultValiditLength;
            this.MinimumAllowedAge= MinimumAllowedAge;
            this.ClassDescription = ClassDescription;
            this.ClassFees = ClassFees;
        }
        clsLicenseClass()
        {
            this.ClassName = string.Empty;
            this.LicenseClassID = -1;
            this.DefaultValiditLength = -1;
            this.MinimumAllowedAge = int.MaxValue;
            this.ClassDescription = string.Empty;
            this.ClassFees = 0;
        }
        //public bool UpdateClassLicense()
        //{
        //    return (clsLicenseClassesDataAccess.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge,this.DefaultValiditLength , this.ClassFees));
        //}
        public static DataTable GetAllLicenses()
        {
            DataTable dataTable = clsLicenseClassesDataAccess.GetAllLicenseClasses();
            return dataTable;
        }
    }
}
