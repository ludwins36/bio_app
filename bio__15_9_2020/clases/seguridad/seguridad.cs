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
    class seguridad
    {






        //..................................objetos................................................................



        public static string recibir_regla;




        public string Recibir_regla
        {
            get { return recibir_regla; }
            set { recibir_regla = value; }
        }


        //................................................................................................................




        //...................................Insertar perfiles.............................................................



        public static void Insert_perfiles(string perfi)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO Perfil(perfil) VALUES(@perfil)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@perfil", perfi);




                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro Guardado exitosamente", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }

            }

        }



        //-------------------------------------------------------------------------------------------------------------------------------------------


        //........................................consultas_perfiles................................................

        // metodo utilizado para consultar los perfiles y agregarlos al combobox

        public static void select_perfil(ComboBox combo)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string consultar = "SELECT * FROM Perfil ";
                SqlCommand cmd = new SqlCommand(consultar, conn);
                cmd.CommandText = consultar;
                SqlDataReader leer = cmd.ExecuteReader();


                while (leer.Read())
                {
                    combo.Items.Add(leer["perfil"]);



                }



            }
        }




        //..................................................................................................................................................


        //........................................consultas_id_perfiles................................................

        // metodo utilizado para consultar los id_ de los perfiles 

        public static void select_id_perfil(Label idperfil, ComboBox cmb_perfil)
        {
            SqlConnection conexion = bd_comun.ObtenerConexion();
            string consultar = "SELECT Id_perfil FROM  Perfil WHERE  perfil = @perfil";
            SqlCommand cmd = new SqlCommand(consultar, conexion);
            cmd.CommandText = consultar;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@perfil", cmb_perfil.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read() == true)
            {
                idperfil.Text = leer["Id_perfil"].ToString();
            }
        }




        //..................................................................................................................................................














        // metodo utilizado para cargar los perfiles y mostrarlos en un datagrid

        public static DataTable Cargarperfiles()
        {



            SqlConnection conn = bd_comun.ObtenerConexion();


            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Perfil ";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                return dt;
            }






        }



        //-------------------------------------------------------------------------------------------------------------------------------------------


        //........................................Eliminar....perfiles.........................................................................................


        //metodo utilizado para eliminar los perfiles


        public static void eliminar_perfiles(string Id)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                if (MessageBox.Show("¿Desea Eliminar este perfil?", "bio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

                    try
                    {

                        string sql = "delete Perfil from Perfil where Id_perfil=" + Id + ";";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.CommandText = sql;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Id_perfil", Id);


                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("Perfil");
                        da.Fill(dt);




                        MessageBox.Show(" registro de  Perfil eliminado");
                    }
                    catch (Exception)
                    {


                    }
            }
        }
        //..............................................................................................................










        //---------------------------------------------------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------------------------------------------------------------

        // reglas 

        //-------------------------------------------------------------------------------------------------------------------------------------


        //...................................Insertar Regla.............................................................



        public static void Insert_Regla(string Regla)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO Regla(Regla) VALUES(@Regla)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Regla", Regla);




                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro Guardado exitosamente", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }

            }

        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        //........................................consultas_Reglas................................................

        // metodo utilizado para consultar las Reglas y agregarlos al combobox

        public static void select_Reglas(ComboBox combo)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string consultar = "SELECT * FROM Regla ";
                SqlCommand cmd = new SqlCommand(consultar, conn);
                cmd.CommandText = consultar;
                SqlDataReader leer = cmd.ExecuteReader();


                while (leer.Read())
                {
                    combo.Items.Add(leer["Regla"]);



                }



            }
        }


        //---------------------------------------------------------------------------------------------------------------------------
        //////////////////////////////////////////// tabla (transperfilregla)   ////////////////////////////////////


        //................................................ tabla intermedia...........................................................................
        //.............................................................................................................................................................


        //...................................Insertar transperfilregla....(tabla intermedia entre perfil y regla).............................................................



        public static void Insert_transperfilregla(string perfil, string regla, string Id_perfil)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO Transperfilregla(perfil,regla,Id_perfil) VALUES(@perfil,@regla,@Id_perfil)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@perfil", perfil);
                cmd.Parameters.AddWithValue("@regla", regla);
                cmd.Parameters.AddWithValue("@Id_perfil", Id_perfil);



                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro Guarddo exitosamente", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());



                }

            }

        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------



        //////////////////////////////////////////// tabla (transperfilregla)   ////////////////////////////////////

        //..................................//Actualizar...reglas para perfiles.............................................................................................

        //metodo utilizado para actualizar los reglas para perfiles


        public static void actualizar_reglas_para_perfiles(string Id, string regla)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {


                if (MessageBox.Show("¿El perfil Ya Contiene una Regla Asignada Desea Reemplazarla?", "bio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {



                    string query = "update Transperfilregla set regla ='" + regla + "' where Id =" + Id + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@regla", regla);
                    cmd.Parameters.AddWithValue("@Id", Id);


                    try
                    {
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Registro Actualizado exitosamente", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());



                    }

                }

            }


        }

        ///.................................validacion de reglas.........................................................






        public void filtrar_regla()
        {

            Acceso datos = new Acceso();
            SqlConnection conexion = bd_comun.ObtenerConexion();



            string consulta2 = "SELECT regla FROM  Transperfilregla WHERE  perfil = @perfil";
            SqlCommand cmd2 = new SqlCommand(consulta2, conexion);
            cmd2.CommandText = consulta2;
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@perfil", datos.Perfil);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            SqlDataReader leer2 = cmd2.ExecuteReader();

            if (leer2.Read() == true)
            {

                Recibir_regla = leer2["regla"].ToString(); //le asigno la regla correspondiente a variable "Recibir_regla"

            }
            else
            {
                MessageBox.Show("no se encontro permisos para este usuario  es posible que se  halla eliminado su perfil pongase en contacto con el administrador y verifique su perfil en la opccion de mantenimiento /usuarios/registro de usuarios!!..  verifique si el perfil se encuenta en la opccion mantenimiento /usuario/reglas... de no existir cree uno nuevo o remplacelo por uno existente !!.... de lo contrario este usuario no tendra permitido utilizar el sistema ", "bio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }


        }





        //..................................................................................................................................................



        // metodo utilizado para cargar las reglas que contienen los perfiles y mostrarlos en un datagrid

        public static DataTable Cargar_reglas_de_perfiles()
        {



            SqlConnection conn = bd_comun.ObtenerConexion();


            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Transperfilregla ";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                return dt;
            }






        }



        //-------------------------------------------------------------------------------------------------------------------------------------------


        //........................................consultas_id_perfiles tabla (trasperfilregla)................................................

        // metodo utilizado para consultar los id_ de los perfiles ubicado en la tabla (transperfilregla)

        public static void select_id_perfil_transperfilregla(Label idperfil, ComboBox cmb_perfil)
        {
            SqlConnection conexion = bd_comun.ObtenerConexion();
            string consultar = "SELECT Id FROM  Transperfilregla WHERE  perfil = @perfil";
            SqlCommand cmd = new SqlCommand(consultar, conexion);
            cmd.CommandText = consultar;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@perfil", cmb_perfil.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read() == true)
            {
                idperfil.Text = leer["Id"].ToString();
            }
        }




        //..................................................................................................................................................









    }
}
