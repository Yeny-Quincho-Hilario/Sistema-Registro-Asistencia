using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace RegistroAsistencia
{
    public partial class frmAsistencia : Form
    {
        DataTable dt = new DataTable();
        public frmAsistencia()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
     
        private bool Validar()
        {
            bool exito = true;
            string mensaje = "";
            if (dtpFecha.Value > DateTime.Now)
            {
                exito = false;
                mensaje = "La fecha es incorrecta...";
                dtpFecha.Focus();
            }

            else if (dgvAsistencia.Rows.Count == 0)
            {
                exito = false;
                mensaje = "No existen estudiantes que registrar...";
                dgvAsistencia.Focus();
            }
            if (!exito)
                MessageBox.Show(mensaje, "Asistencia");
            return exito;
        }
        //public string ObtenerNombreDocenteDelCurso(string Nombre)
        //{
        //    string NombreCompleto = string.Empty; // es igual a poner--string nombreDocente = " ";

        //    // Aquí deberías realizar una consulta a tu base de datos para obtener el nombre del docente según el nombre del curso
        //    string query = "SELECT D.Nombres + ' '+ D.Apellidos AS NombreCompleto FROM CURSO AS C INNER JOIN DOCENTE AS D ON C.DocenteID = D.DocenteID WHERE C.Nombre = @Nombre";

        //    using (SqlConnection connection = new SqlConnection(Globales.cadena))
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Nombre", Nombre);

        //            connection.Open();
        //            var result = command.ExecuteScalar();
        //            if (result != null)
        //            {
        //                NombreCompleto = result.ToString();
        //            }
        //        }
        //    }

        //    return NombreCompleto;
        //}

        private void ListarCursos()
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter("USP_Listar_CursosAsistencia", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@DocenteID", Globales.DocenteID);
                DataTable dt = new DataTable();

                try
                {
                    con.Open();
                    da.Fill(dt);

                    DataRow fila = dt.NewRow();
                    fila["Nombre"] = "Seleccione el curso";
                    dt.Rows.InsertAt(fila, 0);

                    // Asignar los datos al ComboBox de Programas de Estudio
                    cmbCurso.DisplayMember = "Nombre";
                    cmbCurso.ValueMember = "CursoID";
                    cmbCurso.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar Programa de Estudios: " + ex.Message);
                }
                //con.Close();

            }

        }
        private void ListadoEstudiantes()
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("USP_ListarEstudiante_x_Curso", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@CursoID", cmbCurso.SelectedValue);
                da.Fill(dt);
                dgvAsistencia.DataSource = dt;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAsistencia_Load(object sender, EventArgs e)
        {

            // Obtiene la columna específica que contiene el ComboBox
            DataGridViewComboBoxColumn Estado = (DataGridViewComboBoxColumn)dgvAsistencia.Columns["Estado"];

            //mandera como se llenar el ComboBox con una lista de items
            List<string> Condicion = new List<string> { "Asistió", "Falta", "Tarde" };
            Estado.DataSource = Condicion;

            ListarCursos();

            txtDocente.Text = Globales.Nombres;
            txtID.Text = Globales.DocenteID.ToString();

        }

        private void cmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (cmbCurso.SelectedItem != null)
            //{
            //    //string cursoSeleccionado = cmbCurso.SelectedItem.ToString();
            //    string cursoSeleccionado = cmbCurso.SelectedValue.ToString();

            //    // Realizar la conexión a la base de datos
            //    using (SqlConnection con = new SqlConnection(Globales.cadena))
            //    {
            //        con.Open();

            //        // Consulta SQL para obtener el nombre del docente del curso seleccionado
            //        //string query = $"SELECT Docente.Nombres FROM Curso INNER JOIN Docente ON Curso.DocenteID = Docente.DocenteID WHERE Curso.DocenteID = @DocenteID";

            //        using (SqlCommand cmd = new SqlCommand("USP_Mostrar_Docente", con))

            //        {
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@DocenteID", cursoSeleccionado);

            //            // Ejecutar la consulta y obtener el nombre del docente
            //            var result = cmd.ExecuteScalar();
            //            if (result != null)
            //            {
            //                txtDocente.Text = result.ToString();
            //            }
            //            else
            //            {
            //                // Si el curso seleccionado no tiene un docente asignado
            //                txtDocente.Text = "No se asignó un docente a este curso.";
            //            }
            //        }
            //    }
            //}

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ListadoEstudiantes();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                using (SqlConnection con = new SqlConnection(Globales.cadena))
                {
                    con.Open();

                    foreach (DataGridViewRow fila in dgvAsistencia.Rows)
                    {

                        if (int.TryParse(txtID.Text, out int ValorEntero))
                        {
                            if (!fila.IsNewRow)// Ignora la fila de entrada nueva (si está presente) ---IsNewRow = Es nueva fila
                            {
                                //Obtiene los valores de cada celda en la fila
                                int EstudianteID = Convert.ToInt32(fila.Cells["EstudianteID"].Value); // Reemplaza con el nombre de tus columnas
                                string NombreCompleto = fila.Cells["NombreCompleto"].Value.ToString();
                                string Estado = fila.Cells["Estado"].Value.ToString();


                                SqlCommand cmd = new SqlCommand("USP_ASISTENCIA_GUARDAR", con);
                                cmd.CommandType = CommandType.StoredProcedure;

                                // Agregar parámetros para insertar los valores de la fila en la consulta SQL

                                cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value);
                                cmd.Parameters.AddWithValue("@CursoID", cmbCurso.SelectedValue);
                                cmd.Parameters.AddWithValue("@DocenteID", ValorEntero);
                                cmd.Parameters.AddWithValue("@EstudianteID", EstudianteID);
                                cmd.Parameters.AddWithValue("@Estado", Estado);

                                // Ejecutar la consulta de inserción
                                int nReg = cmd.ExecuteNonQuery();
                                if (nReg > 0)
                                {
                                    MessageBox.Show("La Asistencia fué registrada", "ASISTENCIA");
                                }

                            }
                        }

                    }
                }

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void txtDocente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDocente_Leave(object sender, EventArgs e)
        {

        }
    }
}
