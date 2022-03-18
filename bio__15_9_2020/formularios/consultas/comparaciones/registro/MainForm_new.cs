using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Futronic.SDKHelper;


namespace bio
{
    public partial class MainForm_new : Form
    {
        const string kCompanyName = "Futronic";
        const string kProductName = "SDK 4.0";
        const string kDbName = "DataBaseNet";

        call llamar = new call();

        /// <summary>
        /// This delegate enables asynchronous calls for setting
        /// the text property on a status control.
        /// </summary>
        /// <param name="text"></param>
        delegate void SetTextCallback(string text);

        /// <summary>
        /// This delegate enables asynchronous calls for setting
        /// the text property on a identification limit control.
        /// </summary>
        /// <param name="text"></param>
        delegate void SetIdentificationLimitCallback(int limit);

        /// <summary>
        /// This delegate enables asynchronous calls for setting
        /// the Image property on a PictureBox control.
        /// </summary>
        /// <param name="hBitmap">the instance of Bitmap class</param>
        delegate void SetImageCallback(Bitmap hBitmap );

        /// <summary>
        /// This delegate enables asynchronous calls for setting
        /// the Enable property on a buttons.
        /// </summary>
        /// <param name="bEnable">true to enable buttons, otherwise to disable</param>
        delegate void EnableControlsCallback(bool bEnable );

        /// <summary>
        /// Contain reference for current operation object
        /// </summary>
        private FutronicSdkBase m_Operation;

        private bool m_bExit;

        /// <summary>
        /// The type of this parameter is depending from current operation. For
        /// enrollment operation this is DbRecord.
        /// </summary>
        private Object m_OperationObj;

        /// <summary>
        /// A directory name to write user's information.
        /// </summary>
        private String m_DatabaseDir;

        private bool m_bInitializationSuccess;

        static private ComboBoxItem[] rgVersionItems = new ComboBoxItem[]
            {
                new ComboBoxItem( "SDK 3.0", VersionCompatible.ftr_version_previous ),
                new ComboBoxItem( "SDK 3.5", VersionCompatible.ftr_version_current ),
                new ComboBoxItem( "Both", VersionCompatible.ftr_version_compatible )
            };

