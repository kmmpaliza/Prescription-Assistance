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
    public partial class Insert_MedicalRecords : UserControl
    {
        string id, vid;
        Class_MedRec cm = new Class_MedRec();
        Class_Vitals cv = new Class_Vitals();
        DataSet ds = new DataSet();

        public Insert_MedicalRecords(string id, string vid)
        {
            InitializeComponent();
            this.id = id;
            this.vid = vid;
        }

        private void Insert_MedicalRecords_Load(object sender, EventArgs e)
        {
            cm.Patient_id = id;
            ds = cm.viewMedRecDetails();

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cm.Heart_rate = txtHR.Text;
            cm.Temperature = txtTemp.Text;
            cm.Blood_sugar = txtBS.Text;
            cm.Blood_pressure = txtBP.Text;
            cm.Nurse_id = "";
            cm.Datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            cm.insertNewMedRec();
            MessageBox.Show("Medical Record for " + cm.Patient_id + " is successfully inserted.");

            cv.Vital_id = vid;
            cv.Status = "Done";
            cv.updateVital();
        }
    }
}
