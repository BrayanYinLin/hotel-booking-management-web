using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_BE
{
    public class ReservaBE
    {
        public int reservaId { get; set; }
        public String nombreReserva { get; set; }
        public String telefono { get; set; }
        public Decimal precio { get; set; }
        public String creadoPor {  get; set; }
        public DateTime fechaCreacion  { get; set; } 
        public string estado {  get; set; }
       
       

    }
    //grafico
    public class GraficoReserva
    {
        public String periodo { get; set; }
        public Int32 cantidad_reservas { get; set; }
        public Decimal ingreso_mensual { get; set; }
    }
}
