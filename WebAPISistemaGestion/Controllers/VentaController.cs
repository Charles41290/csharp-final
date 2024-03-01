using DTOs;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionData;
using SistemaGestionEntities;

namespace WebAPISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private VentaBussines ventaService;

        public VentaController()
        {
            this.ventaService = new VentaBussines();
        }

        [HttpGet("{idUsuario}")]
        public List<Venta> ObtenerVentaPorIdUsuario(int idUsuario)
        {
            try
            {
                return VentaBussines.GetSalesByUserId(idUsuario);
            }
            catch (Exception)
            {
                return new List<Venta>() { };
            }
        }

        // tendría que recibir como param una lista de los productos correspondiente a la venta -> el listado de productos se procesará en el VentaBussines
        [HttpPost("{idUsuario}")]
        public ActionResult<string> CrearVenta(int idUsuario, [FromBody] List<Producto> productos)
        {
            if (this.ventaService.CreateSaleFront(idUsuario, productos))
            {
                return base.Ok(new { mensaje = "Venta agregada"});
            }
            else
            {
                return base.Conflict(new { mensaje = "La venta no pudo ser agregada." });
            }
        }

    }
}
