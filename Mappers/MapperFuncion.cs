using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Mappers
{
    public class MapperFuncion : IAbmc<BE_Funcion>
    {
        const string archivo = @".\Data\Funcion.xml";
        const string archivoBoletos = @".\Data\Funcion_Boleto.xml";

        public bool Borrar(BE_Funcion pObjFuncion)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                XDocument xmlBoletos = XDocument.Load(archivoBoletos);

                //Verificar que no existan boletos asociados a la funcion antes de borrarla
                int boletosVendidos = xmlBoletos.Descendants("Funcion_Boleto").
                    Count(x => int.Parse(x.Element("IdFuncion").Value) == pObjFuncion.ID);
                if (boletosVendidos == 0)
                {
                    var query = from x in docXML.Descendants("Funcion")
                                where int.Parse(x.Attribute("IdFuncion").Value) == pObjFuncion.ID
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

        public int FuncionID()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                int ultimoId = docXML.Descendants("Funcion").Select(e => (int?)e.Attribute("IdFuncion"))
                               .Max() ?? 0;
                return ultimoId == 0 ? 1 : ultimoId + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Funcion pObjFuncion)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                if (pObjFuncion.ID == 0)
                {
                    docXML.Element("Funciones").Add(new XElement("Funcion",
                            new XAttribute("IdFuncion", FuncionID()),
                            new XElement("IdPelicula", pObjFuncion.IdPelicula),
                            new XElement("FechaFuncion", pObjFuncion.FechaFuncion.ToString("yyyy-MM-dd")),
                            new XElement("HoraFuncion", pObjFuncion.HoraFuncion.ToString("HH:mm")),
                            new XElement("IdSala", pObjFuncion.IdSala),
                            new XElement("EstaActiva", pObjFuncion.EstaActiva),
                            new XElement("Precio", pObjFuncion.Precio.ToString())));

                    docXML.Save(archivo);
                    return true;
                }
                else
                {
                    var query = from x in docXML.Descendants("Funcion")
                                where x.Attribute("IdFuncion").Value == pObjFuncion.ID.ToString()
                                select x;
                    foreach (XElement item in query)
                    {
                        item.Element("IdPelicula").Value = pObjFuncion.IdPelicula.ToString();
                        item.Element("FechaFuncion").Value = pObjFuncion.FechaFuncion.ToString("yyyy-MM-dd");
                        item.Element("HoraFuncion").Value = pObjFuncion.HoraFuncion.ToString("HH:mm");
                        item.Element("IdSala").Value = pObjFuncion.IdSala.ToString();
                        item.Element("EstaActiva").Value = pObjFuncion.EstaActiva.ToString();
                        item.Element("Precio").Value = pObjFuncion.Precio.ToString();
                    }
                }
                docXML.Save(archivo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<BE_Funcion> Consultar()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                List<BE_Funcion> listaFunciones = new List<BE_Funcion>();
                 var query = from x in docXML.Descendants("Funcion")
                             select x;

                foreach (XElement item in query)
                {
                    BE_Funcion objFuncion = new BE_Funcion
                    { ID = int.Parse(item.Attribute("IdFuncion").Value),
                        IdPelicula = int.Parse(item.Element("IdPelicula").Value),
                        FechaFuncion = DateTime.Parse(item.Element("FechaFuncion").Value),
                        HoraFuncion = TimeSpan.Parse(item.Element("HoraFuncion").Value),
                        IdSala = int.Parse(item.Element("IdSala").Value),
                        EstaActiva = bool.Parse(item.Element("EstaActiva").Value),
                        Precio = decimal.Parse(item.Element("Precio").Value)
                    };
                    
                    listaFunciones.Add(objFuncion);
                }
                return listaFunciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
} 

