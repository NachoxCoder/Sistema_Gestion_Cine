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
    public class MapperItemCarrito : MapperBase<BE_ItemCarrito>, IAbmc<BE_ItemCarrito>
    {
        private const string archivoItemCarrito = @".\DATA\ItemCarrito.xml";
        private readonly MapperBoleto mapperBoleto;

        public MapperItemCarrito() : base(archivoItemCarrito)
        {
            mapperBoleto = new MapperBoleto();
        }

        public bool Borrar(BE_ItemCarrito pItemCarrito)
        {
            try
            {
                XDocument docXML = CargarXml();

                var itemCarrito = docXML.Descendants("ItemCarrito").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pItemCarrito.ID);

                if (itemCarrito != null)
                {
                    itemCarrito.Remove();
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

        public bool Guardar(BE_ItemCarrito pItemCarrito)
        {
            try
            {
                XDocument docXML = CargarXml();

                if (pItemCarrito.ID == 0)
                {
                    pItemCarrito.ID = GenerarNuevoId(docXML);
                    var nuevoItemCarrito = new XElement("ItemCarrito",
                    new XAttribute("ID", pItemCarrito.ID),
                    new XElement("IdCarrito", pItemCarrito.IdCarrito),
                    new XElement("IdBoleto", pItemCarrito.IdBoleto),
                    new XElement("Cantidad", pItemCarrito.Cantidad),
                    new XElement("PrecioUnitario", pItemCarrito.PrecioUnitario.ToString("F2")),
                    new XElement("Subtotal", pItemCarrito.Subtotal.ToString("F2")));

                    docXML.Root.Add(nuevoItemCarrito);
                }
                else
                {
                    var itemCarrito = docXML.Descendants("ItemCarrito").
                        FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pItemCarrito.ID);

                    if (itemCarrito != null)
                    {
                        itemCarrito.Element("Cantidad").Value = pItemCarrito.Cantidad.ToString();
                        itemCarrito.Element("PrecioUnitario").Value = pItemCarrito.PrecioUnitario.ToString("F2");
                        itemCarrito.Element("Subtotal").Value = pItemCarrito.Subtotal.ToString("F2");
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

        public List<BE_ItemCarrito> Consultar()
        {
            try
            {
                XDocument docXML = CargarXml();
                var boletos = mapperBoleto.Consultar();

                return docXML.Descendants("ItemCarrito").Select(x => new BE_ItemCarrito
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdCarrito = int.Parse(x.Element("IdCarrito").Value),
                    IdBoleto = int.Parse(x.Element("IdBoleto").Value),
                    Cantidad = int.Parse(x.Element("Cantidad").Value),
                    PrecioUnitario = decimal.Parse(x.Element("PrecioUnitario").Value),
                    Subtotal = decimal.Parse(x.Element("Subtotal").Value),
                    Boleto = boletos.FirstOrDefault(b => b.ID == int.Parse(x.Element("IdBoleto").Value))
                }).ToList();
            }
            catch
            {
                return new List<BE_ItemCarrito>();
            }
        }

        public int GenerarNuevoId(XDocument pXml)
        {
            return pXml.Descendants("ItemCarrito").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }

        public List<BE_ItemCarrito> ConsultarPorCarrito(int pIdCarrito)
        {
           return Consultar().Where(x => x.IdCarrito == pIdCarrito).ToList();
        }
    }
}
