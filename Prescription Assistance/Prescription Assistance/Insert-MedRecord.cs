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
            int hr;
            bool isNumeric = int.TryParse(txtHR.Text, out hr);

            double temp;
            bool isNumericT = double.TryParse(txtTemp.Text, out temp);

            int bp1, bp2;
            bool isNumericBP1 = int.TryParse(txtBP1.Text, out bp1);
            bool isNumericBP2 = int.TryParse(txtBP2.Text, out bp2);

            int bs;
            bool isNumericBS = int.TryParse(txtBS.Text, out bs);

            if (isNumeric)
            {
                cm.Heart_rate = txtHR.Text + " bpm";
                if (isNumericT)
                {
                    cm.Temperature = txtTemp.Text + " °C";
                    if (isNumericBP1)
                    {
                        if (isNumericBP2)
                        {
                            cm.Blood_pressure = txtBP1.Text + "/" + txtBP2.Text + " mmHg";
                            if (isNumericBS)
                            {
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
                            else
                            {
                                MessageBox.Show("Invalid value for Blood Sugar.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid value for Blood Pressure.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid value for Blood Pressure.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid value for Temperature.");
                }
            }
            else
            {
                MessageBox.Show("Invalid value for Heart Rate.");
            }                 
        }
    }
}
