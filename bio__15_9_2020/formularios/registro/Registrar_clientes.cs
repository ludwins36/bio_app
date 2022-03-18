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
using System.Data.OleDb;

namespace bio
{
    public partial class Registrar_clientes : MainForm_new
    {
        private FilterInfoCollection Webcam;
        private VideoCaptureDevice cam;
        private DPFP.Template Template;

        private static string filtrar;


        private static string Año_nac;

        private static string sexo_objet;



        public string Sexo_objet
        {
            get { return sexo_objet; }
            set { sexo_objet = value; }
        }


        public string año_nac
        {
            get { return Año_nac; }
            set { Año_nac = value; }
        }




        public string Filtrar
        {
            get { return filtrar; }
            set { filtrar = value; }
        }















        bool conv = false, neg = false;
        string dir_inicial = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Wallpapers";

       
        public Registrar_clientes()
        {
            InitializeComponent();


            btnconvneg.Click += (s, e) => PictureFingerPrint.Image = negativo();
               
         
        }

          
        Image negativo()
        {
            if (!neg)
            {
                Bitmap bm = new Bitmap(PictureFingerPrint.Image);

            
                //  progres.Maximum = bm.Width * bm.Height;
                for (int x = 0; x < bm.Width; x++)
                    for (int y = 0; y < bm.Height; y++)
                    {
                        Color c = bm.GetPixel(x, y);
                        Color nuevo = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                        bm.SetPixel(x, y, nuevo);
                        // progres.Value++;
                    }
                neg = true;
                //   progres.Value = 0;
                return bm;
            }
            return PictureFingerPrint.Image;
        }



        


        Configuracion config = new Configuracion();
        call llamar = new call();
        objetos obj = new objetos();


        int i = 0;









        private void eliminar_caracteres()
        {

            string cadena = textBox4.Text;

            cadena = cadena.Replace("@", "");
            cadena = cadena.Replace("^", "");
            cadena = cadena.Replace("(", "");
            cadena = cadena.Replace("?", "");
            cadena = cadena.Replace("+", "");
            cadena = cadena.Replace(".", "");
            cadena = cadena.Replace("!", "");
            cadena = cadena.Replace("/", "");
            cadena = cadena.Replace("|", "");
            cadena = cadena.Replace("[", "");
            cadena = cadena.Replace("]", "");
            cadena = cadena.Replace("-", "");
            cadena = cadena.Replace("_", "");
            cadena = cadena.Replace("$", "");
            cadena = cadena.Replace("#", "");
            cadena = cadena.Replace("%", "");
            cadena = cadena.Replace("&", "");
            cadena = cadena.Replace("'", "");
            cadena = cadena.Replace("*", "");
            cadena = cadena.Replace("^", "");
            cadena = cadena.Replace("`", "");
            cadena = cadena.Replace("{", "");
            cadena = cadena.Replace("~", "");
            cadena = cadena.Replace("<", "");
            cadena = cadena.Replace("¡", "");
            cadena = cadena.Replace(" ", "");
            cadena = cadena.Replace("¿", "");
            cadena = cadena.Replace("0M", "*");
            cadena = cadena.Replace("0F", "+");

          filtrar  = cadena;

           // textBox4.Text = cadena;


        }




        private void desifrar_cedula_2()
        {



            try
            {

                string TEXTO = filtrar;
                nombre.Text = TEXTO.Substring(13, 10);



            }
            catch (Exception)
            {

            }





            try
            {





                string input = filtrar;
                string chars = new String(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());

                nombre.Text = chars;



                string sentence = nombre.Text;
                string filter = sentence.Remove(0, 1);

                filter = filter.Replace("PubDSK", "");
                filter = filter.Replace("ubDSK", "");
                filter = filter.Replace("Cq", "");
                filter = filter.Replace("FO", "");

                nombre.Text = filter;




            }
            catch (Exception)
            {

            }











        }






