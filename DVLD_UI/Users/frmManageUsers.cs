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

namespace DVLD_UI.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }
        
        private void _RefreshAllUsers()
        {
            DataTable dataTable = clsUser.GetAllUsers();
            dgvUsers.DataSource = dataTable;
            return;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshAllUsers();
        }

        //private void btnAddNewUser_Click(object sender, EventArgs e)
        //{
        //    Form form = new frmAddUpdateUser();
        //    form.ShowDialog();
        //    _RefreshAllUsers();
        //}

        //private void tsmShowDetails_Click(object sender, EventArgs e)
        //{
        //    Form form = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
        //    form.ShowDialog();
        //    _RefreshAllUsers();
        //}

        //private void tsmDeletePerson_Click(object sender, EventArgs e)
        //{
        //    if (dgvUsers.CurrentRow == null)
        //        return;

        //    int id = (int)dgvUsers.CurrentRow.Cells[0].Value;

        //    try
        //    {
        //        clsUser.DeleteUser(id);
        //        _RefreshAllUsers();
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(
        //            "You can't delete this person because it is linked to other records.",
        //            "Delete Failed",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //    }
        //}


        //private void tsmEditPerson_Click(object sender, EventArgs e)
        //{
        //    Form form = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
        //    form.ShowDialog();
        //    _RefreshAllUsers();
        //}

        //private void tsmAddNewPerson_Click(object sender, EventArgs e)
        //{
        //    Form form = new frmAddUpdateUser();
        //    form.ShowDialog();
        //    _RefreshAllUsers();
        //}

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
