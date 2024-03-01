using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using DTOs;

namespace SistemaGestionData
{
    public class ProductoData
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS;Database=proyecto_csharp;Trusted_Connection=True;";
        private static List<Producto> productos = new List<Producto>();

        public static List<Producto> ListarProductos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int idObtenido = Convert.ToInt32(reader["id"]);
                            string descripcion = reader.GetString(1);
                            decimal costo = reader.GetDecimal(2);
                            decimal precioVenta = reader.GetDecimal(3);
                            int stock = reader.GetInt32(4);
                            int idUsuario = reader.GetInt32(5);

                            Producto productoObtenido = new Producto(idObtenido, descripcion, costo, precioVenta, stock, idUsuario);

                            productos.Add(productoObtenido);
                        }
                        return productos;
                    }
                    throw new Exception("No se encontraron registros");
                }
            }
        }

        public static Producto ObtenerProductoPorId(long id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string descripcion = reader.GetString(1);
                    decimal costo = reader.GetDecimal(2);
                    decimal precioVenta = reader.GetDecimal(3);
                    int stock = reader.GetInt32(4);
                    int idUsuario = reader.GetInt32(5);

                    Producto productoObtenido = new Producto(idObtenido, descripcion, costo, precioVenta, stock, idUsuario);

                    return productoObtenido;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public static bool AgregarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES(@descripcion, @costo, @precioVenta, @stock, @idUsuario) ";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("descripcion", producto.Descripcion);
                comando.Parameters.AddWithValue("costo", producto.Costo);
                comando.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("stock", producto.Stock);
                comando.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                return comando.ExecuteNonQuery() > 0;
            }

        }

        public static bool BorrarProductoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Producto WHERE Id = @id";
                Producto productoObtenido;
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                try
                {
                    productoObtenido = ObtenerProductoPorId(id);
                    if (productoObtenido is not null)
                    {
                        return comando.ExecuteNonQuery() > 0;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool ActualizaProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Producto SET Descripciones = @descripcion, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock, IdUsuario = @idUsuario WHERE id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", producto.Id);
                comando.Parameters.AddWithValue("descripcion", producto.Descripcion);
                comando.Parameters.AddWithValue("costo", producto.Costo);
                comando.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("stock", producto.Stock);
                comando.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                try
                {
                    return comando.ExecuteNonQuery() > 0;
                }
                catch (Exception)
                {

                    return false;
                }
                

                
            }
        }
    }
}
