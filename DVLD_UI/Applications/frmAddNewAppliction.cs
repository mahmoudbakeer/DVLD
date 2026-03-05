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
    public partial class frmAddNewAppliction : Form
    {
        
        int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }
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
        public frmAddNewAppliction(int )
        {
            InitializeComponent();
            
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
            lblCreatedBy.Text = clsGlobalUser.gUser.UserName.ToString().Trim();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = ApplictaionType.ApplicationTypeFees.ToString();

        }
        private void frmAddNewAppliction_Load(object sender, EventArgs e)
        {
            _LoadDefaultValues();
        }
    }
}
