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
    public class MapperSala : IAbmc<BE_Sala>
    {
        const string archivo = @".\Data\Sala.xml";

        public bool Borrar(BE_Sala pObjSala)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);

                //Verificar que no existan funciones asociadas a la sala antes de borrarla
                string archivoFunciones = @".\Data\Funcion.xml";
                XDocument xmlFunciones = XDocument.Load(archivoFunciones);
                var funcionesAsociadas = xmlFunciones.Descendants("Funcion").
                                         Any(x => int.Parse(x.Element("IdSala").Value) == pObjSala.ID);
                if (!funcionesAsociadas)
                {
                    var query = from x in docXML.Descendants("Sala")
                            where int.Parse(x.Attribute("IdSala").Value) == pObjSala.ID
                            select x;

                    query.Remove();
                    docXML.Save(archivo);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SalaID()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                int ultimoId = docXML.Descendants("Sala").Select(e => (int?)e.Attribute("IdSala"))
                               .Max() ?? 0;
                return ultimoId == 0 ? 1 : ultimoId + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Sala objBESala)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);

                if (objBESala.ID == 0)
                {
                    docXML.Element("Salas").Add(new XElement("Sala",
                    new XAttribute("IdSala", SalaID()),
                    new XElement("Nombre", objBESala.Nombre),
                    new XElement("Capacidad", objBESala.Capacidad),
                    new XElement("Tiene3D", objBESala.Tiene3D)));

                    docXML.Save(archivo);
                    return true;
                }
                else
                {
                    var query = from x in docXML.Descendants("Sala")
                                where x.Attribute("IdSala").Value == objBESala.ID.ToString()
                                select x;
                    foreach (XElement item in query)
                    {
                        item.Element("Nombre").Value = objBESala.Nombre;
                        item.Element("Capacidad").Value = objBESala.Capacidad.ToString();
                        item.Element("Tiene3D").Value = objBESala.Tiene3D.ToString();
                    }
                    docXML.Save(archivo);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Sala> Consultar()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                var query = from x in docXML.Descendants("Sala")
                            select x;
                List<BE_Sala> listaSalas = new List<BE_Sala>();

                foreach (XElement item in query)
                {
                    BE_Sala objSala = new BE_Sala();
                    objSala.ID = int.Parse(item.Attribute("IdSala").Value);
                    objSala.Nombre = item.Element("Nombre").Value;
                    objSala.Capacidad = int.Parse(item.Element("Capacidad").Value);
                    objSala.Tiene3D = bool.Parse(item.Element("Tiene3D").Value);
                    listaSalas.Add(objSala);
                }
                return listaSalas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
