using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Membresia : BE_EntidadBase
    {
        public int IdCliente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal CostoMensual { get; set; }
        public TipoMembresia Tipo { get; set; }
        public bool EstaActiva { get; set; }
        public virtual BE_Cliente Cliente { get; set; }
    }

    public enum TipoMembresia
    {
        Plata,
        Oro,
        Premium
    }
}
