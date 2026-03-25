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

namespace DVLD_UI.Tests.TestAppointments
{
    public partial class frmManageTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private DataTable _dtTestAppointments;
        private clsTestType.enTestType _TestType;
        public int LocalDrivingLicenseApplicationID { get { return _LocalDrivingLicenseApplicationID; } }
        public clsTestType.enTestType TestType { get { return _TestType; }
            set { _TestType = value;
                switch(value)
                {
                    case clsTestType.enTestType.Vision:
                        lblMainTitle.Text = "Visoin Test Appointments";
                        break;
                    case clsTestType.enTestType.Written:
                        lblMainTitle.Text = "Written Test Appointments";
                        break;
                    case clsTestType.enTestType.Street:
                        lblMainTitle.Text = "Street Test Appointments";
                        break;
                }
            }
        }
        public frmManageTestAppointments(int localDrivingLicenseApplicationID, clsTestType.enTestType testType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.TestType = testType;
        }
        void _LoadTestAppointments()
        {
            if (clsLocalDrivingLicenseApplication.DoestPersonPassTheTest(LocalDrivingLicenseApplicationID, (int)TestType))
            {
                btnAddAppointment.Enabled = false;
                editTestAppointmentToolStripMenuItem.Enabled = false;
                takeTestToolStripMenuItem.Enabled = false;
            }
            _dtTestAppointments = clsTestAppointment.GetAllTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, TestType);
            // TODO the Alignments
            dgvTestAppoiments.DataSource = _dtTestAppointments;
            dgvTestAppoiments.Columns[0].Width = 100;
            dgvTestAppoiments.Columns[1].Width = 250;
            dgvTestAppoiments.Columns[2].Width = 250;
            dgvTestAppoiments.Columns[3].Width = 150;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestAppointments();
            ctrlLocalDrivingLicenseApplicationInfo1.LoadDLAInformation(_LocalDrivingLicenseApplicationID);

        }
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (clsLocalDrivingLicenseApplication.DoestPersonPassTheTest(LocalDrivingLicenseApplicationID, (int)TestType)) 
            {
                MessageBox.Show("This Person Have Already passed this test you cannot add new appointment","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduleTest frm = new frmScheduleTest(LocalDrivingLicenseApplicationID,TestType);
            frm.ShowDialog();
            _LoadTestAppointments();
        }
        private void editTestAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.IsAppointmentsLocked((int)dgvTestAppoiments.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("This Person Have Already take this test you cannot add new appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduleTest frm = new frmScheduleTest(LocalDrivingLicenseApplicationID, TestType, (int)dgvTestAppoiments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadTestAppointments();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.IsAppointmentsLocked((int)dgvTestAppoiments.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("This Person Have Already take this test you cannot add new appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduledTest frm = new frmScheduledTest(LocalDrivingLicenseApplicationID,  (int)dgvTestAppoiments.CurrentRow.Cells[0].Value , TestType);
            frm.ShowDialog();
            _LoadTestAppointments();
        }
    }
}
