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

    public partial class CapturarHuella : CaptureForm
    {
        public delegate void OnTemplateEventHandler(DPFP.Template template);

        public event OnTemplateEventHandler OnTemplate;

        private DPFP.Processing.Enrollment Enroller;

        protected override void Init()
        {
            base.Init();
            base.Text = "Dar de alta Huella";
            Enroller = new DPFP.Processing.Enrollment();            //  Crear una inscripción
            UpdateStatus();
        }

        protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);

            // Procese la muestra y cree un conjunto de características para el propósito de inscripción.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            // Verifique la calidad de la muestra y agregue al inscriptor si es bueno
            if (features != null) try
                {
                    MakeReport("El conjunto de características de huellas dactilares fue creado.");
                    Enroller.AddFeatures(features);     // Añadir conjunto de características a la plantilla.
                    
 
                }
                finally
                {
                    UpdateStatus();

                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:   // reportar el éxito y dejar de capturar
                            OnTemplate(Enroller.Template);
                            SetPrompt("Haga clic en Cerrar y luego en Verificación de huellas dactilares.");
                            Stop();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // reportar el fallo y reiniciar la captura
                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            OnTemplate(null);
                            Start();
                            break;
                    }
                }
        }

        private void UpdateStatus()
        {
            // Muestras de huellas dactilares necesarias.
            SetStatus(String.Format("Muestras de huellas dactilares necesarias: {0}", Enroller.FeaturesNeeded));
        }

        public CapturarHuella()
        {
            InitializeComponent();
        }

        private void CapturarHuella_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

           



        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (StatusLine.Text == "El conjunto de características de huellas dactilares fue creado.")

            {
                // aqui------------------------------------------------------------------------
               // Empleados.Insertar_huella_temporal(ConvertImage.ImageToByteArray(Picture.Image));
                Registrar_clientes ven = new Registrar_clientes();

                ((PictureBox)ven.Controls["huella"]).Image = this.Picture.Image;

                ven.Show();


                Close();
 
            }
        }
    }
}
