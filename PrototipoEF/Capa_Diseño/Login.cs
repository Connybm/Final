using Capa_Datos;
using Capa_Logica;
using Capa_Diseño;
using CapaLogica_ERP;
using System;
using System.Data.Odbc;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ERP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            circularProgressBar1.Visible = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Txt_user_Enter(object sender, EventArgs e)
        {
            if (Txt_user.Text == "USUARIO")
            {
                Txt_user.Text = "";
                Txt_user.ForeColor = Color.LightGray;
            }
        }

        private void Txt_user_Leave(object sender, EventArgs e)
        {
            if (Txt_user.Text == "")
            {
                Txt_user.Text = "USUARIO";
                Txt_user.ForeColor = Color.DimGray;
            }

        }

        private void Txt_pass_Enter(object sender, EventArgs e)
        {

          
            if (Txt_pass.Text == "CONTRASEÑA")
            {
                Txt_pass.Text = "";
                Txt_pass.ForeColor = Color.LightGray;
                Txt_pass.UseSystemPasswordChar = true;
            }
        }

        private void Txt_pass_Leave(object sender, EventArgs e)
        {
            if (Txt_pass.Text == "")
            {
                Txt_pass.Text = "CONTRASEÑA";
                Txt_pass.ForeColor = Color.DimGray;
                Txt_pass.UseSystemPasswordChar = false;
            }
        }

        private void Btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_minimzar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
          
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();

            if (Txt_user.Text != "USUARIO")
                {
                    if (Txt_pass.Text != "CONTRASEÑA")
                    {
                    Logica logic = new Logica();
                   // OdbcDataReader mostrarResultado = logic.LoginUser(Txt_user.Text,Txt_pass.Text);
                    if (logic.LoginUser(Txt_user.Text, Txt_pass.Text) == true)
                    {
                        string seleccionarUsuario = string.Format("SELECT usuario.*,CONCAT(guardar, modificar,eliminar,consultar) AS nivel FROM usuario INNER JOIN tipo_usuario  ON usuario.pktipousuario=tipo_usuario.pktipousuario WHERE nombreusuario='" + Txt_user.Text + "' AND passusuario='" + Txt_pass.Text + "';");
                        OdbcCommand comm = new OdbcCommand(seleccionarUsuario, cn.conexionbd());
                        OdbcDataReader mostrarResultado = comm.ExecuteReader();

                        while (mostrarResultado.Read())
                        {
                            Cache.Iduser = mostrarResultado.GetInt32(0);
                            Cache.nombre = mostrarResultado.GetString(2);
                            Cache.tipousuario = mostrarResultado.GetInt32(1);
                            Cache.correo = mostrarResultado.GetString(5);
                            Cache.foto = mostrarResultado.GetString(6);
                            Cache.nivel = mostrarResultado.GetString(7);
                        }
                        //Inicializamos estas propiedades de la barra de progreso, mediante codigo.(Opcional)
                        circularProgressBar1.Visible = true;
                        circularProgressBar1.Value = 0;
                        circularProgressBar1.Minimum = 0;
                        circularProgressBar1.Maximum = 100;
                        //Iniciamos el temporizador 1.
                        timer1.Start();
                    }
                    else
                    {
                        msgerror("Incorrecto Usuario o contraseña.");
                        Txt_pass.Text = "CONTRASEÑA";
                        Txt_pass.UseSystemPasswordChar = false;
                        Txt_user.Focus();
                    }
                }
                    else msgerror("Porfavor ingrese contraseña");
                }
                else msgerror("Porfavor ingrese usuario");
           // MessageBox.Show(Cache.nivel);
        }

        public void msgerror(String msg)
        {
            lbl_error.Text = "     " + msg;
            lbl_error.Visible = true;
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            Txt_pass.Text = "CONTRASEÑA";
            Txt_pass.UseSystemPasswordChar = false;
            Txt_user.Text = "USUARIO";
            lbl_error.Visible = false;
            this.Show();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
          
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Hide();
                Menu_Principal mainMenu = new Menu_Principal();
                mainMenu.Show();
                mainMenu.FormClosed += Logout;               
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var RecuperacionContraseña = new RecuperacionContraseña();
            RecuperacionContraseña.ShowDialog();
        }
    }
}
