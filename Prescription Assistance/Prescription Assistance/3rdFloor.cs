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

        public _3rdFloor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("300-A");
            ar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("300-B");
            ar.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("300-C");
            ar.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("300-D");
            ar.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("300-E");
            ar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("300-F");
            ar.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("300-G");
            ar.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("300-H");
            ar.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("301");
            ar.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("302");
            ar.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("303");
            ar.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("304");
            ar.ShowDialog();
        }


        private void _3rdFloor_Load(object sender, EventArgs e)
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
    }
}
