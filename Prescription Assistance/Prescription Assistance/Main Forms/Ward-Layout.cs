using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Prescription_Assistance
{
    public partial class Ward_Layout : Form
    {
        string floor;
        Class_Rooms cr = new Class_Rooms();
        DataSet ds = new DataSet();

        public Ward_Layout(string floor)
        {
            InitializeComponent();
            this.floor = floor;
        }

        private void Ward_Layout_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            switch (floor)
            {
                case "Intensive Care Unit":
                    setButtons("ICU");
                    break;
                case "Open Recovery":
                    setButtons("ORE");
                    pbC.Enabled = false;
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbC.Image = Properties.Resources.images;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblC.Visible = false;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "301":
                    setButtons("301");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "302":
                    setButtons("302");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "303":
                    setButtons("303");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "304":
                    setButtons("304");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "305":
                    setButtons("305");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "306":
                    setButtons("306");
                    pbC.Enabled = false;
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbC.Image = Properties.Resources.images;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblC.Visible = false;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "307":
                    setButtons("307");
                    pbF.Enabled = false;
                    pbF.Image = Properties.Resources.images;
                    lblF.Visible = false;
                    break;
                case "308":
                    setButtons("308");
                    pbF.Enabled = false;
                    pbF.Image = Properties.Resources.images;
                    lblF.Visible = false;
                    break;
                case "309":
                    setButtons("309");
                    pbF.Enabled = false;
                    pbF.Image = Properties.Resources.images;
                    lblF.Visible = false;
                    break;
                case "Female Ward 1":
                    setButtons("FW1");
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "Female Ward 2":
                    setButtons("FW2");
                    pbF.Enabled = false;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "Pediatric Ward":
                    setButtons("PED");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "401":
                    setButtons("401");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "402":
                    setButtons("402");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "403":
                    setButtons("403");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "404":
                    setButtons("404");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "405":
                    setButtons("405");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "406":
                    setButtons("406");
                    pbC.Enabled = false;
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbC.Image = Properties.Resources.images;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblC.Visible = false;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "407":
                    setButtons("407");
                    pbF.Enabled = false;
                    pbF.Image = Properties.Resources.images;
                    lblF.Visible = false;
                    break;
                case "408":
                    setButtons("408");
                    pbF.Enabled = false;
                    pbF.Image = Properties.Resources.images;
                    lblF.Visible = false;
                    break;
                case "409":
                    setButtons("409");
                    pbF.Enabled = false;
                    pbF.Image = Properties.Resources.images;
                    lblF.Visible = false;   
                    break;
                case "501":
                    setButtons("501");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "502":
                    setButtons("502");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "503":
                    setButtons("503");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "504":
                    setButtons("504");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "505":
                    setButtons("505");
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "506":
                    setButtons("506");
                    pbC.Enabled = false;
                    pbD.Enabled = false;
                    pbE.Enabled = false;
                    pbF.Enabled = false;
                    pbC.Image = Properties.Resources.images;
                    pbD.Image = Properties.Resources.images;
                    pbE.Image = Properties.Resources.images;
                    pbF.Image = Properties.Resources.images;
                    lblC.Visible = false;
                    lblD.Visible = false;
                    lblE.Visible = false;
                    lblF.Visible = false;
                    break;
                case "507":
                    setButtons("507");
                    pbF.Enabled = false;
                    pbF.Image = Properties.Resources.images;
                    lblF.Visible = false;
                    break;
                case "508":
                    setButtons("508");
                    pbF.Enabled = false;
                    pbF.Image = Properties.Resources.images;
                    lblF.Visible = false;
                    break;
                case "509":
                    setButtons("509");
                    pbF.Enabled = false;
                    pbF.Image = Properties.Resources.images;
                    lblF.Visible = false;
                    break;
            }
        }

        private void setButtons(string init)
        {
            lblA.Text = "" + init + "-A";
            lblB.Text = "" + init + "-B";
            lblC.Text = "" + init + "-C";
            lblD.Text = "" + init + "-D";
            lblE.Text = "" + init + "-E";
            lblF.Text = "" + init + "-F";

            cr.Bed_id = lblA.Text;
            ds = cr.viewBedandPatient();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][3] == DBNull.Value)
                {
                    labelA.Text = "";
                    pbA.Enabled = false;
                }
                else
                {
                    labelA.Text = ds.Tables[0].Rows[0][3].ToString();
                }
            }
            else {}

            cr.Bed_id = lblB.Text;
            ds = cr.viewBedandPatient();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][3] == DBNull.Value)
                {
                    labelB.Text = "";
                    pbB.Enabled = false;
                }
                else
                {
                    labelB.Text = ds.Tables[0].Rows[0][3].ToString();
                }
            }
            else {}

            cr.Bed_id = lblC.Text;
            ds = cr.viewBedandPatient();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][3] == DBNull.Value)
                {
                    labelC.Text = "";
                    pbC.Enabled = false;
                }
                else
                {
                    labelC.Text = ds.Tables[0].Rows[0][3].ToString();
                }
            }
            else {}

            cr.Bed_id = lblD.Text;
            ds = cr.viewBedandPatient();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][3] == DBNull.Value)
                {
                    labelD.Text = "";
                    pbD.Enabled = false;
                }
                else
                {
                    labelD.Text = ds.Tables[0].Rows[0][3].ToString();
                }
            }
            else {}

            cr.Bed_id = lblE.Text;
            ds = cr.viewBedandPatient();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][3] == DBNull.Value)
                {
                    labelE.Text = "";
                    pbE.Enabled = false;
                }
                else
                {
                    labelE.Text = ds.Tables[0].Rows[0][3].ToString();
                }                
            }
            else {}

            cr.Bed_id = lblF.Text;
            ds = cr.viewBedandPatient();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][3] == DBNull.Value)
                {
                    labelF.Text = "";
                    pbF.Enabled = false;
                }
                else
                {
                    labelF.Text = ds.Tables[0].Rows[0][3].ToString();
                }                
            }
            else {}            
        }

        private void directtoPatientDashboard(string bed)
        {
            Patient_Dashboard p = new Patient_Dashboard(bed, floor);
            p.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Room_Type r = new Room_Type();
            r.Show();
            this.Hide();
        }

        private void pbA_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(lblA.Text);
        }

        private void pbB_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(lblB.Text);
        }

        private void pbC_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(lblC.Text);
        }

        private void pbD_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(lblD.Text);
        }

        private void pbE_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(lblE.Text);
        }

        private void pbF_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(lblF.Text);
        }
    }
}
