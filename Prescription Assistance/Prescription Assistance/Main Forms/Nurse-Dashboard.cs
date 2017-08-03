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
    public partial class Nurse_Dashboard : Form
    {
        Class_Nurse cd = new Class_Nurse();

        public Nurse_Dashboard()
        {
            InitializeComponent();
        }

        private void Nurse_Dashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            cd.Nurse_id = Form1.userid;
            cd.Password = Form1.userpass;
            DataSet ds = new DataSet();
            ds = cd.viewNurseDetails();

            label1.Text = "" + ds.Tables[0].Rows[0][2].ToString() + ", " + ds.Tables[0].Rows[0][3].ToString();

            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = false;
            pnlFrame.Controls.Clear();
            var abc = new Room_Layout();            
            pnlFrame.Controls.Add(abc);
            //abc.Dock = DockStyle.Fill;

            abc.checkAssistance(); //perfect HAHHA
            abc.runVitals();
            abc.runTimeforPrescription();
            abc.runPrescription();
            abc.run5MinutePrescription();
            abc.run10MinutePrescription();
            abc.checkLateAlerts();    
            
            //abc.highlightBed("ICU-A");  
            //abc.checkVitals(); 
                 
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
            var viewInPatient = new View_InPatient();
            pnlOverlay.Controls.Add(viewInPatient);
            viewInPatient.Dock = DockStyle.Fill;
        }

        public void changetoInsert()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var viewInPatient = new Insert_InPatient();
            pnlOverlay.Controls.Add(viewInPatient);
            viewInPatient.Dock = DockStyle.Fill;
        }

        public void changetoViewPatient()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var viewInPatient = new View_InPatient();
            pnlOverlay.Controls.Add(viewInPatient);
            viewInPatient.Dock = DockStyle.Fill;
        }

        public void changetoUpdatePatientAsNurse(string id)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new Update_InPatientDetailsNurse(id);
            pnlOverlay.Controls.Add(abc);
            abc.Dock = DockStyle.Fill;
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
            abc.Dock = DockStyle.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //medical records
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new View_MedicalRecords();
            pnlOverlay.Controls.Add(abc);
            abc.Dock = DockStyle.Fill;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //test results
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new Insert_TestResult();
            pnlOverlay.Controls.Add(abc);
            abc.Dock = DockStyle.Fill;
        }

        public void goto2nd()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _2ndFloorPrivateRoomD();
            pnlOverlay.Controls.Add(abc);
          //  abc.Dock = DockStyle.Fill;
        }

        public void goto3rd()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _3rdFloor();
            pnlOverlay.Controls.Add(abc);
           // abc.Dock = DockStyle.Fill;
        }

        public void goto4th()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _4thFloor();
            pnlOverlay.Controls.Add(abc);
           // abc.Dock = DockStyle.Fill;
        }

        public void goto5th()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _5thFloor();
            pnlOverlay.Controls.Add(abc);
           // abc.Dock = DockStyle.Fill;
        }

        public void allRooms()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new View_Rooms();
            pnlOverlay.Controls.Add(abc);
            abc.Dock = DockStyle.Fill;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new View_Staff();
            pnlOverlay.Controls.Add(abc);
            abc.Dock = DockStyle.Fill;

            //AssignRoomPatient ap = new AssignRoomPatient("301-A");
            //ap.ShowDialog();
        }
    }
}
