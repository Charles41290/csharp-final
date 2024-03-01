using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class ProductoVendidoData
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS;Database=proyecto_csharp;Trusted_Connection=True;";
        private static List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductoVendido";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int idObtenido = Convert.ToInt32(reader["Id"]);
                            int stock = Convert.ToInt32(reader["Stock"]);
                            int idProducto = Convert.ToInt32(reader["IdProducto"]);
                            int idVenta = Convert.ToInt32(reader["IdVenta"]);
                            ProductoVendido producto = new ProductoVendido(idObtenido,idProducto, stock, idVenta);
                            productosVendidos.Add(producto);
                        }
                        return productosVendidos;
                    }
                    throw new Exception("No se encontraron productos vendidos");
                }

            }
        }

        public static ProductoVendido ObtenerProductoVendidoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductoVendido WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("Id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["Id"]);
                    int idProducto = Convert.ToInt32(reader["IdProducto"]);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idVenta = Convert.ToInt32(reader["IdVenta"]);
                    ProductoVendido produto = new ProductoVendido(idProducto, stock, idVenta);
                    return produto;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public static bool AgregarProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ProductoVendido(Stock, IdProducto, IdVenta) VALUES(@stock, @idProducto, @idVenta) ";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("stock", productoVendido.Stock);
                comando.Parameters.AddWithValue("idProducto", productoVendido.IdProducto);
                comando.Parameters.AddWithValue("idVenta", productoVendido.IdVenta);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool BorrarProductoVendidoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ProductoVendido WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool ActualizarProductoVendidoPorId(int id, ProductoVendido producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductoVendido SET Stock = @stock, IdProducto = @idProducto, IdVenta = @idVenta WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("stock", producto.Stock);
                comando.Parameters.AddWithValue("idProducto", producto.IdProducto);
                comando.Parameters.AddWithValue("idVenta", producto.IdVenta);
                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
