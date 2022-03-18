using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
namespace bio
{
    class Transacciones
    {


        SqlConnection miconexion = bd_comun.ObtenerConexion();


        private static string Id;
        private static string Nombre;
        private static string Texto;
        private static string Declarantes;
        private static string PlantillaDot;
        private static string Nombre_Notario;
        private static string Cargo;
        private static string Acta;

        private static string existencia;



        public string Existencia
        {
            get { return existencia; }
            set { existencia = value; }
        }




        public string nombre_Notario
        {
            get { return Nombre_Notario; }
            set { Nombre_Notario = value; }
        }


        public string cargo
        {
            get { return Cargo; }
            set { Cargo = value; }
        }



        public string acta
        {
            get { return Acta; }
            set { Acta = value; }
        }







        public string id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }


        public string texto
        {
            get { return Texto; }
            set { Texto = value; }
        }

        public string declarantes
        {
            get { return Declarantes; }
            set { Declarantes = value; }
        }

        public string plantillaDot
        {
            get { return PlantillaDot; }
            set { PlantillaDot = value; }
        }







 //...........................................cargar informacion del notario.............................................................................................................


        public static void cagar_informacion_del_notario(string Nombre_Notario)
        {

            try
            {

                SqlConnection conexion = bd_comun.ObtenerConexion();


                string consultar = "SELECT * FROM Notarios WHERE  Nombre_Notario = @Nombre_Notario";
                SqlCommand cmd = new SqlCommand(consultar, conexion);
                cmd.CommandText = consultar;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Nombre_Notario", Nombre_Notario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                SqlDataReader leer = cmd.ExecuteReader();

                if (leer.Read() == true)
                {

                    Nombre_Notario = leer["Nombre_Notario"].ToString();
                    Cargo = leer["Cargo"].ToString();
                    Acta = leer["Acta"].ToString();
                    



                }



                conexion.Close();

            }
            catch (Exception)
            {

            }


        }





















        public static void Insert_sticker(string Nombre, string Texto, string Declarantes, string PlantillaDot, string id, string fecha, string hora, string notario, byte[] foto, byte[] huella,string cedula)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO transaccion(Nombre,Texto,Declarantes,PlantillaDot,id,fecha,hora,notario,foto,huella,cedula) VALUES(@Nombre,@Texto,@Declarantes,@PlantillaDot,@id,@fecha,@hora,@notario,@foto,@huella,@cedula)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Texto", Texto);
                cmd.Parameters.AddWithValue("@Declarantes", Declarantes);
                cmd.Parameters.AddWithValue("@PlantillaDot", PlantillaDot);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@notario", notario);
                cmd.Parameters.AddWithValue("@cedula", cedula);


                cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = foto;
                cmd.Parameters.Add("@huella", SqlDbType.VarBinary).Value = huella;

                try
                {
                    cmd.ExecuteNonQuery();

                   

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }

