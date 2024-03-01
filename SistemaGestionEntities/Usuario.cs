using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Usuario
    {
        // Atributos
        private long id;
        private string nombre;
        private string apellido;
        private string nombreUsuario;
        private string contrasenia;
        private string mail;

        // Getters and Setters
        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public string NombreUsuario
        {
            get
            {
                return this.nombreUsuario;
            }
            set
            {
                this.nombreUsuario = value;
            }
        }

        public string Contrasenia
        {
            get
            {
                return this.contrasenia;
            }
            set
            {
                this.contrasenia = value;
            }
        }

        public string Mail
        {
            get
            {
                return this.mail;
            }
            set
            {
                this.mail = value;
            }
        }

        // Constructores
        public Usuario()
        {

        }

        public Usuario(string nombre, string apellido, string nombreUsuario, string contrasenia, string mail)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nombreUsuario = nombreUsuario;
            this.contrasenia = contrasenia;
            this.mail = mail;
        }

        // modifico este constructor para que llame al anterior y se carge el Id
        public Usuario(long id, string nombre, string apellido, string nombreUsuario, string contrasenia, string mail) : this(nombre, apellido, nombreUsuario, contrasenia, mail)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return $"Nombre y apellido: {this.nombre} {this.apellido}, usuario: {this.nombreUsuario}, email: {this.mail} ";
        }
    }
}
