using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.People
{
    public partial class frmShowPersonInfo : Form
    {
        private int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }
            set {
                ctrlPersonCard1.LoadPersonInfo(value);
                _PersonID = value; }
        }
        public frmShowPersonInfo(int PersonID)
        {
            
            InitializeComponent();
            this.PersonID = PersonID;
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }
    }
}
