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
    public partial class _2ndFloorPrivateRoom : UserControl
    {
        Class_Rooms cr = new Class_Rooms();
        DataSet ds = new DataSet();

        public _2ndFloorPrivateRoom()
        {
            InitializeComponent();
            
        }

        private void _2ndFloorPrivateRoom_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cr.Bed_id = "200-A";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 200-A\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "200-B";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 200-B\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "200-C";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 200-C\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "200-D";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 200-D\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "200-E";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 200-E\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "200-F";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 200-F\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "200-G";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 200-G\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "200-H";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 200-H\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "201";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 201\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "202";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 202\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            cr.Bed_id = "203";
            ds = cr.viewBedandPatient();
            MessageBox.Show("Bed: 203\nRoom Type: " + ds.Tables[0].Rows[0]["Room"].ToString() + "\nStatus: " + ds.Tables[0].Rows[0]["Status"].ToString() + "\nPatient: " +
                    ds.Tables[0].Rows[0][3].ToString() + "");
        }
    }
}
