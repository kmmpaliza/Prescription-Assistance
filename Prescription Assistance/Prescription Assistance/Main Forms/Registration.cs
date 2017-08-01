using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Text.RegularExpressions;

namespace Prescription_Assistance
{
    public partial class Registration : Form
    {
        Class_Doctor cd = new Class_Doctor();
        Class_Nurse cn = new Class_Nurse();
        string type, id;

        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string number = txtContact.Text;
            bool isAContact = Regex.Match(number, @"^(\d{9})$").Success;

            if (isAContact)
            {
                type = cboType.Text;

                if (type.Equals("Nurse"))
                {
                    if (txtPass.Text == txtConfirm.Text)
                    {
                        cn.Last_name = txtLast.Text;
                        cn.First_name = txtFirst.Text;
                        cn.Password = txtPass.Text;
                        cn.Contact = txtContact.Text;

                        id = cn.insertNewNurse();
                        this.Close();
                        MessageBox.Show("Account successfully registered.\nName: " + cn.First_name.ToString() + " " + cn.Last_name.ToString() + "\nUsername: " + id);
                    }
                    else
                    {
                        label8.Visible = true;
                    }
                }
                else if (type.Equals("Doctor"))
                {
                    if (txtPass.Text == txtConfirm.Text)
                    {
                        cd.Last_name = txtLast.Text;
                        cd.First_name = txtFirst.Text;
                        cd.Password = txtPass.Text;
                        cd.Contact = txtContact.Text;

                        id = cd.insertNewDoctor();
                        this.Close();
                        MessageBox.Show("Account successfully registered.\nName: " + cd.First_name.ToString() + " " + cd.Last_name.ToString() + "\nUsername: " + id);
                    }
                    else
                    {
                        label8.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Please choose a type of Staff.");
                }
            }
            else{
                MessageBox.Show("Invalid Contact Number.");
                txtContact.Focus();
            }            
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
        }
    }
}
