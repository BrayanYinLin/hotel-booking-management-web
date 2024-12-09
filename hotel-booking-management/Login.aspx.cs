using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hotel_booking_management;
using ProyHotel_BE;
using ProyHotel_BL;

namespace hotel_booking_management
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioBL usuarioBL = new UsuarioBL();
        UsuarioBE usuarioBE = new UsuarioBE();

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Text = String.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBE usuarioRegistrado = new UsuarioBE();
                usuarioRegistrado.usuarioNombre = txtUsername.Text;
                usuarioRegistrado.usuarioClave = txtPassword.Text;

                usuarioBE = usuarioBL.IniciarSesion(usuarioRegistrado);
                if (usuarioBE != null)
                {
                    Response.Redirect("Inicio.aspx");
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "<div class='alert alert-danger' role='alert'>" + ex.Message + "</div>";
            }
        }
    }
}