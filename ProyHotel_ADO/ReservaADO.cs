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
         hotel_databaseEntities miHotel = new hotel_databaseEntities();

        //grafica
        public List<GraficoReserva> graficoReservas()
        {
            try
            {


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
        public List<ReservaBE> obtenerReservasPorDNIyFechas(String dni, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                List<ReservaBE> objReservaPorFecha = new List<ReservaBE>();

                var query = miHotel.sp_ObtenerReservasPorDNIyFechas(dni,fechaInicio,fechaFin);

                foreach (var obj in query) 
                { 
                    ReservaBE objReservaBE = new ReservaBE();
                    objReservaBE.reservaId = obj.Reserva_Id;
                    objReservaBE.nombreReserva = obj.A_Nombre_de;
                    objReservaBE.telefono = obj.Telefono;
                    objReservaBE.precio = obj.Precio;
                    objReservaBE.creadoPor = obj.Creado_por;

                    objReservaBE.fechaCreacion = obj.Fecha_Creacion ?? default(DateTime);
                    objReservaBE.estado = obj.Estado_Pago;

                    objReservaPorFecha.Add(objReservaBE);

                }



                return objReservaPorFecha;
            }
            catch (EntityException ee)
            {
                
                throw new Exception("Error Entity: " + ee);
            }
        }

    }
    
}
