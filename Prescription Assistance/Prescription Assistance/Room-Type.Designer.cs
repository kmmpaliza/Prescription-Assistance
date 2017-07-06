namespace Prescription_Assistance
{
    partial class Room_Type
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cboPrivate = new System.Windows.Forms.ComboBox();
            this.cboWard = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Prescription_Assistance.Properties.Resources.ward;
            this.button2.Location = new System.Drawing.Point(717, 190);
            this.button2.Margin = new System.Windows.Forms.Padding(16);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(8);
            this.button2.Size = new System.Drawing.Size(251, 249);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Prescription_Assistance.Properties.Resources.privateroooom2;
            this.button1.Location = new System.Drawing.Point(395, 190);
            this.button1.Margin = new System.Windows.Forms.Padding(16);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(8);
            this.button1.Size = new System.Drawing.Size(251, 249);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboPrivate
            // 
            this.cboPrivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrivate.FormattingEnabled = true;
            this.cboPrivate.Items.AddRange(new object[] {
            "Select Room..",
            "201",
            "202",
            "203",
            "301",
            "302",
            "303",
            "304",
            "401",
            "402",
            "403",
            "404",
            "501",
            "502",
            "503",
            "504"});
            this.cboPrivate.Location = new System.Drawing.Point(395, 467);
            this.cboPrivate.Name = "cboPrivate";
            this.cboPrivate.Size = new System.Drawing.Size(251, 26);
            this.cboPrivate.TabIndex = 59;
            this.cboPrivate.Visible = false;
            // 
            // cboWard
            // 
            this.cboWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWard.FormattingEnabled = true;
            this.cboWard.Items.AddRange(new object[] {
            "Select Floor..",
            "2nd Floor",
            "3rd Floor",
            "4th Floor",
            "5th Floor"});
            this.cboWard.Location = new System.Drawing.Point(717, 467);
            this.cboWard.Name = "cboWard";
            this.cboWard.Size = new System.Drawing.Size(251, 26);
            this.cboWard.TabIndex = 60;
            this.cboWard.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1140, 25);
            this.button3.Margin = new System.Windows.Forms.Padding(16);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(8);
            this.button3.Size = new System.Drawing.Size(197, 50);
            this.button3.TabIndex = 61;
            this.button3.Text = "Return to Main Page";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Prescription_Assistance.Properties.Resources.logoo2;
            this.pictureBox1.Location = new System.Drawing.Point(25, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Green;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(472, 503);
            this.button4.Margin = new System.Windows.Forms.Padding(16);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(8);
            this.button4.Size = new System.Drawing.Size(96, 50);
            this.button4.TabIndex = 63;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Green;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(794, 503);
            this.button5.Margin = new System.Windows.Forms.Padding(16);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(8);
            this.button5.Size = new System.Drawing.Size(96, 50);
            this.button5.TabIndex = 64;
            this.button5.Text = "OK";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Room_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Prescription_Assistance.Properties.Resources.greenbg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cboWard);
            this.Controls.Add(this.cboPrivate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Room_Type";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iCare";
            this.Load += new System.EventHandler(this.Room_Type_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboPrivate;
        private System.Windows.Forms.ComboBox cboWard;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}