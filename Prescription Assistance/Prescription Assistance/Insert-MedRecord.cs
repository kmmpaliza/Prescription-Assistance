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
            cm.Heart_rate = txtHR.Text + " bpm";
            cm.Temperature = txtTemp.Text + " °C";
            cm.Blood_pressure = txtBP1.Text + "/" + txtBP2.Text + " mmHg";
            cm.Blood_sugar = txtBS.Text + " mg/dl";
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

        private void txtHR_Validating(object sender, CancelEventArgs e)
        {
            int hr;
            bool isNumeric = int.TryParse(txtHR.Text, out hr);

            if (!isNumeric)
            {
                MessageBox.Show("Invalid value for Heart Rate.");
                txtHR.Focus();                              
            }
            else {}  
        }

        private void txtTemp_Validating(object sender, CancelEventArgs e)
        {
            double temp;
            bool isNumericT = double.TryParse(txtTemp.Text, out temp);

            if (!isNumericT)
            {
                MessageBox.Show("Invalid value for Temperature.");
                txtTemp.Focus();              
            }
            else {} 
        }

        private void txtBP1_Validating(object sender, CancelEventArgs e)
        {
            int bp1;
            bool isNumericBP1 = int.TryParse(txtBP1.Text, out bp1);

            if (!isNumericBP1)
            {
                MessageBox.Show("Invalid value for Blood Pressure.");
                txtBP1.Focus();
            }
            else {}         
        }

        private void txtBP2_Validating(object sender, CancelEventArgs e)
        {
            int bp2;
            bool isNumericBP2 = int.TryParse(txtBP2.Text, out bp2);

            if (!isNumericBP2)
            {
                MessageBox.Show("Invalid value for Blood Pressure.");
                txtBP2.Focus();
            }
            else {}
        }

        private void txtBS_Validating(object sender, CancelEventArgs e)
        {
            int bs;
            bool isNumericBS = int.TryParse(txtBS.Text, out bs);

            if (!isNumericBS)
            {
                MessageBox.Show("Invalid value for Blood Sugar.");
                txtBS.Focus();
            }
            else {}
        }
    }
}
