using DVLD_BusinessLogic;
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

namespace DVLD_UI.Tests
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestType;
        private int _AppoointmentID;
        public int LocalDrivingLicenseApplicationID {  get { return _LocalDrivingLicenseApplicationID; } }
        public int AppointmentID {  get { return _AppoointmentID; } }
        public clsTestType.enTestType TestType { get { return _TestType; } }
        public frmScheduleTest(int LocalDrivingLicenseApplicationID , clsTestType.enTestType TestType , int AppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
            _AppoointmentID = AppointmentID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.LoadInfo(LocalDrivingLicenseApplicationID,TestType, AppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
