using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;

namespace Mappers
{
    public class MapperConfiguracion : MapperBase<BE_Configuracion>, IAbmc<BE_Configuracion>
    {
        private const string archivoConfiguracion = @".\DATA\Configuracion.xml";
        public MapperConfiguracion() : base(archivoConfiguracion) { }

        public bool Borrar(BE_Configuracion pObjeto)
        {
            try
            {
                XDocument docXML = CargarXml();

                var configuracion = docXML.Descendants("Configuracion").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pObjeto.ID);

                if (configuracion != null)
                {
                    configuracion.Remove();
                    GuardarXml(docXML);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Guardar(BE_Configuracion pObjeto)
        {
            try
            {
                XDocument docXML = CargarXml();
                if (pObjeto.ID == 0)
                {
                    pObjeto.ID = GenerarNuevoId(docXML);
                    var nuevaConfiguracion = new XElement("Configuracion",
                    new XAttribute("ID", pObjeto.ID),
                    new XElement("Clave", pObjeto.Clave),
                    new XElement("Valor", pObjeto.Valor),
                    new XElement("Descripcion", pObjeto.Descripcion),
                    new XElement("FechaModificacion", pObjeto.FechaModificacion.ToString("yyyy-MM-dd HH:mm:ss")));

                    docXML.Root.Add(nuevaConfiguracion);
                }
                else
                {
                    var configuracion = docXML.Descendants("Configuracion").
                        FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pObjeto.ID);

                    if (configuracion != null)
                    {
                        configuracion.Element("Valor").Value = pObjeto.Valor;
                        configuracion.Element("Descripcion").Value = pObjeto.Descripcion;
                        configuracion.Element("FechaModificacion").Value = pObjeto.FechaModificacion.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                GuardarXml(docXML);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<BE_Configuracion> Consultar()
        {
            try
            {
                XDocument docXML = CargarXml();
                return docXML.Descendants("Configuracion").Select(x => new BE_Configuracion
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    Clave = x.Element("Clave").Value,
                    Valor = x.Element("Valor").Value,
                    Descripcion = x.Element("Descripcion").Value,
                    FechaModificacion = DateTime.Parse(x.Element("FechaModificacion").Value)
                }).ToList();
            }
            catch
            {
                return new List<BE_Configuracion>();
            }
        }

        public int GenerarNuevoId(XDocument pXml)
        {
            return pXml.Descendants("Configuracion").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }
    }
}
