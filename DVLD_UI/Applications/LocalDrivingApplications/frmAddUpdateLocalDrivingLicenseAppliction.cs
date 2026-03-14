using DVLD_BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications
{
    public partial class frmAddUpdateLocalDrivingLicenseAppliction : Form
    {
        private clsLocalDrivingLicenseApplication _LDLA;
        public clsLocalDrivingLicenseApplication LDLA
        {
            get { return _LDLA; }
        }
        int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }
        }
        int _LDLAID;
        public int LDLAID
        {
            get { return _LDLAID; }
        }
        private bool _tabEnabled = false;
        public bool TabEnabled
        {
            get { return _tabEnabled; }
            set
            {
                _tabEnabled = value;
                tpApplicationInfo.Enabled = value;
            }
        }
        enum eMode { AddNew = 1 , Update = 2};
        private eMode _Mode;
        public frmAddUpdateLocalDrivingLicenseAppliction(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LDLAID = LocalDrivingLicenseApplicationID;
            _Mode = eMode.Update;
        }
        public frmAddUpdateLocalDrivingLicenseAppliction()
        {
            InitializeComponent();
            _Mode = eMode.AddNew;
        }
        private void tpApplicationInfo_Click(object sender, EventArgs e)
        {

        }
        private bool _validatePerosn()
        {
            _PersonID = ctrlPersonCardWithFilter1.PersonID;
            if (!clsPerson.isPersonExist(PersonID))
            {
                MessageBox.Show("Error Please select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.Focus();
                tabControl1.SelectedIndex = 0;
                TabEnabled = false;
                return false;
            }
            else
            {
                TabEnabled = true;
                return true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!_validatePerosn()) return;
            else if (tabControl1.SelectedIndex == 1) return;
            tabControl1.SelectedIndex = 1;
        }
        void _LoadDefaultValues()
        {
            if (_Mode == eMode.Update) {
                lblMainTitle.Text = "Update Application Info";
                _LDLA = clsLocalDrivingLicenseApplication.Find(LDLAID);
                if (_LDLA == null) this.Close();
                _PersonID = LDLA.ApplicantPersonID;
                ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);
                TabEnabled = true;
                lblApplivationID.Text = LDLAID.ToString();
                lblApplicationDate.Text = LDLA.ApplicationDate.ToString();
                lblApplicationFees.Text = LDLA.PaidFees.ToString();
                lblCreatedBy.Text = LDLA.UserInfo.UserName.ToString();
                cbLicenseClasses.SelectedItem = LDLA.LicenseClassInfo.ClassName; 
            }
            else
            {
                _LDLA = new clsLocalDrivingLicenseApplication();
                lblMainTitle.Text = "Add New Application";
                TabEnabled = false;
                lblApplivationID.Text = "###";
                lblApplicationDate.Text = DateTime.Now.ToString();
                lblApplicationFees.Text = clsApplicationType.GetApplicationType(1).ApplicationTypeFees.ToString();
                lblCreatedBy.Text = clsGlobalUser.gUser.UserName.ToString();
                cbLicenseClasses.SelectedIndex = 0;
            }
        }
        private void frmAddNewAppliction_Load(object sender, EventArgs e)
        {
            
            _LoadDefaultValues();
        }
        void CollectInformations()
        {
            if(!_validatePerosn()) return;
            LDLA.LicenseClassID = clsLicenseClass.GetLicenseClass(cbLicenseClasses.SelectedItem.ToString()).LicenseClassID;
            LDLA.CreatedByUserID = clsGlobalUser.gUser.ID;
            LDLA.PaidFees = clsApplicationType.GetApplicationType(1).ApplicationTypeFees;
            LDLA.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            LDLA.ApplicationTypeID = ((int)clsApplication.eApplicationType.NewLocalDrivingLicenseService);
            LDLA.ApplicationStatus = clsApplication.eApplicationStatus.New;
            LDLA.ApplicationDate = DateTime.Now;
            LDLA.LastStatusDate = DateTime.Now;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_validatePerosn()) return;
            CollectInformations();
            //if(clsLocalDrivingLicenseApplication.DoesPersonHaveActiveApplication(LDLA.ApplicantPersonID,LDLA.ApplicationTypeID))
            //{
            //    MessageBox.Show("Error,The Person Already have active application of same type\n Please choose another type","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    return;
            //}
            if(clsLocalDrivingLicenseApplication.DoesPersonHaveUnCompletedApplicationFromSameLicenseClass(LDLA.ApplicantPersonID,LDLA.LicenseClassID))
            {
                MessageBox.Show("Error,The Person Already have UnCompleted application of same License Class , Please choose another License Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClasses.Focus();
                  return;
            }
            //if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            //{

            //    MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (LDLA.Save())
            {
                MessageBox.Show("Succeseded", "Information Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = eMode.Update;
                _LDLAID = LDLA.LocalDrivingLicenseApplicationID;
                _LoadDefaultValues();
            }
            else
            {
                MessageBox.Show("Error", "Error Happened While Updating the information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLicenseClasses_Validating(object sender, CancelEventArgs e)
        {
            if (clsPerson.Find(PersonID).Age < clsLicenseClass.GetLicenseClass(cbLicenseClasses.SelectedItem.ToString()).MinimumAllowedAge)
            {
                MessageBox.Show("Error","You cannot choose this because of the age restriction.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                cbLicenseClasses.Focus();
                return;
            }
        }
    }
}
