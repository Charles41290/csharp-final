using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class ProductoVendido
    {
        // Atributos
        private long id;
        private long idProducto;
        private int stock;
        private long idVenta;

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

        public long IdProducto
        {
            get
            {
                return this.idProducto;
            }
            set
            {
                this.idProducto = value;
            }
        }

        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                this.stock = value;
            }
        }

        public long IdVenta
        {
            get
            {
                return this.idVenta;
            }
            set
            {
                this.idVenta = value;
            }
        }

        // Constructores
        public ProductoVendido()
        {

        }

        public ProductoVendido(long idProducto, int stock, long idVenta)
        {
            this.idProducto = idProducto;
            this.stock = stock;
            this.idVenta = idVenta;
        }

        public ProductoVendido(long id, long idProducto, int stock, long idVenta) : this(idProducto, stock, idVenta)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return $"Id: {this.Id}, Stock: {this.Stock}, Id Venta: {this.IdVenta}, IdProducto :{this.IdProducto}";
        }
    }
}
