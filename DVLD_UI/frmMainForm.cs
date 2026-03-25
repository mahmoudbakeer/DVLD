using DVLD_BusinessLogic;
using DVLD_UI.Applications;
using DVLD_UI.Applications.LocalDrivingApplications;
using DVLD_UI.Applications.LocalDrivingApplications.DetainLicense;
using DVLD_UI.Applications.LocalDrivingApplications.RenewLocalDrivingLicense;
using DVLD_UI.Applications.LocalDrivingApplications.ReplaceDrivingLicense;
using DVLD_UI.Drivers;
using DVLD_UI.Licenses;
using DVLD_UI.Licenses.InterNationalLicense;
using DVLD_UI.Tests;
using DVLD_UI.Users;
using DVLD_UI.Users.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class frmMainForm : Form
    {
        public frmLoginScreen _frmLogin;
        public frmMainForm(frmLoginScreen frmLogin)
        {
            _frmLogin = frmLogin;
            InitializeComponent();
        }

        private void applicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void currentUserInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmShowUserInfo frm = new frmShowUserInfo(DVLD_UI.clsGlobalUser.gUser.ID);
            frm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobalUser.gUser = null;
            this.Hide();
            _frmLogin.Show();
            this.Close();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobalUser.gUser.ID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypeManagment frm = new frmTestTypeManagment();
            frm.ShowDialog();
        }

        private void manageLocalDrivingApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseAppliction frm = new frmAddUpdateLocalDrivingLicenseAppliction();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplication frm = new frmInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void listInternationalLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenses frm = new frmListInternationalLicenses();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicense frm = new frmRenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void replacementDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceDrivingLicense frmReplaceDrivingLicense = new frmReplaceDrivingLicense();
            frmReplaceDrivingLicense.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense(); 
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frmManage = new frmManageDetainedLicenses(); 
            frmManage.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frmReleaseLicense = new frmReleaseLicense();
            frmReleaseLicense.ShowDialog();
        }

        private void releasedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frmReleaseLicense = new frmReleaseLicense();
            frmReleaseLicense.ShowDialog();
        }
    }
}
