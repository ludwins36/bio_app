using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bio
{
    public partial class Registro : Form
    {

        private DPFP.Template Template;
       

        public Registro()
        {
            InitializeComponent();
        }
        SqlConnection conn = bd_comun.ObtenerConexion();

        private void cargarempleado()
        {

            SqlDataAdapter elEmpleado = new SqlDataAdapter("select Id,cedula from Empleado", conn);
            DataSet dsEmpleado = new DataSet();
            elEmpleado.Fill(dsEmpleado, "Empleados");
            lista.DataSource = dsEmpleado;
            lista.DataMember = "Empleados";
            conn.Close();
        }


        private void limpiar()
        {
            nombre.Text = "";
            huella.Text = "";
           

        }



        private void btn_registrart_huella_Click(object sender, EventArgs e)
        {

           
        }

      

        private void btn_agregar_Click(object sender, EventArgs e)
        {
           
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            cargarempleado();

            timer1.Enabled = true;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] streamHuella = Template.Bytes;


               


                limpiar();
                cargarempleado();
                Template = null;
                btn_agregar.Enabled = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            CapturarHuella ven = new CapturarHuella();
            ven.OnTemplate += this.OnTemplate;
            ven.Show();
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate()
            {
                Template = template;
                btn_agregar.Enabled = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("La plantilla de huellas dactilares está lista para la verificación de huellas dactilares..", "Inscripción de huellas dactilares");
                    huella.Text = "Huella capturada correctamente";
                }
                else
                {
                    MessageBox.Show("La plantilla de huellas dactilares no es válida. Repetir inscripción de huellas dactilares.", "Inscripción de huellas dactilares");
                }
            }));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CapturarHuella ven = new CapturarHuella();
            ven.OnTemplate += this.OnTemplate;
            ven.Show();
            timer1.Enabled = false;
        }
    }
}
