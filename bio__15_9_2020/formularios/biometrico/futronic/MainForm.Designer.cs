namespace bio
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnEnroll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chFastMode = new System.Windows.Forms.CheckBox();
            this.m_cmbVersion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblIdentificationsLimit = new System.Windows.Forms.Label();
            this.cbMaxFrames = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMIOTOff = new System.Windows.Forms.CheckBox();
            this.tbFARN = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFARNLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chDetectFakeFinger = new System.Windows.Forms.CheckBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.PictureFingerPrint = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureFingerPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(6, 19);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(75, 23);
            this.btnEnroll.TabIndex = 0;
            this.btnEnroll.Text = "Inscribirse";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chFastMode);
            this.groupBox1.Controls.Add(this.m_cmbVersion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_lblIdentificationsLimit);
            this.groupBox1.Controls.Add(this.cbMaxFrames);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMIOTOff);
            this.groupBox1.Controls.Add(this.tbFARN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbFARNLevel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chDetectFakeFinger);
            this.groupBox1.Location = new System.Drawing.Point(272, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(22, 16);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Settings ";
            // 
            // chFastMode
            // 
            this.chFastMode.AutoSize = true;
            this.chFastMode.Location = new System.Drawing.Point(200, 28);
            this.chFastMode.Name = "chFastMode";
            this.chFastMode.Size = new System.Drawing.Size(85, 17);
            this.chFastMode.TabIndex = 12;
            this.chFastMode.Text = "Modo rápido";
            this.chFastMode.UseVisualStyleBackColor = true;
            // 
            // m_cmbVersion
            // 
            this.m_cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbVersion.FormattingEnabled = true;
            this.m_cmbVersion.Location = new System.Drawing.Point(266, 139);
            this.m_cmbVersion.Name = "m_cmbVersion";
            this.m_cmbVersion.Size = new System.Drawing.Size(121, 21);
            this.m_cmbVersion.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "El procesamiento de imágenes es compatible con";
            // 
            // m_lblIdentificationsLimit
            // 
            this.m_lblIdentificationsLimit.Location = new System.Drawing.Point(16, 172);
            this.m_lblIdentificationsLimit.Name = "m_lblIdentificationsLimit";
            this.m_lblIdentificationsLimit.Size = new System.Drawing.Size(402, 23);
            this.m_lblIdentificationsLimit.TabIndex = 9;
            this.m_lblIdentificationsLimit.Text = "label4";
            // 
            // cbMaxFrames
            // 
            this.cbMaxFrames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxFrames.FormattingEnabled = true;
            this.cbMaxFrames.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMaxFrames.Location = new System.Drawing.Point(223, 114);
            this.cbMaxFrames.Name = "cbMaxFrames";
            this.cbMaxFrames.Size = new System.Drawing.Size(43, 21);
            this.cbMaxFrames.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Establecer marcos máximos en la plantilla";
            // 
            // cbMIOTOff
            // 
            this.cbMIOTOff.AutoSize = true;
            this.cbMIOTOff.Location = new System.Drawing.Point(16, 87);
            this.cbMIOTOff.Name = "cbMIOTOff";
            this.cbMIOTOff.Size = new System.Drawing.Size(111, 17);
            this.cbMIOTOff.TabIndex = 6;
            this.cbMIOTOff.Text = "Deshabilitar MIOT";
            this.cbMIOTOff.UseVisualStyleBackColor = true;
            // 
            // tbFARN
            // 
            this.tbFARN.Culture = new System.Globalization.CultureInfo("");
            this.tbFARN.Location = new System.Drawing.Point(339, 56);
            this.tbFARN.Mask = "0000";
            this.tbFARN.Name = "tbFARN";
            this.tbFARN.Size = new System.Drawing.Size(48, 20);
            this.tbFARN.TabIndex = 5;
            this.tbFARN.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tbFARN.ValidatingType = typeof(int);
            this.tbFARN.Validating += new System.ComponentModel.CancelEventHandler(this.tbFARN_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "valor";
            // 
            // cbFARNLevel
            // 
            this.cbFARNLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFARNLevel.FormattingEnabled = true;
            this.cbFARNLevel.Items.AddRange(new object[] {
            "low",
            "below normal",
            "normal",
            "above normal",
            "high",
            "maximum",
            "custom"});
            this.cbFARNLevel.Location = new System.Drawing.Point(158, 56);
            this.cbFARNLevel.Name = "cbFARNLevel";
            this.cbFARNLevel.Size = new System.Drawing.Size(121, 21);
            this.cbFARNLevel.TabIndex = 2;
            this.cbFARNLevel.SelectedIndexChanged += new System.EventHandler(this.cbFARNLevel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Establecer nivel de medida";
            // 
            // chDetectFakeFinger
            // 
            this.chDetectFakeFinger.AutoSize = true;
            this.chDetectFakeFinger.Location = new System.Drawing.Point(16, 28);
            this.chDetectFakeFinger.Name = "chDetectFakeFinger";
            this.chDetectFakeFinger.Size = new System.Drawing.Size(119, 17);
            this.chDetectFakeFinger.TabIndex = 0;
            this.chDetectFakeFinger.Text = "Detectar dedo falso";
            this.chDetectFakeFinger.UseVisualStyleBackColor = true;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(6, 48);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 3;
            this.btnVerify.Text = "Verificar";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(6, 77);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(75, 23);
            this.btnIdentify.TabIndex = 4;
            this.btnIdentify.Text = "Identificar";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEnroll);
            this.groupBox2.Controls.Add(this.btnIdentify);
            this.groupBox2.Controls.Add(this.btnVerify);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Location = new System.Drawing.Point(12, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 142);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operaciones";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(101, 28);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Detener";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(185, 28);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Salida";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(-1, 126);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(184, 20);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.TabStop = false;
            // 
            // PictureFingerPrint
            // 
            this.PictureFingerPrint.BackgroundImage = global::bio.Properties.Resources.ssss;
            this.PictureFingerPrint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureFingerPrint.Image = global::bio.Properties.Resources.ssss1;
            this.PictureFingerPrint.InitialImage = null;
            this.PictureFingerPrint.Location = new System.Drawing.Point(-1, 0);
            this.PictureFingerPrint.Name = "PictureFingerPrint";
            this.PictureFingerPrint.Size = new System.Drawing.Size(133, 120);
            this.PictureFingerPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureFingerPrint.TabIndex = 1;
            this.PictureFingerPrint.TabStop = false;
            this.PictureFingerPrint.WaitOnLoad = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(132, 2);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(54, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Inscribirse";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(135, 24);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(45, 13);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Verificar";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(133, 49);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(53, 13);
            this.linkLabel3.TabIndex = 10;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Identificar";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(137, 74);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(45, 13);
            this.linkLabel4.TabIndex = 11;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Detener";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(137, 99);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(36, 13);
            this.linkLabel5.TabIndex = 12;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Salida";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 305);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PictureFingerPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureFingerPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.PictureBox PictureFingerPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chDetectFakeFinger;
        private System.Windows.Forms.ComboBox cbFARNLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbFARN;
        private System.Windows.Forms.ComboBox cbMaxFrames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbMIOTOff;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label m_lblIdentificationsLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox m_cmbVersion;
        private System.Windows.Forms.CheckBox chFastMode;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.Timer timer1;
    }
}

