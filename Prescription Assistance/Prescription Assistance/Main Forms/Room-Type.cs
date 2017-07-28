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
            cbo2nd.Visible = true;
            bO2nd.Visible = true;
            cbo3rd.Visible = false;
            bO3rd.Visible = false;
            cbo4th.Visible = false;
            bO4th.Visible = false;
            cbo5th.Visible = false;
            bO5th.Visible = false;

            b2nd.Enabled = false;
            b3rd.Enabled = true;
            b4th.Enabled = true;
            b5th.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //toward
            cbo3rd.Visible = true;
            bO3rd.Visible = true;
            cbo2nd.Visible = false;
            bO2nd.Visible = false;
            cbo4th.Visible = false;
            bO4th.Visible = false;
            cbo5th.Visible = false;
            bO5th.Visible = false;

            b3rd.Enabled = false;
            b2nd.Enabled = true;
            b4th.Enabled = true;
            b5th.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cbo3rd.Visible = false;
            bO3rd.Visible = false;
            cbo2nd.Visible = false;
            bO2nd.Visible = false;
            cbo4th.Visible = true;
            bO4th.Visible = true;
            cbo5th.Visible = false;
            bO5th.Visible = false;

            b4th.Enabled = false;
            b2nd.Enabled = true;
            b3rd.Enabled = true;
            b5th.Enabled = true;
        }

        private void b5th_Click(object sender, EventArgs e)
        {
            cbo3rd.Visible = false;
            bO3rd.Visible = false;
            cbo2nd.Visible = false;
            bO2nd.Visible = false;
            cbo4th.Visible = false;
            bO4th.Visible = false;
            cbo5th.Visible = true;
            bO5th.Visible = true;

            b5th.Enabled = false;
            b2nd.Enabled = true;
            b3rd.Enabled = true;
            b4th.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ward_Layout w = new Ward_Layout(cbo2nd.Text);
            w.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {            
            Ward_Layout w = new Ward_Layout(cbo3rd.Text);
            w.Show();
            this.Hide();
        }

        private void Room_Type_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void bO4th_Click(object sender, EventArgs e)
        {
            Ward_Layout w = new Ward_Layout(cbo4th.Text);
            w.Show();
            this.Hide();
        }

        private void bO5th_Click(object sender, EventArgs e)
        {
            Ward_Layout w = new Ward_Layout(cbo5th.Text);
            w.Show();
            this.Hide();
        }

        
    }
}
