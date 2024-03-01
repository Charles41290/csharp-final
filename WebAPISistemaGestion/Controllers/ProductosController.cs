using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;

namespace WebAPISistemaGestion.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private ProductoBussines2 productoService;

        public ProductosController(ProductoBussines2 productoService) 
        {
            this.productoService = productoService;
        }

        public List<Producto> obtenerListadoProductos()
        {
            return this.productoService.GetAllProductos();
        }

 
    }
}
