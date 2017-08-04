using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Text.RegularExpressions;
using System.IO;

namespace Prescription_Assistance
{
    public partial class Update_InPatientDetailsNurse : UserControl
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
        string filename;
        byte[] data;

        public Update_InPatientDetailsNurse(string id)
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
                dateTimePicker1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }

            if (ds.Tables[0].Rows[0][14] != DBNull.Value) {
                data = (byte[])(ds.Tables[0].Rows[0][14]);
                MemoryStream mem = new MemoryStream(data);
                pBoxPhoto.Image = Image.FromStream(mem);
            }
            else {
                pBoxPhoto.Image = Properties.Resources.blank;
                ImageConverter ic = new ImageConverter();
                data = (byte[])ic.ConvertTo(pBoxPhoto.Image, typeof(byte[]));
            }

            dgvMR.ReadOnly = true;
            dgvMR.DataSource = ds2.Tables[0];

            dgvTR.ReadOnly = true;
            dgvTR.DataSource = ds4.Tables[0];

            dgvP.ReadOnly = true;
            dgvP.DataSource = ds3.Tables[0];

            button2.Visible = false;
            button1.Visible = false;

            txtLast.Enabled = false;
            txtFirst.Enabled = false;
            cboGender.Enabled = false;
            txtAge.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtAddress.Enabled = false;
            txtContact.Enabled = false;
            txtWeight.Enabled = false;
            txtHeight.Enabled = false;
            txtMH.Enabled = false;

            button3.Enabled = true;
            btnBrowse.Enabled = false;
        }

        private void Update_InPatientDetailsNurse_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cp.Age = txtAge.Text;
            cp.Weight = txtWeight.Text;
            cp.Height = txtHeight.Text;
            cp.Contact = txtContact.Text;

            cp.Patient_id = id;
            cm.Patient_id = id;

            cp.Last_name = txtLast.Text;
            cp.First_name = txtFirst.Text;
            cp.Gender = cboGender.Text;
            cp.Birthday = dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");
            cp.Address = txtAddress.Text;
            cp.Medical_history = txtMH.Text;
            cp.Imgfile = data;

            cp.updatePatient();

            MessageBox.Show("Patient Details successfully updated.");

            load();                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnBrowse.Enabled = true;
            txtLast.Enabled = true;
            txtFirst.Enabled = true;
            cboGender.Enabled = true;
            txtAge.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtAddress.Enabled = true;
            txtContact.Enabled = true;
            txtWeight.Enabled = true;
            txtHeight.Enabled = true;
            txtMH.Enabled = true;

            button3.Enabled = false;
            button2.Visible = true;
            button1.Visible = true;
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

        private void txtWeight_Validating(object sender, CancelEventArgs e)
        {
            double weight;
            bool isNumericW = double.TryParse(txtWeight.Text, out weight);

            if (!isNumericW)
            {
                MessageBox.Show("Invalid value for Weight.");
                txtWeight.Focus();
            }
            else { }
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
            else { }
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
            string number = txtContact.Text;
            bool isAContact = Regex.Match(number, @"^(\d{9})$").Success;

            if (!isAContact)
            {
                MessageBox.Show("Invalid Contact Number.");
                txtContact.Focus();
            }
            else
            { }
        }
    }
}
