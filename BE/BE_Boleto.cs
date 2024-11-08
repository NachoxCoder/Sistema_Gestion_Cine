using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Boleto : BE_Entidad
    {
        public int IdBoleto { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncion { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Precio { get; set; }
        public string Puesto { get; set; }
        public virtual BE_Cliente Cliente { get; set; }
        public virtual BE_Funcion Funcion { get; set; }
    }
}
