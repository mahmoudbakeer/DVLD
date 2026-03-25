using DVLD_BusinessLogic;
using DVLD_UI.Licenses;
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

namespace DVLD_UI.Applications.LocalDrivingApplications.DetainLicense
{
    public partial class frmManageDetainedLicenses : Form
    {
        private DataTable _dtAllDetainedLicesnses = clsDetainedLicense.GetAllDetainedLicense();
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        private void _RefreshData()
        {
            _dtAllDetainedLicesnses = clsDetainedLicense.GetAllDetainedLicense();
            dgvAllDetainLicenses.DataSource = _dtAllDetainedLicesnses;
            dgvAllDetainLicenses.Columns[0].Width = 60;
            dgvAllDetainLicenses.Columns[1].Width = 60;
            dgvAllDetainLicenses.Columns[2].Width = 100;
            dgvAllDetainLicenses.Columns[3].Width = 100;
            dgvAllDetainLicenses.Columns[4].Width = 100;
            dgvAllDetainLicenses.Columns[5].Width = 70;
            dgvAllDetainLicenses.Columns[6].Width = 100;
            dgvAllDetainLicenses.Columns[7].Width = 250;
            dgvAllDetainLicenses.Columns[8].Width = 200;
        }
        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbSortBy.SelectedItem)
            {
                case "Detain ID":
                    FilterColumn = "D.ID";
                    break;
                case "License ID":
                    FilterColumn = "L.ID";
                    break;
                case "Full Name":
                    FilterColumn = "Full Name";
                    break;
                case "National No":
                    FilterColumn = "N.NO";
                    break;
                case "Release Application ID":
                    FilterColumn = "App.ID";
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
            if (string.IsNullOrEmpty(txtFilter.Text)) return;
            if (FilterColumn == "" || FilterColumn == "None")
            {
                MessageBox.Show("Please Select Filter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbSortBy.Focus();
            }
            else if(string.IsNullOrEmpty(txtFilter.Text)) return;
            else if ((FilterColumn == "D.ID" && !string.IsNullOrEmpty(txtFilter.Text)) || (FilterColumn == "D.ID" && !string.IsNullOrEmpty(txtFilter.Text) || (FilterColumn == "App.ID" && !string.IsNullOrEmpty(txtFilter.Text))))

            {
                if (!clsUtil.IsOnlyNumbers(txtFilter.Text))
                {
                    MessageBox.Show("Error", "Only numbers are allowed in Filtering By the ApplicationID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFilter.Focus();
                    txtFilter.Clear();
                }
                else _dtAllDetainedLicesnses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());

            }
            else if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                _dtAllDetainedLicesnses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());
            }
        }
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem == null)
                return;
            bool Released = cbStatus.SelectedItem.ToString() == "Released" ? true : false;
            _dtAllDetainedLicesnses.DefaultView.RowFilter =
                string.Format($"[Is Released] = '{Released}'", cbStatus.SelectedItem.ToString().Trim());
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshData();
            txtFilter.Clear();
            if (cbSortBy.SelectedItem.ToString() == "Status")
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshData();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllDetainLicenses.CurrentRow == null) return;
            else
            {
                frmShowPersonInfo frm = new frmShowPersonInfo(clsLicense.Find((int)dgvAllDetainLicenses.CurrentRow?.Cells[1].Value).LocalDrivingApplicationInfo.ApplicantPersonID);
                frm.ShowDialog();
            }

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllDetainLicenses.CurrentRow == null) return;
            else
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(clsLicense.Find((int)dgvAllDetainLicenses.CurrentRow?.Cells[1].Value).LicenseID);
                frm.ShowDialog();
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllDetainLicenses.CurrentRow == null) return;
            else
            {
                frmShowLicensesHistory frm = new frmShowLicensesHistory(clsLicense.Find((int)dgvAllDetainLicenses.CurrentRow?.Cells[1].Value).LocalDrivingApplicationInfo.ApplicantPersonID);
                frm.ShowDialog();
            }
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllDetainLicenses.CurrentRow == null) return;
            else if(!clsDetainedLicense.IsLicenseDetained((int)dgvAllDetainLicenses.CurrentRow?.Cells[1].Value))
            {
                MessageBox.Show("The Selected License Is not detained","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                frmReleaseLicense frmReleaseLicense = new frmReleaseLicense((int)dgvAllDetainLicenses.CurrentRow?.Cells[1].Value);
                frmReleaseLicense.ShowDialog();
                _RefreshData();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
            _RefreshData();
        }
    }
}
