using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using Interfaces;

namespace Mappers
{
    public class MapperEmpleado : MapperBase<BE_Empleado>, IAbmc<BE_Empleado>
    {
        private const string archivoEmpleado = @".\DATA\Empleado.xml";

        public bool Guardar(BE_Empleado pEmpleado)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoEmpleado);

                if (pEmpleado.ID == 0)
                {
                    pEmpleado.ID = GenerarNuevoId();
                    docXML.Element("Empleado").Add(new XElement("Empleado",
                        new XAttribute("ID", pEmpleado.ID),
                        new XElement("Username", pEmpleado.Username),
                        new XElement("Password", pEmpleado.Password),
                        new XElement("Nombre", pEmpleado.Nombre),
                        new XElement("Apellido", pEmpleado.Apellido),
                        new XElement("Area", pEmpleado.Area)));
                }
                else
                {
                    var empleado = docXML.Descendants("Empleado").
                        FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pEmpleado.ID);

                    if (empleado != null)
                    {
                        empleado.Element("Username").Value = pEmpleado.Username;
                        empleado.Element("Password").Value = pEmpleado.Password;
                        empleado.Element("Nombre").Value = pEmpleado.Nombre;
                        empleado.Element("Apellido").Value = pEmpleado.Apellido;
                        empleado.Element("Area").Value = pEmpleado.Area;
                    }
                }

                docXML.Save(archivoEmpleado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Borrar(BE_Empleado pEmpleado)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoEmpleado);

                var empleado = docXML.Descendants("Empleado").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pEmpleado.ID);

                if (empleado != null)
                {
                    //Verificar si el Empleado tiene registros asociados (permisos,bitacora, etc...)
                    if(!TieneRegistrosAsociados(pEmpleado.ID))
                    {
                        empleado.Remove();
                        docXML.Save(archivoEmpleado);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BE_Empleado> Consultar()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoEmpleado);

                return docXML.Descendants("Empleado").Select(x => new BE_Empleado
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    Username = x.Element("Username").Value,
                    Password = x.Element("Password").Value,
                    Nombre = x.Element("Nombre").Value,
                    Apellido = x.Element("Apellido").Value,
                    Area = x.Element("Area").Value
                }).ToList();
            }
            catch (Exception)
            {
                return new List<BE_Empleado>();
            }
        }

        private int GenerarNuevoId()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoEmpleado);

                return docXML.Descendants("Empleado").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool TieneRegistrosAsociados(int empleadoId)
        {
            try
            {
                XDocument xmlBitacora = XDocument.Load(@".\DATA\Bitacora.xml");
                bool existeBitacora = xmlBitacora.Descendants("Registro").Any(x => x.Element("Usuario") != null &&
                                  x.Element("Usuario").Value == empleadoId.ToString());

                XDocument xmlPermisos = XDocument.Load(@".\DATA\Permisos.xml");
                bool tienePermisos = xmlPermisos.Descendants("Permiso_Usuario")
                                 .Any(x => int.Parse(x.Element("IdUsuario").Value) == empleadoId);

                return existeBitacora || tienePermisos;

            }
            catch (Exception)
            {

                return false;
            }
            
        }


    }
}
