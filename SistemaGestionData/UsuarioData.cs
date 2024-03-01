using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public class UsuarioData
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS;Database=proyecto_csharp;Trusted_Connection=True;";
        private static List<Usuario> usuarios = new List<Usuario>();

        public static List<Usuario> ListarUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuario";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int idObtenido = Convert.ToInt32(reader["id"]);
                            string nombre = reader.GetString(1); // el orden del indice depende de como fueron definidos los campos en la tabla
                            string apellido = reader.GetString(2);
                            string nombreUsuario = reader.GetString(3);
                            string password = reader.GetString(4);
                            string mail = reader.GetString(5);

                            Usuario usuarioObtenido = new Usuario(idObtenido, nombre, apellido, nombreUsuario, password, mail);
                            usuarios.Add(usuarioObtenido);
                        }
                        return usuarios;
                    }
                    throw new Exception("No se encontraron usuarios");
                }
            }
        }

        public static Usuario ObtenerUsuarioPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuario WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string password = reader.GetString(4);
                    string mail = reader.GetString(5);

                    Usuario usuarioObtenido = new Usuario(idObtenido, nombre, apellido, nombreUsuario, password, mail);
                    return usuarioObtenido;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public static Usuario ObtenerUsuarioPorNombreDeUsuario(string nombreUsuario)
        {
            List<Usuario> usuarios = ListarUsuarios();
            Usuario ? usuarioBuscado = usuarios.Find(u => u.NombreUsuario == nombreUsuario);
            if(usuarioBuscado is null )
            {
                throw new Exception("Nombre de Usuario no encontrado");
            }
            return usuarioBuscado;
 
        }

        public static Usuario ObtenerUsuarioPorNombreDeUsuarioYPassword(string nombreUsuario, string password)
        {
            List<Usuario> usuarios = ListarUsuarios();
            Usuario usuarioBuscado = usuarios.Find(u => u.NombreUsuario == nombreUsuario && u.Contrasenia == password);
            if (usuarioBuscado is null)
            {
                throw new Exception("Usuario o contraseña incorrectos");
            }
            return usuarioBuscado;
        }

        public static bool AgregarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contrasenia, Mail) VALUES (@nombre, @apellido, @nombreUsuario, @contrasenia, @mail)";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("contrasenia", usuario.Contrasenia);
                comando.Parameters.AddWithValue("mail", usuario.Mail);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool BorrarUsuarioPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuario WHERE Id = @id";
                Usuario usuarioObtenido;
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                try
                {
                    usuarioObtenido = ObtenerUsuarioPorId(id);
                    if (usuarioObtenido is not null)
                    {
                        return comando.ExecuteNonQuery() > 0;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }


                //return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool ActualizarUsuarioPorId(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contrasenia = @contrasenia, Mail = @mail WHERE Id = @id ";
                Usuario usuarioObtenido;
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("contrasenia", usuario.Contrasenia);
                comando.Parameters.AddWithValue("mail", usuario.Mail);
                try
                {
                    usuarioObtenido = ObtenerUsuarioPorId(id);
                    if (usuarioObtenido is not null)
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

        public static bool ActualizarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contrasenia = @contrasenia, Mail = @mail WHERE Id = @id ";
                Usuario usuarioObtenido;
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", usuario.Id);
                comando.Parameters.AddWithValue("nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("contrasenia", usuario.Contrasenia);
                comando.Parameters.AddWithValue("mail", usuario.Mail);
                //try
                //{
                //    usuarioObtenido = ObtenerUsuarioPorId(id);
                //    if (usuarioObtenido is not null)
                //    {
                //        return comando.ExecuteNonQuery() > 0;
                //    }
                //    return false;
                //}
                //catch (Exception)
                //{
                //    return false;
                //}
                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
