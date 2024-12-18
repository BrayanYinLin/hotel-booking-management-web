using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyHotel_BE;

namespace ProyHotel_ADO
{
    public class ServicioADO
    {
        hotel_databaseEntities hotel = new hotel_databaseEntities();

        public List<ServicioBE> ListarServicio()
        {
            try
            {
                List<ServicioBE> ListaServicios = new List<ServicioBE>();

                var query = (from service in hotel.vw_servicio orderby service.Id select service).ToList();

                foreach (var service in query)
                {
                    ServicioBE servicioBE = new ServicioBE();
                    servicioBE.servicioId = service.Id;
                    servicioBE.servicioDescripcion = service.Servicio_Descripcion;
                    servicioBE.servicioPrecio = Convert.ToSingle(service.Precio);
                    servicioBE.servicioFechaCreacion = service.Fecha_Creacion ?? DateTime.MinValue;
                    servicioBE.servicioEstadoBoolean = service.Estado == "Activo";
                    servicioBE.servicioEstado = service.Estado;

                    ListaServicios.Add(servicioBE);

                }

                return ListaServicios;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }

        public ServicioBE BuscarServicioPorNombre(string nombre)
        {
            try
            {
                var servicio = (from service in hotel.vw_servicio orderby service.Id select service).Where(service => service.Servicio_Descripcion == nombre).FirstOrDefault();

                if (servicio == null)
                {
                    throw new Exception("No se hallo el servicio");
                }

                ServicioBE servicioBE = new ServicioBE();
                servicioBE.servicioId = servicio.Id;
                servicioBE.servicioDescripcion = servicio.Servicio_Descripcion;
                servicioBE.servicioPrecio = Convert.ToSingle(servicio.Precio);
                servicioBE.servicioFechaCreacion = servicio.Fecha_Creacion ?? DateTime.MinValue;
                servicioBE.servicioEstadoBoolean = servicio.Estado == "Activo";
                servicioBE.servicioEstado = servicio.Estado;

                return servicioBE;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ServicioGrafico> ListarServicioGrafico()
        {
            try
            {

                hotel_databaseEntities miHotel = new hotel_databaseEntities();

                List<ServicioGrafico> listServicios = new List<ServicioGrafico>();

                var query = miHotel.usp_servicios_mes();

                foreach (var resultado in query)
                {
                    ServicioGrafico datoGrafico = new ServicioGrafico();
                    datoGrafico.periodo = resultado.Periodo;
                    datoGrafico.cantidad = Convert.ToInt32(resultado.Cantidad);
                    datoGrafico.ingresoMensual = Convert.ToDouble(resultado.Ingreso_Mensual);

                    listServicios.Add(datoGrafico);

                }
                return listServicios;
            }
            catch (EntityException ex)
            {
                throw new Exception($"Error en el listado: {ex.Message}");
            }
        }
    }
}
