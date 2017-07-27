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
    public partial class Alert_Medicine : UserControl
    {
        Class_PAlert cpa = new Class_PAlert();
        Class_Prescription cp = new Class_Prescription();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        string id, bed;

        public Alert_Medicine(string id)
        {
            InitializeComponent();
            this.id = id;  
            cpa.Palert_id = id;          
        }

        private void Alert_Medicine_Load(object sender, EventArgs e)
        {
            ds = cpa.viewPAlert();

            bed = ds.Tables[0].Rows[0][2].ToString();
            cp.Patient_id = ds.Tables[0].Rows[0][3].ToString();
            cp.Prescription_id = ds.Tables[0].Rows[0][4].ToString();
            ds2 = cp.viewPescriptionDetails();

            label1.Text = bed + " | " + cp.Patient_id.ToString();
            label2.Text = ds2.Tables[0].Rows[0][1].ToString() + " / " + ds2.Tables[0].Rows[0][2].ToString();
            label3.Text = ds2.Tables[0].Rows[0][3].ToString() + "/" + ds2.Tables[0].Rows[0][4].ToString() + "/" + ds2.Tables[0].Rows[0][6].ToString();
        }

        private void Alert_Medicine_Click(object sender, EventArgs e)
        {
            cpa.Status = "Done";
            cpa.updatePAlert();

            this.Enabled = false;
            this.Visible = false;
            this.Parent.Refresh();
            this.Parent.Controls.Remove(this);
        }
    }
}
