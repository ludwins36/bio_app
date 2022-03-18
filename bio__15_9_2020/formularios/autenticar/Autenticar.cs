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
    public partial class Autenticar : MainForm_new
    {
        public Autenticar()
        {
            InitializeComponent();
        }
        private DPFP.Template Template;
        call llamar = new call();


        Transacciones trans = new Transacciones();


        Configuracion config = new Configuracion();

      

        int i = 0;




        //...............funcion para meter el from dentro del panel

        private void abrirfromhija(object fromhija)
        {
            if (this.panel_registrofrom.Controls.Count > 0)

                this.panel_registrofrom.Controls.RemoveAt(0);
            Form fh = fromhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_registrofrom.Controls.Add(fh);
            this.panel_registrofrom.Tag = fh;
            fh.Show();


        }

        //.......................................................................























        private void cargar_id()
        {



            SqlConnection conn = bd_comun.ObtenerConexion();
            SqlDataAdapter Horarios = new SqlDataAdapter("select Id from DatosPersonal", conn);
            DataSet hora = new DataSet();

            Horarios.Fill(hora, "DatosPersonal");
            dataGridView1.DataSource = hora;
            dataGridView1.DataMember = "DatosPersonal";
            conn.Close(); ;


            //   dataGridView1.Columns.Clear();
            DataGridViewCheckBoxColumn chek = new DataGridViewCheckBoxColumn();
            chek.HeaderText = "Seleccionar";
            chek.Name = "Seleccionar";
            chek.Width = 80;
            dataGridView1.Columns.Add(chek);
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].DisplayIndex = 0;

            dataGridView1.DataSource = hora;


            timer1.Enabled = true;

            conn.Close();


        }











        private void verificar_permiso()
        {

            SqlConnection conexion = bd_comun.ObtenerConexion();


            string consultar = "SELECT * FROM biometrico ";
            SqlCommand cmd = new SqlCommand(consultar, conexion);
            cmd.CommandText = consultar;
            cmd.Parameters.Clear();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            SqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read() == true)
            {

                config.Biometrico = leer["biometrico"].ToString();

            }



            conexion.Close();


        }




        private void cargar_biometrico()
        {



            if (config.Biometrico == "Digital Persona")


            {









            }




            if (config.Biometrico == "Futronic FS88H")


            {




            }



        }





        private void filtrar_id()
        {

            SqlConnection conexion = bd_comun.ObtenerConexion();
            string consultar = "SELECT * FROM  TiposDeclaraciones WHERE  Nombre = @Nombre";
            SqlCommand cmd = new SqlCommand(consultar, conexion);
            cmd.CommandText = consultar;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nombre", tramites.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read() == true)
            {
                trans.id = leer["Id"].ToString();
                trans.nombre = leer["Nombre"].ToString();
                trans.texto = leer["Texto"].ToString();
                trans.declarantes = leer["Declarantes"].ToString();
                trans.plantillaDot = leer["PlantillaDot"].ToString();

             
            }

            conexion.Close();


        }




        private void limpiarmemoria()
        {
            trans.nombre = "";
            trans.texto = "";
            trans.plantillaDot = "";
            trans.declarantes = "";

        }


   




        private void cargar_huellas_bd()
        {


            SqlConnection conn = bd_comun.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("select huella,Cedula from DatosPersonal where Id= @Id", conn);
            cmd.Parameters.AddWithValue("@Id", comboBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("huella_tmp");
            byte[] MyData = new byte[0];
            dp.Fill(ds, "huella_tmp");


            if (ds.Tables["huella_tmp"].Rows.Count > 0)
            {

                DataRow myRow = ds.Tables["huella_tmp"].Rows[0];


                MyData = (byte[])myRow["huella"];
                cedula_1.Text = myRow["Cedula"].ToString();

                MemoryStream stream = new MemoryStream(MyData);


                huella_bd.Image = Image.FromStream(stream);



            }


            else

            {



            }


            conn.Close();



        }

















        private void buscar_nootario_deturno()
        {

            if (config.Verificar_notaro() == true)
            {
                notario.Text = config.Notario_de_Turno;

            }

        }













        private void button7_Click(object sender, EventArgs e)
        {
           



        }

        private void button3_Click(object sender, EventArgs e)
        {






        }










        private void Autenticar_Load(object sender, EventArgs e)
        {


            verificar_permiso();
            cargar_biometrico();


            cargar_id();

            Transacciones.select_id_datos_del_personal(comboBox1);
            Defabrica.select_tramites(tramites);


            buscar_nootario_deturno();

         //   llamar.Activar_gif = "true";
           


        }

        private void tramites_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar_id();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Transacciones.eliminar_stiker();
            Transacciones.Insert_sticker(trans.nombre, trans.texto, trans.declarantes, trans.plantillaDot, id_cliente.Text, fecha.Text, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), Identificación.Text);

            Transacciones.Insert_transacion(trans.nombre, trans.texto, trans.declarantes, trans.plantillaDot, id_cliente.Text, fecha.Text, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), Identificación.Text);
            limpiarmemoria();


           

        }

        private void btn_c1_Click(object sender, EventArgs e)
        {
         
        }

        private void btn_registrart_huella_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    Huella.Image = Image.FromFile(imagen);


                }
            }
            catch (Exception)
            {

            }
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

        private void notario_turno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transacciones.eliminar_stiker();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
          

        }

        private void button5_Click(object sender, EventArgs e)
        {


         




        }

        private void button10_Click(object sender, EventArgs e)
        {

          

        }

        private void button9_Click(object sender, EventArgs e)
        {


           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_huellas_bd();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {




            // De momento, en este ejemplo, como el bucle solo tiene una linea, no son
            // necesarias las llaves.
            //   int i;
            //  for (i = 0; i < num; i++)

            int num = comboBox1.Items.Count - 1;


            if (i == num)
            {
                MessageBox.Show("lleno_ refresh");
                i = 0;
                comboBox1.SelectedIndex = 0;

            }
            else
            {
                comboBox1.SelectedIndex++;
                i++;

            }














        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;


        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;

                if (Template != null)
                {
                    MessageBox.Show("La plantilla de huellas dactilares está lista para la verificación de huellas dactilares..", "Inscripción de huellas dactilares");

                }
                else
                {
                    MessageBox.Show("La plantilla de huellas dactilares no es válida. Repetir inscripción de huellas dactilares.", "Inscripción de huellas dactilares");
                }
            }));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = true;
            }



            timer1.Enabled = false;



        }






        private bool imagecomparestrig(Bitmap huella_bd, Bitmap huella_ap)
        {
            MemoryStream ms = new MemoryStream();
            huella_bd.Save(ms, ImageFormat.Jpeg);

            string firsbitmap = Convert.ToBase64String(ms.ToArray());
            ms.Position = 0;
            huella_ap.Save(ms, ImageFormat.Jpeg);
            string segundbitmap = Convert.ToBase64String(ms.ToArray());

            if (firsbitmap.Equals(segundbitmap))
            {
                return true;
            }
            else
            {
                return false;

            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            SqlConnection miconexion = bd_comun.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("select * from DatosPersonal where Cedula= @Cedula", miconexion);
            cmd.Parameters.AddWithValue("@Cedula", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("Clientes");

            byte[] MyData = new byte[0];
            byte[] fingerprint = new byte[0];
            byte[] notaria = new byte[0];

            dp.Fill(ds, "DatosPersonal");

            if (ds.Tables["DatosPersonal"].Rows.Count > 0)
            {

                DataRow myRow = ds.Tables["DatosPersonal"].Rows[0];


                MyData = (byte[])myRow["Foto"];
                fingerprint = (byte[])myRow["huella"];
                notaria = (byte[])myRow["firma"];


                MemoryStream stream = new MemoryStream(MyData);
                MemoryStream stream1 = new MemoryStream(fingerprint);
                MemoryStream stream2 = new MemoryStream(notaria);


                Foto.Image = Image.FromStream(stream);
                Huella.Image = Image.FromStream(stream1);
                firma.Image = Image.FromStream(stream2);

                Nombre.Text = myRow["Nombre"].ToString();
                Apellidos.Text = myRow["Apellidos"].ToString();
                Identificación.Text = myRow["Cedula"].ToString();
                id_cliente.Text = myRow["Id"].ToString();

                tramites.Enabled = true;






            }

            else
            {
                MessageBox.Show("No existe", "bio", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            miconexion.Close();


        }

        private void button6_Click(object sender, EventArgs e)
        {


            comboBox1.SelectedIndex = 0;
            Bitmap bmp = new Bitmap(Huella.Image);
            Bitmap bmp1 = new Bitmap(huella_bd.Image);

            int num = comboBox1.Items.Count;
            bool compare = imagecomparestrig(bmp, bmp1);


            // fila.Cells["cedula"].Value.ToString()


            try
            {

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(fila.Cells["Seleccionar"].Value))
                    {


                        comboBox1.Text = fila.Cells["Id"].Value.ToString();
                        copia.Text = fila.Cells["Id"].Value.ToString();


                        timer1.Enabled = true;


                        //     if (compare == true)
                        //     {


                        //       textBox2.Text = "iguales";
                        //  }

                        //else

                        //    {
                        //      textBox2.Text = "no existe";





                        //}











                    }



                }


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());



            }








        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            cargar_huellas_bd();





        }

        private void timer2_Tick(object sender, EventArgs e)
        {




            Bitmap bmp = new Bitmap(Huella.Image);
            Bitmap bmp1 = new Bitmap(huella_bd.Image);

            int num = comboBox1.Items.Count;
            bool compare = imagecomparestrig(bmp, bmp1);



            if (compare == true)
            {


                label1.Text = "iguales";
            }

            else

            {
                label1.Text = "no existe";





            }


            timer2.Enabled = false;





        }



        private void copia_TextChanged(object sender, EventArgs e)
        {

            Bitmap bmp = new Bitmap(Huella.Image);
            Bitmap bmp1 = new Bitmap(huella_bd.Image);

            int num = comboBox1.Items.Count;
            bool compare = imagecomparestrig(bmp, bmp1);



            if (compare == true)
            {


                label1.Text = "iguales";
            }

            else

            {
                label1.Text = "no existe";





            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "iguales")
            {
                textBox1.Text = cedula_1.Text;


            }

            textBox2.Clear();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {


        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            llamar.Verificar = "verificar";
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            llamar.Detener = "detener";
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            llamar.Salida = "salida";
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
           




        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_3(object sender, EventArgs e)
        {



            try
            {
                string split = textBox4.Text;

                char[] delimitador = { ' ' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {


                    textBox6.Text = trozos[1];
                    textBox1.Text = trozos[1];




                }
            }



            catch (Exception)
            {

            }




        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string split = textBox4.Text;

                char[] delimitador = { ' ' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {


                    textBox6.Text = trozos[1];
                    textBox1.Text = trozos[1];




                }
            }



            catch (Exception)
            {

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            SqlConnection miconexion = bd_comun.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("select * from DatosPersonal where Cedula= @Cedula", miconexion);
            cmd.Parameters.AddWithValue("@Cedula", textBox6.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("Clientes");

            byte[] MyData = new byte[0];
            byte[] fingerprint = new byte[0];
            byte[] notaria = new byte[0];

            dp.Fill(ds, "DatosPersonal");

            if (ds.Tables["DatosPersonal"].Rows.Count > 0)
            {

                DataRow myRow = ds.Tables["DatosPersonal"].Rows[0];


                MyData = (byte[])myRow["Foto"];
                fingerprint = (byte[])myRow["huella"];
                notaria = (byte[])myRow["firma"];


                MemoryStream stream = new MemoryStream(MyData);
                MemoryStream stream1 = new MemoryStream(fingerprint);
                MemoryStream stream2 = new MemoryStream(notaria);


                Foto.Image = Image.FromStream(stream);
                Huella.Image = Image.FromStream(stream1);
                firma.Image = Image.FromStream(stream2);

                Nombre.Text = myRow["Nombre"].ToString();
                Apellidos.Text = myRow["Apellidos"].ToString();
                identidad.Text = myRow["Cedula"].ToString();
                id_cliente.Text = myRow["Id"].ToString();

                

                // fecha.Text = myRow["FechaExpCed"].ToString();
                // hora.Text = myRow["HoraMod"].ToString();

                tramites.Enabled = true;






            }

            else
            {
                MessageBox.Show("No existe", "bio", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


            miconexion.Close();


        }



        private void split_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string split = textBox3.Text;

                char[] delimitador = { ' ' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {


                    textBox6.Text = trozos[1];
                    textBox1.Text = trozos[1];




                }
            }



            catch (Exception)
            {

            }
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
          
        }

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {


         


        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Huella.Image);
            Bitmap bmp1 = new Bitmap(huella_bd.Image);

            int num = comboBox1.Items.Count;
            bool compare = imagecomparestrig(bmp, bmp1);



            if (compare == true)
            {


                label1.Text = "iguales";
            }

            else

            {
                label1.Text = "no existe";





            }


            timer2.Enabled = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string split = textBox7.Text;

                char[] delimitador = { ' ' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {


                    textBox6.Text = trozos[1];
                    textBox1.Text = trozos[1];




                }
            }

            catch (Exception)
            {

            }


        }

        private void Cedula_rogado_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {


       
            








        }

        private void button8_Click(object sender, EventArgs e)
        {
            tramites.Text = "PRESENTACION PERSONAL";
            filtrar_id();

            Transacciones.eliminar_stiker();
            Transacciones.Insert_sticker(Nombre.Text + " " + Apellidos.Text, tramites.Text, "????", "????", id_cliente.Text, fecha.Text, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(firma.Image), identidad.Text);

            Transacciones.Insert_transacion(Nombre.Text + " " + Apellidos.Text, tramites.Text, "????", "????", id_cliente.Text, fecha.Text, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);
            limpiarmemoria();

            reporte_3 ven = new reporte_3();
            ven.Show();

        }

        private void fc_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {


        
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

            
        }

        private void button12_Click(object sender, EventArgs e)
        {

            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {

            

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection miconexion = bd_comun.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("select * from DatosPersonal where Cedula= @Cedula", miconexion);
            cmd.Parameters.AddWithValue("@Cedula", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("Clientes");

            byte[] MyData = new byte[0];
            byte[] fingerprint = new byte[0];
            byte[] notaria = new byte[0];

            dp.Fill(ds, "DatosPersonal");

            if (ds.Tables["DatosPersonal"].Rows.Count > 0)
            {

                DataRow myRow = ds.Tables["DatosPersonal"].Rows[0];


                MyData = (byte[])myRow["Foto"];
                fingerprint = (byte[])myRow["huella"];
               
                MemoryStream stream = new MemoryStream(MyData);
                MemoryStream stream1 = new MemoryStream(fingerprint);
                MemoryStream stream2 = new MemoryStream(notaria);


                Foto.Image = Image.FromStream(stream);
                Huella.Image = Image.FromStream(stream1);
               

                Nombre.Text = myRow["Nombre"].ToString();
                Apellidos.Text = myRow["Apellidos"].ToString();
                identidad.Text = myRow["Cedula"].ToString();
                id_cliente.Text = myRow["Id"].ToString();

                groupBox4.Enabled = true;


                tramites.Enabled = true;


            }

            else
            {
                MessageBox.Show("No existe", "bio", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


            miconexion.Close();

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
          

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {




        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {

                Transacciones.cagar_informacion_del_notario(config.Notario_de_Turno);



                string filtro_fecha = fecha.Value.Day + "/" + fecha.Value.Month + "/" + fecha.Value.Year;


                tramites.Text = "PRESENTACION PERSONAL";
                filtrar_id();

                Transacciones.eliminar_stiker();
                Transacciones.Insert_sticker(Nombre.Text + " " + Apellidos.Text, tramites.Text, "????", "????", id_cliente.Text, filtro_fecha, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);

                Transacciones.Insert_transacion(Nombre.Text + " " + Apellidos.Text, tramites.Text, "????", "????", id_cliente.Text, filtro_fecha, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);
                limpiarmemoria();

                reporte_2 ven = new reporte_2();
                ven.Show();
               // llamar.Reporte_2 = "llamar formulario reporte_2";


            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());



            }

        }

        private void button5_Click_3(object sender, EventArgs e)
        {
            try
            {

                Transacciones.cagar_informacion_del_notario(config.Notario_de_Turno);

                string filtro_fecha = fecha.Value.Day + "/" + fecha.Value.Month + "/" + fecha.Value.Year;

                tramites.Text = "REGISTRAR FIRMA";

                Transacciones.eliminar_stiker();
                Transacciones.Insert_sticker(Nombre.Text + " " + Apellidos.Text, tramites.Text, "????", "????", id_cliente.Text, filtro_fecha, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);

                Transacciones.Insert_transacion(Nombre.Text + " " + Apellidos.Text, tramites.Text, "????", "????", id_cliente.Text, filtro_fecha, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);
                limpiarmemoria();

                reporte_4 ven = new reporte_4();
                ven.Show();

              //  llamar.Reporte_4 = "llamar formulario reporte_4";

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());



            }

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            try
            {

                Transacciones.cagar_informacion_del_notario(config.Notario_de_Turno);

                string filtro_fecha = fecha.Value.Day + "/" + fecha.Value.Month + "/" + fecha.Value.Year;
                tramites.Text = "FIRMA REGISTRADA";
                filtrar_id();

                Transacciones.eliminar_stiker();
                Transacciones.Insert_sticker(Nombre.Text + " " + Apellidos.Text, tramites.Text, "????", "????", id_cliente.Text, filtro_fecha, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);

                Transacciones.Insert_transacion(Nombre.Text + " " + Apellidos.Text, tramites.Text, "????", "????", id_cliente.Text, filtro_fecha, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);
                limpiarmemoria();


            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());



            }

        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_3(object sender, EventArgs e)
        {
            

        }

        private void button9_Click_2(object sender, EventArgs e)
        {
           
        }

        private void Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Apellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    Foto.Image = Image.FromFile(imagen);


                }
            }
            catch (Exception)
            {

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            objetos obj = new objetos();

            SqlConnection conexion = bd_comun.ObtenerConexion();


            try
            {


                SqlConnection conn = bd_comun.ObtenerConexion();

                string sql = "delete from DatosPersonal where Id=" + id_cliente.Text + ";";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", id_cliente.Text);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("bio");
                da.Fill(dt);

            }
            catch (Exception)
            {


            }




            Clientes.Insert(obj.cedula, obj.Name, Apellidos.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image));

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {

                Transacciones.cagar_informacion_del_notario(config.Notario_de_Turno);


                string filtro_fecha = fecha.Value.Day + "/" + fecha.Value.Month + "/" + fecha.Value.Year;



                tramites.Text = "RECONOCIMIENTO DE FIRMA HUELLA  Y CONTENIDO";
                filtrar_id();

                Transacciones.cagar_informacion_del_notario(config.Notario_de_Turno);
                Transacciones.eliminar_stiker();

                Transacciones.Insert_sticker(Nombre.Text + " " + Apellidos.Text, tramites.Text, Cedula_rogado.Text, Nombre_rogado.Text, id_cliente.Text, filtro_fecha, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);

                Transacciones.Insert_transacion(Nombre.Text + " " + Apellidos.Text, tramites.Text, Cedula_rogado.Text, Nombre_rogado.Text, id_cliente.Text, filtro_fecha, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);
                limpiarmemoria();

                reporte2 ven = new reporte2();

                ven.Show();







            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());



            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            try
            {
                Transacciones.cagar_informacion_del_notario(config.Notario_de_Turno);

                panel3.Visible = true;
                string filtro_fecha = fecha.Value.Day + "/" + fecha.Value.Month + "/" + fecha.Value.Year;


                if (Cedula_rogado.Text == "")
                {
                    MessageBox.Show("Introduzca la cedula del rogado", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox7.Visible = true;
                    Cedula_rogado.Focus();


                }

                if (Nombre_rogado.Text == "")
                {
                    MessageBox.Show("Introduzca Nombre del rogado", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Nombre_rogado.Focus();
                    groupBox7.Visible = true;


                }

                else
                {


                    tramites.Text = "RECONOCIMIENTO DE FIRMA HUELLA  Y CONTENIDO";
                    filtrar_id();

                    Transacciones.eliminar_stiker();
                    Transacciones.Insert_sticker(Nombre.Text + " " + Apellidos.Text, tramites.Text, Cedula_rogado.Text, Nombre_rogado.Text, id_cliente.Text, filtro_fecha, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);

                    Transacciones.Insert_transacion(Nombre.Text + " " + Apellidos.Text, tramites.Text, Cedula_rogado.Text, Nombre_rogado.Text, id_cliente.Text, filtro_fecha, hora.Text, notario.Text, ConvertImage.ImageToByteArray(Foto.Image), ConvertImage.ImageToByteArray(Huella.Image), identidad.Text);
                    limpiarmemoria();


                    Form11 ven = new Form11();
                    ven.Show();



                    // llamar.form11 = "llamar formulario Form11";






                }



            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());



            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            llamar.Autenticar = "llamar formulario autenticar";
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
       
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
           
        }

    

        private void automatico_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {
           
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton7_Click_2(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Registro;


        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = Autenticaciones;

        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            btnIdentify.PerformClick();
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            try
            {
                string split = txtMessage.Text;

                char[] delimitador = { ':' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {

                    textBox8.Text = trozos[0];
                    textBox7.Text = trozos[1];


                }


            }
            catch (Exception)
            {


            }
        }

        private void bunifuFlatButton5_Click_1(object sender, EventArgs e)
        {
            string statuscamara_call = llamar.Status_camara;


            llamar.Camara = "detener";
            llamar.Camara = null;


          



            if (statuscamara_call == "iniciado")
            {
                llamar.Camara = "detener";

            }

                       



            if (statuscamara_call == "iniciado")
            {
                llamar.Camara = "detener";

            }

            if (llamar.Status_camara == null)
            {
                abrirfromhija(new Registrar_clientes());

            }




            if (statuscamara_call == "Detenido")
            {
                abrirfromhija(new Registrar_clientes());

            }
        }
    }
}
