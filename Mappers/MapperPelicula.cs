using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Interfaces;

namespace Mappers
{
    public class MapperPelicula : IAbmc<BE_Pelicula>
    {
        const string archivo = @".\Data\Pelicula.xml";
        const string archivoFunciones= @".\Data\Pelicula_Funcion.xml";

        public bool Borrar(BE_Pelicula pObjBEPelicula)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
            
                //Verifica si hay funciones asociadas a la pelicula antes de borrarla
                XDocument xmlFunciones = XDocument.Load(archivoFunciones);

                int funcionesAsociadas = xmlFunciones.Descendants("Pelicula_Funcion").
                    Count(x => int.Parse(x.Element("IdPelicula").Value) == pObjBEPelicula.IdPelicula);

                if (funcionesAsociadas == 0)
                {
                    var query = from x in docXML.Descendants("Pelicula")
                                where int.Parse(x.Element("IdPelicula").Value) == pObjBEPelicula.IdPelicula
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
        public int PeliculaID()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                int ultimoId = docXML.Descendants("Pelicula").Select(e => (int?)e.Attribute("IdPelicula")).Max() ?? 0;
                return ultimoId == 0 ? 1 : ultimoId + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool Guardar(BE_Pelicula objBEPelicula)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                if (objBEPelicula.IdPelicula == 0)
                {
                    docXML.Element("Peliculas").Add(new XElement("Pelicula",
                        new XAttribute("IdPelicula", PeliculaID()),
                        new XElement("Titulo", objBEPelicula.Titulo.Trim()),
                        new XElement("Sinopsis", objBEPelicula.Sinopsis.Trim()),
                        new XElement("Duracion", objBEPelicula.Duracion),
                        new XElement("Rating", objBEPelicula.Rating.Trim()),
                        new XElement("EstaActiva", objBEPelicula.EstaActiva)
                    ));

                    docXML.Save(archivo);
                    return true;
                }
                else
                {
                    var query = from x in docXML.Descendants("Pelicula")
                                where x.Attribute("IdPelicula").Value == objBEPelicula.ID.ToString() 
                                select x;

                    foreach (XElement item in query)
                    {
                        item.Element("Titulo").Value = objBEPelicula.Titulo.Trim();
                        item.Element("Sinopsis").Value = objBEPelicula.Sinopsis.Trim();
                        item.Element("Duracion").Value = objBEPelicula.Duracion.ToString();
                        item.Element("Rating").Value = objBEPelicula.Rating.Trim();
                        item.Element("EstaActiva").Value = objBEPelicula.EstaActiva.ToString();
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

        public List<BE_Pelicula> Consultar()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                List<BE_Pelicula> listaPeliculas = new List<BE_Pelicula>();

                var query = from x in docXML.Descendants("Pelicula")
                            select x;

                foreach (XElement item in query)
                {
                    BE_Pelicula objBEPelicula = new BE_Pelicula
                    {
                        IdPelicula = int.Parse(item.Attribute("IdPelicula").Value),
                        Titulo = item.Element("Titulo").Value,
                        Sinopsis = item.Element("Sinopsis").Value,
                        Duracion = int.Parse(item.Element("Duracion").Value),
                        Rating = item.Element("Rating").Value,
                    };

                    listaPeliculas.Add(objBEPelicula);
                }
                return listaPeliculas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
