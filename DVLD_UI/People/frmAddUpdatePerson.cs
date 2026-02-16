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
    public partial class frmAddUpdatePerson : Form
    {
        clsPerson Person { get; set; }
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            lblMainTitle.Text = "Add New Person";
            ctrlAddUpdatePersonInfo1.CancelRequested += MyControl1_CancelRequested;
        }
        private void MyControl1_CancelRequested(object sender, EventArgs e)
        {
            this.Close();
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            Person = clsPerson.Find(PersonID);
            if (Person.ID == -1) {
            lblMainTitle.Text = "Add New Person";
            }
            else
            {
                lblMainTitle.Text = "Update Person Info";

            }
            ctrlAddUpdatePersonInfo1.CancelRequested += MyControl1_CancelRequested;
            this.Load += frmUpdatePersonInfo_Load;
        }

        private void frmUpdatePersonInfo_Load(object sender, EventArgs e)
        {
            // Set the person ID to the user control
            ctrlAddUpdatePersonInfo1.PersonID = Person.ID;
        }

       
    }
}
