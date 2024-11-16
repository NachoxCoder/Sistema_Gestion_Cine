using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
     public class BE_Butaca : BE_EntidadBase
    {
        public BE_Sala Sala { get; set; }
        public string Fila { get; set; }
        public int Numero { get; set; }
        public bool Disponible { get; set; }
        public int IdSala { get; set; }

        public BE_Butaca()
        {
            Sala = new BE_Sala();
        }

        public override string ToString()
        {
            return $"Fila {Fila} - Asiento {Numero}";
        }

        public bool EstaDisponible()
        {
            return Disponible;
        }
    }
}
