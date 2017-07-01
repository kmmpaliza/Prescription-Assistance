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
    public partial class Insert_InPatient : UserControl
    {
        Class_Patient cp = new Class_Patient();
        Class_MedRec cm = new Class_MedRec();
        Class_Prescription cpr = new Class_Prescription();
        DataSet ds = new DataSet();

        string prescription_id;
        string id; 

        public Insert_InPatient()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cp.Last_name = txtLast.Text;
            cp.First_name = txtFirst.Text;
            cp.Gender = cboGender.Text;
            cp.Age = txtAge.Text;
            cp.Room_id = cboRoom.Text;
            cp.Bed_id = cboBed.Text;

            cp.Birthday = "";
            cp.Address = "";
            cp.Contact = "";

            id = cp.insertNewPatient();
            MessageBox.Show("In-Patient successfully added. " + id);

            cm.Patient_id = id;
            cm.Medical_findings = txtMedFin.Text;
            cm.Special_instructions = txtSpec.Text;
            cm.Weight = "";
            cm.Height = "";
            cm.Heart_rate = "";
            cm.Blood_sugar = "";
            cm.Blood_pressure = "";
            cm.Temperature = "";
            cm.Medical_history = "";

            cm.insertNewMedRec();

            txtMedName.Enabled = true;
            txtDosage.Enabled = true;
            txtNote.Enabled = true;
            cboForm.Enabled = true;
            cboRoute.Enabled = true;
            cboInterval.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            cpr.Patient_id = id;
            RefreshData();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In-Patient details successfully saved.");
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoViewPatient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoViewPatient();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoViewPatient();
        }
    
    }
}
