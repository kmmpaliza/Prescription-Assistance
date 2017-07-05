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
    public partial class _5thFloorD : UserControl
    {
        Class_Rooms cr = new Class_Rooms();
        DataSet ds = new DataSet();

        public _5thFloorD()
        {
            InitializeComponent();
        }

        private void _5thFloorD_Load(object sender, EventArgs e)
        {
            cr.Bed_id = "500-A";
            ds = cr.viewBedandPatient();
            labelA.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-B";
            ds = cr.viewBedandPatient();
            labelB.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-C";
            ds = cr.viewBedandPatient();
            labelC.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-D";
            ds = cr.viewBedandPatient();
            labelD.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-E";
            ds = cr.viewBedandPatient();
            labelE.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-F";
            ds = cr.viewBedandPatient();
            labelF.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-G";
            ds = cr.viewBedandPatient();
            labelG.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "500-H";
            ds = cr.viewBedandPatient();
            labelH.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "501";
            ds = cr.viewBedandPatient();
            label1.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "502";
            ds = cr.viewBedandPatient();
            label2.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "503";
            ds = cr.viewBedandPatient();
            label3.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "504";
            ds = cr.viewBedandPatient();
            label4.Text = ds.Tables[0].Rows[0][3].ToString();
        }
    }
}
