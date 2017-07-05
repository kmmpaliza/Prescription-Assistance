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
    public partial class Room_Type : Form
    {
        public Room_Type()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //toprivate
            cboPrivate.Visible = true;
            button4.Visible = true;
            cboWard.Visible = false;
            button5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //toward
            cboWard.Visible = true;
            button5.Visible = true;
            cboPrivate.Visible = false;
            button4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //okpriv
            Patient_Dashboard p = new Patient_Dashboard(cboPrivate.Text, "private", "");
            p.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //okward
            Ward_Layout w = new Ward_Layout(cboWard.Text);
            w.Show();
            this.Hide();
        }

        private void Room_Type_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;

            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
