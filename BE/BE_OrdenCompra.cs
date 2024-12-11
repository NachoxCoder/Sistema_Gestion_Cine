using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_OrdenCompra : BE_EntidadBase
    {
        public BE_OrdenCompra()
        {
            Detalles = new List<BE_DetalleOrdenCompra>();
            FechaOrdenCompra = DateTime.Now;
        }
        public int IdProveedor { get; set; }
        public string EstadoOrdenCompra { get; set; }
        public DateTime FechaOrdenCompra { get; set; }
        public decimal TotalOrdenCompra { get; set; }
        public virtual BE_Proveedor Proveedor { get; set; }

        public List<BE_DetalleOrdenCompra> Detalles { get; set; }

        public void CalcularTotal()
        {
            TotalOrdenCompra = 0;
            foreach (var detalle in Detalles)
            {
                TotalOrdenCompra += detalle.Subtotal;
            }
        }
    }
}
