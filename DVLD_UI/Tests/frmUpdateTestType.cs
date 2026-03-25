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

namespace DVLD_UI.Tests
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType _TestType;
        public clsTestType TestType
        {
            get { return _TestType; }
        }
        private int _TestTypeID;
        public int TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
        }
        
       
        private void _CollectInfo()
        {
            _TestType.TestTypeTitle = txtTestTypeTitle.Text.Trim();
            if (decimal.TryParse(txtTestFees.Text.Trim(), out decimal fees))
            {
                _TestType.TestTypeFees = fees;
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric fee value.");
                txtTestFees.Focus();
                return;
            }
        }
        private void _LoadInformation()
        {
            _TestType = clsTestType.GetTestType(TestTypeID);
            if (_TestType != null)
            {
                txtTestFees.Text = _TestType.TestTypeFees.ToString();
                txtTestDescription.Text = _TestType.TestTypeDescribtion.ToString();
                txtTestTypeTitle.Text = _TestType.TestTypeTitle.ToString();
                lblTestTypeID.Text = _TestTypeID.ToString();
            }
            else
            {
                MessageBox.Show("Not Exist , The Appliction Type Does Not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();
            this._TestTypeID = TestTypeID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _CollectInfo();
            if (_TestType.UpdateTestType())
            {
                MessageBox.Show("Successfully Updated", "Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error , couldn't update the Data", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtTestFees_Validating(object sender, CancelEventArgs e)
        {
            if (!clsUtil.IsOnlyNumbers(txtTestFees.Text))
            {
                errorProvider1.SetError(txtTestFees, "Only Numbers Are Allowed!");
                txtTestFees.Clear();
                txtTestFees.Focus();
            }
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadInformation();
        }
    }
}
