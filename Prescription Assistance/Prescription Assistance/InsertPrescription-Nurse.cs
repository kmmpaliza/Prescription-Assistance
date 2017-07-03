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
    public partial class InsertPrescription_Nurse : UserControl
    {
        Class_Prescription cpr = new Class_Prescription();
        DataSet ds = new DataSet();

        public InsertPrescription_Nurse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cpr.Patient_id = txtSearch.Text;
            ds = cpr.viewPescriptionDetails();
            dgvPrescription.ReadOnly = true;
            dgvPrescription.DataSource = ds.Tables[0];
            dgvPrescription.Columns[0].Visible = false;
        }

        private void dgvPrescription_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
