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

namespace DVLD_UI.Licenses.InterNationalLicense
{
    public partial class frmListInternationalLicenses : Form
    {
        private DataTable _dtApplications = clsInternationalLicense.GetAllInternatioanLicenses();
        public frmListInternationalLicenses()
        {
            InitializeComponent();
        }
        private void _RefreshAllInternationalLicenses()
        {
            _dtApplications = clsInternationalLicense.GetAllInternatioanLicenses();
            dgvAllInternatioanlLicense.DataSource = _dtApplications;
            dgvAllInternatioanlLicense.Columns[0].Width = 150;
            dgvAllInternatioanlLicense.Columns[1].Width = 150;
            dgvAllInternatioanlLicense.Columns[2].Width = 150;
            dgvAllInternatioanlLicense.Columns[4].Width = 150;
            dgvAllInternatioanlLicense.Columns[3].Width = 150;
            dgvAllInternatioanlLicense.Columns[5].Width = 150;
            dgvAllInternatioanlLicense.Columns[6].Width = 200;
        }
        private void dgvAllInternatioanlLicense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbSortBy.SelectedItem)
            {
                case "Int.License ID":
                    FilterColumn = "Int.License ID";
                    break;
                case "License ID":
                    FilterColumn = "License ID";
                    break;
                case "Application ID":
                    FilterColumn = "App.ID";
                    break;
                case "Driver ID":
                    FilterColumn = "Driver ID";
                    break;
                case "Status":
                    FilterColumn = "Is Active";
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
            else if (FilterColumn != "Status")
            {
                if (!clsUtil.IsOnlyNumbers(txtFilter.Text))
                {
                    MessageBox.Show("Error", "Only numbers are allowed in Filtering By ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFilter.Focus();
                    txtFilter.Clear();
                }
                else _dtApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
              
            }
            //else if(FilterColumn == "Status")
            //{
            //    bool Active = (cbStatus.SelectedItem?.ToString() == "IsActive") ? true : false;
            //    _dtApplications.DefaultView.RowFilter = $"[{FilterColumn}] = {Active}";

            //}
        }
        private void frmListInternationalLicenses_Load(object sender, EventArgs e)
        {
            _RefreshAllInternationalLicenses();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frmShowPersonInfo = new frmShowPersonInfo(clsInternationalLicense.Find((int)dgvAllInternatioanlLicense.CurrentRow?.Cells[0].Value).ApplicationInfo.ApplicantPersonID);
            frmShowPersonInfo.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frmShowPersonInfo = new frmShowInternationalLicenseInfo((int)dgvAllInternatioanlLicense.CurrentRow?.Cells[1].Value);
            frmShowPersonInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicensesHistory frmShowPersonInfo = new frmShowLicensesHistory(clsInternationalLicense.Find((int)dgvAllInternatioanlLicense.CurrentRow?.Cells[0].Value).ApplicationInfo.ApplicantPersonID);
            frmShowPersonInfo.ShowDialog();
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshAllInternationalLicenses();
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplication frm = new frmInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool Active = cbStatus.SelectedItem?.ToString() == "Active";
            _dtApplications.DefaultView.RowFilter = $"[Is Active] = {Active}";
        }
    }
}
