using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogic
{
    public class clsApplicationType
    {

        public int ApplicationTypeID
        {
            get; set;
        }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFees { get; set; }

        public clsApplicationType(int applicationTypeID, string applicationTypeTitle, decimal applicationTypeFees)
        {
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationTypeTitle = applicationTypeTitle;
            this.ApplicationTypeFees = applicationTypeFees;
        }
        public clsApplicationType()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = string.Empty;
            this.ApplicationTypeFees = 0;
        }



        public static  clsApplicationType GetApplicationType(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = string.Empty;
            decimal ApplicationTypeFees = 0;

            if(clsApplicationTypesDataAccess.GetApplicationTypeByID(ApplicationTypeID,ref ApplicationTypeTitle , ref ApplicationTypeFees))
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);
            else return null;
        }
        public bool UpdateApplicationType()
        {
            return clsApplicationTypesDataAccess.UpdateApplicationType(ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationTypeFees);
        }
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();
        }
    }
}
