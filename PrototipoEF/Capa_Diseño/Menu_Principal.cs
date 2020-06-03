using Capa_Diseño.Mantenimientos;
using Capa_Diseño.Procesos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        bool ventanaula = false;
        Frm_Mantaulas aula = new Frm_Mantaulas();

        private void AulasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantaulas);
            if (ventanaula == false || frmC == null)
            {
                if (frmC == null)
                {
                    aula = new Frm_Mantaulas();
                }

                aula.MdiParent = this;
                aula.Show();
                Application.DoEvents();
                ventanaula = true;
            }
            else
            {
                aula.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
        bool ventanalumno = false;
        Frm_Mantalumno alumno = new Frm_Mantalumno();

        private void AlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantalumno);
            if (ventanaula == false || frmC == null)
            {
                if (frmC == null)
                {
                    alumno = new Frm_Mantalumno();
                }

                alumno.MdiParent = this;
                alumno.Show();
                Application.DoEvents();
                ventanaula = true;
            }
            else
            {
                alumno.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanacurso= false;
        Frm_Mantcurso curso = new Frm_Mantcurso();

        private void CursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantcurso);
            if (ventanaula == false || frmC == null)
            {
                if (frmC == null)
                {
                    curso = new Frm_Mantcurso();
                }

                curso.MdiParent = this;
                curso.Show();
                Application.DoEvents();
                ventanaula = true;
            }
            else
            {
                curso.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }

        }
        bool ventanafacultad = false;
        Frm_Mantfacultades facultad = new Frm_Mantfacultades();

        private void FacultadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantfacultades);
            if (ventanaula == false || frmC == null)
            {
                if (frmC == null)
                {
                    facultad = new Frm_Mantfacultades();
                }

                facultad.MdiParent = this;
                facultad.Show();
                Application.DoEvents();
                ventanaula = true;
            }
            else
            {
                facultad.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }

        }

        bool ventanajornada = false;
        Frm_Mantjornadas jornadas = new Frm_Mantjornadas();

        private void JornadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantjornadas);
            if (ventanaula == false || frmC == null)
            {
                if (frmC == null)
                {
                    jornadas = new Frm_Mantjornadas();
                }

                jornadas.MdiParent = this;
                jornadas.Show();
                Application.DoEvents();
                ventanaula = true;
            }
            else
            {
                jornadas.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }

        }

        bool ventanamaestro = false;
        Frm_Mantmaestro maestro = new Frm_Mantmaestro();
        private void MaestroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantmaestro);
            if (ventanaula == false || frmC == null)
            {
                if (frmC == null)
                {
                    maestro = new Frm_Mantmaestro();
                }

                maestro.MdiParent = this;
                maestro.Show();
                Application.DoEvents();
                ventanaula = true;
            }
            else
            {
                maestro.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }


        bool ventanasecciones = false;
        Frm_Mantsecciones secciones = new Frm_Mantsecciones();
        private void SeccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantsecciones);
            if (ventanaula == false || frmC == null)
            {
                if (frmC == null)
                {
                    secciones = new Frm_Mantsecciones();
                }

                secciones.MdiParent = this;
                secciones.Show();
                Application.DoEvents();
                ventanaula = true;
            }
            else
            {
                secciones.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }


        bool ventanasedes = false;
        Frm_Mantsedes sedes = new Frm_Mantsedes();
        private void SedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantsedes);
            if (ventanaula == false || frmC == null)
            {
                if (frmC == null)
                {
                    sedes = new Frm_Mantsedes();
                }

                sedes.MdiParent = this;
                sedes.Show();
                Application.DoEvents();
                ventanaula = true;
            }
            else
            {
                sedes.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanasignacionemp= false;
        Frm_asignacioncursoalumno asignacionemp = new Frm_asignacioncursoalumno();
        private void AsignacionMaestroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_asignacioncursoalumno);
            if (ventanaula == false || frmC == null)
            {
                if (frmC == null)
                {
                    asignacionemp = new Frm_asignacioncursoalumno();
                }

                asignacionemp.MdiParent = this;
                asignacionemp.Show();
                Application.DoEvents();
                ventanaula = true;
            }
            else
            {
                asignacionemp.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
    }

