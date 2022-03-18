using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace bio
{
    public partial class Datos_de_Usuarios : Form
    {
        public Datos_de_Usuarios()
        {
            InitializeComponent();
        }

        call llamar = new call();


        //............................cargar por cedula...............................................................
        private void cargar_por_Cedula()
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = usuario_Demo.Cargar(cedulaa);

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                DataRowView rows = row.DataBoundItem as DataRowView;

            }



        }


        //.....................................................................................



        //.............................cargartodos.............................................................

        private void cargartodos()
        {
            dataGridView2.RowTemplate.Height = 40;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = usuario_Demo.cargartodos();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                DataRowView rows = row.DataBoundItem as DataRowView;

            }
        }


        //..........................................................................................


        //.....................................................................................

        private void cargar_por_nombre()
        {
            dataGridView2.RowTemplate.Height = 60;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = usuario_Demo.Cargar_por_nombre(Nombree);

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                DataRowView rows = row.DataBoundItem as DataRowView;

            }
        }


        //...................................................................................

        //..........................................................................................

        private void pasar()
        {

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                Recibo.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            }
        }


        //..........................................................................................








        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            llamar.Usuarios = "llamar formulario Usuarios";
        }

        private void Datos_de_Usuarios_Load(object sender, EventArgs e)
        {
            cargartodos();
            radioButton1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                cedulaa.Text = "Escriba la Cedula";
                cedulaa.Visible = true;
              
                button2.Visible = true;
                button2.Visible = true;
                button2.Location = new Point(277, 59);
                cedulaa.Location = new Point(129, 62);



            }
            else
            {

                cedulaa.Visible = false;
                button2.Visible = false;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                Nombree.Text = "Escriba el Nombre de usuario ";
                Nombree.Visible = true;
               button1.Visible = true;
                button1.Location = new Point(277, 59);
                Nombree.Location = new Point(129, 62);

            }
            else
            {
                Nombree.Visible = false;
                button1.Visible = false;


            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pasar();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pasar();
        }

        private void Recibo_TextChanged(object sender, EventArgs e)
        {
            if (Recibo.Text == "")
            {


            }

            else
            {
                llamar.Usuario_Detalles_llamar = "llamar formulario Usuario_Detalles";
                llamar.Usuario_Detalles = Recibo.Text;




            }
        }
    }
}
