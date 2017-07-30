using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using ClassLibrary;

namespace Prescription_Assistance
{
    public partial class Room_Layout : UserControl
    {
        private System.Threading.Timer timer;
        private System.Windows.Forms.Timer[] btimer = new System.Windows.Forms.Timer[116];

        Class_Alert ca = new Class_Alert();
        Class_Patient cp = new Class_Patient();
        Class_Vitals cv = new Class_Vitals();
        Class_Rooms cr = new Class_Rooms();
        Class_PAlert cpa = new Class_PAlert();
        Class_Prescription cpr = new Class_Prescription();

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        DataSet ds5 = new DataSet();

        string bed, id;        

        public Room_Layout()
        {
            InitializeComponent();
        }  

        #region Vital Alerts
        public void runVitals() //every hour
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);

            timer = new System.Threading.Timer((e) =>
            {
                checkVitals();
            }, null, startTimeSpan, periodTimeSpan);
        }
        public void checkVitals()
        {
            ds2 = cr.viewOccupiedRooms();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    cv.Patient_id = ds2.Tables[0].Rows[i]["Patient_ID"].ToString();
                    cv.Status = "Undone";
                    cv.Bed_id = ds2.Tables[0].Rows[i]["Bed_ID"].ToString();
                    string id = cv.insertVital();

                    //setBedtoBlink(cv.Bed_id.ToString());
                    showAlertforVitals(id);
                }
            }
        }      
        public void showAlertforVitals(string id)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    showAlertforVitals(id);
                });
                return;
            }
            
            Alert_Vitals a = new Alert_Vitals(id, this);
            ePanel.Controls.Add(a);
            a.BringToFront();                        
        }
        #endregion

        #region Assistance Alerts
        public void runAssistance() //check assistance every minute
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            timer = new System.Threading.Timer((e) =>
            {
                checkAssistance();
            }, null, startTimeSpan, periodTimeSpan);
        }
        public void checkAssistance()
        {            
            ds = ca.viewUnfinishedAlerts();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    showAlertforAssistance(ds.Tables[0].Rows[i]["Alert_ID"].ToString(), ds.Tables[0].Rows[i]["Bed_ID"].ToString(), ds.Tables[0].Rows[i]["Assistance"].ToString(), ds.Tables[0].Rows[i]["Status"].ToString());
                }
            }
        }
        public void showAlertforAssistance(string alertid, string bed, string assistance, string status)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    showAlertforAssistance(alertid, bed, assistance, status);
                });
                return;
            }

            //setBedtoBlink(bed);
            Alert_Assistance a = new Alert_Assistance(alertid, bed, assistance, status);
            ePanel.Controls.Add(a);
        }
        #endregion

        #region Prescription Alerts
        public void runTimeforPrescription() //12 AM
        {
            DateTime requiredTime = DateTime.Today.AddHours(00).AddMinutes(00);

            if (DateTime.Now > requiredTime)
            {
                requiredTime = requiredTime.AddDays(1);
            }

            timer = new System.Threading.Timer(x =>
            {
                checkPrescription();

            }, null, (int)(requiredTime - DateTime.Now).TotalMilliseconds, Timeout.Infinite);
        }  
        public void checkPrescription()
        {
            //check rooms with patients
            ds2 = cr.viewOccupiedRooms();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    //get patient and bed
                    bed = ds2.Tables[0].Rows[i]["Bed_ID"].ToString();
                    cpr.Patient_id = ds2.Tables[0].Rows[i]["Patient_ID"].ToString();

                    //get prescription of patient
                    ds3 = cpr.viewPescriptionDetails();
                    for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                    {
                        string interval = ds3.Tables[0].Rows[j]["Interval"].ToString();
                        checkInterval(bed, cpr.Patient_id, ds3.Tables[0].Rows[j][0].ToString(), interval);
                    }
                }
            }
        }
        public void checkInterval(string bed_id, string patient_id, string prescription_id, string interval)
        {
            cpa.Bed_id = bed_id;
            cpa.Patient_id = patient_id;
            cpa.Prescription_id = prescription_id;
            cpa.Status = "Undone";

            if (interval.Equals("Every 5 minutes"))
            {                
                runMinute5Meds(bed_id, patient_id, prescription_id);
            }
            else if (interval.Equals("Every 10 minutes"))
            {                
                runMinute10Meds(bed_id, patient_id, prescription_id);
            }
            else 
            {
                if (interval.Equals("Once a day (Day)"))
                {
                    cpa.Time = "08";
                    id = cpa.insertPAlert();
                }
                else if (interval.Equals("Once a day (Night)"))
                {
                    cpa.Time = "18";
                    id = cpa.insertPAlert();
                }
                else if (interval.Equals("Twice a day"))
                {
                    cpa.Time = "08"; id = cpa.insertPAlert();
                    cpa.Time = "20"; id = cpa.insertPAlert();
                }
                else if (interval.Equals("Three times a day"))
                {
                    cpa.Time = "08"; id = cpa.insertPAlert();
                    cpa.Time = "12"; id = cpa.insertPAlert();
                    cpa.Time = "20"; id = cpa.insertPAlert();
                }
                else if (interval.Equals("Four times a day"))
                {
                    cpa.Time = "08"; id = cpa.insertPAlert();
                    cpa.Time = "12"; id = cpa.insertPAlert();
                    cpa.Time = "18"; id = cpa.insertPAlert();
                    cpa.Time = "22"; id = cpa.insertPAlert();
                }
                else if (interval.Equals("Every 4 hours"))
                {
                    cpa.Time = "02"; id = cpa.insertPAlert();
                    cpa.Time = "06"; id = cpa.insertPAlert();
                    cpa.Time = "10"; id = cpa.insertPAlert();
                    cpa.Time = "14"; id = cpa.insertPAlert();
                    cpa.Time = "18"; id = cpa.insertPAlert();
                    cpa.Time = "22"; id = cpa.insertPAlert();
                }
                else if (interval.Equals("Every 6 hours"))
                {
                    cpa.Time = "06"; id = cpa.insertPAlert();
                    cpa.Time = "12"; id = cpa.insertPAlert();
                    cpa.Time = "18"; id = cpa.insertPAlert();
                    cpa.Time = "24"; id = cpa.insertPAlert();
                }
                else if (interval.Equals("Every 8 hours"))
                {
                    cpa.Time = "06"; id = cpa.insertPAlert();
                    cpa.Time = "14"; id = cpa.insertPAlert();
                    cpa.Time = "22"; id = cpa.insertPAlert();
                }
                else if (interval.Equals("Before meals"))
                {
                    cpa.Time = "08"; id = cpa.insertPAlert();
                    cpa.Time = "12"; id = cpa.insertPAlert();
                    cpa.Time = "18"; id = cpa.insertPAlert();
                }
                else if (interval.Equals("After meals"))
                {
                    cpa.Time = "09"; id = cpa.insertPAlert();
                    cpa.Time = "13"; id = cpa.insertPAlert();
                    cpa.Time = "19"; id = cpa.insertPAlert();
                }

                runTimeforPrescription();   
            }           
        }

        public void runMinute5Meds(string bed_id, string patient_id, string prescription_id) //check med every 5 minutes
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);

            timer = new System.Threading.Timer((e) =>
            {
                cpa.Bed_id = bed_id;
                cpa.Patient_id = patient_id;
                cpa.Prescription_id = prescription_id;
                cpa.Status = "Undone";
                cpa.Time = "";
                id = cpa.insertPAlert();              
                showAlertforPrescription(id, bed_id);
            }, null, startTimeSpan, periodTimeSpan);
        }
        public void runMinute10Meds(string bed_id, string patient_id, string prescription_id) //check med every 10 minutes
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(10);

            timer = new System.Threading.Timer((e) =>
            {
                cpa.Bed_id = bed_id;
                cpa.Patient_id = patient_id;
                cpa.Prescription_id = prescription_id;
                cpa.Status = "Undone";
                cpa.Time = "";
                id = cpa.insertPAlert();

                showAlertforPrescription(id, bed_id);
            }, null, startTimeSpan, periodTimeSpan);
        }

        public void runPrescription() //every hour
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);

            timer = new System.Threading.Timer((e) =>
            {
                checkPalerts();
            }, null, startTimeSpan, periodTimeSpan);
        }
        public void checkPalerts()
        {
            ds4 = cpa.viewUndonePalerts();
            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                if (DateTime.Now.Hour.ToString() == ds4.Tables[0].Rows[i]["Time"].ToString())
                {
                    bed = ds4.Tables[0].Rows[i][2].ToString();
                    showAlertforPrescription(ds4.Tables[0].Rows[i][1].ToString(), ds4.Tables[0].Rows[i][2].ToString());
                }
            }
        }
        public void showAlertforPrescription(string palert_id, string bed)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    showAlertforPrescription(palert_id, bed);
                });
                return;
            }

            //setBedtoBlink(bed);
            Alert_Medicine a = new Alert_Medicine(palert_id);
            ePanel.Controls.Add(a);
            a.BringToFront();          
        }
        #endregion


        public void setBedtoBlink(string bed_id)
        { 
            ds5 = cr.viewAllBeds();
            if (ds5.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                {
                    if (ds5.Tables[0].Rows[i][0].ToString() == bed_id)
                    {
                        btimer[i] = new System.Windows.Forms.Timer();
                        btimer[i].Start();
                        btimer[i].Enabled = true;
                        btimer[i].Interval = 500;
                        btimer[i].Tag = i;
                        btimer[i].Tick += new EventHandler(Room_Layout_Tick);
                        bed = "" + i;
                    }
                }                
            }            
        }

        private void Room_Layout_Tick(object sender, EventArgs e)
        {
            if (this.Controls.Find("pbox" + bed, true)[0].BackColor == Color.Transparent)
                this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.FromArgb(153, 255, 255, 0);
            else
            {
                this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.Transparent;
            }
        }

        /**public void runTime()
        {
            DateTime requiredTime = DateTime.Today.AddHours(21).AddMinutes(38);
            
            if (DateTime.Now > requiredTime)
            {
                requiredTime = requiredTime.AddDays(1);
            }

            timer = new System.Threading.Timer(x => 
            {
                checkPrescription();

            }, null, (int)(requiredTime - DateTime.Now).TotalMilliseconds, Timeout.Infinite);
        }    */

        public void gotoInsertMedicalRecords(string id, string vid)
        {
            Nurse_Dashboard parent = (Nurse_Dashboard)this.ParentForm;
            parent.changetoInsertMedicalRecords(id, vid);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (bed)
            {
                case "ICU-A":
                    break;
                case "ICU-B":
                    break;
                case "ICU-C":
                    break;
                case "ICU-D":
                    break;
                case "ICU-E":
                    break;
                case "ICU-F":
                    break;
                case "ORE-A":
                    break;
                case "ORE-B":
                    break;
                case "FW2-A":
                    break;
                case "FW2-B":
                    break;
                case "FW2-C":
                    break;
                case "FW2-D":
                    break;
                case "FW2-E":
                    break;
                case "FW1-A":
                    break;
                case "FW1-B":
                    break;
                case "FW1-C":
                    break;
                case "FW1-D":
                    break;
                case "PED-A":
                    break;
                case "PED-B":
                    break;
                case "PED-C":
                    break;
                //3rd floor
                case "301-A":
                    break;
                case "301-B":
                    break;
                case "301-C":
                    break;
                case "302-A":
                    break;
                case "302-B":
                    break;
                case "302-C":
                    break;
                case "303-A":
                    break;
                case "303-B":
                    break;
                case "303-C":
                    break;
                case "304-A":
                    break;
                case "304-B":
                    break;
                case "304-C":
                    break;
                case "305-A":
                    break;
                case "305-B":
                    break;
                case "305-C":
                    break;
                case "306-A":
                    break;
                case "306-B":
                    break;
                case "307-A":
                    break;
                case "307-B":
                    break;
                case "307-C":
                    break;
                case "307-D":
                    break;
                case "307-E":
                    break;
                case "308-A":
                    break;
                case "308-B":
                    break;
                case "308-C":
                    break;
                case "308-D":
                    break;
                case "308-E":
                    break;
                case "309-A":
                    break;
                case "309-B":
                    break;
                case "309-C":
                    break;
                case "309-D":
                    break;
                case "309-E":
                    break;
                //4th Floor
                case "401-A":
                    break;
                case "401-B":
                    break;
                case "401-C":
                    break;
                case "402-A":
                    break;
                case "402-B":
                    break;
                case "402-C":
                    break;
                case "403-A":
                    break;
                case "403-B":
                    break;
                case "403-C":
                    break;
                case "404-A":
                    break;
                case "404-B":
                    break;
                case "404-C":
                    break;
                case "405-A":
                    break;
                case "405-B":
                    break;
                case "405-C":
                    break;
                case "406-A":
                    break;
                case "406-B":
                    break;
                case "407-A":
                    break;
                case "407-B":
                    break;
                case "407-C":
                    break;
                case "407-D":
                    break;
                case "407-E":
                    break;
                case "408-A":
                    break;
                case "408-B":
                    break;
                case "408-C":
                    break;
                case "408-D":
                    break;
                case "408-E":
                    break;
                case "409-A":
                    break;
                case "409-B":
                    break;
                case "409-C":
                    break;
                case "409-D":
                    break;
                case "409-E":
                    break;
                //5th
                case "501-A":
                    break;
                case "501-B":
                    break;
                case "501-C":
                    break;
                case "502-A":
                    break;
                case "502-B":
                    break;
                case "502-C":
                    break;
                case "503-A":
                    break;
                case "503-B":
                    break;
                case "503-C":
                    break;
                case "504-A":
                    break;
                case "504-B":
                    break;
                case "504-C":
                    break;
                case "505-A":
                    break;
                case "505-B":
                    break;
                case "505-C":
                    break;
                case "506-A":
                    break;
                case "506-B":
                    break;
                case "507-A":
                    break;
                case "507-B":
                    break;
                case "507-C":
                    break;
                case "507-D":
                    break;
                case "507-E":
                    break;
                case "508-A":
                    break;
                case "508-B":
                    break;
                case "508-C":
                    break;
                case "508-D":
                    break;
                case "508-E":
                    break;
                case "509-A":
                    break;
                case "509-B":
                    break;
                case "509-C":
                    break;
                case "509-D":
                    break;
                case "509-E":
                    break;
            }
        }

        private void Room_Layout_Load(object sender, EventArgs e)
        {

        }

        private void pbox111_Click(object sender, EventArgs e)
        {
            Alert_Details ad = new Alert_Details("hello", "bed", "Prescription");
            ad.ShowDialog();
        }
   
    }
}
