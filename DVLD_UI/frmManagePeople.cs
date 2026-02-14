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
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }
        private void _RefreshAllPeople()
        {
            dgvAllPeople.DataSource = clsPerson.GetAllPeople();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshAllPeople();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Form form = new frmAddNewPerson();
            form.ShowDialog();
            _RefreshAllPeople();
        }
    }
}
