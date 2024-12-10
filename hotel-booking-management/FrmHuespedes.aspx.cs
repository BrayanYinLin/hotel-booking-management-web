using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyHotel_BE;
using ProyHotel_BL;
namespace hotel_booking_management
{
    public partial class FrmHuespedes : System.Web.UI.Page
    {
        HuespedBL huespedBL = new HuespedBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    gridHuespedes.DataSource = huespedBL.listarHuespedes();
                    gridHuespedes.DataBind();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("error: ",ex);
            }
        }

        private void CargarDatos()
        {
            gridHuespedes.DataSource = huespedBL.listarHuespedes();
            gridHuespedes.DataBind();
        }

        protected void gridHuespedes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridHuespedes.PageIndex = e.NewPageIndex;
            CargarDatos();
        }

        protected void btnBuscarPorNombre_Click(object sender, EventArgs e)
        {
            try
            {
                List<HuespedBE> buscarHuesped = new List<HuespedBE>();
                buscarHuesped.Add(huespedBL.BuscarHuespedPorNombre(txtNombre.Text));

                gridHuespedes.DataSource = buscarHuesped;
                gridHuespedes.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("error: ", ex);
            }
        }
    }
}