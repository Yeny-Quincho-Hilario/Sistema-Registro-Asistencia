using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RegistroAsistencia
{
    public partial class Consulta : Form
    {
        DataView dv = new DataView();
        public Consulta()
        {
            InitializeComponent();
        }
        private void listarConsulta()
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("USP_CONSULTA", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@CursoID", 1); // Reemplazar con el ID del curso
                //da.SelectCommand.Parameters.AddWithValue("@ProgramaEstudioID", 1); // Reemplazar con el ID de la carrera
                //da.SelectCommand.Parameters.AddWithValue("@fecha",dtpFecha.Value ); // Reemplazar con la fecha deseada
                DataTable dt = new DataTable();
                da.Fill(dt);
                dv = dt.DefaultView;
                dgvConsulta.DataSource = dv;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            

        }
        private void Consulta_Load(object sender, EventArgs e)
        {
            listarConsulta();
        }

        private void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = rbtFecha.Checked;
            txtEstudiante.Enabled = rbtEstudiante.Checked;
            txtEstado.Enabled = rbtEstado.Checked;
            txtCurso.Enabled = rbtCurso.Checked;
            //dtpFecha.FindForm();
            //dtpFecha.Checked = false;
           // dtpFecha.Value = DateTime.MinValue;
            txtEstudiante.Clear();
            txtEstado.Clear();
            txtCurso.Clear();
            dtpFecha.Focus();
            txtEstudiante.Focus();
            txtEstado.Focus();
            txtCurso.Focus();

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFecha.Value != DateTime.MinValue)
            {
                // Formatear la fecha del DateTimePicker en el formato correcto para la comparación en el filtro
                string fechaFiltro = dtpFecha.Value.ToString("dd-MM-yyyy");

                // Aplicar el filtro con la fecha formateada
                dv.RowFilter = "Fecha= '" + fechaFiltro + "'";
            }
            
                else
                    dv.RowFilter = "";

        }

        private void txtEstudiante_TextChanged(object sender, EventArgs e)
        {
            if (txtEstudiante.Text.Trim().Length > 0)
                dv.RowFilter = $"Nombres Like '%{txtEstudiante.Text}%' ";
            else
                dv.RowFilter = "";
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            if (txtEstado.Text.Trim().Length > 0)
                dv.RowFilter = $"Estado Like '%{txtEstado.Text}%' ";
            else
                dv.RowFilter = "";
        }

        private void txtCurso_TextChanged(object sender, EventArgs e)
        {
            if (txtCurso.Text.Trim().Length > 0)
                dv.RowFilter = $"Curso Like '%{txtCurso.Text}%' ";
            else
                dv.RowFilter = "";
        }

        private void rbtCurso_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = rbtFecha.Checked;
            txtEstudiante.Enabled = rbtEstudiante.Checked;
            txtEstado.Enabled = rbtEstado.Checked;
            txtCurso.Enabled = rbtCurso.Checked;
            //dtpFecha.FindForm();
            //dtpFecha.Checked = false;
            // dtpFecha.Value = DateTime.MinValue;
            txtEstudiante.Clear();
            txtEstado.Clear();
            txtCurso.Clear();
            dtpFecha.Focus();
            txtEstudiante.Focus();
            txtEstado.Focus();
            txtCurso.Focus();
        }

        private void rbtEstudiante_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = rbtFecha.Checked;
            txtEstudiante.Enabled = rbtEstudiante.Checked;
            txtEstado.Enabled = rbtEstado.Checked;
            txtCurso.Enabled = rbtCurso.Checked;
            //dtpFecha.FindForm();
            //dtpFecha.Checked = false;
            // dtpFecha.Value = DateTime.MinValue;
            txtEstudiante.Clear();
            txtEstado.Clear();
            txtCurso.Clear();
            dtpFecha.Focus();
            txtEstudiante.Focus();
            txtEstado.Focus();
            txtCurso.Focus();
        }
    }
}