using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Permiso : BE_Componente
    {
        public BE_Permiso(string pNombre) : base(pNombre)
        {
            EsRol = false;
        }

        public override void AgregarHijo(BE_Componente pComponente)
        {
            throw new InvalidOperationException("No se pueden agregar hijos a un permiso");
        }

        public override IList<BE_Componente> ObtenerHijos()
        {
            return new List<BE_Componente>();
        }

        public override void QuitarTodosHijos()
        {
            throw new InvalidOperationException("No se pueden quitar hijos a un permiso");
        }

        public override void RemoverHijo(BE_Componente pComponente)
        {
            throw new InvalidOperationException("No se pueden remover hijos a un permiso");

        }
    }
}
