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
        DataSet ds3 = new DataSet();

        _2ndFloorPrivateRoomD f2;
        _3rdFloor f3;
        _4thFloor f4;
        _5thFloor f5;
        View_Rooms vr;

        string bed;

        public AssignRoomPatient(string bed, _2ndFloorPrivateRoomD f2, _3rdFloor f3, _4thFloor f4, _5thFloor f5, View_Rooms vr)
        {
            InitializeComponent();
            this.bed = bed;
            cr.Bed_id = bed;
            this.f2 = f2;
            this.f3 = f3;
            this.f4 = f4;
            this.f5 = f5;
            this.vr = vr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cr.Bed_id = bed;
            cr.Patient_id = "";
            cr.Status = "Vacant";
            cr.updateRoom();

            button3.Enabled = false;
            label3.Text = "None";
            dataGridView1.DataSource = null;
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
                lblText.Text = @"Showing results for '" + txtSearch.Text + @"'. "; 
            }
            else
            {
                dataGridView1.DataSource = null;
                lblText.Text = @"No results for '" + txtSearch.Text + @"'";
            }  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {                
                cp.Patient_id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSearch.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cp.Last_name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                cr.Bed_id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cr.Status = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cr.Room = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cr.Patient_id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                ds3 = cr.searchRoom();
                //MessageBox.Show("" + ds3.Tables[1].Rows.Count);
                if (ds3.Tables[1].Rows.Count > 0)
                {                    
                    MessageBox.Show("Error. " + cr.Patient_id.ToString() + " is already occupying " + ds3.Tables[1].Rows[0][0].ToString());
                }
                else
                {
                    cr.Bed_id = bed;    
                    cr.Patient_id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cr.Status = "Occupied";
                    cr.updateRoom();
                    MessageBox.Show("Patient successfully assigned to " + bed);

                    label3.Text = cr.Patient_id.ToString() + " " + cp.Last_name.ToString();
                    button3.Enabled = true;                    
                }                           
            }
        }

        private void AssignRoomPatient_FormClosing(object sender, FormClosingEventArgs e)
        { 
            f2.refresh();
            f3.refresh();
            f4.refresh();
            f5.refresh();
            vr.refresh();
        }
    }
}
