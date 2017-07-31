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
    public partial class Insert_MedRecord : Form
    {
        Class_MedRec cm = new Class_MedRec();
        Class_Alert ca = new Class_Alert();
        DataSet ds = new DataSet();
        string id, type, bed, info, status, timefordisplay, timeforsms, ondisplay;

        public Insert_MedRecord(string id, string type, string bed, string info, string status,
        string timefordisplay, string timeforsms, string ondisplay)
        {
            InitializeComponent();

            this.id = id;
            this.type = type;
            this.bed = bed;
            this.info = info;
            this.status = status;
            this.timefordisplay = timefordisplay;
            this.timeforsms = timeforsms;
            this.ondisplay = ondisplay;

            ca.Alert_id = id;
            ca.Type = type;
            ca.Bed_id = bed;
            ca.Info_id = info;
            ca.Status = status;
            ca.Timefordisplay = timefordisplay;
            ca.Timeforsms = timeforsms;
            ca.Ondisplay = ondisplay; 
        }

        private void Insert_MedRecord_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            cm.Patient_id = info;
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
            cm.Nurse_id = Form1.userid;
            cm.Datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            cm.insertNewMedRec();
            MessageBox.Show("Medical Record for " + cm.Patient_id + " is successfully inserted.");

            ca.Alert_id = id;
            ca.Status = "Done";
            ca.Timefordisplay = timefordisplay;
            ca.Timeforsms = timeforsms;
            ca.Ondisplay = ondisplay;
            ca.updateAlert();

            load();            
        }
    }
}
