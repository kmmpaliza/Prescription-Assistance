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
        DataSet ds = new DataSet();

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
            cp.Weight = txtWeight.Text;
            cp.Height = txtHeight.Text;
            cp.Birthday = "";
            cp.Address = "";
            cp.Contact = "";
            cp.Medical_history = "";
            cp.Medical_findings = txtMedFin.Text;
            cp.Special_instructions = txtSpec.Text;

            cp.insertNewPatient();
            MessageBox.Show("In-Patient successfully added.");
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoViewPatient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
            parent.changetoViewPatient();
        }

        private void Insert_InPatient_Load(object sender, EventArgs e)
        {

        }    
    }
}
