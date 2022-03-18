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
    class Configuracion
    {


        private static string notario;
        private static string notario_de_Turno;

        private static string biometrico;
        private static string lectura;



        public string Lectura
        {
            get { return lectura; }
            set { lectura = value; }
        }



        public string Biometrico
        {
            get { return biometrico; }
            set { biometrico = value; }
        }





        public string Notario
        {
            get { return notario; }
            set { notario = value; }
        }


        public string Notario_de_Turno
        {
            get { return notario_de_Turno; }
            set { notario_de_Turno = value; }
        }



     









        public static void Insert_error_cadena(string Fecha, string Cedula, string Nombre, string Hora, string Actividad)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO RegActividad (Fecha,Cedula,Nombre,Hora,Actividad) VALUES(@Fecha,@Cedula,@Nombre,@Hora,@Actividad)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Hora", Hora);
                cmd.Parameters.AddWithValue("@Actividad", Actividad);


                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro Guardado exitosamente", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }

                conn.Close();

            }

        }






        public static void Insert_notarios(string Nombre_Notario, string Cargo, string Acta)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO Notarios (Nombre_Notario,Cargo,Acta) VALUES(@Nombre_Notario,@Cargo,@Acta)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre_Notario", Nombre_Notario);
                cmd.Parameters.AddWithValue("@Cargo", Cargo);
                cmd.Parameters.AddWithValue("@Acta", Acta);
               
                

                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro Guardado exitosamente", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }

                conn.Close();

            }

        }

        public static void Insert_notarios_de_turno(string Nombre)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO notario_de_turno (Nombre) VALUES(@Nombre)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", Nombre);
             


                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Listo!!", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }

            }



            conn.Close();




        }


        //......................................biometrico....................................................................................................................








        public static void Insert_biometrico(string biometrico)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO biometrico (biometrico) VALUES(@biometrico)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@biometrico", biometrico);



                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Listo!!", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }

            }



            conn.Close();




        }









        //.........................................................................................................................................................................






        public static void Insert_registros_notaria(string Notaria, string Direccion, string Ciudad, string Telefono, string telefono2, byte[] logo)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO Configuracion (Notaria,Direccion,Ciudad,Telefono,telefono2,logo) VALUES(@Notaria,@Direccion,@Ciudad,@Telefono,@telefono2,@logo)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Notaria", Notaria);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@telefono2", telefono2);

                cmd.Parameters.Add("@logo", SqlDbType.VarBinary).Value = logo;


                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro Guardado exitosamente", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }


                conn.Close();

            }

        }







        public static void select_notarios(ComboBox combo)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string consultar = "SELECT * FROM Notarios ";
                SqlCommand cmd = new SqlCommand(consultar, conn);
                cmd.CommandText = consultar;
                SqlDataReader leer = cmd.ExecuteReader();

                string operador = notario;

                while (leer.Read())
                {



                 //   combo.Items.Add(leer[operador]);



                }

                conn.Close();

            }
        }




        public static void eliminar_notario_de_turno()
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                try
                {
                    string sql = "delete from notario_de_turno ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("notario_de_turno");
                    da.Fill(dt);



                }
                catch (Exception)
                {


                }

                conn.Close();
            }
        }



        public static void eliminar_datos_de_notaria()
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                try
                {
                    string sql = "delete from Configuracion ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Configuracion");
                    da.Fill(dt);



                }
                catch (Exception)
                {


                }


                conn.Close();
            }
        }






        public bool Verificar_notaro()
        {
            bool resultado = false;
            SqlConnection miconexion = bd_comun.ObtenerConexion();
            SqlCommand comando = new SqlCommand("select * from notario_de_turno");
            comando.Connection = miconexion;
            SqlDataReader ejecuta = comando.ExecuteReader();
            if (ejecuta.Read())
            {
                notario_de_Turno = ejecuta["Nombre"].ToString();
               

                
                resultado = true;

            }
            else
            {

            }

            return resultado;

            miconexion.Close();



        }




        public static void eliminar_biometrico()
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                try
                {
                    string sql = "delete from biometrico ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("biometrico");
                    da.Fill(dt);



                }
                catch (Exception)
                {


                }


                conn.Close();
            }
        }



        public static void eliminar_lectura()
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                try
                {
                    string sql = "delete from lectura ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("lectura");
                    da.Fill(dt);



                }
                catch (Exception)
                {


                }

                conn.Close();
            }
        }








        public static void Insert_lectura(string lectura)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO lectura(lectura) VALUES(@lectura)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@lectura", lectura);
              

                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("listo");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }

                conn.Close();

            }

        }


       







    }
}
