using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BE
{
    public class BE_Pelicula : BE_EntidadBase
    {
        public BE_Pelicula()
        {
            Funciones = new List<BE_Funcion>();
            EstaActiva = true;
        }
        //Propiedades de la clase
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public int Duracion { get; set; }
        public string Rating { get; set; }
        public bool EstaActiva { get; set; }
        public virtual ICollection<BE_Funcion> Funciones { get; set; }
    }
}
