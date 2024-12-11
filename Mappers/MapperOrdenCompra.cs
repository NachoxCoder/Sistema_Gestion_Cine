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
    public class MapperOrdenCompra : MapperBase<BE_OrdenCompra>, IAbmc<BE_OrdenCompra>
    {
        private const string ARCHIVO_ORDEN_COMPRA = @"\DATA\OrdenCompra.xml";
        private readonly MapperProveedor mapperProveedor;
        private readonly MapperDetalleOrdenCompra mapperDetalle;

        public MapperOrdenCompra() : base(ARCHIVO_ORDEN_COMPRA)
        {
            mapperProveedor = new MapperProveedor();
            mapperDetalle = new MapperDetalleOrdenCompra();
        }

        public bool Borrar(BE_OrdenCompra pOrdenCompra)
        {
            try
            {
                XDocument docXML = XDocument.Load(ARCHIVO_ORDEN_COMPRA);

                var orden = docXML.Descendants("OrdenCompra").
                    FirstOrDefault(x => int.Parse(x.Attribute("IdOrdenCompra").Value) == pOrdenCompra.ID);

                if(orden != null)
                {
                    foreach (var detalle in pOrdenCompra.Detalles)
                    {
                        mapperDetalle.Borrar(detalle);
                    }

                    orden.Remove();
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

        private int GenerarNuevoId(XDocument docXML)
        {
            return docXML.Descendants("OrdenCompra")
                .Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }

        public bool Guardar(BE_OrdenCompra pOrdenCompra)
        {
            try
            {
                XDocument docXML = CargarXml();

                if (pOrdenCompra.ID == 0)
                {
                    pOrdenCompra.ID = GenerarNuevoId(docXML);

                    var nuevaOrden = new XElement("OrdenCompra",
                        new XAttribute("ID", pOrdenCompra.ID),
                        new XElement("IdProveedor", pOrdenCompra.IdProveedor),
                        new XElement("Total", pOrdenCompra.TotalOrdenCompra.ToString("F2")),
                        new XElement("FechaOrden", pOrdenCompra.FechaOrdenCompra.ToString("yyyy-MM-dd")),
                        new XElement("EstadoOrden", pOrdenCompra.EstadoOrdenCompra));

                    docXML.Root.Add(nuevaOrden);

                    foreach (var detalle in pOrdenCompra.Detalles)
                    {
                        detalle.IdOrdenCompra = pOrdenCompra.ID;
                        mapperDetalle.Guardar(detalle);
                    }
                }
                else 
                {
                    var orden = docXML.Descendants("OrdenCompra").
                        FirstOrDefault(x => int.Parse(x.Attribute("IdOrdenCompra").Value) == pOrdenCompra.ID);

                    if (orden != null)
                    {
                        orden.Element("Total").Value = pOrdenCompra.TotalOrdenCompra.ToString("F2");
                        orden.Element("EstadoOrden").Value = pOrdenCompra.EstadoOrdenCompra;
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

        public List<BE_OrdenCompra> Consultar()
        {
            try
            {
                XDocument docXML = CargarXml();
                var proveedores = mapperProveedor.Consultar();

                var ordenes = docXML.Descendants("OrdenCompra").Select(x => new BE_OrdenCompra
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdProveedor = int.Parse(x.Element("IdProveedor").Value),
                    TotalOrdenCompra = decimal.Parse(x.Element("Total").Value),
                    FechaOrdenCompra = DateTime.Parse(x.Element("FechaOrden").Value),
                    EstadoOrdenCompra = x.Element("EstadoOrden").Value,
                }).ToList();

                foreach (var orden in ordenes)
                {
                    orden.Proveedor = proveedores.FirstOrDefault(p => p.ID == orden.IdProveedor);
                    orden.Detalles = mapperDetalle.ConsultarPorOrden(orden.ID);
                }
                return ordenes;
            }
            catch
            {
                return new List<BE_OrdenCompra>();
            }
        }
    }
}
