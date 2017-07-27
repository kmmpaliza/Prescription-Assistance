using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Prescription_Assistance
{
    public partial class Alert_Assistance : UserControl
    {
        Class_Alert ca = new Class_Alert();
        string alertid, bed, assistance, status;
        public Alert_Assistance(string alertid, string bed, string assistance, string status)
        {
            InitializeComponent();
            this.alertid = alertid;
            this.bed = bed;
            this.assistance = assistance;
            this.status = status;
        }

        private void Alert_Assistance_Load(object sender, EventArgs e)
        {
            label1.Text = bed;
            label2.Text = assistance;
        }

        private void Alert_Assistance_Click(object sender, EventArgs e)
        {
            ca.Alert_id = alertid;
            ca.Bed_id = bed;
            ca.Assistance = assistance;
            ca.Status = "Done";
            ca.updateAlertStatus();

            this.Enabled = false;
            this.Visible = false;
            this.Parent.Refresh();
            this.Parent.Controls.Remove(this); 
        } 
    }
}
