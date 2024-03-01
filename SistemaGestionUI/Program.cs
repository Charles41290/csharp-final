using SistemaGestionBussines;
using SistemaGestionData;
using SistemaGestionEntities;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace SistemaGestionUI
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            try
            {
                //List<Producto> productos = ProductoBussines.GetAllProductos();
                //foreach(Producto producto in productos)
                //{
                //	Console.WriteLine(producto);
                //}

                //Venta ventaAAgregar = new Venta("Todo flama", 2);
                //if(VentaData.AgregarVenta(ventaAAgregar))
                //{
                //	Console.WriteLine("Venta Agregada");
                //}

                //List<Usuario> usuarios = UsuarioBussines.GetAllUsers();
                //foreach(Usuario usuario in usuarios)
                //{
                //	Console.WriteLine(usuario);
                //}


                //List<ProductoVendido> productos = ProductoVendidoBussines.GetAllProductsSold();
                //foreach (var product in productos)
                //{
                //	Console.WriteLine(product);
                //}

                //public static Usuario ObtenerUsuarioPorNombreDeUsuarioYPassword(string nombreUsuario, string password)
                //{
                //    List<Usuario> usuarios = ListarUsuarios();
                //    Usuario? usuarioBuscado = usuarios.Find(u => u.NombreUsuario == nombreUsuario && u.Contrasenia == password);
                //    if (usuarioBuscado is null)
                //    {
                //        throw new Exception("Nombre de Usuario no encontrado");
                //    }
                //    return usuarioBuscado;
                //}

                //Usuario usuarioBuscado1 = UsuarioData.ObtenerUsuarioPorNombreDeUsuario("pedfer");
                //Console.WriteLine(usuarioBuscado1.ToString());

                //            Usuario usuarioBuscado2 = UsuarioData.ObtenerUsuarioPorNombreDeUsuarioYPassword("eperez", "12345");
                //Console.WriteLine(usuarioBuscado2.ToString());

                //            List<Usuario> usuarios = new List<Usuario>();
                //usuarios.Add(new Usuario("Charles", "Romero", "charles", "3456", "mail@gmail.com"));
                //            usuarios.Add(new Usuario("Fredy", "Romero", "fred", "3456", "mail2@gmail.com"));

                //Usuario usuarioBuscado = usuarios.Find(u => u.NombreUsuario == "charles" && u.Contrasenia == "3456");

                //if(usuarioBuscado == null)
                //{
                //                Console.WriteLine("No encontrado");
                //            }
                //else
                //{
                //                Console.WriteLine(usuarioBuscado);
                //            }


                //foreach(Usuario usuario in  usuarios)
                //{
                //	Console.WriteLine(usuario.ToString();
                //}

                // Obtengo todos los productos
                //List<Producto> productos = ProductoData.ListarProductos();
                //// filtramos los productos según el userId
                //List<Producto> productosFiltrados = productos.Where(p => p.IdUsuario == 1).ToList();

                //List<ProductoVendido> resultadoFinal = new List<ProductoVendido>();
                //// obtengo todos los productos vendidos
                //List<ProductoVendido> productosVendidos = ProductoVendidoData.ListarProductosVendidos();
                //// con este for recorro toda la lista de productos

                //foreach (Producto producto in productosFiltrados)
                //{
                //    long id = producto.Id;
                //    ProductoVendido? pVendido = productosVendidos.Find(p => p.IdProducto == id);
                //    if (pVendido is not null)
                //    {
                //        resultadoFinal.Add(pVendido);
                //    }
                //}

                //foreach (var item in productosFiltrados)
                //{
                //    Console.WriteLine(item);
                //}
                //Console.WriteLine();
                //foreach (var item in productosVendidos)
                //{
                //    Console.WriteLine(item);
                //}
                //Console.WriteLine();

                //foreach (var item in resultadoFinal)
                //{
                //    Console.WriteLine(item);
                //}

                //ProductoBussines productoService = new ProductoBussines();
                //List<Producto> productos = productoService.GetProductByUserId(2);
                //foreach (Producto producto in productos)
                //{ 
                //    Console.WriteLine(producto.ToString());
                //}

                List<Producto> productos = ProductoData.ListarProductos();
                List<string> lista = productos.Select(p => p.Descripcion).ToList();
                foreach (var item in lista) 
                { 
                    Console.WriteLine(item);
                }
            }
			catch (Exception ex)
			{

				Console.WriteLine(ex);
			}
        }
    }
}
