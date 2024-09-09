using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RegistroAsistencia
{
    public partial class frmMatriDoc : Form
    {
        public frmMatriDoc()
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
        private void listarMatriculaDocentes()
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Listar_Matricula_Docentes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BindingSource bs = new BindingSource(); //bs es fuente vinculante
                bs.DataSource = dr;
                dgvMatriDoc.DataSource = bs;
            }

        }
        //private bool Validar()
        //{
        //    bool exito = true;
        //    string mensaje = "";
        //    if (cbxProgEst.SelectedValue == null)
        //    {
        //        exito = false;
        //        mensaje = "Tiene que seleccionar un Porgrama de estudio";
        //        cbxProgEst.Focus();
        //    }
        //    else if (cbxCurso.SelectedValue == null)
        //    {
        //        exito = false;
        //        mensaje = "Tiene que seleccionar un Curso";
        //        cbxCurso.Focus();
        //    }
        //    if (cbxDocente.SelectedValue == null)
        //    {
        //        exito = false;
        //        mensaje = "Tiene que seleccionar un docente";
        //        cbxDocente.Focus();
        //    }
        //    if (!exito)
        //        MessageBox.Show(mensaje, "Matrícula");

        //    return exito;
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {

                SqlDataAdapter da = new SqlDataAdapter("USP_ListarDocentes_X_ProgEst", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ProgramaEstudioID", cbxProgEst.SelectedValue);
                DataTable dt = new DataTable();

                try
                {
                    con.Open();
                    da.Fill(dt);

                    DataRow fila = dt.NewRow();
                    fila["NombreCompleto"] = "Seleccione un Docente";
                    dt.Rows.InsertAt(fila, 0);

                    // Asignar los datos al ComboBox de Docentes
                    cbxDocente.DataSource = dt;
                    cbxDocente.DisplayMember = "NombreCompleto";
                    cbxDocente.ValueMember = "DocenteID";


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos de los docentes: " + ex.Message);
                }
                // con.Close();

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMatriDoc_Load(object sender, EventArgs e)
        {
            listarMatriculaDocentes();
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {

                SqlDataAdapter da = new SqlDataAdapter("USP_PROGRAMA_ESTUDIO_Listar", con);
                DataTable dt = new DataTable();

                try
                {
                    con.Open();
                    da.Fill(dt);

                    DataRow fila = dt.NewRow();
                    fila["Nombre"] = "Seleccione un Programa de Estudio";
                    dt.Rows.InsertAt(fila, 0);

                    // Asignar los datos al ComboBox de Programas de Estudio
                    cbxProgEst.DisplayMember = "Nombre";
                    cbxProgEst.ValueMember = "ProgramaEstudioID";
                    cbxProgEst.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar Programa de Estudios: " + ex.Message);
                }
                // con.Close();

            }
        }

        private void cbxProgEst_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {

                SqlDataAdapter daCursos = new SqlDataAdapter("USP_ListarCursos_X_ProgEst", con);
                daCursos.SelectCommand.CommandType = CommandType.StoredProcedure;
                daCursos.SelectCommand.Parameters.AddWithValue("@ProgramaEstudioID", cbxProgEst.SelectedValue);
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
                 
                    SqlCommand cmd = new SqlCommand("USP_MATRICULA_DOCENTE_Guardar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProgramaEstudioID", cbxProgEst.SelectedValue);
                    cmd.Parameters.AddWithValue("@CursoID", cbxCurso.SelectedValue);
                    cmd.Parameters.AddWithValue("@DocenteID", cbxDocente.SelectedValue);
                    cmd.ExecuteNonQuery();
                    listarMatriculaDocentes();
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
            //cbxProgEst.Items.Clear();
            //cbxCurso.Items.Clear();
            //cbxDocente.Items.Clear();
            cbxProgEst.Focus();
        }
    }
}
