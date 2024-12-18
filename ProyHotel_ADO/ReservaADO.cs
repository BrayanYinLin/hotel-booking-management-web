using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProyHotel_BE;

namespace ProyHotel_ADO
{
    public class ReservaADO
    {



        //grafica
        public List<GraficoReserva> graficoReservas()
        {
            try
            {

                hotel_databaseEntities miHotel = new hotel_databaseEntities();

                List<GraficoReserva> objGraficoReservas = new List<GraficoReserva>();

                var query = miHotel.sp_graficoReservas();

                foreach (var resultado in query)
                {
                    GraficoReserva objDatoGraficoMensual = new GraficoReserva();
                    objDatoGraficoMensual.periodo = resultado.periodo;
                    objDatoGraficoMensual.cantidad_reservas = Convert.ToInt32(resultado.cantidad_reservas);
                    objDatoGraficoMensual.ingreso_mensual = Convert.ToDecimal(resultado.ingreso_mensual);

                    objGraficoReservas.Add(objDatoGraficoMensual);

                }
                return objGraficoReservas;
            }
            catch (EntityException ex)
            {
                throw new Exception("Error en el listado:" + ex.Message);
            }
        }

    }
    
}
