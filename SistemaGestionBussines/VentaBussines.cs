using DTOs;
using Mappers;
using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussines
{
    public class VentaBussines 
    {
        private ProductoBussines productoService;

        public VentaBussines() 
        {
            this.productoService = new ProductoBussines();
        }

        public static List<Venta> GetAllSales()
        {
            return VentaData.ListarVentas();
        }

        public static Venta GetSaleById(int id)
        {
            return VentaData.ObtenerVentaPorId(id);
        }

        public static List<Venta> GetSalesByUserId(int idUsuario)
        {
            return VentaData.ObtenerVentasPorIdUsuario(idUsuario);
        }

        public bool CreateSaleFront(int idUsuario, List<Producto> productosSeleccionados)
        {
            // creo una nueva venta
            Venta venta = new Venta();
            // creo una lista con todas las descripciones 
            List<string> nombreDeProductos = productosSeleccionados.Select(p => p.Descripcion).ToList();
            string comentarios = string.Join("-", nombreDeProductos);
            venta.Comentarios = comentarios;
            venta.IdUsuario = idUsuario;

            try
            {
                // almaceno la venta en la base de datos
                VentaData.AgregarVenta(venta);

                //necesito obtener el id de la venta cargada
                List<Venta> ventas = VentaData.ListarVentas();
                Venta ultimaVenta = ventas.Last();

                // agrego cada uno de los productos a ProductoVendido
                this.AgregarAProductosVendidos(productosSeleccionados, ultimaVenta.Id);

                // descuento el stock
                this.DescontarStockDeProductos(productosSeleccionados);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AgregarAProductosVendidos(List<Producto> productos, long idVenta)
        {
            productos.ForEach(p =>
            {
                // por cada producto en la lista creo un producto vendido
                ProductoVendido productoVendido = new ProductoVendido();
                productoVendido.IdProducto = p.Id;
                productoVendido.IdVenta = idVenta;
                productoVendido.Stock = p.Stock;

                ProductoVendidoData.AgregarProductoVendido(productoVendido);
            });
        }

        public void DescontarStockDeProductos(List<Producto> productosSeleccionados) 
        {
            foreach (var productoSeleccionado in productosSeleccionados)
            {
                Producto productoActual = ProductoData.ObtenerProductoPorId(productoSeleccionado.Id);
                productoActual.Stock -= productoSeleccionado.Stock;
                productoService.UpdateProduct(productoActual);
            }
        }

        public static bool DeleteSaleById(int id)
        {
            return VentaData.BorrarVentaPorId(id);
        }

        public static bool UpdateSaleById(int id, VentaDTO ventaDto)
        {
            Venta venta = VentaMapper.MapearAVenta(ventaDto);
            return VentaData.ActualizarVentaPorId(id, venta);
        }
    }
}
