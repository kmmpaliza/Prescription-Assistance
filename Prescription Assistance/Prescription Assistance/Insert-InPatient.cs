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
            int age;
            bool isNumericA = int.TryParse(txtAge.Text, out age);

            double weight;
            bool isNumericW = double.TryParse(txtWeight.Text, out weight);

            double height;
            bool isNumericH = double.TryParse(txtHeight.Text, out height);

            if (isNumericA)
            {
                cp.Age = txtAge.Text;
                if (isNumericW)
                {
                    cp.Weight = txtWeight.Text;
                    if (isNumericH)
                    {
                        cp.Height = txtHeight.Text;
                        cp.Last_name = txtLast.Text;
                        cp.First_name = txtFirst.Text;
                        cp.Gender = cboGender.Text;
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
                    else
                    {
                        MessageBox.Show("Invalid value for Height.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid value for Weight.");
                }
            }
            else
            {
                MessageBox.Show("Invalid value for Age.");
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
            Openpdf.Filter = "JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|All files|*.*;";

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pBoxPhoto_Click(object sender, EventArgs e)
        {

        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSpec_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtMedFin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtLast_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
