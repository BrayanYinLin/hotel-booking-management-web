using ProyHotel_ADO;
using ProyHotel_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_BL
{
    public class ServicioBL
    {
        ServicioADO servicioADO = new ServicioADO();

        public List<ServicioBE> ListarServicio()
        {
            return servicioADO.ListarServicio();
        }

        public ServicioBE BuscarServicioPorNombre(string nombre)
        {
            return servicioADO.BuscarServicioPorNombre(nombre);
        }

        public List<ServicioGrafico> ListarServicioGrafico()
        {
            return servicioADO.ListarServicioGrafico();
        }
    }
}
