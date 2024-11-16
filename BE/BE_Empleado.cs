using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Empleado : BE_EntidadBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Area { get; set; }

        public List<BE_Componente> listaPermisos { get; set; }

        public BE_Empleado() 
        {
            listaPermisos = new List<BE_Componente>();
        }

        public BE_Empleado(int id, string nombreUsuario, string password, string nombre, string apellido, string area)
        {
            NombreUsuario = nombreUsuario;
            Password = password;
            Nombre = nombre;
            Apellido = apellido;
            Area = area;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} - {Area}";
        }

        public bool TienePermiso(string permiso)
        {
            foreach (BE_Componente componente in listaPermisos)
            {
                if (componente.Nombre == permiso)
                    return true;
                if (componente is BE_Rol rol)
                {
                    foreach (BE_Componente permiso in rol.ObtenerHijos())
                    {
                        if (permiso.Nombre == permiso)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
