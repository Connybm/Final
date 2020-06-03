using Capa_Diseño.Consulta;
using Capa_Logica;
using System;
using System.Windows.Forms;

namespace Capa_Diseño.Mantenimientos
{
    public partial class MExistencias : Form
    {
        Logica logic = new Logica();
        string scampo;
        public MExistencias()
        {
            InitializeComponent();
            scampo = logic.siguiente("existencias", "");
            Txt_Codigo.Text = scampo;
            bloquearTXT();
        }

        void bloquearTXT()
        {
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_ven };
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Enabled = false;
            }
            ComboBox[] comboBox = { };
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
            scampo = logic.siguiente("existencias", "");
            Txt_Codigo.Text = scampo;            
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_ven };
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Enabled = true;
            }
            ComboBox[] comboBox = {  };
            for (int i = 0; i < comboBox.Length; i++)
            {
                comboBox[i].Enabled = true;
            }
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            ComboBox[] comboBox = {  };
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_ven };
            if (validarTXT(txtBox) == 0)
                return;
            else
            {               
                string[] valores = { "existencias", Txt_Codigo.Text, Txt_nombre.Text, txt_ven.Text };
                string[] campos = { "codigo_cliente", "nombre_cliente", "direccion_cliente", "telefono_cliente", "nit_cliente", "codigo_vendedor", "estatus_proveedor" };
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
            ComboBox[] comboBox = { };
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_ven };
            if (validarTXT(txtBox) == 0)
                return;
            else
            {               
                string[] valores = { "existencias", Txt_Codigo.Text, Txt_nombre.Text, txt_ven.Text };
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
            ComboBox[] comboBox = {  };
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, txt_ven };
            string[] valores = { "existencias", Txt_Codigo.Text, "" };
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
            CClientes ruta = new CClientes();
            ruta.ShowDialog();

            if (ruta.DialogResult == DialogResult.OK)
            {
                Txt_Codigo.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();
                Txt_nombre.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();                
                txt_ven.Text = ruta.Dgv_consulta.Rows[ruta.Dgv_consulta.CurrentRow.Index].
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

        private void Btn_BV_Click(object sender, EventArgs e)
        {
            CBodega concep = new CBodega();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {
                txt_ven.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CProductos concep = new CProductos();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {
                txt_ven.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
            }
        }
    }
}
