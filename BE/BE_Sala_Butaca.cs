using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Sala_Butaca : BE_EntidadBase
    {
        public int IdSala { get; set; }
        public int IdButaca { get; set; }
        public string Ubicacion { get; set; }
        public bool Ocupada { get; set; }
        public bool Activa { get; set; }
        public virtual BE_Sala Sala { get; set; }
        public virtual BE_Butaca Butaca { get; set; }

        public BE_Sala_Butaca()
        {
            Sala = new BE_Sala();
            Butaca = new BE_Butaca();
            Activa = true;
        }

        public override string ToString()
        {
            return $"Sala: {Sala?.Nombre} - Butaca: {Butaca?.Fila}{Butaca?.Numero}";
        }
    }
}
