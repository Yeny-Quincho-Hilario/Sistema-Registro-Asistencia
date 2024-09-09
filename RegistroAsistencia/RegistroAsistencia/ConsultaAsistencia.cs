using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RegistroAsistencia
{
    public partial class ConsultaAsistencia : Form
    {
        public ConsultaAsistencia()
        {
            InitializeComponent();
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void ConsultaAsistencia_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Globales.cadena))
            {
                con.Open();
                ////string sql = $"SELECT IdProducto,NombreProducto,CantidadPorUnidad,PrecioUnidad,UnidadesEnExistencia,Suspendido FROM Productos WHERE IdProducto={lstProductos.SelectedValue}";
                //SqlCommand cmd = new SqlCommand("USP_HistorialAsistencia", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@EstudianteID", txtDNI.Text);
                //SqlDataReader dr = cmd.ExecuteReader();

                SqlDataAdapter da = new SqlDataAdapter("USP_HistorialAsistencia", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@EstudianteID", txtID.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAsistencia.DataSource = dt;


                DataRow filaEstudiante = dt.Rows[0];
                // Obtén los valores de las columnas específicas y asígnalos a los TextBox
                txtNombres.Text = filaEstudiante["Nombres"].ToString();
                txtApellidos.Text = filaEstudiante["Apellidos"].ToString();
                txtDNI.Text = filaEstudiante["DNI"].ToString();



            }
        }
    }
}
