using DVLD_BusinessLogic;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Users
{
    public partial class frmAddUpdateUser : Form
    {
        enum enMode {Addnew = 1 , Update =2};
        private enMode _Mode;
        private bool _tabEnabled = false;
        public bool TabEnabled
        {
            get { return _tabEnabled; }
            set
            {
                _tabEnabled = value;
                tpUserCredentials.Enabled = value;
            }
        }
        private clsUser user = new clsUser();
        private int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }
        }
        private int _UserID;
        public int UserID
        {
            get { return _UserID; }
        }
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.Addnew;

        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }
        void InitializeInfo()
        {
            if (_Mode == enMode.Addnew)
            {
                lblMainTitle.Text = "ADD NEW USER";
                _setDefaultInfo();
                TabEnabled = false;
            }
            else
            {
                lblMainTitle.Text = "UPDATE USER";
                user = clsUser.Find(UserID);
                if (user != null) 
                {
                    LoadUserInfo();
                }
            }
        }
        private void _setDefaultInfo()
        {
            ctrlPersonCardWithFilter1.Enabled = true;
            TabEnabled = false;
            _PersonID = -1;
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmpassword.Text = "";
            cbIsActive.Checked = false;
        }
        public void LoadUserInfo()
        {
            user = clsUser.Find(UserID);
            ctrlPersonCardWithFilter1.LoadPersonInfo(user.PersonID);
            ctrlPersonCardWithFilter1.Enabled = false;
            _PersonID = user.PersonID;
            TabEnabled = true;
            txtUserName.Text = user.UserName;
            txtPassword.Text = string.Empty;
            txtConfirmpassword.Text = string.Empty;
            if (_Mode == enMode.Update)
            {
                txtConfirmpassword.Enabled = false;
                txtPassword.Enabled = false;
            }
            cbIsActive.Checked = user.IsActive;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!_validatePerosn()) return;
            else if (tabControl1.SelectedIndex == 1) return;
            else tabControl1.SelectedIndex = 1;

        }
        private bool GetInfo()
        {
            if (!_validatePerosn()) return false;
            if(!_validatetxtboxes()) return false;
            if (_Mode == enMode.Addnew) user.Password = clsHashing.HashString(txtPassword.Text);
            user.PersonID = PersonID;
            user.UserName = txtUserName.Text;
            user.IsActive = cbIsActive.Checked;
            return true;
        }
        private bool _validatetxtboxes()
        {
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Cannot be empty!");
                txtUserName.Focus();
                return false;
            }
            else if(_Mode == enMode.Update && clsUser.IsUserNameExistForAnotherUser(txtUserName.Text,UserID))
            {
                errorProvider1.SetError(txtUserName, "UserName is taken, choose another!");
                txtUserName.Clear();
                txtUserName.Focus();
                return false;
            }
            if(_Mode == enMode.Addnew && string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Cannot be empty!");
                txtPassword.Focus();
                return false;
            }
            if (_Mode == enMode.Addnew && string.IsNullOrEmpty(txtConfirmpassword.Text))
            {
                errorProvider1.SetError(txtConfirmpassword, "Cannot be empty!");
                txtConfirmpassword.Focus();
                return false;
            }
            else if (_Mode == enMode.Addnew && txtConfirmpassword.Text.Trim() != txtPassword.Text.Trim()) 
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
            if (!clsPerson.isPersonExist(PersonID))
            {
                MessageBox.Show("Error Please select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.Focus();
                return false;
            }
            else if (clsUser.IsPersonExistForAnotherUser(PersonID) && _Mode == enMode.Addnew)
            {
                MessageBox.Show("This person is taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.Focus();
                return false;
            }
            else
            {
                TabEnabled = true;
                return true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!GetInfo()) return;
            else
            
            {
                if (MessageBox.Show("Are you sure you want to save the user Info ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                if (user.Save())
                {
                    MessageBox.Show("Data Added Successfully!","Successeded",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Error occured,while adding the informations!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            InitializeInfo();


        }
    }
}
