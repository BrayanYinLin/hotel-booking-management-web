//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hotel_booking_management
{
    using System;
    
    public partial class usp_obtener_tb_reserva_habitacion_id_Result
    {
        public int reserva_id { get; set; }
        public int habitacion_id { get; set; }
        public string tipo_habitacion_descripcion { get; set; }
        public string habitacion_nombre { get; set; }
        public decimal costo_noche { get; set; }
        public System.DateTime fecha_checkin { get; set; }
        public System.DateTime fecha_checkout { get; set; }
        public Nullable<decimal> precio_estadia { get; set; }
    }
}
