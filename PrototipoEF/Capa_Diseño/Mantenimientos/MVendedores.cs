using Capa_Logica;
using Capa_Diseño.Consulta;
using System;
using System.Windows.Forms;

namespace Capa_Diseño.Mantenimientos
{
    public partial class MVendedores : Form
    {
        Logica logic = new Logica();
        string scampo;
        public MVendedores()
        {
            InitializeComponent();
            scampo = logic.siguiente("vendedores", "codigo_vendedor");
            Txt_Codigo.Text = scampo;
            bloquearTXT();
        }

        void bloquearTXT()
        {
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_Direccion, txt_tel, txt_nit };
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Enabled = false;
            }
            ComboBox[] comboBox = { Cbo_estado };
            for (int i = 0; i < comboBox.Length; i++)
            {
                comboBox[i].Enabled = false;
            }
        }

        private int validarTXT(TextBox[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (string.IsNullOrEmpty(list[i].Text))
                {
                    MessageBox.Show("Debe completar la informacion en el campo " + list[i].Name);
                    return 0;
                }
            }
            return 1;
        }

        void limpiarTXT(TextBox[] txtBox, ComboBox[] comboBo)
        {
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Text = "";
            }
            scampo = logic.siguiente("vendedores", "codigo_vendedor");
            Txt_Codigo.Text = scampo;
            if (Cbo_estado.Text != "")
            {
                Cbo_estado.Text = "Activo";
            }
            else
            {
                Cbo_estado.Text = "Inactico";
            }
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_Direccion, txt_tel, txt_nit };
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Enabled = true;
            }
            ComboBox[] comboBox = { Cbo_estado };
            for (int i = 0; i < comboBox.Length; i++)
            {
                comboBox[i].Enabled = true;
            }
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            ComboBox[] comboBox = { Cbo_estado };
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_Direccion, txt_tel, txt_nit };
            if (validarTXT(txtBox) == 0)
                return;
            else
            {
                if (Cbo_estado.Text == "Activo")
                {
                    Cbo_estado.Text = "1";
                }
                else
                {
                    Cbo_estado.Text = "0";
                }
                string[] valores = { "vendedores", Txt_Codigo.Text, Txt_nombre.Text, txt_Direccion.Text, txt_tel.Text, txt_nit.Text, Cbo_estado.Text };
                string[] campos = { "codigo_vendedor", "nombre_vendedor", "direccion_vendedor", "telefono_vendedor", "nit_vendedor", "estatus_vendedor" };
                if (logic.Modificar(valores, campos) == null)
                    MessageBox.Show("Ocurrio un error al modificar los datos.");
                else
                {
                    MessageBox.Show("Datos modificados exitosamente.");
                    limpiarTXT(txtBox, comboBox);
                    bloquearTXT();
                }
            }
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            ComboBox[] comboBox = { Cbo_estado };
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_Direccion, txt_tel, txt_nit };
            if (validarTXT(txtBox) == 0)
                return;
            else
            {
                if (Cbo_estado.Text == "Activo")
                {
                    Cbo_estado.Text = "1";
                }
                else
                {
                    Cbo_estado.Text = "0";
                }
                string[] valores = { "vendedores", Txt_Codigo.Text, Txt_nombre.Text, txt_Direccion.Text, txt_tel.Text, txt_nit.Text, Cbo_estado.Text };
                if (logic.Insertar(valores) == null)
                    MessageBox.Show("Ocurrio un error al guardar los datos.");
                else
                {
                    MessageBox.Show("Datos guardados exitosamente.");
                    limpiarTXT(txtBox, comboBox);
                    bloquearTXT();
                }
            }
        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            ComboBox[] comboBox = { Cbo_estado };
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_Direccion, txt_tel, txt_nit };
            string[] valores = { "vendedores", Txt_Codigo.Text, "codigo_vendedor" };
            if (logic.Eliminar(valores) == null)
                MessageBox.Show("Ocurrio un error al borrar los datos.");
            else
            {
                MessageBox.Show("Datos eliminados exitosamente.");
                limpiarTXT(txtBox, comboBox);
                bloquearTXT();
            }
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            CVendedores ruta = new CVendedores();
            ruta.ShowDialog();

            if (ruta.DialogResult == DialogResult.OK)
            {
                Txt_Codigo.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();
                Txt_nombre.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
                txt_Direccion.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[2].Value.ToString();
                txt_tel.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[3].Value.ToString();
                txt_nit.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[4].Value.ToString();
                Cbo_estado.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[5].Value.ToString();
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
