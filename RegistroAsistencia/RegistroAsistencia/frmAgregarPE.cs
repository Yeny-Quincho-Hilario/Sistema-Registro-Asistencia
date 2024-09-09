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
    public partial class frmAgregarPE : Form
    {
        string accion = "";
        public frmAgregarPE()
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //CREANDO PROCEDIMIENTOS 
        private void Limpiar()
        {
            txtIdPE.Clear();
            txtNombre.Clear();
            txtNombre.Focus();
        }

        private void nuevo()
        {
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
            txtNombre.ReadOnly = false;

        
        }
        private void cancelar()
        {
            btnGuardar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = true;
            txtNombre.ReadOnly = true;
        }

        // CREANDO FUNCION(METODO) TIPO BOOL
        private bool validar()
        {
            bool exito = true;
            string mensaje = "";

            if (txtNombre.Text.Trim().Length <= 5)
            {
                exito = false;
                mensaje = "Complete el nombre del Programa de Estudio";
            }

            if (!exito)
                MessageBox.Show(mensaje, "Advertencia");

            return exito;
        }

        private void ListarProgramas()
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_PROGRAMA_ESTUDIO_Listar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BindingSource bs = new BindingSource(); //bs es fuente vinculante
                bs.DataSource = dr;
                dvgAgregarPE.DataSource = bs;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            accion = "N";
            nuevo();
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtIdPE.Text.Length > 0)
            {
                accion = "M";
                nuevo();
                txtNombre.Focus();

            }
            else
                MessageBox.Show("Seleccione el Programa de Estudio que quieres modificar", "Docente");

        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (MessageBox.Show("¿Estas seguro que quieres guardar", "Programa de Estudios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(Globales.cadena))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "USP_PROGRAMA_ESTUDIO_Guardar";
                        if (accion == "M")
                        {
                            cmd.CommandText = "USP_PROGRAMA_ESTUDIO_Actualizar";
                            cmd.Parameters.AddWithValue("@ProgramaEstudioID", txtIdPE.Text);
                        }
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.CommandType = CommandType.StoredProcedure;
                        int nReg = cmd.ExecuteNonQuery();
                        if (nReg > 0)
                        {
                            ListarProgramas();
                            cancelar();
                            Limpiar();
                            MessageBox.Show("El Programa de Estudio se guardó correctamente", "Programa de Estudio");
                        }
                        else
                            MessageBox.Show("El Programa de Estudio no se guardó", "Programa de Estudio");
                    }
                }
            }
        }

        private void frmAgregarPE_Load(object sender, EventArgs e)
        {
            ListarProgramas();
        }

        
        private void dvgAgregarPE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dvgAgregarPE_DoubleClick(object sender, EventArgs e)
        {
            if (dvgAgregarPE.SelectedRows.Count > 0)
            {
                txtIdPE.Text = dvgAgregarPE.SelectedRows[0].Cells[0].Value.ToString();
                txtNombre.Text = dvgAgregarPE.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dvgAgregarPE.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Seguro de Eliminar el Programa de Estudio?", "Programa de Estudio", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int codigo = (int)dvgAgregarPE.SelectedRows[0].Cells[0].Value;
                    using (SqlConnection con = new SqlConnection(Globales.cadena))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("USP_PROGRAMA_ESTUDIO_Eliminar", con);
                        cmd.CommandType = CommandType.StoredProcedure;     //Procedimiento almacenado
                        cmd.Parameters.AddWithValue("@ProgramaEstudioID", codigo);
                        int nReg = cmd.ExecuteNonQuery(); // devuelve la cantidad de afectados
                        if (nReg > 0)
                        {
                            ListarProgramas();
                            MessageBox.Show("Los datos del Programa de Estudio fueron eliminados", "Programa de Estudio");

                        }
                        else
                            MessageBox.Show("Los datos del Programa de Estudio no se eliminaron", "Programa de Estudio");
                    }
                }
            }
            else
                MessageBox.Show("Seleccione los datos del Programa de Estudio a eliminar", "Programa de Estudio");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
            Limpiar();
        }
    }
}
