using ProyHotel_ADO;
using ProyHotel_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_BL
{
    public class TipoHabitacionBL
    {
        TipoHabitacionADO tipoHabitacionADO = new TipoHabitacionADO();

        public List<TipoHabitacionBE> ListarTipoHabitacion()
        {
            return tipoHabitacionADO.ListarTipoHabitacion();
        }

        public TipoHabitacionBE BuscarTipoHabitacionPorNombre(string nombre)
        {
            return tipoHabitacionADO.BuscarTipoHabitacionPorNombre(nombre);
        }
    }
}
