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
    public partial class frmShowPersonInfo : Form
    {
        private int _PersonID;
        public frmShowPersonInfo()
        {
            InitializeComponent();
           
            this.Load += _LoadPersonInfo;
        }
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            this.Load += _LoadPersonInfo;
        }

        private void _LoadPersonInfo(object sender, EventArgs e) {
            ctrlPersonCard1.LoadPersonData(_PersonID);
        }
    }
}
