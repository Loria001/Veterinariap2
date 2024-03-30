using System;
using System.Data;
using System.Data.SqlClient;

public class GestorSesion
{
    public int LoginUsuario { get; set; }
    public string ClaveUsuario { get; set; }

    public bool ValidarCredenciales()
    {
        // Cadena de conexión a la base de datos
        string connectionString = "Data Source=LAPTOP-4M73J555\\SQLEXPRESS;Initial Catalog=DBVETERINARIA;Integrated Security=True";

        // Nombre del procedimiento almacenado
        string storedProcedure = "validar";

        // Crear conexión y comando
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(storedProcedure, connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            // Parámetros del procedimiento almacenado
            command.Parameters.AddWithValue("@login_usuario", LoginUsuario);
            command.Parameters.AddWithValue("@clave_usuario", ClaveUsuario);

            // Abrir conexión y ejecutar el comando
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // Verificar si se encontraron registros
            if (reader.Read())
            {
                // Se encontró un registro, inicio de sesión exitoso
                // Aquí podrías almacenar información del usuario en sesiones, cookies, etc.
                return true;
            }
            else
            {
                // No se encontraron registros, inicio de sesión fallido
                return false;
            }
        }
    }
}
