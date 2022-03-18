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
    public partial class consultas_copia : Form
    {
        public consultas_copia()
        {
            InitializeComponent();
        }

        Transacciones transac = new Transacciones();

        datos_personal datos = new datos_personal  ();

        private static string filtro_fecha;

        private static string id_transaccion_objet;

        private static string Fotografia;

        private static string cedula_objet;


        public string Cedula_objet
        {
            get { return cedula_objet; }
            set { cedula_objet = value; }
        }



          public string fotografia
        {
            get { return Fotografia; }
            set { Fotografia = value; }
        }







        public string Id_transaccion_objet
        {
            get { return id_transaccion_objet; }
            set { id_transaccion_objet = value; }
        }
       


        public string Filtro_fecha
        {
            get { return filtro_fecha; }
            set { filtro_fecha = value; }
        }



        public void ShowAssistanceInfo(string Name, string EmployeeNO)
        {
            try
            {
                string Path = txt_id_transaccion.Text;

                string[] filePaths = Directory.GetFiles(Path, EmployeeNO + "*.jpg");

                if (filePaths.Length > 0)
                {
                    foto.ImageLocation = filePaths[0].ToString();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(" ERROR!!!! Form=" + this.Name + " , Method = " + System.Reflection.MethodInfo.GetCurrentMethod().Name + ", Error Message = " + exc.Message);
            }
        }












        private void pasar_con_ruta()
        {



            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    
                    recibo_cedula.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();



                    try
                    {


                        foto.Image = System.Drawing.Image.FromFile("D:\\bio\\fts\\" + recibo_cedula.Text + ".jpg");

                        huella.Image = System.Drawing.Image.FromFile("D:\\bio\\hls\\" + recibo_cedula.Text + ".bmp");



                    }
                    catch (Exception)
                    {

                    }







                   

                  
                }




            }
            catch (Exception)
            {

            }







        }


        private void pasar()
        {


            if (txt_origen.Text == "notaria")
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        id_transaccion_objet = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        Transacciones.mostrar_imagenes(id_transaccion_objet, foto, huella);

                        // filtrar_imagen_huella();
                    }




                }
                catch (Exception)
                {

                }

            }


            if (txt_origen.Text == "VerDB")
            {
                pasar_con_ruta();

            }





        }






        private void filtrar_imagen_huella()
        {

            SqlConnection miconexion = bd_comun.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("select foto,huella from transacciones where Id_transaccion= @Id_transaccion", miconexion);
            cmd.Parameters.AddWithValue("@Id_transaccion", id_transaccion_objet);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("transacciones");
            byte[] MyData = new byte[0];
            byte[] MyData2 = new byte[0];
            dp.Fill(ds, "transacciones");

            if (ds.Tables["transacciones"].Rows.Count > 0)
            {

                DataRow myRow = ds.Tables["transacciones"].Rows[0];

                MyData = (byte[])myRow["foto"];
                MyData2 = (byte[])myRow["huella"];
                MemoryStream stream = new MemoryStream(MyData);
                MemoryStream stream2 = new MemoryStream(MyData2);
                foto.Image = Image.FromStream(stream);
                huella.Image = Image.FromStream(stream2);



            }

            else
            {
                MessageBox.Show("No existe", "bio", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


            miconexion.Close();


        }








        //...............---------------------------------------------------------------------------------------------------------------------------------------------


        private void Cargar_por_fecha()
        {

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Transacciones.Cargar_por_fecha(filtro_fecha);


            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    DataRowView rows = row.DataBoundItem as DataRowView;

                }

            }
            catch (Exception)
            {

            }


          


        }




        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




        //.....................................................................................................................
        private void cargar_por_Id_transaccion()
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = Transacciones.Cargar_por_Id_transaccion(txt_id_transaccion.Text);


            try
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    DataRowView rows = row.DataBoundItem as DataRowView;
                    //    row.Cells["imagen"].Value = ConvertImage.ByteArrayToImage((byte[])rows["Foto"]);
                }



            }
            catch (Exception)
            {

            }


        }


        //.....................................................................................





        //.....................................................................................................................
        private void cargar_por_Id_transaccion_de_la_otra_bd()
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = Transacciones.Cargar_por_Id_transaccion_de_la_otra_bd(txt_id_transaccion.Text);


            try
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    DataRowView rows = row.DataBoundItem as DataRowView;
                    //    row.Cells["imagen"].Value = ConvertImage.ByteArrayToImage((byte[])rows["Foto"]);
                }



            }
            catch (Exception)
            {

            }


        }


        //.....................................................................................













 //.....................................................................................................................
        private void cargar_por_cedula()
        {
            dataGridView1.AutoGenerateColumns = false;
          
            dataGridView1.DataSource = Transacciones.Cargar_por_cedula(txt_cedula.Text );
            

            try
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                   
                    DataRowView rows = row.DataBoundItem as DataRowView;
                    //    row.Cells["imagen"].Value = ConvertImage.ByteArrayToImage((byte[])rows["Foto"]);
                }



            }
            catch (Exception)
            {

            }


        }


 //.....................................................................................




 //.....................................................................................................................
        private void cargar_por_cedula_de_la_otra_bd()
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = datos_personal.Cargar_por_cedula_de_la_otra_bd(txt_cedula.Text);


            try
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    DataRowView rows = row.DataBoundItem as DataRowView;
                    //    row.Cells["imagen"].Value = ConvertImage.ByteArrayToImage((byte[])rows["Foto"]);
                }



            }
            catch (Exception)
            {

            }


        }


 //.....................................................................................









        private void cargar_tools()
        {
            dataGridView1.AutoGenerateColumns = false;
          
            dataGridView1.DataSource = Transacciones.Cargar_tools();



            try
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    DataRowView rows = row.DataBoundItem as DataRowView;

                }



            }
            catch (Exception)
            {

            }




         
        }










        private void cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Transacciones.Cargar(id);




            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    DataRowView rows = row.DataBoundItem as DataRowView;

                }
            }
            catch (Exception)
            {

            }


          
        }







        private void consultas_Load(object sender, EventArgs e)
        {
            cargar_tools();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {

            
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pasar();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pasar();


           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (cmb_origen.Text == "notaria")

            {
                cargar_por_cedula();
 
            }


            if (cmb_origen.Text == "VerDB")
            {
                cargar_por_cedula_de_la_otra_bd();

            }




            

        
           // 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            cargar_tools();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


            if (cmb_origen.Text == "notaria")
            {
                cargar_por_Id_transaccion();

            }


            if (cmb_origen.Text == "VerDB")
            {
                cargar_por_Id_transaccion_de_la_otra_bd();


            }




            
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            cargar_tools();
        }

        private void cmb_origen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_origen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txt_origen.Text = cmb_origen.Text;
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            filtro_fecha = dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year;
            txt_fecha.Text = filtro_fecha;

            Cargar_por_fecha();
        }
    }
}
