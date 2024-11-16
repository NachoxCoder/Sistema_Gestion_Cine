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
    public class MapperBitacora : IAbmc<BE.BE_Bitacora>
    {
        private const string archivoBitacora = @"\DATA\Bitacora.xml";

        public bool Borrar(BE_Bitacora pObjBitacora)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoBitacora);

                var query = from registro in docXML.Descendants("Bitacora")
                            where int.Parse(registro.Attribute("IdBitacora").Value) == pObjBitacora.ID
                            select registro;

                query.Remove();
                docXML.Save(archivoBitacora);

                return true;
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
                XDocument docXML = XDocument.Load(archivoBitacora);

                int ultimoId = docXML.Descendants("Bitacora").Select(e => (int?)e.Attribute("IdBitacora"))
                               .Max() ?? 0;
                return ultimoId == 0 ? 1 : ultimoId + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE.BE_Bitacora pObjBitacora)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoBitacora);

                if (pObjBitacora.ID == 0)
                {
                    docXML.Element("Bitacora").Add(new XElement("Bitacora",
                    new XAttribute("IdBitacora", GenerarNuevoId()),
                    new XElement("Fecha", pObjBitacora.Fecha.ToString("yyyy-MM-dd HH:mm:ss")),
                    new XElement("Evento", pObjBitacora.Evento),
                    new XElement("IdUsuario", pObjBitacora.UsuarioEmpleado?.ID ?? 0)));

                    docXML.Save(archivoBitacora);
                    return true;
                }
                else
                {
                    var query = from x in docXML.Descendants("Bitacora")
                                where int.Parse(x.Attribute("IdBitacora").Value) == pObjBitacora.ID
                                select x;

                    foreach (XElement item in query)
                    {
                        item.Element("Fecha").Value = pObjBitacora.Fecha.ToString("yyyy-MM-dd HH:mm:ss");
                        item.Element("Evento").Value = pObjBitacora.Evento;
                        item.Element("IdUsuario").Value = (pObjBitacora.UsuarioEmpleado?.ID ?? 0).ToString();
                    }

                    docXML.Save(archivoBitacora);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Bitacora> Consultar()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivoBitacora);

                MapperEmpleado mapperEmpleado = new MapperEmpleado();

                var resgistros = from registro in docXML.Descendants("Bitacora")
                                 select new BE_Bitacora
                                 {
                                     ID = int.Parse(registro.Attribute("IdBitacora").Value),
                                     Fecha = DateTime.Parse(registro.Element("Fecha").Value),
                                     Evento = registro.Element("Evento").Value,
                                     UsuarioEmpleado = mapperEmpleado.Consultar().
                                     FirstOrDefault(e => e.ID == int.Parse(registro.Element("IdUsuario").Value))
                                 };

                return resgistros.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
