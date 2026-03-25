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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UI.Licenses
{
    public partial class frmDetainLicense : Form
    {
        private clsDetainedLicense _DetainedLicense;
        private clsLicense _License;
        private int _LicenseID;
        public frmDetainLicense(int LicenseID = -1)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
           
            LoadIntialInfo();
        }
        private void LoadIntialInfo()
        {

            if (_DetainedLicense != null)
            {
                lblDetianID.Text = _DetainedLicense.DetainedID.ToString();
            }
            else
            {
                lblDetianID.Text = "Not Detained Yet";
            }
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
            lblDetainDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblCreatedByUser.Text = clsGlobalUser.gUser.UserName;
            lblLicenseID.Text = (_License != null) ? _License.LicenseID.ToString() : "Not Selected";
        }
        

        private void CollectDetainedInfo()
        {
            _DetainedLicense = new clsDetainedLicense();
            _DetainedLicense.DetainDate = DateTime.Now;
            _DetainedLicense.CreatedByUserID = clsGlobalUser.gUser.ID;
            _DetainedLicense.FineFees =Convert.ToDecimal(txtFineFees.Text);
            _DetainedLicense.LicenseID = _License.LicenseID;
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
            else if(clsDetainedLicense.IsLicenseDetained(_License.LicenseID))
            {
                MessageBox.Show("this License is already Detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!_License.IsActive)
            {
                MessageBox.Show("You can't Detain unActive License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (_License.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("Cannot Detain an expired license", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(string.IsNullOrEmpty(txtFineFees.Text))
            {
                MessageBox.Show("Please Select Fine Fees first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFineFees.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Detain the license ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                CollectDetainedInfo();
                if (_DetainedLicense.Save())
                {
                    MessageBox.Show($"Done Detaining the Licese the Detain ID = {_DetainedLicense.LicenseID}", "Successeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadIntialInfo();
                    return;
                }
                else
                {
                    MessageBox.Show("Error , couldn't save the Detain License info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
