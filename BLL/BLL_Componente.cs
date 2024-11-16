using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using BE;

namespace BLL
{
    public abstract class BLL_Componente : IAbmc<BE_Componente>
    {
        public abstract bool Borrar(BE_Componente oComponente);
        public abstract bool Guardar(BE_Componente oComponente);
        public abstract List<BE_Componente> Consultar();
        public abstract IList<BE_Componente> ObtenerHijos(BE_Componente oComponente);
        public abstract void AgregarHijo(BE_Componente oComponente);
    }
}
