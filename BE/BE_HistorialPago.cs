using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_HistorialPago : BE_EntidadBase
    {
        public int IdFactura { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public string NumeroTransaccion { get; set; }
        public string Estado { get; set; }
        public virtual BE_Factura Factura { get; set; }
    }
}
