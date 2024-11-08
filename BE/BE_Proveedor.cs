using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Proveedor : BE_Entidad
    {
        public BE_Proveedor()
        {
            OrdenesCompra = new List<BE_OrdenCompra>();
        }
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string EmailProveedor { get; set; }
        public bool EstaActivo { get; set; }
        public virtual ICollection<BE_OrdenCompra> OrdenesCompra { get; set; }
    }
}
