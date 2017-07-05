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

            this.WindowState = FormWindowState.Maximized;
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
            buttonA.Text = "" + init + "-A";
            buttonB.Text = "" + init + "-B";
            buttonC.Text = "" + init + "-C";
            buttonD.Text = "" + init + "-D";
            buttonE.Text = "" + init + "-E";
            buttonF.Text = "" + init + "-F";
            buttonG.Text = "" + init + "-G";
            buttonH.Text = "" + init + "-H";

            cr.Bed_id = buttonA.Text;
            ds = cr.viewBedandPatient();
            labelA.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = buttonB.Text;
            ds = cr.viewBedandPatient();
            labelB.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = buttonC.Text;
            ds = cr.viewBedandPatient();
            labelC.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = buttonD.Text;
            ds = cr.viewBedandPatient();
            labelD.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = buttonE.Text;
            ds = cr.viewBedandPatient();
            labelE.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = buttonF.Text;
            ds = cr.viewBedandPatient();
            labelF.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = buttonG.Text;
            ds = cr.viewBedandPatient();
            labelG.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = buttonH.Text;
            ds = cr.viewBedandPatient();
            labelH.Text = ds.Tables[0].Rows[0][3].ToString();
            
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(buttonA.Text);          
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(buttonB.Text);   
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(buttonC.Text);   
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(buttonD.Text);   
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(buttonE.Text);   
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(buttonF.Text);   
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(buttonH.Text);   
        }

        private void buttonH_Click(object sender, EventArgs e)
        {
            directtoPatientDashboard(buttonG.Text);   
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
    }
}
