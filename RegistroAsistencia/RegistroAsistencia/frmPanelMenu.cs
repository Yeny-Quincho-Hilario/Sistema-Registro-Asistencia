using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroAsistencia
{
    public partial class frmPanelMenu : Form
    {
        public frmPanelMenu()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void programaDeEstudisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmRegistroDoc_Click(object sender, EventArgs e)
        {
            Form formulario = new frmAgregarDocentes();
            this.Hide();
            formulario.ShowDialog();
            this.Show();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void matriculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMatriDoc formulario = new frmMatriDoc();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }

        private void matriculaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMatriEstud formulario = new frmMatriEstud();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }

        private void registroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAgregarEstud formulario = new frmAgregarEstud();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }

        

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarPE formulario = new frmAgregarPE();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }

       

        private void tsmRegistroCursos_Click(object sender, EventArgs e)
        {
            frmAgregarCurso formulario = new frmAgregarCurso();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }

        private void tsmAsistencia_Click(object sender, EventArgs e)
        {
            frmAsistencia formulario = new frmAsistencia();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }

        private void frmPanelMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmPanelMenu_Load(object sender, EventArgs e)
        {

        }

        private void frmPanelMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de cerrar la aplicación?", "Sistema de Registro de Asistencia",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Consulta formulario = new Consulta();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }

        private void consultaPorEstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaAsistencia formulario = new ConsultaAsistencia();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }

        private void consultaGenetalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta formulario = new Consulta();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }
    }
}
