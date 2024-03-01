using DTOs;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionData;
using SistemaGestionEntities;

namespace WebAPISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioBussines usuarioService;

        // // el param usuarioService se inyecta como dependencia en Program.cs
        public UsuarioController(UsuarioBussines usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        //Traer usuario según Nombre de Usuario
        [HttpGet("{nombreUsuario}")]
        public ActionResult<Usuario> ObtenerUsuarioPoNombreDeUsuarioYPassword(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                return base.BadRequest(new { mensaje = "El nombre de usuario no puede estar vacía o contener espacios en blanco" });
            }
            try
            {
                return this.usuarioService.GetUserByUserName(nombreUsuario);
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensaje = ex.Message, status = 404 });
            }
        }


        [HttpGet("{usuario}/{password}")]
        public ActionResult<Usuario> ObtenerUsuarioPoNombreDeUsuario(string usuario, string password)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                return base.BadRequest(new { mensaje = "El nombre de usuario o contraseña no puede estar vacía o contener espacioes en blanco" });
            }
            try
            {
                return this.usuarioService.GetUserByUserNameAndPassword(usuario, password);
            }
            catch (Exception)
            {
                return BadRequest(new { mensaje = "Usuario o contraseña incorrectos", status = 404 });
            }
        }

        
        //Crear usuario
        [HttpPost]
        public ActionResult<string> AgregarUsuario([FromBody]UsuarioDTO usuarioDto)
        {
            if (this.usuarioService.CreateUser(usuarioDto))
            {
                return base.Ok(new { mensaje = "Usuario agregado", usuarioDto });
            }
            else
            {
                return base.Conflict(new { mensaje = "El usuario no pudo ser agregado" });
            }
        }

        [HttpPut]
        public ActionResult<string> ActualizarUsuario([FromBody] Usuario usuario)
        {
            if (usuario.Id > 0)
            {
                if (this.usuarioService.UpdateUser(usuario))
                {
                    return base.Ok(new { mensaje = "Usuario actualizado", status = 200 });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo actualizar el usuario" });
                }
            }
            return base.BadRequest(new { mensaje = "Id inválido", status = 404 });
        }
    }

  
}
