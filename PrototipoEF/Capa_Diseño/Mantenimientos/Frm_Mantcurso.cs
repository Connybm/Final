using Capa_Diseño.Consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Diseño.Mantenimientos
{
    public partial class Frm_Mantcurso : Form
    {
        public Frm_Mantcurso()
        {
            InitializeComponent();
        }

        private void Btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            consulta_curso concep = new consulta_curso();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {
                Txt_Codigo.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();
                Txt_nombre.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
                Cbo_estado.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                     Cells[5].Value.ToString();
            }
        }
    }
}
