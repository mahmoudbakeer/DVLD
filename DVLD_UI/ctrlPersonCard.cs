using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DVLD_BusinessLogic;

namespace DVLD_UI
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;

        // Colors
        private Color primaryColor = Color.FromArgb(99, 102, 241);
        private Color primaryLight = Color.FromArgb(129, 140, 248);
        private Color secondaryColor = Color.FromArgb(16, 185, 129);
        private Color borderColor = Color.FromArgb(226, 232, 240);

        public ctrlPersonCard()
        {
            InitializeComponent();
            this.Load += ctrlPersonCard_Load;
            SetupControlEvents();
        }

       

        private void SetupControlEvents()
        {
            // Panel paint events for custom drawing
            this.pnlMain.Paint += PnlMain_Paint;
            this.pnlPhoto.Paint += PnlPhoto_Paint;
            this.pnlPhotoFrame.Paint += PnlPhotoFrame_Paint;
            this.pnlContactInfo.Paint += PnlContactInfo_Paint;
            this.pnlFooter.Paint += PnlFooter_Paint;
            this.pnlStatusIndicator.Paint += PnlStatusIndicator_Paint;
        }

        private void ApplyCustomStyles()
        {
            // Apply gradient to header
            this.pnlHeader.Paint += (s, e) =>
            {
                Rectangle rect = new Rectangle(0, 0, this.pnlHeader.Width, this.pnlHeader.Height);
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect, primaryColor, primaryLight, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(borderColor, 1))
            {
                Rectangle rect = new Rectangle(0, 0, this.pnlMain.Width - 1, this.pnlMain.Height - 1);
                g.DrawRectangle(pen, rect);
            }
        }

        private void PnlPhoto_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.pnlPhoto.Width - 1, this.pnlPhoto.Height - 1);

            using (Pen pen = new Pen(borderColor, 2))
            {
                g.DrawRectangle(pen, rect);
            }
        }

        private void PnlPhotoFrame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(2, 2, this.pnlPhotoFrame.Width - 5, this.pnlPhotoFrame.Height - 5);
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, primaryColor, Color.FromArgb(236, 72, 153), LinearGradientMode.ForwardDiagonal))
            {
                using (Pen pen = new Pen(brush, 3))
                {
                    g.DrawEllipse(pen, rect);
                }
            }
        }

        private void PnlContactInfo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.pnlContactInfo.Width - 1, this.pnlContactInfo.Height - 1);
            using (Pen pen = new Pen(borderColor, 1))
            {
                g.DrawRectangle(pen, rect);
            }
        }

        private void PnlFooter_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(borderColor, 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, this.pnlFooter.Width, 0);
            }
        }

        private void PnlStatusIndicator_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillEllipse(new SolidBrush(secondaryColor), 0, 0, 10, 10);
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
            ApplyCustomStyles();
            MakePictureCircular();
        }

        private void MakePictureCircular()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pbSelfiPicture.Width, pbSelfiPicture.Height);
            pbSelfiPicture.Region = new Region(path);
        }


        // Public method to load person data
        public void LoadPersonData(int personID)
        {
            _Person = clsPerson.Find(personID);

            if (_Person != null)
            {
                DisplayPersonInfo();
                UpdateStatus("ACTIVE", secondaryColor);
            }
            else
            {
                ClearPersonInfo();
                UpdateStatus("NOT FOUND", Color.FromArgb(239, 68, 68));
            }
        }

        private void DisplayPersonInfo()
        {
            // Personal Info
            lblFullName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            lblPersonID.Text = _Person.ID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblAddress.Text = _Person.Address;

            // Contact Info
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID)?.CountryName ?? "N/A";
            lblPhone.Text = _Person.Phone;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;

            // Photo
            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                try
                {
                    pbSelfiPicture.BringToFront();
                    pbSelfiPicture.Load(_Person.ImagePath);
                    lblPhotoPlaceholder.Visible = false;
                }
                catch
                {
                    
                    pbSelfiPicture.Image = null;
                    lblPhotoPlaceholder.Visible = true;
                }
            }
            else
            {
                pbSelfiPicture.Image = null;
                lblPhotoPlaceholder.Visible = true;
            }

            // Update last updated
            lblLastUpdated.Text = $"⏱️ Last updated: {DateTime.Now.ToShortDateString()}";
        }

        private void ClearPersonInfo()
        {
            lblFullName.Text = "N/A";
            lblPersonID.Text = "N/A";
            lblNationalNo.Text = "N/A";
            lblDateOfBirth.Text = "N/A";
            lblAddress.Text = "N/A";
            lblCountry.Text = "N/A";
            lblPhone.Text = "N/A";
            lblEmail.Text = "N/A";
            lblAddress.Text = "N/A";
            pbSelfiPicture.Image = null;
            lblPhotoPlaceholder.Visible = true;
        }

        private void UpdateStatus(string status, Color color)
        {
            lblStatus.Text = status;
            lblStatus.ForeColor = color;
            pnlStatusIndicator.BackColor = color;
            pnlStatusIndicator.Invalidate(); // Force repaint
        }

        // Property to access person data
        public clsPerson Person
        {
            get { return _Person; }
        }
    }
}