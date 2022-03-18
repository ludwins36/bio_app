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
using System.Drawing.Imaging;

namespace bio
{
    public partial class Activacion : Form
    {
        public Activacion()
        {
            InitializeComponent();
        }

        private void restaurar()
        {




            SqlConnection conn = bd_comun.ObtenerConexion();
            string pasword = "password/123";
            string id_pas = "9";

            string query = "update huella_data set long ='" + pasword + "' where Id =" + id_pas + ";";
            SqlCommand comando = new SqlCommand(query, conn);

            comando.Parameters.AddWithValue("@long", pasword);





            try
            {
                comando.ExecuteNonQuery();

                MessageBox.Show("autenticacion exitosa vuelva a iniciar el sistema", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());



            }



         


        }







        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "password/123")
            {
                restaurar();
                Application.Exit();
            }


            else
            {
                MessageBox.Show("Estimado Usuario introduzca el serial de activacion correcto. contacte al proveedor  Gracias", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
 
            }

        }
    }
}
