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
    public partial class biometria : Form
    {
        public biometria()
        {
            InitializeComponent();
        }

        call llamar = new call();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Digital Persona";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Futronic FS88H";
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void Huella_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Digital Persona";
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Futronic FS88H";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Seleccione el Dispositivo", "bio", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {

                Configuracion.eliminar_biometrico();
                Configuracion.Insert_biometrico(textBox1.Text);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            llamar.configuraciones = "llamar  formulario configuraciones";
        }
    }
}
