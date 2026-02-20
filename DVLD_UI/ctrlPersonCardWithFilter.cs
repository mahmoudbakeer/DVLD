using DVLD_BusinessLogic;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UI
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public int PersonID;
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            

        }
        
        public void LoadPersonInfo(int PersonID)

        {
            this.PersonID = PersonID;
            txtFilter.Text = PersonID.ToString().Trim();
            FindNow();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem == null)
            {
                cbFilter.Focus();
                errorProvider1.SetError(cbFilter, "Please Choose a Filter Item.");
                return;
            }

            string filter = cbFilter.SelectedItem.ToString();

            switch (filter)
            {
                case "Person ID":
                    if (!clsUtil.IsOnlyNumbers(txtFilter.Text))
                        errorProvider1.SetError(txtFilter, "Only Numbers Are Allowed");
                         txtFilter.Clear();
                         txtFilter.Focus();
                    break;
                default:
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            FindNow();  
        }
        public void FindNow()
        {
            if (cbFilter.SelectedItem == null)
            {
                cbFilter.Focus();
                errorProvider1.SetError(cbFilter, "Please Choose a Filter Item.");
                return;
            }

            string filter = cbFilter.SelectedItem.ToString();
            string value = txtFilter.Text.Trim();

            if (string.IsNullOrWhiteSpace(value))
            {
                txtFilter.Focus();
                errorProvider1.SetError(txtFilter, "ENter value To Search");
                return;
            }
            switch (filter)
            {
                case "National NO":
                    ctrlPersonCard1.LoadPersonData(value);
                    break;

                case "Person ID":
                    if (int.TryParse(value, out int id))
                        ctrlPersonCard1.LoadPersonData(id);
                    else
                        errorProvider1.SetError(txtFilter, "Only Numbers Are Allowed");
                    break;

                default:
                    cbFilter.Focus();
                    errorProvider1.SetError(cbFilter, "Please Choose a Filter Item.");
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();

        }
        public void FilterFocus()
        {
            txtFilter.Focus();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
