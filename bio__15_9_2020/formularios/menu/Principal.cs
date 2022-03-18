using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

namespace bio
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }


        call llamar = new call();

        Acceso acceder = new Acceso();

        Configuracion config = new Configuracion();

        int z;
        private static string dato;
        private static string idd;
        private static string dato2;
        private static string existencia;


        public string Existencia
        {
            get { return existencia; }
            set { existencia = value; }
        }



        public string Dato2
        {
            get { return dato2; }
            set { dato2 = value; }
        }

        public string Idd
        {
            get { return idd; }
            set { idd = value; }
        }



        public string Dato
        {
            get { return dato; }
            set { dato = value; }
        }





        private void refresh()
        {

            SqlConnection conn = bd_comun.ObtenerConexion();
            string dato3 = "1";
            string idd3 = "9";

            string query = "update huella_data set pein ='" + dato3 + "' where Id =" + idd3 + ";";
            SqlCommand comando = new SqlCommand(query, conn);

            comando.Parameters.AddWithValue("@pein", dato3);





            try
            {
                comando.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());



            }





        }














        private void verificar()
        {
            SqlConnection conexion = bd_comun.ObtenerConexion();

            try
            {



                string lectura = "password/123";

                string consultar = "SELECT long from huella_data WHERE  long = @long";
                SqlCommand cmd = new SqlCommand(consultar, conexion);
                cmd.CommandText = consultar;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@long", lectura);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                SqlDataReader leer = cmd.ExecuteReader();

                if (leer.Read() == true)
                {
                    existencia = "true";



                }


                else

                {
                    MessageBox.Show("Verificando Autenticacion del sistema Bio a continuacion introduzca el serial de activacion", "bio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }





            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }



            conexion.Close();



        }












        private void validacion()
        {




            SqlConnection conexion = bd_comun.ObtenerConexion();
            string consultar = "SELECT pein,Id FROM huella_data ";
            SqlCommand cmd = new SqlCommand(consultar, conexion);
            cmd.CommandText = consultar;
            cmd.Parameters.Clear();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read() == true)
            {
                dato = leer["pein"].ToString();

                idd = leer["Id"].ToString();



            }



            int a, b;
            a = int.Parse(dato);
            b = a + 1;

            z = a;


            dato2 = b.ToString();










            SqlConnection conn = bd_comun.ObtenerConexion();


            string query = "update huella_data set pein ='" + dato2 + "' where Id =" + idd + ";";
            SqlCommand comando = new SqlCommand(query, conn);

            comando.Parameters.AddWithValue("@pein", dato2);





            try
            {
                comando.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());



            }





            if (z >= 80)
            {

                verificar();


                if (existencia == "true")
                {
                    panel1.Enabled = true;

                }
                else

                {

                    panel1.Enabled = false;

                    abrirfromhija(new Activacion());

                }





               

                             

               
            }






        }





        //...............funcion para meter el from dentro del panel

        private void abrirfromhija(object fromhija)
        {
            if (this.panelformularios.Controls.Count > 0)

                this.panelformularios.Controls.RemoveAt(0);
            Form fh = fromhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelformularios.Controls.Add(fh);
            this.panelformularios.Tag = fh;
            fh.Show();


        }

        //.......................................................................












        private void verificar_permiso()
        {






            SqlConnection conexion = bd_comun.ObtenerConexion();
            

            string consultar = "SELECT * FROM biometrico ";
            SqlCommand cmd = new SqlCommand(consultar, conexion);
            cmd.CommandText = consultar;
            cmd.Parameters.Clear();
             SqlDataAdapter  da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            SqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read() == true)
            {
                
                config.Biometrico = leer["biometrico"].ToString();

            }



            conexion.Close();




        }

















        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            string statuscamara_call = llamar.Status_camara;


            if (statuscamara_call == "iniciado")
            {
                llamar.Camara = "detener";

            }

            if (llamar.Status_camara == null )
            {
                abrirfromhija(new Registrar_clientes());

            }




            if (statuscamara_call == "Detenido")
            {
                abrirfromhija(new Registrar_clientes());

            }



            
        }

        private void button1_Click(object sender, EventArgs e)
        {

       

            string statuscamara_call = llamar.Status_camara;



            if (statuscamara_call == "iniciado")
            {
                llamar.Camara = "detener";

            }


            if (llamar.Status_camara == null)
            {
                abrirfromhija(new Autenticar());

            }

            
            if (statuscamara_call == "Detenido")
            {

                abrirfromhija(new Autenticar());

            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            string statuscamara_call = llamar.Status_camara;


            if (statuscamara_call == "iniciado")
            {
                llamar.Camara = "detener";

            }

            if (llamar.Status_camara == null)
            {
                abrirfromhija(new Configuraciones());

            }


            if (statuscamara_call == "Detenido")
            {
              abrirfromhija(new Configuraciones());

            }

          
         
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            llamar.Camara = "desactivar";
            abrirfromhija(new consultas_copia());
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            llamar.Camara = "desactivar";
            abrirfromhija(new usuario_comun());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //  string dni_call = llamar.Dni_call;

            //  string cedula_empleado_call = llamar.Cedula_empleado_llamar;

            //  string Consultar_horario_historico_call = llamar.Consultar_horario_historico;


            string MainFormcall = llamar.mainForm;
            string CapturarHuellacall = llamar.capturarHuella;
            string MainForm_co_call = llamar.mainForm_co;
            string autenticar_call = llamar.Autenticar;
            string CapturarHuella_co_call = llamar.capturarHuella_co;

            string registrocall = llamar.Registro;

            string connfigura_call = llamar.Configura;

            string biometria_call = llamar.Biometria;

            string configuraciones_call = llamar.configuraciones;

            string reporte2_call = llamar.Reporte2;

            string reporte_2_call = llamar.Reporte_2;
            string reporte_4_call = llamar.Reporte_4; 

            string Form11_call = llamar.form11;

            string windows_state_call = llamar.Windows_State;

            string lector_call = llamar.Lector;

            string registro_from_call = llamar.Registro_from;






            if (registro_from_call == "llamar formulario registro_from ")
            {
                llamar.Registro_from = "";
                registro_from_call = "";

                abrirfromhija(new registro_from());






            }





            if (lector_call == "llamar formulario lector")
            {
                llamar.Lector = "";
                lector_call = "";

                abrirfromhija(new lector());

              




            }






            if (windows_state_call == "Maximizar")
            {
                llamar.Windows_State = "";
                windows_state_call = "";

                this.WindowState = FormWindowState.Maximized;
                




            }





            if (Form11_call == "llamar formulario Form11")
            {

                llamar.form11 = "";
                Form11_call = "";
                abrirfromhija(new Form11());




            }








            if (reporte_4_call == "llamar formulario reporte_4")
            {

                llamar.Reporte_4 = "";
                reporte_4_call = "";
                abrirfromhija(new reporte_4());




            }








            if (reporte_2_call == "llamar formulario reporte_2")
            {

                llamar.Reporte_2 = "";
                reporte_2_call = "";
                abrirfromhija(new reporte_2());




            }




            if (reporte2_call == "llamar formulario reporte2")
            {

                llamar.Reporte2 = "";
                reporte2_call = "";
                abrirfromhija(new reporte2());
                
               
                

            }




            if (configuraciones_call == "llamar  formulario configuraciones")
            {
                abrirfromhija(new Configuraciones());

                llamar.configuraciones = "";
                configuraciones_call = "";

            }


            if (biometria_call == "llamar formulario biometria")
            {
                abrirfromhija(new biometria ());

                llamar.Biometria  = "";
                biometria_call = "";

            }




            if (connfigura_call == "llamar formulario configura")
            {
                abrirfromhija(new Configura());

                llamar.Configura = "";
                connfigura_call = "";

            }




            //--------------------------------------dNI--------------------------------------------------------


            if (MainFormcall == "llamar formulario MainForm")
              {
               abrirfromhija(new MainForm());

                llamar.mainForm = "";
                MainFormcall = "";

            }



            //----------------------------------------------------------------------------------------------


            if (CapturarHuellacall == "llamar formulario CapturarHuella")
            {
                abrirfromhija(new CapturarHuella());

                llamar.capturarHuella = "";
                CapturarHuellacall = "";

            }




            

            //---------------------------------------------------------------------

            string Registrar_clientescall = llamar.registrar_clientes;

            if (Registrar_clientescall == "llamar formulario Registrar_clientes")
            {
                abrirfromhija(new Registrar_clientes());

                llamar.registrar_clientes = "";
                Registrar_clientescall = "";

            }

            //---------------------------------------------------------------------

           

         

            if (autenticar_call == "llamar formulario autenticar")
            {
                abrirfromhija(new Autenticar());

                llamar.Autenticar = "";
                autenticar_call = "";

            }





            //---------------------------------------------------------------------



           
           
           


            if (registrocall == "llamar formulario registro")
            {
                abrirfromhija(new presentacion  ());

                llamar.Registro = "";
                registrocall = "";

            }


        }

        private void panelformularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
           
           

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            timer1 .Enabled  = true ;

          

            validacion();
           
            

            
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            // abrirfromhija(new CapturarHuella  ());

            abrirfromhija(new frmScannerApp());
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
         //   abrirfromhija(new Form_3());
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            abrirfromhija(new reporte_2());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            abrirfromhija(new reporte_3());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            abrirfromhija(new reporte_4());
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            frmScannerApp ven = new frmScannerApp();
            ven.Show();
        }

        private void button6_Click_3(object sender, EventArgs e)
        {
             abrirfromhija(new TopologyPopupForm());
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
           
        }

        private void userControl13_Load(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {


            string statuscamara_call = llamar.Status_camara;


            if (statuscamara_call == "iniciado")
            {
                llamar.Camara = "detener";

            }


            if (llamar.Status_camara == null)
            {
                abrirfromhija(new consultas_copia());

            }



            if (statuscamara_call == "Detenido")
            {

                abrirfromhija(new consultas_copia());

            }

           
        }

        private void panelformularios_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            llamar.Camara = "desactivar";
            Application.Exit();
        }

        private void userControl13_Load_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userControl14_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            llamar.Camara = "detener";
        }
    }
}
