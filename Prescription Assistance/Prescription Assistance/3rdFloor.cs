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
    public partial class _3rdFloor : UserControl
    {
        Class_Rooms cr = new Class_Rooms();
        DataSet ds = new DataSet();
        Nurse_Dashboard n;

        public _3rdFloor(Nurse_Dashboard n)
        {
            InitializeComponent();
            this.n = n;
        }

        private void showDialog(string bed)
        {
            AssignRoomPatient ar = new AssignRoomPatient(bed, n, "3rd Floor");
            ar.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showDialog("300-A");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showDialog("300-B");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showDialog("300-C");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showDialog("300-D");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showDialog("300-E");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showDialog("300-F");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showDialog("300-G");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showDialog("300-H");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showDialog("301");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showDialog("302");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            showDialog("303");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            showDialog("304");
        }

        public void refresh()
        {
            cr.Bed_id = "300-A";
            ds = cr.viewBedandPatient();
            labelA.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-B";
            ds = cr.viewBedandPatient();
            labelB.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-C";
            ds = cr.viewBedandPatient();
            labelC.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-D";
            ds = cr.viewBedandPatient();
            labelD.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-E";
            ds = cr.viewBedandPatient();
            labelE.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-F";
            ds = cr.viewBedandPatient();
            labelF.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-G";
            ds = cr.viewBedandPatient();
            labelG.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-H";
            ds = cr.viewBedandPatient();
            labelH.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "301";
            ds = cr.viewBedandPatient();
            label1.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "302";
            ds = cr.viewBedandPatient();
            label2.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "303";
            ds = cr.viewBedandPatient();
            label3.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "304";
            ds = cr.viewBedandPatient();
            label4.Text = ds.Tables[0].Rows[0][3].ToString();
        }

        private void _3rdFloor_Load(object sender, EventArgs e)
        {
            refresh();            
        }
    }
}
