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

namespace DVLD_UI.Applications.LocalDrivingApplications.Controllers
{
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApplication _LDLA;
        public clsLocalDrivingLicenseApplication LDLA { get { return _LDLA; } }
        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        private void ctrlLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
        }
        public void LoadDLAInformation(int LocalDrivingLicenseApplicationID)
        {
            _LDLA = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
            if (_LDLA == null)
            {
                MessageBox.Show("Application Not Found Make Sure LDLApplication ID is correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ctrlBasicApplicationInfo1.LoadApplicationInfo(LDLA.ApplicationID);
                lblAppliedForLicense.Text = LDLA.LicenseClassInfo.ClassName;
                lblDLAppID.Text = LDLA.LocalDrivingLicenseApplicationID.ToString();
                lblPassedTests.Text = 0.ToString();
            }
        }
    }
}
