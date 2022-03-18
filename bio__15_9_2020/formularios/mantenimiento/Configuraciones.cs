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
    public partial class Configuraciones : Form
    {
        public Configuraciones()
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

                bunifuImageButton3.Visible = false;
                bunifuImageButton1.Visible = false;
                bunifuImageButton2.Location = new Point(101, 39);
                label4.Location = new Point(77, 14);

            }

            else if (seguro.Recibir_regla == "acceso basico")
            {

                bunifuImageButton3.Visible = false;
                bunifuImageButton1.Visible = false;
                bunifuImageButton2.Visible = false;

            }
        }




        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            llamar.Configura = "llamar formulario configura";
               
        }

        private void Configuraciones_Load(object sender, EventArgs e)
        {
            verificar_permiso();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {




                frmScannerApp ven = new frmScannerApp();
                ven.Show();


            }
            catch (Exception)
            {

            }


        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            llamar.Biometria = "llamar formulario biometria";
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            llamar.Registro_from = "llamar formulario registro_from ";
        }
    }
}
