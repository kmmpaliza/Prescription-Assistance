using System;
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
        Room_Layout rl = new Room_Layout();

        public Doctor_Dashboard()
        {
            InitializeComponent();
            
        }

        private void Doctor_Dashboard_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = false;
            pnlFrame.Controls.Clear();
            var abc = new Room_Layout();
            abc.runTime();
            abc.checkAssistance();
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
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var viewInPatient = new View_InPatient();
            pnlOverlay.Controls.Add(viewInPatient);
        }

        public void changetoViewPatient()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var viewInPatient = new View_InPatient();
            pnlOverlay.Controls.Add(viewInPatient);
        }

        public void changetoInsert()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var insertPatient = new Insert_InPatient();
            pnlOverlay.Controls.Add(insertPatient);
        }

        public void changetoViewPatientDetails(string id)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var viewinPatientDetails = new View_InPatientDetails(id);
            pnlOverlay.Controls.Add(viewinPatientDetails);
        }

        public void changetoUpdatePatientAsDoctor(string id) //pansamantala
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new Update_InPatientDetailsDoctor(id);
            pnlOverlay.Controls.Add(abc);
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
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _2ndFloorPrivateRoom();
            pnlOverlay.Controls.Add(abc);
        }

        private void ThirdFloorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _3rdFloor();
            pnlOverlay.Controls.Add(abc);
        }

        private void FourthFloorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _4thFloor();
            pnlOverlay.Controls.Add(abc);
        }

        private void FifthFloorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _5thFloor();
            pnlOverlay.Controls.Add(abc);
        }

        private void allRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new View_Rooms();
            pnlOverlay.Controls.Add(abc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = false;
        }

    }
}
