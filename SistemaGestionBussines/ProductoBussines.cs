using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionData;
using DTOs;
using Mappers;

namespace SistemaGestionBussines
{
    public class ProductoBussines
    {
        public List<Producto> GetAllProductos()
        {
            return ProductoData.ListarProductos();
        }

        public Producto GetProductById(int id)
        {
            return ProductoData.ObtenerProductoPorId(id);
        }

        public List<Producto> GetProductByUserId(int idUsuario)
        {
            List <Producto> productos = ProductoData.ListarProductos();
            List<Producto> productosObtenidos = new List<Producto>();
            if (idUsuario>0)
            {
                foreach (Producto producto in productos)
                {
                    if (producto.IdUsuario == idUsuario)
                    {
                        productosObtenidos.Add(producto);
                    }
                }
                return productosObtenidos;
            }
            throw new Exception();
        }

        public bool CreateProduct(Producto producto)
        {
            try
            {
                return ProductoData.AgregarProducto(producto);
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool DeleteProductById(int id) 
        {
            
            return ProductoData.BorrarProductoPorId(id);
          
            
        }

        public bool UpdateProduct(Producto producto)
        {
            return ProductoData.ActualizaProducto(producto);
            
        }
    }
}
