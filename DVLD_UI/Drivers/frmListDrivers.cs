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

namespace DVLD_UI.Drivers
{
    public partial class frmListDrivers : Form
    {
        private DataTable dtDrivers = clsDriver.GetAllDrivers();
        public frmListDrivers()
        {
            InitializeComponent();
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbSortBy.SelectedItem)
            {
                case "Driver ID":
                    FilterColumn = "Driver ID";
                    break;
                case "Person ID":
                    FilterColumn = "Person ID";
                    break;
                case "National No":
                    FilterColumn = "National No";
                    break;
                case "Name":
                    FilterColumn = "Person Name";
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
            else if ((FilterColumn == "Person ID" || FilterColumn == "Driver ID") && !string.IsNullOrEmpty(txtFilter.Text))

            {
                if (!clsUtil.IsOnlyNumbers(txtFilter.Text))
                {
                    MessageBox.Show("Error", "Only numbers are allowed in Filtering by ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFilter.Focus();
                    txtFilter.Clear();
                }
                else dtDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());

            }
            else if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                dtDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());
            }
        }
        private void dgvAllDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void _RefreshAllPeople()
        {
            dtDrivers = clsDriver.GetAllDrivers();
            dgvAllDrivers.DataSource = dtDrivers;
            dgvAllDrivers.Columns[0].Width = 100;
            dgvAllDrivers.Columns[1].Width = 200;
            dgvAllDrivers.Columns[2].Width = 150;
            dgvAllDrivers.Columns[3].Width = 200;
            dgvAllDrivers.Columns[4].Width = 150;
            dgvAllDrivers.Columns[5].Width = 70;
        }
        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshAllPeople();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvAllDrivers.CurrentRow == null)
            {
                MessageBox.Show("Please Select Row First","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                frmShowLicensesHistory frm = new frmShowLicensesHistory((int)dgvAllDrivers.CurrentRow?.Cells[1].Value);
                frm.ShowDialog();
            }
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllDrivers.CurrentRow == null)
            {
                MessageBox.Show("Please Select Row First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvAllDrivers.CurrentRow?.Cells[1].Value);
                frm.ShowDialog();
            }
        }
    }
}
