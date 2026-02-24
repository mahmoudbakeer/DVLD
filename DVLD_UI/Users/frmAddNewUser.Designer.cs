namespace DVLD_UI.Users
{
    partial class frmAddNewUser
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPerosnalInfo = new System.Windows.Forms.TabPage();
            this.tpUserCredentials = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardWithFilter1 = new DVLD_UI.People.controls.ctrlPersonCardWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassowrd = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtConfirmpassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassowrd = new System.Windows.Forms.Label();
            this.lblPersonIDTitle = new System.Windows.Forms.Label();
            this.lblPersinID = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tpPerosnalInfo.SuspendLayout();
            this.tpUserCredentials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPerosnalInfo);
            this.tabControl1.Controls.Add(this.tpUserCredentials);
            this.tabControl1.Location = new System.Drawing.Point(-4, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(918, 457);
            this.tabControl1.TabIndex = 0;
            // 
            // tpPerosnalInfo
            // 
            this.tpPerosnalInfo.Controls.Add(this.btnNext);
            this.tpPerosnalInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tpPerosnalInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPerosnalInfo.Name = "tpPerosnalInfo";
            this.tpPerosnalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPerosnalInfo.Size = new System.Drawing.Size(910, 431);
            this.tpPerosnalInfo.TabIndex = 0;
            this.tpPerosnalInfo.Text = "Personal Info";
            this.tpPerosnalInfo.UseVisualStyleBackColor = true;
            this.tpPerosnalInfo.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tpUserCredentials
            // 
            this.tpUserCredentials.Controls.Add(this.cbIsActive);
            this.tpUserCredentials.Controls.Add(this.lblPersinID);
            this.tpUserCredentials.Controls.Add(this.lblPersonIDTitle);
            this.tpUserCredentials.Controls.Add(this.lblConfirmPassowrd);
            this.tpUserCredentials.Controls.Add(this.txtConfirmpassword);
            this.tpUserCredentials.Controls.Add(this.pictureBox3);
            this.tpUserCredentials.Controls.Add(this.pictureBox2);
            this.tpUserCredentials.Controls.Add(this.pictureBox1);
            this.tpUserCredentials.Controls.Add(this.lblPassowrd);
            this.tpUserCredentials.Controls.Add(this.lblUserName);
            this.tpUserCredentials.Controls.Add(this.txtPassword);
            this.tpUserCredentials.Controls.Add(this.txtUserName);
            this.tpUserCredentials.Location = new System.Drawing.Point(4, 22);
            this.tpUserCredentials.Name = "tpUserCredentials";
            this.tpUserCredentials.Padding = new System.Windows.Forms.Padding(3);
            this.tpUserCredentials.Size = new System.Drawing.Size(910, 431);
            this.tpUserCredentials.TabIndex = 1;
            this.tpUserCredentials.Text = "User Credentials";
            this.tpUserCredentials.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.SeaShell;
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(3, 6);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Person = null;
            this.ctrlPersonCardWithFilter1.PersonID = 0;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(865, 376);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnNext.Location = new System.Drawing.Point(730, 388);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 37);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancel.Location = new System.Drawing.Point(313, 516);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 37);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSave.Location = new System.Drawing.Point(429, 516);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 37);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(222, 135);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(174, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(222, 180);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(174, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(25, 132);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(92, 22);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "UserName :";
            // 
            // lblPassowrd
            // 
            this.lblPassowrd.AutoSize = true;
            this.lblPassowrd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassowrd.Location = new System.Drawing.Point(25, 180);
            this.lblPassowrd.Name = "lblPassowrd";
            this.lblPassowrd.Size = new System.Drawing.Size(82, 22);
            this.lblPassowrd.TabIndex = 3;
            this.lblPassowrd.Text = "Password :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_UI.Properties.Resources.padlock;
            this.pictureBox2.Location = new System.Drawing.Point(174, 177);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(174, 132);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_UI.Properties.Resources.padlock;
            this.pictureBox3.Location = new System.Drawing.Point(174, 227);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // txtConfirmpassword
            // 
            this.txtConfirmpassword.Location = new System.Drawing.Point(222, 230);
            this.txtConfirmpassword.Name = "txtConfirmpassword";
            this.txtConfirmpassword.Size = new System.Drawing.Size(174, 20);
            this.txtConfirmpassword.TabIndex = 7;
            // 
            // lblConfirmPassowrd
            // 
            this.lblConfirmPassowrd.AutoSize = true;
            this.lblConfirmPassowrd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassowrd.Location = new System.Drawing.Point(25, 230);
            this.lblConfirmPassowrd.Name = "lblConfirmPassowrd";
            this.lblConfirmPassowrd.Size = new System.Drawing.Size(143, 22);
            this.lblConfirmPassowrd.TabIndex = 8;
            this.lblConfirmPassowrd.Text = "Confirm Password :";
            // 
            // lblPersonIDTitle
            // 
            this.lblPersonIDTitle.AutoSize = true;
            this.lblPersonIDTitle.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonIDTitle.Location = new System.Drawing.Point(25, 75);
            this.lblPersonIDTitle.Name = "lblPersonIDTitle";
            this.lblPersonIDTitle.Size = new System.Drawing.Size(80, 22);
            this.lblPersonIDTitle.TabIndex = 9;
            this.lblPersonIDTitle.Text = "PersonID :";
            // 
            // lblPersinID
            // 
            this.lblPersinID.AutoSize = true;
            this.lblPersinID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersinID.Location = new System.Drawing.Point(170, 75);
            this.lblPersinID.Name = "lblPersinID";
            this.lblPersinID.Size = new System.Drawing.Size(34, 22);
            this.lblPersinID.TabIndex = 10;
            this.lblPersinID.Text = "###";
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActive.Location = new System.Drawing.Point(222, 279);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(84, 24);
            this.cbIsActive.TabIndex = 11;
            this.cbIsActive.Text = "IsActive";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 565);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAddNewUser";
            this.Text = "frmAddNewUser";
            this.tabControl1.ResumeLayout(false);
            this.tpPerosnalInfo.ResumeLayout(false);
            this.tpUserCredentials.ResumeLayout(false);
            this.tpUserCredentials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPerosnalInfo;
        private System.Windows.Forms.TabPage tpUserCredentials;
        private People.controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPassowrd;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPersinID;
        private System.Windows.Forms.Label lblPersonIDTitle;
        private System.Windows.Forms.Label lblConfirmPassowrd;
        private System.Windows.Forms.TextBox txtConfirmpassword;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}