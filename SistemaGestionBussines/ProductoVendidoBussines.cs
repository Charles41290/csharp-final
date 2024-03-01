using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussines
{
    public class ProductoVendidoBussines
    {
        public static List<ProductoVendido> GetAllProductsSold()
        {
            return ProductoVendidoData.ListarProductosVendidos();
        }

        public static ProductoVendido GetProductSoldById(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendidoPorId(id);
        }

        public static List<ProductoVendido> GetProductsSoldByUserId(int userId) 
        {
            //***Chequear esta parte*** -> se podría pensar en obtener los productos vendidos segun el id mediante el unión de las tablas Venta y ProductoVendido mediante Venta.Id y ProductoVendido.IdVenta -> filtro la venta según IdUsuario y luego uno esta tabla filtrada con el ProductoVendido

            // Obtengo todos los productos
            List<Producto> productos = ProductoData.ListarProductos();
            // filtramos los productos según el userId
            List<Producto> productosFiltrados = productos.Where(p => p.IdUsuario == userId).ToList();
            //creo una lista donde se almacenaran losProductos Vendidos por el usuario 
            List<ProductoVendido> resultadoFinal = new List<ProductoVendido>();
            // obtengo todos los productos vendidos
            List<ProductoVendido> productosVendidos = ProductoVendidoData.ListarProductosVendidos();
            // con este for recorro toda la lista de productos
            foreach (Producto producto in productosFiltrados)
            {
                long id = producto.Id;
                ProductoVendido? pVendido = productosVendidos.Find(p => p.IdProducto == id);
                if (pVendido is not null)
                {
                    resultadoFinal.Add(pVendido);
                }
            }
            // valido que haya productos
            if (resultadoFinal.Count > 0)
            {
                return resultadoFinal;
            }
            throw new Exception("No se encontraron productos");
            
        }

        public static bool CreateProductSold(ProductoVendido productoVendido)
        {
            return ProductoVendidoData.AgregarProductoVendido(productoVendido);
        }

        public static bool DeleteProductSoldById(int id)
        {
            return ProductoVendidoData.BorrarProductoVendidoPorId(id);
        }

        public static bool UpdateProductSoldById(int id,ProductoVendido productoVendido)
        {
            return ProductoVendidoData.ActualizarProductoVendidoPorId(id, productoVendido);
        }
    }
}
