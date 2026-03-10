using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsLicenseClass
    {
            public int LicenseClassID
        {
            get; set;
        }
            public string ClassName
        {
            get; set;
        }
            public string ClassDescription { get; set; }
            public int MinimumAllowedAge {  get; set; }
            public int DefaultValiditLength {  get; set; }
            public decimal ClassFees {  get; set; }
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
        public static clsLicenseClass GetLicenseClass(int ClassID)
        {
            int MinimumAllowedAge = -1,DefaultValidtyLength = -1;
            decimal ClassFees = 0;
            string ClassDescription = string.Empty,ClassName = string.Empty ;
            if (clsLicenseClassesDataAccess.GetLicenseClassByID(ClassID,ref ClassName,ref ClassDescription,ref MinimumAllowedAge,ref DefaultValidtyLength,ref ClassFees))
            {
                return new clsLicenseClass(ClassID,ClassName,ClassDescription,MinimumAllowedAge,DefaultValidtyLength,ClassFees);
            }
            else return null;
        }
        public static clsLicenseClass GetLicenseClass(string ClassName)
        {
            int MinimumAllowedAge = -1, DefaultValidtyLength = -1, ClassID = -1;
            decimal ClassFees = 0;
            string ClassDescription = string.Empty;
            if (clsLicenseClassesDataAccess.GetLicenseClassByName(ref ClassID,  ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidtyLength, ref ClassFees))
            {
                return new clsLicenseClass(ClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidtyLength, ClassFees);
            }
            else return null;
        }
        public static DataTable GetAllLicenses()
        {
            DataTable dataTable = clsLicenseClassesDataAccess.GetAllLicenseClasses();
            return dataTable;
        }
    }
}
