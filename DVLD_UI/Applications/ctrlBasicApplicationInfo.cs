using DVLD_BusinessLogic;
using DVLD_UI.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications
{
    public partial class ctrlBasicApplicationInfo : UserControl
    {
        private clsApplication _Application;
        public clsApplication Application {  get { return _Application; } }
        public ctrlBasicApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.Find(ApplicationID);
            if (_Application == null)
            {
                MessageBox.Show("Invalid Application ID , Application Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnShowPersonInfo.Enabled = false;
                return;
            }
            else
            {
                lblApplicationID.Text = _Application.ApplicationID.ToString();
                lblApplicantID.Text = _Application.PersonInfo.FirstName.ToString();
                lblApplicationType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle.ToString(); ;
                lblFees.Text = _Application.PaidFees.ToString();
                lblStatusDate.Text = _Application.LastStatusDate.ToString();
                lblDate.Text = _Application.ApplicationDate.ToString();
                lblCreatedBy.Text = _Application.UserInfo.UserName.ToString();
                lblStatus.Text = _Application.getStatusText;
            }

        }

        private void btnShowPersonInfo_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(Application.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void gpApplicationBasicInfo_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlBasicApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
