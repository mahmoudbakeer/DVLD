using DVLD_BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses
{
    public partial class frmIssueLicenseFirstTime : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        public int LocalDrivingLicenseApplicationID
        {
            get {  return _LocalDrivingLicenseApplicationID;}
        }
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsLicense _License;
        private clsDriver _Driver;
        public frmIssueLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
            if(_LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("The LocalDrivingApplication is not exist","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }
            ctrlLocalDrivingLicenseApplicationInfo1.LoadDLAInformation(LocalDrivingLicenseApplicationID);
        }
        private bool _CollectLicenseInfno()
        {
            _License = new clsLicense();
            _License.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _License.LicenseClassID = _LocalDrivingLicenseApplication.LicenseClassID;
            _License.IssueDate = DateTime.Now;
            _License.ExpirationDate = DateTime.Now.AddYears(_LocalDrivingLicenseApplication.LicenseClassInfo.DefaultValiditLength);
            _License.CreatedByUserID = clsGlobalUser.gUser.ID;
            _License.PaidFees = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassFees;
            _License.IsActive = true;
            _License.Notes = txtNotes.Text;
            _License.IssueReason = "First Time Issue";

            _Driver = new clsDriver();
            _Driver.PersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
            _Driver.CreatedByUserID =  clsGlobalUser.gUser.ID;
            _Driver.CreatedDate = DateTime.Now;
            if(_Driver.IsPersonDriver()) _Driver = clsDriver.GetDriverByPersonID(_Driver.PersonID);
            else if(!_Driver.AddNewDriver())
            {
                MessageBox.Show("Couldn't Save the Driver info Please check the Info", "Error");
                this.Enabled = false;
                return false;
            }
            _License.DriverID = _Driver.DriverID;
            if(!_License.Save())
            {
                MessageBox.Show("Couldn't Save the License info Please check the Info", "Error");
                this.Enabled = false;
                return false;
            }
            _LocalDrivingLicenseApplication.ApplicationStatus = clsLocalDrivingLicenseApplication.eApplicationStatus.Completed;
            if(!_LocalDrivingLicenseApplication.Save())
            {
                MessageBox.Show("Couldn't Save the Application status Please check the Info", "Error");
                this.Enabled = false;
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ? , you want to issue this license ?", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            if (!_CollectLicenseInfno()) return;
            MessageBox.Show($"Successed by issuing the license , new license id = {_License.LicenseID}", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;
        }
    }
}
