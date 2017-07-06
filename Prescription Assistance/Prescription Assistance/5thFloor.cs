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
    public partial class _5thFloor : UserControl
    {
        Class_Rooms cr = new Class_Rooms();
        DataSet ds = new DataSet();
        Nurse_Dashboard n;

        public _5thFloor(Nurse_Dashboard n)
        {
            InitializeComponent();
            this.n = n;
        }

        private void showDialog(string bed)
        {
            AssignRoomPatient ar = new AssignRoomPatient(bed, n, "5th Floor");
            ar.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showDialog("500-A");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showDialog("500-B");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showDialog("500-C");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showDialog("500-D");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showDialog("500-E");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showDialog("500-F");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showDialog("500-G");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showDialog("500-H");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showDialog("501");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showDialog("502");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            showDialog("503");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            showDialog("504");
        }

        public void refresh()
        {
            cr.Bed_id = "500-A";
            ds = cr.viewBedandPatient();
            labelA.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-B";
            ds = cr.viewBedandPatient();
            labelB.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-C";
            ds = cr.viewBedandPatient();
            labelC.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-D";
            ds = cr.viewBedandPatient();
            labelD.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-E";
            ds = cr.viewBedandPatient();
            labelE.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-F";
            ds = cr.viewBedandPatient();
            labelF.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-G";
            ds = cr.viewBedandPatient();
            labelG.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-H";
            ds = cr.viewBedandPatient();
            labelH.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "501";
            ds = cr.viewBedandPatient();
            label1.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "502";
            ds = cr.viewBedandPatient();
            label2.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "503";
            ds = cr.viewBedandPatient();
            label3.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "504";
            ds = cr.viewBedandPatient();
            label4.Text = ds.Tables[0].Rows[0][3].ToString();
        }

        private void _5thFloor_Load(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
