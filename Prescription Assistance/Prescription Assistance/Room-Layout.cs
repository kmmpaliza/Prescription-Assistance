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
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace Prescription_Assistance
{
    public partial class Room_Layout : UserControl
    {
        private System.Threading.Timer timer;
        private System.Timers.Timer[] btimer = new System.Timers.Timer[116];
        private System.Threading.Timer[] bttimer = new System.Threading.Timer[116];
        private System.Timers.Timer vTimer = new System.Timers.Timer(); //forvitals
        private System.Timers.Timer m5Timer = new System.Timers.Timer(); //forminuteintervals
        private System.Timers.Timer m10Timer = new System.Timers.Timer(); //forminuteintervals
        private System.Timers.Timer pTimer; //forhourlyprescription
        private System.Timers.Timer smsTimer = new System.Timers.Timer(); //forSMS

        Class_Alert ca = new Class_Alert();
        Class_Patient cp = new Class_Patient();
        Class_Rooms cr = new Class_Rooms();
        Class_Prescription cpr = new Class_Prescription();
        Class_Nurse cn = new Class_Nurse();

        DataSet ds = new DataSet(); //viewoccupiedbeds
        DataSet ds6 = new DataSet(); //viewallbeds
        DataSet ds7 = new DataSet(); //viewnurse
        DataSet ds8 = new DataSet(); //viewlatealerts


        DataSet ds2 = new DataSet(); //viewunfinishedalerts A
        DataSet ds3 = new DataSet(); //viewunfinishedalerts V
        DataSet ds4 = new DataSet(); //viewunfinishedalerts P

        DataSet ds0 = new DataSet(); //viewprescription
        DataSet ds1 = new DataSet(); //viewprescription

        string bed, id, textbody, timeNow, number;        

        public Room_Layout()
        {
            InitializeComponent();

            cn.Nurse_id = Form1.userid;
            cn.Password = Form1.userpass;
            ds7 = cn.viewNurseDetails();

            ds = cr.viewOccupiedRooms();
            
            ds6 = cr.viewAllBeds();

            ds8 = ca.viewLateAlerts();
        }
        private void Room_Layout_Load(object sender, EventArgs e)
        {
            if (Form1.usertype == "Nurse")
            {
                cn.Nurse_id = Form1.userid;
                cn.Password = Form1.userpass;
                ds7 = cn.viewNurseDetails();
                number = ds7.Tables[0].Rows[0][4].ToString();
            }
            else {}

            ds = cr.viewOccupiedRooms();
            ds6 = cr.viewAllBeds();
            ds8 = ca.viewLateAlerts();
        }
        
        #region SMS for Late Alerts
        public void checkLateAlerts() //every minute
        {
            smsTimer.Start();
            smsTimer.Interval = 60000; //1 minutes
            smsTimer.Elapsed +=new System.Timers.ElapsedEventHandler((o, e) =>
            {
                timeNow = DateTime.Now.ToString("HH:mm");
                if (Form1.usertype.Equals("Nurse"))
                {  
                    //ds8 = ca.viewLateAlerts();
                    if (ds8.Tables[0].Rows.Count > 0)
                    {                        
                        for (int i = 0; i < ds8.Tables[0].Rows.Count; i++)
                        {
                            //MessageBox.Show("" + i);
                            
                            //MessageBox.Show("" + timeNow + " " + ds7.Tables[0].Rows[i]["TimeforSMS"].ToString());
                            if (ds8.Tables[0].Rows[i]["TimeforSMS"].ToString() == timeNow)
                            {
                                sendSMS(number, ds8.Tables[0].Rows[i][2].ToString(),
                                    ds8.Tables[0].Rows[i][4].ToString(), ds8.Tables[0].Rows[i][5].ToString());
                            }
                        }                
                    }
                    else {}
                }
                else {}
            });
        }
        public void sendSMS(string num, string type, string bed, string info)
        {
            //MessageBox.Show("enter SMS");
            string number = String.Format("{0: +639#########}", long.Parse(num));
            
            switch (type)
            {
                case "A":
                    textbody = info + " for bed " + bed;   
                    break;
                case "V":
                    textbody = "Vital Check for " + info + " at bed " + bed;
                    break;
                case "P":
                    textbody = "Medicine for " + info + " at bed " + bed;
                    break;
            }

            var accountSid = "AC0ab70b5a1d9076ba7be503d95525ecde";
            // Your Auth Token from twilio.com/console
            var authToken = "f81c8931b8fbfce211261f1d1c785a83";

            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
                to: new PhoneNumber(number),
                from: new PhoneNumber("+1 650-603-5869"),
                body: textbody);

            //string alertmessage = "Message sent";
            
            //MessageBox.Show("" + alertmessage);
        }
        #endregion 

        #region Vital Alerts
        public void runVitals() //every 10 minutes
        {
            vTimer.Start();
            vTimer.Interval = 600000; //10 minutes
            //vTimer.Interval = 30000;
            vTimer.Elapsed += new System.Timers.ElapsedEventHandler((o, e) =>
            {
                checkVitals();
            });

            /**var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            timer = new System.Threading.Timer((e) =>
            {
                //MessageBox.Show("Hello");
                //checkVitals();
            }, null, startTimeSpan, periodTimeSpan);*/
        }
        public void checkVitals()
        {
            ds = cr.viewOccupiedRooms();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ca.Info_id = ds.Tables[0].Rows[i][1].ToString();
                    ca.Status = "Undone";
                    ca.Bed_id = ds.Tables[0].Rows[i][0].ToString();
                    ca.Type = "V";
                    ca.Ondisplay = "false";

                    DateTime currentTime = DateTime.Now;
                    DateTime x10mins = currentTime.AddMinutes(10);

                    ca.Timefordisplay = currentTime.ToString("HH:mm");
                    ca.Timeforsms = x10mins.ToString("HH:mm");
                  
                    string id = ca.insertAlert();
                }
            }

            displayVitals();
        }      
        public void displayVitals()
        {
            ca.Type = "V";          
            ds3 = ca.viewUnfinishedAlerts("V");
            if (ds3.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                {
                    string id = ds3.Tables[0].Rows[i][1].ToString();
                    string type = ds3.Tables[0].Rows[i][2].ToString();
                    string status = ds3.Tables[0].Rows[i][3].ToString();
                    string bed = ds3.Tables[0].Rows[i][4].ToString();
                    string info = ds3.Tables[0].Rows[i][5].ToString();

                    DateTime currentTime = DateTime.Now;
                    DateTime x10mins = currentTime.AddMinutes(10);
                    string timefordisplay = currentTime.ToString("HH:mm");
                    string timeforsms = currentTime.ToString("HH:mm");
                    ca.Timefordisplay = timefordisplay;
                    ca.Timeforsms = timeforsms;

                    string ondisplay = "true";
                    ca.Ondisplay = ondisplay;
                    ca.Alert_id = id;
                    ca.Status = status;
                    ca.updateAlert();

                    showAlert(id, type, bed, info, status, timefordisplay, timeforsms, ondisplay);                    
                }
            }
        }
        #endregion

        #region Assistance Alerts
        public void runAssistance() //check assistance every minute idk kung need pa nito, tryyy
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
            ca.Type = "A";          
            ds2 = ca.viewUnfinishedAlerts("A");                       
            if (ds2.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[1].Rows.Count; i++)
                {
                    string id = ds2.Tables[1].Rows[i][1].ToString();
                    string type = ds2.Tables[1].Rows[i][2].ToString();
                    string status = ds2.Tables[1].Rows[i][3].ToString();
                    string bed = ds2.Tables[1].Rows[i][4].ToString();
                    string info = ds2.Tables[1].Rows[i][5].ToString();

                    DateTime currentTime = DateTime.Now;
                    DateTime x10mins = currentTime.AddMinutes(10);
                    string timefordisplay = currentTime.ToString("HH:mm");
                    string timeforsms = currentTime.ToString("HH:mm");
                    ca.Timefordisplay = timefordisplay;
                    ca.Timeforsms = timeforsms;

                    string ondisplay = "true";
                    ca.Ondisplay = ondisplay;
                    ca.Alert_id = id;
                    ca.Status = status;                    
                    ca.updateAlert();

                    showAlert(id, type, bed, info, status, timefordisplay, timeforsms, ondisplay);
                }
            }
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
            ds = cr.viewOccupiedRooms();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //get patient and bed
                    bed = ds.Tables[0].Rows[i]["Bed_ID"].ToString();
                    cpr.Patient_id = ds.Tables[0].Rows[i]["Patient_ID"].ToString();

                    //get prescription of patient
                    ds0 = cpr.viewPescriptionDetails();
                    for (int j = 0; j < ds0.Tables[0].Rows.Count; j++)
                    {
                        string interval = ds0.Tables[0].Rows[j]["Interval"].ToString();
                        checkIntervalinHours(bed, ds0.Tables[0].Rows[j][0].ToString(), interval);
                    }
                }
            }
        }
        public void checkIntervalinHours(string bed_id, string prescription_id, string interval)
        {
            ca.Bed_id = bed_id;
            ca.Info_id = prescription_id;
            ca.Status = "Undone";
            ca.Type = "P";
            ca.Ondisplay = "false";

            if (interval.Equals("Once a day (Day)"))
            {
                ca.Timefordisplay = "08:00";
                ca.Timeforsms = "08:10";
                id = ca.insertAlert();
            }
            else if (interval.Equals("Once a day (Night)"))
            {
                ca.Timefordisplay = "18:00"; ca.Timeforsms = "18:10"; id = ca.insertAlert();
            }
            else if (interval.Equals("Twice a day"))
            {
                ca.Timefordisplay = "08:00"; ca.Timeforsms = "08:10"; id = ca.insertAlert();
                ca.Timefordisplay = "20:00"; ca.Timeforsms = "20:10"; id = ca.insertAlert();
            }
            else if (interval.Equals("Three times a day"))
            {
                ca.Timefordisplay = "08:00"; ca.Timeforsms = "08:10"; id = ca.insertAlert();
                ca.Timefordisplay = "12:00"; ca.Timeforsms = "12:10"; id = ca.insertAlert();
                ca.Timefordisplay = "20:00"; ca.Timeforsms = "20:10"; id = ca.insertAlert();
            }
            else if (interval.Equals("Four times a day"))
            {
                ca.Timefordisplay = "08:00"; ca.Timeforsms = "08:10"; id = ca.insertAlert();
                ca.Timefordisplay = "12:00"; ca.Timeforsms = "12:10"; id = ca.insertAlert();
                ca.Timefordisplay = "18:00"; ca.Timeforsms = "18:10"; id = ca.insertAlert();
                ca.Timefordisplay = "22:00"; ca.Timeforsms = "22:10"; id = ca.insertAlert();
            }
            else if (interval.Equals("Every 4 hours"))
            {
                ca.Timefordisplay = "02:00"; ca.Timeforsms = "02:10"; id = ca.insertAlert();
                ca.Timefordisplay = "06:00"; ca.Timeforsms = "06:10"; id = ca.insertAlert();
                ca.Timefordisplay = "10:00"; ca.Timeforsms = "10:10"; id = ca.insertAlert();
                ca.Timefordisplay = "14:00"; ca.Timeforsms = "14:10"; id = ca.insertAlert();
                ca.Timefordisplay = "18:00"; ca.Timeforsms = "18:10"; id = ca.insertAlert();
                ca.Timefordisplay = "22:00"; ca.Timeforsms = "22:10"; id = ca.insertAlert();
            }
            else if (interval.Equals("Every 6 hours"))
            {
                ca.Timefordisplay = "06:00"; ca.Timeforsms = "06:10"; id = ca.insertAlert();
                ca.Timefordisplay = "12:00"; ca.Timeforsms = "12:10"; id = ca.insertAlert();
                ca.Timefordisplay = "18:00"; ca.Timeforsms = "18:10"; id = ca.insertAlert();
                ca.Timefordisplay = "00:00"; ca.Timeforsms = "00:10"; id = ca.insertAlert(); //12am
            }
            else if (interval.Equals("Every 8 hours"))
            {
                ca.Timefordisplay = "06:00"; ca.Timeforsms = "06:10"; id = ca.insertAlert();
                ca.Timefordisplay = "14:00"; ca.Timeforsms = "14:10"; id = ca.insertAlert();
                ca.Timefordisplay = "22:00"; ca.Timeforsms = "22:10"; id = ca.insertAlert();
            }
            else if (interval.Equals("Before meals"))
            {
                ca.Timefordisplay = "08:00"; ca.Timeforsms = "08:10"; id = ca.insertAlert();
                ca.Timefordisplay = "12:00"; ca.Timeforsms = "12:10"; id = ca.insertAlert();
                ca.Timefordisplay = "18:00"; ca.Timeforsms = "18:10"; id = ca.insertAlert();
            }
            else if (interval.Equals("After meals"))
            {
                ca.Timefordisplay = "09:00"; ca.Timeforsms = "09:10"; id = ca.insertAlert();
                ca.Timefordisplay = "13:00"; ca.Timeforsms = "13:10"; id = ca.insertAlert();
                ca.Timefordisplay = "19:00"; ca.Timeforsms = "19:10"; id = ca.insertAlert();
            }
            else
            {
                //donothing
            }

            //MessageBox.Show("OK");
            runTimeforPrescription();   
        }
        public void runPrescription() //every hour
        {
            pTimer = new System.Timers.Timer(1000); //One second, (use less to add precision, use more to consume less processor time
            int lastHour = DateTime.Now.Hour;
            pTimer.Start();
            pTimer.Elapsed += new System.Timers.ElapsedEventHandler((o , e) =>
            {
                if(lastHour < DateTime.Now.Hour || (lastHour == 23 && DateTime.Now.Hour == 0))
                 {
                       lastHour = DateTime.Now.Hour;
                       checkPalerts();
                 }
            });

            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromMinutes(60);

            //timer = new System.Threading.Timer((e) =>
            //{
             //   checkPalerts();
            //}, null, startTimeSpan, periodTimeSpan);
        }
        public void checkPalerts()
        {
            ca.Type = "P";
            ds4 = ca.viewUnfinishedAlerts("P");
            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                if (DateTime.Now.ToString("HH:mm") == ds4.Tables[0].Rows[i][6].ToString())
                {
                    string id = ds4.Tables[0].Rows[0][1].ToString();
                    string type = ds4.Tables[0].Rows[0][2].ToString();
                    string status = ds4.Tables[0].Rows[0][3].ToString();
                    string bed = ds4.Tables[0].Rows[0][4].ToString();
                    string info = ds4.Tables[0].Rows[0][5].ToString();
                    string timefordisplay = ds4.Tables[0].Rows[0][6].ToString();
                    string timeforsms = ds4.Tables[0].Rows[0][7].ToString();
                    string ondisplay = ds4.Tables[0].Rows[0][8].ToString();
                    showAlert(id, type, bed, info, status, timefordisplay, timeforsms, ondisplay);

                    ca.Alert_id = id;
                    ca.Status = status;
                    ca.Ondisplay = "true";
                    ca.Timefordisplay = timefordisplay;
                    ca.Timeforsms = timeforsms;
                    ca.updateAlert();
                }
            }
        }

        public void run5MinutePrescription()
        {
            m5Timer.Start();
            m5Timer.Interval = 300000; //5 minutes5
            m5Timer.Elapsed += new System.Timers.ElapsedEventHandler((o, e) =>
            {
                checkMinutePrescription("Every 5 minutes");
            });
        } //every 5 mns
        public void run10MinutePrescription()
        {
            m10Timer.Start();
            m10Timer.Interval = 600000; //10 minutes5
            m10Timer.Elapsed += new System.Timers.ElapsedEventHandler((o, e) =>
            {
                checkMinutePrescription("Every 10 minutes");
            });
        } //every 10 mns
        public void checkMinutePrescription(string intervaltocheck)
        {
            //check rooms with patients
            ds = cr.viewOccupiedRooms();
            //MessageBox.Show("showed dataset");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //MessageBox.Show("showed row " + i);
                    //get patient and bed
                    bed = ds.Tables[0].Rows[i]["Bed_ID"].ToString();
                    cpr.Patient_id = ds.Tables[0].Rows[i]["Patient_ID"].ToString();

                    //get prescription of patient
                    ds1 = cpr.viewPescriptionDetails();
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        string interval = ds1.Tables[0].Rows[j]["Interval"].ToString();
                        //MessageBox.Show(interval);
                        if (intervaltocheck == interval)
                        {
                            saveMinuteMeds(bed, ds1.Tables[0].Rows[j][0].ToString());
                        }
                        else
                        {
                        }                        
                    }
                }
            }
        }
        public void checkIntervalinMinutes(string bed_id, string prescription_id, string interval, string intervaltocheck)
        {
            ca.Bed_id = bed_id;
            ca.Info_id = prescription_id;
            ca.Status = "Undone";
            ca.Type = "P";
            ca.Ondisplay = "false";

            if (interval.Equals(intervaltocheck))
            {
                saveMinuteMeds(bed_id, prescription_id);
            }
            else
            {
                //do nothing
            }
        }
        public void saveMinuteMeds(string bed_id, string prescription_id)
        {
            //MessageBox.Show("saving" + prescription_id);
            ca.Bed_id = bed_id;
            ca.Info_id = prescription_id;
            ca.Status = "Undone";
            ca.Type = "P";
            ca.Ondisplay = "true";

            DateTime currentTime = DateTime.Now;
            DateTime x10mins = currentTime.AddMinutes(10);
            ca.Timefordisplay = currentTime.ToString("HH:mm");
            ca.Timeforsms = x10mins.ToString("HH:mm");
            ca.Ondisplay = "true";

            id = ca.insertAlert();
            //MessageBox.Show("" + id);
            setBedtoBlink(ca.Bed_id.ToString());
            showAlert(id, ca.Type.ToString(), ca.Bed_id.ToString(), ca.Info_id.ToString(), ca.Status.ToString(),
                    ca.Timefordisplay.ToString(), ca.Timeforsms.ToString(), ca.Ondisplay.ToString());
        }
        #endregion

        public void showAlert(string id, string type, string bed, string info, string status,
        string timefordisplay, string timeforsms, string ondisplay)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    showAlert(id, type, bed, info, status, timefordisplay, timeforsms, ondisplay);
                });
                return;
            }

            Alert a = new Alert(id, type, bed, info, status, timefordisplay, timeforsms, ondisplay, this);
            ePanel.Controls.Add(a);
            a.BringToFront();
            a.Width = ePanel.Width - 10;

            highlightBed(bed);
        }

        #region Blink
        public void highlightBed(string bed_id)
        {
            //ds6 = cr.viewAllBeds();
            if (ds6.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < ds6.Tables[1].Rows.Count; i++)
                {
                    if (ds6.Tables[1].Rows[i][0].ToString() == bed_id)
                    {
                        bed = "" + i;
                        this.Controls.Find("pbox" + bed, true)[0].BringToFront();
                        if (this.Controls.Find("pbox" + bed, true)[0].BackColor == Color.Transparent)
                            this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.FromArgb(153, 255, 255, 0);
                        else
                        {
                            this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.FromArgb(153, 255, 255, 0);
                        }
                    }
                }
            } 
        }
        public void stoplightBed(string bed_id)
        {
            //ds6 = cr.viewAllBeds();
            if (ds6.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < ds6.Tables[1].Rows.Count; i++)
                {
                    if (ds6.Tables[1].Rows[i][0].ToString() == bed_id)
                    {
                        bed = "" + i;
                        if (this.Controls.Find("pbox" + bed, true)[0].BackColor == Color.FromArgb(153, 255, 255, 0))
                            this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.Transparent;
                        else
                        {
                            this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.Transparent;
                        }
                    }
                }
            }
        }
        public void setBedtoBlink(string bed_id)
        { 
            //ds5 = cr.viewAllBeds();
            if (ds6.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
                {
                    if (ds6.Tables[0].Rows[i][0].ToString() == bed_id)
                    {
                        bed = "" + i;  
                        //MessageBox.Show("" + btimer[i].ToString());
                        //btimer[i].Start();
                        //btimer[i].Elapsed += new System.Timers.ElapsedEventHandler(Room_Layout_Elapsed);
                        btimer[i] = new System.Timers.Timer();
                        //btimer[i].AutoReset = false;
                        btimer[i].Interval = 500;
                        btimer[i].SynchronizingObject = this;
                        btimer[i].Elapsed += new System.Timers.ElapsedEventHandler((o, e) =>
                        {
                            //Thread.Sleep(500);
                            this.Controls.Find("pbox" + bed, true)[0].BringToFront();
                            if (this.Controls.Find("pbox" + bed, true)[0].BackColor == Color.Transparent)
                                this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.FromArgb(153, 255, 255, 0);
                            else
                            {
                                this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.Transparent;
                            }
                        });
                        btimer[i].Start();

                        //bttimer[i] = new System.Threading.Timer((e) =>
                        //{
                        //    Room_Layout_Elapsed("" + i);
                        //}, null, 0, 500);

                        //bttimer[i] = new System.Threading.Timer(new TimerCallback(Room_Layout_Elapsed), null, 0, 1000);
                        
                    }
                }                
            }            
        }
        private void Room_Layout_Elapsed(string bed)//object sender, System.Timers.ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    Room_Layout_Elapsed(bed);
                });
                return;
            }

            this.Controls.Find("pbox" + bed, true)[0].BringToFront();
            if (this.Controls.Find("pbox" + bed, true)[0].BackColor == Color.Transparent)
                this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.FromArgb(153, 255, 255, 0);
            else
            {
                this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.Transparent;
            }
        }
        public void stopBlink(string bed_id)
        {
            //MessageBox.Show("" + bed_id);
            //ds6 = cr.viewAllBeds();
            if (ds6.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
                {
                    if (ds6.Tables[0].Rows[i][0].ToString() == bed_id)
                    {                        
                        btimer[i].Stop();                         
                        bed = "" + i;
                        this.Controls.Find("pbox" + bed, true)[0].BackColor = Color.Transparent;
                        //MessageBox.Show(btimer[i].Enabled + "Stop");
                    }
                }
            }
        }

        #endregion

        public void runTime()
        {
            DateTime requiredTime = DateTime.Today.AddHours(13).AddMinutes(54);
            
            if (DateTime.Now > requiredTime)
            {
                requiredTime = requiredTime.AddDays(1);
            }

            timer = new System.Threading.Timer(x => 
            {
                //showAlertforPrescription("PL00001", "ICU-A");
                checkVitals();

            }, null, (int)(requiredTime - DateTime.Now).TotalMilliseconds, Timeout.Infinite);
        }
    }
}
