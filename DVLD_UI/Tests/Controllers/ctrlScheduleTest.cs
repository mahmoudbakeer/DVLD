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
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication { get { return _LocalDrivingLicenseApplication; } }
        private clsTestType.enTestType _TestType = clsTestType.enTestType.Vision;
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
                            lblTestTitle.Text = "Vision Test";
                            pbMainPicture.Image = Resources.VisionTest;
                            break;
                        }
                    case clsTestType.enTestType.Written:
                        {
                            lblTestTitle.Text = "Written Test";
                            pbMainPicture.Image = Resources.WrittenTest;
                            break;
                        }
                    case clsTestType.enTestType.Street:
                        {
                            lblTestTitle.Text = "Street Test";
                            pbMainPicture.Image = Resources.StreetExam;
                            break;
                        }
                    default: { break; }
                }
            }
        }
            
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {

        }
    }
}
