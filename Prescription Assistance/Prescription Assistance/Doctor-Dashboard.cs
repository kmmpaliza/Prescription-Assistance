﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prescription_Assistance
{
    public partial class Doctor_Dashboard : Form
    {
        

        public Doctor_Dashboard()
        {
            InitializeComponent();
        }

        private void Doctor_Dashboard_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.FormBorderStyle = Fo rmBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;

            pnlFrame.Controls.Clear();
            var abc = new Room_Layout();
            pnlFrame.Controls.Add(abc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlFrame.Controls.Clear();
            var viewInPatient = new View_InPatient();
            pnlFrame.Controls.Add(viewInPatient);
        }

        public void changetoViewPatient()
        {
            pnlFrame.Controls.Clear();
            var viewInPatient = new View_InPatient();
            pnlFrame.Controls.Add(viewInPatient);
        }

        public void changetoInsert()
        {
            pnlFrame.Controls.Clear();
            var insertPatient = new Insert_InPatient();
            pnlFrame.Controls.Add(insertPatient);
        }

        public void changetoViewPatientDetails(string id)
        {
            pnlFrame.Controls.Clear();
            var viewinPatientDetails = new View_InPatientDetails(id);
            pnlFrame.Controls.Add(viewinPatientDetails);
        }

        public void changetoUpdatePatientAsDoctor(string id) //pansamantala
        {
            pnlFrame.Controls.Clear();
            var abc = new Update_InPatientDetailsDoctor(id);
            pnlFrame.Controls.Add(abc);
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            Point menuLocation;
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                menuLocation = e.Location;
                contextMenuStrip1.Show(button4, menuLocation);
            }
        }

        private void SecondFloorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlFrame.Controls.Clear();
            var abc = new _2ndFloorPrivateRoom();
            pnlFrame.Controls.Add(abc);
        }

        private void ThirdFloorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlFrame.Controls.Clear();
            var abc = new _3rdFloor();
            pnlFrame.Controls.Add(abc);
        }

        private void FourthFloorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlFrame.Controls.Clear();
            var abc = new _4thFloor();
            pnlFrame.Controls.Add(abc);
        }

        private void FifthFloorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pnlFrame.Controls.Clear();
            var abc = new _5thFloor();
            pnlFrame.Controls.Add(abc);
        }

        private void allRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlFrame.Controls.Clear();
            var abc = new View_Rooms();
            pnlFrame.Controls.Add(abc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlFrame.Controls.Clear();
            var abc = new Room_Layout();
            pnlFrame.Controls.Add(abc);
        }

    }
}
