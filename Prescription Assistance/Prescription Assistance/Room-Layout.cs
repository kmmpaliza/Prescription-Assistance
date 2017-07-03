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
        //Class_Vitals cv = new Class_Vitals();
        DataSet ds = new DataSet();

        /**#region VariablesforMedicine
        private int hours, minutes, pointX, pointY, room, medname, dose, route, form, interval, note;

        public int PointY
        {
            get { return pointY; }
            set { pointY = value; }
        }

        public int PointX
        {
            get { return pointX; }
            set { pointX = value; }
        }

        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }
        #endregion*/

        public Room_Layout()
        {
            InitializeComponent();
        }

        private void Room_Layout_Load(object sender, EventArgs e)
        {
        }   

        public void checkAssistance()
        {
            ds = ca.viewUnfinishedAlerts();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for(int i=0; i<ds.Tables[0].Rows.Count; i++)
                {
                    showAlertforAssistance(ds.Tables[0].Rows[i]["Alert_ID"].ToString(), ds.Tables[0].Rows[i]["Bed_ID"].ToString(), ds.Tables[0].Rows[i]["Assistance"].ToString(), 10, 10, ds.Tables[0].Rows[i]["Status"].ToString());
                }
            }
        }

        public void checkVitals()
        {
            
        }

        public void runVitals()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);

            timer = new System.Threading.Timer((e) =>
            {
                showAlertforVitals();
            }, null, startTimeSpan, periodTimeSpan);
        }

        public void runTime()
        {
            DateTime requiredTime = DateTime.Today.AddHours(13).AddMinutes(30);
            
            if (DateTime.Now > requiredTime)
            {
                requiredTime = requiredTime.AddDays(1);
            }

            timer = new System.Threading.Timer(x => 
            {
                showAlertforPrescription();
            }, null, (int)(requiredTime - DateTime.Now).TotalMilliseconds, Timeout.Infinite);
        }    

        public void showAlertforPrescription()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(showAlertforPrescription));
            }
            else {
                Alert_Medicine a = new Alert_Medicine();
                a.Location = new Point(100, 100);
                ePanel.Controls.Add(a);

                Alert_Medicine b = new Alert_Medicine();
                ePanel.Controls.Add(b);
                runTime();
            }
        }

        public void showAlertforVitals()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(showAlertforVitals));
            }
            else
            {
                Alert_Vitals a = new Alert_Vitals();
                a.Location = new Point(100, 100);
                ePanel.Controls.Add(a);
                runTime();
            }
        }

        public void showAlertforAssistance(string alertid, string bed, string assistance, int pointx, int pointy, string status)
        {
            Alert_Assistance a = new Alert_Assistance(alertid, bed, assistance, status);
            a.Location = new Point(pointx, pointy);
            ePanel.Controls.Add(a);
        }

        private void ePanel_Click(object sender, EventArgs e)
        {

        }
    }
}
