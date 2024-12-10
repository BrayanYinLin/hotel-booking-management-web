using ProyHotel_BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_ADO
{
    public class TipoUsuarioADO
    {
        hotel_databaseEntities hotel = new hotel_databaseEntities();

        public List<TipoUsuarioBE> ListarTipoUsuario()
        {
            try
            {
                List<TipoUsuarioBE> ListaTipoUsuario = new List<TipoUsuarioBE>();

                var query = (from type in hotel.vw_tipo_usuario orderby type.Id select type).ToList();

                foreach (var typeUser in query)
                {
                    TipoUsuarioBE servicioBE = new TipoUsuarioBE();
                    servicioBE.tipoUsuarioId = typeUser.Id;
                    servicioBE.tipoUsuarioDescripcion = typeUser.Tipo_Descripcion;

                    ListaTipoUsuario.Add(servicioBE);
                }

                return ListaTipoUsuario;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoUsuarioBE BuscarTipoUsuarioPorNombre(string nombre)
        {
            try
            {
                var tipoUsuario = (from type in hotel.vw_tipo_usuario orderby type.Id select type).Where(service => service.Tipo_Descripcion == nombre).FirstOrDefault();

                TipoUsuarioBE tipoUsuarioBE = new TipoUsuarioBE();
                tipoUsuarioBE.tipoUsuarioId = tipoUsuario.Id;
                tipoUsuarioBE.tipoUsuarioDescripcion = tipoUsuario.Tipo_Descripcion;

                return tipoUsuarioBE;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
