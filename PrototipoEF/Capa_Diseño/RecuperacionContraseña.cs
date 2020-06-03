using Capa_Datos;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class RecuperacionContraseña : Form
    {
        public RecuperacionContraseña()
        {
            InitializeComponent();
        }

        private void Btn_cerrar_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void Btn_minimzar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var user = new Sentencias();
            //var result = user.RecoverPassword(Txt_pass.Text);
           // Lbl_resultado.Text = result;
        }

    }
}
