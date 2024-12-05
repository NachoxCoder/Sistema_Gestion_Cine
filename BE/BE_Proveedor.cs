using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Proveedor : BE_EntidadBase
    {
        public BE_Proveedor()
        {
            OrdenesCompra = new List<BE_OrdenCompra>();
            EstaActivo = true;
        }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string DireccionProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string EmailProveedor { get; set; }
        public bool EstaActivo { get; set; }
        public virtual ICollection<BE_OrdenCompra> OrdenesCompra { get; set; }

        public override string ToString()
        {
            return $"{RazonSocial} ({CUIT})";
        }   
    }
}
