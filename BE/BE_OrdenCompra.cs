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
            Productos = new List<BE_Producto>();
        }
        public int IdProveedor { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string EstadoOrdenCompra { get; set; }
        public DateTime FechaOrdenCompra { get; set; }
        public decimal TotalOrdenCompra { get; set; }
        public virtual ICollection<BE_Producto> Productos { get; set; }
        public virtual BE_Proveedor Proveedor { get; set; }
        public virtual BE_Inventario Inventario { get; set; }
    }
}
