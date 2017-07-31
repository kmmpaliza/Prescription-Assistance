using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.IO;

namespace Prescription_Assistance
{
    public partial class Update_InPatientDetailsDoctor : UserControl
    {
        string id;
        Class_Patient cp = new Class_Patient();
        Class_MedRec cm = new Class_MedRec();
        Class_Prescription cpa = new Class_Prescription();
        Class_Test ct = new Class_Test();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        byte[] data;

        public Update_InPatientDetailsDoctor(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void load()
        {
            cp.Patient_id = id;
            cm.Patient_id = id;
            cpa.Patient_id = id;

            ds = cp.viewPatientDetails();
            ds2 = cm.viewMedRecDetails();
            ds3 = cpa.viewPescriptionDetails();
            ds4 = ct.selectTest(id);

            txtLast.Text = ds.Tables[0].Rows[0][2].ToString();
            txtFirst.Text = ds.Tables[0].Rows[0][3].ToString();
            cboGender.Text = ds.Tables[0].Rows[0][4].ToString();
            txtAge.Text = ds.Tables[0].Rows[0][5].ToString();
            
            txtAddress.Text = ds.Tables[0].Rows[0][7].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][8].ToString();
            txtWeight.Text = ds.Tables[0].Rows[0][9].ToString();
            txtHeight.Text = ds.Tables[0].Rows[0][10].ToString();
            txtMH.Text = ds.Tables[0].Rows[0][11].ToString();
            txtMF.Text = ds.Tables[0].Rows[0][12].ToString();
            txtSI.Text = ds.Tables[0].Rows[0][13].ToString();

            if (ds.Tables[0].Rows[0][6] != DBNull.Value)
            {
                dateTimePicker1.Text = ds.Tables[0].Rows[0][6].ToString();
            }
            else
            {
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }

            if (ds.Tables[0].Rows[0][14] != DBNull.Value)
            {
                data = (byte[])(ds.Tables[0].Rows[0][14]);
                MemoryStream mem = new MemoryStream(data);
                pBoxPhoto.Image = Image.FromStream(mem);
            }
            else
            {
                pBoxPhoto.Image = Properties.Resources.blank;
            }   

            dgvMR.ReadOnly = true;
            dgvMR.DataSource = ds2.Tables[0];

            dgvTR.ReadOnly = true;
            dgvTR.DataSource = ds4.Tables[0];

            dgvP.ReadOnly = true;
            dgvP.DataSource = ds3.Tables[0];

            button2.Visible = false;
            button1.Visible = false;
            txtMF.Enabled = false;
            txtSI.Enabled = false;
        }

        private void Update_InPatientDetailsDoctor_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMF.Enabled = true;
            txtSI.Enabled = true;

            button3.Enabled = false;
            button2.Visible = true;
            button1.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cp.Patient_id = id;
            cp.Medical_findings = txtMF.Text;
            cp.Special_instructions = txtSI.Text;

            cp.updatePatientDoctor();

            MessageBox.Show("Patient Details successfully updated.");

            button3.Enabled = true;

            load();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            //parent.changetoViewPatient();
            load();
        }
    }
}
