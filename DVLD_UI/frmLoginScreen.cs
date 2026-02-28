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

namespace DVLD_UI
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((clsGlobalUser.gUser = clsUser.GetUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim())) != null)
            {
                if(clsGlobalUser.gUser.IsActive)
                {

                }
            }
        }
    }
}
