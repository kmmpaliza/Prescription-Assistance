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

            if (type.Equals("P"))
            {
                this.BackColor = Color.SteelBlue;

                cp.Prescription_id = id;
                ds = cp.viewSpecificPrescription();

                cp.Patient_id = ds.Tables[0].Rows[0][7].ToString();
                lblMed.Text = ds.Tables[0].Rows[0][1].ToString();
                lblText.Text = ds.Tables[0].Rows[0][2].ToString() + "\n" + 
                    ds.Tables[0].Rows[0][3].ToString() + "\n" + ds.Tables[0].Rows[0][4].ToString() + "\n" +
                    ds.Tables[0].Rows[0][5].ToString() + "\n" + ds.Tables[0].Rows[0][6].ToString();
            }
            else
            {
                this.BackColor = Color.DarkOrange;

                lblMed.Text = id;
                lblText.Text = "";                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
