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

namespace DVLD_UI
{
    public partial class frmManagePeople : Form
    {
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();

        //only select the columns that you want to show in the grid
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                         "FirstName", "SecondName", "ThirdName", "LastName",
                                                         "Gendor", "DateOfBirth", 
                                                         "Phone", "Email");

        private void _RefreshAllPeople()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gendor", "DateOfBirth", 
                                                       "Phone", "Email");
            dgvAllPeople.DataSource = _dtPeople;
        }
        public frmManagePeople()
        {
            InitializeComponent();
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
            frmShowPersonInfo form = new frmShowPersonInfo((int)dgvAllPeople.CurrentRow.Cells[0].Value);
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
            if (dgvAllPeople.CurrentRow == null)
            {
                MessageBox.Show("Please select a person first");
                return;
            }

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

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbSortBy.SelectedItem)
            {
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "None":
                    FilterColumn = "None";
                    break;
                default:
                    FilterColumn = string.Empty;
                    break;
            }
            if(FilterColumn == "" || FilterColumn == "None")
            {
                MessageBox.Show("Please Select Filter","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                cbSortBy.Focus();
            }
            else if(FilterColumn == "PersonID" && !string.IsNullOrEmpty(txtFilter.Text))

            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());

            }
            else if(!string.IsNullOrEmpty(txtFilter.Text))
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());
            }
        }

        
    }
}
