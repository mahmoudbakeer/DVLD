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

namespace DVLD_UI.People.controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        private clsPerson _Person;
        public clsPerson Person
        {
            get { return _Person; }
            set
            {
                _Person = value;
                if (_Person != null)
                    ctrlPersonCard1.LoadPersonInfo(_Person.ID);
            }
        }
        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = value;
            }
        }
        private int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }
            set {
                _PersonID = value;
            }
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        private bool Validate()
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtSearchValue.Text))
            {
                errorProvider1.SetError(txtSearchValue, "Cannot be Blank!");
                txtSearchValue.Focus();
                return false;
            }
            if(cbSearchBy.SelectedItem.ToString() == "Person ID" && !clsUtil.IsOnlyNumbers(txtSearchValue.Text))
            {
                errorProvider1.SetError(txtSearchValue, "Cannot Have a character , Only Numbers are allowed!");
                txtSearchValue.Clear();
                txtSearchValue.Focus();
                return false;
            }
            return true;
            
        }
        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            if (!Validate()) return;
          
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbSearchBy.SelectedIndex = 0;
        }
        private void FindNow()
        {
            if (!Validate())
                return;

            if (cbSearchBy.Text == "Person ID")
                LoadPerson(int.Parse(txtSearchValue.Text));
            else
                LoadPerson(clsPerson.Find(txtSearchValue.Text.ToString())?.ID ?? -1);
        }
        public void LoadPersonInfo(int PersonID)
        {
            txtSearchValue.Text = PersonID.ToString();
            cbSearchBy.SelectedIndex = 0;
            FindNow();
        }
        private void LoadPerson(int id)
        {
            _PersonID = id;
            _Person = clsPerson.Find(id);
            ctrlPersonCard1.LoadPersonInfo(id);

            
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindNow();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += frm_DataBack;
            frm.ShowDialog();

        }
        private void frm_DataBack(object sender,int PersonID)
        {
            LoadPerson(PersonID);
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
