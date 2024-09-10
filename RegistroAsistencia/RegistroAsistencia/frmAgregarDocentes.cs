using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace RegistroAsistencia
{
    public partial class frmAgregarDocentes : Form
    {
        string accion = "";

        public frmAgregarDocentes()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAgregarDocentes_Load(object sender, EventArgs e)
        {
            ListarDatos();
        }

        //CREANDO PROCEDIMIENTOS y FUNCIONES 
        private void Limpiar()
        {
            txtDocenteID.Clear();
            txtDNI.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtE_mail.Clear();
            txtTelefono.Clear();
            txtContraseña.Clear();          
            txtDNI.Focus();
        }

        private void nuevo()
        {
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
            txtDNI.ReadOnly = false;
            txtNombres.ReadOnly = false;
            txtApellidos.ReadOnly = false;
            txtE_mail.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtContraseña.ReadOnly = false;
            

        }
        private void cancelar()
        {
            btnGuardar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = true;
            txtDNI.ReadOnly = true;
            txtNombres.ReadOnly = true;
            txtApellidos.ReadOnly = true;
            txtE_mail.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtContraseña.ReadOnly = true;
        
            
        }
        // CREANDO FUNCION(METODO) TIPO BOOL
        private bool validar()
        {
            bool exito = true;
            string mensaje = "";

            if (txtDNI.Text.Trim().Length != 8)
            {
                exito = false;
                mensaje = "Complete los digitos de su DNI";
            }
            else if (txtNombres.Text.Trim().Length < 3)
            {
                exito = false;
                mensaje = "Escriba su nombre completo";
            }

            else if (txtApellidos.Text.Trim().Length < 5)
            {
                exito = false;
                mensaje = "Escriba sus apellidos completos";
            }
            else if (txtTelefono.Text.Trim().Length < 6)
            {
                exito = false;
                mensaje = "Complete los digitos de su telefono";
            }
            else if (txtE_mail.Text.Trim().Length < 5)
            {
                exito = false;
                mensaje = "Complete los digitos de su telefono";
            }
            
            else if (txtContraseña.Text.Trim().Length < 4)
            {
                exito = false;
                mensaje = "Complete su contarseña";
            }
            else if (cbxPE.SelectedIndex == -1)
            {
                exito = false;
                mensaje = "Seleccione el Programa de estudio";
            }
            if (!exito)
                MessageBox.Show(mensaje, "Advertencia");

            return exito;
        }
        private void ListarDatos()
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_DOCENTE_Listar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BindingSource bs = new BindingSource(); //bs es fuente vinculante
                bs.DataSource = dr;
                dgvRegDoc.DataSource = bs;
            }
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
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            accion = "N";
            listar_programaEstudio();
            nuevo();
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (MessageBox.Show("¿Estas seguro que quieres guardar", "Docentes", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(Globales.cadena))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "USP_DOCENTE_Guardar";
                        if (accion =="M")
                        {
                            cmd.CommandText = "USP_DOCENTE_Actualizar";
                            cmd.Parameters.AddWithValue("@DocenteID", txtDocenteID.Text);
                        }
                        cmd.Parameters.AddWithValue("@DNI", txtDNI.Text);
                        cmd.Parameters.AddWithValue("@Nombres", txtNombres.Text);
                        cmd.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                        cmd.Parameters.AddWithValue("@E_mail", txtE_mail.Text);
                        cmd.Parameters.AddWithValue("@Teléfono",txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@ProgramaEstudioID", cbxPE.SelectedValue);
                        cmd.Parameters.AddWithValue("@Contraseña", txtContraseña.Text);
                        //cmd.Parameters.AddWithValue("@ProgramaEstudioID", txtProgramaEstudioID.Text);


                        cmd.CommandType = CommandType.StoredProcedure;
                        int nReg = cmd.ExecuteNonQuery();
                        if (nReg > 0)
                        {
                            ListarDatos();
                            cancelar();
                            Limpiar();
                            MessageBox.Show("Los datos del docente se guardaron correctamente", "Docente");
                        }
                        else
                        MessageBox.Show("Los datos del docente no se guardaron", "Docente");
                    }
                }
            }
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtDocenteID.Text.Length > 0)
            {
                accion ="M";
                nuevo();
                listar_programaEstudio();
                txtDNI.Focus();

            }
            else
                MessageBox.Show("Seleccione los datos de Docente que quieres modificar", "Docente");

        }

        private void dgvRegDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        // PARA ESTE PROCEDIMIENTO SE TIENE QUE IR A EVENTOS DEL DVG Y BUSCAR 
        //DOUBLECLICK Y HACER DOBLE CLIC Y RECIEN AHI ESCRIBIR LA CONDICION
        private void dgvRegDoc_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRegDoc.SelectedRows.Count > 0)
            {
                txtDocenteID.Text = dgvRegDoc.SelectedRows[0].Cells[0].Value.ToString();
                txtDNI.Text = dgvRegDoc.SelectedRows[0].Cells[1].Value.ToString();
                txtNombres.Text = dgvRegDoc.SelectedRows[0].Cells[2].Value.ToString();
                txtApellidos.Text = dgvRegDoc.SelectedRows[0].Cells[3].Value.ToString();
                txtE_mail.Text = dgvRegDoc.SelectedRows[0].Cells[4].Value.ToString();
                txtTelefono.Text = dgvRegDoc.SelectedRows[0].Cells[5].Value.ToString();
                cbxPE.SelectedText= dgvRegDoc.SelectedRows[0].Cells[6].Value.ToString();
                txtContraseña.Text = dgvRegDoc.SelectedRows[0].Cells[7].Value.ToString();
                // txtProgramaEstudioID.Text = dgvRegDoc.SelectedRows[0].Cells[6].Value.ToString();

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           // fue un error
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
            Limpiar();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvRegDoc.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Seguro que quieres eliminar los datos del docente?", "Docente", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int codigo = (int)dgvRegDoc.SelectedRows[0].Cells[0].Value;
                    using (SqlConnection con = new SqlConnection(Globales.cadena))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("USP_DOCENTE_Eliminar", con);
                        cmd.CommandType = CommandType.StoredProcedure;     //Procedimiento almacenado
                        cmd.Parameters.AddWithValue("@DocenteID", codigo);
                        int nReg = cmd.ExecuteNonQuery(); // devuelve la cantidad de afectados
                        if (nReg > 0)
                        {
                            ListarDatos();
                            MessageBox.Show("Los datos del docente fueron eliminados", "Docente");

                        }
                        else
                            MessageBox.Show("Los datos del docente no se eliminaron", "Docente");
                    }
                }
            }
            else
                MessageBox.Show("Seleccione los datos a eliminar", "Docente");

        }

        private void txtProgramaEstudioID_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
