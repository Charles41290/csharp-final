using DTOs;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public class UsuarioMapper
    {
        public static Usuario MapearAUsuario(UsuarioDTO usuarioDto) 
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = usuarioDto.Nombre;
            usuario.Apellido = usuarioDto.Apellido;
            usuario.NombreUsuario = usuarioDto.NombreUsuario;
            usuario.Contrasenia = usuarioDto.Contrasenia;
            usuario.Mail = usuarioDto.Mail;
            return usuario;
        }

        public static UsuarioDTO MapearADTO(Usuario usuario)
        {
            UsuarioDTO usuarioDto = new UsuarioDTO();
            usuarioDto.Nombre = usuario.Nombre;
            usuarioDto.Apellido = usuario.Apellido;
            usuarioDto.NombreUsuario = usuario.NombreUsuario;
            usuarioDto.Contrasenia = usuario.Contrasenia;
            usuarioDto.Mail = usuario.Mail;
            return usuarioDto;
        }
    }
}
