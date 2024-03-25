using System;
using System.Data.SqlClient;

namespace Veterinariap2
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string claveUsuario = txtClaveUsuario.Text;

            int loginUsuario;
            if (int.TryParse(txtLoginUsuario.Text, out loginUsuario))
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Usuario (login_usuario, nombre_usuario, clave_usuario) VALUES (@LoginUsuario, @NombreUsuario, @ClaveUsuario)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoginUsuario", loginUsuario);
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        command.Parameters.AddWithValue("@ClaveUsuario", claveUsuario);
                        connection.Open();
                        command.ExecuteNonQuery();
                        lblMensajeError.Text = "El usuario ha sido agregado correctamente.";
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                }
            }
            else
            {
                lblMensajeError.Text = "Por favor, ingrese un login de usuario válido.";
            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int loginUsuario;
            if (int.TryParse(txtLoginUsuario.Text, out loginUsuario))
            {
                if (UsuarioExists(loginUsuario))
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Usuario WHERE login_usuario = @LoginUsuario";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@LoginUsuario", loginUsuario);
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                lblMensajeError.Text = "El usuario ha sido eliminado correctamente.";
                                Response.Redirect(Request.Url.AbsoluteUri);
                            }
                            else
                            {
                                lblMensajeError.Text = "No se encontró un usuario con el login especificado.";
                            }
                        }
                    }
                }
                else
                {
                    lblMensajeError.Text = "El login no existe en la tabla de usuarios.";
                }
            }
            else
            {
                lblMensajeError.Text = "Por favor, ingrese un login de usuario válido.";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int loginUsuario;
            if (int.TryParse(txtLoginUsuario.Text, out loginUsuario))
            {
                string nombreUsuario = txtNombreUsuario.Text;
                string claveUsuario = txtClaveUsuario.Text;

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Usuario SET nombre_usuario = @NombreUsuario, clave_usuario = @ClaveUsuario WHERE login_usuario = @LoginUsuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        command.Parameters.AddWithValue("@ClaveUsuario", claveUsuario);
                        command.Parameters.AddWithValue("@LoginUsuario", loginUsuario);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Response.Redirect(Request.Url.AbsoluteUri);
                        if (rowsAffected > 0)
                        {
                            lblMensajeError.Text = "El usuario ha sido modificado correctamente.";
                        }
                        else
                        {
                            lblMensajeError.Text = "No se encontró un usuario con el login especificado.";
                        }
                    }
                }
            }
            else
            {
                lblMensajeError.Text = "Por favor, ingrese un login de usuario válido.";
            }
        }

        private bool UsuarioExists(int loginUsuario)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Usuario WHERE login_usuario = @LoginUsuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoginUsuario", loginUsuario);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
