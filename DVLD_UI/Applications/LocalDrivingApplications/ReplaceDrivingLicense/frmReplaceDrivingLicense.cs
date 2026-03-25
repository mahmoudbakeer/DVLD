using DVLD_BusinessLogic;
using DVLD_UI.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UI.Applications.LocalDrivingApplications.ReplaceDrivingLicense
{
    public partial class frmReplaceDrivingLicense : Form
    {
        private clsLicense _ReplaceLicense;
        private clsLicense _License;
        private clsLocalDrivingLicenseApplication _Application;
        decimal LicenseFees = 0;
        decimal ApplicationFees = 0;
        private enum enReplaceFor { Damage = 1 , Lost = 2};
        enReplaceFor ReasonToReplace;
        public frmReplaceDrivingLicense()
        {
            InitializeComponent();
        }
        private void LoadIntialInfo()
        {

            if (_ReplaceLicense != null)
            {
                lblRenewedLicenseID.Text = _ReplaceLicense.LicenseID.ToString();

            }
            if (_License != null)
            {
                gbReplaceFor.Enabled = true;
                btnShowLicensesHistory.Enabled = true;
                btnShowLicenseInfo.Enabled = true;
                LicenseFees = clsLicenseClass.GetLicenseClass(_License.LicenseClassID).ClassFees;
            }
            else
            {
                gbReplaceFor.Enabled = false;
                btnShowLicensesHistory.Enabled = false;
                btnShowLicenseInfo.Enabled = false;

            }
            ApplicationFees = (ReasonToReplace == enReplaceFor.Damage) ? clsApplicationType.GetApplicationType((int)clsApplication.eApplicationType.ReplacmentForDamagedDrivingLicense).ApplicationTypeFees : clsApplicationType.GetApplicationType((int)clsApplication.eApplicationType.ReplacementForALostDrivingLicense).ApplicationTypeFees;
            lblApplicationID.Text = (_Application == null || _Application.LocalDrivingLicenseApplicationID <= 0)
            ? "Not Created Yet"
            : _Application.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            lblLicenseIssueDate.Text = (_License == null)
                ? "Not Selected Yet"
                : _License.IssueDate.ToString("yyyy-MM-dd");

            lblLicenseExpirationDate.Text = (_License == null)
                ? "Not Selected Yet"
                : _License.ExpirationDate.ToString("yyyy-MM-dd");
            lblOldLicenseID.Text = (_License == null) ? "Not Selected Yet" : _License.LicenseID.ToString();
            lblRenewedLicenseID.Text = _ReplaceLicense == null ? "Not Replaced" : _ReplaceLicense.LicenseID.ToString();
            lblCreatedByUser.Text = clsGlobalUser.gUser.UserName;
            lblLicenseFees.Text = (_License == null) ? "Not Selected Yet" : clsLicenseClass.GetLicenseClass(_License.LicenseClassID).ClassFees.ToString();
            lblApplicationFees.Text = ApplicationFees.ToString();
            lblTotalFees.Text = (LicenseFees + ApplicationFees).ToString();
        }
        private void frmReplaceDrivingLicense_Load(object sender, EventArgs e)
        {
            LoadIntialInfo();
        }

        private void CollectReplacedLicenseInfo()
        {
            _ReplaceLicense = new clsLicense();
            _ReplaceLicense.DriverID = _License.DriverID;
            _ReplaceLicense.PaidFees = ApplicationFees + clsLicenseClass.GetLicenseClass(_License.LicenseClassID).ClassFees;
            _ReplaceLicense.LocalDrivingLicenseApplicationID = _Application.LocalDrivingLicenseApplicationID;
            _ReplaceLicense.ExpirationDate = _License.ExpirationDate;
            _ReplaceLicense.IssueDate = DateTime.Now;
            _ReplaceLicense.CreatedByUserID = clsGlobalUser.gUser.ID;
            _ReplaceLicense.IsActive = true;
            _ReplaceLicense.LicenseClassID = _License.LicenseClassID;
            _ReplaceLicense.Notes = txtNotes.Text;
            string Reason = (ReasonToReplace == enReplaceFor.Damage) ? " Damage" : " Lost";
            _ReplaceLicense.IssueReason = "Replace License" +Reason;
        }
        private void CollectApplicationInfo()
        {
            _Application = new clsLocalDrivingLicenseApplication();
            _Application.ApplicantPersonID = _License.LocalDrivingApplicationInfo.ApplicantPersonID;
            _Application.ApplicationStatus = clsApplication.eApplicationStatus.Completed;
            _Application.ApplicationTypeID = (ReasonToReplace == enReplaceFor.Damage) ? (int)clsApplication.eApplicationType.ReplacmentForDamagedDrivingLicense : (int)clsApplication.eApplicationType.ReplacementForALostDrivingLicense;
            _Application.ApplicationDate = DateTime.Now;
            _Application.LastStatusDate = DateTime.Now;
            _Application.CreatedByUserID = clsGlobalUser.gUser.ID;
            _Application.PaidFees = ApplicationFees;
            _Application.LicenseClassID = _License.LicenseClassID;
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _License = clsLicense.Find(obj);
            LoadIntialInfo();
        }
        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if(!rbLost.Checked && !rbDamage.Checked)
            {
                MessageBox.Show("Please select valid Reason first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rbDamage.Focus();
                return;
            }
            if (_License == null)
            {
                MessageBox.Show("Please select valid licnese first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!_License.IsActive)
            {
                MessageBox.Show("You can't replace unActive License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (_License.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("Cannot replace an expired license", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Replace the license ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                CollectApplicationInfo();
                if (_Application.Save())
                {
                    CollectReplacedLicenseInfo();
                    _License.IsActive = false;
                    if (_ReplaceLicense.Save() && _License.Save())
                    {
                        MessageBox.Show($"Done issuing the Replacing Licese with LicenseID = {_ReplaceLicense.LicenseID}", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadIntialInfo();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Error , couldn't save the Replaced License info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            frmShowLicenseInfo frm = new frmShowLicenseInfo((_ReplaceLicense == null) ? _License.LicenseID : _ReplaceLicense.LicenseID);
            frm.ShowDialog();
        }
        private void rbDamage_CheckedChanged(object sender, EventArgs e)
        {
            ReasonToReplace = (rbDamage.Checked) ? enReplaceFor.Damage : enReplaceFor.Lost;
            LoadIntialInfo();
        }
        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            ReasonToReplace = (rbLost.Checked) ? enReplaceFor.Lost : enReplaceFor.Damage;
            LoadIntialInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
