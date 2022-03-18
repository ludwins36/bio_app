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
    public partial class registro_from : Form
    {
        public registro_from()
        {
            InitializeComponent();
        }

        private void Huella_Click(object sender, EventArgs e)
        {

        }
          

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Registro Manual";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Registro Manual";
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
              textBox1.Text = "Registro Automatico";
        
        }

        private void registro_from_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            call llamar = new call();
            llamar.configuraciones = "llamar  formulario configuraciones";
        }
    }
}
