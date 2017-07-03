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
    public partial class Patient_Dashboard : Form
    {
        Class_Alert ca = new Class_Alert();
        Room_Layout rl = new Room_Layout();

        public Patient_Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Ward";
            ca.Status = "Undone";
            //ca.insertAlert();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Private";
            ca.Status = "Undone";
            //ca.insertAlert();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Room Transfer";
            ca.Status = "Undone";
            //ca.insertAlert();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Medical Consultation";
            ca.Status = "Undone";
            //ca.insertAlert();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Check Medical Status";
            ca.Status = "Undone";
            //ca.insertAlert();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Request for Wheelchair";
            ca.Status = "Undone";
            //ca.insertAlert();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Request for Shuttle";
            ca.Status = "Undone";
            //ca.insertAlert();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Room Maintenance";
            ca.Status = "Undone";
            //ca.insertAlert();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Main f = new Main();
            f.Show();
            this.Close();
        }
    }
}
