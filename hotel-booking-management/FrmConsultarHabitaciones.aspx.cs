using ProyHotel_BE;
using ProyHotel_BL;
using System;
using System.Collections.Generic;

namespace hotel_booking_management
{
    public partial class FrmConsultarHabitaciones : System.Web.UI.Page
    {
        HabitacionBL habitacionBL = new HabitacionBL();
        TipoHabitacionBL tipoHabitacionBL = new TipoHabitacionBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    CargarTiposHabitacion();
                    CargarHabitaciones(0);
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private void CargarTiposHabitacion()
        {
            try
            {
                List<TipoHabitacionBE> listaTipos = tipoHabitacionBL.ListarTiposHabitacion();

                TipoHabitacionBE opcionInicial = new TipoHabitacionBE
                {
                    tipoHabitacionId = 0,
                    tipoHabitacionDescripcion = "--Seleccione--"
                };
                listaTipos.Insert(0, opcionInicial);

                cboTipoHabitacion.DataSource = listaTipos;
                cboTipoHabitacion.DataValueField = "tipoHabitacionId";
                cboTipoHabitacion.DataTextField = "tipoHabitacionDescripcion";
                cboTipoHabitacion.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los tipos de habitación: " + ex.Message;
            }
        }

        private void CargarHabitaciones(int tipoHabitacionId)
        {
            try
            {
                List<HabitacionBE> listaHabitaciones = habitacionBL.obtenerListaHabitacionesPorTipo(tipoHabitacionId);

                grvHabitaciones.DataSource = listaHabitaciones;
                grvHabitaciones.DataBind();

                lblMensaje.Text = $"Registros encontrados: {listaHabitaciones.Count}";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar las habitaciones: " + ex.Message;
            }
        }

        protected void btnFiltrar_Click1(object sender, EventArgs e)
        {
            try
            {
                int tipoHabitacionId = Convert.ToInt32(cboTipoHabitacion.SelectedValue);

                CargarHabitaciones(tipoHabitacionId);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al filtrar las habitaciones: " + ex.Message;
            }
        }
    }
}
