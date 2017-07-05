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
        DataSet ds = new DataSet();
        byte[] data;
        string filename, id;

        public Insert_TestResult()
        {
            InitializeComponent();
        }
        
        public void RefreshData()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = txtSearch.Text;
            ds = ct.selectTest(txtSearch.Text);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];  
                      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                string filename = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string path = @"D:\" + filename + ".pdf";
                FileStream fsRead = new FileStream(path, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fsRead);
                byte[] test = ct.selectTestFile(dataGridView1.CurrentRow.Cells[1].Value.ToString());
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
            ct.insertFile(filename, txtSearch.Text, data);
        }
    }
}
