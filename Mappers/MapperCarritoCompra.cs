using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Mappers;
using System.Xml.Linq;
using Interfaces;


namespace Mappers
{
    public class MapperCarritoCompra : MapperBase<BE_CarritoCompra>, IAbmc<BE_CarritoCompra>
    {
        private const string archivoCarritoCompra = @".\DATA\CarritoCompra.xml";
        private readonly MapperCliente mapperCliente;
        private readonly MapperItemCarrito mapperItemCarrito;

        public MapperCarritoCompra() : base(archivoCarritoCompra)
        {
            mapperCliente = new MapperCliente();
            mapperItemCarrito = new MapperItemCarrito();
        }

        public bool Borrar(BE_CarritoCompra pCarritoCompra)
        {
            try
            {
                XDocument docXML = CargarXml();

                var carritoCompra = docXML.Descendants("CarritoCompra").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pCarritoCompra.ID);

                if (carritoCompra != null)
                {
                    foreach (var item in pCarritoCompra.Items)
                    {
                        mapperItemCarrito.Borrar(item);
                    }

                    carritoCompra.Remove();
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

        public bool Guardar(BE_CarritoCompra pCarritoCompra)
        {
            try
            {
                XDocument xml = CargarXml();

                if (pCarritoCompra.ID == 0)
                {
                    pCarritoCompra.ID = GenerarNuevoId(xml);

                    var nuevoCarritoCompra = new XElement("CarritoCompra",
                        new XAttribute("ID", pCarritoCompra.ID),
                        new XElement("IdCliente", pCarritoCompra.IdCliente),
                        new XElement("FechaCreacion", pCarritoCompra.FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss")),
                        new XElement("Total", pCarritoCompra.Total.ToString("F2")));

                    xml.Root.Add(nuevoCarritoCompra);

                    foreach (var item in pCarritoCompra.Items)
                    {
                        item.IdCarrito = pCarritoCompra.ID;
                        mapperItemCarrito.Guardar(item);
                    }
                }
                else
                {
                    var carritoCompra = xml.Descendants("CarritoCompra").
                        FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pCarritoCompra.ID);

                    if (carritoCompra != null)
                    {
                        carritoCompra.Element("Total").Value = pCarritoCompra.Total.ToString("F2");
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

        public List<BE_CarritoCompra> Consultar()
        {
            try
            {
                XDocument xml = CargarXml();
                var clientes = mapperCliente.Consultar();
                var carritos = xml.Descendants("CarritoCompra").Select(x => new BE_CarritoCompra
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdCliente = int.Parse(x.Element("IdCliente").Value),
                    FechaCreacion = DateTime.Parse(x.Element("FechaCreacion").Value),
                    Total = decimal.Parse(x.Element("Total").Value)
                }).ToList();

                foreach (var carrito in carritos)
                {
                    carrito.Cliente = clientes.FirstOrDefault(c => c.ID == carrito.IdCliente);
                    carrito.Items = mapperItemCarrito.ConsultarPorCarrito(carrito.ID);
                }

                return carritos;
            }
            catch
            {
                return new List<BE_CarritoCompra>();
            }
        }

        public int GenerarNuevoId(XDocument xml)
        {
            return xml.Descendants("CarritoCompra").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }
    }
}
