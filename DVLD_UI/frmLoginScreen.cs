using DVLD_BusinessLogic;
using DVLD_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class frmLoginScreen : Form
    {
        public string filePath = string.Empty;
        private string _UserName;
        private string _Password;
        public string UserName
        {
            get { return _UserName; }
        }
        public string Password
        {
            get { return _Password; }
        }
        private clsUser _User;
        public frmLoginScreen()
        {
            InitializeComponent();
        }
        bool isSaved(string filepath)
        {
            return clsUtil.GetInfoFromFile(ref _UserName, ref _Password, filepath);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsGlobalUser.gUser = clsUser.GetUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            
            if (clsGlobalUser.gUser != null)
            {
                if (clsGlobalUser.gUser.IsActive)
                {
                    if (cbRememberMe.Checked)
                    {
                        clsUtil.SaveInfoInFile(txtUserName.Text.Trim(),
                        txtPassword.Text.Trim(),
                        filePath);
                    }
                    else
                    {
                        clsUtil.ClearFile(filePath);
                    }
                     
                    this.Hide();
                    frmMainForm frm = new frmMainForm(this);
                    frm.ShowDialog();

                    return;
                }
                else
                {
                    MessageBox.Show("Please Contact Your Adming this User is not Active", "UnActive User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblError.Text = "User Is Not Active!";
                    return;
                }
            }
            else
            {
                txtPassword.Text = string.Empty;
                txtUserName.Text = string.Empty;
                MessageBox.Show("UserName or Password Are Incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblError.Text = "UserName / Password is wrong!";
                return;
            }
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            // Change the direction of the file so it does not break
            filePath = "C:\\Users\\mahmo\\dir\\DVLD\\DVLD_UI\\Logs.txt";
            if (isSaved(filePath))
            {
                txtUserName.Text = UserName.Trim();
                txtPassword.Text = Password.Trim();
                cbRememberMe.Checked = true;
            }
            else
            {
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                cbRememberMe.Checked = false;
            }
        }
    }
}
