using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RegistroAsistencia
{
    public partial class frmLogin : Form
    {
        int intento = 0;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        private bool validar()
        {
            // CREANDO FUNCION(METODO) TIPO BOOL
                bool exito = true;
                string mensaje = "";

                if (txtUsuario.Text.Trim().Length < 3)
                {
                    exito = false;
                    mensaje = "Complete el nombre del usuario";
                    txtUsuario.Focus();
                }
               else if (txtContraseña.Text.Trim().Length < 3)
                {
                    exito = false;
                    mensaje = "Complete su contraseña";
                    txtContraseña.Focus();
                }

                 if (!exito)// si no es exito o si exito = falso
                    MessageBox.Show(mensaje, "Advertencia");

                return exito;
            }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btbnIngresar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                using (SqlConnection con = new SqlConnection(Globales.cadena))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("USP_UsuariosLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNI", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@contraseña", txtContraseña.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows) //has row devuelve V si es que la consulta trae datos y si devuelve F np existe el ususario o contraseña
                    {
                        //leer los datos del DataReader a variables
                        dr.Read();
                        Globales.DocenteID = dr.GetInt32(0);
                   
                        Globales.Nombres = dr.GetString(1);

                        Form formulario = new frmPanelMenu();
                        this.Hide();
                        formulario.ShowDialog();
                        this.Show();
                    }

                    else
                    {
                        intento+=1;
                        MessageBox.Show("Usuario/Contraseña incorrecta", "Registro de Asistencia");
                        if (intento == 3)
                            this.Close();
                    }
                }
            }

        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

