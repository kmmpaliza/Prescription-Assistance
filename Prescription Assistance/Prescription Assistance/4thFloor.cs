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
    public partial class _4thFloor : UserControl
    {
        Class_Rooms cr = new Class_Rooms();
        DataSet ds = new DataSet();

        public _4thFloor()
        {
            InitializeComponent();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            cr.Bed_id = "400-A";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "400-B";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "400-C";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "400-D";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "400-E";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "400-F";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "400-G";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "400-H";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "401";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "402";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "403";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "404";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: " + ds.Tables[0].Rows[0][0].ToString() + "\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }
    }
}
