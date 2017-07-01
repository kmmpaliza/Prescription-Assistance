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
    public partial class Update_InPatientDetailsNurse : UserControl
    {
        string id;
        Class_Patient cp = new Class_Patient();
        Class_MedRec cm = new Class_MedRec();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        public Update_InPatientDetailsNurse(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Update_InPatientDetailsNurse_Load(object sender, EventArgs e)
        {
            cp.Patient_id = id;
            cm.Patient_id = id;

            ds = cp.viewPatientDetails();
            ds2 = cm.viewMedRecDetails();

            string name = ds.Tables[0].Rows[0][2].ToString() + ", " + ds.Tables[0].Rows[0][3].ToString();
            lblName.Text = name;

            txtLast.Text = ds.Tables[0].Rows[0][2].ToString();
            txtFirst.Text = ds.Tables[0].Rows[0][3].ToString();
            cboGender.Text = ds.Tables[0].Rows[0][4].ToString();
            txtAge.Text = ds.Tables[0].Rows[0][5].ToString();
            dateTimePicker1.Text = ds.Tables[0].Rows[0][6].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0][7].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][8].ToString();

            txtWeight.Text = ds2.Tables[0].Rows[0][3].ToString();
            txtHeight.Text = ds2.Tables[0].Rows[0][4].ToString();
            txtHR.Text = ds2.Tables[0].Rows[0][5].ToString();
            txtBS.Text = ds2.Tables[0].Rows[0][6].ToString();
            txtBP.Text = ds2.Tables[0].Rows[0][7].ToString();
            txtTemp.Text = ds2.Tables[0].Rows[0][8].ToString();
            txtMH.Text = ds2.Tables[0].Rows[0][9].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update patient
            cp.Patient_id = id;
            cm.Patient_id = id;

            cp.Last_name = txtLast.Text;
            cp.First_name = txtFirst.Text;
            cp.Gender = cboGender.Text;
            cp.Age = txtAge.Text;
            cp.Birthday = dateTimePicker1.Value.Date.ToShortDateString();
            cp.Address = txtAddress.Text;
            cp.Contact = txtContact.Text;

            cm.Weight = txtWeight.Text;
            cm.Height = txtHeight.Text;
            cm.Heart_rate = txtHR.Text;
            cm.Blood_sugar = txtBS.Text;
            cm.Blood_pressure = txtBP.Text;
            cm.Temperature = txtTemp.Text;
            cm.Medical_history = txtMH.Text;

            cp.updatePatient();
            cm.updateMedRec();

            MessageBox.Show("Patient Details successfully updated.");
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoViewPatientDetails(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoViewPatientDetails(id);
        }

    }
}
