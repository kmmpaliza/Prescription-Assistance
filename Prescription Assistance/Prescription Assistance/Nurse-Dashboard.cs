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
    public partial class Nurse_Dashboard : Form
    {
        public Nurse_Dashboard()
        {
            InitializeComponent();
        }

        private void Nurse_Dashboard_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = false;
            pnlFrame.Controls.Clear();
            var abc = new Room_Layout();
            abc.runAssistance();
            abc.runVitals();
            abc.runTimeforPrescription();
            abc.runPrescription();
            pnlFrame.Controls.Add(abc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = false;
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
            goto2nd();
        }

        private void ThirdFloorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goto3rd();
        }

        private void FourthFloorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goto4th();
        }

        private void FifthFloorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            goto5th();
        }

        private void allRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allRooms();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var viewInPatient = new View_InPatient_Nurse();
            pnlOverlay.Controls.Add(viewInPatient);
        }

        public void changetoViewPatient()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var viewInPatient = new View_InPatient_Nurse();
            pnlOverlay.Controls.Add(viewInPatient);
        }

        public void changetoUpdatePatientAsNurse(string id)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new Update_InPatientDetailsNurse(id);
            pnlOverlay.Controls.Add(abc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new InsertPrescription_Nurse();
            pnlOverlay.Controls.Add(abc);
        }

        public void changetoInsertMedicalRecords(string id, string vid)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new Insert_MedicalRecords(id, vid);
            pnlOverlay.Controls.Add(abc);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //medical records
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new View_MedicalRecords();
            pnlOverlay.Controls.Add(abc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //test results
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new Insert_TestResult();
            pnlOverlay.Controls.Add(abc);
        }

        public void goto2nd()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _2ndFloorPrivateRoomD(this);
            pnlOverlay.Controls.Add(abc);
        }

        public void goto3rd()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _3rdFloor(this);
            pnlOverlay.Controls.Add(abc);
        }

        public void goto4th()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _4thFloor(this);
            pnlOverlay.Controls.Add(abc);
        }

        public void goto5th()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _5thFloor(this);
            pnlOverlay.Controls.Add(abc);
        }

        public void allRooms()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new View_Rooms();
            pnlOverlay.Controls.Add(abc);
        }

    }
}
