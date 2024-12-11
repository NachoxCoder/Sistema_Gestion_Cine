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
    public class MapperBoletoFuncion : MapperBase<BE_BoletoFuncion>
    {
        private const string archivoBoletoFuncion = @".\DATA\BoletoFuncion.xml";
        private readonly MapperBoleto mapperBoleto;
        private readonly MapperFuncion mapperFuncion;

        public MapperBoletoFuncion() : base(archivoBoletoFuncion)
        {
            mapperBoleto = new MapperBoleto();
            mapperFuncion = new MapperFuncion();
        }

        public bool Borrar(BE_BoletoFuncion pBoletoFuncion)
        {
            try
            {
                XDocument docXML = CargarXml();

                var boletoFuncion = docXML.Descendants("BoletoFuncion").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pBoletoFuncion.ID);

                if (boletoFuncion != null)
                {
                    boletoFuncion.Remove();
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

        public bool Guardar(BE_BoletoFuncion pBoletoFuncion)
        {
            try
            {
                XDocument docXML = CargarXml();
                if (pBoletoFuncion.ID == 0)
                {
                    pBoletoFuncion.ID = GenerarNuevoId(docXML);
                    var nuevoBoletoFuncion = new XElement("BoletoFuncion",
                    new XAttribute("ID", pBoletoFuncion.ID),
                    new XElement("IdBoleto", pBoletoFuncion.IdBoleto),
                    new XElement("IdFuncion", pBoletoFuncion.IdFuncion),
                    new XElement("FechaVenta", pBoletoFuncion.FechaVenta.ToString("yyyy-MM-dd HH:mm:ss")));

                    docXML.Root.Add(nuevoBoletoFuncion);
                }
                else
                {
                    var boletoFuncion = docXML.Descendants("BoletoFuncion").
                        FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pBoletoFuncion.ID);

                    if (boletoFuncion != null)
                    {
                        boletoFuncion.Element("IdBoleto").Value = pBoletoFuncion.IdBoleto.ToString();
                        boletoFuncion.Element("IdFuncion").Value = pBoletoFuncion.IdFuncion.ToString();
                        boletoFuncion.Element("FechaVenta").Value = pBoletoFuncion.FechaVenta.ToString("yyyy-MM-dd HH:mm:ss");
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

        public List<BE_BoletoFuncion> Consultar()
        {
            try
            {
                XDocument xml = CargarXml();
                var boletos = mapperBoleto.Consultar();
                var funciones = mapperFuncion.Consultar();

                return xml.Descendants("BoletoFuncion").Select(x => new BE_BoletoFuncion
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdBoleto = int.Parse(x.Element("IdBoleto").Value),
                    IdFuncion = int.Parse(x.Element("IdFuncion").Value),
                    FechaVenta = DateTime.Parse(x.Element("FechaVenta").Value),
                    Boleto = boletos.FirstOrDefault(b => b.ID == int.Parse(x.Element("IdBoleto").Value)),
                    Funcion = funciones.FirstOrDefault(f => f.ID == int.Parse(x.Element("IdFuncion").Value))
                }).ToList();
            }
            catch
            {
                return new List<BE_BoletoFuncion>();
            }
        }

        public int GenerarNuevoId(XDocument xml)
        {
            return xml.Descendants("BoletoFuncion").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }
    }
}
