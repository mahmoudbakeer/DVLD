using DVLD_BusinessLogic;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class ctrlAddNewPerson : UserControl
    {
        clsPerson _Person;
        string _SelectedImagePath = "";

        public ctrlAddNewPerson()
        {
            InitializeComponent();

            // Allow only past dates for birth
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-120);

            _Person = new clsPerson();

            _FillCountriesInComoboBox();
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            cbCountries.Items.Clear();

            foreach (DataRow row in dtCountries.Rows)
                cbCountries.Items.Add(row["CountryName"].ToString());
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _SelectedImagePath = openFileDialog1.FileName;
                ProfilePicture.Load(_SelectedImagePath);
                btnDeletePicture.Visible = true;
            }
        }

        private void btnDeletePicture_Click(object sender, EventArgs e)
        {
            ProfilePicture.ImageLocation = null;
            _SelectedImagePath = "";
            btnDeletePicture.Visible = false;
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
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                epValidation.SetError(txtEmail, "Required");
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
            else if (clsPerson.isPersonExist(txtNationalNo.Text))
            {
                epValidation.SetError(txtNationalNo, "Already exists");
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

            return isValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateInputs())
                return;

            var country = clsCountry.Find(cbCountries.Text);

            if (country == null)
            {
                MessageBox.Show("Invalid country.");
                return;
            }

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.NationalityCountryID = country.ID;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.ImagePath = _SelectedImagePath;
            MessageBox.Show(txtEmail.Text);
            if (_Person.Save())
                MessageBox.Show("Saved successfully.");
            else
                MessageBox.Show("Save failed.");
        }
    }
}
