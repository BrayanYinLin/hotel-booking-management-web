using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_BE
{
    public class ServicioBE
    {
        public int servicioId { get; set; }
        public string servicioDescripcion { get; set; }
        public float servicioPrecio { get; set; }
        public DateTime servicioFechaCreacion { get; set; }
        public string servicioEstado { get; set; }
        public bool servicioEstadoBoolean { get; set; }

        public ServicioBE(int servicioId, string servicioDescripcion, float servicioPrecio, DateTime servicioFechaCreacion, bool servicioEstado)
        {
            this.servicioId = servicioId;
            this.servicioDescripcion = servicioDescripcion;
            this.servicioPrecio = servicioPrecio;
            this.servicioFechaCreacion = servicioFechaCreacion;
            this.servicioEstadoBoolean = servicioEstado;
        }

        public ServicioBE(string servicioDescripcion, float servicioPrecio, bool servicioEstado)
        {
            this.servicioDescripcion = servicioDescripcion;
            this.servicioPrecio = servicioPrecio;
            this.servicioEstadoBoolean = servicioEstado;
        }

        public ServicioBE(int servicioId, string servicioDescripcion, float servicioPrecio, bool servicioEstado)
        {
            this.servicioId = servicioId;
            this.servicioDescripcion = servicioDescripcion;
            this.servicioPrecio = servicioPrecio;
            this.servicioEstadoBoolean = servicioEstado;
        }

        public ServicioBE()
        {
        }
    }

    public class ServicioReservaBE : ServicioBE
    {
        public int reservaId { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaModificacion { get; set; }
        public double precioTotal { get; set; }

        
    }

    public class ServicioGrafico
    {
        public string periodo { get; set; }
        public int cantidad { get; set; }
        public double ingresoMensual { get; set; }
    }
}
