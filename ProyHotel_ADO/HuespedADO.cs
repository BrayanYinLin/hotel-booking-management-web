﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProyHotel_BE;

namespace ProyHotel_ADO
{
    public class HuespedADO
    {
        hotel_databaseEntities hotel = new hotel_databaseEntities();

        public List<HuespedBE> listarHuespedes()
        {
            try
            {
                List<HuespedBE> listaHuespedes = new List<HuespedBE>();
                
                var query = (from huesped in hotel.vw_huesped orderby huesped.Id select huesped).ToList();

                foreach (var huesped in query)
                {
                    HuespedBE huespedBE = new HuespedBE();
                    huespedBE.huespedId = huesped.Id;
                    huespedBE.huespedNombre = huesped.Nombre;
                    huespedBE.huespedTelefono = huesped.Telefono;
                    huespedBE.huespedDni = huesped.DNI;
                    huespedBE.huespedCorreo = huesped.Correo;
                    huespedBE.huespedSexo = huesped.Sexo;



                    listaHuespedes.Add(huespedBE);

                }

                return listaHuespedes;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public HuespedBE BuscarHuespedPorNombre(string nombre)
        {
            try
            {
                var huespedB = (from huesped in hotel.vw_huesped orderby huesped.Id select huesped).Where(huesped => huesped.Nombre.Contains(nombre)).FirstOrDefault();
                
                HuespedBE huespedBE = new HuespedBE();
                huespedBE.huespedId = huespedB.Id;
                huespedBE.huespedNombre = huespedB.Nombre;
                huespedBE.huespedTelefono = huespedB.Telefono;
                huespedBE.huespedDni = huespedB.DNI;
                huespedBE.huespedCorreo = huespedB.Correo;
                huespedBE.huespedSexo = huespedB.Sexo;

                return huespedBE;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<GraficoMensual> ObtenerEstadisticasPorMesHuesped()
        {
            try
            {

                hotel_databaseEntities miHotel = new hotel_databaseEntities();

                List<GraficoMensual> objObtenerEstadisticasPorMesHuesped = new List<GraficoMensual>();

                var query = miHotel.sp_ObtenerEstadisticasPorMesHuesped();

                foreach (var resultado in query)
                {
                    GraficoMensual objGraficoMensual = new GraficoMensual();
                    objGraficoMensual.TotalHuespedes = Convert.ToInt16(resultado.TotalHuespedes);
                    objGraficoMensual.MesCreacion = Convert.ToInt32(resultado.MesCreacion);
                    objGraficoMensual.TotalMasculinos = Convert.ToInt16(resultado.TotalMasculinos);
                    objGraficoMensual.TotalFemeninos = Convert.ToInt16(resultado.TotalFemeninos);

                    objObtenerEstadisticasPorMesHuesped.Add(objGraficoMensual);

                }
                return objObtenerEstadisticasPorMesHuesped;
            }
            catch (EntityException ex)
            {
                throw new Exception("Error en el listado:" + ex.Message);
            }
        }
    }
}
