namespace DVLD_UI
{
    partial class frmUpdatePersonInfo
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
            this.ctrlUpdatePersonInfo1 = new DVLD_UI.ctrlUpdatePersonInfo();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlUpdatePersonInfo1
            // 
            this.ctrlUpdatePersonInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ctrlUpdatePersonInfo1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctrlUpdatePersonInfo1.Location = new System.Drawing.Point(1, 1);
            this.ctrlUpdatePersonInfo1.Name = "ctrlUpdatePersonInfo1";
            this.ctrlUpdatePersonInfo1.Size = new System.Drawing.Size(900, 600);
            this.ctrlUpdatePersonInfo1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(380, 635);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 40);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "💾Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmUpdatePersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 685);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ctrlUpdatePersonInfo1);
            this.Name = "frmUpdatePersonInfo";
            this.Text = "frmUpdatePersonInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlUpdatePersonInfo ctrlUpdatePersonInfo1;
        private System.Windows.Forms.Button btnCancel;
    }
}