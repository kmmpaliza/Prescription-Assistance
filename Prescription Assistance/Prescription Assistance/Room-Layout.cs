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

namespace Prescription_Assistance
{
    public partial class Room_Layout : UserControl
    {
        private System.Threading.Timer timer;
        public Room_Layout()
        {
            InitializeComponent();
            time();
        }

        private void Room_Layout_Load(object sender, EventArgs e)
        {
            
        }   

        private void time()
        {
            DateTime requiredTime = DateTime.Today.AddHours(00).AddMinutes(16);
            
            if (DateTime.Now > requiredTime)
            {
                requiredTime = requiredTime.AddDays(1);
            }

            timer = new System.Threading.Timer(x => 
            {
                TimerAction();
            }, null, (int)(requiredTime - DateTime.Now).TotalMilliseconds, Timeout.Infinite);
        }    

        private void TimerAction()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(TimerAction));
            }
            else {
                Alert_Medicine a = new Alert_Medicine();
                a.Location = new Point(100, 100);
                ePanel.Controls.Add(a);

                Alert_Medicine b = new Alert_Medicine();
                ePanel.Controls.Add(b);
                time();
            }
        }
    }
}
