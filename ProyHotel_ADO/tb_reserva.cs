//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyHotel_ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_reserva()
        {
            this.tb_reserva_habitacion = new HashSet<tb_reserva_habitacion>();
            this.tb_reserva_servicio = new HashSet<tb_reserva_servicio>();
            this.tb_reserva_habitacion_huesped = new HashSet<tb_reserva_habitacion_huesped>();
        }
    
        public int reserva_id { get; set; }
        public int usuario_id { get; set; }
        public string usuario_dni { get; set; }
        public string usuario_telefono { get; set; }
        public decimal precio_total { get; set; }
        public Nullable<bool> reserva_estado { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_pago { get; set; }
        public bool estado_pago { get; set; }
        public string reserva_nombre { get; set; }
        public Nullable<int> usuario_ult_modificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_reserva_habitacion> tb_reserva_habitacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_reserva_servicio> tb_reserva_servicio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_reserva_habitacion_huesped> tb_reserva_habitacion_huesped { get; set; }
        public virtual tb_usuario tb_usuario { get; set; }
    }
}
