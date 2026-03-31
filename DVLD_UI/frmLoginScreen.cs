using DVLD_BusinessLogic;
using System;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class frmLoginScreen : Form
    {
        private string _UserName = string.Empty;
        private string _Password = string.Empty;

        public string UserName
        {
            get { return _UserName; }
        }

        public string Password
        {
            get { return _Password; }
        }

        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsGlobalUser.gUser = clsUser.GetUserByUserNameAndPassword(
                txtUserName.Text.Trim(),
                clsHashing.HashString(txtPassword.Text.Trim()));

            if (clsGlobalUser.gUser != null)
            {
                if (clsGlobalUser.gUser.IsActive)
                {
                    if (cbRememberMe.Checked)
                    {
                        clsRegistryUtil.SaveLogin(
                            txtUserName.Text.Trim(),
                            txtPassword.Text.Trim());
                    }
                    else
                    {
                        clsRegistryUtil.ClearLogin();
                    }

                    this.Hide();
                    frmMainForm frm = new frmMainForm(this);
                    frm.ShowDialog();
                    return;
                }
                else
                {
                    MessageBox.Show(
                        "Please contact admin, this user is not active",
                        "Inactive User",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    lblError.Text = "User is not active!";
                    return;
                }
            }
            else
            {
                txtPassword.Text = "";
                txtUserName.Text = "";

                MessageBox.Show(
                    "Username or Password is incorrect",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                lblError.Text = "Username / Password is wrong!";
            }
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            if (clsRegistryUtil.LoadLogin(ref _UserName, ref _Password))
            {
                txtUserName.Text = _UserName;
                txtPassword.Text = _Password;
                cbRememberMe.Checked = true;
            }
            else
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                cbRememberMe.Checked = false;
            }
        }
    }
}