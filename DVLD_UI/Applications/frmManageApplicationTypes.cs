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

namespace DVLD_UI.Applications
{
    public partial class frmManageApplicationTypes : Form
    {
        private DataTable _dt;
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _RefreshAllData()
        {
            _dt = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _dt;
            dgvApplicationTypes.Columns[0].Width = 150;
            dgvApplicationTypes.Columns[1].Width = 350;
            dgvApplicationTypes.Columns[2].Width = 350;
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshAllData();
        }

        private void editApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
