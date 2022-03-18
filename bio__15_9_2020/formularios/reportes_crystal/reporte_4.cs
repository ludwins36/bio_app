using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace bio
{
    public partial class reporte_4 : Form
    {
        public reporte_4()
        {
            InitializeComponent();
        }
        call llamar = new call();

        private void reporte_4_Load(object sender, EventArgs e)
        {

             llamar.Windows_State = "Maximizar";

            ReportDocument crystalrpt = new ReportDocument();
            
            SqlConnection con = bd_comun.ObtenerConexion();
            SqlDataAdapter sda = new SqlDataAdapter("select * from transaccion ", con);
            DataSet dt = new DataSet();
            sda.Fill(dt, "transaccion");

            crystalrpt.Load("C:\\reportes\\registro_de_firma.rpt");
            crystalrpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crystalrpt;
            crystalReportViewer1.Refresh();

            

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
