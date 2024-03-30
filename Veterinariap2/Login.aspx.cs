using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Veterinariap2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bingresar_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de usuario y la contraseña ingresados por el usuario
            int loginUsuario;
            if (int.TryParse(Tusuario.Text.Trim(), out loginUsuario))
            {

            }
            else
            {

            }
            string claveUsuario = Tclave.Text.Trim();

            // Crear una instancia de GestorSesion y asignar los valores de las propiedades
            GestorSesion gestorSesion = new GestorSesion();
            gestorSesion.LoginUsuario = loginUsuario;
            gestorSesion.ClaveUsuario = claveUsuario;

            // Llamar al método ValidarCredenciales
            bool inicioSesionExitoso = gestorSesion.ValidarCredenciales();

            // Verificar si el inicio de sesión fue exitoso
            if (inicioSesionExitoso)
            {
                // Inicio de sesión exitoso, redireccionar al usuario a la página INICIO.aspx
                Response.Redirect("INICIO.aspx");
            }
            else
            {
                // Inicio de sesión fallido, mostrar mensaje de error
                Lerror.Text = "Usuario o contraseña incorrectos.";
            }
        }




    }
}