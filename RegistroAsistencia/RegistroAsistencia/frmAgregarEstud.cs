using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RegistroAsistencia
{
    public partial class frmAgregarEstud : Form
    {
        string accion = "";
        public frmAgregarEstud()
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
        //CREANDO PROCEDIMIENTOS 
        private void Limpiar()
        {
            txtID.Clear();
            txtDNI.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtE_mail.Clear();
            txtTelefono.Clear();
            //cbxPE.SelectedItem = 0;
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
            else if (txtNombres.Text.Trim().Length <= 3)
            {
                exito = false;
                mensaje = "Escriba su nombre completo";
            }

            else if (txtApellidos.Text.Trim().Length <= 5)
            {
                exito = false;
                mensaje = "Escriba sus apellidos completos";
            }
            else if (txtTelefono.Text.Trim().Length <= 5)
            {
                exito = false;
                mensaje = "Complete los digitos de su telefono";
            }
            else if (txtE_mail.Text.Trim().Length <= 5)
            {
                exito = false;
                mensaje = "Complete los digitos de su telefono";
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
                SqlCommand cmd = new SqlCommand("USP_ESTUDIANTE_Listar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BindingSource bs = new BindingSource(); //bs es fuente vinculante
                bs.DataSource = dr;
                dgvEstudiantes.DataSource = bs;
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAgregarEstud_Load(object sender, EventArgs e)
        {
            ListarDatos();
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
                if (MessageBox.Show("¿Estas seguro que quieres guardar", "Estudiante", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(Globales.cadena))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "USP_ESTUDIANTE_Guardar";
                        if (accion == "M")
                        {
                            cmd.CommandText = "USP_ESTUDIANTE_Actualizar";
                            cmd.Parameters.AddWithValue("@EstudianteID", txtID.Text);
                        }
                        cmd.Parameters.AddWithValue("@DNI", txtDNI.Text);
                        cmd.Parameters.AddWithValue("@Nombres", txtNombres.Text);
                        cmd.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                        cmd.Parameters.AddWithValue("@E_mail", txtE_mail.Text);
                        cmd.Parameters.AddWithValue("@Teléfono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@ProgramaEstudioID", cbxPE.SelectedValue);

                        cmd.CommandType = CommandType.StoredProcedure;
                        int nReg = cmd.ExecuteNonQuery();
                        if (nReg > 0)
                        {
                            ListarDatos();
                            cancelar();
                            Limpiar();
                            MessageBox.Show("Los datos del estudiante se guardaron correctamente", "Estudiante");
                        }
                        else
                            MessageBox.Show("Los datos del estudiante no se guardaron", "Estudiante");
                    }
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length > 0)
            {
                accion = "M";
                nuevo();
                listar_programaEstudio();
                txtDNI.Focus();

            }
            else
                MessageBox.Show("Seleccione los datos del Estudiante que quieres modificar", "Estudiante");
        }

        private void dgvEstudiantes_DoubleClick(object sender, EventArgs e)
        {

            if (dgvEstudiantes.SelectedRows.Count > 0)
            {
                txtID.Text = dgvEstudiantes.SelectedRows[0].Cells[0].Value.ToString();
                txtDNI.Text = dgvEstudiantes.SelectedRows[0].Cells[1].Value.ToString();
                txtNombres.Text = dgvEstudiantes.SelectedRows[0].Cells[2].Value.ToString();
                txtApellidos.Text = dgvEstudiantes.SelectedRows[0].Cells[3].Value.ToString();
                txtTelefono.Text = dgvEstudiantes.SelectedRows[0].Cells[4].Value.ToString();
                txtE_mail.Text = dgvEstudiantes.SelectedRows[0].Cells[5].Value.ToString();
                cbxPE.SelectedText = dgvEstudiantes.SelectedRows[0].Cells[6].Value.ToString();
                //listar_programaEstudio();
            }
        }

        private void dgvEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
            Limpiar();
            listar_programaEstudio();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Seguro de Eliminar datos del estudiante?", "Estudiante", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int codigo = (int)dgvEstudiantes.SelectedRows[0].Cells[0].Value;
                    using (SqlConnection con = new SqlConnection(Globales.cadena))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("USP_ESTUDIANTE_Eliminar", con);
                        cmd.CommandType = CommandType.StoredProcedure;     //Procedimiento almacenado
                        cmd.Parameters.AddWithValue("@EstudianteID", codigo);
                        int nReg = cmd.ExecuteNonQuery(); // devuelve la cantidad de afectados
                        if (nReg > 0)
                        {
                            ListarDatos();
                            MessageBox.Show("Los datos del estudiante fueron eliminados", "Estudiante");

                        }
                        else
                            MessageBox.Show("Los datos del estudiante no se eliminaron", "Estudiante");
                    }
                }
            }
            else
                MessageBox.Show("Seleccione los datos a eliminar", "Estudiante");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

}

