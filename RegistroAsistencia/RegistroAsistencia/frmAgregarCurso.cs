using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RegistroAsistencia
{
    public partial class frmAgregarCurso : Form

    {
        string accion = "";
        public frmAgregarCurso()
        {
            InitializeComponent();
        }

        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //CREANDO PROCEDIMIENTOS 
        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtHI.Clear();
            txtHF.Clear();
            //txtpeID.Clear();
            //txtDocID.Clear();
            txtNombre.Focus();
        }

        private void nuevo()
        {
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
            txtNombre.ReadOnly = false;
            txtHI.ReadOnly = false;
            txtHF.ReadOnly = false;
            //txtpeID.ReadOnly = false;
            //txtDocID.ReadOnly = false;
        }
        private void cancelar()
        {
            btnGuardar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = true;
            txtNombre.ReadOnly = true;
            txtHI.ReadOnly = true;
            txtHF.ReadOnly = true;
            //txtpeID.ReadOnly = true;
            //txtDocID.ReadOnly = true;
        }
        // CREANDO FUNCION(METODO) TIPO BOOL
        private bool validar()
        {
            bool exito = true;
            string mensaje = "";

            if (txtNombre.Text.Trim().Length < 5)
            {
                exito = false;
                mensaje = "Complete el nombre del Curso";
            }
            else if (txtHI.Text.Trim().Length < 3)
            {
                exito = false;
                mensaje = "Complete el horario de Inicio";
            }

            else if (txtHF.Text.Trim().Length < 5)
            {
                exito = false;
                mensaje = "Complete el horario Final";
            }

            if (!exito)
                MessageBox.Show(mensaje, "Advertencia");

            return exito;
        }
        private void ListarCursos()
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_CURSO_Listar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BindingSource bs = new BindingSource(); //bs es fuente vinculante
                bs.DataSource = dr;
                dgvCurso.DataSource = bs;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length > 0)
            {
                accion = "M";
                listar_programaEstudio();
                nuevo();
                txtNombre.Focus();

            }
            else
                MessageBox.Show("Seleccione los datos de Curso que quieres modificar", "Curso");
        }
        private void listar_programaEstudio()
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {

                SqlCommand cmd = new SqlCommand("USP_PROGRAMA_ESTUDIO_Listar", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    con.Open();
                    da.Fill(dt);

                    DataRow fila = dt.NewRow();
                    fila["Nombre"] = "Seleccione un Programa de estudio";
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
                con.Close();

            }
        }

        private void visualizarDocentes()
        {

            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT DocenteID, Nombres +' '+ Apellidos AS NombreCompleto FROM DOCENTE WHERE ProgramaEstudioID = @ProgramaEstudioID", con);
                da.SelectCommand.Parameters.AddWithValue("@ProgramaEstudioID", cbxPE.SelectedValue);
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

            
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAgregarCurso_Load(object sender, EventArgs e)
        {
            ListarCursos();  
        }
        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (MessageBox.Show("¿Estas seguro que quieres guardar", "Cursos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(Globales.cadena))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "USP_CURSO_Guardar";
                        if (accion == "M")
                        {
                            cmd.CommandText = "USP_CURSO_Actualizar";
                            cmd.Parameters.AddWithValue("@CursoID", txtID.Text);
                        }
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Horario_Inicio", txtHI.Text);
                        cmd.Parameters.AddWithValue("@Horario_Final", txtHF.Text);
                        cmd.Parameters.AddWithValue("@ProgramaEstudioID", cbxPE.SelectedValue);
                        cmd.Parameters.AddWithValue("@DocenteID", cbxDocente.SelectedValue);
                        //cmd.Parameters.AddWithValue("@DocenteID", txtDocID.Text);
                        //cmd.Parameters.AddWithValue("@ProgramaEstudioID", txtpeID.Text);

                        cmd.CommandType = CommandType.StoredProcedure;
                        int nReg = cmd.ExecuteNonQuery();
                        if (nReg > 0)
                        {
                            ListarCursos();
                            cancelar();
                            Limpiar();
                            MessageBox.Show("Los datos del curso se guardaron correctamente", "Curso");
                        }
                        else
                            MessageBox.Show("Los datos del curso no se guardaron", "Curso");
                    }
                }
            }
        }

        private void dgvCurso_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCurso.SelectedRows.Count > 0)
            {
                txtID.Text = dgvCurso.SelectedRows[0].Cells[0].Value.ToString();
                txtNombre.Text = dgvCurso.SelectedRows[0].Cells[1].Value.ToString();
                txtHI.Text = dgvCurso.SelectedRows[0].Cells[2].Value.ToString();
                txtHF.Text = dgvCurso.SelectedRows[0].Cells[3].Value.ToString();
                //txtDocID.Text = dgvCurso.SelectedRows[0].Cells[4].Value.ToString();
                //txtpeID.Text = dgvCurso.SelectedRows[0].Cells[5].Value.ToString();
                cbxPE.SelectedText = dgvCurso.SelectedRows[0].Cells[5].Value.ToString();
                cbxDocente.SelectedText = dgvCurso.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCurso.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Seguro de Eliminar datos el curso?", "Curso", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int codigo = (int)dgvCurso.SelectedRows[0].Cells[0].Value;
                    using (SqlConnection con = new SqlConnection(Globales.cadena))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("USP_CURSO_Eliminar", con);
                        cmd.CommandType = CommandType.StoredProcedure;     //Procedimiento almacenado
                        cmd.Parameters.AddWithValue("@CursoID", codigo);
                        int nReg = cmd.ExecuteNonQuery(); // devuelve la cantidad de afectados
                        if (nReg > 0)
                        {
                            ListarCursos();
                            MessageBox.Show("Los datos del Curso fueron eliminados", "Curso");

                        }
                        else
                            MessageBox.Show("Los datos del Curso no se eliminaron", "Curso");
                    }
                }
            }
            else
                MessageBox.Show("Seleccione los datos a eliminar", "Curso");

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            accion = "N";
            listar_programaEstudio();
            nuevo();
            Limpiar();
        }

        private void txtHI_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            visualizarDocentes();
        }
    }
}
