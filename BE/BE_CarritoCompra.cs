using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_CarritoCompra : BE_EntidadBase
    {
        public BE_CarritoCompra()
        {
            Items = new List<BE_ItemCarrito>();
            FechaCreacion = DateTime.Now;
        }

        public int IdCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<BE_ItemCarrito> Items { get; set; }
        public decimal Total { get; set; }
        public virtual BE_Cliente Cliente { get; set; }
    }
}
