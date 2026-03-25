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

namespace DVLD_UI.Tests
{
    public partial class frmTestTypeManagment : Form
    {
        DataTable _dtTestTypes;
        public frmTestTypeManagment()
        {
            InitializeComponent();
        }
        void _RefreshAllTestTypes()
        {
            _dtTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = _dtTestTypes;
            dgvTestTypes.Columns[0].Width = 150;
            dgvTestTypes.Columns[1].Width = 250;
            dgvTestTypes.Columns[2].Width = 350;
            dgvTestTypes.Columns[3].Width = 200;

        }
        private void frmTestManagment_Load(object sender, EventArgs e)
        {
            _RefreshAllTestTypes();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshAllTestTypes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
