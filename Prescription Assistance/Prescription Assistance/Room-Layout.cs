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
                    showAlertforAssistance(ds.Tables[0].Rows[i]["Alert_ID"].ToString(), ds.Tables[0].Rows[i]["Bed_ID"].ToString(), ds.Tables[0].Rows[i]["Assistance"].ToString(), 10, 10, ds.Tables[0].Rows[i]["Status"].ToString());
                }
            }
        }
        public void showAlertforAssistance(string alertid, string bed, string assistance, int pointx, int pointy, string status)
        {
            Alert_Assistance a = new Alert_Assistance(alertid, bed, assistance, status);
            a.Location = new Point(pointx, pointy);
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
                    showAlertforPrescription(ds4.Tables[0].Rows[i][1].ToString());
                }
            }
        }
        public void showAlertforPrescription(string palert_id)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    showAlertforPrescription(palert_id);
                });
                return;
            }

            Alert_Medicine a = new Alert_Medicine(palert_id);
            a.Location = new Point(100, 100);
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
    }
}
