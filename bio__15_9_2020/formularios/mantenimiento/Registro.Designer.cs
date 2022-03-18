namespace bio
{
    partial class Registro
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.huella = new System.Windows.Forms.TextBox();
            this.lista = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_registrart_huella = new Bunifu.Framework.UI.BunifuImageButton();
            this.btn_agregar = new Bunifu.Framework.UI.BunifuImageButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_registrart_huella)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agregar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Huella";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(0, 1);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(166, 20);
            this.nombre.TabIndex = 2;
            // 
            // huella
            // 
            this.huella.Location = new System.Drawing.Point(0, 43);
            this.huella.Name = "huella";
            this.huella.Size = new System.Drawing.Size(166, 20);
            this.huella.TabIndex = 3;
            // 
            // lista
            // 
            this.lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lista.Location = new System.Drawing.Point(0, 135);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(368, 127);
            this.lista.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 767;
            this.label3.Text = "Agregar";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 25);
            this.button1.TabIndex = 769;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(314, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 768;
            this.pictureBox1.TabStop = false;
            // 
            // btn_registrart_huella
            // 
            this.btn_registrart_huella.BackColor = System.Drawing.Color.Transparent;
            this.btn_registrart_huella.Image = global::bio.Properties.Resources.Fingerprint_48px;
            this.btn_registrart_huella.ImageActive = null;
            this.btn_registrart_huella.Location = new System.Drawing.Point(215, 41);
            this.btn_registrart_huella.Name = "btn_registrart_huella";
            this.btn_registrart_huella.Size = new System.Drawing.Size(31, 27);
            this.btn_registrart_huella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_registrart_huella.TabIndex = 766;
            this.btn_registrart_huella.TabStop = false;
            this.btn_registrart_huella.Zoom = 10;
            this.btn_registrart_huella.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.Transparent;
            this.btn_agregar.Enabled = false;
            this.btn_agregar.Image = global::bio.Properties.Resources.Add_File_48px;
            this.btn_agregar.ImageActive = null;
            this.btn_agregar.Location = new System.Drawing.Point(2, 102);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(31, 27);
            this.btn_agregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_agregar.TabIndex = 765;
            this.btn_agregar.TabStop = false;
            this.btn_agregar.Tag = "";
            this.btn_agregar.Zoom = 10;
            this.btn_agregar.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(369, 262);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_registrart_huella);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.lista);
            this.Controls.Add(this.huella);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Registro";
            this.Load += new System.EventHandler(this.Registro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_registrart_huella)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agregar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox huella;
        private System.Windows.Forms.DataGridView lista;
        private Bunifu.Framework.UI.BunifuImageButton btn_agregar;
        private Bunifu.Framework.UI.BunifuImageButton btn_registrart_huella;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}