using DVLD_BusinessLogic;
using DVLD_UI.People;
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
        private static DataTable _dtAllUsers;

        //only select the columns that you want to show in the grid

        private void _RefreshAllUsers()
        {
            dgvAllUsers.DataSource = _dtAllUsers;
        }
        public frmManageUsers()
        {
            InitializeComponent();
           
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

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbSortBy.SelectedItem)
            {
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "None":
                    FilterColumn = "None";
                    break;
                default:
                    FilterColumn = string.Empty;
                    break;
            }
            if (FilterColumn == "" || FilterColumn == "None")
            {
                MessageBox.Show("Please Select Filter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbSortBy.Focus();
            }
            else if (FilterColumn == "PersonID" && !string.IsNullOrEmpty(txtFilter.Text) || FilterColumn == "UserID" && !string.IsNullOrEmpty(txtFilter.Text))

            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());

            }
            else if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshAllUsers();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshAllUsers();
        }

        private void editUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a User first");
                return;
            }

            Form form = new frmAddUpdateUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshAllUsers();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a User first");
                return;
            }

            int id = (int)dgvAllUsers.CurrentRow.Cells[0].Value;

            try
            {
                clsUser.DeleteUser(id);
                _RefreshAllUsers();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "You can't delete this User because it is linked to other records.",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvAllUsers.DataSource = _dtAllUsers;
            cbSortBy.SelectedIndex = 0;


            dgvAllUsers.Columns[0].HeaderText = "UserID";
            dgvAllUsers.Columns[0].Width = 110;

            dgvAllUsers.Columns[1].HeaderText = "PersonID";
            dgvAllUsers.Columns[1].Width = 120;

            dgvAllUsers.Columns[3].HeaderText = "UserName";
            dgvAllUsers.Columns[3].Width = 120;

            dgvAllUsers.Columns[2].HeaderText = "FullName";
            dgvAllUsers.Columns[2].Width = 350;

            dgvAllUsers.Columns[4].HeaderText = "IsActive";
            dgvAllUsers.Columns[4].Width = 120;
        }
    }
}
