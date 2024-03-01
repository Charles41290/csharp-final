using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Venta
    {
        // Atributos 
        private long id;
        private string comentarios;
        private long idUsuario;

        // Getters and setters
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

        public string Comentarios
        {
            get
            {
                return this.comentarios;
            }
            set
            {
                this.comentarios = value;
            }
        }

        public long IdUsuario
        {
            get
            {
                return this.idUsuario;
            }
            set
            {
                this.idUsuario = value;
            }
        }

        // Constructores
        public Venta() { }

        public Venta(string comentarios, long idUsuario)
        {
            this.comentarios = comentarios;
            this.idUsuario = idUsuario;
        }

        public Venta(long id, string comentarios, long idUsuario) : this(comentarios, idUsuario)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return $"Venta Id: {this.Id}, Comentarios: {this.Comentarios}, Id Usuario: {this.IdUsuario}";
        }
    }
}
