using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_BoletoFuncion : BE_EntidadBase
    {
        public int IdFuncion { get; set; }
        public int IdBoleto { get; set; }
        public DateTime FechaVenta { get; set; }
        public virtual BE_Boleto Boleto { get; set; }
        public virtual BE_Funcion Funcion { get; set; }
    }
}
