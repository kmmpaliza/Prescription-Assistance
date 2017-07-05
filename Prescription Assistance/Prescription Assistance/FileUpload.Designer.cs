namespace Prescription_Assistance
{
    partial class FileUpload
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtfilename = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(126, 15);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(245, 20);
            this.txtFile.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtfilename
            // 
            this.txtfilename.Location = new System.Drawing.Point(127, 76);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.Size = new System.Drawing.Size(245, 20);
            this.txtfilename.TabIndex = 3;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(127, 42);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(100, 20);
            this.txtid.TabIndex = 4;
            // 
            // FileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 124);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtfilename);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.button1);
            this.Name = "FileUpload";
            this.Text = "FileUpload";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtfilename;
        private System.Windows.Forms.TextBox txtid;
    }
}