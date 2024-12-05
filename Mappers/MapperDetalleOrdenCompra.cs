using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using Interfaces;

namespace Mappers
{
    public class MapperDetalleOrdenCompra : MapperBase<BE_DetalleOrdenCompra>, IAbmc<BE_DetalleOrdenCompra>
    {
        private const string archivoDetalleOrdenCompra = @".\DATA\DetalleOrdenCompra.xml";
        private readonly MapperProducto mapperProducto;
        private readonly MapperOrdenCompra mapperOrdenCompra;

        public MapperDetalleOrdenCompra() : base(archivoDetalleOrdenCompra)
        {
            mapperOrdenCompra = new MapperOrdenCompra();
            mapperProducto = new MapperProducto();
        }

        public bool Borrar(BE_DetalleOrdenCompra pDetalle)
        {
            try
            {
                XDocument docXML = CargarXml();

                var detalle = docXML.Descendants("DetalleOrdenCompra")
                    .FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pDetalle.ID);

                if (detalle != null)
                {
                    detalle.Remove();
                    GuardarXml(docXML);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar borrar el detalle de la orden de compra: {ex.Message}", ex);
            }
        }

        public bool Guardar(BE_DetalleOrdenCompra pDetalle)
        {
            try
            {
                XDocument docXML = CargarXml();
                if (pDetalle.ID == 0)
                {
                    pDetalle.ID = GenerarNuevoID(docXML);
                    var nuevoDetalle = new XElement("DetalleOrdenCompra",
                        new XAttribute("ID", pDetalle.ID),
                        new XElement("IDOrdenCompra", pDetalle.IdOrdenCompra),
                        new XElement("IDProducto", pDetalle.IdProducto),
                        new XElement("Cantidad", pDetalle.Cantidad),
                        new XElement("PrecioUnitario", pDetalle.PrecioUnitario.ToString("F2")));

                    docXML.Root.Add(nuevoDetalle);
                }
                else
                {
                    var detalle = docXML.Descendants("DetalleOrdenCompra")
                        .FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pDetalle.ID);

                    if (detalle != null)
                    {
                        detalle.Element("Cantidad").Value = pDetalle.Cantidad.ToString();
                        detalle.Element("PrecioUnitario").Value = pDetalle.PrecioUnitario.ToString("F2");
                    }
                }

                GuardarXml(docXML);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar guardar el detalle de la orden de compra: {ex.Message}", ex);
            }
        }

        public List<BE_DetalleOrdenCompra> Consultar()
        {
            try
            {
                XDocument docXML = CargarXml();
                var productos = mapperProducto.Consultar();
                var ordenesCompra = mapperOrdenCompra.Consultar();

                return docXML.Descendants("DetalleOrdenCompra").Select(x => new BE_DetalleOrdenCompra
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdOrdenCompra = int.Parse(x.Element("IDOrdenCompra").Value),
                    IdProducto = int.Parse(x.Element("IDProducto").Value),
                    Cantidad = int.Parse(x.Element("Cantidad").Value),
                    PrecioUnitario = decimal.Parse(x.Element("PrecioUnitario").Value),
                    Producto = productos.FirstOrDefault(p => p.ID == int.Parse(x.Element("IDProducto").Value)),
                    OrdenCompra = ordenesCompra.FirstOrDefault(o => o.ID == int.Parse(x.Element("IDOrdenCompra").Value))
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar consultar los detalles de la orden de compra: {ex.Message}", ex);
            }
        }

        private int GenerarNuevoID(XDocument docXml)
        {
            try
            {
                return docXml.Descendants("DetalleOrdenCompra")
                    .Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar generar un nuevo ID para el detalle de la orden de compra: {ex.Message}", ex);
            }
        }

        public List<BE_DetalleOrdenCompra> ConsultarPorOrden(int idOrden)
        {
            return Consultar().Where(x => x.IdOrdenCompra == idOrden).ToList();
        }
    }
}
