using DVLD_BusinessLogic;
using DVLD_UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Tests.Controllers
{
    public partial class ctrlScheduleTest : UserControl
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        int _AppointmentID;
        public int AppointmentID { get { return _AppointmentID; } }
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication { get { return _LocalDrivingLicenseApplication; } }
        private clsTestType.enTestType _TestType = clsTestType.enTestType.Vision;
        clsTestAppointment _Appointment = new clsTestAppointment();
        private int _RetakeTestAppID = -1;
        public clsTestAppointment Appointment { get { return _Appointment; } }
        enum enCreation { FirstTime =1 , RetakeTest = 2};
        enum enMode { AddNew =1 , Update =2 };
        enCreation _Creation;
        enMode _Mode;
        public clsTestType.enTestType TestType
        {
            get { return _TestType; }
            set
            {
                _TestType = value;
                switch (value)
                {
                    case clsTestType.enTestType.Vision:
                        {
                            lblTestTitle.Text = "Schedule Vision Test";
                            pbMainPicture.Image = Resources.VisionTest;
                            break;
                        }
                    case clsTestType.enTestType.Written:
                        {
                            lblTestTitle.Text = "Schedule Written Test";
                            pbMainPicture.Image = Resources.WrittenTest;
                            break;
                        }
                    case clsTestType.enTestType.Street:
                        {
                            lblTestTitle.Text = "Schedule Street Test";
                            pbMainPicture.Image = Resources.StreetExam;
                            break;
                        }
                    default: { break; }
                }
                lblTestTitle.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
        public void LoadInfo(int LocalDrivingLicenseApplicationID , clsTestType.enTestType enTestType,int appointmentID = -1)
        {
            TestType = enTestType;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
            //dtpDate.MinDate = DateTime.Now;
            if (_LocalDrivingLicenseApplication == null)
            {
                
                this.Enabled = false;
                lblError.Text = "Application Not found check the Application information";
                return;
            }
            if(appointmentID == -1)
            {
                dtpDate.MinDate = DateTime.Now;
                _Mode = enMode.AddNew;
            }
            else
            {
                _AppointmentID = appointmentID;
                LoadAppointmentData();
                _Mode = enMode.Update;
            }
            if(LocalDrivingLicenseApplication.DoesThisPersonAttentTheTest((int)TestType))
            {
                decimal RetakeFees = clsApplicationType.GetApplicationType((int)clsApplication.eApplicationType.RetakeTest).ApplicationTypeFees;
                _Creation = enCreation.RetakeTest;
                gbRetakeTest.Enabled = true;
                lblRAppFees.Text = RetakeFees.ToString();
                lblTestTitle.Text = "Retake " + lblTestTitle.Text;
                lblRTestAppID.Text = "0";
                lblRTotalFees.Text= (clsTestType.GetTestType((int)TestType).TestTypeFees + RetakeFees).ToString();
            }
            else
            {
                _Creation = enCreation.FirstTime;
                gbRetakeTest.Enabled = false;
            }
            lblDrivingClass.Text = LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFees.Text = LocalDrivingLicenseApplication.LicenseClassInfo.ClassFees.ToString();
            lblLDLAID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblName.Text = LocalDrivingLicenseApplication.PersonInfo.FirstName.ToString() + " "+ LocalDrivingLicenseApplication.PersonInfo.SecondName.ToString();
            lblTrial.Text = LocalDrivingLicenseApplication.HowManyTestsDidHeAttended((int)TestType).ToString();

            if (!_HandleActiveTestConstraint()) return;
            if (!_HandleAppointmentLockedConstraint()) return;
        }
        private void LoadAppointmentData()
        {
            _Appointment = clsTestAppointment.Find(AppointmentID);
            if (_Appointment == null)
            {
                MessageBox.Show("Error", "The Appointment ID is wrong cannot process further", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }
            else
            {
                dtpDate.Value = (DateTime)Appointment.AppointmentDate;
                if(Appointment.RetakeTestApplicationID != -1)
                {
                    lblRTestAppID.Text = Appointment.RetakeTestApplicationID.ToString();
                    lblRAppFees.Text = Appointment.RetakeTestAppInfo.PaidFees.ToString();
                    lblFees.Text = Appointment.PaidFees.ToString();
                }
            }

        }
        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {
        }
        private bool _HandleActiveTestConstraint()
        {
            if(_Mode == enMode.AddNew && LocalDrivingLicenseApplication.DoesPersonHaveActiveSheduledTest((int)TestType))
            {
                this.Enabled = false;
                lblError.Text = "This Application Have an active Appointment you cannot open new one until colsing the previous";
                return false;
            }
            return true;
        }
        private bool _HandleAppointmentLockedConstraint()
        {
            if(Appointment != null && Appointment.IsLocked)
            {
                lblError.Text = "This Appointment is already completed , you can't modify it.";
                this.Enabled = false;
                return false;
            }
            return true;
        }
        private bool _CollectRetakeTestInfo()
        {
            if (_Mode == enMode.AddNew && _Creation == enCreation.RetakeTest)
            {
                clsApplication application = new clsApplication();
                application.ApplicationStatus = clsApplication.eApplicationStatus.Completed;
                application.ApplicationTypeID = (int)clsApplication.eApplicationType.RetakeTest;
                application.ApplicantPersonID = LocalDrivingLicenseApplication.ApplicantPersonID;
                application.CreatedByUserID = clsGlobalUser.gUser.ID;
                application.LastStatusDate = DateTime.Now;
                application.ApplicationDate = DateTime.Now;
                application.PaidFees = clsApplicationType.GetApplicationType((int)clsApplication.eApplicationType.RetakeTest).ApplicationTypeFees;
               if(!application.Save())
                {
                    MessageBox.Show("Error","couldn't save the Retake test application , something wrong with the information passed.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.Enabled=false;
                    return false;
                }
                application = clsApplication.Find(application.ApplicationID);
               lblRTestAppID.Text = application.ApplicationID.ToString();
               _Appointment.RetakeTestApplicationID = application.ApplicationID;
               return true;
            }
            else return true;
        }
        private void _CollectAppoitmentInfo()
        {
            if(_Appointment == null)
            {
                _Appointment = new clsTestAppointment();
            }
            _Appointment.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _Appointment.AppointmentDate = dtpDate.Value;
            _Appointment.CreatedByUserID = clsGlobalUser.gUser.ID ;
            _Appointment.TestClassID = TestType;
            _Appointment.PaidFees = Convert.ToDecimal(lblFees.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_CollectRetakeTestInfo()) return;
            _CollectAppoitmentInfo();
            if (_Appointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
