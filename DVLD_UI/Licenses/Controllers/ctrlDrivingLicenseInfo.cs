using DVLD_BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses.Controllers
{
    public partial class ctrlDrivingLicenseInfo : UserControl
    {
        private clsLicense _License;
        public clsLicense License
        {
            get {  return _License; }
        }
        public ctrlDrivingLicenseInfo()
        {
            InitializeComponent();
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            _License = clsLicense.Find(LicenseID);
            if (License == null)
            {
                MessageBox.Show("No such License Found , please check the info","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }
            lblLicenseID.Text = LicenseID.ToString();
            lblLicenseClass.Text = License.LocalDrivingApplicationInfo.LicenseClassInfo.ClassName.ToString();
            lblName.Text = License.LocalDrivingApplicationInfo.PersonInfo.FirstName + " " + License.LocalDrivingApplicationInfo.PersonInfo.LastName;
            lblNationalNo.Text = License.LocalDrivingApplicationInfo.PersonInfo.NationalNo;
            lblIssueReason.Text = License.IssueReason;
            lblIssueDate.Text = License.IssueDate.Date.ToString("yyyy-mm-dd");
            lblNotes.Text = License.Notes;
            lblIsActive.Text = License.IsActive == true ? "Yes" : "No";
            lblDateOfBirth.Text = License.LocalDrivingApplicationInfo.PersonInfo.DateOfBirth.Date.ToString("yyyy-mm-dd"); 
            lblExpDate.Text = License.ExpirationDate.Date.ToString("yyyy-mm-dd");
            lblIsDetained.Text = !clsDetainedLicense.IsLicenseDetained(License.LicenseID) ? "No":"Yes";
            
            if(License.LocalDrivingApplicationInfo.PersonInfo.ImagePath != string.Empty) pbPersonPicture.Load(License.LocalDrivingApplicationInfo.PersonInfo.ImagePath.ToString());
        }
        private void ctrlDrivingLicenseInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
