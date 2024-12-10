using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyHotel_BE;
using ProyHotel_ADO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ProyHotel_BL
{
    public class HuespedBL
    {
        HuespedADO huespedADO = new HuespedADO();

        public List<HuespedBE> listarHuespedes()
        {
            return huespedADO.listarHuespedes();
        }

        public HuespedBE BuscarHuespedPorNombre(String nombre)
        {
            return huespedADO.BuscarHuespedPorNombre(nombre);
        }

    }
}
