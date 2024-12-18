using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyHotel_BL;

namespace hotel_booking_management
{
    public partial class FrmReserva : System.Web.UI.Page
    {
        ReservaBL reservaBL = new ReservaBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                graficoReserva.DataSource = reservaBL.graficoReservas();
                graficoReserva.DataBind();

                graficoReserva.Series.Add("Totales");
                graficoReserva.Series["Totales"].Points.DataBindXY(reservaBL.graficoReservas(), "periodo",
                                                                reservaBL.graficoReservas(), "ingreso_mensual");
                graficoReserva.Series["Totales"].IsValueShownAsLabel = true;
                graficoReserva.Series["Totales"].LabelFormat = "c";


                GraficoCantidadReservas.Series.Add("Reservas");
                GraficoCantidadReservas.Series["Reservas"].Points.DataBindXY(reservaBL.graficoReservas(), "periodo",
                                                                reservaBL.graficoReservas(), "cantidad_reservas");
                GraficoCantidadReservas.Series["Reservas"].IsValueShownAsLabel = true;



            }
            catch (Exception ex)
            {
                throw new Exception("error: ", ex);
            }
        }
    }
}