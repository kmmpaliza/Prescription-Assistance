using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Text.RegularExpressions;

namespace Prescription_Assistance
{
    public partial class View_Staff : UserControl
    {
        Class_Doctor cd = new Class_Doctor();
        Class_Nurse cn = new Class_Nurse();
        DataSet ds = new DataSet();

        public View_Staff()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Enabled = false;

            cboType.Enabled = true;
            txtLast.Enabled = true;
            txtFirst.Enabled = true;
            txtContact.Enabled = true;
            txtPass.Enabled = true;
            txtConfirm.Enabled = true;
        }

        private void load()
        {
            if (Form1.usertype.Equals("Doctor"))
            {
                cd.Doctor_id = Form1.userid;
                cd.Password = Form1.userpass;
                ds = cd.viewDoctorDetails();

                cboType.Text = "Doctor";
                txtFirst.Text = ds.Tables[0].Rows[0][3].ToString();
                txtLast.Text = ds.Tables[0].Rows[0][2].ToString();
                txtContact.Text = ds.Tables[0].Rows[0][4].ToString();
                txtUsername.Text = ds.Tables[0].Rows[0][1].ToString();
                txtPass.Text = ds.Tables[0].Rows[0][5].ToString();
            }
            else
            {
                cn.Nurse_id = Form1.userid;
                cn.Password = Form1.userpass;
                ds = cn.viewNurseDetails();

                cboType.Text = "Nurse";
                txtFirst.Text = ds.Tables[0].Rows[0][3].ToString();
                txtLast.Text = ds.Tables[0].Rows[0][2].ToString();
                txtContact.Text = ds.Tables[0].Rows[0][4].ToString();
                txtUsername.Text = ds.Tables[0].Rows[0][1].ToString();
                txtPass.Text = ds.Tables[0].Rows[0][5].ToString();
            }

            button1.Visible = false;
            button2.Visible = false;
            button3.Enabled = true;

            cboType.Enabled = false;
            txtLast.Enabled = false;
            txtFirst.Enabled = false;
            txtContact.Enabled = false;
            txtPass.Enabled = false;
            txtConfirm.Enabled = false;

            label9.Visible = false;
        }

        private void View_Staff_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string number = txtContact.Text;
            bool isAContact = Regex.Match(number, @"^(\d{9})$").Success;

            if (isAContact)
            {
                if (txtPass.Text == txtConfirm.Text)
                {
                    if (Form1.usertype.Equals("Doctor"))
                    {
                        cd.Doctor_id = Form1.userid;
                        cd.Last_name = txtLast.Text;
                        cd.First_name = txtFirst.Text;
                        cd.Contact = txtContact.Text;
                        cd.Password = txtPass.Text;
                        Form1.userpass = txtPass.Text;

                        cd.updateDoctor();
                        label9.Visible = false;
                        load();
                        MessageBox.Show("Details successfully updated");
                    }
                    else
                    {
                        cn.Nurse_id = Form1.userid;
                        cn.Last_name = txtLast.Text;
                        cn.First_name = txtFirst.Text;
                        cn.Contact = txtContact.Text;
                        cn.Password = txtPass.Text;
                        Form1.userpass = txtPass.Text;

                        cn.updateNurse();
                        label9.Visible = false;
                        load();
                        MessageBox.Show("Details successfully updated");
                    }
                }
                else
                {
                    label9.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Invalid Contact Number.");
                txtContact.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}
