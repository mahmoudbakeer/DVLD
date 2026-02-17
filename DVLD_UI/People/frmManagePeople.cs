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
            Form form = new frmAddUpdatePerson();
            form.ShowDialog();
            _RefreshAllPeople();
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            Form form = new frmShowPersonInfo((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshAllPeople();
        }

        private void tsmDeletePerson_Click(object sender, EventArgs e)
        {
            if (dgvAllPeople.CurrentRow == null)
                return;

            int id = (int)dgvAllPeople.CurrentRow.Cells[0].Value;

            try
            {
                clsPerson.DeletePerson(id);
                _RefreshAllPeople();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "You can't delete this person because it is linked to other records.",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void tsmEditPerson_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdatePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshAllPeople();
        }

        private void tsmAddNewPerson_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdatePerson();
            form.ShowDialog();
            _RefreshAllPeople();
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string val = cbSortBy.SelectedItem.ToString();
            //switch (val)
            //{
            //    case "FirstName":
            //        dgvAllPeople.DataSource = clsPerson.GetAllPeople().DefaultView.RowFilter = "FirstName";
            //        break;
            //}
        }
    }
}
