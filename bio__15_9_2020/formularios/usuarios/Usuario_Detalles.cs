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
    public partial class Usuario_Detalles : Form
    {
        public Usuario_Detalles()
        {
            InitializeComponent();
        }

        call llamar = new call();

        private void limpiar()
        {
            perfil.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            cargo.Text = "";
            nombre_de_usuario.Text = "";
            contraseña.Text = "";
            cedula.Text = "";

            Nombre_operador.Text = "";




        }


        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            llamar.Datos_de_Usuarios = "llamar formulario Datos_de_Usuarios";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Usuario_Detalles_Load(object sender, EventArgs e)
        {
            seguridad.select_perfil(perfil);

            textBox1.Text = llamar.Usuario_Detalles;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection miconexion = bd_comun.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("select * from usuario where cedula= @cedula", miconexion);
            cmd.Parameters.AddWithValue("@cedula", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("usuario");

            dp.Fill(ds, "usuario");

            if (ds.Tables["usuario"].Rows.Count > 0)
            {
                DataRow myRow = ds.Tables["usuario"].Rows[0];

                //llenar datos correspondientes  a la cosnulta
                nombre.Text = myRow["nombre"].ToString();
                apellido.Text = myRow["apellido"].ToString();
                cargo.Text = myRow["cargo"].ToString();
                nombre_de_usuario.Text = myRow["nombre_de_usuario"].ToString();
                contraseña.Text = myRow["contraseña"].ToString();
                cedula.Text = myRow["cedula"].ToString();
                perfil.Text = myRow["perfil"].ToString();
                id.Text = myRow["Id_usuario"].ToString();
                Nombre_operador.Text = myRow["Nombre_operador"].ToString();   


            }

            else
            {
                MessageBox.Show("No existe", "BIO", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            usuario_Demo.actualizar_usuario(nombre.Text, apellido.Text, cargo.Text, nombre_de_usuario.Text, contraseña.Text, cedula.Text, perfil.Text, Nombre_operador.Text, id.Text);

            limpiar();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            usuario_Demo.eliminar_usuario(id.Text);
            limpiar();
        }
    }
}
