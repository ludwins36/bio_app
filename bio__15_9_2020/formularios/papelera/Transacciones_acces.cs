using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace bio
{
    class Transacciones_acces
    {


        OleDbConnection miconexion = bd_comun_acces.ObtenerConexion();


        private static string Id;
        private static string Nombre;
        private static string Texto;
        private static string Declarantes;
        private static string PlantillaDot;


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
                string query = "INSERT INTO transacciones(Nombre,Texto,Declarantes,PlantillaDot,id,fecha,hora,notario,foto,huella,cedula) VALUES(@Nombre,@Texto,@Declarantes,@PlantillaDot,@id,@fecha,@hora,@notario,@foto,@huella,@cedula)";
                SqlCommand cmd = new SqlCommand (query, conn);

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
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string consultar = "SELECT Id FROM DatosPersonal ";
                SqlCommand cmd = new SqlCommand(consultar, conn);
                cmd.CommandText = consultar;
                SqlDataReader leer = cmd.ExecuteReader();


                while (leer.Read())
                {
                    combo.Items.Add(leer["Id"]);



                }

                conn.Close();

            }
        }
















    }
}
