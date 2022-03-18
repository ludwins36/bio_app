using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Data.SqlClient;
using System.IO;



namespace bio
{
    public partial class Configura : Form
    {
        public Configura()
        {
            InitializeComponent();
        }


        Configuracion config = new Configuracion();

        call llamar = new call();



        public bool Verificar_notaro()
        {
            bool resultado = false;
            SqlConnection miconexion = bd_comun.ObtenerConexion();
            SqlCommand comando = new SqlCommand("select * from notario_de_turno");
            comando.Connection = miconexion;
            SqlDataReader ejecuta = comando.ExecuteReader();
            if (ejecuta.Read())
            {
                Notario_Activo.Text  = ejecuta["Nombre"].ToString();



                resultado = true;

            }
            else
            {

            }

            return resultado;

            miconexion.Close();



        }













        private void seleccionar_notarios()
        {

            Configuracion.eliminar_notario_de_turno();
            Configuracion.Insert_notarios_de_turno(txt_Nombre_Notario.Text);
            Verificar_notaro();


        }

        //--------------------------------------------------



        private void pasar()
        {

          
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    recibo.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                }

            }
            catch (Exception)
            {

            }



           
        }
















        private void limpiar_notaria()
        {

            Notaria.Text = "";
            Direccion.Text = "";
            Ciudad.Text = "";
            Telefono.Text = "";
            telefono2.Text = "";
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        private void cargar_notarios()
        {

            SqlConnection conn = bd_comun.ObtenerConexion();


            SqlDataAdapter Horarios = new SqlDataAdapter("select * from Notarios", conn);
            DataSet hora = new DataSet();

            Horarios.Fill(hora, "Notarios");
            dataGridView2.DataSource = hora;
            dataGridView2.DataMember = "Notarios";
            conn.Close(); ;

            

            dataGridView2.DataSource = hora;


        }

        //--------------------------------------------------

        private void handlercomun_Click(object sender, EventArgs e)
        {
            

            Console.Beep();

            seleccionar_notarios();


           




        }



        private void registro_notaria()
        {

            

            SqlConnection conexion = bd_comun.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("select * from Configuracion ", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("Empleados");
            byte[] MyData = new byte[0];
            dp.Fill(ds, "Configuracion");


            if (ds.Tables["Configuracion"].Rows.Count > 0)
            {

                DataRow myRow = ds.Tables["Configuracion"].Rows[0];


                MyData = (byte[])myRow["logo"];

                MemoryStream stream = new MemoryStream(MyData);


                logo.Image = Image.FromStream(stream);


                Notaria.Text = myRow["Notaria"].ToString();
                Direccion.Text = myRow["Direccion"].ToString();
                Ciudad.Text = myRow["Ciudad"].ToString();
                Telefono.Text = myRow["Telefono"].ToString();
                telefono2.Text = myRow["telefono2"].ToString();






            }







        }





           

               
        







        private void GuardarConfig_Click(object sender, EventArgs e)
        {



            SqlConnection conn = bd_comun.ObtenerConexion();
            string query = "update Notarios set Nombre_Notario ='" + txt_Nombre_Notario.Text + "' ,Cargo ='" + Cargo.Text + "',Acta ='" + Acta.Text + "' where Id_Notario =" + id_notaria.Text + ";";
            SqlCommand cmd = new SqlCommand(query, conn);

            


            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Registro Actualizado exitosamente", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());



            }

            
            

            cargar_notarios();

            txt_Nombre_Notario.Text  = "";
                
                Cargo.Text = "";

                Acta.Text = "";




            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //y cargarla al pictureboox
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    logo.Image = Image.FromFile(imagen);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Elivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void CancelarConfig_Click(object sender, EventArgs e)
        {

            Configuracion.eliminar_datos_de_notaria();
            Configuracion.Insert_registros_notaria(Notaria.Text, Direccion.Text, Ciudad.Text, Telefono.Text, telefono2.Text, ConvertImage.ImageToByteArray(logo.Image));
            limpiar_notaria();
            registro_notaria();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void Configura_Load(object sender, EventArgs e)
        {
           
            registro_notaria();
            cargar_notarios();
            Verificar_notaro();

        }

        private void notario_turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configuracion.eliminar_notario_de_turno();
            Configuracion.Insert_notarios_de_turno(notario_turno.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            llamar.configuraciones = "llamar  formulario configuraciones";
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

      

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            seleccionar_notarios();
            dataGridView2.Columns.Clear();
            cargar_notarios();
        }

        private void recibo_TextChanged(object sender, EventArgs e)
        {



            SqlConnection conexion = bd_comun.ObtenerConexion();
             string consultar = "SELECT * FROM Notarios WHERE  Id_Notario = @Id_Notario";
            SqlCommand cmd = new SqlCommand(consultar, conexion);
            cmd.CommandText = consultar;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id_Notario", recibo.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            SqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read() == true)
            {

                txt_Nombre_Notario.Text = leer["Nombre_Notario"].ToString();
                Cargo.Text = leer["Cargo"].ToString();
                Acta.Text = leer["Acta"].ToString();
                id_notaria.Text = leer["Id_Notario"].ToString();






                //

            }






        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pasar();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pasar();
        }

        private void txt_Nombre_Notario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cargo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
