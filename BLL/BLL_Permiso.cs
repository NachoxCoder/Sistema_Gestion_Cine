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

        public override IList<BE_Componente> ObtenerHijos(BE_Componente componente)
        {
            throw new NotImplementedException();
        }

        public List<BE_Componente> ListarPermisosUsuario(BE_Empleado empleado)
        {
            return mapperPermiso.ListarPermisosUsuario(empleado);
        }
        public bool AsignarPermisoUsuario(BE_Empleado empleado, BE_Componente permiso)
        {
            return mapperPermiso.AsignarPermisoUsuario(empleado, permiso);
        }
        public bool BorrarPermisoUsuario(BE_Empleado empleado, BE_Componente componente)
        {
            return mapperPermiso.BorrarPermisoUsuario(empleado, componente);
        }

        public bool AsignarPermisoARol(BE_Rol rol, BE_Permiso permiso)
        {
            return mapperPermiso.AsignarPermisoARol(rol, permiso);
        }

        public bool EliminarPermisoDeRol(BE_Rol rol, BE_Permiso permiso)
        {
            return mapperPermiso.EliminarPermisodeRol(rol, permiso);
        }

        public List<BE_Componente> ListarRoles()
        {
            return mapperPermiso.ListarRoles();
        }

        public bool AsignarRolAUsuario(BE_Empleado empleado, BE_Rol rol)
        {
            try
            {
                if(empleado == null || rol == null)
                    throw new ArgumentNullException("El empleado o el rol no pueden ser nulos");

                //Verificarsi el usuarioa ya tiene el rol asignado
                var permisosUsuario = ListarPermisosUsuario(empleado);
                if (permisosUsuario.Any(p => p.ID == rol.ID))
                {
                    throw new Exception($"El usuario {empleado.Nombre} ya tiene asignado el rol {rol.Nombre}");
                }

                return mapperPermiso.AsignarRolAUsuario(empleado, rol);
            }
            catch (Exception ex)
            {

                throw new Exception ($"Error al asignar el rol al usuario: {ex.Message}", ex);
            }
        }

        public bool RemoverRolDeUsuario(BE_Empleado empleado, BE_Rol rol)
        {
            try
            {
                if (empleado == null || rol == null)
                    throw new ArgumentNullException("El empleado o el rol no pueden ser nulos");

                //Verificar si el usuario tiene el rol asignado
                var permisosUsuario = ListarPermisosUsuario(empleado);
                if (!permisosUsuario.Any(p => p.ID == rol.ID))
                {
                    throw new Exception($"El usuario {empleado.Nombre} no tiene asignado el rol {rol.Nombre}");
                }

                return mapperPermiso.RemoverRolDeUsuario(empleado, rol);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al remover el rol del usuario: {ex.Message}", ex);
            }
        }
    }
}
