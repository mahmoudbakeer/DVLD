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
            this.components = new System.ComponentModel.Container();
            this.ManagePeopleTitle = new System.Windows.Forms.Label();
            this.dgvAllPeople = new System.Windows.Forms.DataGridView();
            this.cmsManagePerson = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.cbSortBy = new System.Windows.Forms.ComboBox();
            this.SortTitle = new System.Windows.Forms.Label();
            this.pbManagePeopleForm = new System.Windows.Forms.PictureBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).BeginInit();
            this.cmsManagePerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbManagePeopleForm)).BeginInit();
            this.SuspendLayout();
            // 
            // ManagePeopleTitle
            // 
            this.ManagePeopleTitle.AutoSize = true;
            this.ManagePeopleTitle.Font = new System.Drawing.Font("Palatino Linotype", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManagePeopleTitle.ForeColor = System.Drawing.Color.Blue;
            this.ManagePeopleTitle.Location = new System.Drawing.Point(340, 195);
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
            this.dgvAllPeople.ContextMenuStrip = this.cmsManagePerson;
            this.dgvAllPeople.Location = new System.Drawing.Point(5, 298);
            this.dgvAllPeople.Name = "dgvAllPeople";
            this.dgvAllPeople.ReadOnly = true;
            this.dgvAllPeople.Size = new System.Drawing.Size(922, 295);
            this.dgvAllPeople.TabIndex = 2;
            // 
            // cmsManagePerson
            // 
            this.cmsManagePerson.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.tsmShowDetails,
            this.toolStripMenuItem1,
            this.tsmDeletePerson,
            this.tsmEditPerson,
            this.tsmAddNewPerson,
            this.toolStripMenuItem3});
            this.cmsManagePerson.Name = "contextMenuStrip1";
            this.cmsManagePerson.Size = new System.Drawing.Size(181, 132);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmShowDetails
            // 
            this.tsmShowDetails.Image = global::DVLD_UI.Properties.Resources.show_details;
            this.tsmShowDetails.Name = "tsmShowDetails";
            this.tsmShowDetails.Size = new System.Drawing.Size(180, 22);
            this.tsmShowDetails.Text = "Show Details";
            this.tsmShowDetails.Click += new System.EventHandler(this.tsmShowDetails_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmDeletePerson
            // 
            this.tsmDeletePerson.Image = global::DVLD_UI.Properties.Resources.delete;
            this.tsmDeletePerson.Name = "tsmDeletePerson";
            this.tsmDeletePerson.Size = new System.Drawing.Size(180, 22);
            this.tsmDeletePerson.Text = "Delete Person";
            this.tsmDeletePerson.Click += new System.EventHandler(this.tsmDeletePerson_Click);
            // 
            // tsmEditPerson
            // 
            this.tsmEditPerson.Image = global::DVLD_UI.Properties.Resources.update;
            this.tsmEditPerson.Name = "tsmEditPerson";
            this.tsmEditPerson.Size = new System.Drawing.Size(180, 22);
            this.tsmEditPerson.Text = "Edit Info";
            this.tsmEditPerson.Click += new System.EventHandler(this.tsmEditPerson_Click);
            // 
            // tsmAddNewPerson
            // 
            this.tsmAddNewPerson.Image = global::DVLD_UI.Properties.Resources.Addnew;
            this.tsmAddNewPerson.Name = "tsmAddNewPerson";
            this.tsmAddNewPerson.Size = new System.Drawing.Size(180, 22);
            this.tsmAddNewPerson.Text = "Add New Person";
            this.tsmAddNewPerson.Click += new System.EventHandler(this.tsmAddNewPerson_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
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
            "None",
            "Person ID",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "National No",
            "Gendor",
            "Phone",
            "Email"});
            this.cbSortBy.Location = new System.Drawing.Point(90, 259);
            this.cbSortBy.Name = "cbSortBy";
            this.cbSortBy.Size = new System.Drawing.Size(204, 21);
            this.cbSortBy.TabIndex = 4;
            this.cbSortBy.SelectedIndexChanged += new System.EventHandler(this.cbSortBy_SelectedIndexChanged);
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
            this.pbManagePeopleForm.Location = new System.Drawing.Point(309, 40);
            this.pbManagePeopleForm.Name = "pbManagePeopleForm";
            this.pbManagePeopleForm.Size = new System.Drawing.Size(278, 139);
            this.pbManagePeopleForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbManagePeopleForm.TabIndex = 0;
            this.pbManagePeopleForm.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(309, 259);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(185, 20);
            this.txtFilter.TabIndex = 6;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(939, 620);
            this.Controls.Add(this.txtFilter);
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
            this.cmsManagePerson.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip cmsManagePerson;
        private System.Windows.Forms.ToolStripMenuItem tsmShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmDeletePerson;
        private System.Windows.Forms.ToolStripMenuItem tsmEditPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmAddNewPerson;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.TextBox txtFilter;
    }
}