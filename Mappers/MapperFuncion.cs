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
    public class MapperFuncion : MapperBase<BE_Funcion>, IAbmc<BE_Funcion>
    {
        private const string archivoFuncion = @".\Data\Funcion.xml";
        private readonly MapperPelicula _mapperPelicula;
        private readonly MapperSala _mapperSala;

        public MapperFuncion() : base(archivoFuncion)
        {
            _mapperPelicula = new MapperPelicula();
            _mapperSala = new MapperSala();
        }

        public bool Borrar(BE_Funcion pFuncion)
        {
            try
            {
                XDocument xml = CargarXml();

                var funcion = xml.Descendants("Funcion").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pFuncion.ID);

                if (funcion != null)
                {
                    funcion.Remove();
                    GuardarXml(xml);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GenerarNuevoID(XDocument xml)
        {
            try
            {
                return xml.Descendants("Funcion").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Funcion pFuncion)
        {
            try
            {
                XDocument xml = CargarXml();
                if (pObjFuncion.ID == 0)
                {
                    pFuncion.ID = GenerarNuevoID(xml);
                    var nuevaFuncion = new XElement("Funcion",
                            new XAttribute("ID", pFuncion.ID),
                            new XElement("IdPelicula", pFuncion.IdPelicula),
                            new XElement("FechaFuncion", pFuncion.FechaFuncion.ToString("yyyy-MM-dd")),
                            new XElement("HoraFuncion", pFuncion.HoraFuncion.ToString("HH:mm")),
                            new XElement("IdSala", pFuncion.IdSala),
                            new XElement("EstaActiva", pFuncion.EstaActiva),
                            new XElement("Precio", pFuncion.Precio.ToString("F2")));

                    xml.Root.Add(nuevaFuncion);
                }
                else
                {
                    var funcion = xml.Descendants("Funcion").
                        FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pFuncion.ID);

                    if (funcion != null)
                    {
                        funcion.Element("IdPelicula").Value = pFuncion.IdPelicula.ToString();
                        funcion.Element("FechaFuncion").Value = pFuncion.FechaFuncion.ToString("yyyy-MM-dd");
                        funcion.Element("HoraFuncion").Value = pFuncion.HoraFuncion.ToString("HH:mm");
                        funcion.Element("IdSala").Value = pFuncion.IdSala.ToString();
                        funcion.Element("EstaActiva").Value = pFuncion.EstaActiva.ToString();
                    }
                }

                GuardarXml(xml);
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
                XDocument xml = CargarXml();
                var funciones = xml.Descendants("Funcion").Select(x => new BE_Funcion
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdPelicula = int.Parse(x.Element("IdPelicula").Value),
                    FechaFuncion = DateTime.Parse(x.Element("FechaFuncion").Value),
                    HoraFuncion = TimeSpan.Parse(x.Element("HoraFuncion").Value),
                    IdSala = int.Parse(x.Element("IdSala").Value),
                    EstaActiva = bool.Parse(x.Element("EstaActiva").Value),
                    Precio = decimal.Parse(x.Element("Precio").Value)
                }).ToList();    
               
                var peliculas = _mapperPelicula.Consultar();
                var salas = _mapperSala.Consultar();

                foreach (var funcion in funciones)
                {
                    funcion.Pelicula = peliculas.FirstOrDefault(x => x.ID == funcion.IdPelicula);
                    funcion.Sala = salas.FirstOrDefault(x => x.ID == funcion.IdSala);
                }

                return funciones;
            }
            catch
            {
                return new List<BE_Funcion>();
            }

        }
    }
} 

