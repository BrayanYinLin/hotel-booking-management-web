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

        public List<HuespedBE> BuscarHuespedPorNombre(string nombre)
        {
            try
            {
                var query = (from huesped in hotel.vw_huesped
                             where huesped.Nombre.Contains(nombre)
                             orderby huesped.Id
                             select huesped).ToList();

                List<HuespedBE> listaHuespedes = new List<HuespedBE>();
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
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
