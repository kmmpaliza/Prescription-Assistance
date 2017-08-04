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
    public partial class Insert_InPatient : UserControl
    {
        Class_Patient cp = new Class_Patient();
        Class_MedRec cm = new Class_MedRec();
        DataSet ds = new DataSet();
        string filename;
        byte[] data;

        public Insert_InPatient()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cp.Height = txtHeight.Text;
            cp.Last_name = txtLast.Text;
            cp.First_name = txtFirst.Text;
            cp.Gender = cboGender.Text;
            cp.Age = txtAge.Text;
            cp.Weight = txtWeight.Text;
            cp.Birthday = "";
            cp.Address = "";
            cp.Contact = "";
            cp.Medical_history = "";
            cp.Medical_findings = txtMedFin.Text;
            cp.Special_instructions = txtSpec.Text;
            cp.Imgfile = data;

            cp.insertNewPatient();
            MessageBox.Show("In-Patient successfully added.");

            if (Form1.usertype.Equals("Doctor"))
            {
                Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
                parent.changetoViewPatient();
            }
            else
            {
                Nurse_Dashboard parent = (Nurse_Dashboard)this.ParentForm;
                parent.changetoViewPatient();
            }      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.usertype.Equals("Doctor"))
            {
                Doctor_Dashboard parent = (Doctor_Dashboard)this.ParentForm;
                parent.changetoViewPatient();
            }
            else
            {
                Nurse_Dashboard parent = (Nurse_Dashboard)this.ParentForm;
                parent.changetoViewPatient();
            }
        }

        private void Insert_InPatient_Load(object sender, EventArgs e)
        {
            if (Form1.usertype.Equals("Doctor"))
            {
                txtMedFin.Enabled = true;
                txtSpec.Enabled = true;

            }
            else {
                txtMedFin.Enabled = false;
                txtSpec.Enabled = false;
            }

            pBoxPhoto.Image = Properties.Resources.blank;
            ImageConverter ic = new ImageConverter();
            data = (byte[])ic.ConvertTo(pBoxPhoto.Image, typeof(byte[]));
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openpdf = new OpenFileDialog();
            Openpdf.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|All files|*.*;";

            if (Openpdf.ShowDialog() == DialogResult.OK)
            {
                filename = Openpdf.FileName;

                FileInfo finfo = new FileInfo(Openpdf.FileName);

                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryReader br = new BinaryReader(fs);

                data = br.ReadBytes(Convert.ToInt32(finfo.Length));
                MemoryStream mem = new MemoryStream(data);
                pBoxPhoto.Image = Image.FromStream(mem);
                br.Close();
                fs.Close();
                fs.Dispose();
            }
        }

        private void txtWeight_Validating(object sender, CancelEventArgs e)
        {
            double weight;
            bool isNumericW = double.TryParse(txtWeight.Text, out weight);

            if (!isNumericW)
            {
                MessageBox.Show("Invalid value for Weight.");
                txtWeight.Focus();
            }
            else {}
        }

        private void txtHeight_Validating(object sender, CancelEventArgs e)
        {
            double height;
            bool isNumericH = double.TryParse(txtHeight.Text, out height);

            if (!isNumericH)
            {
                MessageBox.Show("Invalid value for Height.");
                txtHeight.Focus();
            }
            else {}
        }

        private void txtAge_Validating(object sender, CancelEventArgs e)
        {
            int age;
            bool isNumericA = int.TryParse(txtAge.Text, out age);

            if (!isNumericA)
            {                
                MessageBox.Show("Invalid value for Age.");
                txtAge.Focus();
            }
            else {}            
        }
    }
}
