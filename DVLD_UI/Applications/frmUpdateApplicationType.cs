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

namespace DVLD_UI.Applications
{
    public partial class frmUpdateApplicationType : Form
    {
        private clsApplicationType _ApplicationType;
        public clsApplicationType ApplicationType
        {
            get { return _ApplicationType; }
        }
        private int _ApplicationTypeID;
        public int ApplicationTypeID
        {
            get
            {
                return _ApplicationTypeID;
            }
        }
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _CollectInfo()
        {
            _ApplicationType.ApplicationTypeTitle = txtApplicationTitle.Text.Trim();
            if (decimal.TryParse(txtApplicationFees.Text.Trim(), out decimal fees))
            {
                _ApplicationType.ApplicationTypeFees = fees;
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric fee value.");
                txtApplicationFees.Focus();
                return;
            }
        }
        private void _LoadInformation()
        {
            _ApplicationType = clsApplicationType.GetApplicationType(ApplicationTypeID);
            if (_ApplicationType != null)
            {
                txtApplicationFees.Text = _ApplicationType.ApplicationTypeFees.ToString();
                txtApplicationTitle.Text = _ApplicationType.ApplicationTypeTitle.ToString();
                lblAppID.Text = _ApplicationTypeID.ToString();
            }
            else
            {
                MessageBox.Show("Not Exist , The Appliction Type Does Not Exist!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void txtApplicationFees_Validating(object sender, CancelEventArgs e)
        {
            if(!clsUtil.IsOnlyNumbers(txtApplicationFees.Text))
            {
                errorProvider1.SetError(txtApplicationFees, "Only Numbers Are Allowed!");
                txtApplicationFees.Clear();
                txtApplicationFees.Focus();
            }
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
           _LoadInformation();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _CollectInfo();
            if (_ApplicationType.UpdateApplicationType())
            {
                MessageBox.Show("Successfully Updated","Updated!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error , couldn't update the Data","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
