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
    public partial class frmUpdatePersonInfo : Form
    {
       
        private int _PersonID;
        public frmUpdatePersonInfo(int PersonID)
        {
            InitializeComponent(); // Now without parameters
            _PersonID = PersonID;

            // Load the person data after the form is initialized
            this.Load += frmUpdatePersonInfo_Load;
        }

        private void frmUpdatePersonInfo_Load(object sender, EventArgs e)
        {
            // Set the person ID to the user control
            ctrlUpdatePersonInfo1._SetInformation(_PersonID);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
