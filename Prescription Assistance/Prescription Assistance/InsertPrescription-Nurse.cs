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
    public partial class InsertPrescription_Nurse : UserControl
    {
        Class_Prescription cpr = new Class_Prescription();
        Class_Patient cp = new Class_Patient();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();

        public InsertPrescription_Nurse()
        {
            InitializeComponent();
        }

        private void displayRecords(string text)
        {
            dgvPrescription.DataSource = null;
            cpr.Patient_id = text;

            Class_Patient cp2 = new Class_Patient();
            cp2.Patient_id = text;

            ds = cpr.viewPescriptionDetails();
            if (ds.Tables[0].Rows.Count >= 1)
            {
                ds3 = cp2.viewPatientDetails();
                string name = ds3.Tables[0].Rows[0][3].ToString() + " " + ds3.Tables[0].Rows[0][2].ToString();
                lblText.Text = "Displaying Prescription Records of " + cp2.Patient_id.ToString() + ", " + name;

                dgvPrescription.ReadOnly = true;
                dgvPrescription.DataSource = ds.Tables[0];
                dgvPrescription.Columns[0].Visible = false;

                lblCounter.Visible = true;
                int count = ds.Tables[0].Rows.Count;
                lblCounter.Text = "" + count + " result/s";
            }
            else
            {
                lblText.Text = @"No Prescription Records for '" + text + @"'";
                lblCounter.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals(""))
            {
                lblText.Text = "Search field is required.";
            }
            else
            {
                cp.Patient_id = txtSearch.Text;
                cp.Last_name = txtSearch.Text;
                cp.First_name = txtSearch.Text;
                cp.Age = txtSearch.Text;
                cp.Contact = txtSearch.Text;
                cp.Gender = txtSearch.Text;

                ds2 = cp.searchPatient();
                int count = ds2.Tables[0].Rows.Count;

                if (count == 1)
                {
                    displayRecords(ds2.Tables[0].Rows[0][0].ToString());
                }
                else if (count > 1)
                {
                    dgvPrescription.ReadOnly = true;
                    dgvPrescription.DataSource = ds2.Tables[0];
                    dgvPrescription.Columns[0].Visible = true;
                    int counter = ds2.Tables[0].Rows.Count;
                    lblCounter.Visible = true;
                    lblCounter.Text = "" + counter + " result/s";
                    lblText.Text = @"Search results for '" + txtSearch.Text + @"'";
                }
                else
                {
                    dgvPrescription.DataSource = null;
                    lblText.Text = @"No results for '" + txtSearch.Text + @"'";
                    lblCounter.Visible = false;
                }
            }   
        }

        private void InsertPrescription_Nurse_Load(object sender, EventArgs e)
        {
            dgvPrescription.Columns[0].Visible = false;
            lblCounter.Visible = false;
        }

        private void dgvPrescription_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                displayRecords(dgvPrescription.CurrentRow.Cells[1].Value.ToString());
            }
        }
    }
}
