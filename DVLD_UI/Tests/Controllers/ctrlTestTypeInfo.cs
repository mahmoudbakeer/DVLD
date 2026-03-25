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
    public partial class ctrlTestTypeInfo : UserControl
    {
        private clsTestType.enTestType _TestType;
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
                            lblTestTitle.Text = "Scheduled Vision Test";
                            groupBox1.Text = "Vision Test";
                            pbMainPicture.Image = Resources.VisionTest;
                            break;
                        }
                    case clsTestType.enTestType.Written:
                        {
                            lblTestTitle.Text = "Scheduled Written Test";
                            groupBox1.Text = "Written Test";
                            pbMainPicture.Image = Resources.WrittenTest;
                            break;
                        }
                    case clsTestType.enTestType.Street:
                        {
                            lblTestTitle.Text = "Scheduled Street Test";
                            groupBox1.Text = "Street Test";
                            pbMainPicture.Image = Resources.StreetExam;
                            break;
                        }
                    default: { break; }
                }
                lblTestTitle.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
        public ctrlTestTypeInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void LoadTestTypeInfo(int LocalDrivingLicenseApplicationID ,clsTestType.enTestType TestType,int TestID = -1)
        {
            clsLocalDrivingLicenseApplication LDLA = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
            dtpDate.Enabled = false;
            if (LDLA == null)
            {
                lblError.Text = "Application Not found check the Application information";
                return;
            }
            this.TestType = TestType;
            lblDrivingClass.Text = LDLA.LicenseClassInfo.ClassName;
            lblFees.Text = clsTestType.GetTestType((int)TestType).TestTypeFees.ToString(); ;
            lblLDLAID.Text = LDLA.LocalDrivingLicenseApplicationID.ToString();
            lblName.Text = LDLA.PersonInfo.FirstName.ToString() + " " + LDLA.PersonInfo.SecondName.ToString();
            lblTrial.Text = LDLA.HowManyTestsDidHeAttended((int)TestType).ToString();
            lblTestID.Text = (TestID == -1) ? "Not Taken Yet" : TestID.ToString(); 
        }

        private void ctrlTestTypeInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
