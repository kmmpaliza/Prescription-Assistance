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
    public partial class AssignRoomPatient : Form
    {
        Class_Rooms cr = new Class_Rooms();
        Class_Patient cp = new Class_Patient();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        string bed;

        public AssignRoomPatient(string bed)
        {
            InitializeComponent();
            this.bed = bed;
            cr.Bed_id = bed;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cr.Patient_id = "";
            cr.updateRoom();
            label3.Text = "None";
            button3.Enabled = false;
        }

        private void AssignRoomPatient_Load(object sender, EventArgs e)
        {
            label2.Text = bed;
            label1.Text = "Assign New In-Patient to " + bed;

            ds = cr.viewBedandPatient();
            if (ds.Tables[0].Rows[0][2].ToString() == "Occupied")
            {
                label3.Text = ds.Tables[0].Rows[0][4].ToString() + "  " + ds.Tables[0].Rows[0][3].ToString();
            }
            else {
                button3.Enabled = false;
                label3.Text = "None";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cp.Patient_id = txtSearch.Text;
            cp.Last_name = txtSearch.Text;
            cp.First_name = txtSearch.Text;
            cp.Gender = txtSearch.Text;
            cp.Age = txtSearch.Text;
            cp.Contact = txtSearch.Text;

            ds2 = cp.searchPatient();
            dataGridView1.Refresh();
            dataGridView1.DataSource = ds2.Tables["search_Patient"];  
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cr.Patient_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cp.Patient_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cp.Last_name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            cr.updateRoom();
            label3.Text = cp.Patient_id + " | " + cp.Last_name;
            button3.Enabled = true;
        }
    }
}
