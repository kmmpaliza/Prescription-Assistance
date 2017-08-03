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
    public partial class InsertPrescription : UserControl
    {
        Class_Prescription cpr = new Class_Prescription();
        Class_Patient cp = new Class_Patient();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        string prescription_id;

        public InsertPrescription()
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
                dgvPrescription.Columns["View"].Visible = false;
                dgvPrescription.Columns["Edit"].Visible = true;

                RefreshData();

                txtMedName.Enabled = true;
                txtDosage.Enabled = true;
                txtNote.Enabled = true;
                cboForm.Enabled = true;
                cboRoute.Enabled = true;
                cboInterval.Enabled = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                lblText.Text = @"No Prescription Records for '" + text + @"'";
                lblCounter.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnClear.Enabled = false;

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
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnClear.Enabled = false;
                }
                else if (count > 1)
                {
                    dgvPrescription.ReadOnly = true;
                    dgvPrescription.DataSource = ds2.Tables[0];
                    dgvPrescription.Columns["View"].Visible = true;
                    dgvPrescription.Columns["Edit"].Visible = false;
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

        private void RefreshData()
        {
            ds = cpr.viewPescriptionDetails();
            dgvPrescription.ReadOnly = true;
            dgvPrescription.DataSource = ds.Tables[0];
            dgvPrescription.Columns["View"].Visible = false;
            dgvPrescription.Columns["Edit"].Visible = true;

            lblCounter.Visible = true;
            int count = ds.Tables[0].Rows.Count;
            lblCounter.Text = "" + count + " result/s";
        }

        private void ClearTexts()
        {
            txtMedName.Text = "";
            txtDosage.Text = "";
            txtNote.Text = "";
            cboForm.SelectedIndex = -1;
            cboRoute.SelectedIndex = -1;
            cboInterval.SelectedIndex = -1;
            txtSearch.Text = "";
            btnClear.Enabled = false;
            dgvPrescription.ClearSelection();
            dgvPrescription.CurrentCell = null;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cpr.Medicine_name = txtMedName.Text;
            cpr.Dosage = txtDosage.Text;
            cpr.Route = cboRoute.Text;
            cpr.Form = cboForm.Text;
            cpr.Interval = cboInterval.Text;
            cpr.Note = txtNote.Text;

            cpr.insertNewPrescription();
            ClearTexts();
            RefreshData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cpr.Medicine_name = txtMedName.Text;
            cpr.Dosage = txtDosage.Text;
            cpr.Route = cboRoute.Text;
            cpr.Form = cboForm.Text;
            cpr.Interval = cboInterval.Text;
            cpr.Note = txtNote.Text;

            cpr.updatePrescription();
            ClearTexts();
            RefreshData();

            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cpr.deletePrescription();
            ClearTexts();
            RefreshData();
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTexts();
        }

        private void InsertPrescription_Load(object sender, EventArgs e)
        {
            dgvPrescription.Columns["View"].Visible = false;
            dgvPrescription.Columns["Edit"].Visible = false;
            lblCounter.Visible = false;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnClear.Enabled = false;
        }

        private void dgvPrescription_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                displayRecords(dgvPrescription.CurrentRow.Cells[2].Value.ToString());
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;              
            }

            if (e.ColumnIndex == 1)
            {
                prescription_id = dgvPrescription.Rows[e.RowIndex].Cells[2].Value.ToString();
                cpr.Prescription_id = prescription_id;

                txtMedName.Text = dgvPrescription.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDosage.Text = dgvPrescription.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNote.Text = dgvPrescription.Rows[e.RowIndex].Cells[8].Value.ToString();
                cboForm.Text = dgvPrescription.Rows[e.RowIndex].Cells[6].Value.ToString();
                cboRoute.Text = dgvPrescription.Rows[e.RowIndex].Cells[5].Value.ToString();
                cboInterval.Text = dgvPrescription.Rows[e.RowIndex].Cells[7].Value.ToString();

                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnClear.Enabled = true;
            }
        }
    }
}
