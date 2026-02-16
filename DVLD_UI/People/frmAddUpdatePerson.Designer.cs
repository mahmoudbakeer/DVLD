namespace DVLD_UI
{
    partial class frmAddUpdatePerson
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
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.ctrlAddUpdatePersonInfo1 = new DVLD_UI.ctrlAddUpdatePersonInfo();
            this.SuspendLayout();
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.Red;
            this.lblMainTitle.Location = new System.Drawing.Point(298, 78);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(239, 32);
            this.lblMainTitle.TabIndex = 1;
            this.lblMainTitle.Text = "ADD NEW PEROSN";
            // 
            // ctrlAddUpdatePersonInfo1
            // 
            this.ctrlAddUpdatePersonInfo1.Location = new System.Drawing.Point(-1, 144);
            this.ctrlAddUpdatePersonInfo1.Name = "ctrlAddUpdatePersonInfo1";
            this.ctrlAddUpdatePersonInfo1.PersonID = -1;
            this.ctrlAddUpdatePersonInfo1.Size = new System.Drawing.Size(832, 427);
            this.ctrlAddUpdatePersonInfo1.TabIndex = 0;
            // 
            // frmAddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 576);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.ctrlAddUpdatePersonInfo1);
            this.Name = "frmAddUpdatePerson";
            this.Text = "frmAddNewUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlAddUpdatePersonInfo ctrlAddUpdatePersonInfo1;
        private System.Windows.Forms.Label lblMainTitle;
    }
}