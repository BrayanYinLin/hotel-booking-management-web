using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyHotel_BE;
using ProyHotel_ADO;
namespace ProyHotel_BL
{
    public class ReservaBL
    {
        ReservaADO reservaADO = new ReservaADO();

        //grafico
        public List<GraficoReserva> graficoReservas()
        {
            return reservaADO.graficoReservas();
        }

    }
}
