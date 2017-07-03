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
    public partial class Update_InPatientDetailsDoctor : UserControl
    {
        string id;
        Class_Patient cp = new Class_Patient();
        Class_MedRec cm = new Class_MedRec();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        public Update_InPatientDetailsDoctor(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Update_InPatientDetailsDoctor_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            txtMF.Enabled = true;
            txtSI.Enabled = true;

            button3.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cp.Patient_id = id;
            cp.Medical_findings = txtMF.Text;
            cp.Special_instructions = txtSI.Text;

            cp.updatePatientDoctor();

            MessageBox.Show("Patient Details successfully updated.");

            txtMF.Enabled = false;
            txtSI.Enabled = false;

            button3.Enabled = true;
            button2.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoViewPatient();
        }
    }
}
