using Capa_Diseño.Mantenimientos;
using Capa_Diseño.Procesos;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Diseño
{
    public partial class Menu_Principal : Form
    {
        private int childFormNumber = 0;

        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
                
        bool ventanabodega = false;
        MBodega bodega = new MBodega();
        private void bodegasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MBodega);
            if (ventanabodega == false || frmC == null)
            {
                if (frmC == null)
                {
                    bodega = new MBodega();
                }

                bodega.MdiParent = this;
                bodega.Show();
                Application.DoEvents();
                ventanabodega = true;
            }
            else
            {
                bodega.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanalinea = false;
        MLineas linea = new MLineas();
        private void lineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MLineas);
            if (ventanalinea == false || frmC == null)
            {
                if (frmC == null)
                {
                    linea = new MLineas();
                }

                linea.MdiParent = this;
                linea.Show();
                Application.DoEvents();
                ventanalinea = true;
            }
            else
            {
                linea.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanamarca = false;
        MMarcas marca = new MMarcas();
        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MMarcas);
            if (ventanamarca == false || frmC == null)
            {
                if (frmC == null)
                {
                    marca = new MMarcas();
                }

                marca.MdiParent = this;
                marca.Show();
                Application.DoEvents();
                ventanamarca = true;
            }
            else
            {
                marca.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaproveedor = false;
        MProveedores proveedor = new MProveedores();
        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MProveedores);
            if (ventanaproveedor == false || frmC == null)
            {
                if (frmC == null)
                {
                    proveedor = new MProveedores();
                }

                proveedor.MdiParent = this;
                proveedor.Show();
                Application.DoEvents();
                ventanaproveedor = true;
            }
            else
            {
                proveedor.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanavendedor = false;
        MVendedores vendedor = new MVendedores();
        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MVendedores);
            if (ventanavendedor == false || frmC == null)
            {
                if (frmC == null)
                {
                    vendedor = new MVendedores();
                }

                vendedor.MdiParent = this;
                vendedor.Show();
                Application.DoEvents();
                ventanavendedor = true;
            }
            else
            {
                vendedor.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanacliente = false;
        MCliente cliente = new MCliente();
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MCliente);
            if (ventanacliente == false || frmC == null)
            {
                if (frmC == null)
                {
                    cliente = new MCliente();
                }

                cliente.MdiParent = this;
                cliente.Show();
                Application.DoEvents();
                ventanacliente = true;
            }
            else
            {
                cliente.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaexis = false;
        MExistencias exis = new MExistencias();
        private void existenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MExistencias);
            if (ventanaexis == false || frmC == null)
            {
                if (frmC == null)
                {
                    exis = new MExistencias();
                }

                exis.MdiParent = this;
                exis.Show();
                Application.DoEvents();
                ventanaexis = true;
            }
            else
            {
                exis.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanapro = false;
        MProductos pro = new MProductos();
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MProductos);
            if (ventanapro == false || frmC == null)
            {
                if (frmC == null)
                {
                    pro = new MProductos();
                }

                pro.MdiParent = this;
                pro.Show();
                Application.DoEvents();
                ventanapro = true;
            }
            else
            {
                pro.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaventa = false;
        PVenta venta = new PVenta();
        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is PVenta);
            if (ventanaventa == false || frmC == null)
            {
                if (frmC == null)
                {
                    venta = new PVenta();
                }

                venta.MdiParent = this;
                venta.Show();
                Application.DoEvents();
                ventanaventa = true;
            }
            else
            {
                venta.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanacompra = false;
        PCompra compra = new PCompra();
        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is PCompra);
            if (ventanacompra == false || frmC == null)
            {
                if (frmC == null)
                {
                    compra = new PCompra();
                }

                compra.MdiParent = this;
                compra.Show();
                Application.DoEvents();
                ventanacompra = true;
            }
            else
            {
                compra.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}

