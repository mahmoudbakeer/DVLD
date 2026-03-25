using DVLD_BusinessLogic;
using DVLD_UI.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UI.Applications.LocalDrivingApplications.DetainLicense
{
    public partial class frmReleaseLicense : Form
    {
        private clsDetainedLicense _DetainedLicense;
        private clsLicense _License;
        private int _LicenseID;
        clsApplication _Application;
        private decimal ApplicationFees = clsApplicationType.GetApplicationType((int)clsApplication.eApplicationType.ReleaseDetainedDrivingLicense).ApplicationTypeFees;
        private decimal FineFees = 0;
        public frmReleaseLicense(int LicenseID = -1)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadIntialInfo()
        {
            if(_DetainedLicense != null) FineFees = _DetainedLicense.FineFees;
            if (_License != null)
            {
               
                btnShowLicensesHistory.Enabled = true;
                btnShowLicenseInfo.Enabled = true;
            }
            else
            {
                btnShowLicensesHistory.Enabled = false;
                btnShowLicenseInfo.Enabled = false;
            }
            lblApplicationFees.Text = ApplicationFees.ToString();

            lblApplicationID.Text = (_Application == null)
            ? "Not Created Yet"
            : _Application.ApplicationID.ToString();
            lblDetainDate.Text = _DetainedLicense == null ? DateTime.Now.ToString("yyyy-MM-dd") : _DetainedLicense.DetainDate.Date.ToString("yyyy-MM-dd");

            lblFineFees.Text = (_DetainedLicense == null) ? "Not Selected" : _DetainedLicense.FineFees.ToString();

            lblLicenseID.Text = (_License == null)
                ? "Not Selected Yet"
                : _License.LicenseID.ToString("yyyy-MM-dd");
            lblCreatedByUser.Text = clsGlobalUser.gUser.UserName;

            lblApplicationFees.Text = ApplicationFees.ToString();
            lblTotalFees.Text = (FineFees + ApplicationFees).ToString();
        }
        

        private void CollectDetainInfoLicenseInfo()
        {
            _DetainedLicense = clsDetainedLicense.GetDetainedByLicenseID(_License.LicenseID);
            if (_DetainedLicense == null) return;
            else
            {
                _DetainedLicense.ReleaseDate = DateTime.Now;
                _DetainedLicense.IsReleased = true;
                _DetainedLicense.ApplicationID = _Application.ApplicationID;
                _DetainedLicense.ReleasedByUserID = clsGlobalUser.gUser.ID;
            }
        }
        private void CollectApplicationInfo()
        {
            _Application = new clsApplication();
            _Application.ApplicantPersonID = _License.LocalDrivingApplicationInfo.ApplicantPersonID;
            _Application.ApplicationStatus = clsApplication.eApplicationStatus.Completed;
            _Application.ApplicationTypeID = (int)clsApplication.eApplicationType.ReleaseDetainedDrivingLicense;
            _Application.ApplicationDate = DateTime.Now;
            _Application.LastStatusDate = DateTime.Now;
            _Application.CreatedByUserID = clsGlobalUser.gUser.ID;
            _Application.PaidFees = ApplicationFees + FineFees;
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _License = clsLicense.Find(obj);
            LoadIntialInfo();
        }
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {

            if (_License == null)
            {
                MessageBox.Show("Please select valid licnese first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!_License.IsActive)
            {
                MessageBox.Show("You can't Detain unActive License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(!clsDetainedLicense.IsLicenseDetained(_License.LicenseID))
            {
                MessageBox.Show("The License in not detained", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Release the license ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                CollectApplicationInfo();
                if (_Application.Save())
                {
                    CollectDetainInfoLicenseInfo();
                    if (_DetainedLicense.Save())
                    {
                        MessageBox.Show($"Done issuing the Releasing Detained License with ID = {_DetainedLicense.DetainedID}", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadIntialInfo();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Error , couldn't save the Released License info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error , couldn't save the Application info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void btnShowLicensesHistory_Click(object sender, EventArgs e)
        {
            if (_License == null)
            {
                MessageBox.Show("Please select valid licnese first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmShowLicensesHistory frm = new frmShowLicensesHistory(_License.LocalDrivingApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();
        }
        private void btnShowLicenseInfo_Click(object sender, EventArgs e)
        {
            if (_License == null)
            {
                MessageBox.Show("Please select valid licnese first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_License.LicenseID);
            frm.ShowDialog();
        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            if (_LicenseID != -1)
            {
                _License = clsLicense.Find(_LicenseID);
                if (_License != null) ctrlLicenseInfoWithFilter1.LoadInfo(_LicenseID);
            }
            LoadIntialInfo();
        }
    }
}
