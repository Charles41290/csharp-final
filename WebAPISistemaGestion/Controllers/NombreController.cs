using Microsoft.AspNetCore.Mvc;

namespace WebAPISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NombreController : Controller
    {
        [HttpGet]
        public ActionResult<string> obtenerNombre() 
        {
            return "Carlos Romero";
        }
    
    }
}
