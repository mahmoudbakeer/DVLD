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

namespace DVLD_UI.Licenses.InterNationalLicense.contollers
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        private clsInternationalLicense _InternationalLicense;
        public clsInternationalLicense InternationalLicens { get { return _InternationalLicense; } }
        private int _InternationalLicenseID;
        public int InternationalLicenseID { get { return _InternationalLicenseID; } }
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void LoadInternationalLicenseInfo(int LicenseID)
        {
            _InternationalLicense = clsInternationalLicense.FindByLicenseID(LicenseID);
            if (_InternationalLicense == null)
            {
                MessageBox.Show("The International license id is wrong please make sure it is correct","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
            lblLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblDateOfBirth.Text = _InternationalLicense.ApplicationInfo.PersonInfo.DateOfBirth.ToString();
            lblExpDate.Text = _InternationalLicense.ExpirationDate.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes":"No";
            lblIsDetained.Text = "No"; //TODO is detained
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString();
            lblLicenseClass.Text = clsLicenseClass.GetLicenseClass(_InternationalLicense.LicenseInfo.LicenseClassID).ClassName;
            lblName.Text = _InternationalLicense.ApplicationInfo.PersonInfo.FullName;
            lblNationalNo.Text = _InternationalLicense.ApplicationInfo.PersonInfo.NationalNo;
            if(_InternationalLicense.ApplicationInfo.PersonInfo.ImagePath != string.Empty) pbPersonPicture.Load(_InternationalLicense.ApplicationInfo.PersonInfo.ImagePath);
            return;

        }
    }
}
