using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DVLD_UI
{
    partial class ctrlUpdatePersonInfo
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlRightColumn = new System.Windows.Forms.Panel();
            this.lblContactInfoHeader = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.txtNationalNo = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cbCountries = new System.Windows.Forms.ComboBox();
            this.pnlLeftColumn = new System.Windows.Forms.Panel();
            this.lblPersonalInfoHeader = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblSecondName = new System.Windows.Forms.Label();
            this.txtSecondName = new System.Windows.Forms.TextBox();
            this.lblThirdName = new System.Windows.Forms.Label();
            this.txtThirdName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pnlPhotoSection = new System.Windows.Forms.Panel();
            this.pnlPhotoFrame = new System.Windows.Forms.Panel();
            this.ProfilePicture = new System.Windows.Forms.PictureBox();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.btnDeletePicture = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblAddNewPerson = new System.Windows.Forms.Label();
            this.pnlHeaderAccent = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.epValidation = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlRightColumn.SuspendLayout();
            this.pnlLeftColumn.SuspendLayout();
            this.pnlPhotoSection.SuspendLayout();
            this.pnlPhotoFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlPhotoSection);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 600);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 530);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(30, 15, 30, 15);
            this.pnlFooter.Size = new System.Drawing.Size(900, 70);
            this.pnlFooter.TabIndex = 3;
            this.pnlFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFooter_Paint);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(379, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "💾 Save Person";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSave_Paint);
            this.btnSave.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.pnlRightColumn);
            this.pnlContent.Controls.Add(this.pnlLeftColumn);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 250);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlContent.Size = new System.Drawing.Size(900, 350);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlRightColumn
            // 
            this.pnlRightColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlRightColumn.Controls.Add(this.lblContactInfoHeader);
            this.pnlRightColumn.Controls.Add(this.lblPhone);
            this.pnlRightColumn.Controls.Add(this.txtPhone);
            this.pnlRightColumn.Controls.Add(this.lblAddress);
            this.pnlRightColumn.Controls.Add(this.txtAddress);
            this.pnlRightColumn.Controls.Add(this.lblDateOfBirth);
            this.pnlRightColumn.Controls.Add(this.dtpDateOfBirth);
            this.pnlRightColumn.Controls.Add(this.lblNationalNo);
            this.pnlRightColumn.Controls.Add(this.txtNationalNo);
            this.pnlRightColumn.Controls.Add(this.lblCountry);
            this.pnlRightColumn.Controls.Add(this.cbCountries);
            this.pnlRightColumn.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightColumn.Location = new System.Drawing.Point(450, 20);
            this.pnlRightColumn.Name = "pnlRightColumn";
            this.pnlRightColumn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnlRightColumn.Size = new System.Drawing.Size(420, 310);
            this.pnlRightColumn.TabIndex = 1;
            this.pnlRightColumn.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRightColumn_Paint);
            // 
            // lblContactInfoHeader
            // 
            this.lblContactInfoHeader.AutoSize = true;
            this.lblContactInfoHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblContactInfoHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.lblContactInfoHeader.Location = new System.Drawing.Point(20, 0);
            this.lblContactInfoHeader.Name = "lblContactInfoHeader";
            this.lblContactInfoHeader.Size = new System.Drawing.Size(204, 21);
            this.lblContactInfoHeader.TabIndex = 0;
            this.lblContactInfoHeader.Text = "📞 Contact & Other Details";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPhone.Location = new System.Drawing.Point(20, 35);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(88, 15);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "Phone Number";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtPhone.Location = new System.Drawing.Point(20, 58);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(190, 25);
            this.txtPhone.TabIndex = 6;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblAddress.Location = new System.Drawing.Point(20, 90);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(49, 15);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtAddress.Location = new System.Drawing.Point(20, 113);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(190, 25);
            this.txtAddress.TabIndex = 7;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateOfBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDateOfBirth.Location = new System.Drawing.Point(230, 35);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(73, 15);
            this.lblDateOfBirth.TabIndex = 5;
            this.lblDateOfBirth.Text = "Date of Birth";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(230, 58);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(160, 25);
            this.dtpDateOfBirth.TabIndex = 8;
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNationalNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNationalNo.Location = new System.Drawing.Point(230, 90);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(71, 15);
            this.lblNationalNo.TabIndex = 7;
            this.lblNationalNo.Text = "National No";
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtNationalNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNationalNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNationalNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtNationalNo.Location = new System.Drawing.Point(230, 113);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Size = new System.Drawing.Size(160, 25);
            this.txtNationalNo.TabIndex = 9;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCountry.Location = new System.Drawing.Point(230, 145);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(50, 15);
            this.lblCountry.TabIndex = 9;
            this.lblCountry.Text = "Country";
            // 
            // cbCountries
            // 
            this.cbCountries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.cbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCountries.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCountries.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cbCountries.FormattingEnabled = true;
            this.cbCountries.Location = new System.Drawing.Point(230, 168);
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.Size = new System.Drawing.Size(160, 25);
            this.cbCountries.TabIndex = 10;
            // 
            // pnlLeftColumn
            // 
            this.pnlLeftColumn.BackColor = System.Drawing.Color.White;
            this.pnlLeftColumn.Controls.Add(this.lblPersonalInfoHeader);
            this.pnlLeftColumn.Controls.Add(this.lblFirstName);
            this.pnlLeftColumn.Controls.Add(this.txtFirstName);
            this.pnlLeftColumn.Controls.Add(this.lblSecondName);
            this.pnlLeftColumn.Controls.Add(this.txtSecondName);
            this.pnlLeftColumn.Controls.Add(this.lblThirdName);
            this.pnlLeftColumn.Controls.Add(this.txtThirdName);
            this.pnlLeftColumn.Controls.Add(this.lblLastName);
            this.pnlLeftColumn.Controls.Add(this.txtLastName);
            this.pnlLeftColumn.Controls.Add(this.lblEmail);
            this.pnlLeftColumn.Controls.Add(this.txtEmail);
            this.pnlLeftColumn.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftColumn.Location = new System.Drawing.Point(30, 20);
            this.pnlLeftColumn.Name = "pnlLeftColumn";
            this.pnlLeftColumn.Size = new System.Drawing.Size(400, 310);
            this.pnlLeftColumn.TabIndex = 0;
            // 
            // lblPersonalInfoHeader
            // 
            this.lblPersonalInfoHeader.AutoSize = true;
            this.lblPersonalInfoHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPersonalInfoHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.lblPersonalInfoHeader.Location = new System.Drawing.Point(0, 0);
            this.lblPersonalInfoHeader.Name = "lblPersonalInfoHeader";
            this.lblPersonalInfoHeader.Size = new System.Drawing.Size(199, 21);
            this.lblPersonalInfoHeader.TabIndex = 0;
            this.lblPersonalInfoHeader.Text = "👤 Personal Information";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFirstName.Location = new System.Drawing.Point(0, 35);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(64, 15);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtFirstName.Location = new System.Drawing.Point(0, 58);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(190, 25);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblSecondName
            // 
            this.lblSecondName.AutoSize = true;
            this.lblSecondName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSecondName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSecondName.Location = new System.Drawing.Point(0, 90);
            this.lblSecondName.Name = "lblSecondName";
            this.lblSecondName.Size = new System.Drawing.Size(81, 15);
            this.lblSecondName.TabIndex = 3;
            this.lblSecondName.Text = "Second Name";
            // 
            // txtSecondName
            // 
            this.txtSecondName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtSecondName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSecondName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtSecondName.Location = new System.Drawing.Point(0, 113);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(190, 25);
            this.txtSecondName.TabIndex = 2;
            // 
            // lblThirdName
            // 
            this.lblThirdName.AutoSize = true;
            this.lblThirdName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThirdName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblThirdName.Location = new System.Drawing.Point(0, 145);
            this.lblThirdName.Name = "lblThirdName";
            this.lblThirdName.Size = new System.Drawing.Size(70, 15);
            this.lblThirdName.TabIndex = 5;
            this.lblThirdName.Text = "Third Name";
            // 
            // txtThirdName
            // 
            this.txtThirdName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtThirdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThirdName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtThirdName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtThirdName.Location = new System.Drawing.Point(0, 168);
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Size = new System.Drawing.Size(190, 25);
            this.txtThirdName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblLastName.Location = new System.Drawing.Point(210, 35);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(63, 15);
            this.lblLastName.TabIndex = 7;
            this.lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtLastName.Location = new System.Drawing.Point(210, 58);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(190, 25);
            this.txtLastName.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEmail.Location = new System.Drawing.Point(210, 90);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(81, 15);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email Address";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtEmail.Location = new System.Drawing.Point(210, 113);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(190, 25);
            this.txtEmail.TabIndex = 5;
            // 
            // pnlPhotoSection
            // 
            this.pnlPhotoSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlPhotoSection.Controls.Add(this.pnlPhotoFrame);
            this.pnlPhotoSection.Controls.Add(this.btnAddPicture);
            this.pnlPhotoSection.Controls.Add(this.btnDeletePicture);
            this.pnlPhotoSection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPhotoSection.Location = new System.Drawing.Point(0, 90);
            this.pnlPhotoSection.Name = "pnlPhotoSection";
            this.pnlPhotoSection.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlPhotoSection.Size = new System.Drawing.Size(900, 160);
            this.pnlPhotoSection.TabIndex = 1;
            // 
            // pnlPhotoFrame
            // 
            this.pnlPhotoFrame.BackColor = System.Drawing.Color.White;
            this.pnlPhotoFrame.Controls.Add(this.ProfilePicture);
            this.pnlPhotoFrame.Location = new System.Drawing.Point(370, 20);
            this.pnlPhotoFrame.Name = "pnlPhotoFrame";
            this.pnlPhotoFrame.Size = new System.Drawing.Size(120, 120);
            this.pnlPhotoFrame.TabIndex = 0;
            this.pnlPhotoFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPhotoFrame_Paint);
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ProfilePicture.Image = global::DVLD_UI.Properties.Resources.office_man;
            this.ProfilePicture.Location = new System.Drawing.Point(10, 10);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(100, 100);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfilePicture.TabIndex = 0;
            this.ProfilePicture.TabStop = false;
            this.ProfilePicture.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnAddPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPicture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddPicture.ForeColor = System.Drawing.Color.White;
            this.btnAddPicture.Location = new System.Drawing.Point(510, 45);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(130, 35);
            this.btnAddPicture.TabIndex = 1;
            this.btnAddPicture.Text = "📷 Change Photo";
            this.btnAddPicture.UseVisualStyleBackColor = false;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            this.btnAddPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.btnAddPicture_Paint);
            this.btnAddPicture.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnAddPicture.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnDeletePicture
            // 
            this.btnDeletePicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDeletePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePicture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeletePicture.ForeColor = System.Drawing.Color.White;
            this.btnDeletePicture.Location = new System.Drawing.Point(510, 90);
            this.btnDeletePicture.Name = "btnDeletePicture";
            this.btnDeletePicture.Size = new System.Drawing.Size(130, 35);
            this.btnDeletePicture.TabIndex = 2;
            this.btnDeletePicture.Text = "🗑️ Remove";
            this.btnDeletePicture.UseVisualStyleBackColor = false;
            this.btnDeletePicture.Click += new System.EventHandler(this.btnDeletePicture_Click);
            this.btnDeletePicture.Paint += new System.Windows.Forms.PaintEventHandler(this.btnDeletePicture_Paint);
            this.btnDeletePicture.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnDeletePicture.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblAddNewPerson);
            this.pnlHeader.Controls.Add(this.pnlHeaderAccent);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 90);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblSubtitle.Location = new System.Drawing.Point(28, 57);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(153, 19);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Update personal details";
            // 
            // lblAddNewPerson
            // 
            this.lblAddNewPerson.AutoSize = true;
            this.lblAddNewPerson.BackColor = System.Drawing.Color.Transparent;
            this.lblAddNewPerson.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAddNewPerson.ForeColor = System.Drawing.Color.White;
            this.lblAddNewPerson.Location = new System.Drawing.Point(25, 20);
            this.lblAddNewPerson.Name = "lblAddNewPerson";
            this.lblAddNewPerson.Size = new System.Drawing.Size(272, 37);
            this.lblAddNewPerson.TabIndex = 1;
            this.lblAddNewPerson.Text = "Update Person";
            // 
            // pnlHeaderAccent
            // 
            this.pnlHeaderAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlHeaderAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderAccent.Name = "pnlHeaderAccent";
            this.pnlHeaderAccent.Size = new System.Drawing.Size(5, 90);
            this.pnlHeaderAccent.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // epValidation
            // 
            this.epValidation.ContainerControl = this;
            // 
            // ctrlUpdatePersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ctrlUpdatePersonInfo";
            this.Size = new System.Drawing.Size(900, 600);
            this.pnlMain.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlRightColumn.ResumeLayout(false);
            this.pnlRightColumn.PerformLayout();
            this.pnlLeftColumn.ResumeLayout(false);
            this.pnlLeftColumn.PerformLayout();
            this.pnlPhotoSection.ResumeLayout(false);
            this.pnlPhotoFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Paint Event Handlers

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(this.borderColor, 1))
            {
                Rectangle rect = new Rectangle(0, 0, this.pnlMain.Width - 1, this.pnlMain.Height - 1);
                g.DrawRectangle(pen, rect);
            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, this.pnlHeader.Width, this.pnlHeader.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, this.primaryColor, this.primaryLight, LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void pnlPhotoFrame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.pnlPhotoFrame.Width - 1, this.pnlPhotoFrame.Height - 1);
            using (Pen pen = new Pen(this.borderColor, 2))
            {
                g.DrawRectangle(pen, rect);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, this.ProfilePicture.Width - 1, this.ProfilePicture.Height - 1);
                this.ProfilePicture.Region = new Region(path);
            }
        }

        private void pnlRightColumn_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.pnlRightColumn.Width - 1, this.pnlRightColumn.Height - 1);
            using (Pen pen = new Pen(this.borderColor, 1))
            {
                g.DrawRectangle(pen, rect);
            }
        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(this.borderColor, 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, this.pnlFooter.Width, 0);
            }
        }

        private void btnSave_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(this.primaryColor, 0))
                {
                    Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void btnCancel_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(this.mediumText, 0))
                {
                    Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void btnAddPicture_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(this.accentGreen, 0))
                {
                    Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void btnDeletePicture_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(this.accentRed, 0))
                {
                    Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void Button_MouseEnter(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                // Slightly darken on hover
                if (btn == this.btnSave)
                    btn.BackColor = Color.FromArgb(79, 82, 221); // Darker primary
                else if (btn == this.btnAddPicture)
                    btn.BackColor = Color.FromArgb(5, 150, 105); // Darker green
                else if (btn == this.btnDeletePicture)
                    btn.BackColor = Color.FromArgb(220, 38, 38); // Darker red
            }
        }

        private void Button_MouseLeave(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Return to original color using the color fields
                if (btn == this.btnSave)
                    btn.BackColor = this.primaryColor;
                else if (btn == this.btnAddPicture)
                    btn.BackColor = this.accentGreen;
                else if (btn == this.btnDeletePicture)
                    btn.BackColor = this.accentRed;
            }
        }

        #endregion

        #region Color Fields

        private Color primaryColor;
        private Color primaryLight;
        private Color accentGreen;
        private Color accentOrange;
        private Color accentRed;
        private Color darkText;
        private Color mediumText;
        private Color lightText;
        private Color cardBackground;
        private Color sectionBackground;
        private Color borderColor;
        private Color inputBackground;

        #endregion

        #region Control Declarations

        // Panels
        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlHeaderAccent;
        private Panel pnlPhotoSection;
        private Panel pnlPhotoFrame;
        private Panel pnlContent;
        private Panel pnlLeftColumn;
        private Panel pnlRightColumn;
        private Panel pnlFooter;

        // Header
        private Label lblAddNewPerson;
        private Label lblSubtitle;

        // Photo section
        private PictureBox ProfilePicture;
        private Button btnAddPicture;
        private Button btnDeletePicture;

        // Section headers
        private Label lblPersonalInfoHeader;
        private Label lblContactInfoHeader;

        // Name fields
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblSecondName;
        private TextBox txtSecondName;
        private Label lblThirdName;
        private TextBox txtThirdName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblEmail;
        private TextBox txtEmail;

        // Contact fields
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblDateOfBirth;
        private DateTimePicker dtpDateOfBirth;
        private Label lblNationalNo;
        private TextBox txtNationalNo;
        private Label lblCountry;
        private ComboBox cbCountries;

        // Action buttons
        private Button btnSave;

        #endregion

        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private ErrorProvider epValidation;
    }

    // Add this partial class for the constructor and additional methods
}