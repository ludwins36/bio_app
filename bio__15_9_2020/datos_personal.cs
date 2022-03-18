using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

namespace bio
{
    class datos_personal
    {


        private static string Nombre;
        private static string Apellidos;
        private static string identidad;
        private static string id_cliente;
        private static string RutaFoto;
        private static string RutaHuella;
       private static string RutaFirma;
        private static string existencia;
        private static string Fotografia;
        private static string existencia_transaccion;


        public string Existencia_transaccion
        {
            get { return existencia_transaccion; }
            set { existencia_transaccion = value; }
        }










        public string fotografia
        {
            get { return Fotografia; }
            set { Fotografia = value; }
        }





       public string Existencia
       {
           get { return existencia; }
           set { existencia = value; }
       }



  



        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string apellidos
        {
            get { return Apellidos; }
            set { Apellidos = value; }
        }


        public string Identidad
        {
            get { return identidad; }
            set { identidad = value; }
        }


        public string Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }


        public string rutaFoto
        {
            get { return RutaFoto; }
            set { RutaFoto = value; }
        }



        public string rutaHuella
        {
            get { return RutaHuella; }
            set { RutaHuella = value; }
        }



        public string rutaFirma
        {
            get { return RutaFirma; }
            set { RutaFirma = value; }
        }







        public static void buscar_en_otra_bd(string Cedula)
        {

            //metodo utilizado para  importar el id del producto correspondiente  necesario para Actualizar y elimira registros
            SqlConnection conexion = bd_comun.ObtenerConexion_de_la_otra_bd();
            string consultar = "select * from DatosPersonal where Cedula= @Cedula";
            SqlCommand cmd = new SqlCommand(consultar, conexion);
            cmd.CommandText = consultar;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Cedula", Cedula);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read() == true)
            {
                
                Nombre = leer["Nombre"].ToString();
                Apellidos = leer["Apellidos"].ToString();
                identidad = leer["Cedula"].ToString();
                id_cliente = leer["Id"].ToString();
                RutaFoto = leer["RutaFoto"].ToString();
                RutaHuella = leer["RutaHuella"].ToString();
                RutaFirma = leer["RutaFirma"].ToString();

                existencia = "true";

                              

            }


            else
            {
                MessageBox.Show("No existe", "bio", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


            conexion.Close();



        }



        //----------------------------------------------------------------------------------------------------------
        public static DataTable Cargar_por_cedula_de_la_otra_bd(string cedulaa)
        {
            SqlConnection conn = bd_comun.ObtenerConexion_de_la_otra_bd();





            {
                DataTable dt = new DataTable();
                string query = "select *  from RegTransac WHERE  cedula = @cedula";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@cedula", cedulaa);
                adap.Fill(dt);
                return dt;
            }


            conn.Close();


        }





        public static void buscar_transaccion_en_otra_bd(string Id_transaccion)
        {

            //metodo utilizado para  importar el id del producto correspondiente  necesario para Actualizar y elimira registros
            SqlConnection conexion = bd_comun.ObtenerConexion_de_la_otra_bd();
            string consultar = "select * from RegTransac where Id_transaccion= @Id_transaccion";
            SqlCommand cmd = new SqlCommand(consultar, conexion);
            cmd.CommandText = consultar;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id_transaccion", Id_transaccion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read() == true)
            {
                existencia_transaccion = "true";

                Fotografia = leer["Fotografia"].ToString();
                

                



            }


            else
            {
                MessageBox.Show("No existe", "bio", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


            conexion.Close();



        }








    }
}
