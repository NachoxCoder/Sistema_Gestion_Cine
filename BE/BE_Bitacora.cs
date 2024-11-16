using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Bitacora : BE_EntidadBase
    {
        public DateTime Fecha { get; set; }
        public string Evento { get; set; }
        public BE_Empleado UsuarioEmpleado { get; set; }

        public BE_Bitacora()
        {
            Fecha = DateTime.Now;
            Evento = string.Empty;
        }
        public BE_Bitacora(DateTime fecha, string evento, BE_Empleado usuarioEmpleado)
        {
            Fecha = fecha;
            Evento = evento;
            UsuarioEmpleado = usuarioEmpleado;
        }

        public override string ToString()
        {
            return $"[{Fecha:dd/MM/yyyy HH:mm:ss}] - {Evento} - {UsuarioEmpleado}";
        }

        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            return false;

            BE_Bitacora otra = (BE_Bitacora)obj;
            return ID == otra.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID,Fecha,Evento);
        }
    }
}
