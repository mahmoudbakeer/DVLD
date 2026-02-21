using DVLD_BusinessLogic;
using DVLD_UI.Properties;
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

namespace DVLD_UI.People
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        private int _PersonID;
        clsPerson _Person;
        enum eMode  {AddNew=1,Update=2};
        eMode _Mode;
        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = eMode.AddNew;
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
            _Mode = eMode.Update;

        }

        private void _SetPersonInfo()
        {
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            cbCountry.SelectedItem = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            if (_Person.Gendor == "Male") rbMale.Checked = true;
            else rbFemale.Checked = true;
            if (_Person.ImagePath == "")
            {
                _LoadPictureByGendor();
            }
            else
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
                llRemoveImage.Enabled = true;
            }
        }
        private void btnRemovePicture_Click(object sender, EventArgs e)
        {
            if (_Person.ImagePath != "" && clsUtil.DeleteFile(_Person.ImagePath))
            {
                _Person.ImagePath = "";
                pbPersonImage.ImageLocation = null;
                llRemoveImage.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed", "Can't Delete the Image");
            }
        }
        private void ClearValues()
        {
            _LoadAllCountries();
            if (_Mode == eMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }
            txtFirstName.Clear();
            txtSecondName.Clear();
            txtThirdName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cbCountry.SelectedItem = "Syria";
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);
            rbMale.Checked = true;
            _LoadPictureByGendor();
        }
        private void _LoadPictureByGendor()
        {
            llRemoveImage.Enabled = false;
            if (rbFemale.Checked)
            {

                pbPersonImage.Image = Resources.woman;
            }
            else
            {
                pbPersonImage.Image = Resources.office_man;
            }
        }
        private void _LoadAllCountries()
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }

        }
        private void LoadPerson()
        {
            if (clsPerson.isPersonExist(PersonID))
            {
                _Person = clsPerson.Find(PersonID);
                _SetPersonInfo();
            }
            else
            { 
                _Person = new clsPerson();
                ClearValues();
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (_Person.ImagePath != "")
                {
                    clsUtil.DeleteFile(_Person.ImagePath);
                    _Person.ImagePath = "";
                }
                _Person.ImagePath = clsUtil.CopyWithGuidName(openFileDialog1.FileName, "D:\\Pictures"); ;
                pbPersonImage.ImageLocation = _Person.ImagePath;
                llRemoveImage.Enabled = true;
            }
        }

        
        private void _ValidateTextBox(TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                errorProvider1.SetError(txt, "Cannot Be Empty");
            }
            else
            {
                errorProvider1.SetError(txt, "");
            }

        }
        private bool _ValidateInputs()
        {
            bool isValid = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "Required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtSecondName.Text))
            {
                errorProvider1.SetError(txtSecondName, "Required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "Required");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtThirdName.Text))
            {
                errorProvider1.SetError(txtThirdName, "Required");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Required");
                isValid = false;
            }
            if (!clsUtil.IsValidEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email Address should be valid");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "Required");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "Required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(cbCountry.Text))
            {
                errorProvider1.SetError(cbCountry, "Select country");
                isValid = false;
            }

            if (dtpDateOfBirth.Value > DateTime.Now)
            {
                errorProvider1.SetError(dtpDateOfBirth, "Invalid date");
                isValid = false;
            }
            ValidatenationalNo();
            return isValid;
        }
        

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            _ValidateTextBox((TextBox)sender);
        }

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {
            _ValidateTextBox((TextBox)sender);

        }

        private void txtThirdName_TextChanged(object sender, EventArgs e)
        {
            _ValidateTextBox((TextBox)sender);

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            _ValidateTextBox((TextBox)sender);
        }

        private void txtNationalNo_TextChanged(object sender, EventArgs e)
        {
            ValidatenationalNo();
        }

        private void ValidatenationalNo()
        {
            string newNo = txtNationalNo.Text.Trim();

            if (string.IsNullOrWhiteSpace(newNo))
            {
                errorProvider1.SetError(txtNationalNo, "Required");
                return;
            }

            bool exists = clsPerson.isPersonExist(newNo);

            // if adding new person OR editing but number changed
            if (exists && (_Person == null || _Person.NationalNo != newNo))
            {
                errorProvider1.SetError(txtNationalNo, "National Number already exists");
                return;
            }

            errorProvider1.SetError(txtNationalNo, "");
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

            _ValidateTextBox((TextBox)sender);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            _ValidateTextBox((TextBox)sender);
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            _ValidateTextBox((TextBox)sender);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (_Person == null) return;

            if (_Person.ImagePath == "")
                _LoadPictureByGendor();
            _Person.Gendor = (rbFemale.Checked) ? "Female" : "Male";

        }
        private void _FillPersonFromUI()
        {
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (_Person == null) return;
            if (_Person.ImagePath == "")
                _LoadPictureByGendor();
            _Person.Gendor = (rbFemale.Checked) ? "Female" : "Male";
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            ClearValues();
            if(_Mode == eMode.Update) LoadPerson();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateInputs())
            {
                return;
            }
            else
            {
                _FillPersonFromUI();
                if (_Person.Save())
                {
                    if (MessageBox.Show("Successed!", "Informations Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        DataBack?.Invoke(this,_Person.ID);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Failed!", "Failed To Add/Update Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return;
        }

        
    }
}
    