        public MainForm_new()
        {
            InitializeComponent();
            m_bInitializationSuccess = false;
            // Create FutronicEnrollment object for retrieve default values only
            FutronicEnrollment dummy = new FutronicEnrollment();
            cbFARNLevel.SelectedIndex = (int)dummy.FARnLevel;
            cbMaxFrames.SelectedItem = dummy.MaxModels.ToString();
            chDetectFakeFinger.Checked = dummy.FakeDetection;
            cbMIOTOff.Checked = dummy.MIOTControlOff;
            chFastMode.Checked = dummy.FastMode;
            SetIdentificationLimit(dummy.IdentificationsLeft);
            btnStop.Enabled = false;
            m_bExit = false;
            int selectedIndex = 0, itemIndex;
            foreach( ComboBoxItem item in rgVersionItems )
            {
                itemIndex = m_cmbVersion.Items.Add(item);
                if ((VersionCompatible)item.Tag == dummy.Version)
                {
                    selectedIndex = itemIndex;
                }
            }
            m_cmbVersion.SelectedIndex = selectedIndex;

            try
            {
                m_DatabaseDir = GetDatabaseDir();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(this, "Initialization failed. Application will be close.\nCan not create database folder. Access denied.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (IOException)
            {
                MessageBox.Show(this, "Initialization failed. Application will be close.\nCan not create database folder",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            m_bInitializationSuccess = true;
        }

        private void SetIdentificationLimit(int nLimit)
        {
            if( this.m_lblIdentificationsLimit.InvokeRequired )
            {
                SetIdentificationLimitCallback d = new SetIdentificationLimitCallback(this.SetIdentificationLimit);
                this.Invoke( d, new object[] { nLimit } );
            } else {
                if (nLimit == Int32.MaxValue)
                {
                    m_lblIdentificationsLimit.Text = "Identification limit: No limits";
                }
                else
                {
                    m_lblIdentificationsLimit.Text = String.Format("Identification limit: {0}", nLimit);
                }
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            DbRecord User = new DbRecord();
            
            // Get user name
            EnrollmentName frmName = new EnrollmentName();
            frmName.ShowDialog( this );
            if (frmName.DialogResult != DialogResult.OK )
            {
                return;
            }
        
            // Try creat the file for user's information
            if( isUserExists(frmName.UserName) )
            {
                DialogResult nResponse;
                nResponse = MessageBox.Show("Documento ID ya existe. �Quieres reemplazarlo?",
                                            "bio",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (nResponse == DialogResult.No)
                    return;
            } else {
                try
                {
                    CreateFile(frmName.UserName);
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show(this, "No se puede crear un archivo para guardar la informaci�n de un usuario.", this.Text,
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                catch (IOException )
                {
                    MessageBox.Show(this, String.Format("Nombre de usuario incorrecto '{0}'.", frmName.UserName),
                                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            User.UserName = frmName.UserName;

            m_OperationObj = User;
            FutronicSdkBase dummy = new FutronicEnrollment();
            if (m_Operation != null)
            {
                m_Operation.Dispose();
                m_Operation = null;
            }
            m_Operation = dummy;

            // Set control properties
            m_Operation.FakeDetection = chDetectFakeFinger.Checked;
            m_Operation.FFDControl = true;
            m_Operation.FARN = Int32.Parse(tbFARN.Text);
            m_Operation.Version = (VersionCompatible)((ComboBoxItem)m_cmbVersion.SelectedItem).Tag;
            m_Operation.FastMode = chFastMode.Checked;
            ((FutronicEnrollment)m_Operation).MIOTControlOff = cbMIOTOff.Checked;
            ((FutronicEnrollment)m_Operation).MaxModels = Int32.Parse( (String)cbMaxFrames.SelectedItem );

            EnableControls(false);

            // register events
            m_Operation.OnPutOn += new OnPutOnHandler(this.OnPutOn);
            m_Operation.OnTakeOff += new OnTakeOffHandler(this.OnTakeOff);
            m_Operation.UpdateScreenImage += new UpdateScreenImageHandler(this.UpdateScreenImage);
            m_Operation.OnFakeSource += new OnFakeSourceHandler(this.OnFakeSource);
            ((FutronicEnrollment)m_Operation).OnEnrollmentComplete += new OnEnrollmentCompleteHandler(this.OnEnrollmentComplete);

            // start enrollment process
            ((FutronicEnrollment)m_Operation).Enrollment();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            SetStatusText("Programme is loading database, please wait ...");
            List<DbRecord> Users = DbRecord.ReadRecords(m_DatabaseDir);
            SetStatusText( String.Empty );
            if (Users.Count == 0)
            {
                EnableControls(true);
                MessageBox.Show(this, "Users not found. Please, run enrollment process first.", 
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // select user's information for verification
            SelectUser frmSelectUser = new SelectUser( Users, m_DatabaseDir );
            frmSelectUser.ShowDialog( this );

            if( frmSelectUser.SelectedUser == null )
            {
                EnableControls(true);
                MessageBox.Show(this, "No selected user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            m_OperationObj = frmSelectUser.SelectedUser;

            FutronicSdkBase dummy = new FutronicVerification(((DbRecord)m_OperationObj).Template);
            if (m_Operation != null)
            {
                m_Operation.Dispose();
                m_Operation = null;
            }
            m_Operation = dummy;

            // Set control properties
            m_Operation.FakeDetection = chDetectFakeFinger.Checked;
            m_Operation.FFDControl = true;
            m_Operation.FARN = Int32.Parse(tbFARN.Text);
            m_Operation.Version = (VersionCompatible)((ComboBoxItem)m_cmbVersion.SelectedItem).Tag;
            m_Operation.FastMode = chFastMode.Checked;

            // register events
            m_Operation.OnPutOn += new OnPutOnHandler(this.OnPutOn);
            m_Operation.OnTakeOff += new OnTakeOffHandler(this.OnTakeOff);
            m_Operation.UpdateScreenImage += new UpdateScreenImageHandler(this.UpdateScreenImage);
            m_Operation.OnFakeSource += new OnFakeSourceHandler(this.OnFakeSource);
            ((FutronicVerification)m_Operation).OnVerificationComplete += new OnVerificationCompleteHandler(this.OnVerificationComplete);

            // start verification process
            ((FutronicVerification)m_Operation).Verification();
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            SetStatusText("El programa est� cargando la base de datos, espere.....");
            List<DbRecord> Users = DbRecord.ReadRecords( m_DatabaseDir );
            SetStatusText(String.Empty);
            if (Users.Count == 0)
            {
                MessageBox.Show(this, "Usuarios no encontrados. Por favor, ejecute el proceso de inscripci�n primero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EnableControls(true);
                return;
            }
            m_OperationObj = Users;
            FutronicSdkBase dummy = new FutronicIdentification();
            if (m_Operation != null)
            {
                m_Operation.Dispose();
                m_Operation = null;
            }
            m_Operation = dummy;

            // Set control property
            m_Operation.FakeDetection = chDetectFakeFinger.Checked;
            m_Operation.FFDControl = true;
            m_Operation.FARN = Int32.Parse(tbFARN.Text);
            m_Operation.Version = (VersionCompatible)((ComboBoxItem)m_cmbVersion.SelectedItem).Tag;
            m_Operation.FastMode = chFastMode.Checked;

            // register events
            m_Operation.OnPutOn += new OnPutOnHandler(this.OnPutOn);
            m_Operation.OnTakeOff += new OnTakeOffHandler(this.OnTakeOff);
            m_Operation.UpdateScreenImage += new UpdateScreenImageHandler(this.UpdateScreenImage);
            m_Operation.OnFakeSource += new OnFakeSourceHandler(this.OnFakeSource);
            ((FutronicIdentification)m_Operation).OnGetBaseTemplateComplete += 
                    new OnGetBaseTemplateCompleteHandler(this.OnGetBaseTemplateComplete );

            // start identification process
            ((FutronicIdentification)m_Operation).GetBaseTemplate();
        }

        private void cbFARNLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( cbFARNLevel.SelectedIndex == 6 )
            {
                tbFARN.ReadOnly = false;
            } else {
                tbFARN.Text = FutronicSdkBase.rgFARN[cbFARNLevel.SelectedIndex].ToString();
                tbFARN.ReadOnly = true;
            }
        }

        private void OnPutOn(FTR_PROGRESS Progress)
        {
            this.SetStatusText("Pon el dedo en el dispositivo, por favor ...");
        }

        private void OnTakeOff(FTR_PROGRESS Progress)
        {
            this.SetStatusText("Quite el dedo del dispositivo, por favor ...");
        }

        private void UpdateScreenImage(Bitmap hBitmap)
        {
            // Do not change the state control during application closing.
            if (m_bExit)
                return;

            if( PictureFingerPrint.InvokeRequired )
            {
                SetImageCallback d = new SetImageCallback(this.UpdateScreenImage);
                this.Invoke(d, new object[] { hBitmap });
            }
            else
            {
                PictureFingerPrint.Image = hBitmap;
            }
        }

        private bool OnFakeSource(FTR_PROGRESS Progress)
        {
            if( m_bExit )
                return true;

            DialogResult result;
            result = MessageBox.Show("Fuente falsa detectada. �Quieres continuar el proceso ?? ",
                                     "bio",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (result == DialogResult.No);
        }

        private void OnEnrollmentComplete(bool bSuccess, int nRetCode )
        {
            StringBuilder szMessage = new StringBuilder();
            if (bSuccess)
            {
                // set status string
                szMessage.Append("El proceso de inscripci�n finaliz� con �xito..");
                szMessage.Append("Calidad: ");
                szMessage.Append(((FutronicEnrollment)m_Operation).Quality.ToString() );
                this.SetStatusText(szMessage.ToString());

                // Set template into user's information and save it
                DbRecord User = (DbRecord)m_OperationObj;
                User.Template = ((FutronicEnrollment)m_Operation).Template;

                String szFileName = Path.Combine(m_DatabaseDir, User.UserName );
                if (!User.Save(szFileName) )
                {
                    MessageBox.Show("No se puede guardar la informaci�n del usuario en el archivo" + szFileName,
                                     "bio",
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                szMessage.Append("El proceso de inscripci�n fall�..");
                szMessage.Append("Error de descripci�n: ");
                szMessage.Append(FutronicSdkBase.SdkRetCode2Message(nRetCode));
                this.SetStatusText(szMessage.ToString() );
            }

            // unregister events
            m_Operation.OnPutOn -= new OnPutOnHandler(this.OnPutOn);
            m_Operation.OnTakeOff -= new OnTakeOffHandler(this.OnTakeOff);
            m_Operation.UpdateScreenImage -= new UpdateScreenImageHandler(this.UpdateScreenImage);
            m_Operation.OnFakeSource -= new OnFakeSourceHandler(this.OnFakeSource);
            ((FutronicEnrollment)m_Operation).OnEnrollmentComplete -= new OnEnrollmentCompleteHandler(this.OnEnrollmentComplete);

            m_OperationObj = null;
            EnableControls(true);
        }

        private void OnVerificationComplete(bool bSuccess,
                                            int nRetCode,
                                            bool bVerificationSuccess)
        {
            StringBuilder szResult = new StringBuilder();
            if (bSuccess)
            {
                if (bVerificationSuccess)
                {
                    szResult.Append("La verificaci�n es exitosa.");
                    szResult.Append("Nombre de usuario: ");
                    szResult.Append(((DbRecord)m_OperationObj).UserName);
                }
                else
                    szResult.Append("Fallo en la verificaci�n.");
            }
            else
            {
                szResult.Append("Proceso de verificaci�n fallido.");
                szResult.Append("Error de descripci�n: ");
                szResult.Append(FutronicSdkBase.SdkRetCode2Message(nRetCode));
            }

            this.SetStatusText(szResult.ToString());
            this.SetIdentificationLimit(m_Operation.IdentificationsLeft);

            // unregister events
            m_Operation.OnPutOn -= new OnPutOnHandler(this.OnPutOn);
            m_Operation.OnTakeOff -= new OnTakeOffHandler(this.OnTakeOff);
            m_Operation.UpdateScreenImage -= new UpdateScreenImageHandler(this.UpdateScreenImage);
            m_Operation.OnFakeSource -= new OnFakeSourceHandler(this.OnFakeSource);
            ((FutronicVerification)m_Operation).OnVerificationComplete -= new OnVerificationCompleteHandler(this.OnVerificationComplete);

            m_OperationObj = null;
            EnableControls(true);
        }

        private void OnGetBaseTemplateComplete(bool bSuccess, int nRetCode)
        {
            StringBuilder szMessage = new StringBuilder();
            if (bSuccess)
            {
                this.SetStatusText("Identificaci�n de inicio...");
                List<DbRecord> Users = (List<DbRecord>)m_OperationObj;

                int iRecords = 0;
                int nResult;
                FtrIdentifyRecord[] rgRecords = new FtrIdentifyRecord[Users.Count];
                foreach (DbRecord item in Users)
                {
                    rgRecords[iRecords] = item.GetRecord();
                    iRecords++;
                }
                nResult = ((FutronicIdentification)m_Operation).Identification(rgRecords, ref iRecords);
                if (nResult == FutronicSdkBase.RETCODE_OK)
                {
                    szMessage.Append("Proceso de identificaci�n completo. Usuario: ");
                    if (iRecords != -1)
                        szMessage.Append(Users[iRecords].UserName);
                    else
                        szMessage.Append("extraviado");
                }
                else
                {
                    szMessage.Append("Identificaci�n fallida.");
                    szMessage.Append(FutronicSdkBase.SdkRetCode2Message(nResult));
                }
                this.SetIdentificationLimit(m_Operation.IdentificationsLeft);
            }
            else
            {
                szMessage.Append("No se puede recuperar la plantilla base.");
                szMessage.Append("Error de descripci�n: ");
                szMessage.Append( FutronicSdkBase.SdkRetCode2Message(nRetCode) );
            }
            this.SetStatusText(szMessage.ToString());
            
            // unregister events
            m_Operation.OnPutOn -= new OnPutOnHandler(this.OnPutOn);
            m_Operation.OnTakeOff -= new OnTakeOffHandler(this.OnTakeOff);
            m_Operation.UpdateScreenImage -= new UpdateScreenImageHandler(this.UpdateScreenImage);
            m_Operation.OnFakeSource -= new OnFakeSourceHandler(this.OnFakeSource);
            ((FutronicIdentification)m_Operation).OnGetBaseTemplateComplete -=
                    new OnGetBaseTemplateCompleteHandler(this.OnGetBaseTemplateComplete);

            m_OperationObj = null;
            EnableControls(true);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            m_Operation.OnCalcel();
        }

        private void EnableControls(bool bEnable)
        {
            // Do not change the state control during application closing.
            if( m_bExit )
                return;
            if (this.InvokeRequired)
            {
                EnableControlsCallback d = new EnableControlsCallback(this.EnableControls);
                this.Invoke( d, new object[] { bEnable } );
            }
            else
            {
                btnEnroll.Enabled = bEnable;
                btnIdentify.Enabled = bEnable;
                btnVerify.Enabled = bEnable;
                btnStop.Enabled = !bEnable;
            }
        }

        private void SetStatusText(String text)
        {
            // Do not change the state control during application closing.
            if( m_bExit )
                return;

            if (this.txtMessage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(this.SetStatusText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtMessage.Text = text;
                this.Update();
            }
        }

        /// <summary>
        /// Get the database directory.
        /// </summary>
        /// <returns>returns the database directory.</returns>
        public static String GetDatabaseDir()
        {
            String szDbDir;
            szDbDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.Create);
            szDbDir = Path.Combine(szDbDir, kCompanyName);
            if (!Directory.Exists(szDbDir))
            {
                Directory.CreateDirectory(szDbDir);
            }
            szDbDir = Path.Combine(szDbDir, kProductName);
            if (!Directory.Exists(szDbDir))
            {
                Directory.CreateDirectory(szDbDir);
            }

            szDbDir = Path.Combine(szDbDir, kDbName);
            if (!Directory.Exists(szDbDir))
            {
                Directory.CreateDirectory(szDbDir);
            }

            return szDbDir;
        }

        protected bool isUserExists(String UserName)
        {
            String szFileName;
            szFileName = Path.Combine(m_DatabaseDir, UserName );
            return File.Exists(szFileName);
        }

        protected void CreateFile(String UserName)
        {


            try
            {

                String szFileName;
                szFileName = Path.Combine(m_DatabaseDir, UserName);
                File.Create(szFileName).Close();
                File.Delete(szFileName);


            }
            catch (Exception)
            {


            }




        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            m_bExit = true;
            if (m_Operation != null)
            {
                m_Operation.Dispose();
            }
            base.OnFormClosing(e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // aqui------------------------------------------------------------------------

            Defabrica.eliminar_huella_tmp();
            Defabrica.guardar_huella_tmp(ConvertImage.ImageToByteArray(PictureFingerPrint.Image));

        }

        private void tbFARN_Validating(object sender, CancelEventArgs e)
        {
            int nValue = -1;

            try
            {
                nValue = Int32.Parse(tbFARN.Text);
            }
            catch (FormatException)
            {
            }
            if(nValue > 1000 || nValue < 1)
            {
                MessageBox.Show(this, "Valor FARN no v�lido El rango de valor es de 1 a 1000", this.Text,
                                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }

        }

        private void MainForm_new_Load(object sender, EventArgs e)
        {

            timer1.Enabled = true;

            if (!m_bInitializationSuccess)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            llamar.TxtMessage = resultado2.Text;

            string inscribirse_call = llamar.inscribirse;

            string verificar_call = llamar.Verificar;

            string Identificar_call = llamar.identificar;

            string detener_call = llamar.Detener;

            string salida_call = llamar.Salida;

            string split_call = llamar.Split;

            llamar.Status_biometrico_futronic_f88 = txtMessage.Text;



            if (inscribirse_call == "inscribirse")

            {

                timer2.Enabled = true;

            }




            if (verificar_call == "verificar")

            {

                timer2.Enabled = true;


            }

            if (Identificar_call == "identificar")

            {

                timer2.Enabled = true;


            }


            if (detener_call == "detener")

            {

                timer2.Enabled = true;


            }


            if (salida_call == "salida")

            {
                timer2.Enabled = true;

            }


            if (split_call == "split")

            {
                timer2.Enabled = true;

                

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            llamar.TxtMessage = resultado2.Text;

            string inscribirse_call = llamar.inscribirse;

            string verificar_call = llamar.Verificar;

            string Identificar_call = llamar.identificar;


            string detener_call = llamar.Detener;

            string salida_call = llamar.Salida;

            string split_call = llamar.Split;






            if (inscribirse_call == "inscribirse")

            {
                llamar.inscribirse = "";
                inscribirse_call = "";


                btnEnroll.PerformClick();


            }


            if (verificar_call == "verificar")

            {
                llamar.Verificar = "";
                verificar_call = "";


                btnVerify.PerformClick();




            }


            if (Identificar_call == "identificar")

            {

                llamar.identificar = "";
                Identificar_call = "";
                btnIdentify.PerformClick();


            }




            if (detener_call == "detener")

            {
                llamar.Detener = "";
                detener_call = "";
                Detener.PerformClick();


            }


            if (salida_call == "salida")

            {
                llamar.Salida = "";
                salida_call = "";
                btnExit.PerformClick();


            }



            if (split_call == "split")
            {
                

                string split = txtMessage.Text;


                char[] delimitador = { ':' };
                string[] trozos = split.Split(delimitador);
                int i;
                for (i = 0; i < trozos.Length; i++)
                {

                    resultado.Text = trozos[0];
                    resultado2.Text = trozos[1];
                    llamar.Split_devuelto = resultado2.Text;


                    llamar.Split = "";
                    split_call = "";

                }





            }

            


            timer2.Enabled = false;

        }

        private void split_Click(object sender, EventArgs e)
        {
            string split = txtMessage.Text;

            char[] delimitador = { ':' };
            string[] trozos = split.Split(delimitador);
            int i;
            for (i = 0; i < trozos.Length; i++)
            {

                resultado.Text = trozos[0];
                resultado2.Text = trozos[1];
                llamar.Split_devuelto = resultado2.Text;

            }
        }

        private void Detener_Click(object sender, EventArgs e)
        {

            try
            {

                m_Operation.OnCalcel();

            }
            catch (Exception)
            {


            }



           
        }

        private void resultado2_TextChanged(object sender, EventArgs e)
        {
            llamar.Split_devuelto = resultado2.Text;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            string split = txtMessage.Text;

            char[] delimitador = { ':' };
            string[] trozos = split.Split(delimitador);
            int i;
            for (i = 0; i < trozos.Length; i++)
            {

                resultado.Text = trozos[0];
                resultado2.Text = trozos[1];
                llamar.Split_devuelto = resultado2.Text;

            }

            timer3.Enabled = false;
        }
    }
}
