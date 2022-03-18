using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace bio
{
    public partial class reporte2 : Form
    {
        public reporte2()
        {
            InitializeComponent();
        }

        call llamar = new call();

        private void reporte2_Load(object sender, EventArgs e)
        {

            //  llamar.Windows_State = "Maximizar";
            
            ReportDocument crystalrpt = new ReportDocument();
            SqlConnection con = bd_comun.ObtenerConexion();
            SqlDataAdapter sda = new SqlDataAdapter("select * from transaccion ", con);
            DataSet dt = new DataSet();
            sda.Fill(dt, "transaccion");

            crystalrpt.Load("C:\\reportes\\reconocimiento_firma_huella_contenido.rpt");
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
