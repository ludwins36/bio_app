using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bio
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        call llamar = new call();


        
        seguridad seguro = new seguridad();



        private void verificar_permiso()  //acceso completo
        {

            if (seguro.Recibir_regla == "acceso completo")
            {


            }

            else if (seguro.Recibir_regla == "acceso limitado")
            {

                bunifuImageButton4.Visible = false;
                bunifuImageButton1.Visible = false;
                bunifuImageButton2.Visible = false;
                bunifuImageButton3.Location = new Point(23, 32);
                bunifuImageButton9.Location = new Point(186, 30);
                label2.Location = new Point(-1, 9);
                label11.Location = new Point(188, 8);

                label5.Visible = false;
                label6.Visible = false;
                label1.Visible = false;
              

            }
        }




        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            llamar.Usuario_comun = "llamar formulario usuario_comun";
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            llamar.reglas_para_perfiles = "llamar formulario reglas_para_perfiles";
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            llamar.perfiles = "llamar formulario Perfiles";
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            llamar.Datos_de_Usuarios = "llamar formulario Datos_de_Usuarios";
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            llamar.configuraciones = "llamar formulario Configuraciones";
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            verificar_permiso();
        }
    }
}

