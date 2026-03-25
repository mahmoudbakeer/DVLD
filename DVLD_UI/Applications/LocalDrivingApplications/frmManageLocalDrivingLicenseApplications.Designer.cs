namespace DVLD_UI.Applications.LocalDrivingApplications
{
    partial class frmManageLocalDrivingLicenseApplications
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
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.SortTitle = new System.Windows.Forms.Label();
            this.cbSortBy = new System.Windows.Forms.ComboBox();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.dgvAllLDLAs = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewApplictionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writtenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirsrtTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageLDLATitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pbManageLDLA = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLDLAs)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageLDLA)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(309, 254);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(185, 20);
            this.txtFilter.TabIndex = 13;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // SortTitle
            // 
            this.SortTitle.AutoSize = true;
            this.SortTitle.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortTitle.Location = new System.Drawing.Point(12, 249);
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Size = new System.Drawing.Size(72, 26);
            this.SortTitle.TabIndex = 12;
            this.SortTitle.Text = "Sort By";
            // 
            // cbSortBy
            // 
            this.cbSortBy.BackColor = System.Drawing.Color.Silver;
            this.cbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSortBy.FormattingEnabled = true;
            this.cbSortBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbSortBy.Location = new System.Drawing.Point(90, 254);
            this.cbSortBy.Name = "cbSortBy";
            this.cbSortBy.Size = new System.Drawing.Size(204, 21);
            this.cbSortBy.TabIndex = 11;
            this.cbSortBy.SelectedIndexChanged += new System.EventHandler(this.cbSortBy_SelectedIndexChanged);
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.BackColor = System.Drawing.Color.Sienna;
            this.btnAddNewApplication.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewApplication.ForeColor = System.Drawing.Color.Bisque;
            this.btnAddNewApplication.Location = new System.Drawing.Point(960, 238);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(129, 37);
            this.btnAddNewApplication.TabIndex = 10;
            this.btnAddNewApplication.Text = "AddNew";
            this.btnAddNewApplication.UseVisualStyleBackColor = false;
            this.btnAddNewApplication.TextChanged += new System.EventHandler(this.btnAddNewApplication_Click);
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // dgvAllLDLAs
            // 
            this.dgvAllLDLAs.AllowUserToAddRows = false;
            this.dgvAllLDLAs.AllowUserToDeleteRows = false;
            this.dgvAllLDLAs.AllowUserToOrderColumns = true;
            this.dgvAllLDLAs.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgvAllLDLAs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllLDLAs.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllLDLAs.Location = new System.Drawing.Point(5, 281);
            this.dgvAllLDLAs.Name = "dgvAllLDLAs";
            this.dgvAllLDLAs.ReadOnly = true;
            this.dgvAllLDLAs.Size = new System.Drawing.Size(1084, 275);
            this.dgvAllLDLAs.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationInfoToolStripMenuItem,
            this.addNewApplictionToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.editApplicationInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cancelToolStripMenuItem,
            this.toolStripMenuItem2,
            this.scheduleTestToolStripMenuItem,
            this.issueDrivingLicenseFirsrtTimeToolStripMenuItem,
            this.toolStripMenuItem3,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem4,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(251, 226);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showApplicationInfoToolStripMenuItem
            // 
            this.showApplicationInfoToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.show_details;
            this.showApplicationInfoToolStripMenuItem.Name = "showApplicationInfoToolStripMenuItem";
            this.showApplicationInfoToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.showApplicationInfoToolStripMenuItem.Text = "Show Application Info";
            this.showApplicationInfoToolStripMenuItem.Click += new System.EventHandler(this.tsmShowDetails_Click);
            // 
            // addNewApplictionToolStripMenuItem
            // 
            this.addNewApplictionToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.AddApplication;
            this.addNewApplictionToolStripMenuItem.Name = "addNewApplictionToolStripMenuItem";
            this.addNewApplictionToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.addNewApplictionToolStripMenuItem.Text = "Add New Appliction";
            this.addNewApplictionToolStripMenuItem.Click += new System.EventHandler(this.tsmAddNewLDLA_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.delete;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.tsmDeleteApplication_Click);
            // 
            // editApplicationInfoToolStripMenuItem
            // 
            this.editApplicationInfoToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Editapplication;
            this.editApplicationInfoToolStripMenuItem.Name = "editApplicationInfoToolStripMenuItem";
            this.editApplicationInfoToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.editApplicationInfoToolStripMenuItem.Text = "Edit Application Info";
            this.editApplicationInfoToolStripMenuItem.Click += new System.EventHandler(this.tsmEditApplicaion_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(247, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.cancelled;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.cancelToolStripMenuItem.Text = "Cancel Application";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(247, 6);
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // scheduleTestToolStripMenuItem
            // 
            this.scheduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.writtenTestToolStripMenuItem,
            this.streetTestToolStripMenuItem});
            this.scheduleTestToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.licensing;
            this.scheduleTestToolStripMenuItem.Name = "scheduleTestToolStripMenuItem";
            this.scheduleTestToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.scheduleTestToolStripMenuItem.Text = "Schedule Test";
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.VisionTest;
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.visionTestToolStripMenuItem.Text = "Vision Test";
            this.visionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // writtenTestToolStripMenuItem
            // 
            this.writtenTestToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.WrittenTest;
            this.writtenTestToolStripMenuItem.Name = "writtenTestToolStripMenuItem";
            this.writtenTestToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.writtenTestToolStripMenuItem.Text = "Written Test";
            this.writtenTestToolStripMenuItem.Click += new System.EventHandler(this.writtenTestToolStripMenuItem_Click);
            // 
            // streetTestToolStripMenuItem
            // 
            this.streetTestToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.StreetExam;
            this.streetTestToolStripMenuItem.Name = "streetTestToolStripMenuItem";
            this.streetTestToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.streetTestToolStripMenuItem.Text = "Street Test";
            this.streetTestToolStripMenuItem.Click += new System.EventHandler(this.streetTestToolStripMenuItem_Click);
            // 
            // issueDrivingLicenseFirsrtTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirsrtTimeToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.id_card;
            this.issueDrivingLicenseFirsrtTimeToolStripMenuItem.Name = "issueDrivingLicenseFirsrtTimeToolStripMenuItem";
            this.issueDrivingLicenseFirsrtTimeToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.issueDrivingLicenseFirsrtTimeToolStripMenuItem.Text = "Issue Driving License (Firsrt Time)";
            this.issueDrivingLicenseFirsrtTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirsrtTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(247, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.drivingLicenseNew;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(247, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.History;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // ManageLDLATitle
            // 
            this.ManageLDLATitle.AutoSize = true;
            this.ManageLDLATitle.Font = new System.Drawing.Font("Palatino Linotype", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageLDLATitle.ForeColor = System.Drawing.Color.Beige;
            this.ManageLDLATitle.Location = new System.Drawing.Point(235, 176);
            this.ManageLDLATitle.Name = "ManageLDLATitle";
            this.ManageLDLATitle.Size = new System.Drawing.Size(640, 43);
            this.ManageLDLATitle.TabIndex = 8;
            this.ManageLDLATitle.Text = "Manage Local Driving License Applications";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "New",
            "Complete",
            "Cancelled"});
            this.cbStatus.Location = new System.Drawing.Point(309, 254);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 15;
            this.cbStatus.Visible = false;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Bisque;
            this.button1.Location = new System.Drawing.Point(960, 574);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 37);
            this.button1.TabIndex = 16;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbManageLDLA
            // 
            this.pbManageLDLA.Image = global::DVLD_UI.Properties.Resources.Manage_Applications1;
            this.pbManageLDLA.Location = new System.Drawing.Point(400, 34);
            this.pbManageLDLA.Name = "pbManageLDLA";
            this.pbManageLDLA.Size = new System.Drawing.Size(278, 139);
            this.pbManageLDLA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbManageLDLA.TabIndex = 7;
            this.pbManageLDLA.TabStop = false;
            // 
            // frmManageLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(1101, 614);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.SortTitle);
            this.Controls.Add(this.cbSortBy);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.dgvAllLDLAs);
            this.Controls.Add(this.ManageLDLATitle);
            this.Controls.Add(this.pbManageLDLA);
            this.Name = "frmManageLocalDrivingLicenseApplications";
            this.Text = "frmManageLocalDrivingLicenseApplications";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLDLAs)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageLDLA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label SortTitle;
        private System.Windows.Forms.ComboBox cbSortBy;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.DataGridView dgvAllLDLAs;
        private System.Windows.Forms.Label ManageLDLATitle;
        private System.Windows.Forms.PictureBox pbManageLDLA;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ToolStripMenuItem showApplicationInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewApplictionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writtenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirsrtTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}