using ProyHotel_BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_ADO
{
    public class HabitacionADO
    {
        hotel_databaseEntities hotel = new hotel_databaseEntities();

        public List<HabitacionBE> obtenerListaHabitaciones()
        {
            try
            {
                //Codifique
                var query = hotel.usp_listar_tb_habitacion().ToList();

                List<HabitacionBE> listaHabitaciones = query.Select(item => new HabitacionBE
                {
                    habitacionId = item.Habitacion_Id,
                    tipoHabitacionId = item.Tipo_Habitacion_Id,
                    habitacionAforo = item.Habitacion_Aforo,
                    estadoHabitacion = item.Estado_Numero,
                    habitacionNombre = item.Habitacion_Nombre,
                    fechaUltModificacion = item.Fecha_Ultima_Modificacion,
                    usuarioUltModificacion = item.Usuario_Ultima_Modificacion

                }
                ).ToList();
                return listaHabitaciones;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<HabitacionBE> obtenerListaHabitacionesPorTipo(int tipoHabitacionId)
        {
            try
            {
                //Codifique
                var query = hotel.usp_obtener_tb_habitacion_tipo_id(tipoHabitacionId).ToList();

                List<HabitacionBE> listaHabitaciones = query.Select(item => new HabitacionBE
                {
                    habitacionId = item.Habitacion_Id,
                    tipoHabitacionId = item.Tipo_Habitacion_Id,
                    habitacionAforo = item.Habitacion_Aforo,
                    estadoHabitacion = item.Estado_Numero,
                    habitacionNombre = item.Habitacion_Nombre,
                    fechaUltModificacion = item.Fecha_Ultima_Modificacion,
                    usuarioUltModificacion = item.Usuario_Ultima_Modificacion
                }
                ).ToList();

                Console.WriteLine($"Cantidad de habitaciones encontradas: {listaHabitaciones.Count}");
                foreach (var habitacion in listaHabitaciones)
                {
                    Console.WriteLine($"ID: {habitacion.habitacionId}, Nombre: {habitacion.habitacionNombre}");
                }

                return listaHabitaciones;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
