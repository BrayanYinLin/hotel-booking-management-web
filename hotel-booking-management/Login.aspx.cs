using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWEB_Sem10
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Text = String.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                //Codifique
                if (txtUsername.Text.Trim() == "admin" && txtPassword.Text.Trim() == "12345")
                {
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    throw new Exception("Usuario y/o contraseña incorrecta.");
                }
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "<div class='alert alert-danger' role='alert'>" + ex.Message + "</div>";
            }

        }
    }
}