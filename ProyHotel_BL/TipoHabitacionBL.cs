using ProyHotel_ADO;
using ProyHotel_BE;
using System.Collections.Generic;

namespace ProyHotel_BL
{
    public class TipoHabitacionBL
    {
        TipoHabitacionADO tipoHabitacionADO = new TipoHabitacionADO();

        public List<TipoHabitacionBE> ListarTiposHabitacion()
        {
            return tipoHabitacionADO.ListarTiposHabitacion();
        }
    }
}
