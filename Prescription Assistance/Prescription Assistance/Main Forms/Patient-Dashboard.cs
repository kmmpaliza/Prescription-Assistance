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
        string bed, floor;

        public Patient_Dashboard(string bed, string floor)
        {
            InitializeComponent();
            this.bed = bed;
            ca.Bed_id = bed;
            this.floor = floor;         
            
        }

        private void returntoWard()
        {
            Ward_Layout w = new Ward_Layout(floor);
            w.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ca.Info_id = "Pharmacy";
            ca.Status = "Undone";
            DateTime currentTime = DateTime.Now;
            DateTime x10mins = currentTime.AddMinutes(10);
            ca.Type = "A";
            ca.Timefordisplay = currentTime.ToString("HH:mm");
            ca.Timeforsms = x10mins.ToString("HH:mm");
            ca.Ondisplay = "false";
            ca.insertAlert();
            
            MessageBox.Show("Request for Pharmacy is successful. Please wait while your request is processed.");
            

            returntoWard();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ca.Info_id = "Order Meal";
            ca.Status = "Undone";
            DateTime currentTime = DateTime.Now;
            DateTime x10mins = currentTime.AddMinutes(10);
            ca.Type = "A";
            ca.Timefordisplay = currentTime.ToString("HH:mm");
            ca.Timeforsms = x10mins.ToString("HH:mm");
            ca.Ondisplay = "false";
            ca.insertAlert();

            MessageBox.Show("Request to Order Meal is successful. Please wait while your request is processed.");
            returntoWard();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ca.Info_id = "Room Transfer";
            ca.Status = "Undone";
            DateTime currentTime = DateTime.Now;
            DateTime x10mins = currentTime.AddMinutes(10);
            ca.Type = "A";
            ca.Timefordisplay = currentTime.ToString("HH:mm");
            ca.Timeforsms = x10mins.ToString("HH:mm");
            ca.Ondisplay = "false";
            ca.insertAlert();

            MessageBox.Show("Request for Room Transfer is successful. Please wait while your request is processed.");
            returntoWard();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ca.Info_id = "Medical Consultation";
            ca.Status = "Undone";
            DateTime currentTime = DateTime.Now;
            DateTime x10mins = currentTime.AddMinutes(10);
            ca.Type = "A";
            ca.Timefordisplay = currentTime.ToString("HH:mm");
            ca.Timeforsms = x10mins.ToString("HH:mm");
            ca.Ondisplay = "false";
            ca.insertAlert();

            MessageBox.Show("Request for Medical Consultation is successful. Please wait while your request is processed.");
            returntoWard();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ca.Info_id = "Check Medical Status";
            ca.Status = "Undone";
            DateTime currentTime = DateTime.Now;
            DateTime x10mins = currentTime.AddMinutes(10);
            ca.Type = "A";
            ca.Timefordisplay = currentTime.ToString("HH:mm");
            ca.Timeforsms = x10mins.ToString("HH:mm");
            ca.Ondisplay = "false";
            ca.insertAlert();

            MessageBox.Show("Request for Medical Status Check is successful. Please wait while your request is processed.");
            returntoWard();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ca.Info_id = "Request for Wheelchair";
            ca.Status = "Undone";
            DateTime currentTime = DateTime.Now;
            DateTime x10mins = currentTime.AddMinutes(10);
            ca.Type = "A";
            ca.Timefordisplay = currentTime.ToString("HH:mm");
            ca.Timeforsms = x10mins.ToString("HH:mm");
            ca.Ondisplay = "false";
            ca.insertAlert();

            MessageBox.Show("Request for Wheelchair is successful. Please wait while your request is processed.");
            returntoWard();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ca.Info_id = "Request for Shuttle";
            ca.Status = "Undone";
            DateTime currentTime = DateTime.Now;
            DateTime x10mins = currentTime.AddMinutes(10);
            ca.Type = "A";
            ca.Timefordisplay = currentTime.ToString("HH:mm");
            ca.Timeforsms = x10mins.ToString("HH:mm");
            ca.Ondisplay = "false";
            ca.insertAlert();

            MessageBox.Show("Request for Shuttle is successful. Please wait while your request is processed.");
            returntoWard();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ca.Info_id = "Room/Bed Maintenance";
            ca.Status = "Undone";
            DateTime currentTime = DateTime.Now;
            DateTime x10mins = currentTime.AddMinutes(10);
            ca.Type = "A";
            ca.Timefordisplay = currentTime.ToString("HH:mm");
            ca.Timeforsms = x10mins.ToString("HH:mm");
            ca.Ondisplay = "false";
            ca.insertAlert();

            MessageBox.Show("Request for Room/Bed Maintenance is successful. Please wait while your request is processed.");
            returntoWard();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Ward_Layout w = new Ward_Layout(floor);
            w.Show();
            this.Hide();
        }

        private void Patient_Dashboard_Load(object sender, EventArgs e)
        {
            label1.Text = bed;
            //this.TopMost = true;

            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
