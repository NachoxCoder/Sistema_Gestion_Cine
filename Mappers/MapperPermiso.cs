using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaces;
using System.Xml.Linq;

namespace Mappers
{
    public class MapperPermiso : IAbmc<BE_Componente>
    {
        const string archivoPermiso = @".\DATA\Permiso.xml";
        const string archivoPermiso2 = @".\DATA\Permiso_Permiso.xml";
        const string archivoEmpleadoPermiso = @".\DATA\Empleado_Permiso.xml";

        public bool Borrar(BE_Componente pComponente)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoPermiso);

                var query = from e in docXML.Descendants("Permiso")
                            where int.Parse(e.Attribute("PermisoId").Value) == pComponente.ID
                            select e;

                query.Remove();
                docXML.Save(archivoPermiso);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Componente pComponente)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoPermiso);

                if (pComponente.ID == 0)
                {
                    pComponente.ID = GenerarNuevoId();
                    docXML.Element("Permiso").Add(new XElement("Permiso",
                        new XAttribute("PermisoId", pComponente.ID),
                        new XElement("Nombre", pComponente.Nombre),
                        new XElement("Rol", pComponente.EsRol.ToString())));
                }
                else
                {
                    var permiso = docXML.Descendants("Permiso").
                        FirstOrDefault(x => int.Parse(x.Attribute("PermisoId").Value) == pComponente.ID);

                    if (permiso != null)
                    {
                        permiso.Element("Nombre").Value = pComponente.Nombre;
                        new XElement("Rol", pComponente.EsRol.ToString());
                    }
                }

                docXML.Save(archivoPermiso);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Componente> Consultar()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Componente> ListarRoles()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoPermiso);
                XDocument docXML2 = XDocument.Load(archivoPermiso2);
                List<BE_Componente> listaRoles = new List<BE_Componente>();
                List<BE_Componente> listaPermisos = new List<BE_Componente>();

                var permisoQuery = from r in docXML.Descendants("Permiso")
                              select r;

                foreach (XElement r in permisoQuery)
                {
                    if ((bool)r.Element("Rol") == true)
                    {
                        BE_Componente rol = new BE_Rol(
                            pNombre: r.Element("Nombre").Value
                            );
                        rol.ID = int.Parse(r.Attribute("PermisoId").Value);
                        listaRoles.Add(rol);
                    }
                    else
                    {
                        BE_Componente permisoComponent = new BE_Permiso(
                            pNombre: r.Element("Nombre").Value
                            );
                        permisoComponent.ID = int.Parse(r.Attribute("PermisoId").Value);
                        listaPermisos.Add(permisoComponent);
                    }
                }

                foreach (BE_Componente rol in listaRoles)
                {
                    var rolperm = from rp in docXML2.Descendants("Permiso_Permiso")
                                  where int.Parse(rp.Element("PermisoPadreId").Value) == rol.ID
                                  select int.Parse(rp.Element("PermisoHijoId").Value);
                    foreach (int rp in rolperm)
                    {
                        rol.AgregarHijo(listaPermisos.Find(x => x.ID == rp));
                    }
                }

                return listaRoles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Componente> ListarPermisosIndividuales()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoPermiso);
                List<BE_Componente> listaPermisos = new List<BE_Componente>();

                var permisos = from r in docXML.Descendants("Permiso")
                               where (bool)r.Element("Rol") == false
                               select r;

                foreach (XElement r in permisos)
                {
                    BE_Componente BEPermiso = new BE_Permiso(
                        pNombre: r.Element("Nombre").Value
                        );
                    BEPermiso.ID = int.Parse(r.Attribute("PermisoId").Value);
                    listaPermisos.Add(BEPermiso);
                }

                return listaPermisos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Componente> ListarPermisosUsuario(BE_Empleado oBEEmpleado)
        {
            try
            {
                List<BE_Componente> listaPermisos = ListarRoles();
                XDocument docXML = XDocument.Load(archivoEmpleadoPermiso);

                var query = from p in docXML.Descendants("Empleado_Permiso")
                            where int.Parse(p.Element("EmpleadoId").Value) == oBEEmpleado.ID
                            select int.Parse(p.Element("PermisoId").Value);
                List<BE_Componente> listaPermisosUsuario = new List<BE_Componente>();
                foreach (int Idp in query)
                {
                    if (listaPermisos.Exists(x => x.ID == Idp))
                    {
                        listaPermisosUsuario.Add(listaPermisos.Find(x => x.ID == Idp));
                    }
                    else
                    {
                        foreach (BE_Componente c in listaPermisos)
                        {
                            if (c.ObtenerHijos().ToList().Exists(x => x.ID == Idp) && !listaPermisosUsuario.Exists(x => x.ID == Idp))
                            {
                                listaPermisosUsuario.Add(c.ObtenerHijos().First(x => x.ID == Idp));
                            }
                        }
                    }
                }
                return listaPermisosUsuario;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al listar los permisos del usuario", ex);
            }
        }

        public bool AsignarPermisoUsuario(BE_Empleado oBEEmpleado, BE_Componente oBEPermiso)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoEmpleadoPermiso);
                docXML.Element("Empleado_Permisos").Add(new XElement("Empleado_Permiso",
                        new XElement("EmpleadoId", oBEEmpleado.ID.ToString()),
                        new XElement("PermisoId", oBEPermiso.ID.ToString())
                        ));
                docXML.Save(archivoEmpleadoPermiso);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool BorrarPermisoUsuario(BE_Empleado oBEEmpleado, BE_Componente oBEComponente)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoEmpleadoPermiso);

                var query = from e in docXML.Descendants("Empleado_Permiso")
                            where int.Parse(e.Element("EmpleadoId").Value) == oBEEmpleado.ID
                            where int.Parse(e.Element("PermisoId").Value) == oBEComponente.ID
                            select e;

                query.Remove();
                docXML.Save(archivoEmpleadoPermiso);

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool AsignarPermisoARol(BE_Rol rol, BE_Permiso permiso)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoPermiso2);

                // Verificar si ya existe la relación
                var existeRelacion = (from p in docXML.Descendants("Permiso_Permiso")
                                      where int.Parse(p.Element("PermisoPadreId").Value) == rol.ID
                                      && int.Parse(p.Element("PermisoHijoId").Value) == permiso.ID
                                      select p).Any();

                // Si no existe la relación, agregarla
                if (!existeRelacion)
                {
                    docXML.Element("Permisos_Permisos").Add(new XElement("Permiso_Permiso",
                        new XElement("PermisoPadreId", rol.ID),
                        new XElement("PermisoHijoId", permiso.ID)
                    ));


                    docXML.Save(archivoPermiso2);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al asignar permiso al rol", ex);
            }
        }

        public bool EliminarPermisodeRol(BE_Rol rol, BE_Permiso permiso)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoPermiso2);

                // Buscar la relación entre el rol y el permiso
                var relacion = (from p in docXML.Descendants("Permiso_Permiso")
                                where int.Parse(p.Element("PermisoPadreId").Value) == rol.ID
                                && int.Parse(p.Element("PermisoHijoId").Value) == permiso.ID
                                select p).FirstOrDefault();

                // Si la relación existe, eliminarla
                if (relacion != null)
                {
                    relacion.Remove();

                    // Guardar los cambios en el archivo XML
                    docXML.Save(archivoPermiso2);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GenerarNuevoId()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoPermiso);

                return docXML.Descendants("Permiso").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AsignarRolAUsuario(BE_Empleado empleado, BE_Rol rol)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoEmpleadoPermiso);

                var existeRelacion = docXML.Descendants("Empleado_Permiso").Any(x =>
                    int.Parse(x.Element("EmpleadoId").Value) == empleado.ID &&
                    int.Parse(x.Element("PermisoId").Value) == rol.ID);

                if (!existeRelacion)
                {
                    docXML.Element("Empleado_Permisos").Add(new XElement("Empleado_Permiso",
                        new XElement("EmpleadoId", empleado.ID),
                        new XElement("PermisoId", rol.ID),
                        new XElement("FechaAsignacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))));

                    docXML.Save(archivoEmpleadoPermiso);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al asignar rol al usuario: {ex.Message}", ex);
            }
        }

        public bool RemoverRolDeUsuario(BE_Empleado empleado, BE_Rol rol)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoEmpleadoPermiso);

                var relacion = docXML.Descendants("Empleado_Permiso").FirstOrDefault(x =>
                    int.Parse(x.Element("EmpleadoId").Value) == empleado.ID &&
                    int.Parse(x.Element("PermisoId").Value) == rol.ID);

                if (relacion != null)
                {
                    relacion.Remove();
                    docXML.Save(archivoEmpleadoPermiso);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al remover rol del usuario: {ex.Message}", ex);
            }
        }
    }
}
