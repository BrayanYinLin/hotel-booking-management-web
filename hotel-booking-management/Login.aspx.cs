using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hotel_booking_management;

namespace DemoWEB_Sem10
{
    public partial class Login : System.Web.UI.Page
    {
        hotel_databaseEntities hotelDB = new hotel_databaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Text = String.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                //Codifique
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                var query = hotelDB.tb_usuario.ToList();

                foreach (var item in query)
                {
                    if (item.usuario_nombre == username && item.usuario_password == password)
                    {
                        Response.Redirect("Inicio.aspx");
                        return;
                    }
                }

                throw new Exception("Usuario y/o contraseña incorrecta.");
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "<div class='alert alert-danger' role='alert'>" + ex.Message + "</div>";
            }

        }
    }
}