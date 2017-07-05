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
    public partial class _3rdFloorD : UserControl
    {  
        Class_Rooms cr = new Class_Rooms();
        DataSet ds = new DataSet();

        public _3rdFloorD()
        {
            InitializeComponent();
        }

        private void _3rdFloorD_Load(object sender, EventArgs e)
        {
            cr.Bed_id = "300-A";
            ds = cr.viewBedandPatient();
            labelA.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-B";
            ds = cr.viewBedandPatient();
            labelB.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-C";
            ds = cr.viewBedandPatient();
            labelC.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-D";
            ds = cr.viewBedandPatient();
            labelD.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-E";
            ds = cr.viewBedandPatient();
            labelE.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-F";
            ds = cr.viewBedandPatient();
            labelF.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-G";
            ds = cr.viewBedandPatient();
            labelG.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "300-H";
            ds = cr.viewBedandPatient();
            labelH.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "301";
            ds = cr.viewBedandPatient();
            label1.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "302";
            ds = cr.viewBedandPatient();
            label2.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "303";
            ds = cr.viewBedandPatient();
            label3.Text = ds.Tables[0].Rows[0][3].ToString();

            cr.Bed_id = "304";
            ds = cr.viewBedandPatient();
            label4.Text = ds.Tables[0].Rows[0][3].ToString();
        }
    }
}
