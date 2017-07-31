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
    public partial class Alert : UserControl
    {
        Class_Alert ca = new Class_Alert();
        Class_Prescription cp = new Class_Prescription();
        DataSet ds = new DataSet();
        Room_Layout r;
        string id, type, bed, info, status, timefordisplay, timeforsms, ondisplay;

        public Alert(string id, string type, string bed, string info, string status, 
        string timefordisplay, string timeforsms, string ondisplay, Room_Layout r)
        {
            InitializeComponent();

            this.id = id;
            this.type = type;
            this.bed = bed;
            this.info = info;
            this.status = status;
            this.timefordisplay = timefordisplay;
            this.timeforsms = timeforsms;
            this.ondisplay = ondisplay;

            this.r = r;
            
            ca.Alert_id = id;
            ca.Type = type;
            ca.Bed_id = bed;
            ca.Info_id = info;
            ca.Status = status; 
            ca.Timefordisplay = timefordisplay;
            ca.Timeforsms = timeforsms;
            ca.Ondisplay = ondisplay;         
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            if (type.Equals("A"))
            {
                //assistance
                this.BackColor = Color.DarkOrange;
                lblBed.ForeColor = Color.White;
                lblText.ForeColor = Color.White;

                lblBed.Text = bed;
                lblText.Text = info;
            }
            else if (type.Equals("V"))
            {
                //vital
                this.BackColor = Color.Gold;
                lblBed.ForeColor = Color.Black;
                lblText.ForeColor = Color.Black;

                lblBed.Text = bed;
                lblText.Text = "Vital Check for " + info;
            }
            else
            {
                //prescription
                this.BackColor = Color.SteelBlue;
                lblBed.ForeColor = Color.White;
                lblText.ForeColor = Color.White;

                cp.Prescription_id = info;
                ds = cp.viewSpecificPrescription();

                lblBed.Text = bed;
                lblText.Text = "Medicine for " + ds.Tables[0].Rows[0][7].ToString();
            }

            if (Form1.usertype.Equals("Doctor"))
            {
                this.Enabled = false;
                this.Click -= new EventHandler(Alert_Click);
            }
            else
            {
                this.Enabled = true;
                this.Click += new EventHandler(Alert_Click);
            }
        }

        private void Alert_Click(object sender, EventArgs e)
        {
            if (type.Equals("A"))
            {
                //assistance
                ca.Status = "Done";

                this.Enabled = false;
                this.Visible = false;
                this.Parent.Refresh();
                this.Parent.Controls.Remove(this);

                ca.Status = "Done";
                ca.Ondisplay = "false";
                ca.updateAlert();

                Alert_Details ad = new Alert_Details(info, bed, "A");
                ad.ShowDialog();

                r.stopBlink(bed);              
            }
            else if (type.Equals("V"))
            {
                //vital
                ca.Status = "Doing";
                ca.Ondisplay = "false";
                ca.updateAlert();

                this.Enabled = false;
                this.Visible = false;
                this.Parent.Refresh();
                this.Parent.Controls.Remove(this);

                r.stopBlink(bed); 
                Insert_MedRecord im = new Insert_MedRecord(id, type, bed, info, status, timefordisplay, timeforsms, ondisplay);
                im.ShowDialog();             
            }
            else
            {
                //prescription                
                cp.Prescription_id = info;

                this.Enabled = false;
                this.Visible = false;
                this.Parent.Refresh();
                this.Parent.Controls.Remove(this);

                ca.Status = "Done";
                ca.Ondisplay = "false";
                ca.updateAlert();

                Alert_Details ad = new Alert_Details(info, bed, "P");
                ad.ShowDialog();

                r.stopBlink(bed);
            }
        }
    }
}
