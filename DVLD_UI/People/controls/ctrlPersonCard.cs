using DVLD_BusinessLogic;
using DVLD_UI.Properties;
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
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID;
        private clsPerson _Person;
        public clsPerson SelctedPerson
        {
            get { return _Person; }
        }
        public int PersonID
        {
            get { return _PersonID; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public void LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;
            _Person = clsPerson.Find(PersonID);
            if (_Person != null)
            {
                _FillPersonInfo();
            }
            else
            {
                MessageBox.Show("This Person is Not Exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void _FillPersonInfo()
        {
            lblFullName.Text = $"{_Person.FirstName} {_Person.LastName}";
            lblNationalNo.Text = _Person.NationalNo;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblGendor.Text = _Person.Gendor;
            lblPersonID.Text = _Person.ID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblGendor.Text = _Person.Gendor;

            if (_Person.ImagePath != null) 
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }
            else
            {
                if (_Person.Gendor == "Male") pbPersonImage.ImageLocation = Resources.office_man.ToString();
                else pbPersonImage.ImageLocation = Resources.woman.ToString();
            }
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmAddUpdatePerson(_PersonID);
           
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}
