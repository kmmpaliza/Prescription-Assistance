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
    public partial class Alert_Details : Form
    {
        string id, bed, type;
        Class_PAlert cpa = new Class_PAlert();
        Class_Prescription cp = new Class_Prescription();
        Class_Alert ca = new Class_Alert();
        Class_Rooms cr = new Class_Rooms();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        public Alert_Details(string id, string bed, string type)
        {
            InitializeComponent();
            this.id = id;
            this.bed = bed;
            this.type = type;
        }

        private void Alert_Details_Load(object sender, EventArgs e)
        {
            lblRoom.Text = bed;

            cr.Bed_id = bed;
            ds = cr.viewBedandPatient();
            lblPatient.Text = ds.Tables[0].Rows[0][3].ToString();

            if (type.Equals("Prescription"))
            {
                this.BackColor = Color.SteelBlue;

                cpa.Palert_id = id; 
                ds = cpa.viewPAlert();

                cp.Patient_id = ds.Tables[0].Rows[0][3].ToString();
                cp.Prescription_id = ds.Tables[0].Rows[0][4].ToString();
                ds2 = cp.viewSpecificPrescription();

                lblMed.Text = ds2.Tables[0].Rows[0][1].ToString();
                lblText.Text = ds2.Tables[0].Rows[0][2].ToString() + "/n" + ds2.Tables[0].Rows[0][3].ToString() + "/n" +
                    ds2.Tables[0].Rows[0][3].ToString() + "/n" + ds2.Tables[0].Rows[0][4].ToString() + "/n" +
                    ds2.Tables[0].Rows[0][5].ToString() + "/n" + ds2.Tables[0].Rows[0][6].ToString();
            }
            else
            {
                this.BackColor = Color.DarkOrange;

                lblMed.Text = type;
                lblText.Text = "";                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
