using ProyHotel_BE;
using ProyHotel_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hotel_booking_management
{
    public partial class FrmServicioHospedaje : System.Web.UI.Page
    {
        ServicioBL servicioBL = new ServicioBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<ServicioReservaBE> listTargets = servicioBL.BuscarPorReserva(Convert.ToInt32(textboxSearch.Text.Trim()));
                gridServicesSearched.DataSource = listTargets;
                gridServicesSearched.DataBind();
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
            }
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {

        }

        protected void gridServicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}