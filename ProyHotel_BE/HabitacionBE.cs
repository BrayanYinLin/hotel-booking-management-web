using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_BE
{
    public class HabitacionBE
    {
        public int habitacionId { get; set; }
        public int tipoHabitacionId { get; set; }
        public byte? habitacionAforo { get; set; }
        public bool estadoHabitacion { get; set; }
        public string estadoHabitacionString { get; set; }
        public string habitacionNombre { get; set; }
        public DateTime? fechaUltModificacion { get; set; }
        public string usuarioUltModificacion { get; set; }

    }
}
