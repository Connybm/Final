using Capa_Diseño.Consulta;
using Capa_Logica;
using System;
using System.Windows.Forms;

namespace Capa_Diseño.Mantenimientos
{
    public partial class MProductos : Form
    {
        Logica logic = new Logica();
        string scampo;
        public MProductos()
        {
            InitializeComponent();
            scampo = logic.siguiente("productos", "codigo_producto");
            Txt_Codigo.Text = scampo;
            bloquearTXT();
        }

        void bloquearTXT()
        {
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_clinea, txt_cmarca, txt_exis };
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
            scampo = logic.siguiente("productos", "codigo_producto");
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

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_clinea, txt_cmarca, txt_exis };
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
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_clinea, txt_cmarca, txt_exis };
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
                string[] valores = { "productos", Txt_Codigo.Text, Txt_nombre.Text, txt_clinea.Text, txt_cmarca.Text, txt_exis.Text, Cbo_estado.Text };
                string[] campos = { "codigo_producto", "nombre_producto", "codigo_linea", "codigo_marca", "existencia_producto", "estatus_producto" };
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
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_clinea, txt_cmarca, txt_exis };
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
                string[] valores = { "productos", Txt_Codigo.Text, Txt_nombre.Text, txt_clinea.Text, txt_cmarca.Text, txt_exis.Text, Cbo_estado.Text };
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
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_clinea, txt_cmarca, txt_exis };
            string[] valores = { "productos", Txt_Codigo.Text, "codigo_producto" };
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
            CProductos ruta = new CProductos();
            ruta.ShowDialog();

            if (ruta.DialogResult == DialogResult.OK)
            {
                Txt_Codigo.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();
                Txt_nombre.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
                txt_clinea.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[2].Value.ToString();
                txt_cmarca.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[3].Value.ToString();
                txt_exis.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[4].Value.ToString();
                Cbo_estado.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[5].Value.ToString();
            }
        }

        private void btn_bl_Click(object sender, EventArgs e)
        {
            CLineas concep = new CLineas();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {
                txt_clinea.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
            }
        }

        private void Btn_bm_Click(object sender, EventArgs e)
        {
            CMarcas concep = new CMarcas();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {
                txt_cmarca.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
            }
        }
    }
}
