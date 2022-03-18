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
    public partial class usuario_comun : Form
    {
        public usuario_comun()
        {
            InitializeComponent();
        }

        call llamar = new call();

        SqlConnection conexion = bd_comun.ObtenerConexion();

        seguridad seguro = new seguridad();




        private void verificar_permiso()  //acceso completo
        {

            if (seguro.Recibir_regla == "acceso completo")
            {


            }

            else if (seguro.Recibir_regla == "acceso limitado")
            {
                perfil.Text = "invitado";
                perfil.Enabled = false;


            }
        }















        private void limpiar()
        {
            perfil.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            cargo.Text = "";
            nombre_de_usuario.Text = "";
            contraseña.Text = "";
            cedula.Text = "";




        }





        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (nombre.Text == "")
            {
                MessageBox.Show("El Campo nombre se encuentra vacio Digitelo para continuar", "bio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nombre.Focus();
            }


            if (apellido.Text == "")
            {
                MessageBox.Show("El Campo apellido se encuentra vacio Digitelo para continuar", "bio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nombre.Focus();
            }



            else if (cedula.Text == "")
            {
                MessageBox.Show("El Campo cedula  se encuentra vacio Digitelo para continuar", "bio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cedula.Focus();

            }


            else if (nombre_de_usuario.Text == "")
            {
                MessageBox.Show("El Campo nombre_de_usuario  se encuentra vacio Digitelo para continuar", "bio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cedula.Focus();

            }


            else if (contraseña.Text == "")
            {
                MessageBox.Show("El Campo contraseña  se encuentra vacio Digitelo para continuar", "bio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                contraseña.Focus();
            }

            else if (cargo.Text == "")
            {
                MessageBox.Show("El Campo cargo  se encuentra vacio Digitelo para continuar", "bio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cargo.Focus();
            }

            else if (perfil.Text == "")
            {
                MessageBox.Show("El Campo perfil  se encuentra vacio seleccine un perfil  para continuar", "bio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nombre_de_usuario.Focus();
            }



            else
            {



                string consulta2 = "SELECT regla FROM  Transperfilregla WHERE  perfil = @perfil";
                SqlCommand cmd2 = new SqlCommand(consulta2, conexion);
                cmd2.CommandText = consulta2;
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@perfil", perfil.Text);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                SqlDataReader leer2 = cmd2.ExecuteReader();

                if (leer2.Read() == true)
                {
                    string Nombre_operador = nombre.Text + "  " + apellido.Text;
                    usuario_Demo.Insertaeeee(nombre.Text, apellido.Text, cargo.Text, nombre_de_usuario .Text , contraseña.Text, cedula.Text, perfil.Text, Nombre_operador);
                    limpiar();
                   

                }
             



            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usuario_comun_Load(object sender, EventArgs e)
        {
            
            
        }

        private void cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
