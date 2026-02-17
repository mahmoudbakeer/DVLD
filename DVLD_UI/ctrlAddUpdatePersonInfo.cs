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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UI
{
    public partial class ctrlAddUpdatePersonInfo : UserControl
    {
        clsPerson Person {  get; set; }
        private int _personID = -1;
        public int PersonID
        {
            get { return _personID; }
            set
            {
                _personID = value;
                LoadPerson();
            }
        }

        public ctrlAddUpdatePersonInfo()
        {
            InitializeComponent();
            _LoadAllCountries();

        }
        private void _SetPersonInfo()
        {
            txtFirstName.Text = Person.FirstName;
            txtSecondName.Text = Person.SecondName;
            txtThirdName.Text = Person.ThirdName;
            txtLastName.Text = Person.LastName;
            txtEmail.Text = Person.Email;
            txtAddress.Text = Person.Address;
            txtPhone.Text = Person.Phone;
            txtNationalNo.Text = Person.NationalNo;
            dtpDateOfBirth.Value = Person.DateOfBirth;
            cbCountries.SelectedItem = clsCountry.Find(Person.NationalityCountryID).CountryName;
            if(Person.Gendor == "Male") rbMale.Checked = true;
            else rbFemale.Checked = true;
            if (Person.ImagePath == "")
            {
                _LoadPictureByGendor();
            }
            else
            {
                pbProfilePicture.ImageLocation = (Person.ImagePath);
                btnRemovePicture.Enabled = true;
            }
        }
        private void ClearValues()
        {
            txtFirstName.Clear();
            txtSecondName.Clear();
            txtThirdName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cbCountries.SelectedItem = "Syria";
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);
            rbMale.Checked = true;
            _LoadPictureByGendor();
        }
        private void _LoadPictureByGendor()
        {
            btnRemovePicture.Enabled = false;
            if (rbFemale.Checked)
            {

                pbProfilePicture.Image = Resources.woman;
            }
            else
            {
                pbProfilePicture.Image = Resources.office_man;
            }
        }
        private void _LoadAllCountries()
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow row in dt.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }

        }
        private void LoadPerson()
        {
            if (clsPerson.isPersonExist(_personID))
            {
                Person = clsPerson.Find(_personID);
                _SetPersonInfo();
            }
            else
            {
                Person = new clsPerson();
                ClearValues();
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Person.ImagePath != "" )
                {
                    clsUtil.DeleteFile(Person.ImagePath);
                    Person.ImagePath = "";
                }
                Person.ImagePath = clsUtil.CopyWithGuidName(openFileDialog1.FileName, "D:\\Pictures"); ;
                pbProfilePicture.ImageLocation = Person.ImagePath;
                btnRemovePicture.Enabled=true;
            }
        }

        private void btnRemovePicture_Click(object sender, EventArgs e)
        {
            if (Person.ImagePath != "" && clsUtil.DeleteFile(Person.ImagePath))
            {
                Person.ImagePath = "";
                pbProfilePicture.ImageLocation = null;
                btnRemovePicture.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed", "Can't Delete the Image");
            }
        }
        private void _ValidateTextBox(TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                epValidation.SetError(txt, "Cannot Be Empty");
            }
            else
            {
                epValidation.SetError(txt, "");
            }

        }
        private bool _ValidateInputs()
        {
            bool isValid = true;
            epValidation.Clear();

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                epValidation.SetError(txtFirstName, "Required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtSecondName.Text))
            {
                epValidation.SetError(txtSecondName, "Required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                epValidation.SetError(txtLastName, "Required");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                epValidation.SetError(txtPhone, "Required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtThirdName.Text))
            {
                epValidation.SetError(txtThirdName, "Required");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text) )
            {
                epValidation.SetError(txtEmail, "Required");
                isValid = false;
            }
            if (!clsUtil.IsValidEmail(txtEmail.Text))
            {
                epValidation.SetError(txtEmail, "Email Address should be valid");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                epValidation.SetError(txtAddress, "Required");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                epValidation.SetError(txtNationalNo, "Required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(cbCountries.Text))
            {
                epValidation.SetError(cbCountries, "Select country");
                isValid = false;
            }

            if (dtpDateOfBirth.Value > DateTime.Now)
            {
                epValidation.SetError(dtpDateOfBirth, "Invalid date");
                isValid = false;
            }
            ValidatenationalNo();
            return isValid;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_ValidateInputs())
            {
                return;
            }
            
            else
            {
                _FillPersonFromUI();
                if (Person.Save())
                {
                    if (MessageBox.Show("Successed!", "Informations Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
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
                epValidation.SetError(txtNationalNo, "Required");
                return;
            }

            bool exists = clsPerson.isPersonExist(newNo);

            // if adding new person OR editing but number changed
            if (exists && (Person == null || Person.NationalNo != newNo))
            {
                epValidation.SetError(txtNationalNo, "National Number already exists");
                return;
            }

            epValidation.SetError(txtNationalNo, "");
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

        public event EventHandler CancelRequested;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (Person == null) return;

            if (Person.ImagePath == "")
                _LoadPictureByGendor();
            Person.Gendor = (rbFemale.Checked) ? "Female" : "Male";

        }
        private void _FillPersonFromUI()
        {
            Person.FirstName = txtFirstName.Text.Trim();
            Person.SecondName = txtSecondName.Text.Trim();
            Person.ThirdName = txtThirdName.Text.Trim();
            Person.LastName = txtLastName.Text.Trim();
            Person.Email = txtEmail.Text.Trim();
            Person.Address = txtAddress.Text.Trim();
            Person.Phone = txtPhone.Text.Trim();
            Person.NationalNo = txtNationalNo.Text.Trim();
            Person.DateOfBirth = dtpDateOfBirth.Value;
            Person.NationalityCountryID = clsCountry.Find(cbCountries.Text).ID;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (Person == null) return;
            if (Person.ImagePath == "")
                _LoadPictureByGendor();
            Person.Gendor = (rbFemale.Checked) ? "Female" : "Male";
        }
    }
}
