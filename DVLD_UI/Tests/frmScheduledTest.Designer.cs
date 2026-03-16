namespace DVLD_UI.Tests
{
    partial class frmScheduledTest
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
            this.ctrlTestTypeInfo1 = new DVLD_UI.Tests.Controllers.ctrlTestTypeInfo();
            this.label22 = new System.Windows.Forms.Label();
            this.rbtnPass = new System.Windows.Forms.RadioButton();
            this.rbtnFail = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlTestTypeInfo1
            // 
            this.ctrlTestTypeInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlTestTypeInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlTestTypeInfo1.Name = "ctrlTestTypeInfo1";
            this.ctrlTestTypeInfo1.Size = new System.Drawing.Size(500, 568);
            this.ctrlTestTypeInfo1.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(12, 613);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 25);
            this.label22.TabIndex = 1;
            this.label22.Text = "Result : ";
            // 
            // rbtnPass
            // 
            this.rbtnPass.AutoSize = true;
            this.rbtnPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPass.Location = new System.Drawing.Point(128, 618);
            this.rbtnPass.Name = "rbtnPass";
            this.rbtnPass.Size = new System.Drawing.Size(56, 20);
            this.rbtnPass.TabIndex = 2;
            this.rbtnPass.Text = "Pass";
            this.rbtnPass.UseVisualStyleBackColor = true;
            // 
            // rbtnFail
            // 
            this.rbtnFail.AutoSize = true;
            this.rbtnFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFail.Location = new System.Drawing.Point(217, 618);
            this.rbtnFail.Name = "rbtnFail";
            this.rbtnFail.Size = new System.Drawing.Size(47, 20);
            this.rbtnFail.TabIndex = 3;
            this.rbtnFail.Text = "Fail";
            this.rbtnFail.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 678);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 97);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 678);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Notes : ";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Violet;
            this.btnCancel.Location = new System.Drawing.Point(128, 795);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Violet;
            this.btnSave.Location = new System.Drawing.Point(288, 795);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmScheduledTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(533, 835);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rbtnFail);
            this.Controls.Add(this.rbtnPass);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.ctrlTestTypeInfo1);
            this.Name = "frmScheduledTest";
            this.Text = "frmScheduledTest";
            this.Load += new System.EventHandler(this.frmScheduledTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controllers.ctrlTestTypeInfo ctrlTestTypeInfo1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton rbtnPass;
        private System.Windows.Forms.RadioButton rbtnFail;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}