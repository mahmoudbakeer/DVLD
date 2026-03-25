namespace DVLD_UI.Drivers
{
    partial class frmListDrivers
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
            this.MainDriversTitle = new System.Windows.Forms.Label();
            this.dgvAllDrivers = new System.Windows.Forms.DataGridView();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cbSortBy = new System.Windows.Forms.ComboBox();
            this.pbManagePeopleForm = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllDrivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManagePeopleForm)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainDriversTitle
            // 
            this.MainDriversTitle.AutoSize = true;
            this.MainDriversTitle.Font = new System.Drawing.Font("Palatino Linotype", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainDriversTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainDriversTitle.Location = new System.Drawing.Point(406, 171);
            this.MainDriversTitle.Name = "MainDriversTitle";
            this.MainDriversTitle.Size = new System.Drawing.Size(187, 43);
            this.MainDriversTitle.TabIndex = 8;
            this.MainDriversTitle.Text = "List Drivers";
            // 
            // dgvAllDrivers
            // 
            this.dgvAllDrivers.AllowUserToAddRows = false;
            this.dgvAllDrivers.AllowUserToDeleteRows = false;
            this.dgvAllDrivers.AllowUserToOrderColumns = true;
            this.dgvAllDrivers.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dgvAllDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllDrivers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllDrivers.Location = new System.Drawing.Point(53, 277);
            this.dgvAllDrivers.Name = "dgvAllDrivers";
            this.dgvAllDrivers.ReadOnly = true;
            this.dgvAllDrivers.Size = new System.Drawing.Size(922, 295);
            this.dgvAllDrivers.TabIndex = 9;
            this.dgvAllDrivers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllDrivers_CellContentClick);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(298, 239);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(185, 20);
            this.txtFilter.TabIndex = 12;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cbSortBy
            // 
            this.cbSortBy.BackColor = System.Drawing.Color.Silver;
            this.cbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSortBy.FormattingEnabled = true;
            this.cbSortBy.Items.AddRange(new object[] {
            "None",
            "Driver ID",
            "Person ID",
            "Name",
            "National No"});
            this.cbSortBy.Location = new System.Drawing.Point(78, 238);
            this.cbSortBy.Name = "cbSortBy";
            this.cbSortBy.Size = new System.Drawing.Size(204, 21);
            this.cbSortBy.TabIndex = 11;
            // 
            // pbManagePeopleForm
            // 
            this.pbManagePeopleForm.Image = global::DVLD_UI.Properties.Resources.driverNew;
            this.pbManagePeopleForm.Location = new System.Drawing.Point(357, 19);
            this.pbManagePeopleForm.Name = "pbManagePeopleForm";
            this.pbManagePeopleForm.Size = new System.Drawing.Size(278, 139);
            this.pbManagePeopleForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbManagePeopleForm.TabIndex = 7;
            this.pbManagePeopleForm.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.BurlyWood;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(863, 581);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 13;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonLicenseHistoryToolStripMenuItem,
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(226, 70);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.History;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.show_details;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.showLicenseInfoToolStripMenuItem.Text = "Show Person Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // frmListDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1029, 627);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cbSortBy);
            this.Controls.Add(this.dgvAllDrivers);
            this.Controls.Add(this.MainDriversTitle);
            this.Controls.Add(this.pbManagePeopleForm);
            this.Name = "frmListDrivers";
            this.Text = "frmListDrivers";
            this.Load += new System.EventHandler(this.frmListDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllDrivers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManagePeopleForm)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbManagePeopleForm;
        private System.Windows.Forms.Label MainDriversTitle;
        private System.Windows.Forms.DataGridView dgvAllDrivers;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cbSortBy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}