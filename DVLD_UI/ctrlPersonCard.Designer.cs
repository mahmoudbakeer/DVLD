using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DVLD_UI
{
    partial class ctrlPersonCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Enhanced Modern Color Palette
            Color primaryColor = Color.FromArgb(99, 102, 241);        // Indigo
            Color primaryLight = Color.FromArgb(129, 140, 248);       // Light Indigo
            Color secondaryColor = Color.FromArgb(16, 185, 129);      // Emerald
            Color accentOrange = Color.FromArgb(251, 146, 60);        // Orange
            Color accentPink = Color.FromArgb(236, 72, 153);          // Pink
            Color darkText = Color.FromArgb(30, 41, 59);              // Slate 800
            Color mediumText = Color.FromArgb(71, 85, 105);           // Slate 600
            Color lightText = Color.FromArgb(148, 163, 184);          // Slate 400
            Color cardBackground = Color.White;
            Color sectionBackground = Color.FromArgb(248, 250, 252);  // Slate 50
            Color borderColor = Color.FromArgb(226, 232, 240);        // Slate 200
            Color hoverColor = Color.FromArgb(241, 245, 249);         // Slate 100

            // Create panels
            this.pnlMain = new Panel();
            this.pnlHeader = new Panel();
            this.pnlPhotoSection = new Panel();
            this.pnlPhoto = new Panel();
            this.pnlContent = new Panel();
            this.pnlPersonalInfo = new Panel();
            this.pnlContactInfo = new Panel();
            this.pnlFooter = new Panel();
            this.pnlDivider = new Panel();

            // Header elements
            this.lblCardTitle = new Label();
            this.lblCardSubtitle = new Label();
            this.pnlHeaderAccent = new Panel();

            // Photo section
            this.pbSelfiPicture = new PictureBox();
            this.lblPhotoPlaceholder = new Label();
            this.pnlPhotoFrame = new Panel();

            // Personal Information section
            this.lblPersonalInfoHeader = new Label();
            this.lblNameTitle = new Label();
            this.lblPersonIDTitle = new Label();
            this.lblNationalNoTitle = new Label();
            this.lblDateOfBirthTitle = new Label();
            this.lblAddressTitle = new Label();
            this.lblGenderTitle = new Label();

            this.lblFullName = new Label();
            this.lblPersonID = new Label();
            this.lblNationalNo = new Label();
            this.lblDateOfBirth = new Label();
            this.lblAddress = new Label();
            this.lblGender = new Label();

            // Contact Information section
            this.lblContactInfoHeader = new Label();
            this.lblCountryTitle = new Label();
            this.lblPhoneTitle = new Label();
            this.lblEmailTitle = new Label();

            this.lblCountry = new Label();
            this.lblPhone = new Label();
            this.lblEmail = new Label();

            // Icons
            this.pbNameIcon = new PictureBox();
            this.pbPersonIDIcon = new PictureBox();
            this.pbNationalNoIcon = new PictureBox();
            this.pbDateOfBirthIcon = new PictureBox();
            this.pbAddressIcon = new PictureBox();
            this.pbGenderIcon = new PictureBox();
            this.pbCountryIcon = new PictureBox();
            this.pbPhoneIcon = new PictureBox();
            this.pbEmailIcon = new PictureBox();

            // Footer elements
            this.lblLastUpdated = new Label();
            this.lblStatus = new Label();
            this.pnlStatusIndicator = new Panel();

            // ToolTip
            this.toolTip = new ToolTip(this.components);

            // Begin initialization
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlPhotoSection.SuspendLayout();
            this.pnlPhoto.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlPersonalInfo.SuspendLayout();
            this.pnlContactInfo.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelfiPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNameIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonIDIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNationalNoIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDateOfBirthIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddressIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenderIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCountryIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoneIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmailIcon)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlMain - Main Container
            // 
            this.pnlMain.BackColor = cardBackground;
            this.pnlMain.BorderStyle = BorderStyle.None;
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Controls.Add(this.pnlDivider);
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlPhotoSection);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(0);
            this.pnlMain.Size = new Size(800, 450);
            this.pnlMain.TabIndex = 0;

            // Add shadow and rounded corners effect
            this.pnlMain.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw subtle border
                using (Pen pen = new Pen(borderColor, 1))
                {
                    Rectangle rect = new Rectangle(0, 0, this.pnlMain.Width - 1, this.pnlMain.Height - 1);
                    g.DrawRectangle(pen, rect);
                }
            };

            // 
            // pnlHeader - Gradient Header
            // 
            this.pnlHeader.BackColor = primaryColor;
            this.pnlHeader.Controls.Add(this.lblCardSubtitle);
            this.pnlHeader.Controls.Add(this.lblCardTitle);
            this.pnlHeader.Controls.Add(this.pnlHeaderAccent);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(800, 80);
            this.pnlHeader.TabIndex = 0;

            // Gradient paint
            this.pnlHeader.Paint += (s, e) =>
            {
                Rectangle rect = new Rectangle(0, 0, this.pnlHeader.Width, this.pnlHeader.Height);
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect, primaryColor, primaryLight, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };

            // 
            // pnlHeaderAccent
            // 
            this.pnlHeaderAccent.BackColor = Color.FromArgb(100, 255, 255, 255);
            this.pnlHeaderAccent.Location = new Point(0, 0);
            this.pnlHeaderAccent.Name = "pnlHeaderAccent";
            this.pnlHeaderAccent.Size = new Size(5, 80);
            this.pnlHeaderAccent.TabIndex = 0;

            // 
            // lblCardTitle
            // 
            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.BackColor = Color.Transparent;
            this.lblCardTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblCardTitle.ForeColor = Color.White;
            this.lblCardTitle.Location = new Point(25, 20);
            this.lblCardTitle.Name = "lblCardTitle";
            this.lblCardTitle.Size = new Size(200, 32);
            this.lblCardTitle.TabIndex = 1;
            this.lblCardTitle.Text = "Person Profile";

            // 
            // lblCardSubtitle
            // 
            this.lblCardSubtitle.AutoSize = true;
            this.lblCardSubtitle.BackColor = Color.Transparent;
            this.lblCardSubtitle.Font = new Font("Segoe UI", 9F);
            this.lblCardSubtitle.ForeColor = Color.FromArgb(220, 230, 255);
            this.lblCardSubtitle.Location = new Point(28, 52);
            this.lblCardSubtitle.Name = "lblCardSubtitle";
            this.lblCardSubtitle.Size = new Size(180, 15);
            this.lblCardSubtitle.TabIndex = 2;
            this.lblCardSubtitle.Text = "Complete personal information";

            // 
            // pnlPhotoSection - Photo Container
            // 
            this.pnlPhotoSection.BackColor = sectionBackground;
            this.pnlPhotoSection.Controls.Add(this.pnlPhoto);
            this.pnlPhotoSection.Dock = DockStyle.Left;
            this.pnlPhotoSection.Location = new Point(0, 80);
            this.pnlPhotoSection.Name = "pnlPhotoSection";
            this.pnlPhotoSection.Padding = new Padding(25, 25, 15, 25);
            this.pnlPhotoSection.Size = new Size(220, 315);
            this.pnlPhotoSection.TabIndex = 1;

            // 
            // pnlPhoto - Photo Frame
            // 
            this.pnlPhoto.BackColor = Color.White;
            this.pnlPhoto.Controls.Add(this.pnlPhotoFrame);
            this.pnlPhoto.Controls.Add(this.pbSelfiPicture);
            this.pnlPhoto.Controls.Add(this.lblPhotoPlaceholder);
            this.pnlPhoto.Dock = DockStyle.Top;
            this.pnlPhoto.Location = new Point(25, 25);
            this.pnlPhoto.Name = "pnlPhoto";
            this.pnlPhoto.Size = new Size(180, 220);
            this.pnlPhoto.TabIndex = 0;

            // Rounded corners and shadow
            this.pnlPhoto.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, this.pnlPhoto.Width - 1, this.pnlPhoto.Height - 1);

                // Draw border
                using (Pen pen = new Pen(borderColor, 2))
                {
                    g.DrawRectangle(pen, rect);
                }
            };

            // 
            // pnlPhotoFrame - Decorative frame
            // 
            this.pnlPhotoFrame.BackColor = Color.Transparent;
            this.pnlPhotoFrame.Location = new Point(15, 15);
            this.pnlPhotoFrame.Name = "pnlPhotoFrame";
            this.pnlPhotoFrame.Size = new Size(150, 150);
            this.pnlPhotoFrame.TabIndex = 0;

            this.pnlPhotoFrame.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw gradient circle border
                Rectangle rect = new Rectangle(2, 2, this.pnlPhotoFrame.Width - 5, this.pnlPhotoFrame.Height - 5);
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect, primaryColor, accentPink, LinearGradientMode.ForwardDiagonal))
                {
                    using (Pen pen = new Pen(brush, 3))
                    {
                        g.DrawEllipse(pen, rect);
                    }
                }
            };

            // 
            // pbSelfiPicture
            // 
            this.pbSelfiPicture.BackColor = Color.FromArgb(245, 247, 250);
            this.pbSelfiPicture.Location = new Point(20, 20);
            this.pbSelfiPicture.Name = "pbSelfiPicture";
            this.pbSelfiPicture.Size = new Size(140, 140);
            this.pbSelfiPicture.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbSelfiPicture.TabIndex = 1;
            this.pbSelfiPicture.TabStop = false;
            this.toolTip.SetToolTip(this.pbSelfiPicture, "Person Photo");

            // Circular image mask
            this.pbSelfiPicture.Paint += (s, e) =>
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, this.pbSelfiPicture.Width - 1, this.pbSelfiPicture.Height - 1);
                    this.pbSelfiPicture.Region = new Region(path);
                }
            };

            // 
            // lblPhotoPlaceholder
            // 
            this.lblPhotoPlaceholder.AutoSize = true;
            this.lblPhotoPlaceholder.Font = new Font("Segoe UI", 9F);
            this.lblPhotoPlaceholder.ForeColor = mediumText;
            this.lblPhotoPlaceholder.Location = new Point(40, 175);
            this.lblPhotoPlaceholder.Name = "lblPhotoPlaceholder";
            this.lblPhotoPlaceholder.Size = new Size(100, 15);
            this.lblPhotoPlaceholder.TabIndex = 2;
            this.lblPhotoPlaceholder.Text = "Profile Photo";
            this.lblPhotoPlaceholder.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlDivider - Vertical divider
            // 
            this.pnlDivider.BackColor = borderColor;
            this.pnlDivider.Dock = DockStyle.Left;
            this.pnlDivider.Location = new Point(220, 80);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new Size(1, 315);
            this.pnlDivider.TabIndex = 2;

            // 
            // pnlContent - Main content area
            // 
            this.pnlContent.BackColor = cardBackground;
            this.pnlContent.Controls.Add(this.pnlContactInfo);
            this.pnlContent.Controls.Add(this.pnlPersonalInfo);
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Location = new Point(221, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new Padding(25, 20, 25, 20);
            this.pnlContent.Size = new Size(579, 315);
            this.pnlContent.TabIndex = 3;

            // 
            // pnlPersonalInfo
            // 
            this.pnlPersonalInfo.BackColor = cardBackground;
            this.pnlPersonalInfo.Controls.Add(this.lblPersonalInfoHeader);
            this.pnlPersonalInfo.Controls.Add(this.CreateInfoRow(this.pbNameIcon, this.lblNameTitle, this.lblFullName, 50));
            this.pnlPersonalInfo.Controls.Add(this.CreateInfoRow(this.pbPersonIDIcon, this.lblPersonIDTitle, this.lblPersonID, 90));
            this.pnlPersonalInfo.Controls.Add(this.CreateInfoRow(this.pbNationalNoIcon, this.lblNationalNoTitle, this.lblNationalNo, 130));
            this.pnlPersonalInfo.Controls.Add(this.CreateInfoRow(this.pbGenderIcon, this.lblGenderTitle, this.lblGender, 170));
            this.pnlPersonalInfo.Controls.Add(this.CreateInfoRow(this.pbDateOfBirthIcon, this.lblDateOfBirthTitle, this.lblDateOfBirth, 210));
            this.pnlPersonalInfo.Dock = DockStyle.Left;
            this.pnlPersonalInfo.Location = new Point(25, 20);
            this.pnlPersonalInfo.Name = "pnlPersonalInfo";
            this.pnlPersonalInfo.Size = new Size(260, 275);
            this.pnlPersonalInfo.TabIndex = 0;

            // 
            // lblPersonalInfoHeader
            // 
            this.lblPersonalInfoHeader.AutoSize = true;
            this.lblPersonalInfoHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblPersonalInfoHeader.ForeColor = primaryColor;
            this.lblPersonalInfoHeader.Location = new Point(0, 5);
            this.lblPersonalInfoHeader.Name = "lblPersonalInfoHeader";
            this.lblPersonalInfoHeader.Size = new Size(140, 20);
            this.lblPersonalInfoHeader.TabIndex = 0;
            this.lblPersonalInfoHeader.Text = "📋 Personal Details";

            // Configure Personal Info Labels
            ConfigureFieldTitle(this.lblNameTitle, "Full Name");
            ConfigureFieldValue(this.lblFullName, "[Full Name]", darkText, FontStyle.Bold);

            ConfigureFieldTitle(this.lblPersonIDTitle, "Person ID");
            ConfigureFieldValue(this.lblPersonID, "[PersonID]", mediumText);

            ConfigureFieldTitle(this.lblNationalNoTitle, "National No");
            ConfigureFieldValue(this.lblNationalNo, "[NationalNo]", mediumText);

            ConfigureFieldTitle(this.lblGenderTitle, "Gender");
            ConfigureFieldValue(this.lblGender, "[Gender]", mediumText);

            ConfigureFieldTitle(this.lblDateOfBirthTitle, "Date of Birth");
            ConfigureFieldValue(this.lblDateOfBirth, "[DateOfBirth]", mediumText);

            // 
            // pnlContactInfo
            // 
            this.pnlContactInfo.BackColor = sectionBackground;
            this.pnlContactInfo.Controls.Add(this.lblContactInfoHeader);
            this.pnlContactInfo.Controls.Add(this.CreateInfoRow(this.pbCountryIcon, this.lblCountryTitle, this.lblCountry, 50));
            this.pnlContactInfo.Controls.Add(this.CreateInfoRow(this.pbPhoneIcon, this.lblPhoneTitle, this.lblPhone, 90));
            this.pnlContactInfo.Controls.Add(this.CreateInfoRow(this.pbEmailIcon, this.lblEmailTitle, this.lblEmail, 130));
            this.pnlContactInfo.Controls.Add(this.CreateInfoRow(this.pbAddressIcon, this.lblAddressTitle, this.lblAddress, 170));
            this.pnlContactInfo.Dock = DockStyle.Right;
            this.pnlContactInfo.Location = new Point(299, 20);
            this.pnlContactInfo.Name = "pnlContactInfo";
            this.pnlContactInfo.Padding = new Padding(20, 0, 0, 0);
            this.pnlContactInfo.Size = new Size(255, 275);
            this.pnlContactInfo.TabIndex = 1;

            // Rounded corners for contact section
            this.pnlContactInfo.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, this.pnlContactInfo.Width - 1, this.pnlContactInfo.Height - 1);
                using (Pen pen = new Pen(borderColor, 1))
                {
                    g.DrawRectangle(pen, rect);
                }
            };

            // 
            // lblContactInfoHeader
            // 
            this.lblContactInfoHeader.AutoSize = true;
            this.lblContactInfoHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblContactInfoHeader.ForeColor = accentOrange;
            this.lblContactInfoHeader.Location = new Point(20, 5);
            this.lblContactInfoHeader.Name = "lblContactInfoHeader";
            this.lblContactInfoHeader.Size = new Size(140, 20);
            this.lblContactInfoHeader.TabIndex = 0;
            this.lblContactInfoHeader.Text = "📞 Contact Details";

            // Configure Contact Info Labels
            ConfigureFieldTitle(this.lblCountryTitle, "Country");
            ConfigureFieldValue(this.lblCountry, "[Country]", mediumText);

            ConfigureFieldTitle(this.lblPhoneTitle, "Phone");
            ConfigureFieldValue(this.lblPhone, "[Phone]", mediumText);

            ConfigureFieldTitle(this.lblEmailTitle, "Email");
            ConfigureFieldValue(this.lblEmail, "[Email]", mediumText);
            this.lblEmail.MaximumSize = new Size(200, 60);

            ConfigureFieldTitle(this.lblAddressTitle, "Address");
            ConfigureFieldValue(this.lblAddress, "[Address]", mediumText);
            this.lblAddress.MaximumSize = new Size(200, 60);

            // Configure Icons
            ConfigureIcon(this.pbNameIcon, 20);
            ConfigureIcon(this.pbPersonIDIcon, 20);
            ConfigureIcon(this.pbNationalNoIcon, 20);
            ConfigureIcon(this.pbGenderIcon, 20);
            ConfigureIcon(this.pbDateOfBirthIcon, 20);
            ConfigureIcon(this.pbCountryIcon, 20);
            ConfigureIcon(this.pbPhoneIcon, 20);
            ConfigureIcon(this.pbEmailIcon, 20);
            ConfigureIcon(this.pbAddressIcon, 20);

            // Set icon images (using your existing resources)
            this.pbNameIcon.Image = global::DVLD_UI.Properties.Resources.id_card;
            this.pbPersonIDIcon.Image = global::DVLD_UI.Properties.Resources.id_card__1_;
            this.pbNationalNoIcon.Image = global::DVLD_UI.Properties.Resources.id_card__1_;
            this.pbGenderIcon.Image = global::DVLD_UI.Properties.Resources.id_card;
            this.pbDateOfBirthIcon.Image = global::DVLD_UI.Properties.Resources.date_of_birth;
            this.pbCountryIcon.Image = global::DVLD_UI.Properties.Resources.coronavirus;
            this.pbPhoneIcon.Image = global::DVLD_UI.Properties.Resources.phone_call;
            this.pbEmailIcon.Image = global::DVLD_UI.Properties.Resources.mail;
            this.pbAddressIcon.Image = global::DVLD_UI.Properties.Resources.address;

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = sectionBackground;
            this.pnlFooter.BorderStyle = BorderStyle.None;
            this.pnlFooter.Controls.Add(this.pnlStatusIndicator);
            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Controls.Add(this.lblLastUpdated);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 395);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new Padding(25, 10, 25, 10);
            this.pnlFooter.Size = new Size(800, 55);
            this.pnlFooter.TabIndex = 4;

            // Footer top border
            this.pnlFooter.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(borderColor, 1))
                {
                    e.Graphics.DrawLine(pen, 0, 0, this.pnlFooter.Width, 0);
                }
            };

            // 
            // pnlStatusIndicator
            // 
            this.pnlStatusIndicator.BackColor = secondaryColor;
            this.pnlStatusIndicator.Location = new Point(660, 20);
            this.pnlStatusIndicator.Name = "pnlStatusIndicator";
            this.pnlStatusIndicator.Size = new Size(10, 10);
            this.pnlStatusIndicator.TabIndex = 0;

            // Circular indicator
            this.pnlStatusIndicator.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillEllipse(new SolidBrush(secondaryColor), 0, 0, 10, 10);
            };

            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblStatus.ForeColor = secondaryColor;
            this.lblStatus.Location = new Point(675, 17);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(60, 15);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "ACTIVE";

            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Font = new Font("Segoe UI", 8F);
            this.lblLastUpdated.ForeColor = lightText;
            this.lblLastUpdated.Location = new Point(25, 18);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new Size(110, 13);
            this.lblLastUpdated.TabIndex = 2;
            this.lblLastUpdated.Text = "⏱️ Last updated: N/A";

            // 
            // ctrlPersonCard - Main Control
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.Controls.Add(this.pnlMain);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "ctrlPersonCard";
            this.Size = new Size(800, 450);

            // Resume layouts
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPhotoSection.ResumeLayout(false);
            this.pnlPhoto.ResumeLayout(false);
            this.pnlPhoto.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlPersonalInfo.ResumeLayout(false);
            this.pnlPersonalInfo.PerformLayout();
            this.pnlContactInfo.ResumeLayout(false);
            this.pnlContactInfo.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelfiPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNameIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonIDIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNationalNoIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDateOfBirthIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddressIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenderIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCountryIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoneIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmailIcon)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Helper Methods

        private Panel CreateInfoRow(PictureBox icon, Label title, Label value, int yPosition)
        {
            Panel rowPanel = new Panel
            {
                BackColor = Color.Transparent,
                Location = new Point(0, yPosition),
                Size = new Size(240, 30),
                TabIndex = 0
            };

            icon.Location = new Point(0, 5);
            title.Location = new Point(30, 7);
            value.Location = new Point(30, 7);
            value.Left = 130; // Align values

            return rowPanel;
        }

        private void ConfigureFieldTitle(Label label, string text)
        {
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
            label.ForeColor = Color.FromArgb(148, 163, 184);
            label.Text = text.ToUpper();
        }

        private void ConfigureFieldValue(Label label, string text, Color color, FontStyle style = FontStyle.Regular)
        {
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 9.5F, style);
            label.ForeColor = color;
            label.Text = text;
        }

        private void ConfigureIcon(PictureBox pictureBox, int size)
        {
            pictureBox.Size = new Size(size, size);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
        }

        #endregion

        #region Control Declarations

        // Panels
        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlHeaderAccent;
        private Panel pnlPhotoSection;
        private Panel pnlPhoto;
        private Panel pnlPhotoFrame;
        private Panel pnlDivider;
        private Panel pnlContent;
        private Panel pnlPersonalInfo;
        private Panel pnlContactInfo;
        private Panel pnlFooter;
        private Panel pnlStatusIndicator;

        // Header
        private Label lblCardTitle;
        private Label lblCardSubtitle;

        // Photo
        private PictureBox pbSelfiPicture;
        private Label lblPhotoPlaceholder;

        // Headers
        private Label lblPersonalInfoHeader;
        private Label lblContactInfoHeader;

        // Personal Info - Titles
        private Label lblNameTitle;
        private Label lblPersonIDTitle;
        private Label lblNationalNoTitle;
        private Label lblGenderTitle;
        private Label lblDateOfBirthTitle;
        private Label lblAddressTitle;

        // Personal Info - Values
        private Label lblFullName;
        private Label lblPersonID;
        private Label lblNationalNo;
        private Label lblGender;
        private Label lblDateOfBirth;
        private Label lblAddress;

        // Contact Info - Titles
        private Label lblCountryTitle;
        private Label lblPhoneTitle;
        private Label lblEmailTitle;

        // Contact Info - Values
        private Label lblCountry;
        private Label lblPhone;
        private Label lblEmail;

        // Icons
        private PictureBox pbNameIcon;
        private PictureBox pbPersonIDIcon;
        private PictureBox pbNationalNoIcon;
        private PictureBox pbGenderIcon;
        private PictureBox pbDateOfBirthIcon;
        private PictureBox pbAddressIcon;
        private PictureBox pbCountryIcon;
        private PictureBox pbPhoneIcon;
        private PictureBox pbEmailIcon;

        // Footer
        private Label lblLastUpdated;
        private Label lblStatus;

        // Components
        private ToolTip toolTip;

        #endregion
    }
}
