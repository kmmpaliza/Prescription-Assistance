using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Prescription_Assistance
{
    public partial class View_Rooms : UserControl
    {
        Class_Rooms cr = new Class_Rooms();
        DataSet ds = new DataSet();

        public View_Rooms()
        {
            InitializeComponent();
        }

        private void View_Rooms_Load(object sender, EventArgs e)
        {
            ds = cr.viewAllBeds();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr.Bed_id = txtSearch.Text;
            cr.Room = txtSearch.Text;
            cr.Status = txtSearch.Text;
            cr.Patient_id = txtSearch.Text;

            ds = cr.searchRoom();
            dataGridView1.Refresh();
            dataGridView1.DataSource = ds.Tables["search_Room"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                AssignRoomPatient ar = new AssignRoomPatient(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                ar.ShowDialog();
            }
        }
    }
}
