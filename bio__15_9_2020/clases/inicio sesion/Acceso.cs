using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bio
{
    class Acceso
    {

        SqlConnection miconexion = bd_comun.ObtenerConexion();
        

        private static string Id;
        private static string nombre;
        private static string apellido;

        private static string cedula;
        private static string usuario;
        private static string contraseña;
        private static string cargo;
        private static string perfil;
        private static string Nombre_operador;


        



        public string id
        {
            get { return Id; }
            set { Id = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }



        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }


        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }


        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }


        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }



        public string Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }

        public string nombre_operador
        {
            get { return Nombre_operador; }
            set { Nombre_operador = value; }
        }




        public bool Verificar()
        {
            bool resultado = false;

            SqlCommand comando = new SqlCommand("select * from usuario where nombre_de_usuario='" + usuario + "'and contraseña='" + contraseña + "'", miconexion);
            comando.Connection = miconexion;
            SqlDataReader ejecuta = comando.ExecuteReader();
            if (ejecuta.Read())
            {
                id = ejecuta["Id_usuario"].ToString();
                nombre = ejecuta["nombre"].ToString();
                apellido = ejecuta["apellido"].ToString();
                cargo = ejecuta["cargo"].ToString();
                usuario = ejecuta["nombre_de_usuario"].ToString();
                contraseña = ejecuta["contraseña"].ToString();
                cedula = ejecuta["cedula"].ToString();
               
                nombre_operador = ejecuta["Nombre_operador"].ToString();
              
               
               
                 

                resultado = true;

            }
            else
            {

            }

            return resultado;

            miconexion.Close();


        }




    }
}
