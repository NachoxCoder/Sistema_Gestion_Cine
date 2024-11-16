using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Sala : BE_EntidadBase
    {
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public bool Tiene3D { get; set; }
        public virtual ICollection<BE_Funcion> Funciones { get; set; }

        public BE_Sala()
        {
            Funciones = new List<BE_Funcion>();
        }
    }
}