        private void desifrar_cedula()
        {



            try
            {

                string TEXTO = filtrar;
               // Cedula.Text = TEXTO.Substring(33, 10);

              //  Cedula.Text = TEXTO.Substring(25, 10);
                              
     //  nombre.Text = TEXTO.Substring(33, 10);

           

//-------------------split despues del sexo  masculino ---------------------------------------------------------------------

                string split = TEXTO;


                char[] delimitador = { '*' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {

                    string fecha  = trozos[1];
                    string año = fecha.Substring(0, 4);
                    string mes = fecha.Substring(4, 2);
                    string dia = fecha.Substring(6, 2);

                    fecha_nac.Text = dia + "/" + mes + "/" + año;

                    Año_nac = año;

                    sexo_objet = "masculino";

                }

                
               // fecha_nac.Text = TEXTO.Substring(70, 8);
              //  string prueba = nombre.Text;

            }
            catch (Exception)
            {

            }



            //-------------------split despues del sexo  femenino ---------------------------------------------------------------------
            try
            {


                string TEXTO = filtrar;
                string split_f = TEXTO;


                char[] delimitador = { '+' };
                string[] trozos = split_f.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {

                    string fecha  = trozos[1];
                    string año = fecha.Substring(0, 4);
                    string mes = fecha.Substring(4, 2);
                    string dia = fecha.Substring(6, 2);

                    fecha_nac.Text = dia + "/" + mes + "/" + año;

                    Año_nac = año;

                    sexo_objet = "femenino";

                }

                
               // fecha_nac.Text = TEXTO.Substring(70, 8);
              //  string prueba = nombre.Text;

            }
            catch (Exception)
            {

            }




            try
            {





                string input = filtrar;
                string chars = new String(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());

                nombre.Text = chars;



                string sentence = nombre.Text;
                string filter = sentence.Remove(0, 1);

                filter = filter.Replace("PubDSK", ""); 
                filter = filter.Replace("ubDSK", "");
                filter = filter.Replace("Cq", "");
                filter = filter.Replace("FO", "");
                filter = filter.Replace("MAunizyvcg°ZNp¨MKMVqfEmf°Er", "");



                string split = filter;


                char[] delimitador = { '*' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {

                    nombre.Text = trozos[0];
                  

                 

                }


           




              //  nombre.Text = filter;




            }
            catch (Exception)
            {

            }


//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


           //      Recorat cedula

            int años;
            if (Sexo_objet == "masculino")
            {

                años = int.Parse(Año_nac);

                if (años < 2000)
                {

                    Cedula.Text = filtrar.Substring(33, 10);


                }



                if (años > 2000)
                {

                    Cedula.Text = filtrar.Substring(25, 10);

                }




            }


            else
            {




                años = int.Parse(Año_nac);

                if (años < 2000)
                {

                   // Cedula.Text = filtrar.Substring(25, 10);

                    Cedula.Text = filtrar.Substring(22, 10);


                }



                if (años > 2000)
                {

                    Cedula.Text = filtrar.Substring(26, 10);

                }




            }


   



//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




        }





  //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
















        private void manual_obj()
        {


            automatico.Visible = false;

            manual.Visible = true;

            manual.Location = new Point(1, 289);

        

          //  Sistema.Location = new Point(526, 71);

            textBox4.Visible = false;

            label31.Visible = false;



        }




//-------------------------limpiar------------------------------------------------------------------------------------------  


        private void limpiar()
        {

     
            Cedula.Text = "";

          //  name.Text = "";


            femenino.Text = "";
            masculino.Text = "";


        }







//...................................................................SPLIT_-----------------------------



        private void SPLIT()
        {






            segundo_nombre.Text = "";
            textBox8.Text = "";



            string cadena = textBox4.Text;



//--------------------------------------OBTENER EL VALOR CEDULA-------------------------------------------------------------
            try
            {

                string TEXTO = textBox4.Text;
                Cedula.Text = TEXTO.Substring(33, 10);
            }
            catch (Exception)
            {

            }
 //----------------------------------------------------------------------------------------------------------------------------


            try
            {
                nombre.Text = cadena.Substring(56, 6);




                string input = textBox4.Text;
                string chars = new String(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());

                nombre.Text = chars;



                string sentence = nombre.Text;
                string filter = sentence.Remove(0, 1);

                nombre.Text = filter;




            }
            catch (Exception)
            {

            }



            //   try
            //   {
            //    nombre.Text = nombre.Text.Substring(0, nombre.Text.Count() - 30);  //longitud  que recorte  a partir de 30  caracteres
            //  }
            // catch (Exception)
            //   {

            // }


          

            //agale




  //-------------------------validar para cedulas femeninas



            try
            {
                segundo_nombre.Text = nombre.Text.Substring(17, nombre.Text.Count() - 121);  //longitud  que recorte  a partir de 30  caracteres
            }
            catch (Exception)
            {

            }


  //-------------------------------------------------------------------------------------------------------------------






//-------------------------validar para cedulas masculinas



            try
            {
                textBox8.Text = nombre.Text.Substring(25, nombre.Text.Count() - 53);  //longitud  que recorte  a partir de 30  caracteres
            }
            catch (Exception)
            {

            }

 //-------------------------------------------------------------------------------------------------------------------


            if (label27.Text == "FO")
            {
                try
                {



                    nombre.Text = nombre.Text.Replace("FO", ",");


                    string split = nombre.Text;

                    char[] delimitador = { ',' };
                    string[] trozos = split.Split(delimitador);
                    int i;
                    for (i = 0; i < trozos.Length; i++)
                    {

                        nombre.Text = trozos[0];


                    }




                }
                catch (Exception)
                {

                }


            }




            else if (label27.Text == "MA")
            {
                try
                {



                    nombre.Text = nombre.Text.Replace("MA", ",");

                    string split = nombre.Text;

                    char[] delimitador = { ',' };
                    string[] trozos = split.Split(delimitador);
                    int i;
                    for (i = 0; i < trozos.Length; i++)
                    {

                        nombre.Text = trozos[0];


                    }







                }
                catch (Exception)
                {

                }

            }






 //split para las cedulas que tengan signo de interrogacion al comienzo

            try
            {





                string split = nombre.Text;

                char[] delimitador = { '?' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {

                    nombre.Text = trozos[1];




                }




            }
            catch (Exception)
            {

            }



        }

       
 //.......................................................................

       


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


        }


      



        private void Registrar_clientes_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            manual_obj();
            textBox4.Focus();


            string GroupBox2_call = llamar.GroupBox2;

            if (GroupBox2_call == "Enable")
            {
                groupBox2.Enabled = true;
            }

           


            Webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);


            try
            {
                foreach (FilterInfo videocapturedevice in Webcam)
                {

                    comboBox1.Items.Add(videocapturedevice.Name);

                }

                comboBox1.SelectedIndex = 0;

                llamar.Status_camara = "iniciado";
                
            }
            catch (Exception)
            {
               
            }




       
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(Webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }

        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            foto.Image = bit;
        }

