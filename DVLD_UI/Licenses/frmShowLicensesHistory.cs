using DVLD_BusinessLogic;
using DVLD_UI.Licenses.InterNationalLicense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses
{
    public partial class frmShowLicensesHistory : Form
    {
        private int _PersonID;
        public int PersonID { get { return _PersonID; } }
        public frmShowLicensesHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        private void _RefreshAllLicenses()
        {
            _RefreshInternationalLicenses();
            _RefreshLocalLicenses();
        }
        private void _RefreshLocalLicenses()
        {
            dgvLocalLicenses.DataSource = clsLicense.GetAllLicnesesForPersonID(PersonID);
            dgvLocalLicenses.Columns[0].Width = 150;
            dgvLocalLicenses.Columns[1].Width = 150;
            dgvLocalLicenses.Columns[2].Width = 250;
            dgvLocalLicenses.Columns[3].Width = 150;
            dgvLocalLicenses.Columns[4].Width = 150;
            dgvLocalLicenses.Columns[5].Width = 150;
        }
        private void _RefreshInternationalLicenses()
        {
            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetAllInternationalLicensesForPerson(PersonID);
            dgvInternationalLicenses.Columns[0].Width = 150;
            dgvInternationalLicenses.Columns[1].Width = 150;
            dgvInternationalLicenses.Columns[2].Width = 250;
            dgvInternationalLicenses.Columns[3].Width = 150;
            dgvInternationalLicenses.Columns[4].Width = 150;
            dgvInternationalLicenses.Columns[5].Width = 150;
        }
        private void frmShowLicensesHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInfo(PersonID);
            _RefreshAllLicenses();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAID = (int)dgvLocalLicenses.CurrentRow?.Cells[0].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LDLAID);
            frm.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int LDLAID = (int)dgvInternationalLicenses.CurrentRow?.Cells[1].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(LDLAID);
            frm.ShowDialog();
        }
    }
}
