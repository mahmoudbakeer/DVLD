namespace DVLD_UI.Applications
{
    partial class frmAddUpdateLocalDrivingLicenseAppliction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPerosnalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new DVLD_UI.People.controls.ctrlPersonCardWithFilter();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblLicenseClassTitle = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplivationID = new System.Windows.Forms.Label();
            this.lblPersonIDTitle = new System.Windows.Forms.Label();
            this.lblCreatedByTitle = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblApplicationFeesTitle = new System.Windows.Forms.Label();
            this.lblApplicationDateTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpPerosnalInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPerosnalInfo);
            this.tabControl1.Controls.Add(this.tpApplicationInfo);
            this.tabControl1.Location = new System.Drawing.Point(22, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(918, 457);
            this.tabControl1.TabIndex = 1;
            // 
            // tpPerosnalInfo
            // 
            this.tpPerosnalInfo.BackColor = System.Drawing.Color.SaddleBrown;
            this.tpPerosnalInfo.Controls.Add(this.btnNext);
            this.tpPerosnalInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tpPerosnalInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPerosnalInfo.Name = "tpPerosnalInfo";
            this.tpPerosnalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPerosnalInfo.Size = new System.Drawing.Size(910, 431);
            this.tpPerosnalInfo.TabIndex = 0;
            this.tpPerosnalInfo.Text = "Personal Info";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(770, 388);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 37);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.SaddleBrown;
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(16, 6);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Person = null;
            this.ctrlPersonCardWithFilter1.PersonID = 0;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(865, 376);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tpApplicationInfo.Controls.Add(this.cbLicenseClasses);
            this.tpApplicationInfo.Controls.Add(this.pictureBox4);
            this.tpApplicationInfo.Controls.Add(this.lblLicenseClassTitle);
            this.tpApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tpApplicationInfo.Controls.Add(this.lblApplivationID);
            this.tpApplicationInfo.Controls.Add(this.lblPersonIDTitle);
            this.tpApplicationInfo.Controls.Add(this.lblCreatedByTitle);
            this.tpApplicationInfo.Controls.Add(this.pictureBox3);
            this.tpApplicationInfo.Controls.Add(this.pictureBox2);
            this.tpApplicationInfo.Controls.Add(this.pictureBox1);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationFeesTitle);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationDateTitle);
            this.tpApplicationInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(910, 431);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            this.tpApplicationInfo.Click += new System.EventHandler(this.tpApplicationInfo_Click);
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Items.AddRange(new object[] {
            "Class 1 - Small Motorcycle",
            "Class 2 - Heavy Motorcycle License",
            "Class 3 - Ordinary driving license",
            "Class 4 - Commercial",
            "Class 5 - Agricultural",
            "Class 6 - Small and medium bus",
            "Class 7 - Truck and heavy vehicle"});
            this.cbLicenseClasses.Location = new System.Drawing.Point(254, 291);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(231, 21);
            this.cbLicenseClasses.TabIndex = 17;
            this.cbLicenseClasses.Validating += new System.ComponentModel.CancelEventHandler(this.cbLicenseClasses_Validating);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_UI.Properties.Resources.licensing;
            this.pictureBox4.Location = new System.Drawing.Point(174, 287);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 23);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // lblLicenseClassTitle
            // 
            this.lblLicenseClassTitle.AutoSize = true;
            this.lblLicenseClassTitle.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseClassTitle.Location = new System.Drawing.Point(25, 288);
            this.lblLicenseClassTitle.Name = "lblLicenseClassTitle";
            this.lblLicenseClassTitle.Size = new System.Drawing.Size(107, 22);
            this.lblLicenseClassTitle.TabIndex = 15;
            this.lblLicenseClassTitle.Text = "License Class :";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.ForeColor = System.Drawing.Color.Red;
            this.lblCreatedBy.Location = new System.Drawing.Point(250, 227);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(34, 22);
            this.lblCreatedBy.TabIndex = 14;
            this.lblCreatedBy.Text = "###";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.ForeColor = System.Drawing.Color.Red;
            this.lblApplicationFees.Location = new System.Drawing.Point(250, 180);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(34, 22);
            this.lblApplicationFees.TabIndex = 13;
            this.lblApplicationFees.Text = "###";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblApplicationDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.ForeColor = System.Drawing.Color.Red;
            this.lblApplicationDate.Location = new System.Drawing.Point(250, 132);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(34, 22);
            this.lblApplicationDate.TabIndex = 12;
            this.lblApplicationDate.Text = "###";
            // 
            // lblApplivationID
            // 
            this.lblApplivationID.AutoSize = true;
            this.lblApplivationID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplivationID.Location = new System.Drawing.Point(170, 75);
            this.lblApplivationID.Name = "lblApplivationID";
            this.lblApplivationID.Size = new System.Drawing.Size(34, 22);
            this.lblApplivationID.TabIndex = 10;
            this.lblApplivationID.Text = "###";
            // 
            // lblPersonIDTitle
            // 
            this.lblPersonIDTitle.AutoSize = true;
            this.lblPersonIDTitle.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonIDTitle.Location = new System.Drawing.Point(25, 75);
            this.lblPersonIDTitle.Name = "lblPersonIDTitle";
            this.lblPersonIDTitle.Size = new System.Drawing.Size(113, 22);
            this.lblPersonIDTitle.TabIndex = 9;
            this.lblPersonIDTitle.Text = "ApplicationID :";
            // 
            // lblCreatedByTitle
            // 
            this.lblCreatedByTitle.AutoSize = true;
            this.lblCreatedByTitle.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByTitle.Location = new System.Drawing.Point(25, 230);
            this.lblCreatedByTitle.Name = "lblCreatedByTitle";
            this.lblCreatedByTitle.Size = new System.Drawing.Size(94, 22);
            this.lblCreatedByTitle.TabIndex = 8;
            this.lblCreatedByTitle.Text = "Created By :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_UI.Properties.Resources.user;
            this.pictureBox3.Location = new System.Drawing.Point(174, 227);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_UI.Properties.Resources.money;
            this.pictureBox2.Location = new System.Drawing.Point(174, 177);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.date_of_birth;
            this.pictureBox1.Location = new System.Drawing.Point(174, 132);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblApplicationFeesTitle
            // 
            this.lblApplicationFeesTitle.AutoSize = true;
            this.lblApplicationFeesTitle.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFeesTitle.Location = new System.Drawing.Point(25, 180);
            this.lblApplicationFeesTitle.Name = "lblApplicationFeesTitle";
            this.lblApplicationFeesTitle.Size = new System.Drawing.Size(129, 22);
            this.lblApplicationFeesTitle.TabIndex = 3;
            this.lblApplicationFeesTitle.Text = "Application Fees :";
            // 
            // lblApplicationDateTitle
            // 
            this.lblApplicationDateTitle.AutoSize = true;
            this.lblApplicationDateTitle.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDateTitle.Location = new System.Drawing.Point(25, 132);
            this.lblApplicationDateTitle.Name = "lblApplicationDateTitle";
            this.lblApplicationDateTitle.Size = new System.Drawing.Size(136, 22);
            this.lblApplicationDateTitle.TabIndex = 2;
            this.lblApplicationDateTitle.Text = "Appllication Date :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(478, 557);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 37);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Goldenrod;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(359, 557);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 37);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Palatino Linotype", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.PeachPuff;
            this.lblMainTitle.Location = new System.Drawing.Point(322, 41);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(311, 39);
            this.lblMainTitle.TabIndex = 6;
            this.lblMainTitle.Text = "Add New Application";
            // 
            // frmAddUpdateLocalDrivingLicenseAppliction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(967, 605);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAddUpdateLocalDrivingLicenseAppliction";
            this.Text = "frmAddNewAppliction";
            this.Load += new System.EventHandler(this.frmAddNewAppliction_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPerosnalInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPerosnalInfo;
        private System.Windows.Forms.Button btnNext;
        private People.controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.Label lblApplivationID;
        private System.Windows.Forms.Label lblPersonIDTitle;
        private System.Windows.Forms.Label lblCreatedByTitle;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblApplicationFeesTitle;
        private System.Windows.Forms.Label lblApplicationDateTitle;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblLicenseClassTitle;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMainTitle;
    }
}