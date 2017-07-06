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
    public partial class View_MedicalRecords : UserControl
    {
        Class_MedRec cm = new Class_MedRec();
        DataSet ds = new DataSet();

        public View_MedicalRecords()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cm.Patient_id = txtSearch.Text;
            ds = cm.viewMedRecDetails();

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void View_MedicalRecords_Load(object sender, EventArgs e)
        {

        }
    }
}
