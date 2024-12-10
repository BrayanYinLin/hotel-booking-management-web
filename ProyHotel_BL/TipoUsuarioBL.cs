using ProyHotel_ADO;
using ProyHotel_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_BL
{
    public class TipoUsuarioBL
    {
        TipoUsuarioADO tipoUsuarioADO = new TipoUsuarioADO();
        public List<TipoUsuarioBE> ListarTipoUsuario()
        {
            return tipoUsuarioADO.ListarTipoUsuario();
        }

        public TipoUsuarioBE BuscarTipoUsuarioPorNombre(string nombre)
        {
            return tipoUsuarioADO.BuscarTipoUsuarioPorNombre(nombre);
        }
    }
}
