using DTOs;
using Mappers;
using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussines
{
    public class UsuarioBussines
    {

        // anteriormente todos los siguientes métodos eran estáticos
        public List<Usuario> GetAllUsers()
        {
            return UsuarioData.ListarUsuarios();
        }

        public Usuario GetUserById(int id)
        {
            return UsuarioData.ObtenerUsuarioPorId(id);
        }

        public Usuario GetUserByUserName(string userName) 
        {
            return UsuarioData.ObtenerUsuarioPorNombreDeUsuario(userName);               
        }

        public Usuario GetUserByUserNameAndPassword(string userName, string password)
        {
            return UsuarioData.ObtenerUsuarioPorNombreDeUsuarioYPassword(userName, password);
        }

        public bool CreateUser(UsuarioDTO usuarioDto)
        {
            Usuario usuario = UsuarioMapper.MapearAUsuario(usuarioDto);
            return UsuarioData.AgregarUsuario(usuario);
        }

        public bool DeleteUserById(int id)
        {
            return UsuarioData.BorrarUsuarioPorId(id);
        }

        public bool UpdateUserById(int id, UsuarioDTO usuarioDto)
        {
            Usuario usuario = UsuarioMapper.MapearAUsuario(usuarioDto);
            return UsuarioData.ActualizarUsuarioPorId(id, usuario);
        }

        public bool UpdateUser(Usuario usuario)
        {
            //Usuario usuario = UsuarioMapper.MapearAUsuario(usuarioDto);
            return UsuarioData.ActualizarUsuario(usuario);
        }
    }
}
