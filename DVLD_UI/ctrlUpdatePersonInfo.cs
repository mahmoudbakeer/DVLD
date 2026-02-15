using DVLD_BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class ctrlUpdatePersonInfo : UserControl
    {
        clsPerson _Person;
        string _SelectedImagePath;
     
        public ctrlUpdatePersonInfo()
        {
            InitializeColors();
            SetInitialButtonColors();
            InitializeComponent();
            
            
        }

        private void _LoadInfo()
        {
            _FillCountriesInComoboBox();
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtEmail.Text = _Person.Email;
            txtNationalNo.Text = _Person.NationalNo;
            txtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            txtPhone.Text = _Person.Phone;

            // Select the correct country in combobox
            string countryName = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            cbCountries.SelectedItem = countryName;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                ProfilePicture.Load(_Person.ImagePath);
                _SelectedImagePath = _Person.ImagePath;
                btnDeletePicture.Visible = true;
            }
            else
            {
                btnDeletePicture.Visible = false;
            }

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
            if (_Person.Save())
                MessageBox.Show("Saved successfully.");
            else
                MessageBox.Show("Save failed.");
        }

        private void InitializeColors()
        {
            // Initialize all color fields
            this.primaryColor = Color.FromArgb(99, 102, 241);     // Purple/blue
            this.primaryLight = Color.FromArgb(129, 140, 248);    // Lighter purple
            this.accentGreen = Color.FromArgb(16, 185, 129);      // Green
            this.accentOrange = Color.FromArgb(251, 146, 60);     // Orange
            this.accentRed = Color.FromArgb(239, 68, 68);         // Red
            this.darkText = Color.FromArgb(30, 41, 59);           // Dark text
            this.mediumText = Color.FromArgb(71, 85, 105);        // Medium text
            this.lightText = Color.FromArgb(148, 163, 184);       // Light text
            this.cardBackground = Color.White;                     // White
            this.sectionBackground = Color.FromArgb(248, 250, 252); // Light gray
            this.borderColor = Color.FromArgb(226, 232, 240);      // Light border
            this.inputBackground = Color.FromArgb(249, 250, 251);  // Input background
        }

        private void SetInitialButtonColors()
        {
            // Ensure buttons have their initial colors
            if (btnSave != null)
                btnSave.BackColor = this.primaryColor;

            if (btnAddPicture != null)
                btnAddPicture.BackColor = this.accentGreen;

            if (btnDeletePicture != null)
                btnDeletePicture.BackColor = this.accentRed;
        }

        public void _SetInformation(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person != null)
            {
                _LoadInfo();
            }
            else
            {
                _Person = new clsPerson();
            }
        }
    }
}
