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
    class Clientes
    {



        // metodo utilizado para insertar los registros  en la la tabla DatosPersonal

        public static void Insert(string Cedula, string Nombre, string Apellidos,byte[] foto, byte[] huella)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO DatosPersonal (Cedula,Nombre,Apellidos,foto,huella) VALUES(@Cedula,@Nombre,@Apellidos,@foto,@huella)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = foto;
                cmd.Parameters.Add("@huella", SqlDbType.VarBinary).Value = huella;
              
               

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






     

    }
}
