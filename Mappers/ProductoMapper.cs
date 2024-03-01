using DTOs;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public class ProductoMapper
    {
        public static Producto MapearAProducto(ProductoDTO productoDTO) 
        {
            Producto producto = new Producto();
            producto.Descripcion = productoDTO.Descripcion;
            producto.Costo = productoDTO.Costo;
            producto.PrecioVenta = productoDTO.PrecioVenta;
            producto.Stock = productoDTO.Stock;
            producto.IdUsuario = productoDTO.IdUsuario;
            return producto;
        }

        public static ProductoDTO MapearADto(Producto producto) 
        {
            ProductoDTO productoDTO = new ProductoDTO();
            productoDTO.Descripcion = producto.Descripcion;
            productoDTO.Costo = producto.Costo;
            productoDTO.PrecioVenta = producto.PrecioVenta;
            productoDTO.Stock = producto.Stock;
            productoDTO.IdUsuario = producto.IdUsuario;
            return productoDTO;
        }
    }
}
