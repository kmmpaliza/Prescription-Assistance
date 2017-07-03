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
    public partial class View_InPatient : UserControl
    {
        Class_Patient cp = new Class_Patient();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        public View_InPatient()
        {
            InitializeComponent();
           
        }

        private void View_InPatient_Load(object sender, EventArgs e)
        {
            ds = cp.viewAllPatients();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount-1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoInsert();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
                parent.changetoUpdatePatientAsDoctor(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cp.Patient_id = txtSearch.Text;
            cp.Last_name = txtSearch.Text;
            cp.First_name = txtSearch.Text;
            cp.Gender = txtSearch.Text;
            cp.Age = txtSearch.Text;
            cp.Birthday = txtSearch.Text;

            ds2 = cp.searchPatient();
            dataGridView1.Refresh();
            dataGridView1.DataSource = ds2.Tables["search_Patient"];            
        }
    }
}
