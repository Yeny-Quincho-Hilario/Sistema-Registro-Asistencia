using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RegistroAsistencia
{
    public partial class frmMatriEstud : Form
    {
        public frmMatriEstud()
        {
            InitializeComponent();
        }

        private void clsBotonCirculo1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void listarMatriculaEstudiantes()
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_Listar_Matricula_Estudiantes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BindingSource bs = new BindingSource(); //bs es fuente vinculante
                bs.DataSource = dr;
                dgvListarEst.DataSource = bs;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //OJO

            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {

                SqlDataAdapter da = new SqlDataAdapter("USP_ListarEstudiantes_X_ProgEst", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ProgramaEstudioID", cbxPE.SelectedValue);
                DataTable dt = new DataTable();

                try
                {
                    con.Open();
                    da.Fill(dt);

                    DataRow fila = dt.NewRow();
                    fila["NombreCompleto"] = "Seleccione un Estudiante";
                    dt.Rows.InsertAt(fila, 0);

                    // Asignar los datos al ComboBox de Docentes
                    cbxEstudiante.DataSource = dt;
                    cbxEstudiante.DisplayMember = "NombreCompleto";
                    cbxEstudiante.ValueMember = "EstudianteID";


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos de los estudiantes: " + ex.Message);
                }
                // con.Close();

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMatriEstud_Load(object sender, EventArgs e)
        {
            listarMatriculaEstudiantes();
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter("USP_PROGRAMA_ESTUDIO_Listar", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();

                try
                {
                    con.Open();
                    da.Fill(dt);

                    DataRow fila = dt.NewRow();
                    fila["Nombre"] = "Seleccione un Programa de Estudio";
                    dt.Rows.InsertAt(fila, 0);

                    // Asignar los datos al ComboBox de Programas de Estudio
                    cbxPE.DisplayMember = "Nombre";
                    cbxPE.ValueMember = "ProgramaEstudioID";
                    cbxPE.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar Programa de Estudios: " + ex.Message);
                }
                // con.Close();

            }
        }

        private void cbxPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {

                SqlDataAdapter daCursos = new SqlDataAdapter("USP_ListarCursos_X_ProgEst", con);
                daCursos.SelectCommand.CommandType = CommandType.StoredProcedure;
                daCursos.SelectCommand.Parameters.AddWithValue("@ProgramaEstudioID", cbxPE.SelectedValue);
                DataTable dtCursos = new DataTable();

                try
                {
                    con.Open();
                    daCursos.Fill(dtCursos);

                    DataRow fila = dtCursos.NewRow();
                    fila["Nombre"] = "Seleccione un Curso";
                    dtCursos.Rows.InsertAt(fila, 0);

                    cbxCurso.DataSource = dtCursos;
                    cbxCurso.DisplayMember = "Nombre";
                    cbxCurso.ValueMember = "CursoID";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar Cursos: " + ex.Message);
                }

            }
        }

        private void btnMatricular_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("USP_MATRICULA_ESTUDIANTE_Guardar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProgramaEstudioID", cbxPE.SelectedValue);
                    cmd.Parameters.AddWithValue("@CursoID", cbxCurso.SelectedValue);
                    cmd.Parameters.AddWithValue("@EstudianteID", cbxEstudiante.SelectedValue);
                    cmd.ExecuteNonQuery();
                    listarMatriculaEstudiantes();
                    MessageBox.Show("la matricula fue guardado correctamente en la base de datos.");
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar : " + ex.Message);
                }
                finally
                {
                    // Cerrar la conexión a la base de datos
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cbxPE.Focus();
        }
    }
}
