using DVLD_BusinessLogic;
using DVLD_UI.People;
using DVLD_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.LocalDrivingApplications
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        private DataTable _dtApplications;
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void _RefreshAllApplications()
        {

            _dtApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();

            dgvAllLDLAs.DataSource = _dtApplications;
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshAllApplications();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateLocalDrivingLicenseAppliction();
            form.ShowDialog();
            _RefreshAllApplications();
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            //frmAddUpdateLocalDrivingLicenseAppliction form = new frmAddUpdateLocalDrivingLicenseAppliction((int)dgvAllLDLAs.CurrentRow.Cells[0].Value);
            //form.ShowDialog();
            //_RefreshAllApplications();
        }

        private void tsmDeleteApplication_Click(object sender, EventArgs e)
        {
            if (dgvAllLDLAs.CurrentRow == null)
                return;

            int id = (int)dgvAllLDLAs.CurrentRow.Cells[0].Value;

            try
            {
                clsLocalDrivingLicenseApplication.DeleteApplication(id);
                _RefreshAllApplications();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "You can't delete this Application because it is linked to other records.",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void tsmEditApplicaion_Click(object sender, EventArgs e)
        {
            if (dgvAllLDLAs.CurrentRow == null)
            {
                MessageBox.Show("Please select a Application first");
                return;
            }

            Form form = new frmAddUpdateLocalDrivingLicenseAppliction((int)dgvAllLDLAs.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshAllApplications();
        }
        private void tsmAddNewLDLA_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateLocalDrivingLicenseAppliction();
            form.ShowDialog();
            _RefreshAllApplications();
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSortBy.SelectedItem.ToString() == "Status")
            {
                txtFilter.Enabled = false;
                cbStatus.Enabled = true;
                return;
            }
            else
            {
                txtFilter.Enabled = true;
                cbStatus.Enabled = false;
                return;
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbSortBy.SelectedItem)
            {
                case "L.D.L.AppID":
                    FilterColumn = "L.D.L.AppID";
                    break;
                case "National No":
                    FilterColumn = "National No";
                    break;
                case "Full Name":
                    FilterColumn = "Full Name";
                    break;
                case "Status":
                    FilterColumn = "Status";
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
            else if (FilterColumn == "L.D.L.AppID" && !string.IsNullOrEmpty(txtFilter.Text))

            {
                if (!clsUtil.IsOnlyNumbers(txtFilter.Text))
                {
                    MessageBox.Show("Error", "Only numbers are allowed in Filtering By the ApplicationID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFilter.Focus();
                    txtFilter.Clear();
                }
                else _dtApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());

            }
            else if(FilterColumn == "Status")
            {
                _dtApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, cbStatus.SelectedItem.ToString().Trim());
            }
            else if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                _dtApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());
            }
        }

        
    }
}
