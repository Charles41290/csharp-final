using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class VentaDTO
    {
        // Atributos
        private string comentarios;
        private long idUsuario;

        // Getters and setters

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
    }
}
