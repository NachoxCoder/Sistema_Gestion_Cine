using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaces;
using Mappers;

namespace BLL
{
    public class BLL_Permiso : BLL_Componente, IAbmc<BE_Componente>
    {
        private readonly MapperPermiso mapperPermiso;

        public BLL_Permiso()
        {
            mapperPermiso = new MapperPermiso();
        }

        public override void AgregarHijo(BE_Componente oComponente)
        {
            throw new NotImplementedException();
        }

        public override bool Borrar(BE_Componente oComponente)
        {
            return mapperPermiso.Borrar(oComponente);
        }

        public override List<BE_Componente> Consultar()
        {
            throw new NotImplementedException();
        }

        public override bool Guardar(BE_Componente oComponente)
        {
            return mapperPermiso.Guardar(oComponente);
        }

        public List<BE_Componente> ListarPermisosIndividuales()
        {
            return mapperPermiso.ListarPermisosIndividuales();
        }

        public override IList<BE_Componente> ObtenerHijos(BE_Componente oBEComponente)
        {
            throw new NotImplementedException();
        }

        public List<BE_Componente> ListarPermisosUsuario(BE_Empleado oBEEmpleado)
        {
            return mapperPermiso.ListarPermisosUsuario(oBEEmpleado);
        }
        public bool AsignarPermisoUsuario(BE_Empleado oBEEmpleado, BE_Componente oBEPermiso)
        {
            return mapperPermiso.AsignarPermisoUsuario(oBEEmpleado, oBEPermiso);
        }
        public bool BorrarPermisoUsuario(BE_Empleado oBEEmpleado, BE_Componente oBEComponente)
        {
            return mapperPermiso.BorrarPermisoUsuario(oBEEmpleado, oBEComponente);
        }

        public bool AsignarPermisoARol(BE_Rol rol, BE_Permiso permiso)
        {
            return mapperPermiso.AsignarPermisoARol(rol, permiso);
        }

        public bool EliminarPermisodeRol(BE_Rol rol, BE_Permiso permiso)
        {
            return mapperPermiso.EliminarPermisodeRol(rol, permiso);
        }
    }
}
