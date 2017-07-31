namespace Prescription_Assistance
{
    partial class Alert
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblText = new System.Windows.Forms.Label();
            this.lblBed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.Black;
            this.lblText.Location = new System.Drawing.Point(11, 43);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(196, 22);
            this.lblText.TabIndex = 16;
            this.lblText.Text = "Request for Wheelchair";
            // 
            // lblBed
            // 
            this.lblBed.AutoSize = true;
            this.lblBed.BackColor = System.Drawing.Color.Transparent;
            this.lblBed.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBed.ForeColor = System.Drawing.Color.Black;
            this.lblBed.Location = new System.Drawing.Point(11, 10);
            this.lblBed.Name = "lblBed";
            this.lblBed.Size = new System.Drawing.Size(82, 33);
            this.lblBed.TabIndex = 15;
            this.lblBed.Text = "200-A";
            // 
            // Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblBed);
            this.Name = "Alert";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(250, 75);
            this.Load += new System.EventHandler(this.Alert_Load);
            this.Click += new System.EventHandler(this.Alert_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblBed;
    }
}
