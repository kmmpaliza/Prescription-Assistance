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
        Class_Prescription cpr = new Class_Prescription();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();

        public Update_InPatientDetailsDoctor(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Update_InPatientDetailsDoctor_Load(object sender, EventArgs e)
        {
            cp.Patient_id = id;
            cm.Patient_id = id;
            cpr.Patient_id = id;

            ds = cp.viewPatientDetails();
            ds2 = cm.viewMedRecDetails();

            string name = ds.Tables[0].Rows[0][2].ToString() + ", " + ds.Tables[0].Rows[0][3].ToString();
            lblName.Text = name;

            txtMF.Text = ds2.Tables[0].Rows[0][10].ToString();
            txtSI.Text = ds2.Tables[0].Rows[0][11].ToString();

            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cm.Medical_findings = txtMF.Text;
            cm.Special_instructions = txtSI.Text;
            cm.Patient_id = id;
            
            cm.updateMedRecDoctor();

            MessageBox.Show("Patient Details successfully updated.");
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoViewPatientDetails(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoViewPatientDetails(id);
        }

        private void RefreshData()
        {
            ds3 = cpr.viewPescriptionDetails();
            dgvPrescription.ReadOnly = true;
            dgvPrescription.DataSource = ds3.Tables[0];
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
    }
}
