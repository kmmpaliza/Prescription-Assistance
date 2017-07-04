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
    public partial class Alert_Vitals : UserControl
    {
        string id;
        Class_Vitals cv = new Class_Vitals();
        DataSet ds = new DataSet();
        private Room_Layout rl;

        public Alert_Vitals(string id, Room_Layout rl)
        {
            InitializeComponent();
            this.id = id;
            this.rl = rl;
        }

        private void Alert_Vitals_Load(object sender, EventArgs e)
        {
            cv.Vital_id = id;
            ds = cv.viewVital();
            cv.Patient_id = ds.Tables[0].Rows[0][2].ToString();
            label1.Text = ds.Tables[0].Rows[0][3].ToString();
            label2.Text = "Vital Check for " + ds.Tables[0].Rows[0][2].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cv.Vital_id = id;
            cv.Status = "Doing";
            cv.updateVital();

            this.Enabled = false;
            this.Visible = false;
            this.Parent.Refresh();
            this.Parent.Controls.Remove(this);


            rl.gotoInsertMedicalRecords(cv.Patient_id.ToString(), id);
            //Room_Layout parent = (Room_Layout)this.Parent;
            //parent.gotoInsertMedicalRecords(cv.Patient_id.ToString(), id);
        }
    }
}
