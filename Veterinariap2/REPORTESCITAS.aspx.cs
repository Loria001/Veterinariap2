using System;
using System.Data.SqlClient;

namespace Veterinariap2
{
    public partial class REPORTES_CITAS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int idMascota;
            if (int.TryParse(txtIdMascota.Text, out idMascota))
            {
                if (MascotaExists(idMascota))
                {
                    DateTime proximaFecha;
                    if (DateTime.TryParse(txtProximaFecha.Text, out proximaFecha))
                    {
                        string medicoAsignado = txtMedicoAsignado.Text;

                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "INSERT INTO Cita (id_mascota, proxima_fecha, medico_asiganado) VALUES (@IdMascota, @ProximaFecha, @MedicoAsignado)";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@IdMascota", idMascota);
                                command.Parameters.AddWithValue("@ProximaFecha", proximaFecha);
                                command.Parameters.AddWithValue("@MedicoAsignado", medicoAsignado);
                                connection.Open();
                                command.ExecuteNonQuery();
                                lblMensajeError.Text = "La cita ha sido agregada correctamente.";
                                Response.Redirect(Request.Url.AbsoluteUri);
                            }
                        }
                    }
                    else
                    {
                        lblMensajeError.Text = "La fecha ingresada no es válida.";
                    }
                }
                else
                {
                    lblMensajeError.Text = "La mascota con el ID especificado no existe.";
                }
            }
            else
            {
                lblMensajeError.Text = "Por favor, ingrese un ID de mascota válido.";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idCita;
            if (int.TryParse(txtIdCita.Text, out idCita))
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Cita WHERE id_cita = @IdCita";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdCita", idCita);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)       
                        {
                            lblMensajeError.Text = "La cita ha sido eliminada correctamente.";
                            Response.Redirect(Request.Url.AbsoluteUri);
                        }
                        else
                        {
                            lblMensajeError.Text = "No se encontró una cita con el ID especificado.";
                        }
                    }
                }
            }

        }



        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int idCita;
            if (int.TryParse(txtIdCita.Text, out idCita))
            {
                DateTime proximaFecha;
                if (DateTime.TryParse(txtProximaFecha.Text, out proximaFecha))
                {
                    string medicoAsignado = txtMedicoAsignado.Text;

                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBVETERINARIAConnectionString"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Cita SET proxima_fecha = @ProximaFecha, medico_asiganado = @MedicoAsignado WHERE id_cita = @IdCita";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ProximaFecha", proximaFecha);
                            command.Parameters.AddWithValue("@MedicoAsignado", medicoAsignado);
                            command.Parameters.AddWithValue("@IdCita", idCita);
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                lblMensajeError.Text = "La cita ha sido modificada correctamente.";
                            }
                            else
                            {
                                lblMensajeError.Text = "No se encontró una cita con el ID especificado.";
                            }
                        }
                    }
                }
                else
                {
                    lblMensajeError.Text = "La fecha ingresada no es válida.";
                }
            }
            else
            {
                lblMensajeError.Text = "Por favor, ingrese un ID de cita válido.";
            }
            Response.Redirect(Request.Url.AbsoluteUri);
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

        protected void txtIdMascota_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
