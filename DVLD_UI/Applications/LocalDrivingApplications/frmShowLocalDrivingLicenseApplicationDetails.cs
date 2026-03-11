using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.LocalDrivingApplications
{
    public partial class frmShowLocalDrivingLicenseApplicationDetails : Form
    {
        private int _LDLA;
        public int LDLA
        {
            get {  return _LDLA; }
        }
        public frmShowLocalDrivingLicenseApplicationDetails(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LDLA = LocalDrivingLicenseApplicationID;
        }

        private void frmShowLocalDrivingLicenseApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplicationInfo1.LoadDLAInformation(_LDLA);
        }
    }
}
