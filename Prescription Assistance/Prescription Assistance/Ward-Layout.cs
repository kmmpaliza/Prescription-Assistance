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
            //this.TopMost = true;

          //  this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;

            switch (floor)
            {
                case "2nd Floor":
                    setButtons("200");
                    break;
                case "3rd Floor":
                    setButtons("300");
                    break;
                case "4th Floor":
                    setButtons("400");
                    break;
                case "5th Floor":
                    setButtons("500");
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
            lblG.Text = "" + init + "-G";
            lblH.Text = "" + init + "-H";

            cr.Bed_id = lblA.Text;
            ds = cr.viewBedandPatient();
            labelA.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = lblB.Text;
            ds = cr.viewBedandPatient();
            labelB.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = lblC.Text;
            ds = cr.viewBedandPatient();
            labelC.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = lblD.Text;
            ds = cr.viewBedandPatient();
            labelD.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = lblE.Text;
            ds = cr.viewBedandPatient();
            labelE.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = lblF.Text;
            ds = cr.viewBedandPatient();
            labelF.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = lblG.Text;
            ds = cr.viewBedandPatient();
            labelG.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = lblH.Text;
            ds = cr.viewBedandPatient();
            labelH.Text = ds.Tables[0].Rows[0][3].ToString();
            
        }

        private void directtoPatientDashboard(string bed)
        {
            Patient_Dashboard p = new Patient_Dashboard(bed, "ward", floor);
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

        private void pbG_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(lblG.Text);
        }

        private void pbH_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(lblH.Text);
        }
    }
}
