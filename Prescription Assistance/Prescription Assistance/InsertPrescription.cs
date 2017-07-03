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
        DataSet ds = new DataSet();
        string prescription_id;

        public InsertPrescription()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cpr.Patient_id = txtSearch.Text;
            
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

        private void RefreshData()
        {
            ds = cpr.viewPescriptionDetails();
            dgvPrescription.ReadOnly = true;
            dgvPrescription.DataSource = ds.Tables[0];
            dgvPrescription.Columns[0].Visible = false;
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
        }

        private void dgvPrescription_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            prescription_id = dgvPrescription.Rows[e.RowIndex].Cells[0].Value.ToString();
            cpr.Prescription_id = prescription_id;

            txtMedName.Text = dgvPrescription.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDosage.Text = dgvPrescription.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNote.Text = dgvPrescription.Rows[e.RowIndex].Cells[6].Value.ToString();
            cboForm.Text = dgvPrescription.Rows[e.RowIndex].Cells[4].Value.ToString();
            cboRoute.Text = dgvPrescription.Rows[e.RowIndex].Cells[3].Value.ToString();
            cboInterval.Text = dgvPrescription.Rows[e.RowIndex].Cells[5].Value.ToString();
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cpr.deletePrescription();
            ClearTexts();
            RefreshData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTexts();
        }



    }
}
