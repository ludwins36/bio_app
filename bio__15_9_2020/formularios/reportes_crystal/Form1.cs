using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace bio
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        call llamar = new call();
        private void Form1_Load(object sender, EventArgs e)
        {
            // llamar.Windows_State = "Maximizar";
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load("C:\\prueba\\CrystalReport2.rpt");
            crystalReportViewer1.ReportSource = crystalrpt;
            crystalReportViewer1.Refresh();

            
        }
    }
}
