using DVLD_BusinessLogic;
using DVLD_UI.People;
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
namespace DVLD_UI.Licenses.InterNationalLicense
{
    public partial class frmInternationalLicenseApplication : Form
    {
        clsLicense _License;
        clsApplication _Application = new clsApplication();
        clsInternationalLicense _InternationalLicense = new clsInternationalLicense();

        public frmInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        private void LoadIntialInfo()
        {
            if (_License != null)
            {
                btnShowPersonInfo.Enabled = true;
                btnShowPersonInfo.Visible = true;
                btnShowLicensesHistory.Enabled = true;
                btnShowLicenseInfo.Enabled = true;
            }
            else
            {
                btnShowPersonInfo.Enabled = false;
                btnShowPersonInfo.Visible = false;
                btnShowLicensesHistory.Enabled = false;
                btnShowLicenseInfo.Enabled = false;
            }
            lblApplicationID.Text = _Application == null ? "Not applied yet" : _InternationalLicense.ApplicationInfo.ApplicationID.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblLicenseIssueDate.Text = (_License == null) ? "Not Selected Yet" : _License.IssueDate.ToString();
            lblLicenseExpDate.Text = (_License == null) ? "Not Selected Yet" : _License.ExpirationDate.ToString();
            lblLocalLicenseID.Text = (_License == null) ? "Not Selected Yet" : _License.LicenseID.ToString();
            lblInternationalLicenseID.Text = "TODO ";
            lblCreatedBy.Text = clsGlobalUser.gUser.UserName;
            lblFees.Text = clsApplicationType.GetApplicationType((int)clsApplication.eApplicationType.NewInterNationalLicense).ApplicationTypeFees.ToString();

        }
        private void CollectInternationalLicenseInfo()
        {
            _InternationalLicense.LicenseID = _License.LicenseID;
            _InternationalLicense.DriverID = _License.DriverID;
            _InternationalLicense.ApplicationID = _Application.ApplicationID;
            _InternationalLicense.ExpirationDate = _License.ExpirationDate;
            _InternationalLicense.IssueDate = _License.IssueDate;
            _InternationalLicense.CreatedByUserID = clsGlobalUser.gUser.ID;
            _InternationalLicense.IsActive = _License.IsActive;
        }
        private void CollectApplicationInfo()
        {
            _Application.ApplicantPersonID = _License.LocalDrivingApplicationInfo.ApplicantPersonID;
            _Application.ApplicationStatus = clsApplication.eApplicationStatus.Completed;
            _Application.ApplicationTypeID = (int)clsApplication.eApplicationType.NewInterNationalLicense;
            _Application.ApplicationDate= DateTime.Now;
            _Application.LastStatusDate = DateTime.Now;
            _Application.CreatedByUserID = clsGlobalUser.gUser.ID;
            _Application.PaidFees = clsApplicationType.GetApplicationType((int)clsApplication.eApplicationType.NewInterNationalLicense).ApplicationTypeFees;
        }
        private void frmInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            LoadIntialInfo();
        }
        
        private void btnIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            if(_License == null)
            {
                MessageBox.Show("Please select valid licnese first","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else if(clsInternationalLicense.IsLicenseHasInternationalLicense(_License.LicenseID))
            {
                MessageBox.Show("Already there is International License for this License , you cannot apply for more", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                LoadIntialInfo();
                CollectApplicationInfo();
                if (_Application.Save())
                {
                    CollectInternationalLicenseInfo();
                    if (_InternationalLicense.Save())
                    {
                        MessageBox.Show("Successed ,Done issuing the International Licese", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadIntialInfo();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Error , couldn't save the international License info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _License = clsLicense.Find(obj);
            LoadIntialInfo();
        }

        private void btnShowLicenseInfo_Click(object sender, EventArgs e)
        {
            if (_License == null)
            {
                MessageBox.Show("Please select valid licnese first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_License.LicenseID);
            frm.ShowDialog();
        }

        private void btnShowPersonInfo_Click(object sender, EventArgs e)
        {
            if (_License == null)
            {
                MessageBox.Show("Please select valid licnese first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmShowPersonInfo frm = new frmShowPersonInfo(_License.LocalDrivingApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
