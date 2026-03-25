namespace DVLD_UI.Tests
{
    partial class frmScheduleTest
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
            this.ctrlScheduleTest1 = new DVLD_UI.Tests.Controllers.ctrlScheduleTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlScheduleTest1
            // 
            this.ctrlScheduleTest1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlScheduleTest1.Location = new System.Drawing.Point(41, 12);
            this.ctrlScheduleTest1.Name = "ctrlScheduleTest1";
            this.ctrlScheduleTest1.Size = new System.Drawing.Size(485, 727);
            this.ctrlScheduleTest1.TabIndex = 0;
            this.ctrlScheduleTest1.TestType = DVLD_BusinessLogic.clsTestType.enTestType.Vision;
            this.ctrlScheduleTest1.Load += new System.EventHandler(this.ctrlScheduleTest1_Load);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Wheat;
            this.btnClose.Location = new System.Drawing.Point(316, 691);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(566, 752);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlScheduleTest1);
            this.Name = "frmScheduleTest";
            this.Text = "frmScheduleTest";
            this.Load += new System.EventHandler(this.frmScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.ctrlScheduleTest ctrlScheduleTest1;
        private System.Windows.Forms.Button btnClose;
    }
}