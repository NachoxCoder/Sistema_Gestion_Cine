using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Producto : BE_Entidad
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<BE_OrdenCompra> OrdenesCompra { get; set; }
    }
}
