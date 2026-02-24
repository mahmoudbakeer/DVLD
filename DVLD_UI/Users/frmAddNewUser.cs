using DVLD_BusinessLogic;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Users
{
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
        }
        private bool _tabEnabled = false;
        public bool TabEnabled
        {
            get { return _tabEnabled; }
            set {
                _tabEnabled = value;
                tpUserCredentials.Enabled = value;
            }
        }
        private clsUser user;
        private int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!_validatePerosn()) return;
            else if (tabControl1.SelectedIndex == 1) return;
            tabControl1.SelectedIndex = 1;

        }
        private void GetInfo()
        {
            if (!_validatePerosn()) return;

        }
        private bool _validatetxtboxes()
        {
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Cannot be empty!");
                txtUserName.Focus();
                return false;
            }
            else if(clsUser.isUserExist(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "UserName is taken, choose another!");
                txtUserName.Clear();
                txtUserName.Focus();
                return false;
            }
            if(string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Cannot be empty!");
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtConfirmpassword.Text))
            {
                errorProvider1.SetError(txtConfirmpassword, "Cannot be empty!");
                txtConfirmpassword.Focus();
                return false;
            }
            else if (txtConfirmpassword.Text.Trim() != txtPassword.Text.Trim()) 
            {
                errorProvider1.SetError(txtConfirmpassword, "Confirmation Is wrong!!");
                txtConfirmpassword.Focus();
                return false;
            }
            return true;
        }
        private bool _validatePerosn()
        {
            _PersonID = ctrlPersonCardWithFilter1.PersonID;
            if (PersonID == -1)
            {
                MessageBox.Show("Error Please select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.Focus();
                return false;
            }
            else if (clsUser.IsPersonExistForAnotherUser(PersonID))
            {
                MessageBox.Show("Error This person is taken , please select another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.Focus();
                return false;

            }
            else
            {
                TabEnabled = true;
                return true;
            }
        }
    }
}
