using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace bio
{
    class usuario_Demo
    {





        //----------------------------- metodo utilizado para insertar los registros  en la la tabla usuario

        public static void Insertaeeee(string nombre, string apellido, string cargo, string nombre_de_usuario, string contraseña, string cedula, string perfil, string Nombre_operador)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();


            string query = "INSERT INTO usuario(nombre,apellido,cargo,nombre_de_usuario,contraseña,cedula,perfil,Nombre_operador) VALUES(@nombre,@apellido,@cargo,@nombre_de_usuario,@contraseña,@cedula,@perfil,@Nombre_operador)";
            SqlCommand cmd = new SqlCommand(query, conn);


            cmd.Parameters.AddWithValue("@nombre", nombre);

            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            cmd.Parameters.AddWithValue("@nombre_de_usuario", nombre_de_usuario);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.Parameters.AddWithValue("@perfil", perfil);
            cmd.Parameters.AddWithValue("@Nombre_operador", Nombre_operador);







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





        ////////////////////////////////////////////////////////////////////////////////
        //..................................//Actualizar...usuario.............................................................................................

        //metodo utilizado para actualizar los usuarios


        public static void actualizar_usuario(string nombre, string apellido, string cargo, string nombre_de_usuario, string contraseña, string cedula, string perfil, string Nombre_operador, string Id_usuario)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "update usuario set nombre ='" + nombre + "',apellido='" + apellido + "',cargo='" + cargo + "',nombre_de_usuario='" + nombre_de_usuario + "',contraseña='" + contraseña + "',cedula='" + cedula + "',perfil='" + perfil + "',Nombre_operador='" + Nombre_operador + "' where Id_usuario =" + Id_usuario + ";";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@cargo", cargo);
                cmd.Parameters.AddWithValue("@nombre_de_usuario", nombre_de_usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                cmd.Parameters.AddWithValue("@cedula", cedula);
                cmd.Parameters.AddWithValue("@perfil", perfil);
                cmd.Parameters.AddWithValue("@Nombre_operador", Nombre_operador);
                cmd.Parameters.AddWithValue("@Id_usuario", Id_usuario); 



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














        //..................................actualizar_supervisor.............................................................................................

        //metodo utilizado para actualizar_supervisor


        public static void actualizar_supervisor(string nombre_supervisor)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {



                string query = "update Empleado set supervisor ='" + nombre_supervisor + "' where supervisor =" + nombre_supervisor + ";";
                SqlCommand cmd = new SqlCommand(query, conn);



                cmd.Parameters.AddWithValue("@supervisor", nombre_supervisor);



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




















        //........................................Eliminar....usuarios.........................................................................................


        //metodo utilizado para eliminar los usuarios


        public static void eliminar_usuario(string Id)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                if (MessageBox.Show("¿Desea Eliminar este usuario?", "bio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

                    try
                    {

                        string sql = "delete from usuario where Id_usuario=" + Id + ";";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.CommandText = sql;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Id_usuario", Id);


                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("usuario");
                        da.Fill(dt);




                        MessageBox.Show("El registro de este usuario ha sido eliminado");
                    }
                    catch (Exception)
                    {


                    }
            }
        }
        //..............................................................................................................







        //........................................consultas_usuarios................................................

        // metodo utilizado para consultar los usuarios y agregarlos al combobox

        public static void select_usuarios(ComboBox combo)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string consultar = "SELECT * FROM usuario ";
                SqlCommand cmd = new SqlCommand(consultar, conn);
                cmd.CommandText = consultar;
                SqlDataReader leer = cmd.ExecuteReader();


                while (leer.Read())
                {
                    combo.Items.Add(leer["Nombre_operador"]);



                }



            }
        }




        //..................................................................................................................................................


        public static void select_Empleados(ComboBox combo)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string consultar = "SELECT * FROM Empleado ";
                SqlCommand cmd = new SqlCommand(consultar, conn);
                cmd.CommandText = consultar;
                SqlDataReader leer = cmd.ExecuteReader();


                while (leer.Read())
                {
                    combo.Items.Add(leer["cedula"]);



                }



            }
        }

















        //---------------------------------cargar por cedula-------------------------------------------------------------------------
        public static DataTable Cargar(TextBox cedulaa)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();





            {
                DataTable dt = new DataTable();
                string query = "select * from usuario WHERE  cedula = @cedula";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@cedula", cedulaa.Text);
                adap.Fill(dt);
                return dt;
            }


        }


        //----------------------------------------------------------------------------------------------------------


        //---------------------------------cargar todos -------------------------------------------------------------------------
        public static DataTable cargartodos()
        {
            SqlConnection conn = bd_comun.ObtenerConexion();





            {
                DataTable dt = new DataTable();
                string query = "select*  from usuario";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                return dt;
            }


        }


        //----------------------------------------------------------------------------------------------------------




        //-------------------------------------------Cargar_por_nombre---------------------------------------------------------------


        public static DataTable Cargar_por_nombre(TextBox nombre)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();





            {
                DataTable dt = new DataTable();
                string query = "select*  from usuario WHERE  users = @users";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@users", nombre.Text);
                adap.Fill(dt);
                return dt;
            }


        }

        //----------------------------------------------------------------------------------------------------------





    }
}
