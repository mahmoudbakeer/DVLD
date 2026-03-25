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

namespace DVLD_UI.Applications.LocalDrivingApplications.RenewLocalDrivingLicense
{
    public partial class frmRenewLocalDrivingLicense : Form
    {
        private clsLicense _RenewLicense;
            private clsLicense _License;
            private clsLocalDrivingLicenseApplication _Application;
            decimal LicenseFees = 0;
            decimal ApplicationFees = 0;
            public frmRenewLocalDrivingLicense()
            {
                InitializeComponent();
            }
            private void LoadIntialInfo()
            {
                if(_RenewLicense != null)
                {
                    lblRenewedLicenseID.Text = _RenewLicense.LicenseID.ToString();
                 
                }
                if (_License != null)
                {
                    btnShowLicensesHistory.Enabled = true;
                    btnShowLicenseInfo.Enabled = true;
                    LicenseFees = _License.PaidFees;
                }
                else
                {
                    btnShowLicensesHistory.Enabled = false;
                    btnShowLicenseInfo.Enabled = false;
                    
                }
                ApplicationFees = (_License == null) ? 0 : clsApplicationType.GetApplicationType((int)clsApplication.eApplicationType.RenewDrivingLicenseService).ApplicationTypeFees;
                lblApplicationID.Text = _RenewLicense == null ? "Not Selected yet" : _RenewLicense.LocalDrivingLicenseApplicationID.ToString();
                lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                lblLicenseIssueDate.Text = (_License == null)
                    ? "Not Selected Yet"
                    : _License.IssueDate.ToString("yyyy-MM-dd");

                lblLicenseExpirationDate.Text = (_License == null)
                    ? "Not Selected Yet"
                    : _License.ExpirationDate.ToString("yyyy-MM-dd");
                lblOldLicenseID.Text = (_License == null) ? "Not Selected Yet" : _License.LicenseID.ToString();
                lblRenewedLicenseID.Text = _RenewLicense == null ? "Not Renewed":_RenewLicense.LicenseID.ToString();
                lblCreatedByUser.Text = clsGlobalUser.gUser.UserName;
                lblLicenseFees.Text = (_License == null) ? "Not Selected Yet" : clsLicenseClass.GetLicenseClass(_License.LicenseClassID).ClassFees.ToString();
                lblApplicationFees.Text = ApplicationFees.ToString();
                lblTotalFees.Text = (LicenseFees + ApplicationFees).ToString();
            }
            private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
            {

            }
            private void CollectRenewLicenseInfo()
            {
                _RenewLicense = new clsLicense();
                _RenewLicense.DriverID = _License.DriverID;
                _RenewLicense.PaidFees = ApplicationFees + clsLicenseClass.GetLicenseClass(_License.LicenseClassID).ClassFees;
                _RenewLicense.LocalDrivingLicenseApplicationID = _Application.LocalDrivingLicenseApplicationID;
                _RenewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.GetLicenseClass(_License.LicenseClassID).DefaultValiditLength);
                _RenewLicense.IssueDate = DateTime.Now;
                _RenewLicense.CreatedByUserID = clsGlobalUser.gUser.ID;
                _RenewLicense.IsActive = _License.IsActive;
                _RenewLicense.LicenseClassID = _License.LicenseClassID;
                _RenewLicense.Notes = txtNotes.Text;
                _RenewLicense.IssueReason = "Renew License";
            }
            private void CollectApplicationInfo()
            {
                _Application = new clsLocalDrivingLicenseApplication();
                _Application.ApplicantPersonID = _License.LocalDrivingApplicationInfo.ApplicantPersonID;
                _Application.ApplicationStatus = clsApplication.eApplicationStatus.Completed;
                _Application.ApplicationTypeID = (int)clsApplication.eApplicationType.RenewDrivingLicenseService;
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
                if (_License == null)
                {
                    MessageBox.Show("Please select valid licnese first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!_License.IsActive)
                {
                    MessageBox.Show("You can't Renew unActive License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (_License.ExpirationDate > DateTime.Now)
                {
                    MessageBox.Show("There still time , the License not expired you can't renew it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (clsLicense.DoesPersonHaveUnExpiredLicenseOfSameType(_License.LicenseID, _License.LocalDrivingApplicationInfo.ApplicantPersonID, _License.LicenseClassID))
                {
                    MessageBox.Show("Already there is Unexpired License for this License , you cannot apply for more", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    {
                        if(MessageBox.Show("Are you sure you want ro renew the license ?","Attention",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
                        {
                             return;
                        }
                        LoadIntialInfo();
                        CollectApplicationInfo();
                        if (_Application.Save())
                        {
                            CollectRenewLicenseInfo();
                            _License.IsActive = false;
                            if (_RenewLicense.Save()&&_License.Save())
                            {
                                MessageBox.Show($"Done issuing the Renewed Licese with LicenseID = {_RenewLicense.LicenseID}", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadIntialInfo();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Error , couldn't save the Renewed License info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            frmShowLicenseInfo frm = new frmShowLicenseInfo((_RenewLicense == null) ? _License.LicenseID:_RenewLicense.LicenseID);
            frm.ShowDialog();
        }

        private void gpApplicationInfo_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}

        
   
