using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAbmc<T> where T : IEntidad
    {
        bool Guardar(T pObj);
        bool Borrar(T pObj);
        List<T> Consultar();
    }
}
