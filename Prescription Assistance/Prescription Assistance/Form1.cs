﻿using System;
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
        string password;

        public Form1()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            Application.DoEvents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            
            //this.WindowState = FormWindowState.Maximized;this.FormBorderStyle = FormBorderStyle.None;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            cd.Doctor_id = textBox1.Text;
            cd.Password = textBox2.Text;
                
            if (Convert.ToBoolean(cd.viewDoctorDetails().Tables[0].Rows.Count > 0))
            {
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
                    Nurse_Dashboard nd = new Nurse_Dashboard();
                    nd.Show();
                    this.Hide();                  
                }

                else
                {
                    cr.Bed_id = textBox1.Text;
                    password = textBox2.Text;

                    if (Convert.ToBoolean(cr.viewBedDetails().Tables[0].Rows.Count > 0) && password.Equals("12345"))
                    {
                        Patient_Dashboard pd = new Patient_Dashboard();
                        pd.Show();
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

        }
    }
}
