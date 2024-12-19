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
                lblErrorMensaje.Text = ex.Message;

                throw new Exception("error: ", ex);
            }



        }
        private void CargarDatos()
        {
            DateTime fecInicio = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime fecFin = Convert.ToDateTime(txtFin.Text);

            if (fecInicio> fecFin)
            {
                throw new Exception("La fecha de inicio no puede ser mayor a la del fecha fin");
            }
            grdView.DataSource = reservaBL.obtenerReservasPorDNIyFechas(txtDni.Text,fecInicio,fecFin);
            grdView.DataBind();
        }

        protected void consultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFechaInicio.Text.Trim() == String.Empty || txtFin.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar las fechas de inicio y fin");
                }
                CargarDatos();
            }
            catch (Exception ex)
            {
                lblErrorMensaje.Text = ex.Message;
                grdView.DataSource = null;
                grdView.DataBind();
            }
        }
    }
}