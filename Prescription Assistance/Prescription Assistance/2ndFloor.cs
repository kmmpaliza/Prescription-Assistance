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

        private void button1_Click_1(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("200-A");
            ar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("200-B");
            ar.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("200-C");
            ar.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("200-D");
            ar.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("200-E");
            ar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("200-F");
            ar.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("200-G");
            ar.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("200-H");
            ar.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("201");
            ar.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("202");
            ar.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AssignRoomPatient ar = new AssignRoomPatient("203");
            ar.ShowDialog();
        }
    }
}
