    using System;
    using System.Data.SqlClient;

    namespace Veterinariap2
    {
        public partial class GestionMascotas : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {

            }

            protected void btnAgregar_Click(object sender, EventArgs e)
            {
                string nombreMascota = txtNombreMascota.Text;
                string tipoMascota = txtTipoMascota.Text;
                string comidaFavorita = txtComidaFavorita.Text;

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Mascota (nombre_mascota, tipo_mascota, comida_favorita) VALUES (@NombreMascota, @TipoMascota, @ComidaFavorita)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreMascota", nombreMascota);
                        command.Parameters.AddWithValue("@TipoMascota", tipoMascota);
                        command.Parameters.AddWithValue("@ComidaFavorita", comidaFavorita);
                        connection.Open();
                        command.ExecuteNonQuery();
                        lblMensajeError.Text = "La mascota ha sido agregada correctamente.";
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                }
            }

            protected void btnEliminar_Click(object sender, EventArgs e)
            {
                int idMascota;
                if (int.TryParse(txtIdMascota.Text, out idMascota))
                {
                    if (MascotaExists(idMascota))
                    {
                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM Mascota WHERE id_mascota = @IdMascota";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@IdMascota", idMascota);
                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    lblMensajeError.Text = "La mascota ha sido eliminada correctamente.";
                                    Response.Redirect(Request.Url.AbsoluteUri);
                                }
                                else
                                {
                                    lblMensajeError.Text = "No se encontró una mascota con el ID especificado.";
                                }
                            }
                        }
                    }
                    else
                    {
                        lblMensajeError.Text = "ID no existe en la tabla mascotas";
                    }
                }
                else
                {
                    lblMensajeError.Text = "Por favor, ingrese un ID de mascota válido.";
                }
            }



            protected void btnModificar_Click(object sender, EventArgs e)
            {
                int idMascota;
                if (int.TryParse(txtIdMascota.Text, out idMascota))
                {
                    string nombreMascota = txtNombreMascota.Text;
                    string tipoMascota = txtTipoMascota.Text;
                    string comidaFavorita = txtComidaFavorita.Text;

                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Mascota SET nombre_mascota = @NombreMascota, tipo_mascota = @TipoMascota, comida_favorita = @ComidaFavorita WHERE id_mascota = @IdMascota";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@NombreMascota", nombreMascota);
                            command.Parameters.AddWithValue("@TipoMascota", tipoMascota);
                            command.Parameters.AddWithValue("@ComidaFavorita", comidaFavorita);
                            command.Parameters.AddWithValue("@IdMascota", idMascota);
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            Response.Redirect(Request.Url.AbsoluteUri);
                            if (rowsAffected > 0)
                            {
                                lblMensajeError.Text = "La mascota ha sido modificada correctamente.";
                            }
                            else
                            {
                                lblMensajeError.Text = "No se encontró una mascota con el ID especificado.";
                            }
                        }
                    }
                }
                else
                {
                    lblMensajeError.Text = "Por favor, ingrese un ID de mascota válido.";
                }
            }

            private bool MascotaExists(int idMascota)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Mascota WHERE id_mascota = @IdMascota";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdMascota", idMascota);
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
        }
    }
