using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_BE
{
    public class HuespedBE
    {
        public Int32 huespedId { get; set; }
        public String huespedNombre { get; set; }
        public String huespedTelefono { get; set; }
        public string huespedDni { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaUltimaModificacion { get; set; }
        public String huespedCorreo {  get; set; }
        public String huespedSexo { get; set; }
        public String UsuarioUltModificacion { get; set; }
        public  Boolean huespedEstado { get; set; }
    }
}
