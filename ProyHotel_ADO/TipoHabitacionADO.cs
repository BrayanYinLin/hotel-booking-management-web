using ProyHotel_BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;

namespace ProyHotel_ADO
{
    public class TipoHabitacionADO
    {
        hotel_databaseEntities hotel = new hotel_databaseEntities();

        public List<TipoHabitacionBE> ListarTiposHabitacion()
        {
            try
            {
                var query = hotel.usp_listar_tb_tipo_habitacion().ToList();

                return query.Select(item => new TipoHabitacionBE
                {
                    tipoHabitacionId = item.tipo_habitacion_id,
                    tipoHabitacionDescripcion = item.tipo_habitacion_descripcion,
                    costoNoche = item.costo_noche
                }).ToList();
            }
            catch (EntityException ex)
            {
                throw new Exception("Error al listar tipos de habitación: " + ex.Message);
            }
        }
    }
}
