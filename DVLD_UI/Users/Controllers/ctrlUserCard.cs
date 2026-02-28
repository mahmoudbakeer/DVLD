using DVLD_BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Users.Controllers
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;
        public clsUser User
            { get { return _User; } }
        private int _UserID;
        public int UserID
        {
            get {
                return _UserID;
            }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        private void _SetInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(User.PersonID);
            lblIsActive.Text = User.IsActive ? "YES": "NO";
            lblUserID.Text = User.ID.ToString();
            lblUserName.Text = User.UserName.ToString();

        }

        public void LoadUser(int UserID)
        {
            _User = clsUser.Find(UserID);
            if (_User == null) return;
            else
            {
                _UserID = UserID;
                _SetInfo();
                return;
            }
        }
    }
}