                conn.Close();

            }

        }





        public static void Insert_transacion(string Nombre, string Texto, string Declarantes, string PlantillaDot, string id, string fecha, string hora, string notario, byte[] foto, byte[] huella, string cedula)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO transacciones(Nombre,Texto,Declarantes,PlantillaDot,id,fecha,hora,notario,foto,huella,cedula,Cargo,Acta) VALUES(@Nombre,@Texto,@Declarantes,@PlantillaDot,@id,@fecha,@hora,@notario,@foto,@huella,@cedula,@Cargo,@Acta)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Texto", Texto);
                cmd.Parameters.AddWithValue("@Declarantes", Declarantes);
                cmd.Parameters.AddWithValue("@PlantillaDot", PlantillaDot);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@notario", notario);
                cmd.Parameters.AddWithValue("@cedula", cedula);
                cmd.Parameters.AddWithValue("@Cargo", Cargo);
                cmd.Parameters.AddWithValue("@Acta", Acta);


                cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = foto;
                cmd.Parameters.Add("@huella", SqlDbType.VarBinary).Value = huella;

                try
                {
                    cmd.ExecuteNonQuery();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }

                conn.Close();

            }

        }















        public static DataTable Cargar(TextBox textBox1)
        {




            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM transacciones where Id =@Id ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                return dt;
            }


            conn.Close();


        }




        public static DataTable Cargar_tools()
        {




            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM transacciones ";
                SqlCommand cmd = new SqlCommand(query, conn);
                 SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                return dt;
            }


            conn.Close();


        }















        public static void eliminar_stiker()
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                try
                {
                    string sql = "delete from transaccion ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("sticker");
                    da.Fill(dt);



                }
                catch (Exception)
                {


                }

                conn.Close();
            }
        }








        //metodo utilizado para consultar los turnos  y cargarlos en el combobox

        public static void select_id_datos_del_personal(ComboBox combo)
        {
           SqlConnection  conn = bd_comun.ObtenerConexion();

            {
                string consultar = "SELECT Id FROM DatosPersonal ";
                SqlCommand  cmd = new SqlCommand(consultar, conn);
                cmd.CommandText = consultar;
                SqlDataReader  leer = cmd.ExecuteReader();


                while (leer.Read())
                {
                    combo.Items.Add(leer["Id"]);



                }

                conn.Close();

            }
        }








        //----------------------------------------------------------------------------------------------------------
        public static DataTable Cargar_por_cedula(string cedulaa)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();





            {
                DataTable dt = new DataTable();
                string query = "select*  from transacciones WHERE  cedula = @cedula";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@cedula", cedulaa);
                adap.Fill(dt);
                return dt;
            }


        }



        //-------------------------------------------Cargar_por_id---------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public static DataTable Cargar_por_Id_transaccion(string Id_transaccion)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();





            {
                DataTable dt = new DataTable();
                string query = "select*  from transacciones WHERE  Id_transaccion = @Id_transaccion";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Id_transaccion", Id_transaccion);
                adap.Fill(dt);
                return dt;
            }


        }



//-------------------------------------------------------------------------------------------------------------------------------


        public static DataTable Cargar_por_Id_transaccion_de_la_otra_bd(string Id_transaccion)
        {
            SqlConnection conn = bd_comun.ObtenerConexion_de_la_otra_bd();





            {
                DataTable dt = new DataTable();
                string query = "select*  from RegTransac WHERE  Id_transaccion = @Id_transaccion";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Id_transaccion", Id_transaccion);
                adap.Fill(dt);
                return dt;
            }


        }






//-----------------------------------------------cargar por fecha---------------------------------------------------------------------------------------------------------------------------





        public static DataTable Cargar_por_fecha(string fecha)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();


            {
                DataTable dt = new DataTable();
                string query = "select * from transacciones WHERE  fecha = @fecha";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                adap.Fill(dt);
                return dt;
            }


            conn.Close();

        }






        public static void mostrar_imagenes(string recibo, PictureBox pbfoto, PictureBox pbhuella)
        {



            try
            {


                SqlConnection miconexion = bd_comun.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("select * from transacciones where Id_transaccion= @Id_transaccion", miconexion);
                cmd.Parameters.AddWithValue("@Id_transaccion", recibo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("transacciones");
                byte[] MyData = new byte[0];
                byte[] MyData2 = new byte[0];
                dp.Fill(ds, "transacciones");

                if (ds.Tables["transacciones"].Rows.Count > 0)
                {
                    DataRow myRow = ds.Tables["transacciones"].Rows[0];
                    MyData = (byte[])myRow["foto"];
                    MyData2 = (byte[])myRow["huella"];
                    MemoryStream stream = new MemoryStream(MyData);
                    MemoryStream stream2 = new MemoryStream(MyData2);
                    pbfoto.Image = Image.FromStream(stream);
                    pbhuella.Image = Image.FromStream(stream2);





                }


                else
                {

                    existencia = "false";


 
                }





                miconexion.Close();

            }
            catch (Exception)
            {

            }



















        }






    }
}
