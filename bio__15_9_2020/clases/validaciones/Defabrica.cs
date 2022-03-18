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
    class Defabrica
    {

        public static void foto_fabrica(PictureBox foto)
        {
            SqlConnection miconexion = bd_comun.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("select Foto from imagen_defabrica", miconexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("imagen_defabrica");
            byte[] MyData = new byte[0];
            dp.Fill(ds, "imagen_defabrica");
            DataRow myRow = ds.Tables["imagen_defabrica"].Rows[0];
            MyData = (byte[])myRow["Foto"];
            MemoryStream stream = new MemoryStream(MyData);
            foto.Image = Image.FromStream(stream);

            miconexion.Close();



        }

        public static void buscar_huella_tmp(PictureBox huella)
        {
            SqlConnection miconexion = bd_comun.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("select huella from huella_tmp", miconexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("huella_tmp");
            byte[] MyData = new byte[0];
            dp.Fill(ds, "huella_tmp");
            DataRow myRow = ds.Tables["huella_tmp"].Rows[0];
            MyData = (byte[])myRow["huella"];
            MemoryStream stream = new MemoryStream(MyData);
            huella.Image = Image.FromStream(stream);

            miconexion.Close();



        }











        public static void select_tramites(ComboBox combo)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string consultar = "SELECT * FROM TiposDeclaraciones ";
                SqlCommand cmd = new SqlCommand(consultar, conn);
                cmd.CommandText = consultar;
                SqlDataReader leer = cmd.ExecuteReader();


                while (leer.Read())
                {
                    combo.Items.Add(leer["Nombre"]);



                }

                conn.Close();



            }
        }








        public static void guardar_huella_tmp(byte[] huella)
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                string query = "INSERT INTO huella_tmp (huella) VALUES(@huella)";
                SqlCommand cmd = new SqlCommand(query, conn);






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











        public static void eliminar_huella_tmp()
        {
            SqlConnection conn = bd_comun.ObtenerConexion();

            {
                try
                {
                    string sql = "delete from huella_tmp ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("huella_tmp");
                    da.Fill(dt);



                }
                catch (Exception)
                {


                }


                conn.Close();
            }
        }













    }

}
