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
        string bed;

        public Room_Layout()
        {
            InitializeComponent();
        }

        private void Room_Layout_Load(object sender, EventArgs e)
        {
            //pictureBox1.Fore
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
            a.Location = new Point(100, 100);
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

            Alert_Assistance a = new Alert_Assistance(alertid, bed, assistance, status);
            int[] loc = setLocation(bed);
            a.Location = new Point(loc[0], loc[1]);
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

            switch (interval)
            {
                case "Once a day (Day)":
                    cpa.Time = "08"; cpa.insertPAlert();
                    break;
                case "Once a day (Night)":
                    cpa.Time = "18"; cpa.insertPAlert();
                    break;
                case "Twice a day":
                    cpa.Time = "08"; cpa.insertPAlert();
                    cpa.Time = "20"; cpa.insertPAlert();
                    break;
                case "Three times a day":
                    cpa.Time = "08"; cpa.insertPAlert();
                    cpa.Time = "12"; cpa.insertPAlert();
                    cpa.Time = "20"; cpa.insertPAlert();
                    break;
                case "Four times a day":
                    cpa.Time = "08"; cpa.insertPAlert();
                    cpa.Time = "12"; cpa.insertPAlert();
                    cpa.Time = "18"; cpa.insertPAlert();
                    cpa.Time = "22"; cpa.insertPAlert();
                    break;
                case "Every 4 hours":
                    cpa.Time = "02"; cpa.insertPAlert();
                    cpa.Time = "06"; cpa.insertPAlert();
                    cpa.Time = "10"; cpa.insertPAlert();
                    cpa.Time = "14"; cpa.insertPAlert();
                    cpa.Time = "18"; cpa.insertPAlert();
                    cpa.Time = "22"; cpa.insertPAlert();
                    break;
                case "Every 6 hours":
                    cpa.Time = "06"; cpa.insertPAlert();
                    cpa.Time = "12"; cpa.insertPAlert();
                    cpa.Time = "18"; cpa.insertPAlert();
                    cpa.Time = "24"; cpa.insertPAlert();
                    break;
                case "Every 8 hours":
                    cpa.Time = "06"; cpa.insertPAlert();
                    cpa.Time = "14"; cpa.insertPAlert();
                    cpa.Time = "22"; cpa.insertPAlert();
                    break;
                case "Before meals":
                    cpa.Time = "08"; cpa.insertPAlert();
                    cpa.Time = "12"; cpa.insertPAlert();
                    cpa.Time = "18"; cpa.insertPAlert();
                    break;
                case "After meals":
                    cpa.Time = "09"; cpa.insertPAlert();
                    cpa.Time = "13"; cpa.insertPAlert();
                    cpa.Time = "19"; cpa.insertPAlert();
                    break;
            }

            runTimeforPrescription();
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

            Alert_Medicine a = new Alert_Medicine(palert_id);
            int[] loc = setLocation(bed);
            a.Location = new Point(loc[0], loc[1]);
            ePanel.Controls.Add(a);
            a.BringToFront();          
        }
        #endregion

        public void runTime()
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
        }    

        public void gotoInsertMedicalRecords(string id, string vid)
        {
            Nurse_Dashboard parent = (Nurse_Dashboard)this.ParentForm;
            parent.changetoInsertMedicalRecords(id, vid);
        }

        public int[] setLocation(string bed)
        {
            int[] loc = new int[2];

            switch (bed)
            {
                case "200-A":
                    loc[0] = 110;
                    loc[1] = 11;
                    break;
                case "200-B":
                    loc[0] = 110;
                    loc[1] = 81;
                    break;
                case "200-C":
                    loc[0] = 110;
                    loc[1] = 151;
                    break;
                case "200-D":
                    loc[0] = 110;
                    loc[1] = 221;
                    break;
                case "200-E":
                    loc[0] = 313;
                    loc[1] = 11;
                    break;
                case "200-F":
                    loc[0] = 313;
                    loc[1] = 81;
                    break;
                case "200-G":
                    loc[0] = 313;
                    loc[1] = 151;
                    break;
                case "200-H":
                    loc[0] = 313;
                    loc[1] = 221;
                    break;
                case "201":
                    loc[0] = 503;
                    loc[1] = 56;
                    break;
                case "202":
                    loc[0] = 503;
                    loc[1] = 140;
                    break;
                case "203":
                    loc[0] = 503;
                    loc[1] = 246;
                    break;
                case "300-A":
                    loc[0] = 41;
                    loc[1] = 409;
                    break;
                case "300-B":
                    loc[0] = 112;
                    loc[1] = 409;
                    break;
                case "300-C":
                    loc[0] = 184;
                    loc[1] = 409;
                    break;
                case "300-D":
                    loc[0] = 262;
                    loc[1] = 409;
                    break;
                case "300-E":
                    loc[0] = 41;
                    loc[1] = 545;
                    break;
                case "300-F":
                    loc[0] = 112;
                    loc[1] = 545;
                    break;
                case "300-G":
                    loc[0] = 184;
                    loc[1] = 545;
                    break;
                case "300-H":
                    loc[0] = 262;
                    loc[1] = 545;
                    break;
                case "301":
                    loc[0] = 362;
                    loc[1] = 432;
                    break;
                case "302":
                    loc[0] = 487;
                    loc[1] = 432;
                    break;
                case "303":
                    loc[0] = 362;
                    loc[1] = 563;
                    break;
                case "304":
                    loc[0] = 487;
                    loc[1] = 563;
                    break;
                case "400-A":
                    loc[0] = 594;
                    loc[1] = 110;
                    break;
                case "400-B":
                    loc[0] = 661;
                    loc[1] = 110;
                    break;
                case "400-C":
                    loc[0] = 741;
                    loc[1] = 110;
                    break;
                case "400-D":
                    loc[0] = 802;
                    loc[1] = 110;
                    break;
                case "400-E":
                    loc[0] = 861;
                    loc[1] = 110;
                    break;
                case "400-F":
                    loc[0] = 933;
                    loc[1] = 110;
                    break;
                case "400-G":
                    loc[0] = 974;
                    loc[1] = 125;
                    break;
                case "400-H":
                    loc[0] = 1031;
                    loc[1] = 125;
                    break;
                case "401":
                    loc[0] = 606;
                    loc[1] = 247;
                    break;
                case "402":
                    loc[0] = 728;
                    loc[1] = 253;
                    break;
                case "403":
                    loc[0] = 856;
                    loc[1] = 253;
                    break;
                case "404":
                    loc[0] = 989;
                    loc[1] = 253;
                    break;
                case "500-A":
                    loc[0] = 705;
                    loc[1] = 407;
                    break;
                case "500-B":
                    loc[0] = 775;
                    loc[1] = 407;
                    break;
                case "500-C":
                    loc[0] = 845;
                    loc[1] = 407;
                    break;
                case "500-D":
                    loc[0] = 915;
                    loc[1] = 407;
                    break;
                case "500-E":
                    loc[0] = 709;
                    loc[1] = 541;
                    break;
                case "500-F":
                    loc[0] = 779;
                    loc[1] = 541;
                    break;
                case "500-G":
                    loc[0] = 849;
                    loc[1] = 541;
                    break;
                case "500-H":
                    loc[0] = 1031;
                    loc[1] = 541;
                    break;
                case "501":
                    loc[0] = 600;
                    loc[1] = 400;
                    break;
                case "502":
                    loc[0] = 600;
                    loc[1] = 530;
                    break;
                case "503":
                    loc[0] = 1010;
                    loc[1] = 400;
                    break;
                case "504":
                    loc[0] = 1010;
                    loc[1] = 530;
                    break;
            }

            return loc;
        }
    }
}
