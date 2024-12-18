using ProyHotel_ADO;
using ProyHotel_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_BL
{
    public class HabitacionBL
    {
        HabitacionADO habitacionADO = new HabitacionADO();

        public List<HabitacionBE> obtenerListaHabitaciones()
        {
            return habitacionADO.obtenerListaHabitaciones();
        }
        public List<HabitacionBE> obtenerListaHabitacionesPorTipo(int habitacionId)
        {
            return habitacionADO.obtenerListaHabitacionesPorTipo(habitacionId);
        }
    }
}
