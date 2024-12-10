using ProyHotel_ADO;
using ProyHotel_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_BL
{
    public class UsuarioBL
    {
        UsuarioADO usuarioADO = new UsuarioADO();

        public UsuarioBE IniciarSesion(UsuarioBE usuarioBE)
        {
            return usuarioADO.IniciarSesion(usuarioBE);
        }

        public List<UsuarioBE> ListarUsuarios()
        {
            return usuarioADO.ListarUsuarios();
        }
    }
}
