using DVLD_BusinessLogic;
using DVLD_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses.Controllers
{
    public partial class ctrlLicenseInfoWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }
        private clsLicense _License {  get; set; }
        public clsLicense License
        {
            get { return _License; }
        }
        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!clsUtil.IsOnlyNumbers(txtLicenseID.Text) || string.IsNullOrEmpty(txtLicenseID.Text))
            {
                MessageBox.Show("Please enter a vaild value to seach for", "InValid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                txtLicenseID.Clear();
                return;
            }
            else
            {
                _License = clsLicense.Find(Convert.ToInt32(txtLicenseID.Text));
                if (_License == null)
                {
                    MessageBox.Show($"The License with ID {txtLicenseID.Text}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLicenseID.Focus();
                    txtLicenseID.Clear();
                    return;
                }
                else
                {
                    ctrlDrivingLicenseInfo1.LoadLicenseInfo(License.LicenseID);
                    if (OnLicenseSelected != null) OnLicenseSelected(License.LicenseID);
                    return;
                }
            }
        }
        public  void LoadInfo(int LicenseID)
        {
            gbFilter.Enabled = false;
            txtLicenseID.Text = LicenseID.ToString();
            ctrlDrivingLicenseInfo1.LoadLicenseInfo(LicenseID);
            return;
        }
        private void ctrlDrivingLicenseInfo1_Load(object sender, EventArgs e)
        {

        }

        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }
    }
}
