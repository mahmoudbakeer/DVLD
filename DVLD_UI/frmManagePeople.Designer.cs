namespace DVLD_UI
{
    partial class frmManagePeople
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
            this.ManagePeopleTitle = new System.Windows.Forms.Label();
            this.dgvAllPeople = new System.Windows.Forms.DataGridView();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.cbSortBy = new System.Windows.Forms.ComboBox();
            this.SortTitle = new System.Windows.Forms.Label();
            this.pbManagePeopleForm = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManagePeopleForm)).BeginInit();
            this.SuspendLayout();
            // 
            // ManagePeopleTitle
            // 
            this.ManagePeopleTitle.AutoSize = true;
            this.ManagePeopleTitle.Font = new System.Drawing.Font("Palatino Linotype", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManagePeopleTitle.ForeColor = System.Drawing.Color.Blue;
            this.ManagePeopleTitle.Location = new System.Drawing.Point(339, 212);
            this.ManagePeopleTitle.Name = "ManagePeopleTitle";
            this.ManagePeopleTitle.Size = new System.Drawing.Size(227, 43);
            this.ManagePeopleTitle.TabIndex = 1;
            this.ManagePeopleTitle.Text = "ManagePeople";
            // 
            // dgvAllPeople
            // 
            this.dgvAllPeople.AllowUserToAddRows = false;
            this.dgvAllPeople.AllowUserToDeleteRows = false;
            this.dgvAllPeople.AllowUserToOrderColumns = true;
            this.dgvAllPeople.BackgroundColor = System.Drawing.Color.LightSalmon;
            this.dgvAllPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllPeople.Location = new System.Drawing.Point(5, 298);
            this.dgvAllPeople.Name = "dgvAllPeople";
            this.dgvAllPeople.ReadOnly = true;
            this.dgvAllPeople.Size = new System.Drawing.Size(922, 295);
            this.dgvAllPeople.TabIndex = 2;
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackColor = System.Drawing.Color.SandyBrown;
            this.btnAddNewPerson.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewPerson.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewPerson.Location = new System.Drawing.Point(777, 228);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(129, 53);
            this.btnAddNewPerson.TabIndex = 3;
            this.btnAddNewPerson.Text = "AddNew";
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // cbSortBy
            // 
            this.cbSortBy.BackColor = System.Drawing.Color.Silver;
            this.cbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSortBy.FormattingEnabled = true;
            this.cbSortBy.Items.AddRange(new object[] {
            "FirstName",
            "SecondName",
            "ThirdName",
            "LastName",
            "NationalNo",
            "Country"});
            this.cbSortBy.Location = new System.Drawing.Point(90, 259);
            this.cbSortBy.Name = "cbSortBy";
            this.cbSortBy.Size = new System.Drawing.Size(204, 21);
            this.cbSortBy.TabIndex = 4;
            // 
            // SortTitle
            // 
            this.SortTitle.AutoSize = true;
            this.SortTitle.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortTitle.Location = new System.Drawing.Point(12, 254);
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Size = new System.Drawing.Size(72, 26);
            this.SortTitle.TabIndex = 5;
            this.SortTitle.Text = "Sort By";
            // 
            // pbManagePeopleForm
            // 
            this.pbManagePeopleForm.Image = global::DVLD_UI.Properties.Resources.group;
            this.pbManagePeopleForm.Location = new System.Drawing.Point(309, 53);
            this.pbManagePeopleForm.Name = "pbManagePeopleForm";
            this.pbManagePeopleForm.Size = new System.Drawing.Size(278, 139);
            this.pbManagePeopleForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbManagePeopleForm.TabIndex = 0;
            this.pbManagePeopleForm.TabStop = false;
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(939, 620);
            this.Controls.Add(this.SortTitle);
            this.Controls.Add(this.cbSortBy);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.dgvAllPeople);
            this.Controls.Add(this.ManagePeopleTitle);
            this.Controls.Add(this.pbManagePeopleForm);
            this.Name = "frmManagePeople";
            this.Text = "ManagePeople";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManagePeopleForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbManagePeopleForm;
        private System.Windows.Forms.Label ManagePeopleTitle;
        private System.Windows.Forms.DataGridView dgvAllPeople;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.ComboBox cbSortBy;
        private System.Windows.Forms.Label SortTitle;
    }
}