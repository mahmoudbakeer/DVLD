using DVLD_BusinessLogic;
using DVLD_UI.People;
using DVLD_UI.Tests.TestAppointments;
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
        private DataTable _dtApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void _RefreshAllApplications()
        {

            _dtApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();

            dgvAllLDLAs.DataSource = _dtApplications;
            dgvAllLDLAs.Columns[0].Width = 100;
            dgvAllLDLAs.Columns[1].Width = 200;
            dgvAllLDLAs.Columns[2].Width = 150;
            dgvAllLDLAs.Columns[3].Width = 250;
            dgvAllLDLAs.Columns[4].Width = 200;
            dgvAllLDLAs.Columns[5].Width = 70;
            dgvAllLDLAs.Columns[6].Width = 150;
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
            frmShowLocalDrivingLicenseApplicationDetails form = new frmShowLocalDrivingLicenseApplicationDetails((int)dgvAllLDLAs.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshAllApplications();
        }

        private void tsmDeleteApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Applicarion ?", "Attention!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvAllLDLAs.CurrentRow == null)
                    return;

                int id = (int)dgvAllLDLAs.CurrentRow.Cells[0].Value;

                try
                {
                    clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication(id);
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
            _RefreshAllApplications();
            txtFilter.Clear();
            if(cbSortBy.SelectedItem.ToString() == "Status")
            {
                txtFilter.Enabled = false;
                txtFilter.Visible = false;
                cbStatus.Enabled = true;
                cbStatus.Visible = true;

                return;
            }
            else
            {
                txtFilter.Visible = true;
                txtFilter.Enabled = true;
                cbStatus.Enabled = false;
                cbStatus.Visible = false;
                return;
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbSortBy.SelectedItem)
            {
                case "L.D.L.AppID":
                    FilterColumn = "L.D.LAppID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
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
            else if (FilterColumn == "L.D.LAppID" && !string.IsNullOrEmpty(txtFilter.Text))

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

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem == null)
                return;

            _dtApplications.DefaultView.RowFilter =
                string.Format("[Status] LIKE '{0}%'", cbStatus.SelectedItem.ToString().Trim());
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel this Applicarion ?", "Attention!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvAllLDLAs.CurrentRow == null)
                    return;

                int id = (int)dgvAllLDLAs.CurrentRow.Cells[0].Value;
                try
                {
                    clsLocalDrivingLicenseApplication.UpdateStatus(id, (int)clsApplication.eApplicationStatus.Cancelled);
                    _RefreshAllApplications();
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "You can't Cancel this Application .",
                        "Cancelation Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int LDLAID = (int)dgvAllLDLAs.CurrentRow?.Cells[0].Value;
            clsLocalDrivingLicenseApplication LDLA = clsLocalDrivingLicenseApplication.Find(LDLAID);
            bool PassVisionTest = LDLA.DoestPersonPassTheTest((int)clsTestType.enTestType.Vision);
            bool PassWrittenTest = LDLA.DoestPersonPassTheTest((int)clsTestType.enTestType.Written);
            bool PassStreetTest = LDLA.DoestPersonPassTheTest((int)clsTestType.enTestType.Written);
            bool HaveLicense = LDLA.DoestPersonHaveActiveLicense();
            if(dgvAllLDLAs.CurrentRow?.Cells[6].Value.ToString() == "Cancelled")
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirsrtTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
                return;
            }
            if(PassVisionTest && PassWrittenTest && PassStreetTest)
            {
                scheduleTestToolStripMenuItem.Enabled = false;
            }
            if(!PassVisionTest)
            {
                visionTestToolStripMenuItem.Enabled = true;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
            }
            else if(PassVisionTest && !PassWrittenTest)
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = true;
                streetTestToolStripMenuItem.Enabled = false;
            }
            else if(PassVisionTest && PassWrittenTest && !PassStreetTest)
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = true;
            }
            if (HaveLicense)
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirsrtTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = true;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
            }
            else
            {
                issueDrivingLicenseFirsrtTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frm = new frmManageTestAppointments((int)dgvAllLDLAs.CurrentRow?.Cells[0].Value, clsTestType.enTestType.Vision);
            frm.ShowDialog();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frm = new frmManageTestAppointments((int)dgvAllLDLAs.CurrentRow?.Cells[0].Value, clsTestType.enTestType.Written);
            frm.ShowDialog();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frm = new frmManageTestAppointments((int)dgvAllLDLAs.CurrentRow?.Cells[0].Value, clsTestType.enTestType.Street);
            frm.ShowDialog();
        }
    }
}
