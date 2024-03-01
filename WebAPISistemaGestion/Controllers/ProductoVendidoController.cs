using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;
using System.Net;

namespace WebAPISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : Controller
    {

        [HttpGet("{idUsuario}")]
        public ActionResult<List<ProductoVendido>> obtenerProductoVendidoPorIdUsuario(int idUsuario)
        {
            if (idUsuario < 0)
            {
                return base.BadRequest(new { mns = "Id inválido", status = HttpStatusCode.BadRequest });
            }
            try
            {
                return ProductoVendidoBussines.GetProductsSoldByUserId(idUsuario).ToList();
            }
            catch (Exception ex)
            {

                return base.Conflict(new { mensaje = ex.Message, status = HttpStatusCode.Conflict });
            }
            
        }

    }
}
