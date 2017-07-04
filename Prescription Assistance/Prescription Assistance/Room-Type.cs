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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //toward
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }
    }
}
