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
            
        }
    }
}
