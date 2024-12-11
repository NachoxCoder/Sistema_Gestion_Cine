using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Interfaces;

namespace Mappers
{
    public class MapperPelicula : MapperBase<BE_Pelicula>, IAbmc<BE_Pelicula>
    {
        private const string ARCHIVO_PELICULA = @".\Data\Pelicula.xml";

        public MapperPelicula() : base(ARCHIVO_PELICULA) { }

        public bool Borrar(BE_Pelicula pPelicula)
        {
            try
            {
                XDocument xml = CargarXml();

                var pelicula = xml.Descendants("Pelicula").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pPelicula.ID);

                if (pelicula != null)
                {
                    pelicula.Remove();
                    GuardarXml(xml);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        private int GenerarNuevoID(XDocument xml)
        {
            try
            {
                return xml.Descendants("Pelicula").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool Guardar(BE_Pelicula pPelicula)
        {
            try
            {
                XDocument xml = CargarXml();
                if (pPelicula.ID == 0)
                {
                    pPelicula.ID = GenerarNuevoId(xml);
                    var nuevaPelicula = new XElement("Pelicula",
                        new XAttribute("IdPelicula", pPelicula.ID),
                        new XElement("Titulo", pPelicula.Titulo),
                        new XElement("Sinopsis", pPelicula.Sinopsis),
                        new XElement("Duracion", pPelicula.Duracion),
                        new XElement("Rating", pPelicula.Rating),
                        new XElement("EstaActiva", pPelicula.EstaActiva));

                    xml.Root.Add(nuevaPelicula);
                }
                else
                {
                    var pelicula = xml.Descendants("Pelicula").
                        FirstOrDefault(x => int.Parse(x.Attribute("IdPelicula").Value) == pPelicula.ID);

                    if (pelicula != null)
                    {
                        pelicula.Element("Titulo").Value = pPelicula.Titulo;
                        pelicula.Element("Sinopsis").Value = pPelicula.Sinopsis;
                        pelicula.Element("Duracion").Value = pPelicula.Duracion.ToString();
                        pelicula.Element("Rating").Value = pPelicula.Rating;
                        pelicula.Element("EstaActiva").Value = pPelicula.EstaActiva.ToString();
                    }
                }

                GuardarXml(xml);
                return true;
                
            }   
            catch
            {
                return false;
            }
        }

        public List<BE_Pelicula> Consultar()
        {
            try
            {
                XDocument xml = CargarXml();

                return xml.Descendants("Pelicula").Select(x => new BE_Pelicula
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    Titulo = x.Element("Titulo").Value,
                    Sinopsis = x.Element("Sinopsis").Value,
                    Duracion = int.Parse(x.Element("Duracion").Value),
                    Rating = x.Element("Rating").Value,
                    EstaActiva = bool.Parse(x.Element("EstaActiva").Value)
                }).ToList();
            }
            catch
            {
                return new List<BE_Pelicula>();
            }
        }

        public int GenerarNuevoId(XDocument xml)
        {
            try
            {
                return xml.Descendants("Pelicula").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
