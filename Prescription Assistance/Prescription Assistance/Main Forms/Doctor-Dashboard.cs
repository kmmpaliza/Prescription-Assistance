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
    public partial class Doctor_Dashboard : Form
    {
        Class_Doctor cd = new Class_Doctor();

        public Doctor_Dashboard()
        {
            InitializeComponent();            
        }

        private void Doctor_Dashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            cd.Doctor_id = Form1.userid;
            cd.Password = Form1.userpass;
            DataSet ds = new DataSet();
            ds = cd.viewDoctorDetails();

            label1.Text = "" + ds.Tables[0].Rows[0][2].ToString() + ", " + ds.Tables[0].Rows[0][3].ToString();            

            pnlOverlay.Controls.Clear();
            pnlOverlay.Visible = false;
            pnlFrame.Controls.Clear();
            var abc = new Room_Layout();
            pnlFrame.Controls.Add(abc);          
            abc.Dock = DockStyle.Fill;

            abc.checkAssistance();
            abc.runVitals();
            abc.runTimeforPrescription();
            abc.runPrescription();
            abc.run5MinutePrescription();
            abc.run10MinutePrescription();
            abc.checkLateAlerts();
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

        public void changetoInsert()
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var insertPatient = new Insert_InPatient();
            pnlOverlay.Controls.Add(insertPatient);
            insertPatient.Dock = DockStyle.Fill;
        }

        public void changetoUpdatePatientAsDoctor(string id)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new Update_InPatientDetailsDoctor(id);
            pnlOverlay.Controls.Add(abc);
            abc.Dock = DockStyle.Fill;
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
            var abc = new _2ndFloorPrivateRoomD();
            pnlOverlay.Controls.Add(abc);
          //  abc.Dock = DockStyle.Fill;
        }

        private void ThirdFloorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _3rdFloor();
            pnlOverlay.Controls.Add(abc);
           // abc.Dock = DockStyle.Fill;
        }

        private void FourthFloorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _4thFloor();
            pnlOverlay.Controls.Add(abc);
           // abc.Dock = DockStyle.Fill;
        }

        private void FifthFloorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new _5thFloor();
            pnlOverlay.Controls.Add(abc);
         //   abc.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new InsertPrescription();
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
            var viewInPatient = new Insert_TestResult();
            pnlOverlay.Controls.Add(viewInPatient);
            viewInPatient.Dock = DockStyle.Fill;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pnlOverlay.Visible = true;
            pnlOverlay.Controls.Clear();
            var abc = new View_Staff();
            pnlOverlay.Controls.Add(abc);
            abc.Dock = DockStyle.Fill;
        }
    }
}
