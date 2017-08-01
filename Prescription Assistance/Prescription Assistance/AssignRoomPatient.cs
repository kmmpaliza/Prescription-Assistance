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
            cr.Status = "Vacant";
            cr.updateRoom();
            load();
        }

        private void AssignRoomPatient_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            label2.Text = bed;
            label1.Text = "Assign New In-Patient to " + bed;

            ds = cr.viewBedandPatient();
            if (ds.Tables[0].Rows[0][2].ToString() == "Occupied")
            {
                label3.Text = ds.Tables[0].Rows[0][4].ToString() + "  " + ds.Tables[0].Rows[0][3].ToString();
            }
            else
            {
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
            int count = ds2.Tables[0].Rows.Count;

            if (count > 0)
            {
                dataGridView1.Refresh();
                dataGridView1.DataSource = ds2.Tables["search_Patient"];
                lblText.Text = @"Showing results for '" + txtSearch.Text + @"'. " + count + " result/s."; 
            }
            else
            {
                dataGridView1.DataSource = null;
                lblText.Text = @"No results for '" + txtSearch.Text + @"'";
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cr.Status = "Occupied";
            cr.updateRoom();
            MessageBox.Show("Patient successfully assigned to " + bed);
            load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                cr.Patient_id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cp.Patient_id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSearch.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();              
            }
        }
    }
}
