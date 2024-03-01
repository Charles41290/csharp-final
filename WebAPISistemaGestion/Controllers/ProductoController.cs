using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;
using DTOs;

namespace WebAPISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private ProductoBussines productoService;

        // el param productService se inyecta como dependencia en Program.cs
        public ProductoController(ProductoBussines productoService)
        {
            this.productoService = productoService;
        }

        //Obtiene el producto según el idUsuario
        [HttpGet("{idUsuario}")]
         public ActionResult<List<Producto>> ObtenerProductoPorId(int idUsuario)
        {
            try
            {
                return this.productoService.GetProductByUserId(idUsuario);
            }
            catch (Exception)
            {
                return BadRequest(new { mensaje = "Id de usuario no encontrado", status = 404});
            }
        }

        [HttpPost]
        public IActionResult AgregarProducto([FromBody] Producto producto)
        {
            if(producto.Stock <= 0)
            {
                return base.Conflict(new { mensaje = "El stock tiene que ser mayor a 0" });
            }
            if (this.productoService.CreateProduct(producto))
            {
                return base.Ok(new { mensaje = "Producto agregado", producto});
            }
            else
            {
                return base.Conflict(new { mensaje = "El producto no pudo ser agregado. Verificar IdUsuario" });
            }
        }


        [HttpDelete("{idProducto}")]
        public IActionResult BorradProducto(int idProducto)
        {
            if (idProducto > 0)
            {
                if (this.productoService.DeleteProductById(idProducto))
                {
                    return base.Ok(new { mensaje = "Producto eliminado", status = 200 });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo eliminar el producto" });
                }
            }
            return base.BadRequest(new { mensaje = "Id inválido", status = 404 });
        }

        [HttpPut]
        public IActionResult ActualizarProductoPorId([FromBody] Producto producto)
        {
            if (producto.Stock <= 0)
            {
                return base.Conflict(new { mensaje = "El stock tiene que ser mayor a 0" });
            }
            if (producto.Id > 0)
            {
                if (this.productoService.UpdateProduct(producto))
                {
                    return base.Ok(new { mensaje = "Producto actualizado", status = 200 });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo actualizar el producto. Conflicto en Id o IdUsuario" });
                }
            }
             return base.BadRequest(new { mensaje = "Id inválido", status = 404 });
        }
    }
}

