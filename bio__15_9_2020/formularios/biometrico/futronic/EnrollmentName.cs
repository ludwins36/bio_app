using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bio
{
    public partial class EnrollmentName : Form
    {
        public EnrollmentName()
        {
            InitializeComponent();
        }
        call llamar = new call();
        public String UserName
        {
            get
            {
                return txtUserName.Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void EnrollmentName_Load(object sender, EventArgs e)
        {
            txtUserName.Text = llamar.Nombre_de_usuario;
            btnOK.PerformClick();

        }
    }
}