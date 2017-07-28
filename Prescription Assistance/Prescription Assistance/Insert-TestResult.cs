using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClassLibrary;

namespace Prescription_Assistance
{
    public partial class Insert_TestResult : UserControl
    {
        Class_Test ct = new Class_Test();
        Class_Patient cp = new Class_Patient();
        Class_Patient cp2 = new Class_Patient();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        string type;
        byte[] data;
        string filename, id;

        public Insert_TestResult()
        {
            InitializeComponent();
        }
        
        public void RefreshData()
        {
            ct.selectTest(cp2.Patient_id);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;

            lblCounter.Visible = true;
            int count = ds.Tables[0].Rows.Count;
            lblCounter.Text = "" + count + " result/s";
        }

        private void displayRecords(string text)
        {
            dataGridView1.DataSource = null;
            id = text;
            
            cp2.Patient_id = text;

            ds = ct.selectTest(text);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                ds3 = cp2.viewPatientDetails();
                string name = ds3.Tables[0].Rows[0][3].ToString() + " " + ds3.Tables[0].Rows[0][2].ToString();
                lblText.Text = "Displaying Test Results of " + cp2.Patient_id.ToString() + ", " + name;

                RefreshData();
            }
            else
            {
                lblText.Text = @"No results for '" + text + @"'";
                lblCounter.Visible = false;
            }
            
            button2.Enabled = true;
            button3.Enabled = true; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals(""))
            {
                lblText.Text = "Search field is required.";
            }
            else
            {
                type = cboType.Text;
                if (type.Equals("Patient ID"))
                {
                    displayRecords(txtSearch.Text);
                }
                else if (type.Equals("Last Name") || type.Equals("First Name"))
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
                        dataGridView1.ReadOnly = true;
                        dataGridView1.DataSource = ds2.Tables[0];
                        dataGridView1.Columns[0].Visible = true;
                        dataGridView1.Columns[1].Visible = false;
                        int counter = ds2.Tables[0].Rows.Count;
                        lblCounter.Visible = true;
                        lblCounter.Text = "" + counter + " result/s";
                        lblText.Text = @"Search results for '" + txtSearch.Text + @"'";
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        lblText.Text = @"No results for '" + txtSearch.Text + @"'";
                        lblCounter.Visible = false;
                    }
                }
            }  
                   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                displayRecords(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            }
            if (e.ColumnIndex == 1)
            {

                string filename = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string path = @"D:\" + filename + ".pdf";
                FileStream fsRead = new FileStream(path, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fsRead);
                byte[] test = ct.selectTestFile(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                fsRead.Write(test, 0, test.Length);
                fsRead.Close(); 
                MessageBox.Show("File " + path + @" saved at D:\");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openpdf = new OpenFileDialog();
            Openpdf.Filter = "PDF files|*.pdf|All files|*.*;";

            if (Openpdf.ShowDialog() == DialogResult.OK)
            {
                filename = Openpdf.FileName;
                txtFile.Text = filename;

                FileInfo finfo = new FileInfo(Openpdf.FileName);

                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryReader br = new BinaryReader(fs);

                data = br.ReadBytes(Convert.ToInt32(finfo.Length));
                br.Close();
                fs.Close();
                fs.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (data == null)
            {
                MessageBox.Show("Error. No Test Result inserted.");
            }
            else
            {
                ct.insertFile(filename, id, data);
                MessageBox.Show("Test Result successfully uploaded.");
                RefreshData();
            }
        }

        private void Insert_TestResult_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            lblCounter.Visible = false;
            button2.Enabled = false;
            button3.Enabled = false; 
        }
    }
}
