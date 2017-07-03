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

            txtLast.Text = ds.Tables[0].Rows[0][2].ToString();
            txtFirst.Text = ds.Tables[0].Rows[0][3].ToString();
            cboGender.Text = ds.Tables[0].Rows[0][4].ToString();
            txtAge.Text = ds.Tables[0].Rows[0][5].ToString();
            dateTimePicker1.Text = ds.Tables[0].Rows[0][6].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0][7].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][8].ToString();
            txtWeight.Text = ds.Tables[0].Rows[0][9].ToString();
            txtHeight.Text = ds.Tables[0].Rows[0][10].ToString();
            txtMH.Text = ds.Tables[0].Rows[0][11].ToString();
            txtMF.Text = ds.Tables[0].Rows[0][12].ToString();
            txtSI.Text = ds.Tables[0].Rows[0][13].ToString();

            dgvMedRec.ReadOnly = true;
            dgvMedRec.DataSource = ds2.Tables[0];
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
            cp.Weight = txtWeight.Text;
            cp.Height = txtHeight.Text;
            cp.Medical_history = txtMH.Text;

            cp.updatePatient();

            MessageBox.Show("Patient Details successfully updated.");

            txtLast.Enabled = false;
            txtFirst.Enabled = false;
            cboGender.Enabled = false;
            txtAge.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtAddress.Enabled = false;
            txtContact.Enabled = false;
            txtWeight.Enabled = false;
            txtHeight.Enabled = false;
            txtMH.Enabled = false;

            button3.Enabled = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel
            Nurse_Dashboard parent = (Nurse_Dashboard)this.ParentForm;
            parent.changetoViewPatient();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtLast.Enabled = true;
            txtFirst.Enabled = true;
            cboGender.Enabled = true;
            txtAge.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtAddress.Enabled = true;
            txtContact.Enabled = true;
            txtWeight.Enabled = true;
            txtHeight.Enabled = true;
            txtMH.Enabled = true;

            button3.Enabled = false;
            button2.Enabled = true;
        }
    }
}
