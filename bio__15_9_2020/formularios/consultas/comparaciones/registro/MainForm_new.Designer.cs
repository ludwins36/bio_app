namespace bio
{
    partial class MainForm_new
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm_new));
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
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.split = new System.Windows.Forms.Button();
            this.Detener = new System.Windows.Forms.Button();
            this.resultado2 = new System.Windows.Forms.TextBox();
            this.resultado = new System.Windows.Forms.TextBox();
            this.PictureFingerPrint = new System.Windows.Forms.PictureBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureFingerPrint)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(143, 49);
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
            this.groupBox1.Location = new System.Drawing.Point(111, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(25, 23);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Settings ";
            this.groupBox1.Visible = false;
            // 
            // chFastMode
            // 
            this.chFastMode.AutoSize = true;
            this.chFastMode.Location = new System.Drawing.Point(200, 28);
            this.chFastMode.Name = "chFastMode";
            this.chFastMode.Size = new System.Drawing.Size(75, 17);
            this.chFastMode.TabIndex = 12;
            this.chFastMode.Text = "Fast mode";
            this.chFastMode.UseVisualStyleBackColor = true;
            // 
            // m_cmbVersion
            // 
            this.m_cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbVersion.FormattingEnabled = true;
            this.m_cmbVersion.Location = new System.Drawing.Point(200, 138);
            this.m_cmbVersion.Name = "m_cmbVersion";
            this.m_cmbVersion.Size = new System.Drawing.Size(121, 21);
            this.m_cmbVersion.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Do image processing compatible to: ";
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
            this.cbMaxFrames.Location = new System.Drawing.Point(158, 111);
            this.cbMaxFrames.Name = "cbMaxFrames";
            this.cbMaxFrames.Size = new System.Drawing.Size(43, 21);
            this.cbMaxFrames.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Set max frames in template:";
            // 
            // cbMIOTOff
            // 
            this.cbMIOTOff.AutoSize = true;
            this.cbMIOTOff.Location = new System.Drawing.Point(16, 87);
            this.cbMIOTOff.Name = "cbMIOTOff";
            this.cbMIOTOff.Size = new System.Drawing.Size(91, 17);
            this.cbMIOTOff.TabIndex = 6;
            this.cbMIOTOff.Text = "Disable MIOT";
            this.cbMIOTOff.UseVisualStyleBackColor = true;
            // 
            // tbFARN
            // 
            this.tbFARN.Culture = new System.Globalization.CultureInfo("");
            this.tbFARN.Location = new System.Drawing.Point(300, 55);
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
            this.label2.Location = new System.Drawing.Point(250, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "value";
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
            this.cbFARNLevel.Location = new System.Drawing.Point(119, 55);
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
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Set measure level: ";
            // 
            // chDetectFakeFinger
            // 
            this.chDetectFakeFinger.AutoSize = true;
            this.chDetectFakeFinger.Location = new System.Drawing.Point(16, 28);
            this.chDetectFakeFinger.Name = "chDetectFakeFinger";
            this.chDetectFakeFinger.Size = new System.Drawing.Size(111, 17);
            this.chDetectFakeFinger.TabIndex = 0;
            this.chDetectFakeFinger.Text = "Detect fake finger";
            this.chDetectFakeFinger.UseVisualStyleBackColor = true;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(18, 106);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 3;
            this.btnVerify.Text = "Verificar";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(212, 93);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(75, 23);
            this.btnIdentify.TabIndex = 4;
            this.btnIdentify.Text = "Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(254, 49);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Detener";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(18, 77);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Salida";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(-3, 140);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(266, 20);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // split
            // 
            this.split.Location = new System.Drawing.Point(131, 93);
            this.split.Name = "split";
            this.split.Size = new System.Drawing.Size(75, 23);
            this.split.TabIndex = 10;
            this.split.Text = "split";
            this.split.UseVisualStyleBackColor = true;
            this.split.Click += new System.EventHandler(this.split_Click);
            // 
            // Detener
            // 
            this.Detener.Location = new System.Drawing.Point(18, 48);
            this.Detener.Name = "Detener";
            this.Detener.Size = new System.Drawing.Size(75, 23);
            this.Detener.TabIndex = 9;
            this.Detener.Text = "Detener";
            this.Detener.UseVisualStyleBackColor = true;
            this.Detener.Click += new System.EventHandler(this.Detener_Click);
            // 
            // resultado2
            // 
            this.resultado2.Location = new System.Drawing.Point(326, 355);
            this.resultado2.Name = "resultado2";
            this.resultado2.Size = new System.Drawing.Size(265, 20);
            this.resultado2.TabIndex = 807;
            this.resultado2.Visible = false;
            this.resultado2.TextChanged += new System.EventHandler(this.resultado2_TextChanged);
            // 
            // resultado
            // 
            this.resultado.Location = new System.Drawing.Point(326, 329);
            this.resultado.Name = "resultado";
            this.resultado.Size = new System.Drawing.Size(265, 20);
            this.resultado.TabIndex = 806;
            this.resultado.Visible = false;
            // 
            // PictureFingerPrint
            // 
            this.PictureFingerPrint.BackgroundImage = global::bio.Properties.Resources.ssss;
            this.PictureFingerPrint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureFingerPrint.Image = global::bio.Properties.Resources.ssss1;
            this.PictureFingerPrint.InitialImage = null;
            this.PictureFingerPrint.Location = new System.Drawing.Point(-8, -4);
            this.PictureFingerPrint.Name = "PictureFingerPrint";
            this.PictureFingerPrint.Size = new System.Drawing.Size(133, 120);
            this.PictureFingerPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureFingerPrint.TabIndex = 808;
            this.PictureFingerPrint.TabStop = false;
            this.PictureFingerPrint.WaitOnLoad = true;
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Controls.Add(this.Detener);
            this.groupBox3.Controls.Add(this.btnVerify);
            this.groupBox3.Location = new System.Drawing.Point(411, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 196);
            this.groupBox3.TabIndex = 809;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operations";
            this.groupBox3.Visible = false;
            // 
            // MainForm_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 600);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.split);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.PictureFingerPrint);
            this.Controls.Add(this.resultado2);
            this.Controls.Add(this.resultado);
            this.Controls.Add(this.btnIdentify);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm_new";
            this.Text = "C# example for Futronic SDK v.4.2";
            this.Load += new System.EventHandler(this.MainForm_new_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureFingerPrint)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label m_lblIdentificationsLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox m_cmbVersion;
        private System.Windows.Forms.CheckBox chFastMode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox txtMessage;
        public System.Windows.Forms.TextBox resultado2;
        public System.Windows.Forms.TextBox resultado;
        public System.Windows.Forms.PictureBox PictureFingerPrint;
        public System.Windows.Forms.Button btnEnroll;
        public System.Windows.Forms.Button btnIdentify;
        public System.Windows.Forms.Button split;
        public System.Windows.Forms.Button Detener;
        public System.Windows.Forms.Button btnStop;
    }
}

