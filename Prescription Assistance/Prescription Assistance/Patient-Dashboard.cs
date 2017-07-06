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
        string bed, room, floor;

        public Patient_Dashboard(string bed, string room, string floor)
        {
            InitializeComponent();
            this.bed = bed;
            ca.Bed_id = bed;
            this.room = room;
            this.floor = floor;
        }

        private void returntoWard()
        {
            switch (floor)
            {
                case "private":
                    break;
                case "ward":
                    Ward_Layout w = new Ward_Layout(floor);
                    w.Show();
                    this.Hide();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Pharmacy";
            ca.Status = "Undone";
            ca.insertAlert();
            returntoWard();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Order Meal";
            ca.Status = "Undone";
            ca.insertAlert();
            returntoWard();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Room Transfer";
            ca.Status = "Undone";
            ca.insertAlert();
            returntoWard();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Medical Consultation";
            ca.Status = "Undone";
            ca.insertAlert();
            returntoWard();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Check Medical Status";
            ca.Status = "Undone";
            ca.insertAlert();
            returntoWard();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Request for Wheelchair";
            ca.Status = "Undone";
            ca.insertAlert();
            returntoWard();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Request for Shuttle";
            ca.Status = "Undone";
            ca.insertAlert();
            returntoWard();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ca.Assistance = "Room Maintenance";
            ca.Status = "Undone";
            ca.insertAlert();
            returntoWard();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            switch (room)
            {
                case "private":
                    Room_Type r = new Room_Type();
                    r.Show();
                    this.Hide();
                    break;
                case "ward":
                    Ward_Layout w = new Ward_Layout(floor);
                    w.Show();
                    this.Hide();
                    break;
            }
        }

        private void Patient_Dashboard_Load(object sender, EventArgs e)
        {
            label1.Text = bed;
            //this.TopMost = true;

           // this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
