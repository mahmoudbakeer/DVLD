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

namespace DVLD_UI.Users.Controllers
{
    public partial class frmShowUserInfo : Form
    {
        private int _UserID;
        public int UserID
        {
            get {  return _UserID; }
        }
        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUser(UserID);
        }
    }
}
