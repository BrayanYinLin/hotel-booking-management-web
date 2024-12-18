using ProyHotel_BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHotel_ADO
{
    public class UsuarioADO
    {
        hotel_databaseEntities hotel = new hotel_databaseEntities();

        public List<UsuarioBE> ListarUsuarios()
        {
            try
            {
                List<UsuarioBE> listaUsuarios = new List<UsuarioBE>();

                var query = (from u in hotel.vw_usuario
                             select new
                             {
                                 u.Id,
                                 u.Usuario,
                                 u.Contraseña,
                                 u.Tipo,
                                 u.Correo,
                                 Estado = u.Estado == "Activo"
                             }).ToList();

                foreach (var u in query)
                {
                    listaUsuarios.Add(new UsuarioBE
                    {
                        usuarioId = (short)u.Id,
                        usuarioNombre = u.Usuario,
                        usuarioClave = u.Contraseña,
                        usuarioTipo = u.Tipo,
                        usuarioTipoId = 0, // Ajuste temporal: asume que Tipo es string y no se puede convertir a short
                        usuarioCorreo = u.Correo,
                        usuarioEstado = u.Estado,
                        usuarioEstadoString = u.Estado ? "Activo" : "Inactivo"
                    });
                }

                return listaUsuarios;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioBE IniciarSesion(UsuarioBE usuarioBE)
        {
            try
            {
                string username = usuarioBE.usuarioNombre;
                string password = usuarioBE.usuarioClave;

                var query = hotel.usp_ingreso_tb_usuario(username, password).ToList();

                if (!query.Any())
                {
                    throw new Exception("Usuario y/o contraseña incorrecta.");
                }

                var firstUser = query.First();
                UsuarioBE usuario = new UsuarioBE();
                usuario.usuarioId = (short)firstUser.usuario_id;
                usuario.usuarioNombre = firstUser.usuario_nombre;
                usuario.usuarioClave = firstUser.usuario_password;
                usuario.usuarioEstado = firstUser.usuario_estado;
                return usuario;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
