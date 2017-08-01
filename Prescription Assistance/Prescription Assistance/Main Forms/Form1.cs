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
    public partial class Form1 : Form
    {
        Class_Nurse cn = new Class_Nurse();
        Class_Doctor cd = new Class_Doctor();
        Class_Rooms cr = new Class_Rooms();
        public static string userid = "";
        public static string usertype = "";
        public static string userpass = "";
        public static string usercontact = "";

        public Form1()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            Application.DoEvents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            
           
            //this.FormBorderStyle = FormBorderStyle.None;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            cd.Doctor_id = textBox1.Text;
            cd.Password = textBox2.Text;
                
            if (Convert.ToBoolean(cd.viewDoctorDetails().Tables[0].Rows.Count > 0))
            {
                userid = cd.Doctor_id;
                usertype = "Doctor";
                userpass = cd.Password;
                Doctor_Dashboard dd = new Doctor_Dashboard();
                dd.Show();
                this.Hide();
            }

            else
            {
                cn.Nurse_id = textBox1.Text;
                cn.Password = textBox2.Text;

                if (Convert.ToBoolean(cn.viewNurseDetails().Tables[0].Rows.Count > 0))
                {
                    userid = cn.Nurse_id;
                    usertype = "Nurse";
                    userpass = cn.Password;
                    Nurse_Dashboard nd = new Nurse_Dashboard();                    
                    nd.Show();
                    this.Hide();                  
                }

                else
                {
                    label2.Visible = true;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();  
                }
            }           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main rt = new Main();
            rt.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration r = new Registration();
            r.ShowDialog();
        }
    }
}
