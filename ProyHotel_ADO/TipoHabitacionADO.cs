using ProyHotel_BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_ADO
{
    public class TipoHabitacionADO
    {
        hotel_databaseEntities hotel = new hotel_databaseEntities();

        public List<TipoHabitacionBE> ListarTipoHabitacion()
        {
            try
            {
                List<TipoHabitacionBE> ListadoTipoHabitaciones = new List<TipoHabitacionBE>();

                var query = (from tipo in hotel.vw_tipo_habitacion orderby tipo.Id select tipo).ToList();

                foreach (var tipoHabitacion in query)
                {
                    TipoHabitacionBE tipoHabitacionBE = new TipoHabitacionBE();
                    tipoHabitacionBE.tipoHabitacionId = tipoHabitacion.Id;
                    tipoHabitacionBE.tipoHabitacionDescripcion = tipoHabitacion.Habitacion_Descripcion;
                    tipoHabitacionBE.tipoHabitacionPrecio = Convert.ToSingle(tipoHabitacion.Precio);

                    ListadoTipoHabitaciones.Add(tipoHabitacionBE);

                }

                return ListadoTipoHabitaciones;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoHabitacionBE BuscarTipoHabitacionPorNombre(string nombre)
        {
            try
            {
                var tipoHabitacion = (from habitacion in hotel.vw_tipo_habitacion orderby habitacion.Id select habitacion).Where(service => service.Habitacion_Descripcion == nombre).FirstOrDefault();

                if (tipoHabitacion == null)
                {
                    throw new Exception("No se hallo el tipo de habitacion");
                }

                TipoHabitacionBE tipoHabitacionBE = new TipoHabitacionBE();
                tipoHabitacionBE.tipoHabitacionId = tipoHabitacion.Id;
                tipoHabitacionBE.tipoHabitacionDescripcion = tipoHabitacion.Habitacion_Descripcion;
                tipoHabitacionBE.tipoHabitacionPrecio = Convert.ToSingle(tipoHabitacion.Precio);

                return tipoHabitacionBE;
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
    }
}
