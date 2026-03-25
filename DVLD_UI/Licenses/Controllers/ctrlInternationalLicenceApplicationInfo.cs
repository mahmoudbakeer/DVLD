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
    public partial class ctrlInternationalLicenceApplicationInfo : UserControl
    {
        clsApplication _Application;
        int _ApplicationID ;
        clsLicense _License;
        int _LicenseID;
        public ctrlInternationalLicenceApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadInfo(int LicenseID , int InterNationalLicenseApplicationID = -1)
        {
            _ApplicationID = InterNationalLicenseApplicationID;
            _Application = clsApplication.Find(_ApplicationID);
            _LicenseID = LicenseID;
            _License = clsLicense.Find(_LicenseID);
            if (_License == null)
            {
                MessageBox.Show("The License Info Is Wrong Please Make of the passed information","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }
            if (_Application != null)
            {
                lblApplicationID.Text = _Application.ApplicationID.ToString(); 
            }
            lblLocalLicenseID.Text = _LicenseID.ToString();
            lblCreatedBy.Text = clsGlobalUser.gUser.ID.ToString();
            lblDate.Text = DateTime.Now.ToString();
            lblLicenseIssueDate.Text = _License.IssueDate.ToString();
            lblLicenseExpDate.Text = _License.ExpirationDate.ToString();

        }
        private void ctrlInternationalLicenceApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
