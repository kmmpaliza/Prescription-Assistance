using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClassLibrary;

namespace Prescription_Assistance
{
    public partial class FileUpload : Form
    {

        public FileUpload()
        {
            InitializeComponent();
        }

        TestClass ts = new TestClass();

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openpdf = new OpenFileDialog();
            Openpdf.Filter = "PDF files|*.pdf|All files|*.*;";

            if (Openpdf.ShowDialog() == DialogResult.OK)
            {
                string filename = Openpdf.FileName;
                txtFile.Text = filename;

                FileInfo finfo = new FileInfo(Openpdf.FileName);

                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryReader br = new BinaryReader(fs);

                byte[] data = br.ReadBytes(Convert.ToInt32(finfo.Length));
                br.Close();
                fs.Close();
                fs.Dispose();

                ts.insertFile("1", "1", data);



                MessageBox.Show("Upload successfully");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = txtfilename.Text;
            int id = Convert.ToInt32(txtid.Text);
            FileStream fsRead = new FileStream(@"D:\" + filename + ".pdf", FileMode.Create);
            byte[] test = ts.selectTest(id);
            fsRead.Write(test, 0, test.Length);
            fsRead.Close();

            MessageBox.Show("Save successfully");

        }
    }
}
