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
    public partial class View_InPatientDetails : UserControl
    {
        string id;
        Class_Patient cp = new Class_Patient();
        Class_MedRec cm = new Class_MedRec();
        Class_Prescription cpr = new Class_Prescription();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();

        public View_InPatientDetails(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void View_InPatientDetails_Load(object sender, EventArgs e)
        {
            cp.Patient_id = id;
            cm.Patient_id = id;
            cpr.Patient_id = id;

            ds = cp.viewPatientDetails();
            string name = ds.Tables[0].Rows[0][2].ToString() + ", " + ds.Tables[0].Rows[0][3].ToString();
            lblName.Text = name;
            //lblRoom wala pa
            //lblBed wala pa    
            lblGender.Text = ds.Tables[0].Rows[0][4].ToString();
            lblAge.Text = ds.Tables[0].Rows[0][5].ToString();
            lblBirthday.Text = ds.Tables[0].Rows[0][6].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0][7].ToString();
            lblContact.Text = ds.Tables[0].Rows[0][8].ToString();

            ds2 = cm.viewMedRecDetails();
            lblWeight.Text = ds2.Tables[0].Rows[0][3].ToString();
            lblHeight.Text = ds2.Tables[0].Rows[0][4].ToString();
            lblHeartRate.Text = ds2.Tables[0].Rows[0][5].ToString();
            lblBS.Text = ds2.Tables[0].Rows[0][6].ToString();
            lblBP.Text = ds2.Tables[0].Rows[0][7].ToString();
            lblTemp.Text = ds2.Tables[0].Rows[0][8].ToString();
            lblMH.Text = ds2.Tables[0].Rows[0][9].ToString();
            lblMF.Text = ds2.Tables[0].Rows[0][10].ToString();
            lblSI.Text = ds2.Tables[0].Rows[0][11].ToString();

            ds3 = cpr.viewPescriptionDetails();
            dgvPrescription.ReadOnly = true;
            dgvPrescription.DataSource = ds3.Tables[0];
            dgvPrescription.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoUpdatePatientAsNurse(id);
            
        }

    }
}
