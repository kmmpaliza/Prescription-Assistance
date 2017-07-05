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
        Nurse_Dashboard n;

        public _4thFloor(Nurse_Dashboard n)
        {
            InitializeComponent();
            this.n = n;
        }

        private void showDialog(string bed)
        {
            AssignRoomPatient ar = new AssignRoomPatient(bed, n, "4th Floor");
            ar.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            showDialog("400-A");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showDialog("400-B");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showDialog("400-C");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showDialog("400-D");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showDialog("400-E");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showDialog("400-F");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showDialog("400-G");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showDialog("400-H");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showDialog("401");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showDialog("402");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            showDialog("403");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            showDialog("404");
        }

        public void refresh()
        {
            cr.Bed_id = "400-A";
            ds = cr.viewBedandPatient();
            labelA.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "400-B";
            ds = cr.viewBedandPatient();
            labelB.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "400-C";
            ds = cr.viewBedandPatient();
            labelC.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "400-D";
            ds = cr.viewBedandPatient();
            labelD.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "400-E";
            ds = cr.viewBedandPatient();
            labelE.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "400-F";
            ds = cr.viewBedandPatient();
            labelF.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "400-G";
            ds = cr.viewBedandPatient();
            labelG.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "400-H";
            ds = cr.viewBedandPatient();
            labelH.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "401";
            ds = cr.viewBedandPatient();
            label1.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "402";
            ds = cr.viewBedandPatient();
            label2.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "403";
            ds = cr.viewBedandPatient();
            label3.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "404";
            ds = cr.viewBedandPatient();
            label4.Text = ds.Tables[0].Rows[0][3].ToString();
        }

        private void _4thFloor_Load(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
