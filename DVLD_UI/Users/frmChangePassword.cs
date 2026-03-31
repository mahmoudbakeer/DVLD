using DVLD_BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private clsUser _User;
        public clsUser User
        {
            get { return _User; }
        }
        public int UserID
        {
            get { return _UserID; }
        }
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }
        public void LoadInfo(int UserID)
        {
            
            _User = clsUser.Find(UserID);
            if (User == null) return;
            else
            {
                ctrlUserCard1.LoadUser(UserID);
                txtUserName.Text = User.UserName;
                txtPassword.Text = string.Empty;
                txtConfirmpassword.Text = string.Empty;
                cbIsActive.Checked = User.IsActive;
            }
        }
        private void _FillInfo()
        {
            if (!_validatetxtboxes()) return;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = clsHashing.HashString(txtPassword.Text.Trim());
            _User.IsActive = cbIsActive.Checked;
        }
        private bool _validatetxtboxes()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Cannot be empty!");
                txtUserName.Focus();
                return false;
            }
            else if (clsUser.IsUserNameExistForAnotherUser(txtUserName.Text, UserID))
            {
                errorProvider1.SetError(txtUserName, "UserName is taken, choose another!");
                txtUserName.Clear();
                txtUserName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
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
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            LoadInfo(UserID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_validatetxtboxes()) return;
            _FillInfo();
            if(User.Save())
            {
                MessageBox.Show("Done,Informations Updated Successfully!","Successeded",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed,Couldnt Update the information!","Failed",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
