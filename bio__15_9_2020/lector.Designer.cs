namespace bio
{
    partial class lector
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
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_origen = new System.Windows.Forms.ComboBox();
            this.id_lectura = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(17, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 848;
            this.label6.Text = "Opccion de registro";
            // 
            // cmb_origen
            // 
            this.cmb_origen.FormattingEnabled = true;
            this.cmb_origen.Items.AddRange(new object[] {
            "Manual ",
            "Automatico"});
            this.cmb_origen.Location = new System.Drawing.Point(20, 52);
            this.cmb_origen.Name = "cmb_origen";
            this.cmb_origen.Size = new System.Drawing.Size(163, 21);
            this.cmb_origen.TabIndex = 847;
            this.cmb_origen.SelectedIndexChanged += new System.EventHandler(this.cmb_origen_SelectedIndexChanged);
            // 
            // id_lectura
            // 
            this.id_lectura.AutoSize = true;
            this.id_lectura.Location = new System.Drawing.Point(243, 23);
            this.id_lectura.Name = "id_lectura";
            this.id_lectura.Size = new System.Drawing.Size(53, 13);
            this.id_lectura.TabIndex = 849;
            this.id_lectura.Text = "id_lectura";
            // 
            // lector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 397);
            this.Controls.Add(this.id_lectura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_origen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "lector";
            this.Text = "lector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_origen;
        private System.Windows.Forms.Label id_lectura;
    }
}