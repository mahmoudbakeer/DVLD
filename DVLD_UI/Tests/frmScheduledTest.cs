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
using static DVLD_BusinessLogic.clsTestType;

namespace DVLD_UI.Tests
{
    public partial class frmScheduledTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        int _AppointmentID;
        public int AppointmentID { get { return _AppointmentID; } }
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication { get { return _LocalDrivingLicenseApplication; } }
        private clsTestType.enTestType _TestType = clsTestType.enTestType.Vision;
        clsTestAppointment _Appointment;
        public clsTestAppointment Appointment { get { return _Appointment; } }
        public frmScheduledTest(int LocalDrivingLicenseApplicationID , int AppointmentID , clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            _AppointmentID= AppointmentID;
            _TestType = TestType;
        }
        private void frmScheduledTest_Load(object sender, EventArgs e)
        {
            ctrlTestTypeInfo1.LoadTestTypeInfo(_LocalDrivingLicenseApplicationID,_TestType);
            _Appointment = clsTestAppointment.Find(AppointmentID);
            if( _Appointment == null )
            {
                MessageBox.Show("This Appointment is not valid please make sure the id is correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }
            if (clsLocalDrivingLicenseApplication.DoestPersonPassTheTest(_LocalDrivingLicenseApplicationID, (int)_TestType))
            {
                MessageBox.Show("This Person Have Already passed this test you cannot add new appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool _ValidateResult()
        {
            if(!rbtnFail.Checked && !rbtnPass.Checked)
            {
                MessageBox.Show("Please Select a result", "Error");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateResult()) return;
            clsTest Test = new clsTest();
            Test.TestAppointmentID = _AppointmentID;
            Test.TestResult = (rbtnPass.Checked && !rbtnFail.Checked) ? true : false;
            Test.Notes = textBox1.Text;
            Test.CreatedByUserID = clsGlobalUser.gUser.ID;
            _Appointment.IsLocked = true;
            if(Test.Save() && _Appointment.Save())
            {
                MessageBox.Show("Succeseded", "Test Result Subitted Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Error", "Test Result Was Not Subitted ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
