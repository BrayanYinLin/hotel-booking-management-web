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
    
    public partial class usp_obtener_tb_reserva_servicio_id_Result
    {
        public int reserva_id { get; set; }
        public int servicio_id { get; set; }
        public string servicio_descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal servicio_precio { get; set; }
        public decimal precio_total { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_ult_modificacion { get; set; }
    }
}