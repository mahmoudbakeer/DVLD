using DVLD_BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Users
{
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID = -1;
        clsUser _User;
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        private void LoadUserInfo() { 
            //clsPerson Person = clsPerson.Find()
        }
        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                _User = new clsUser();
                tpUserCred.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update User";
                _User = new clsUser();
                tpUserCred.Enabled = true;
            }


            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            cbIsActive.Checked = true;
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(_Mode == enMode.Update)
                _LoadData();
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);
            if( _User == null )
            {
                MessageBox.Show("No Such User ", "Failed To Find User");
                this.Close();
                return;
            }
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            cbIsActive.Enabled = _User.IsActive;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            return;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpUserCred.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpUserCred"];
            }
            if(ctrlPersonCardWithFilter1.PersonID != -1)
            {
                if(clsUser.IsPersonExistForAnotherUser(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpUserCred.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Cannot be blank!");
                txtUserName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtUserName,null);
            }

            if(_Mode == enMode.AddNew)
            {
                if(clsUser.isUserExist(txtUserName.Text.Trim()))
                {
                    errorProvider1.SetError(txtUserName, "Username is taken for another user.");
                    txtUserName.Clear();
                    txtUserName.Focus();
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
            }
            else
            {
                if(_User.UserName != txtUserName.Text.Trim())
                {
                    errorProvider1.SetError(txtUserName, "Username is taken for another user.");
                    txtUserName.Clear();
                    txtUserName.Focus();
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtPassword, "Cannot be blank!");
                txtUserName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                errorProvider1.SetError(txtPassword, "The Password should match");
                txtUserName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.Password = txtPassword.Text;
            _User.UserName = txtUserName.Text;
            _User.IsActive = cbIsActive.Checked;
            if(_User.Save())
            {
                lblTitle.Text = "Update User Info";
                _Mode = enMode.Update;
                MessageBox.Show("Data Added Successfully","Done!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Add the Data", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
