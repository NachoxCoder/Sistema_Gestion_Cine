using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mappers
{
    public abstract class MapperBase<T> where T : BE_EntidadBase
    {
        protected readonly string ArchivoXml;

        protected MapperBase(string archivoXml)
        {
            ArchivoXml = archivoXml;
        }

        protected XDocument CargarXml()
        {
            try
            {
                return XDocument.Load(ArchivoXml);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al cargar el archivo {ArchivoXml}", ex);
            }
            
        }

        protected void GuardarXml(XDocument docXML)
        {
            try
            {
                docXML.Save(ArchivoXml);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el archivo {ArchivoXml}", ex);
            }
        }
    }
}
