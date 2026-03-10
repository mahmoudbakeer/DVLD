namespace DVLD_UI.Applications
{
    partial class frmManageApplicationTypes
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
            this.dgvApplicationTypes = new System.Windows.Forms.DataGridView();
            this.cmsManageApplictionTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).BeginInit();
            this.cmsManageApplictionTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvApplicationTypes
            // 
            this.dgvApplicationTypes.AllowUserToAddRows = false;
            this.dgvApplicationTypes.AllowUserToDeleteRows = false;
            this.dgvApplicationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationTypes.ContextMenuStrip = this.cmsManageApplictionTypes;
            this.dgvApplicationTypes.Location = new System.Drawing.Point(1, 254);
            this.dgvApplicationTypes.Name = "dgvApplicationTypes";
            this.dgvApplicationTypes.ReadOnly = true;
            this.dgvApplicationTypes.Size = new System.Drawing.Size(815, 239);
            this.dgvApplicationTypes.TabIndex = 0;
            // 
            // cmsManageApplictionTypes
            // 
            this.cmsManageApplictionTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationDetailsToolStripMenuItem});
            this.cmsManageApplictionTypes.Name = "cmsManageApplictionTypes";
            this.cmsManageApplictionTypes.Size = new System.Drawing.Size(197, 26);
            // 
            // editApplicationDetailsToolStripMenuItem
            // 
            this.editApplicationDetailsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.ManageApllications1;
            this.editApplicationDetailsToolStripMenuItem.Name = "editApplicationDetailsToolStripMenuItem";
            this.editApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.editApplicationDetailsToolStripMenuItem.Text = "Edit Application Details";
            this.editApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.editApplicationDetailsToolStripMenuItem_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblMainTitle.Location = new System.Drawing.Point(225, 21);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(347, 31);
            this.lblMainTitle.TabIndex = 1;
            this.lblMainTitle.Text = "Manage Applications Types";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.ManageApllications1;
            this.pictureBox1.Location = new System.Drawing.Point(262, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(816, 544);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.dgvApplicationTypes);
            this.Name = "frmManageApplicationTypes";
            this.Text = "frmManageApplicationTypes";
            this.Load += new System.EventHandler(this.frmManageApplicationTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).EndInit();
            this.cmsManageApplictionTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvApplicationTypes;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsManageApplictionTypes;
        private System.Windows.Forms.ToolStripMenuItem editApplicationDetailsToolStripMenuItem;
    }
}