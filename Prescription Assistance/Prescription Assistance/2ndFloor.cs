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
    public partial class _2ndFloorPrivateRoomD : UserControl
    {
        Class_Rooms cr = new Class_Rooms();
        DataSet ds = new DataSet();
        Nurse_Dashboard n;

        public _2ndFloorPrivateRoomD(Nurse_Dashboard n)
        {
            InitializeComponent();
            this.n = n;
            
        }

        public void refresh()
        {
            cr.Bed_id = "200-A";
            ds = cr.viewBedandPatient();
            labelA.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "200-B";
            ds = cr.viewBedandPatient();
            labelB.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "200-C";
            ds = cr.viewBedandPatient();
            labelC.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "200-D";
            ds = cr.viewBedandPatient();
            labelD.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "200-E";
            ds = cr.viewBedandPatient();
            labelE.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "200-F";
            ds = cr.viewBedandPatient();
            labelF.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "200-G";
            ds = cr.viewBedandPatient();
            labelG.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "200-H";
            ds = cr.viewBedandPatient();
            labelH.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "201";
            ds = cr.viewBedandPatient();
            label1.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "202";
            ds = cr.viewBedandPatient();
            label2.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "203";
            ds = cr.viewBedandPatient();
            label3.Text = ds.Tables[0].Rows[0][3].ToString();
        }

        public void _2ndFloorPrivateRoom_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void showDialog(string bed)
        {
            AssignRoomPatient ar = new AssignRoomPatient(bed, n, "2nd Floor");
            ar.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showDialog("200-A");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showDialog("200-B");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showDialog("200-C");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showDialog("200-D");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showDialog("200-E");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showDialog("200-F");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showDialog("200-G");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showDialog("200-H");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            showDialog("201");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            showDialog("202");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            showDialog("203");
        }
    }
}