        private void bunifuImageButton4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_registrart_huella_Click(object sender, EventArgs e)
        {


            verificar_permiso();



            if (config.Biometrico == "Digital Persona")


            {

                


                CapturarHuella ven = new CapturarHuella();
                ven.OnTemplate += this.OnTemplate;
                llamar.capturarHuella = "llamar formulario CapturarHuella";




            }




            if (config.Biometrico == "Futronic FS88H")


            {

                llamar.mainForm = "llamar formulario MainForm";


            }







        }
        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate()
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

        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }

      

        private void EditarPersona_Click(object sender, EventArgs e)
        {








        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Empleados.Insertar_huella_temporal(ConvertImage.ImageToByteArray(Picture.Image));
            //   Registrar_clientes ven = new Registrar_clientes();
            //   ((PictureBox)ven.Controls["huella"]).Image = this.foto.Image;
            //  llamar.registrar_clientes = "llamar formulario Registrar_clientes";



            //y cargarla al pictureboox
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    foto.Image = Image.FromFile(imagen);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Elivo seleccionado no es un tipo de imagen válido");
            }







        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void Cedula_TextChanged(object sender, EventArgs e)
        {

          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string camara_call = llamar.Camara;
            textBox6.Text = camara_call;

           

            
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {


            llamar.Verificar = "verificar";

        }

        private void Cedula_Leave(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
          

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            llamar.Registro = "llamar formulario registro";
        }

        private void PictureFingerPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {
           


       

            


        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

            txtMessage.Visible = true;

            string split = txtMessage.Text;

            char[] delimitador = { '.' };
            string[] trozos = split.Split(delimitador);
            int i;
            for (i = 0; i < trozos.Length; i++)
            {

                textBox1.Text = trozos[0];



            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            string split = txtMessage.Text;

            char[] delimitador = { '.' };
            string[] trozos = split.Split(delimitador);
            int i;
            for (i = 0; i < trozos.Length; i++)
            {

                textBox1.Text = trozos[0];



            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "El proceso de inscripción finalizó con éxito")

            {
                EditarPersona.Visible = true;

               

            }


            }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)

            {
                sexo.Text = "Masculino";

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)

            {
                sexo.Text = "Femenino";

            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

            SqlConnection conexion = bd_comun.ObtenerConexion();
             
            
            string consulta = "select cedula from DatosPersonal where cedula ='" + Cedula.Text + "';";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader LectorDatos;
            LectorDatos = comando.ExecuteReader();
            Boolean ExistenciaRegistros = LectorDatos.HasRows;

            if (ExistenciaRegistros)
            {

                MessageBox.Show("El Registro  ya existe ", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }


            else
            {

                Clientes.Insert(obj.cedula, obj.Name, Apellidos.Text, ConvertImage.ImageToByteArray(foto.Image), ConvertImage.ImageToByteArray(PictureFingerPrint.Image));



                llamar.Registro = "llamar formulario registro";


            }
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {

        }

        private void btnconvneg_Click(object sender, EventArgs e)
        {

        }

        private void Registrar_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

          


           

        }

        private void button19_Click(object sender, EventArgs e)
        {

            SPLIT();



        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {



                nombre.Text = nombre.Text.Replace("FO", ",");


                string split = nombre.Text;

                char[] delimitador = { ',' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {

                    nombre.Text = trozos[0];


                }




            }
            catch (Exception)
            {

            }



        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {



                nombre.Text = nombre.Text.Replace("MA", ",");

                string split = nombre.Text;

                char[] delimitador = { ',' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {

                    nombre.Text = trozos[0];


                }







            }
            catch (Exception)
            {

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int num = textBox4_2.Items.Count - 1;


            if (i == num)
            {

                i = 0;
                textBox4_2.SelectedIndex = 0;

            }
            else
            {
                textBox4_2.SelectedIndex++;
                i++;

            }
        }

        private void textBox4_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox4_2.Text.ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "MA")
            {
                label27.Text = textBox8.Text;



                textBox8.Text = "";

            }
            else
            {

                textBox8.Text = "";
            }
        }

        private void segundo_nombre_TextChanged(object sender, EventArgs e)
        {
            label27.Text = "FO";

            segundo_nombre.Text = "";
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {
            name.Text = nombre.Text.ToString();
        }

        private void bunifuImageButton4_Click_2(object sender, EventArgs e)
        {
            SPLIT();

        }

        private void label27_TextChanged(object sender, EventArgs e)
        {
            if (label27.Text == "MA")
            {

                radioButton2.Checked = true;


            }


            else if (label27.Text == "FO")
            {

                radioButton1.Checked = true;
 

            }



        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            limpiar();





            string cadena = textBox4.Text;





            //--------------------------------------OBTENER EL VALOR CEDULA--------------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            try
            {


                string split = textBox4.Text;

                char[] delimitador = { '?' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {


                    Filtro_cedula.Text = trozos[1];



                    // name2.Text = trozos[1];

                }


            }
            catch (Exception)
            {


            }






            //--------------------------------------OBTENER EL VALOR CEDULA tipo1 -------------------------------------------------------------




            try
            {

                string TEXTO = Filtro_cedula.Text;
                cedula_1.Text = TEXTO.Substring(7, 10);
                Cedula.Text = TEXTO.Substring(7, 10);



            }
            catch (Exception)
            {

            }







            //-------------------------------------------------------------------------------------------------------------------------------



            try
            {

                string TEXTO = textBox4.Text;
                Cedula.Text = TEXTO.Substring(33, 10);
                cedula_2.Text = TEXTO.Substring(33, 10);
            }
            catch (Exception)
            {

            }






            //------------------------------------------------------------------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------------------------------------


            try
            {
                nombre.Text = cadena.Substring(56, 6);




                string input = textBox4.Text;
                string chars = new String(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());

                nombre.Text = chars;



                string sentence = nombre.Text;
                string filter = sentence.Remove(0, 1);

                nombre.Text = filter;




            }
            catch (Exception)
            {

            }



            //   try
            //   {
            //    nombre.Text = nombre.Text.Substring(0, nombre.Text.Count() - 30);  //longitud  que recorte  a partir de 30  caracteres
            //  }
            // catch (Exception)
            //   {

            // }




            //agale




            //-------------------------validar para cedulas femeninas



            try
            {
                femenino.Text = nombre.Text.Substring(17, nombre.Text.Count() - 121);  //longitud  que recorte  a partir de 30  caracteres
            }
            catch (Exception)
            {

            }


            //-------------------------------------------------------------------------------------------------------------------






            //-------------------------validar para cedulas masculinas



            try
            {
                masculino.Text = nombre.Text.Substring(25, nombre.Text.Count() - 53);  //longitud  que recorte  a partir de 30  caracteres
            }
            catch (Exception)
            {

            }

            //-------------------------------------------------------------------------------------------------------------------


            if (label27.Text == "FO")
            {
                try
                {



                    nombre.Text = nombre.Text.Replace("FO", ",");


                    string split = nombre.Text;

                    char[] delimitador = { ',' };
                    string[] trozos = split.Split(delimitador);
                    int i;
                    for (i = 0; i < trozos.Length; i++)
                    {

                        nombre.Text = trozos[0];


                    }




                }
                catch (Exception)
                {

                }


            }




            else if (label27.Text == "MA")
            {
                try
                {



                    nombre.Text = nombre.Text.Replace("MA", ",");

                    string split = nombre.Text;

                    char[] delimitador = { ',' };
                    string[] trozos = split.Split(delimitador);
                    int i;
                    for (i = 0; i < trozos.Length; i++)
                    {

                        nombre.Text = trozos[0];


                    }







                }
                catch (Exception)
                {

                }

            }

            //-------------------------------------------------------------------------------------------------------------------------------------------------------




            //split para las cedulas que tengan signo de interrogacion al comienzo

            try
            {





                string split = nombre.Text;

                char[] delimitador = { '?' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {

                    nombre.Text = trozos[1];
                    name3.Text = trozos[0];




                }




            }
            catch (Exception)
            {

            }









            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------




        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {

            }

            else
            {

                Configuracion.Insert_error_cadena("", "", this.textBox4.Text, "", "");
            }
            
        }

        private void name_TextChanged(object sender, EventArgs e)
        {

            //------------------------------split ¿---------------------------------------------------------------------------------------------------------------------
            // name.Text = name.Text.Replace("¿", ",");
           

            obj.Respaldo = name.Text;

     

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = comboBox2.Text.ToString();
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            int num = comboBox2.Items.Count - 1;


            if (i == num)
            {

                i = 0;
                comboBox2.SelectedIndex = 0;

            }
            else
            {
                comboBox2.SelectedIndex++;
                i++;

            }
        }

        private void femenino_TextChanged(object sender, EventArgs e)
        {
            label27.Text = "FO";

            femenino.Text = "";
        }

        private void masculino_TextChanged(object sender, EventArgs e)
        {
            if (masculino.Text == "MA")
            {
                label27.Text = masculino.Text;



                masculino.Text = "";

            }
            else
            {

                masculino.Text = "";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            int temp = 0;



            if (int.TryParse(cedula_validar.Text, out temp))
            {
                MessageBox.Show("son numeros");
            }
            else
            {
                Cedula.Text = cedula_1.Text;
            }
        }

        private void cedula_validar_TextChanged(object sender, EventArgs e)
        {

            try
            {

                int temp = 0;



                if (int.TryParse(cedula_validar.Text, out temp))
                {
                   
                }
                else
                {
                    Cedula.Text = cedula_1.Text;
                }


            }
            catch (Exception)
            {


            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
          //  name.Text = name.Text.Replace("MO", "");



            try
            {
                string cadena = copia.Text;
                sexo_txt.Text = cadena.Substring(cadena.Length - 2, 2);

            }
            catch (Exception)
            {

            }



        }

        private void copia_TextChanged(object sender, EventArgs e)
        {



      



          
        }

        private void sexo_txt_TextChanged(object sender, EventArgs e)
        {




        }

        private void nombres_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {

           


        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
          

        }

        private void teclado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_3(object sender, EventArgs e)
        {
            desifrar_cedula();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

          

             

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = comboBox3.Text;
        }

        private void button7_Click_4(object sender, EventArgs e)
        {
            sexo_call.Text = sexo_objet;
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            //metodo utilizado para examinar las imagenes en el computador
            //y cargarla al pictureboox
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    foto.Image = Image.FromFile(imagen);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Elivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //metodo utilizado para examinar las imagenes en el computador
            //y cargarla al pictureboox
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    PictureFingerPrint.Image = Image.FromFile(imagen);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Elivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void identidad_TextChanged(object sender, EventArgs e)
        {
            try
            {





                for (int i = 0; i <= textBox4.TextLength; i++)
                {

                    label7.Text = i.ToString();


                }

                if (label7.Text == "80")
                {
                    textBox4.Enabled = false;




                }




                //  SPLIT();

                // button6.PerformClick();


                eliminar_caracteres();

                desifrar_cedula();

                if (name.Text == "")
                {
                    desifrar_cedula_2();

                }

                textBox5.Text = filtrar;



            }
            catch (Exception)
            {

            }
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
         
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
           
        }

        private void cedula_validar_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton24_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning)
            {

                cam.Stop();
                llamar.Status_camara = "Detenido";
            }





        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            llamar.Nombre_de_usuario = cedula_manual.Text;
            btnEnroll.PerformClick();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            automatico.Visible = true;

            manual.Visible = false;

            manual.Location = new Point(35, 496);


            //  Sistema.Location = new Point(621, 121);

            cedula_manual.Text = "";
            name_manual.Text = "";


            textBox4.Visible = true;

            label31.Visible = true;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            automatico.Visible = false;

            manual.Visible = true;

            manual.Location = new Point(1, 289);



            //    Sistema.Location = new Point(526, 71);

            textBox4.Visible = false;

            label31.Visible = false;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

            llamar.Nombre_de_usuario = name_manual.Text;
            llamar.inscribirse = "inscribirse";





            if (textBox1.Text == "El proceso de inscripción finalizó con éxito")
            {


                btnconvneg.PerformClick();
                //------------------------------------------------------------------------------------------------------------------


            }



            else
            {

                if (automatico.Visible == true)
                {
                    obj.cedula = Cedula.Text;
                    obj.Name = name.Text;






                }


                if (manual.Visible == true)
                {
                    obj.cedula = cedula_manual.Text;
                    obj.Name = name_manual.Text;

                }



                SqlConnection conexion = bd_comun.ObtenerConexion();

                string consulta = "select cedula from DatosPersonal where cedula ='" + obj.cedula + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader LectorDatos;
                LectorDatos = comando.ExecuteReader();
                Boolean ExistenciaRegistros = LectorDatos.HasRows;

                if (ExistenciaRegistros)
                {

                    MessageBox.Show("El Registro  ya existe ", "bio", MessageBoxButtons.OK, MessageBoxIcon.Information);




                }




                else
                {


                    Clientes.Insert(obj.cedula, obj.Name, Apellidos.Text, ConvertImage.ImageToByteArray(foto.Image), ConvertImage.ImageToByteArray(PictureFingerPrint.Image));


                    llamar.Detener = "detener";
                    obj.cedula = "";
                    obj.Name = "";

                    llamar.Autenticar = "llamar formulario autenticar";






                }

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string camara_call = llamar.Camara;


            if (textBox6.Text  == "detener")
            {


            

                    if (cam.IsRunning)
                    {

                        cam.Stop();


                        llamar.Status_camara = "Detenido";
                    }





            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                cam = new VideoCaptureDevice(Webcam[comboBox4.SelectedIndex].MonikerString);
                cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
                cam.Start();


            }
            catch (Exception)
            {

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {


           


        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            Webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);


            try
            {
                foreach (FilterInfo videocapturedevice in Webcam)
                {

                    comboBox4.Items.Add(videocapturedevice.Name);

                }





            }
            catch (Exception)
            {

            }



            comboBox4.SelectedIndex = 0;

            llamar.Status_camara = "iniciado";
        }
    }
}
